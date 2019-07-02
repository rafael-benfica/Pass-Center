DELIMITER $
CREATE PROCEDURE matricular (IN usu_codigoP INT, IN gra_codigoP INT)
BEGIN
			-- Declaracoes
			DECLARE _eau_codigo int;
			DECLARE fim INT DEFAULT 0;
		
			-- Declaracao do Cursor
			DECLARE c1 CURSOR FOR select eau_codigo from eventos_grades where gra_codigo = gra_codigoP;
            
			DECLARE CONTINUE HANDLER FOR NOT FOUND SET fim=1;
			SET fim = 0;
			
			OPEN c1;
			ideLoop:LOOP	
					-- varrendo registro por registro
					FETCH c1 INTO _eau_codigo;
					IF fim = 1 THEN LEAVE ideLoop; END IF;
					-- Inserindo presenca
					INSERT INTO turmas VALUES (usu_codigoP, _eau_codigo);
			END LOOP ideLoop;
			CLOSE c1;
       
	END;
$