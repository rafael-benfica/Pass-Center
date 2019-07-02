drop procedure inserir;
delimiter |
create procedure inserir(
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
  in` tus_codigoP` INT,
  in `gra_codigoP` INT
)

begin
declare `end_codigoP` INT;
declare `pes_codigoP` INT;
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
                VALUES ('1', '1', '1', '2018-01-12 00:00:00', '2018-01-12 00:00:00', '1', '1', pes_codigoP, tus_codigoP, '1');


                    
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


end