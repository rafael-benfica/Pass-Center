
-- Precedure MigrarAno
drop procedure if exists MigrarAno2;

delimiter $
CREATE PROCEDURE MigrarAno2(in vInstituicao int, in vPeriodo varchar(45))
begin
	-- Declaracoes
	declare _eau_codigo INT;
	declare _eau_estado TINYINT;
	declare _eau_data_abertura DATETIME;
	declare _eau_data_fechamento DATETIME;
	declare _pes_codigo INT;
	declare _eve_codigo INT;
	declare _ins_codigo INT;

	DECLARE _gra_codigo int;
    DECLARE _gra_prox_grade int;
	DECLARE _fimUsuarios int;
    DECLARE _usu_codigo int;
    DECLARE ultimoID int;
	DECLARE fimGrades INT DEFAULT 0;
	DECLARE fimDisciplinas INT DEFAULT 0;
    DECLARE fimMatricula INT DEFAULT 0;
    
	-- Declaracao do Cursor
	DECLARE cGrade CURSOR FOR select gra_codigo from grades where ins_codigo = vInstituicao;
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET fimGrades=1;
	SET fimGrades = 0;
			
	OPEN cGrade;
		ideLoop:LOOP	
			FETCH cGrade INTO _gra_codigo;
            IF fimGrades = 1 THEN LEAVE ideLoop; END IF;
            select _gra_codigo;
			begin
				DECLARE cDisciplinas CURSOR FOR select eau_codigo, pes_codigo, eve_codigo, ins_codigo  from eventos_auditores inner join eventos_grades using (eau_codigo) where gra_codigo = _gra_codigo;
				DECLARE CONTINUE HANDLER FOR NOT FOUND SET fimDisciplinas=1;
				SET fimDisciplinas = 0;
                
				OPEN cDisciplinas;
					disLoop:LOOP	
						
						fetch cDisciplinas into _eau_codigo, _pes_codigo, _eve_codigo, _ins_codigo;
						
                       	IF fimDisciplinas = 1 THEN LEAVE disLoop; END IF;
                        
						update eventos_auditores set eau_estado = 0, eau_operacao = 0, eau_data_fechamento = NOW() where eau_codigo = _eau_codigo;
						
						insert into eventos_auditores values (0, vPeriodo, 1, 0, NOW(), null, _pes_codigo, _eve_codigo, _ins_codigo);
						select last_insert_id() into ultimoID;
						
                        delete from eventos_grades where eau_codigo = _eau_codigo;
						insert into eventos_grades values(_gra_codigo, ultimoID, true);
                        
                       	IF fimDisciplinas = 1 THEN LEAVE disLoop; END IF;
                        
                    END LOOP disLoop;
				CLOSE cDisciplinas;
            end;
            IF fimGrades = 1 THEN LEAVE ideLoop; END IF;
		END LOOP ideLoop;
	CLOSE cGrade;
    
    begin
		DECLARE cUsuarios CURSOR FOR select usu_codigo, gra_prox_grade from usuarios inner join grades using(gra_codigo) where ins_codigo = vInstituicao;
		DECLARE CONTINUE HANDLER FOR NOT FOUND SET _fimUsuarios=1;
		SET _fimUsuarios = 0;
                    
		OPEN cUsuarios;
			usuLoop:LOOP
				FETCH cUsuarios INTO _usu_codigo, _gra_prox_grade;
				IF _fimUsuarios = 1 THEN LEAVE usuLoop; END IF;
                            
                            
				update usuarios set gra_codigo=_gra_prox_grade where usu_codigo =_usu_codigo;
				call Matricular(_usu_codigo,_gra_prox_grade);
						
                            
				IF _fimUsuarios = 1 THEN LEAVE usuLoop; END IF;
			END LOOP usuLoop;
		CLOSE cUsuarios;
    end;
end
$