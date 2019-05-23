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
static String versao = "0.1";                                                               //Indica a versão do Fimewae
static String api = "http://my-json-server.typicode.com/RafaABSilva/PassCenterJSONServer/"; //Indica o endereço base do servidor API
static bool debug = false;                                                                  //Flag para ativar/desativar debug
bool shouldSaveConfig = false;                                                              //Flag para indicar se foi salva uma nova configuração de rede

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
  Serial.println("                      #      PassCeter - Totem       #");
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
  Serial.println("#                           Self test: Inicializado                            #");
  mfrc522.PCD_DumpVersionToSerial(); // Mostra a versão do PCD - MFRC522 Card Reader
  Serial.println("#                           Self test: Finalizado!                             #");
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

      switch (estado)
      {
      case 0:
        requisicaoPessoa(conteudo);
        if(estado==1){
          requisicaoAuditor();
        } else{
          Serial.println("É Gerente de Cadastro");
        }
        break;
      case 1:
        if (conteudo == RFIDmaster)
        {
          RFIDmaster="";
          estado = 0;
          Serial.println("Saiu!");
        }
        else
        {
          Serial.println();
          Serial.println("ID do objeto: " + conteudo); // Mostra o valor de ID
        }
        break;
      }
      delay(1000);
    }
  }
}

void resetWiFI()
{

  Serial.println("");
  Serial.println("############################### Assistete de Rede ##############################");
  Serial.println("                   => Assistete de Rede: Aguardando Conexao <=                  ");
  digitalWrite(PIN, HIGH);
  delay(1000);
  digitalWrite(PIN, LOW);

  if (!wifiManager.startConfigPortal("PassCenter - Totem", "12345678"))
  {

    Serial.println("                          => Assistete Encerrado! <=                            ");

    Serial.println("################################################################################");

    ESP.restart();
  }

  digitalWrite(PIN, HIGH);
  delay(10000);
  digitalWrite(PIN, LOW);
  Serial.println("             => Totem conectado com Sucesso a um ponto de Acesso! <=            ");
  Serial.println("                             => Assistete Encerrado! <=                         ");
  Serial.println("################################################################################");
}

void requisicaoPessoa(String RFID)
{
  if ((WiFi.status() == WL_CONNECTED)) //Verifica o estado de rede do Totem
  {
    Serial.println("############################### Indentifica Pessoa ##############################");
    Serial.println();
    Serial.println("                           => ID do objeto: " + String(RFID) + " <=                         "); // Mostra o valor de ID


    HTTPClient http;            // Declaração do objeto para a requisição HTTP
    http.begin(api + "pessoa"); //Endereço para a requisição HTTP
    int httpCode = http.GET();  //Realiza a requisição HTTP
    
    Serial.println("                         => Resposta HTTP: " + String(httpCode) + "  <=                       "); // Mostra a resposta HTTP da requisição
    
    if (httpCode == 200) //Verifica o código de retorno
    {
      String payload = http.getString(); //Converte o retorno da requisição para String
      
      Serial.println("                     => Início da resposta da Requisição <=                     ");
      Serial.println(payload);
      Serial.println("                       => Fim da resposta da Requisição <=                      ");
      

      const size_t capacity = JSON_OBJECT_SIZE(2) + 30; //Determina a quantidade de memória para a ser alocada para converter o JSON
      DynamicJsonDocument doc(capacity);                //Aloca memória para converter o JSON

      char json[payload.length()];                 //Instancia um Array de Chars
      payload.toCharArray(json, payload.length()); //Converte o conteu do pauload para o Array

      deserializeJson(doc, json); //Realiza a conversão do Json

      const char *pes_nome = doc["pes_nome"];
      int tus_codigo = doc["tus_codigo"];

      http.end(); //Libera os recursos alocados

      Serial.println();
      Serial.println("Olá, " + String(pes_nome));
      Serial.println("O tipo do seu usuário é: " + tus_codigo);
      Serial.println();

      RFIDmaster = RFID; // Define o Objeto RFID Master
      
      if (tus_codigo == 4)
      {
        estado = 1;
        Serial.println("         => Totem Especializado (1): Sessão inicializada pelo auditor <=        ");
        
      }
      else if (tus_codigo == 3)
      {
        estado = 4;
        Serial.println("                 => Totem Especializado (4): Modo Cadastro; <=                  ");
      }
      
    }

    else
    {
      http.end(); //Libera os recursos alocados
      Serial.println("                 => Erro Durante a requisição HTTP: " + String(httpCode) + "  <=                  "); // Mostra a resposta HTTP da requisição
    }
    Serial.println("################################################################################");
  }
}

void requisicaoAuditor()
{
  if ((WiFi.status() == WL_CONNECTED)) //Verifica o estado de rede do Totem
  {

Serial.println("############################### Requisição Auditor ##############################");
    Serial.println();


    HTTPClient http;            // Declaração do objeto para a requisição HTTP
    http.begin(api + "disciplinas"); //Endereço para a requisição HTTP
    int httpCode = http.GET();  //Realiza a requisição HTTP
    
    Serial.println("                         => Resposta HTTP: " + String(httpCode) + "  <=                       "); // Mostra a resposta HTTP da requisição


    if (httpCode == 200) //Verifica o código de retorno
    {

      String payload = http.getString(); //Converte o retorno da requisição para String
      
      Serial.println("                     => Início da resposta da Requisição <=                     ");
      Serial.println(payload);
      Serial.println("                       => Fim da resposta da Requisição <=                      ");

      DynamicJsonDocument doc(1024); //Aloca memória para converter o JSON

      char json[payload.length()];                 //Instancia um Array de Chars
      payload.toCharArray(json, payload.length()); //Converte o conteu do pauload para o Array

      deserializeJson(doc, json); //Realiza a conversão do Json

      JsonObject disciplinas = doc[0];
      int disciplinas_eau_codigo = disciplinas["eau_codigo"];       // 1
      const char *disciplinas_eau_sigla = disciplinas["eau_sigla"]; // "Mat01"
      const char *disciplinas_eau_nome = disciplinas["eau_nome"];   // "Matemática 01"


      Serial.println("Sigla: " + disciplinas_eau_codigo);
      Serial.println("Sigla: " + String(disciplinas_eau_sigla));
      Serial.println("Nome: " + String(disciplinas_eau_nome));

      
      http.end(); //Libera os recursos alocados
    }

    else
    {
      http.end(); //Libera os recursos alocados
      Serial.println("                 => Erro Durante a requisição HTTP: " + String(httpCode) + "  <=                  "); // Mostra a resposta HTTP da requisição
    }
    Serial.println("################################################################################");
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
