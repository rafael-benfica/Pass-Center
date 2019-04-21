

-- Precedure InserirPresenca
drop procedure if exists InserirPresenca;

DELIMITER $
CREATE PROCEDURE `InserirPresenca`(in vEau_codigo int, in vPes_codigo int, in list_of_ids text, in vPre_horario_entrada datetime, in vPre_horario_saida datetime, in vSes_codigo int)  
	BEGIN
			-- Declaracoes
			declare _ide_identificador int;
			declare i INT;
			declare total INT;
			
			-- inicializacao
			set i = 0;
			set total = 0;
			
			-- Criando Tabela temporaria e realizando insercao dos IDs que não devem receber presencas
			create temporary table if not exists participantes_ausentes(id text);
			set @sql = concat('insert into participantes_ausentes (id) values',list_of_ids,'');
			PREPARE stmt1 FROM @sql;
			EXECUTE stmt1;
		
		BEGIN
			-- Declaracao do Cursor
			declare c1 cursor for select ide_identificador from turmas
			inner join eventos_auditores eau using (eau_codigo)
			inner join usuarios usu using (usu_codigo)
			inner join identificadores using (usu_codigo)
			where eau_codigo = vEau_codigo and eau.pes_codigo = vPes_codigo and usu.usu_codigo not in (select * from participantes_ausentes);
		
			-- Inserindo o total de registro na variavel de controle
			select count(*) into total from turmas
			inner join eventos_auditores eau using (eau_codigo)
			inner join usuarios usu using (usu_codigo)
			where eau_codigo = vEau_codigo and eau.pes_codigo = vPes_codigo and usu.usu_codigo not in (select * from participantes_ausentes);
			
			open c1;
				while i<total do
                
					-- varrendo registro por registro
					fetch c1 into _ide_identificador;
                    -- Inserindo presenca
					INSERT INTO presencas VALUES (vSes_codigo, _ide_identificador, vPre_horario_entrada, vPre_horario_saida, 0);
					set i = i + 1;
				
				end while;
			close c1;
            
            -- Deletando tabela temporaria
            drop temporary table participantes_ausentes;
        END;
	END;
$


-- Precedure MigrarAno
drop procedure if exists MigrarAno;

delimiter $
CREATE PROCEDURE MigrarAno(in vInstituicao int, in vPeriodo varchar(45))
begin
	declare _eau_codigo INT;
	declare _eau_periodo_identificacao VARCHAR(45);
	declare _eau_estado TINYINT;
	declare _eau_data_abertura DATETIME;
	declare _eau_data_fechamento DATETIME;
	declare _pes_codigo INT;
	declare _eve_codigo INT;
	declare _ins_codigo INT;

	declare i INT;
	declare total INT;

	declare c1 cursor for select * from enventos_auditores where ins_codigo = vInstituicao and eau_estado = 1;

	set i = 0;
	set total = 0;

	select count(*) into total from enventos_auditores where ins_codigo = vInstituicao and eau_estado = 1;


	open c1;
		while i<total do
			fetch c1 into _eau_codigo, _eau_periodo_identificacao, _eau_estado, _eau_data_abertura, 
			_eau_data_fechamento, _pes_codigo, _eve_codigo, _ins_codigo;
			
			update enventos_auditores set eau_estado = 0, eau_data_fechamento = NOW() where eau_codigo = _eau_codigo;
			
			insert into enventos_auditores values (0, vPeriodo, 1, NOW(), null, _pes_codigo, _eve_codigo, _ins_codigo);
			
		   set i = i + 1;
		
		end while;
	close c1;
end
$