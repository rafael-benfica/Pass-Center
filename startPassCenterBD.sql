use passcenter;

INSERT INTO tipos_usuarios (`tus_titulo`) VALUES ('administrador');

INSERT INTO tipos_usuarios (`tus_titulo`) VALUES ('aluno');

INSERT INTO tipos_enderecos (`ten_titulo`) VALUES ('instituição');

INSERT INTO tipos_enderecos (`ten_titulo`) VALUES ('pessoa');

INSERT INTO enderecos(end_logradouro, end_numero, end_bairro, end_municipio, end_cep, end_estado, end_complemento, end_pais, ten_codigo)
VALUES('rua', 'numero', 'bairro', 'municipio', '00000000', '1', 'complemento', 'pais', '1');

INSERT INTO instituicoes(ins_nome_fantasia, ins_razao_social, ins_inscricao_estadual, ins_cnpj, ins_estado, ins_periodo_renovacao_dias, end_codigo)
VALUES('Nome Fantasia', 'Razão Social', 'Inscrição Estadual', '00.000.000/0000-00', '1', '30', '1');

INSERT INTO enderecos(end_logradouro, end_numero, end_bairro, end_municipio, end_cep, end_estado, end_complemento, end_pais, ten_codigo)
VALUES('rua', 'numero', 'bairro', 'municipio', '00000000', '1', 'complemento', 'pais', '2');

INSERT INTO pessoas (pes_nome, pes_sobrenomes, pes_cpf, pes_rg, pes_matricula, pes_sexo, pes_tel_residencial, pes_tel_celular, pes_info_adicionais, end_codigo, ins_codigo) 
VALUES ('João', 'Silva', '000.000.000-00', '00.000.000-0', '0000000', '1', '0000-0000', '90000-0000', 'Informações Adicionais','2', '1');

INSERT INTO usuarios (usu_login, usu_senha, usu_estado, usu_data_criacao, usu_data_desativacao, usu_primeiro_login, usu_redefinir_senha, pes_codigo, tus_codigo) 
VALUES ('joao', 'oi', '1', '2018-01-12 00:00:00', '0001-01-01 00:00:00', '0', '0', '1', '1');
