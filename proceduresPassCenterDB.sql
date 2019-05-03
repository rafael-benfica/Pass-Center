
-- Precedure MigrarAno
drop procedure if exists MigrarAno;

-- Precedure InserirPresenca
drop procedure if exists InserirPresenca;


DELIMITER $
CREATE PROCEDURE InserirPresenca (IN vEau_codigo INT, IN vPes_codigo INT, IN list_of_ids TEXT, IN vPre_horario_entrada DATETIME, IN vPre_horario_saida DATETIME, IN vSes_codigo INT)
BEGIN
			-- Declaracoes
			DECLARE _ide_identificador INT;
			DECLARE fim INT DEFAULT 0;
		
			-- Declaracao do Cursor
			DECLARE c1 CURSOR FOR SELECT ide_identificador FROM turmas
			INNER JOIN eventos_auditores eau USING (eau_codigo)
			INNER JOIN usuarios usu USING (usu_codigo)
			INNER JOIN identificadores USING (usu_codigo)
			WHERE eau_codigo = vEau_codigo AND eau.pes_codigo = vPes_codigo 
			AND FIND_IN_SET(usu.usu_codigo, list_of_ids) = 0;
            
			DECLARE CONTINUE HANDLER FOR NOT FOUND SET fim=1;
			SET fim = 0;
			
			OPEN c1;
			ideLoop:LOOP	
					-- varrendo registro por registro
					FETCH c1 INTO _ide_identificador;
					IF fim = 1 THEN LEAVE ideLoop; END IF;
					-- Inserindo presenca
					INSERT INTO presencas VALUES (vSes_codigo, _ide_identificador, vPre_horario_entrada, vPre_horario_saida, 0);
			END LOOP ideLoop;
			CLOSE c1;
       
	END;
$

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