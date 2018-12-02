-- Selects Básicos
select * from tipos_enderecos;
select * from enderecos inner join tipos_enderecos using(ten_codigo);
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

select usu_codigo, ins_codigo, tus_codigo from usuarios as a inner join pessoas using (pes_codigo)
inner join tipos_usuarios using (tus_codigo)
where a.usu_login = "cunha" and a.usu_senha = "oi";



-- Outros
alter table pagamentos change pag_data_criação pag_data_criacao datetime;

insert into tipos_enderecos(ten_titulo) value("Professor"); SELECT LAST_INSERT_ID();

delete from enderecos;