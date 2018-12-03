-- Selects Básicos
select * from tipos_enderecos;
select * from enderecos;
select * from instituicoes;
select * from pessoas;
select * from tipos_usuarios;
select * from usuarios;
select * from tipos_eventos;
select * from eventos;
select * from turmas;
select * from totens;
select * from tipos_identificadores;
select * from identificadores;
select * from horarios_eventos;
select * from tipos_insercoes;
select * from sessoes;
select * from presencas;
select * from planos;
select * from pagamentos;

-- selects com Inner Join

select usu_codigo, pes_codigo, ins_codigo, tus_codigo from usuarios as a inner join pessoas using (pes_codigo)
inner join tipos_usuarios using (tus_codigo)
where a.usu_login = "cunha" and a.usu_senha = "oi";

select * from usuarios inner join pessoas using (pes_codigo) 
inner join enderecos using(end_codigo)
where pes_codigo = "1";


select usu_codigo, pes_codigo, ins_codigo, tus_codigo from usuarios as a inner join pessoas using (pes_codigo) inner join tipos_usuarios using (tus_codigo) where a.usu_login = "rafael" and a.usu_senha = "oi";



-- inserts

INSERT INTO tipos_usuarios (`tus_titulo`) VALUES ('Gerente Geral');

INSERT INTO pessoas (`pes_nome`, `pes_sobrenomes`, `pes_cpf`, `pes_rg`, `pes_matricula`, `pes_sexo`, `pes_tel_residencial`, `pes_tel_celular`, `pes_info_adicionais`, `end_codigo`, `ins_codigo`) 
VALUES ('Rafael', 'Alcântara', '456', '654', 'oioi2', '1', '0000-0000', '90000-0000', '321', '1', '4');

INSERT INTO usuarios (`usu_login`, `usu_senha`, `usu_estado`, `usu_data_criacao`, `usu_data_desativacao`, `usu_primeiro_login`, `usu_redefinir_senha`, `pes_codigo`, `tus_codigo`) 
VALUES ('rafael', 'oi', '1', '2018-01-12 00:00:00', '0001-01-01 00:00:00', '0', '0', '2', '2');

-- Outros
alter table pagamentos change pag_data_criação pag_data_criacao datetime;

	
ALTER TABLE enderecos ADD end_cep int AFTER end_municipio;

insert into tipos_enderecos(ten_titulo) value("Professor"); SELECT LAST_INSERT_ID();

delete from enderecos;