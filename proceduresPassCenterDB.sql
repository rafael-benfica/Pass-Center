
-- Precedure MigrarAno
drop procedure if exists MigrarAno;

-- Precedure InserirPresenca
drop procedure if exists InserirPresenca;

-- Precedure InserirPessoa
drop procedure if exists InserirUsuario;

-- Precedure InserirPessoa
drop procedure if exists Matricular;

DELIMITER $
CREATE PROCEDURE Matricular (IN usu_codigoP INT, IN gra_codigoP INT)
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

delimiter $
create procedure InserirUsuario(
  in `end_logradouroP` VARCHAR(120),
  in `end_numeroP` VARCHAR(10),
  in `end_bairroP` VARCHAR(50),
  in `end_municipioP` VARCHAR(50),
  in `end_cepP` INT,
  in `end_estadoP` VARCHAR(50) ,
  in `end_complementoP` VARCHAR(50),
  in `end_paisP` VARCHAR(50),

  in `pes_nomeP` VARCHAR(30),
  in `pes_sobrenomesP` VARCHAR(120),
  in `pes_data_nascimentoP` DATETIME,
  in `pes_cpfP` VARCHAR(50),
  in `pes_rgP` VARCHAR(50),
  in `pes_matriculaP` VARCHAR(45),
  in `pes_sexoP` INT,
  in `pes_tel_residencialP` VARCHAR(45),
  in `pes_tel_celularP` VARCHAR(45),
  in `pes_info_adicionaisP` VARCHAR(120),
  in `ins_codigoP` INT,
  
  in `usu_loginP` VARCHAR(50),
  in `usu_senhaP` TEXT,
  in `usu_data_criacaoP` DATETIME,
  in `tus_codigoP` INT,
  in `gra_codigoP` INT
)

begin
declare `end_codigoP` INT;
declare `pes_codigoP` INT;
declare `usu_codigoP` INT;
declare excessao smallint default 0;
declare continue handler for sqlexception set excessao = 1;

	start transaction;

		INSERT INTO enderecos(end_logradouro, end_numero, end_bairro, end_municipio, end_cep, end_estado, end_complemento, end_pais) 
        VALUES(end_logradouroP, end_numeroP, end_bairroP, end_municipioP, end_cepP, end_estadoP, end_complementoP, end_paisP);
        
        if(excessao = 0) then
			select last_insert_id() into end_codigoP;
            
            if(excessao = 0) then
				INSERT INTO pessoas(pes_nome, pes_sobrenomes, pes_data_nascimento, pes_cpf, pes_rg, pes_matricula, pes_sexo, pes_tel_residencial, pes_tel_celular, pes_info_adicionais, end_codigo, ins_codigo)
				VALUES(pes_nomeP, pes_sobrenomesP, pes_data_nascimentoP, pes_cpfP, pes_rgP, pes_matriculaP, pes_sexoP, pes_tel_residencialP, pes_tel_celularP, pes_info_adicionaisP, end_codigoP, ins_codigoP);
                select last_insert_id() into pes_codigoP;
                
                if(excessao = 0) then
             
                INSERT INTO `passcenter`.`usuarios` (`usu_login`, `usu_senha`, `usu_estado`, `usu_data_criacao`, `usu_data_desativacao`, `usu_primeiro_login`, `usu_redefinir_senha`, `pes_codigo`, `tus_codigo`, `gra_codigo`) 
                VALUES (usu_loginP, usu_senhaP, '1', usu_data_criacaoP, null, '1', '1', pes_codigoP, tus_codigoP, gra_codigoP);
				select last_insert_id() into usu_codigoP;
                
                    if(excessao = 0) then
						select '0' as msg;
                        commit;
                        -- SET excessao := 0;
                    else
						select '-4' as msg;
                        rollback;
                    end if;
                else
					select '-3' as msg;
                    rollback;
                end if;
            else
				select '-2' as msg;
                rollback;
            end if;
        else
			select '-1' as msg;
            rollback;
        end if;

		call Matricular(usu_codigoP, gra_codigoP);
        
end
$

DELIMITER $
CREATE PROCEDURE InserirPresenca (IN vEau_codigo INT, IN vPes_codigo INT, IN list_of_ids TEXT, IN vPre_horario_entrada DATETIME, IN vPre_horario_saida DATETIME, IN vSes_codigo INT)
BEGIN
			-- Declaracoes
			DECLARE _ide_identificador int;
			DECLARE fim INT DEFAULT 0;
		
			-- Declaracao do Cursor
			DECLARE c1 CURSOR FOR SELECT ide_codigo FROM turmas
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