drop procedure InserirPresenca;

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
			where eau_codigo = _eau_codigo and eau.pes_codigo = _pes_codigo and usu.usu_codigo not in (select * from participantes_ausentes);
			
			open c1;
				while i<total do
                
					-- varrendo registro por registro
					fetch c1 into _ide_identificador;
                    -- Inserindo presenca
					INSERT INTO presencas VALUES ('0', vPre_horario_entrada, vPre_horario_saida, 0, _ide_identificador, vSes_codigo);
					set i = i + 1;
				
				end while;
			close c1;
            
            -- Deletando tabela temporaria
            drop temporary table teste;
        END;
	END;
$

call InserirPresenca(1, 4,'(6)', '00:00:01', 1);