//Bibliotecas Utilizadas

//ESP32
#include <WiFi.h> // ESP32 Core WiFi
#include <SPI.h>  // Necessaria para utilizar o MFRC522
#include <Wire.h> // Necessaria para comunicação do I2C com o LiquidCrystal
#include <HTTPClient.h>

//ArduinoJson
#include <ArduinoJson.h> //Realiza o tratamento dos JSONs recebidos e enviados

//WiFiManager
#include <DNSServer.h>   //Local DNS Server used for redirecting all requests to the configuration portal ( https://github.com/zhouhan0126/DNSServer---esp32 )
#include <WebServer.h>   //Local WebServer used to serve the configuration portal ( https://github.com/zhouhan0126/WebServer-esp32 )
#include <WiFiManager.h> //WiFi Configuration Magic ( https://github.com/tzapu/WiFiManager/tree/development ) >> https://github.com/tzapu/WiFiManager (ORIGINAL)

//MFRC522 - leitor RFID
#include <MFRC522.h> //MFRC522 ( https://github.com/miguelbalboa/rfid )

//LiquidCrystal I2C
#include <LiquidCrystal_I2C.h> //LiquidCrystal I2C ( https://github.com/fdebrabander/Arduino-LiquidCrystal-I2C-library )

//Config Totem
static String versao = "0.1";                   //Indica a versão do Fimewae
static String api = "http://192.168.0.70/api/"; //Indica o endereço base do servidor API
static bool debug = false;                      //Flag para ativar/desativar debug
bool shouldSaveConfig = false;                  //Flag para indicar se foi salva uma nova configuração de rede

//Pinos
const int PIN_AP = 2;   //Botão para abrir o Assitente de configuração do WiFi
const int PIN = 18;     //LED indicador
const int SS_PIN = 5;   //Pino para o MFRC522 - Conectado ao pino D5 do ESP32
const int RST_PIN = 36; //Pino para o MFRC522 - Conectado ao pino VP do ESP32

//variáveis que indicam os núcleos
static uint8_t nucleoZero = 0;
static uint8_t nucleoUm = 1;

//variáveis do sistema
int estado = 0; /*  0 = Totem Genério: Aguardando especialização | Operacional;
                    1 = Totem Especializado: Sessão inicializada pelo auditor | Aguaradando entrada dos participantes;
                    3 = Totem Especializado: Sessão finalizada pelo auditor | Desespecializando Totem;
                    4 = Totem Especializado: Modo Cadastro;
                    5 = Totem Genério: Em erro
                */
String RFIDmaster = "";
String token = "";
int sessao;

//Declarando Objetos
LiquidCrystal_I2C lcd(0x3F, 16, 2); //Cria uma instância do Display LCD (definindo o endereço do display, linhas e colunas)
MFRC522 mfrc522(SS_PIN, RST_PIN);   //Cria uma instância MFRC522.
WiFiManager wifiManager;            //declaração do objeto wifiManager

void setup()
{

  Serial.begin(115200); //Inicializando o Monitor Serial

  Serial.println("");

  Serial.println("                      ################################");
  Serial.println("                      #                              #");
  Serial.println("                      #      PassCenter - Totem      #");
  Serial.println("                      #        Fimeware v" + versao + "         #");
  Serial.println("                      #                              #");
  Serial.println("                      ################################");

  Serial.println("");

  Serial.println("############################### Inicialização ##################################");
  pinMode(PIN_AP, INPUT);
  pinMode(PIN, OUTPUT);
  digitalWrite(PIN, HIGH); //Acende o LED Indicador
  Serial.println("                      => Configurador: Inicializado... <=                       ");

  Serial.println("               => Configurador: WifiManager - Configurando... <=                ");

  // Configurando WifiManager
  wifiManager.setDebugOutput(debug);                         //Por padrão as mensagens de Debug vão aparecer no monitor serial, caso queira desabilitá-la modifique a flag
  wifiManager.setAPCallback(configModeCallback);             //Callback para quando entra em modo de configuração AP
  wifiManager.setSaveConfigCallback(saveConfigCallback);     //Callback para quando se conecta em uma rede, ou seja, quando passa a trabalhar em modo estação
  wifiManager.autoConnect("PassCenter - Totem", "12345678"); //Cria uma rede sem senha

  Serial.println("                 => Configurador: WifiManager - Executado! <=                   ");
  Serial.println("                => Configurador: Inicializando Componentes... <=                ");

  lcd.begin(); //Inicializando o Display LCD

  Serial.println("                 => Configurador: Display LCD Inicializado!  <=                 ");

  SPI.begin(); //Inicia SPI

  Serial.println("                     => Configurador: SPI Inicializado!  <=                     ");

  mfrc522.PCD_Init(); //Inicia MFRC522

  Serial.println("                   => Configurador: MFRC522 Inicializado!  <=                   ");
  Serial.println("                 => Configurador: Componentes Inicializados! <=                 ");
  Serial.println("                     => Configurador: Rotina executada! <=                      ");
  Serial.println("################################################################################");
  digitalWrite(PIN, LOW); //Apaga o LED indicador

  if (digitalRead(PIN_AP) == HIGH)
  {
    resetWiFI();
  }

  Serial.println("");

  Serial.println("############################### Inicialização ##################################");
  Serial.println("                         => Self test: Inicializado <=                          ");
  mfrc522.PCD_DumpVersionToSerial(); // Mostra a versão do PCD - MFRC522 Card Reader
  Serial.println("                         => Self test: Finalizado! <=                           ");
  Serial.println("################################################################################");

  //cria uma tarefa que será executada na função checarRFID, com prioridade 1 e execução no núcleo 1
  xTaskCreatePinnedToCore(
      checarRFID,   /* função que implementa a tarefa */
      "checarRFID", /* nome da tarefa */
      10000,        /* número de palavras a serem alocadas para uso com a pilha da tarefa */
      NULL,         /* parâmetro de entrada para a tarefa (pode ser NULL) */
      1,            /* prioridade da tarefa (0 a N) */
      NULL,         /* referência para a tarefa (pode ser NULL) */
      nucleoUm);    /* Núcleo que executará a tarefa */

  delay(500); //tempo para a tarefa iniciar
}

void loop() {}

//Task de leitura de RFID
void checarRFID(void *pvParameters)
{
  while (true)
  {
    bool controle = true;
    if (!mfrc522.PICC_IsNewCardPresent())
    { // Procura por novos cartões
      controle = false;
    }

    if (!mfrc522.PICC_ReadCardSerial())
    { // Reenicia a leitura
      controle = false;
    }
    if (controle)
    {

      String conteudo = "";
      byte letra;
      // Rotina para despejar a matriz de bytes com os valores hexadecimais para Serial.
      for (byte i = 0; i < mfrc522.uid.size; i++)
      {
        conteudo.concat(String(mfrc522.uid.uidByte[i] < 0x10 ? " 0" : " "));
        conteudo.concat(String(mfrc522.uid.uidByte[i], HEX));
      }

      conteudo.trim();

      switch (estado)
      {
      case 0:
        requisicaoPessoa(conteudo);
        if (estado == 1)
        {
          requisicaoAuditor();
        }
        else if (estado == 4)
        {
          Serial.println("É Gerente de Cadastro");
        }
        else
        {
          Serial.println("RFID não Autorizado!");
        }
        break;
      case 1:
        if (conteudo == RFIDmaster)
        {
          RFIDmaster = "";
          estado = 0;
          Serial.println("Saiu!");
        }
        else
        {
          gerarPresenca(conteudo);
        }
        break;
      case 4:
        if (conteudo == RFIDmaster)
        {
          RFIDmaster = "";
          estado = 0;
          Serial.println("Saiu!");
        }
      }
      delay(1000);
    }
  }
}

void resetWiFI()
{

  Serial.println("");
  Serial.println("############################### Assistente de Rede ##############################");
  Serial.println("                   => Assistente de Rede: Aguardando Conexão <=                  ");
  digitalWrite(PIN, HIGH);
  delay(1000);
  digitalWrite(PIN, LOW);

  if (!wifiManager.startConfigPortal("PassCenter - Totem", "12345678"))
  {

    Serial.println("                         => Assistente Encerrado! <=                            ");

    Serial.println("###############################################################################");

    ESP.restart();
  }

  digitalWrite(PIN, HIGH);
  delay(10000);
  digitalWrite(PIN, LOW);
  Serial.println("             => Totem conectado com Sucesso a um ponto de Acesso! <=             ");
  Serial.println("                             => Assistente Encerrado! <=                          ");
  Serial.println("#################################################################################");
}

void requisicaoPessoa(String RFID)
{

  if ((WiFi.status() == WL_CONNECTED)) //Verifica o estado de rede do Totem
  {
    Serial.println();
    Serial.println("############################ Indentifica Pessoa ###############################");
    Serial.println();
    Serial.println("                       => ID do objeto: " + String(RFID) + " <=                     "); // Mostra o valor de ID

    //Cria o JSON para o envio
    DynamicJsonDocument credenciais(128);

    credenciais["usu_login"] = RFID;
    String requisicao;
    serializeJson(credenciais, requisicao);

    HTTPClient http; // Declaração do objeto para a requisição HTTP

    http.begin(api + "Tokens/Totem");                   //Endereço para a requisição HTTP
    http.addHeader("Content-Type", "application/json"); //Especifica content-type do cabeçalho
    int httpCode = http.POST(requisicao);

    Serial.println("                          => Resposta HTTP: " + String(httpCode) + "  <=          "); // Mostra a resposta HTTP da requisição

    if (httpCode == 200) //Verifica o código de retorno
    {
      String payload = http.getString(); //Converte o retorno da requisição para String

      Serial.println("                     => Início da resposta da Requisição <=                     ");
      Serial.println(payload);
      Serial.println("                       => Fim da resposta da Requisição <=                      ");

      DynamicJsonDocument doc(256); //Aloca memória para converter o JSON

      char json[payload.length()];                 //Instancia um Array de Chars
      payload.toCharArray(json, payload.length()); //Converte o conteu do payload para o Array

      deserializeJson(doc, json); //Realiza a conversão do Json

      const char *tokenJ = doc[0];
      const char *tipoJ = doc[1];
      const char *nomeJ = doc[2];

      token = String(tokenJ);

      Serial.println();
      Serial.println("Olá, " + String(nomeJ));
      Serial.println("O tipo do seu usuário é: " + String(tipoJ));
      Serial.println("O seu token de segurança é: " + token);
      Serial.println();

      RFIDmaster = RFID; // Define o Objeto RFID Master

      if (String(tipoJ) == "4")
      {
        estado = 1;
        Serial.println("         => Totem Especializado (1): Sessão inicializada pelo auditor <=        ");
      }
      else if (String(tipoJ) == "3")
      {
        estado = 4;
        Serial.println("                 => Totem Especializado (4): Modo Cadastro; <=                  ");
      }
    }

    else
    {
      Serial.println("    => Erro Durante a requisição HTTP: " + String(httpCode) + "  <=             "); // Mostra a resposta HTTP da requisição
    }
    http.end(); //Libera os recursos alocados
    Serial.println("################################################################################");
  }
}

void requisicaoAuditor()
{
  if ((WiFi.status() == WL_CONNECTED)) //Verifica o estado de rede do Totem
  {
    Serial.println();
    Serial.println("############################ Requisição Auditor ################################");
    Serial.println();

    HTTPClient http;                                    // Declaração do objeto para a requisição HTTP
    http.begin(api + "Totens/Disciplinas");             //Endereço para a requisição HTTP
    http.addHeader("Content-Type", "application/json"); //Especifica content-type do cabeçalho
    http.addHeader("Authorization", token);             //Especifica content-type do cabeçalho
    int httpCode = http.GET();                          //Realiza a requisição HTTP

    Serial.println("                            => Resposta HTTP: " + String(httpCode) + "  <=          "); // Mostra a resposta HTTP da requisição

    if (httpCode == 200) //Verifica o código de retorno
    {

      String payload = http.getString(); //Converte o retorno da requisição para String

      Serial.println("                   => Início da resposta da Requisição <=                       ");
      Serial.println(payload);
      Serial.println("                    => Fim da resposta da Requisição <=                         ");

      DynamicJsonDocument doc(256); //Aloca memória para converter o JSON

      char json[payload.length()];                 //Instancia um Array de Chars
      payload.toCharArray(json, payload.length()); //Converte o conteu do pauload para o Array

      deserializeJson(doc, json); //Realiza a conversão do Json

      JsonObject disciplinas = doc[0];
      JsonObject root_0 = doc[0];

      int eau_codigo = disciplinas["eau_codigo"];                                       // 1
      const char *eve_sigla = disciplinas["eve_sigla"];                                 // "Mat01"
      const char *eau_periodo_identificacao = disciplinas["eau_periodo_identificacao"]; // "Matemática 01"

      Serial.println("Sigla: " + String(eau_codigo));
      Serial.println("Sigla: " + String(eve_sigla));
      Serial.println("Nome: " + String(eau_periodo_identificacao));

      criaSessao(eau_codigo);
    }

    else
    {
      Serial.println("    => Erro Durante a requisição HTTP: " + String(httpCode) + "  <=             "); // Mostra a resposta HTTP da requisição
    }
    http.end(); //Libera os recursos alocados

    Serial.println("##############################################################################");
  }
}

void criaSessao(int disciplina)
{

  if ((WiFi.status() == WL_CONNECTED)) //Verifica o estado de rede do Totem
  {
    Serial.println();
    Serial.println("############################### Cria Sessão ##################################");

    //Cria o JSON para o envio
    DynamicJsonDocument dados(128);

    JsonObject eau_codigo = dados.createNestedObject("eau_codigo");
    eau_codigo["eau_codigo"] = disciplina;
    JsonObject hev_codigo = dados.createNestedObject("hev_codigo");
    hev_codigo["hev_codigo"] = "1";
    JsonObject tot_codigo = dados.createNestedObject("tot_codigo");
    tot_codigo["tot_codigo"] = "1";

    String requisicao;
    serializeJson(dados, requisicao);

    HTTPClient http; // Declaração do objeto para a requisição HTTP

    http.begin(api + "Totens/Sessoes");                 //Endereço para a requisição HTTP
    http.addHeader("Content-Type", "application/json"); //Especifica content-type do cabeçalho
    http.addHeader("Authorization", token);             //Especifica content-type do cabeçalho
    int httpCode = http.POST(requisicao);

    Serial.println("                          => Resposta HTTP: " + String(httpCode) + "  <=          "); // Mostra a resposta HTTP da requisição

    if (httpCode == 200) //Verifica o código de retorno
    {
      String payload = http.getString(); //Converte o retorno da requisição para String

      Serial.println("                     => Início da resposta da Requisição <=                     ");
      Serial.println(payload);
      Serial.println("                       => Fim da resposta da Requisição <=                      ");

      sessao = payload.toInt();
      Serial.println();

      Serial.println("O código da sessão é:" + String(sessao));
      Serial.println();
    }

    else
    {
      Serial.println("    => Erro Durante a requisição HTTP: " + String(httpCode) + "  <=             "); // Mostra a resposta HTTP da requisição
    }
    http.end(); //Libera os recursos alocados
    Serial.println("##############################################################################");
    Serial.println();
  }
}

void gerarPresenca(String RFID)
{

  if ((WiFi.status() == WL_CONNECTED)) //Verifica o estado de rede do Totem
  {
    Serial.println();
    Serial.println("################################ Preseça ####################################");
    Serial.println();
    Serial.println("                       => ID do objeto: " + String(RFID) + " <=                     "); // Mostra o valor de ID

    //Cria o JSON para o envio
    DynamicJsonDocument dados(256);

    JsonObject Ses_codigo = dados.createNestedObject("Ses_codigo");
    Ses_codigo["Ses_codigo"] = sessao;
    JsonObject Ide_codigo = dados.createNestedObject("Ide_codigo");
    Ide_codigo["ide_identificador"] = RFID;

    String requisicao;

    serializeJson(dados, requisicao);

    Serial.println(requisicao);
    HTTPClient http; // Declaração do objeto para a requisição HTTP

    http.begin(api + "Totens/Presenca");                //Endereço para a requisição HTTP
    http.addHeader("Content-Type", "application/json"); //Especifica content-type do cabeçalho
    http.addHeader("Authorization", token);             //Especifica content-type do cabeçalho
    int httpCode = http.POST(requisicao);

    Serial.println("                          => Resposta HTTP: " + String(httpCode) + "  <=          "); // Mostra a resposta HTTP da requisição

    if (httpCode == 200) //Verifica o código de retorno
    {
      Serial.println("                                    => Presença OK <=                                     ");
    }

    else
    {
      Serial.println("    => Erro Durante a requisição HTTP: " + String(httpCode) + "  <=             "); // Mostra a resposta HTTP da requisição
    }
    http.end(); //Libera os recursos alocados
    Serial.println("##############################################################################");
    Serial.println();
  }
}

//callback que indica que o ESP entrou no modo AP
void configModeCallback(WiFiManager *myWiFiManager)
{
  Serial.println(WiFi.softAPIP());                      //imprime o IP do AP
  Serial.println(myWiFiManager->getConfigPortalSSID()); //imprime o SSID criado da rede
}

//callback que indica que salvamos uma nova rede para se conectar (modo estação)
void saveConfigCallback()
{
  Serial.println("#                           Configurações Salvas !                             #");
  Serial.println(WiFi.softAPIP()); //imprime o IP do AP
}
