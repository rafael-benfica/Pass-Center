-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema PassCenter
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema PassCenter
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `PassCenter` DEFAULT CHARACTER SET utf8 ;
USE `PassCenter` ;

-- -----------------------------------------------------
-- Table `PassCenter`.`tipos_enderecos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PassCenter`.`tipos_enderecos` (
  `ten_codigo` INT NOT NULL AUTO_INCREMENT,
  `ten_titulo` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`ten_codigo`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PassCenter`.`enderecos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PassCenter`.`enderecos` (
  `end_codigo` INT NOT NULL AUTO_INCREMENT,
  `end_logradouro` VARCHAR(120) NOT NULL,
  `end_numero` VARCHAR(10) NOT NULL,
  `end_bairro` VARCHAR(50) NOT NULL,
  `end_municipio` VARCHAR(50) NOT NULL,
  `end_estado` VARCHAR(50) NOT NULL,
  `end_complemento` VARCHAR(50) NULL,
  `end_pais` VARCHAR(50) NOT NULL,
  `ten_codigo` INT NOT NULL,
  PRIMARY KEY (`end_codigo`),
  INDEX `fk_enderecos_tipo_endereco1_idx` (`ten_codigo` ASC) VISIBLE,
  CONSTRAINT `fk_enderecos_tipo_endereco1`
    FOREIGN KEY (`ten_codigo`)
    REFERENCES `PassCenter`.`tipos_enderecos` (`ten_codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PassCenter`.`instituicoes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PassCenter`.`instituicoes` (
  `ins_codigo` INT NOT NULL AUTO_INCREMENT,
  `ins_nome_fantasia` VARCHAR(120) NOT NULL,
  `ins_razao_social` VARCHAR(120) NOT NULL,
  `ins_inscricao_estadual` VARCHAR(45) NOT NULL,
  `ins_cnpj` VARCHAR(50) NOT NULL,
  `ins_estado` TINYINT NOT NULL,
  `ins_periodo_renovacao_dias` INT NOT NULL,
  `end_codigo` INT NOT NULL,
  PRIMARY KEY (`ins_codigo`),
  UNIQUE INDEX `razao_social_UNIQUE` (`ins_razao_social` ASC) VISIBLE,
  UNIQUE INDEX `inscricao_estadual_UNIQUE` (`ins_inscricao_estadual` ASC) VISIBLE,
  UNIQUE INDEX `nome_fantasia_UNIQUE` (`ins_nome_fantasia` ASC) VISIBLE,
  UNIQUE INDEX `cnpj_UNIQUE` (`ins_cnpj` ASC) VISIBLE,
  INDEX `fk_instituicoes_enderecos1_idx` (`end_codigo` ASC) VISIBLE,
  CONSTRAINT `fk_instituicoes_enderecos1`
    FOREIGN KEY (`end_codigo`)
    REFERENCES `PassCenter`.`enderecos` (`end_codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PassCenter`.`pessoas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PassCenter`.`pessoas` (
  `pes_codigo` INT NOT NULL AUTO_INCREMENT,
  `pes_nome` VARCHAR(30) NOT NULL,
  `pes_sobrenomes` VARCHAR(120) NOT NULL,
  `pes_cpf` VARCHAR(50) NOT NULL,
  `pes_rg` VARCHAR(50) NOT NULL,
  `pes_matricula` VARCHAR(45) NOT NULL,
  `pes_sexo` INT NOT NULL,
  `pes_tel_residencial` VARCHAR(45) NOT NULL,
  `pes_tel_celular` VARCHAR(45) NULL,
  `pes_info_adicionais` VARCHAR(120) NULL,
  `end_codigo` INT NOT NULL,
  `ins_codigo` INT NOT NULL,
  PRIMARY KEY (`pes_codigo`),
  INDEX `fk_pessoas_enderecos1_idx` (`end_codigo` ASC) VISIBLE,
  INDEX `fk_pessoas_instituicoes1_idx` (`ins_codigo` ASC) VISIBLE,
  CONSTRAINT `fk_pessoas_enderecos1`
    FOREIGN KEY (`end_codigo`)
    REFERENCES `PassCenter`.`enderecos` (`end_codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_pessoas_instituicoes1`
    FOREIGN KEY (`ins_codigo`)
    REFERENCES `PassCenter`.`instituicoes` (`ins_codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PassCenter`.`tipos_usuarios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PassCenter`.`tipos_usuarios` (
  `tus_codigo` INT NOT NULL AUTO_INCREMENT,
  `tus_titulo` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`tus_codigo`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PassCenter`.`usuarios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PassCenter`.`usuarios` (
  `usu_codigo` INT NOT NULL AUTO_INCREMENT,
  `usu_login` VARCHAR(50) NOT NULL,
  `usu_senha` VARCHAR(50) NOT NULL,
  `usu_estado` TINYINT NOT NULL,
  `usu_data_criacao` DATETIME NOT NULL,
  `usu_data_desativacao` DATETIME NULL,
  `usu_primeiro_login` TINYINT NOT NULL,
  `usu_redefinir_senha` TINYINT NOT NULL,
  `pes_codigo` INT NOT NULL,
  `tus_codigo` INT NOT NULL,
  UNIQUE INDEX `login_UNIQUE` (`usu_login` ASC) VISIBLE,
  PRIMARY KEY (`usu_codigo`),
  INDEX `fk_usuarios_pessoas1_idx` (`pes_codigo` ASC) VISIBLE,
  INDEX `fk_usuarios_tipo_usuario1_idx` (`tus_codigo` ASC) VISIBLE,
  CONSTRAINT `fk_usuarios_pessoas1`
    FOREIGN KEY (`pes_codigo`)
    REFERENCES `PassCenter`.`pessoas` (`pes_codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_usuarios_tipo_usuario1`
    FOREIGN KEY (`tus_codigo`)
    REFERENCES `PassCenter`.`tipos_usuarios` (`tus_codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PassCenter`.`tipos_eventos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PassCenter`.`tipos_eventos` (
  `tev_codigo` INT NOT NULL AUTO_INCREMENT,
  `tev_titulo` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`tev_codigo`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PassCenter`.`eventos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PassCenter`.`eventos` (
  `eve_codigo` INT NOT NULL AUTO_INCREMENT,
  `eve_nome` VARCHAR(120) NOT NULL,
  `eve_sigla` VARCHAR(6) NOT NULL,
  `eve_descricao` VARCHAR(220) NOT NULL,
  `eve_estado` TINYINT NOT NULL,
  `eve_operacao` TINYINT NOT NULL,
  `tev_codigo` INT NOT NULL,
  PRIMARY KEY (`eve_codigo`),
  INDEX `fk_eventos_tipo_eventos1_idx` (`tev_codigo` ASC) VISIBLE,
  CONSTRAINT `fk_eventos_tipo_eventos1`
    FOREIGN KEY (`tev_codigo`)
    REFERENCES `PassCenter`.`tipos_eventos` (`tev_codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PassCenter`.`turmas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PassCenter`.`turmas` (
  `tur_codigo` INT NOT NULL AUTO_INCREMENT,
  `tur_periodo_identificacao` VARCHAR(45) NOT NULL,
  `tur_data_abertura` DATETIME NOT NULL,
  `tur_date_fechamento` DATETIME NULL,
  `tur_estado` TINYINT NOT NULL,
  `ins_codigo` INT NOT NULL,
  `eve_codigo` INT NOT NULL,
  `usu_codigo_participante` INT NOT NULL,
  `pes_codigo_auditor` INT NULL,
  PRIMARY KEY (`tur_codigo`),
  INDEX `fk_turmas_instituicaos1_idx` (`ins_codigo` ASC) VISIBLE,
  INDEX `fk_turmas_eventos1_idx` (`eve_codigo` ASC) VISIBLE,
  INDEX `fk_turmas_usuarios1_idx` (`usu_codigo_participante` ASC) VISIBLE,
  INDEX `fk_turmas_pessoas1_idx` (`pes_codigo_auditor` ASC) VISIBLE,
  CONSTRAINT `fk_turmas_instituicaos1`
    FOREIGN KEY (`ins_codigo`)
    REFERENCES `PassCenter`.`instituicoes` (`ins_codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_turmas_eventos1`
    FOREIGN KEY (`eve_codigo`)
    REFERENCES `PassCenter`.`eventos` (`eve_codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_turmas_usuarios1`
    FOREIGN KEY (`usu_codigo_participante`)
    REFERENCES `PassCenter`.`usuarios` (`usu_codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_turmas_pessoas1`
    FOREIGN KEY (`pes_codigo_auditor`)
    REFERENCES `PassCenter`.`pessoas` (`pes_codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PassCenter`.`totens`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PassCenter`.`totens` (
  `tot_codigo` INT NOT NULL AUTO_INCREMENT,
  `tot_numero_serie` VARCHAR(50) NOT NULL,
  `tot_estado` TINYINT NOT NULL,
  `tot_operacao` TINYINT NOT NULL,
  `ins_codigo` INT NOT NULL,
  PRIMARY KEY (`tot_codigo`),
  INDEX `fk_totens_instituicoes1_idx` (`ins_codigo` ASC) VISIBLE,
  CONSTRAINT `fk_totens_instituicoes1`
    FOREIGN KEY (`ins_codigo`)
    REFERENCES `PassCenter`.`instituicoes` (`ins_codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PassCenter`.`tipos_identificadores`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PassCenter`.`tipos_identificadores` (
  `tid_codigo` INT NOT NULL AUTO_INCREMENT,
  `tid_titulo` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`tid_codigo`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PassCenter`.`identificadores`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PassCenter`.`identificadores` (
  `ide_codigo` INT NOT NULL AUTO_INCREMENT,
  `ide_estado` TINYINT NOT NULL,
  `ide_identificador` VARCHAR(50) NOT NULL,
  `usu_codigo` INT NOT NULL,
  `tid_codigo` INT NOT NULL,
  PRIMARY KEY (`ide_codigo`),
  INDEX `fk_cartoes_usuarios1_idx` (`usu_codigo` ASC) VISIBLE,
  INDEX `fk_identificadores_tipo_identificadores1_idx` (`tid_codigo` ASC) VISIBLE,
  CONSTRAINT `fk_cartoes_usuarios1`
    FOREIGN KEY (`usu_codigo`)
    REFERENCES `PassCenter`.`usuarios` (`usu_codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_identificadores_tipo_identificadores1`
    FOREIGN KEY (`tid_codigo`)
    REFERENCES `PassCenter`.`tipos_identificadores` (`tid_codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PassCenter`.`horarios_eventos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PassCenter`.`horarios_eventos` (
  `hev_codigo` INT NOT NULL AUTO_INCREMENT,
  `hev_data_hora` DATETIME NOT NULL,
  `hev_estado` TINYINT NOT NULL,
  `hev_dia_semana` VARCHAR(50) NOT NULL,
  `eve_codigo` INT NOT NULL,
  PRIMARY KEY (`hev_codigo`),
  INDEX `fk_horarios_eventos_evento1_idx` (`eve_codigo` ASC) VISIBLE,
  CONSTRAINT `fk_horarios_eventos_evento1`
    FOREIGN KEY (`eve_codigo`)
    REFERENCES `PassCenter`.`eventos` (`eve_codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PassCenter`.`tipos_insercoes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PassCenter`.`tipos_insercoes` (
  `tin_codigo` INT NOT NULL AUTO_INCREMENT,
  `tin_titulo` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`tin_codigo`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PassCenter`.`sessoes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PassCenter`.`sessoes` (
  `ses_codigo` INT NOT NULL AUTO_INCREMENT,
  `ses_horario_inicio` DATETIME NOT NULL,
  `ses_horario_fim` DATETIME NULL,
  `tot_codigo` INT NULL,
  `eve_codigo` INT NOT NULL,
  `hev_codigo` INT NOT NULL,
  `tin_codigo` INT NOT NULL,
  PRIMARY KEY (`ses_codigo`),
  INDEX `fk_sessoes_totens1_idx` (`tot_codigo` ASC) VISIBLE,
  INDEX `fk_sessoes_evento1_idx` (`eve_codigo` ASC) VISIBLE,
  INDEX `fk_sessoes_horarios_eventos1_idx` (`hev_codigo` ASC) VISIBLE,
  INDEX `fk_sessoes_tipos_insercoes1_idx` (`tin_codigo` ASC) VISIBLE,
  CONSTRAINT `fk_sessoes_totens1`
    FOREIGN KEY (`tot_codigo`)
    REFERENCES `PassCenter`.`totens` (`tot_codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_sessoes_evento1`
    FOREIGN KEY (`eve_codigo`)
    REFERENCES `PassCenter`.`eventos` (`eve_codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_sessoes_horarios_eventos1`
    FOREIGN KEY (`hev_codigo`)
    REFERENCES `PassCenter`.`horarios_eventos` (`hev_codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_sessoes_tipos_insercoes1`
    FOREIGN KEY (`tin_codigo`)
    REFERENCES `PassCenter`.`tipos_insercoes` (`tin_codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PassCenter`.`presencas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PassCenter`.`presencas` (
  `pre_codigo` INT NOT NULL AUTO_INCREMENT,
  `pre_horario_entrada` DATETIME NOT NULL,
  `pre_horario_saida` DATETIME NULL,
  `ide_codigo` INT NULL,
  `ses_codigo` INT NOT NULL,
  `eve_codigo` INT NOT NULL,
  `tin_codigo` INT NOT NULL,
  PRIMARY KEY (`pre_codigo`),
  INDEX `fk_presencas_cartoes1_idx` (`ide_codigo` ASC) VISIBLE,
  INDEX `fk_presencas_sessoes1_idx` (`ses_codigo` ASC) VISIBLE,
  INDEX `fk_presencas_evento1_idx` (`eve_codigo` ASC) VISIBLE,
  INDEX `fk_presencas_tipos_insercoes1_idx` (`tin_codigo` ASC) VISIBLE,
  CONSTRAINT `fk_presencas_cartoes1`
    FOREIGN KEY (`ide_codigo`)
    REFERENCES `PassCenter`.`identificadores` (`ide_codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_presencas_sessoes1`
    FOREIGN KEY (`ses_codigo`)
    REFERENCES `PassCenter`.`sessoes` (`ses_codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_presencas_evento1`
    FOREIGN KEY (`eve_codigo`)
    REFERENCES `PassCenter`.`eventos` (`eve_codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_presencas_tipos_insercoes1`
    FOREIGN KEY (`tin_codigo`)
    REFERENCES `PassCenter`.`tipos_insercoes` (`tin_codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PassCenter`.`planos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PassCenter`.`planos` (
  `pla_codigo` INT NOT NULL AUTO_INCREMENT,
  `pla_qtd_totens` INT NOT NULL,
  `pla_qtd_tags` INT NOT NULL,
  `pla_preco_totens` DOUBLE NOT NULL,
  `pla_preco_tags` DOUBLE NOT NULL,
  `pla_estado` TINYINT NOT NULL,
  PRIMARY KEY (`pla_codigo`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PassCenter`.`pagamentos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PassCenter`.`pagamentos` (
  `pag_codigo` INT NOT NULL AUTO_INCREMENT,
  `pag_data_criacao` DATETIME NOT NULL,
  `pag_data_vencimento` DATETIME NOT NULL,
  `pag_data_pagamento` DATETIME NULL,
  `ins_codigo` INT NOT NULL,
  `pla_codigo` INT NOT NULL,
  PRIMARY KEY (`pag_codigo`),
  INDEX `fk_pagamento_instituicoes1_idx` (`ins_codigo` ASC) VISIBLE,
  INDEX `fk_pagamentos_planos1_idx` (`pla_codigo` ASC) VISIBLE,
  CONSTRAINT `fk_pagamento_instituicoes1`
    FOREIGN KEY (`ins_codigo`)
    REFERENCES `PassCenter`.`instituicoes` (`ins_codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_pagamentos_planos1`
    FOREIGN KEY (`pla_codigo`)
    REFERENCES `PassCenter`.`planos` (`pla_codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
