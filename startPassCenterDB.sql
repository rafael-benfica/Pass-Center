use passcenter;

-- Inserindo Tipos de Usuários
INSERT INTO tipos_usuarios (`tus_titulo`) VALUES ('Administrador');
INSERT INTO tipos_usuarios (`tus_titulo`) VALUES ('Gerente Geral');
INSERT INTO tipos_usuarios (`tus_titulo`) VALUES ('Gerente Cadastro');
INSERT INTO tipos_usuarios (`tus_titulo`) VALUES ('Auditor');
INSERT INTO tipos_usuarios (`tus_titulo`) VALUES ('Aluno');


-- Inserindo Instituição
INSERT INTO enderecos(end_logradouro, end_numero, end_bairro, end_municipio, end_cep, end_estado, end_complemento, end_pais)
VALUES('Av. Prof. João Rodrigues', '1501', 'Jardim Esperança', 'Guaratinguetá', '12518150', 'SP', 'complemento', 'Brasil');
INSERT INTO instituicoes(ins_nome_fantasia, ins_razao_social, ins_inscricao_estadual, ins_cnpj, ins_estado, ins_periodo_renovacao_dias, end_codigo)
VALUES('FATEC Guaratinguetá', 'Faculdade de Tecnologia Estadual de Guaratinguetá', '000.000.000.000', '00.000.000-0000-00', '1', '30', '1');


-- Inserindo Tipos de Identificadores
INSERT INTO tipos_identificadores (tid_titulo) 
VALUES ('Cartão RFID');

-- Inserir Grade
INSERT INTO grades VALUES (0,'1º Ano - E.M.', 1);

-- Inserindo Usuários

-- Inserindo Administrador
INSERT INTO enderecos(end_logradouro, end_numero, end_bairro, end_municipio, end_cep, end_estado, end_complemento, end_pais)
VALUES('Rua Teerã', '930', 'Parque da Lapa', 'São Paulo', '05301000', '1', '', 'Brasil');

INSERT INTO pessoas (pes_nome, pes_sobrenomes, pes_data_nascimento, pes_cpf, pes_rg, pes_matricula, pes_sexo, pes_tel_residencial, pes_tel_celular, pes_info_adicionais, end_codigo, ins_codigo) 
VALUES ('Filipe', 'Márcio Ferreira', '1996-02-01', '240.436.648-34', '48.085.566-3', '1802010', '1', '(11) 2511-5724', '(11) 98403-6407', '','2', '1');

INSERT INTO usuarios (usu_login, usu_senha, usu_estado, usu_data_criacao, usu_data_desativacao, usu_primeiro_login, usu_redefinir_senha, pes_codigo, tus_codigo) 
VALUES ('adm@teste.com', '5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6', '1', '2018-01-12 00:00:00', '0001-01-01 00:00:00', '0', '0', '1', '1');

INSERT INTO identificadores (ide_estado, ide_identificador, usu_codigo, tid_codigo) 
VALUES ('1', '0001', '1', '1');

-- Inserindo Gerente Geral
INSERT INTO enderecos(end_logradouro, end_numero, end_bairro, end_municipio, end_cep, end_estado, end_complemento, end_pais)
VALUES('Rua Presidente João Café Filho', '592', 'Jardim Ipanema', 'Santo André', '09121680', 'SP', '', 'Brasil');

INSERT INTO pessoas (pes_nome, pes_sobrenomes, pes_data_nascimento, pes_cpf, pes_rg, pes_matricula, pes_sexo, pes_tel_residencial, pes_tel_celular, pes_info_adicionais, end_codigo, ins_codigo) 
VALUES ('Nicole', 'Bruna Aline Freitas', '1996-08-26', '309.127.538-89', '33.609.202-7', '1802020', '2', '(11) 2706-6469', '(11) 98193-4069', '','3', '1');

INSERT INTO usuarios (usu_login, usu_senha, usu_estado, usu_data_criacao, usu_data_desativacao, usu_primeiro_login, usu_redefinir_senha, pes_codigo, tus_codigo) 
VALUES ('geral@teste.com', '5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6', '1', '2018-01-12 00:00:00', '0001-01-01 00:00:00', '0', '0', '2', '2');

INSERT INTO identificadores (ide_estado, ide_identificador, usu_codigo, tid_codigo) 
VALUES ('1', '0002', '2', '1');

-- Inserindo Gerente Cadastro
INSERT INTO enderecos(end_logradouro, end_numero, end_bairro, end_municipio, end_cep, end_estado, end_complemento, end_pais)
VALUES('Rua Hugo Prado', '954', 'Jardim Amaralina', 'São Paulo', '05570210', 'SP', '', 'Brasil');

INSERT INTO pessoas (pes_nome, pes_sobrenomes, pes_data_nascimento, pes_cpf, pes_rg, pes_matricula, pes_sexo, pes_tel_residencial, pes_tel_celular, pes_info_adicionais, end_codigo, ins_codigo) 
VALUES ('Yuri', 'Felipe Castro', '1996-08-06', '536.525.748-00', '14.648.632-8', '1802030', '1', '(11) 2545-4040', '(11) 99272-4760', '','4', '1');

INSERT INTO usuarios (usu_login, usu_senha, usu_estado, usu_data_criacao, usu_data_desativacao, usu_primeiro_login, usu_redefinir_senha, pes_codigo, tus_codigo) 
VALUES ('cadastro@teste.com', '5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6', '1', '2018-01-12 00:00:00', '0001-01-01 00:00:00', '0', '0', '3', '3');

INSERT INTO identificadores (ide_estado, ide_identificador, usu_codigo, tid_codigo) 
VALUES ('1', '0003', '3', '1');

-- Inserindo Auditor
INSERT INTO enderecos(end_logradouro, end_numero, end_bairro, end_municipio, end_cep, end_estado, end_complemento, end_pais)
VALUES('Rua Fábio Tullio de Mattos', '481', 'Jardim Maria Amélia', 'Jacareí', '12318280', 'SP', '', 'Brasil');

INSERT INTO pessoas (pes_nome, pes_sobrenomes, pes_data_nascimento, pes_cpf, pes_rg, pes_matricula, pes_sexo, pes_tel_residencial, pes_tel_celular, pes_info_adicionais, end_codigo, ins_codigo) 
VALUES ('Bruna', 'Benedita Alessandra Drumond', '1996-01-08','730.056.198-50', '26.499.183-7', '1802040', '2', '(12) 2630-2701', '(12) 99159-8474', '','5', '1');

INSERT INTO usuarios (usu_login, usu_senha, usu_estado, usu_data_criacao, usu_data_desativacao, usu_primeiro_login, usu_redefinir_senha, pes_codigo, tus_codigo) 
VALUES ('auditor@teste.com', '5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6', '1', '2018-01-12 00:00:00', '0001-01-01 00:00:00', '0', '0', '4', '4');

INSERT INTO identificadores (ide_estado, ide_identificador, usu_codigo, tid_codigo) 
VALUES ('1', '0004', '4', '1');

-- Inserindo Aluno
INSERT INTO enderecos(end_logradouro, end_numero, end_bairro, end_municipio, end_cep, end_estado, end_complemento, end_pais)
VALUES('Rua Soldado Amarilho Gonçalves Queiroz', '302', 'Ponte Grande', 'Guarulhos', '07032200', 'SP', '', 'Brasil');

INSERT INTO pessoas (pes_nome, pes_sobrenomes, pes_data_nascimento, pes_cpf, pes_rg, pes_matricula, pes_sexo, pes_tel_residencial, pes_tel_celular, pes_info_adicionais, end_codigo, ins_codigo) 
VALUES ('Diego', 'Daniel Cardoso', '1996-11-07','313.172.158-85', '15.498.605-7', '1802050', '1', '(11) 2840-1247', '(11) 99614-1502', '','6', '1');

INSERT INTO usuarios (usu_login, usu_senha, usu_estado, usu_data_criacao, usu_data_desativacao, usu_primeiro_login, usu_redefinir_senha, pes_codigo, tus_codigo, gra_codigo) 
VALUES ('aluno@teste.com', '5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6', '1', '2018-01-12 00:00:00', '0001-01-01 00:00:00', '0', '0', '5', '5', '1');

INSERT INTO identificadores (ide_estado, ide_identificador, usu_codigo, tid_codigo) 
VALUES ('1', '0005', '5', '1');

-- Inserindo Aluno 2
INSERT INTO enderecos(end_logradouro, end_numero, end_bairro, end_municipio, end_cep, end_estado, end_complemento, end_pais)
VALUES('Rua Soldado Amarilho Gonçalves Queiroz', '302', 'Ponte Grande', 'Guarulhos', '07032200', 'SP', '', 'Brasil');

INSERT INTO pessoas (pes_nome, pes_sobrenomes, pes_data_nascimento, pes_cpf, pes_rg, pes_matricula, pes_sexo, pes_tel_residencial, pes_tel_celular, pes_info_adicionais, end_codigo, ins_codigo) 
VALUES ('Rodrigo', 'Daniel Cardoso', '1996-11-07','313.172.658-85', '15.598.605-7', '1803050', '1', '(11) 2840-1247', '(11) 99614-1502', '','6', '1');

INSERT INTO usuarios (usu_login, usu_senha, usu_estado, usu_data_criacao, usu_data_desativacao, usu_primeiro_login, usu_redefinir_senha, pes_codigo, tus_codigo, gra_codigo) 
VALUES ('aluno2@teste.com', '5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6', '1', '2018-01-12 00:00:00', '0001-01-01 00:00:00', '0', '0', '6', '5', '1');

INSERT INTO identificadores (ide_estado, ide_identificador, usu_codigo, tid_codigo) 
VALUES ('1', '0006', '6', '1');

-- Inserindo Tipos de Eventos
INSERT INTO tipos_eventos (`tev_titulo`) VALUES ('Disciplina');
INSERT INTO tipos_eventos (`tev_titulo`) VALUES ('Evento');

-- Inserindo Evento
INSERT INTO eventos (eve_nome, eve_sigla, eve_descricao, eve_estado, eve_operacao, tev_codigo, ins_codigo) VALUES ('Matemática 1', 'Mat01', 'Aprender a Somar e Subtrair', '1', '0', '1', '1');

INSERT INTO eventos_auditores (eau_periodo_identificacao, eau_estado, eau_data_abertura, pes_codigo, eve_codigo, ins_codigo) VALUES ('2018/01', '1', '2018-12-06', '4', '1', '1');

-- Inserindo Horario de Eventos
INSERT INTO horarios_eventos (hev_codigo, hev_data_hora, hev_estado, hev_dia_semana, eve_codigo) 
VALUES ('1', '0000-00-00 00:00:00', '1', 'Segunda-feira', '1');

-- Inserido Turmas
INSERT INTO turmas (usu_codigo, eau_codigo) 
VALUES ('5', '1'), ('6', '1');

-- Inserir Eventos Grades
INSERT INTO eventos_grades VALUES (1, 1);


-- Inserindo Sessao
INSERT INTO sessoes (ses_codigo, ses_horario_inicio , ses_horario_fim, ses_sessao_automatico, hev_codigo, eau_codigo) 
VALUES ('1', '0000-00-00 00:00:00', '0000-00-00 00:00:00', '0', '1', '1');