CREATE DATABASE  IF NOT EXISTS `passcenter` /*!40100 DEFAULT CHARACTER SET utf8 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `passcenter`;
-- MySQL dump 10.13  Distrib 8.0.16, for Win64 (x86_64)
--
-- Host: 192.168.0.70    Database: passcenter
-- ------------------------------------------------------
-- Server version	8.0.16

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `atrelar_tag`
--

DROP TABLE IF EXISTS `atrelar_tag`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `atrelar_tag` (
  `ata_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `ata_identificador` varchar(45) NOT NULL,
  `ins_codigo` int(11) NOT NULL,
  PRIMARY KEY (`ata_codigo`),
  KEY `fk_atrelar_tag_instituicoes1_idx` (`ins_codigo`),
  CONSTRAINT `fk_atrelar_tag_instituicoes1` FOREIGN KEY (`ins_codigo`) REFERENCES `instituicoes` (`ins_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `atrelar_tag`
--

LOCK TABLES `atrelar_tag` WRITE;
/*!40000 ALTER TABLE `atrelar_tag` DISABLE KEYS */;
/*!40000 ALTER TABLE `atrelar_tag` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `enderecos`
--

DROP TABLE IF EXISTS `enderecos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `enderecos` (
  `end_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `end_logradouro` varchar(120) NOT NULL,
  `end_numero` varchar(10) NOT NULL,
  `end_bairro` varchar(50) NOT NULL,
  `end_municipio` varchar(50) NOT NULL,
  `end_cep` int(11) NOT NULL,
  `end_estado` varchar(50) NOT NULL,
  `end_complemento` varchar(50) DEFAULT NULL,
  `end_pais` varchar(50) NOT NULL,
  PRIMARY KEY (`end_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=108 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enderecos`
--

LOCK TABLES `enderecos` WRITE;
/*!40000 ALTER TABLE `enderecos` DISABLE KEYS */;
INSERT INTO `enderecos` VALUES (1,'Av. Prof. João Rodrigues','1501','Jardim Esperança','Guaratinguetá',12518150,'SP','complemento','Brasil'),(2,'Av. Prof. João Rodrigues','1501','Jardim Esperança','Guaratinguetá',12518150,'SP','complemento','Brasil'),(3,'Rua Teerã','930','Parque da Lapa','São Paulo',5301000,'SP','','Brasil'),(4,'Rua Presidente João Café Filho','592','Jardim Ipanema','Santo André',9121680,'SP','','Brasil'),(5,'Rua Hugo Prado','954','Jardim Amaralina','São Paulo',5570210,'SP','','Brasil'),(6,'Rua Fábio Tullio de Mattos','481','Jardim Maria Amélia','Jacareí',12318280,'SP','','Brasil'),(7,'Rua Soldado Amarilho Gonçalves Queiroz','302','Ponte Grande','Guarulhos',7032200,'SP','','Brasil'),(8,'Rua Soldado Amarilho Gonçalves Queiroz','302','Ponte Grande','Guarulhos',7032200,'SP','','Brasil'),(9,'P.O. Box 307, 537 Mauris, Ave','180','Jardim Esperança','Quillón',12518150,'SP',NULL,'Iraq'),(10,'P.O. Box 516, 3243 Tellus, Avenue','424','Jardim Esperança','Macklin',12518150,'SP',NULL,'Haiti'),(11,'185-3263 Id, Street','21','Jardim Esperança','Minna',12518150,'SP',NULL,'New Caledonia'),(12,'8286 Ac Ave','157','Jardim Esperança','Gravataí',12518150,'SP',NULL,'Sudan'),(13,'Ap #507-7003 Elementum Rd.','222','Jardim Esperança','Vienna',12518150,'SP',NULL,'India'),(14,'4444 Pellentesque Av.','953','Jardim Esperança','Napier',12518150,'SP',NULL,'Colombia'),(15,'578-5382 Ipsum Road','987','Jardim Esperança','Vienna',12518150,'SP',NULL,'Croatia'),(16,'216 Eros Road','374','Jardim Esperança','Märsta',12518150,'SP',NULL,'Seychelles'),(17,'883-1430 Cras Rd.','103','Jardim Esperança','Meise',12518150,'SP',NULL,'Laos'),(18,'7941 Dis Ave','447','Jardim Esperança','Ajmer',12518150,'SP',NULL,'Egypt'),(19,'8056 Natoque Street','749','Jardim Esperança','Timkur',12518150,'SP',NULL,'Christmas Island'),(20,'Ap #330-9469 Nullam St.','649','Jardim Esperança','Cagnes-sur-Mer',12518150,'SP',NULL,'Swaziland'),(21,'Ap #723-6911 Dis Av.','550','Jardim Esperança','Oosterhout',12518150,'SP',NULL,'Liechtenstein'),(22,'7603 Suspendisse St.','361','Jardim Esperança','Bauchi',12518150,'SP',NULL,'Panama'),(23,'P.O. Box 592, 442 Felis Avenue','480','Jardim Esperança','Poederlee',12518150,'SP',NULL,'Azerbaijan'),(24,'Ap #240-4527 Sed Rd.','526','Jardim Esperança','Uppingham. Cottesmore',12518150,'SP',NULL,'Saint Helena, Ascension and Tristan da Cunha'),(25,'751-5183 Integer Street','294','Jardim Esperança','Mauá',12518150,'SP',NULL,'Togo'),(26,'P.O. Box 954, 446 Urna. Street','882','Jardim Esperança','Lowell',12518150,'SP',NULL,'Iran'),(27,'660-8638 Augue St.','882','Jardim Esperança','Orangeville',12518150,'SP',NULL,'Bhutan'),(28,'3879 Amet, Av.','470','Jardim Esperança','Galway',12518150,'SP',NULL,'Curaçao'),(29,'339 Felis Ave','109','Jardim Esperança','BiercŽe',12518150,'SP',NULL,'Côte D\'Ivoire (Ivory Coast)'),(30,'Ap #331-5663 Porttitor Rd.','527','Jardim Esperança','Wörgl',12518150,'SP',NULL,'Libya'),(31,'9629 Fusce Avenue','319','Jardim Esperança','Märsta',12518150,'SP',NULL,'Taiwan'),(32,'7143 Semper St.','793','Jardim Esperança','Nampa',12518150,'SP',NULL,'Reunion'),(33,'9120 Metus Avenue','714','Jardim Esperança','Sandy',12518150,'SP',NULL,'Latvia'),(34,'Ap #742-411 Cursus Ave','686','Jardim Esperança','La Salle',12518150,'SP',NULL,'Kuwait'),(35,'P.O. Box 948, 5444 Mollis St.','599','Jardim Esperança','Ajaccio',12518150,'SP',NULL,'Ethiopia'),(36,'9889 Accumsan Avenue','356','Jardim Esperança','Polatl?',12518150,'SP',NULL,'Sint Maarten'),(37,'Ap #345-2854 Mauris, St.','469','Jardim Esperança','Vienna',12518150,'SP',NULL,'China'),(38,'Ap #105-1887 Lorem, Street','501','Jardim Esperança','Berlin',12518150,'SP',NULL,'Heard Island and Mcdonald Islands'),(39,'Ap #838-9141 Turpis St.','779','Jardim Esperança','Leduc',12518150,'SP',NULL,'Gibraltar'),(40,'570-2804 Sed, Rd.','809','Jardim Esperança','Sydney',12518150,'SP',NULL,'Saint Barthélemy'),(41,'P.O. Box 115, 416 Morbi Street','525','Jardim Esperança','Konya',12518150,'SP',NULL,'Macedonia'),(42,'Ap #421-8787 Non, Av.','808','Jardim Esperança','Bünyan',12518150,'SP',NULL,'Chad'),(43,'Ap #900-4248 Id Avenue','161','Jardim Esperança','Vienna',12518150,'SP',NULL,'Swaziland'),(44,'P.O. Box 740, 9564 In, St.','108','Jardim Esperança','Belfast',12518150,'SP',NULL,'New Caledonia'),(45,'2553 Urna. Avenue','732','Jardim Esperança','Fermont',12518150,'SP',NULL,'Suriname'),(46,'P.O. Box 144, 8808 Ipsum. Av.','116','Jardim Esperança','K?z?lcahamam',12518150,'SP',NULL,'Congo, the Democratic Republic of the'),(47,'P.O. Box 518, 5372 Turpis Road','217','Jardim Esperança','Burdinne',12518150,'SP',NULL,'Cameroon'),(48,'292-4611 Felis Av.','571','Jardim Esperança','Aulnay-sous-Bois',12518150,'SP',NULL,'Kyrgyzstan'),(49,'198-6612 Ullamcorper Av.','537','Jardim Esperança','Motala',12518150,'SP',NULL,'Namibia'),(50,'Ap #846-7714 Libero Street','78','Jardim Esperança','Sint-Gillis-Waas',12518150,'SP',NULL,'Congo, the Democratic Republic of the'),(51,'P.O. Box 861, 3096 Vivamus St.','490','Jardim Esperança','Pike Creek',12518150,'SP',NULL,'Latvia'),(52,'Ap #128-2079 Risus. Ave','172','Jardim Esperança','Estevan',12518150,'SP',NULL,'Jamaica'),(53,'456-8163 Consequat St.','465','Jardim Esperança','Grey County',12518150,'SP',NULL,'New Caledonia'),(54,'883-4595 Massa Road','780','Jardim Esperança','Vienna',12518150,'SP',NULL,'Iran'),(55,'P.O. Box 961, 8465 Eu Avenue','996','Jardim Esperança','Renfrew',12518150,'SP',NULL,'Switzerland'),(56,'1049 Penatibus Road','919','Jardim Esperança','Varanasi',12518150,'SP',NULL,'Holy See (Vatican City State)'),(57,'P.O. Box 804, 6266 Risus. St.','832','Jardim Esperança','Connah\'s Quay',12518150,'SP',NULL,'Andorra'),(58,'Ap #180-5057 Dolor St.','397','Jardim Esperança','Port Harcourt',12518150,'SP',NULL,'Singapore'),(59,'668-2617 Aliquam Rd.','374','Jardim Esperança','Trollhättan',12518150,'SP',NULL,'Holy See (Vatican City State)'),(60,'643-644 Nisi Road','932','Jardim Esperança','New Haven',12518150,'SP',NULL,'Cyprus'),(61,'567-5563 Etiam St.','16','Jardim Esperança','Belfast',12518150,'SP',NULL,'Saint Barthélemy'),(62,'592-7691 Faucibus St.','89','Jardim Esperança','Melton',12518150,'SP',NULL,'Tanzania'),(63,'P.O. Box 436, 903 Est, St.','834','Jardim Esperança','Minitonas',12518150,'SP',NULL,'Guadeloupe'),(64,'250-4718 Ac Av.','335','Jardim Esperança','Laval',12518150,'SP',NULL,'Georgia'),(65,'P.O. Box 853, 6433 Ante Avenue','167','Jardim Esperança','Paredones',12518150,'SP',NULL,'Slovakia'),(66,'P.O. Box 482, 2522 Commodo Rd.','535','Jardim Esperança','Galway',12518150,'SP',NULL,'Malta'),(67,'5347 Et Av.','87','Jardim Esperança','Bauchi',12518150,'SP',NULL,'Estonia'),(68,'928-1811 Ornare, Street','859','Jardim Esperança','Jalgaon',12518150,'SP',NULL,'Cyprus'),(69,'2410 A St.','440','Jardim Esperança','Montes Claros',12518150,'SP',NULL,'Greenland'),(70,'235 Nulla Street','677','Jardim Esperança','Pukekohe',12518150,'SP',NULL,'Bouvet Island'),(71,'P.O. Box 871, 8553 Euismod Rd.','30','Jardim Esperança','Oxford County',12518150,'SP',NULL,'Slovakia'),(72,'Ap #598-990 Nascetur Street','79','Jardim Esperança','Glauchau',12518150,'SP',NULL,'French Southern Territories'),(73,'P.O. Box 907, 2950 Euismod Avenue','382','Jardim Esperança','Kawawachikamach',12518150,'SP',NULL,'Barbados'),(74,'P.O. Box 377, 9403 Aliquam Street','349','Jardim Esperança','Novo Hamburgo',12518150,'SP',NULL,'Saint Barthélemy'),(75,'169-8241 Fringilla Rd.','200','Jardim Esperança','Gijón',12518150,'SP',NULL,'Svalbard and Jan Mayen Islands'),(76,'684 Nullam Avenue','767','Jardim Esperança','Cerrillos',12518150,'SP',NULL,'Bahamas'),(77,'2046 Non, St.','210','Jardim Esperança','Artena',12518150,'SP',NULL,'Pakistan'),(78,'3172 Nec, Rd.','534','Jardim Esperança','Cartago',12518150,'SP',NULL,'Israel'),(79,'578-4699 Enim Avenue','974','Jardim Esperança','Granada',12518150,'SP',NULL,'Israel'),(80,'632-2462 Quis St.','2','Jardim Esperança','Foz do Iguaçu',12518150,'SP',NULL,'Isle of Man'),(81,'P.O. Box 479, 9692 Nullam Road','891','Jardim Esperança','Dortmund',12518150,'SP',NULL,'Poland'),(82,'Ap #740-6405 Ut Rd.','592','Jardim Esperança','Auckland',12518150,'SP',NULL,'Bosnia and Herzegovina'),(83,'P.O. Box 383, 843 Lorem St.','345','Jardim Esperança','Sagar',12518150,'SP',NULL,'Qatar'),(84,'P.O. Box 405, 2916 Enim St.','600','Jardim Esperança','LiŽge',12518150,'SP',NULL,'Venezuela'),(85,'9789 Elit Street','14','Jardim Esperança','Concepción',12518150,'SP',NULL,'Nauru'),(86,'P.O. Box 209, 4645 Mauris Rd.','749','Jardim Esperança','Ere?li',12518150,'SP',NULL,'Egypt'),(87,'P.O. Box 400, 4972 Elementum Road','845','Jardim Esperança','Bowling Green',12518150,'SP',NULL,'Jersey'),(88,'P.O. Box 919, 5035 Neque St.','893','Jardim Esperança','Grafton',12518150,'SP',NULL,'Guadeloupe'),(89,'879 Et, Street','110','Jardim Esperança','Cobquecura',12518150,'SP',NULL,'Uzbekistan'),(90,'852-4110 Neque. Rd.','883','Jardim Esperança','Timon',12518150,'SP',NULL,'South Georgia and The South Sandwich Islands'),(91,'9492 Morbi Street','154','Jardim Esperança','Merzig',12518150,'SP',NULL,'Colombia'),(92,'9180 Facilisi. Ave','806','Jardim Esperança','Berlin',12518150,'SP',NULL,'Saint Martin'),(93,'9330 Consectetuer Avenue','215','Jardim Esperança','Blue Mountains',12518150,'SP',NULL,'Uzbekistan'),(94,'822-6527 Ullamcorper Avenue','951','Jardim Esperança','Caucaia',12518150,'SP',NULL,'Somalia'),(95,'Ap #827-2676 Ante. Avenue','33','Jardim Esperança','Titagarh',12518150,'SP',NULL,'Namibia'),(96,'481-2553 Sociis Avenue','205','Jardim Esperança','Segovia',12518150,'SP',NULL,'Cook Islands'),(97,'Ap #493-4442 Donec Avenue','404','Jardim Esperança','Vienna',12518150,'SP',NULL,'Slovenia'),(98,'6831 Ligula. Rd.','257','Jardim Esperança','Reus',12518150,'SP',NULL,'Norfolk Island'),(99,'P.O. Box 686, 9396 Fusce Ave','960','Jardim Esperança','Courbevoie',12518150,'SP',NULL,'Ghana'),(100,'755-9178 A, St.','928','Jardim Esperança','Lincoln',12518150,'SP',NULL,'Bhutan'),(101,'8273 Nibh. Rd.','800','Jardim Esperança','San Vicente',12518150,'SP',NULL,'Venezuela'),(102,'8988 Molestie Avenue','727','Jardim Esperança','Maryborough',12518150,'SP',NULL,'Guinea'),(103,'757-4667 Etiam Rd.','9','Jardim Esperança','Pontedera',12518150,'SP',NULL,'Bouvet Island'),(104,'7189 Vitae Rd.','29','Jardim Esperança','Szczecin',12518150,'SP',NULL,'San Marino'),(105,'6359 Mi. Rd.','910','Jardim Esperança','Rocca Santo Stefano',12518150,'SP',NULL,'Saint Vincent and The Grenadines'),(106,'P.O. Box 921, 875 Nonummy Av.','941','Jardim Esperança','Collipulli',12518150,'SP',NULL,'Guyana'),(107,'387-1569 Ut St.','968','Jardim Esperança','Vienna',12518150,'SP',NULL,'Kyrgyzstan');
/*!40000 ALTER TABLE `enderecos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `eventos`
--

DROP TABLE IF EXISTS `eventos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `eventos` (
  `eve_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `eve_nome` varchar(120) NOT NULL,
  `eve_sigla` varchar(6) NOT NULL,
  `eve_descricao` varchar(220) NOT NULL,
  `eve_estado` tinyint(4) NOT NULL,
  `ins_codigo` int(11) NOT NULL,
  `tev_codigo` int(11) NOT NULL,
  PRIMARY KEY (`eve_codigo`),
  KEY `fk_eventos_instituicoes1_idx` (`ins_codigo`),
  KEY `fk_eventos_tipos_eventos1_idx` (`tev_codigo`),
  CONSTRAINT `fk_eventos_instituicoes1` FOREIGN KEY (`ins_codigo`) REFERENCES `instituicoes` (`ins_codigo`),
  CONSTRAINT `fk_eventos_tipos_eventos1` FOREIGN KEY (`tev_codigo`) REFERENCES `tipos_eventos` (`tev_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `eventos`
--

LOCK TABLES `eventos` WRITE;
/*!40000 ALTER TABLE `eventos` DISABLE KEYS */;
INSERT INTO `eventos` VALUES (1,'Matemática 1','Mat01','Aprender a Somar e Subtrair',1,2,1),(2,'Biologia 1','Bio01','',1,2,1);
/*!40000 ALTER TABLE `eventos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `eventos_auditores`
--

DROP TABLE IF EXISTS `eventos_auditores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `eventos_auditores` (
  `eau_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `eau_periodo_identificacao` varchar(45) NOT NULL,
  `eau_estado` tinyint(4) NOT NULL,
  `eau_operacao` tinyint(1) NOT NULL,
  `eau_data_abertura` datetime NOT NULL,
  `eau_data_fechamento` datetime DEFAULT NULL,
  `pes_codigo` int(11) DEFAULT NULL,
  `eve_codigo` int(11) NOT NULL,
  `ins_codigo` int(11) NOT NULL,
  PRIMARY KEY (`eau_codigo`),
  KEY `fk_envento_auditor_pessoas1_idx` (`pes_codigo`),
  KEY `fk_envento_auditor_eventos1_idx` (`eve_codigo`),
  KEY `fk_envento_auditor_instituicoes1_idx` (`ins_codigo`),
  CONSTRAINT `fk_envento_auditor_eventos1` FOREIGN KEY (`eve_codigo`) REFERENCES `eventos` (`eve_codigo`),
  CONSTRAINT `fk_envento_auditor_instituicoes1` FOREIGN KEY (`ins_codigo`) REFERENCES `instituicoes` (`ins_codigo`),
  CONSTRAINT `fk_envento_auditor_pessoas1` FOREIGN KEY (`pes_codigo`) REFERENCES `pessoas` (`pes_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `eventos_auditores`
--

LOCK TABLES `eventos_auditores` WRITE;
/*!40000 ALTER TABLE `eventos_auditores` DISABLE KEYS */;
INSERT INTO `eventos_auditores` VALUES (1,'2018/01',1,0,'2018-12-06 00:00:00',NULL,4,1,2),(2,'2019',1,0,'2019-08-05 15:46:22',NULL,11,2,2);
/*!40000 ALTER TABLE `eventos_auditores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `eventos_grades`
--

DROP TABLE IF EXISTS `eventos_grades`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `eventos_grades` (
  `gra_codigo` int(11) NOT NULL,
  `eau_codigo` int(11) NOT NULL,
  `egr_estado` tinyint(1) NOT NULL,
  PRIMARY KEY (`gra_codigo`,`eau_codigo`),
  KEY `fk_eventos_has_grades_grades1_idx` (`gra_codigo`),
  KEY `fk_eventos_grades_eventos_auditores1_idx` (`eau_codigo`),
  CONSTRAINT `fk_eventos_grades_eventos_auditores1` FOREIGN KEY (`eau_codigo`) REFERENCES `eventos_auditores` (`eau_codigo`),
  CONSTRAINT `fk_eventos_has_grades_grades1` FOREIGN KEY (`gra_codigo`) REFERENCES `grades` (`gra_codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `eventos_grades`
--

LOCK TABLES `eventos_grades` WRITE;
/*!40000 ALTER TABLE `eventos_grades` DISABLE KEYS */;
INSERT INTO `eventos_grades` VALUES (1,1,1),(1,2,1);
/*!40000 ALTER TABLE `eventos_grades` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grades`
--

DROP TABLE IF EXISTS `grades`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `grades` (
  `gra_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `gra_nome` varchar(50) NOT NULL,
  `ins_codigo` int(11) NOT NULL,
  `gra_prox_grade` int(11) DEFAULT NULL,
  PRIMARY KEY (`gra_codigo`),
  KEY `fk_grades_instituicoes1_idx` (`ins_codigo`),
  KEY `fk_grades_grades1_idx` (`gra_prox_grade`),
  CONSTRAINT `fk_grades_grades1` FOREIGN KEY (`gra_prox_grade`) REFERENCES `grades` (`gra_codigo`),
  CONSTRAINT `fk_grades_instituicoes1` FOREIGN KEY (`ins_codigo`) REFERENCES `instituicoes` (`ins_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grades`
--

LOCK TABLES `grades` WRITE;
/*!40000 ALTER TABLE `grades` DISABLE KEYS */;
INSERT INTO `grades` VALUES (1,'1º Ano - E.M.',2,NULL);
/*!40000 ALTER TABLE `grades` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `horarios_eventos`
--

DROP TABLE IF EXISTS `horarios_eventos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `horarios_eventos` (
  `hev_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `hev_data_hora` datetime NOT NULL,
  `hev_estado` tinyint(4) NOT NULL,
  `hev_dia_semana` varchar(50) NOT NULL,
  `eau_codigo` int(11) NOT NULL,
  PRIMARY KEY (`hev_codigo`),
  KEY `fk_horarios_eventos_eventos_auditores1_idx` (`eau_codigo`),
  CONSTRAINT `fk_horarios_eventos_eventos_auditores1` FOREIGN KEY (`eau_codigo`) REFERENCES `eventos_auditores` (`eau_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `horarios_eventos`
--

LOCK TABLES `horarios_eventos` WRITE;
/*!40000 ALTER TABLE `horarios_eventos` DISABLE KEYS */;
INSERT INTO `horarios_eventos` VALUES (1,'2019-04-26 22:09:00',1,'Segunda-feira',1);
/*!40000 ALTER TABLE `horarios_eventos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `identificadores`
--

DROP TABLE IF EXISTS `identificadores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `identificadores` (
  `ide_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `ide_estado` tinyint(4) NOT NULL,
  `ide_identificador` varchar(50) NOT NULL,
  `usu_codigo` int(11) NOT NULL,
  `tid_codigo` int(11) NOT NULL,
  PRIMARY KEY (`ide_codigo`),
  KEY `fk_cartoes_usuarios1_idx` (`usu_codigo`),
  KEY `fk_identificadores_tipo_identificadores1_idx` (`tid_codigo`),
  CONSTRAINT `fk_cartoes_usuarios1` FOREIGN KEY (`usu_codigo`) REFERENCES `usuarios` (`usu_codigo`),
  CONSTRAINT `fk_identificadores_tipo_identificadores1` FOREIGN KEY (`tid_codigo`) REFERENCES `tipos_identificadores` (`tid_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=116 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `identificadores`
--

LOCK TABLES `identificadores` WRITE;
/*!40000 ALTER TABLE `identificadores` DISABLE KEYS */;
INSERT INTO `identificadores` VALUES (1,1,'0001',1,1),(2,1,'0002',2,1),(3,1,'0003',3,1),(4,0,'17 59 8e 76',4,1),(6,1,'0006',6,1),(7,1,'87 5b 9c 76',7,1),(8,1,'8',8,1),(9,1,'9',9,1),(10,1,'10',10,1),(11,0,'11',11,1),(12,0,'12',12,1),(13,1,'13',13,1),(14,1,'14',14,1),(15,1,'15',15,1),(17,1,'17',17,1),(18,1,'18',18,1),(19,1,'19',19,1),(21,1,'21',21,1),(22,1,'22',22,1),(23,1,'23',23,1),(24,1,'24',24,1),(25,1,'25',25,1),(26,1,'26',26,1),(28,1,'28',28,1),(29,1,'29',29,1),(30,1,'30',30,1),(31,1,'31',31,1),(32,1,'32',32,1),(33,1,'33',33,1),(34,1,'34',34,1),(35,1,'35',35,1),(37,1,'37',37,1),(38,1,'38',38,1),(39,1,'39',39,1),(40,1,'40',40,1),(41,1,'41',41,1),(42,1,'42',42,1),(43,1,'43',43,1),(44,1,'44',44,1),(45,1,'45',45,1),(46,1,'46',46,1),(47,1,'47',47,1),(48,1,'48',48,1),(49,1,'49',49,1),(51,1,'51',51,1),(52,1,'52',52,1),(53,1,'53',53,1),(54,1,'54',54,1),(55,1,'55',55,1),(56,1,'56',56,1),(57,1,'57',57,1),(58,1,'58',58,1),(59,1,'59',59,1),(60,1,'60',60,1),(61,1,'61',61,1),(62,1,'62',62,1),(63,1,'63',63,1),(64,1,'64',64,1),(65,1,'65',65,1),(66,1,'66',66,1),(67,1,'67',67,1),(68,1,'68',68,1),(69,1,'69',69,1),(70,1,'70',70,1),(71,1,'71',71,1),(72,1,'72',72,1),(73,1,'73',73,1),(74,1,'74',74,1),(75,1,'75',75,1),(76,1,'76',76,1),(77,1,'77',77,1),(78,1,'78',78,1),(79,1,'79',79,1),(80,1,'80',80,1),(81,1,'81',81,1),(82,1,'82',82,1),(83,1,'83',83,1),(84,1,'84',84,1),(85,1,'85',85,1),(86,1,'86',86,1),(87,1,'87',87,1),(88,1,'88',88,1),(89,1,'89',89,1),(90,1,'90',90,1),(91,1,'91',91,1),(92,1,'92',92,1),(93,1,'93',93,1),(94,1,'94',94,1),(95,1,'95',95,1),(96,1,'96',96,1),(97,1,'97',97,1),(98,1,'98',98,1),(99,1,'99',99,1),(100,1,'100',100,1),(101,1,'101',101,1),(102,1,'102',102,1),(103,1,'103',103,1),(104,1,'104',104,1),(105,1,'105',105,1),(106,1,'106',106,1),(107,1,'c7 67 8e 76',12,1),(108,1,'17 59 8e 76',4,1),(109,1,'67 a0 9e 76',50,1),(110,1,'97 a0 9c 76',20,1),(111,1,'b7 11 8f 76',27,1),(112,1,'27 ea 8e 76',16,1),(113,1,'37 5f 95 76',11,1),(114,1,'d7 b1 8e 76',36,1),(115,1,'c7 24 92 76',5,1);
/*!40000 ALTER TABLE `identificadores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `instituicoes`
--

DROP TABLE IF EXISTS `instituicoes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `instituicoes` (
  `ins_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `ins_nome_fantasia` varchar(120) NOT NULL,
  `ins_razao_social` varchar(120) NOT NULL,
  `ins_inscricao_estadual` varchar(45) NOT NULL,
  `ins_cnpj` varchar(50) NOT NULL,
  `ins_estado` tinyint(4) NOT NULL,
  `ins_periodo_renovacao_dias` int(11) NOT NULL,
  `ins_telefone` varchar(45) NOT NULL,
  `end_codigo` int(11) NOT NULL,
  PRIMARY KEY (`ins_codigo`),
  UNIQUE KEY `razao_social_UNIQUE` (`ins_razao_social`),
  UNIQUE KEY `inscricao_estadual_UNIQUE` (`ins_inscricao_estadual`),
  UNIQUE KEY `nome_fantasia_UNIQUE` (`ins_nome_fantasia`),
  UNIQUE KEY `cnpj_UNIQUE` (`ins_cnpj`),
  KEY `fk_instituicoes_enderecos1_idx` (`end_codigo`),
  CONSTRAINT `fk_instituicoes_enderecos1` FOREIGN KEY (`end_codigo`) REFERENCES `enderecos` (`end_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `instituicoes`
--

LOCK TABLES `instituicoes` WRITE;
/*!40000 ALTER TABLE `instituicoes` DISABLE KEYS */;
INSERT INTO `instituicoes` VALUES (1,'Pass Center Company','Pass Center Company Ltda.','000.000.000.000','00.000.000-0000-00',1,0,'(00) 0000-0000',1),(2,'FATEC Guaratinguetá','Faculdade de Tecnologia Estadual de Guaratinguetá','000.000.000.001','00.000.000-0000-01',1,30,'(12) 3126-2643',1);
/*!40000 ALTER TABLE `instituicoes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pagamentos`
--

DROP TABLE IF EXISTS `pagamentos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `pagamentos` (
  `pag_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `pag_data_criacao` datetime NOT NULL,
  `pag_data_vencimento` datetime NOT NULL,
  `pag_data_pagamento` datetime DEFAULT NULL,
  `ins_codigo` int(11) NOT NULL,
  `pla_codigo` int(11) NOT NULL,
  PRIMARY KEY (`pag_codigo`),
  KEY `fk_pagamento_instituicoes1_idx` (`ins_codigo`),
  KEY `fk_pagamentos_planos1_idx` (`pla_codigo`),
  CONSTRAINT `fk_pagamento_instituicoes1` FOREIGN KEY (`ins_codigo`) REFERENCES `instituicoes` (`ins_codigo`),
  CONSTRAINT `fk_pagamentos_planos1` FOREIGN KEY (`pla_codigo`) REFERENCES `planos` (`pla_codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pagamentos`
--

LOCK TABLES `pagamentos` WRITE;
/*!40000 ALTER TABLE `pagamentos` DISABLE KEYS */;
/*!40000 ALTER TABLE `pagamentos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pessoas`
--

DROP TABLE IF EXISTS `pessoas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `pessoas` (
  `pes_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `pes_nome` varchar(30) NOT NULL,
  `pes_sobrenomes` varchar(120) NOT NULL,
  `pes_data_nascimento` datetime NOT NULL,
  `pes_cpf` varchar(50) NOT NULL,
  `pes_rg` varchar(50) NOT NULL,
  `pes_matricula` varchar(45) NOT NULL,
  `pes_sexo` int(11) NOT NULL,
  `pes_tel_residencial` varchar(45) NOT NULL,
  `pes_tel_celular` varchar(45) DEFAULT NULL,
  `pes_info_adicionais` varchar(120) DEFAULT NULL,
  `end_codigo` int(11) NOT NULL,
  `ins_codigo` int(11) NOT NULL,
  PRIMARY KEY (`pes_codigo`),
  UNIQUE KEY `pes_cpf_UNIQUE` (`pes_cpf`),
  UNIQUE KEY `pes_rg_UNIQUE` (`pes_rg`),
  UNIQUE KEY `pes_matricula_UNIQUE` (`pes_matricula`),
  KEY `fk_pessoas_enderecos1_idx` (`end_codigo`),
  KEY `fk_pessoas_instituicoes1_idx` (`ins_codigo`),
  CONSTRAINT `fk_pessoas_enderecos1` FOREIGN KEY (`end_codigo`) REFERENCES `enderecos` (`end_codigo`),
  CONSTRAINT `fk_pessoas_instituicoes1` FOREIGN KEY (`ins_codigo`) REFERENCES `instituicoes` (`ins_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=107 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pessoas`
--

LOCK TABLES `pessoas` WRITE;
/*!40000 ALTER TABLE `pessoas` DISABLE KEYS */;
INSERT INTO `pessoas` VALUES (1,'Filipe','Márcio Ferreira','1996-02-01 00:00:00','240.436.648-34','48.085.566-3','1802010',1,'(11) 2511-5724','(11) 98403-6407','',2,1),(2,'Nicole','Bruna Aline Freitas','1996-08-26 00:00:00','309.127.538-89','33.609.202-7','1802020',2,'(11) 2706-6469','(11) 98193-4069','',3,2),(3,'Yuri','Felipe Castro','1996-08-06 00:00:00','536.525.748-00','14.648.632-8','1802030',1,'(11) 2545-4040','(11) 99272-4760','',4,2),(4,'Bruna','Benedita Alessandra Drumond','1996-01-08 00:00:00','730.056.198-50','26.499.183-7','1802040',2,'(12) 2630-2701','(12) 99159-8474','',5,2),(5,'Diego','Daniel Cardoso','1996-11-07 00:00:00','313.172.158-85','15.498.605-7','1802050',1,'(11) 2840-1247','(11) 99614-1502','',6,2),(6,'Rodrigo','Daniel Cardoso','1996-11-07 00:00:00','313.172.658-85','15.598.605-7','1803050',1,'(11) 2840-1247','(11) 99614-1502','',6,2),(7,'Simon','Bolton','2020-01-06 00:00:00','30368717','30368717','1902001',2,'(35) 3922-5020','(38) 99937-6406',NULL,8,2),(8,'Nash','Snow','2018-10-17 00:00:00','31493926','31493926','1902002',2,'(33) 9583-3521','(27) 93810-7171',NULL,9,2),(9,'Zeph','Delacruz','2018-10-28 00:00:00','25166850','25166850','1902003',2,'(99) 1126-1138','(85) 91784-4305',NULL,10,2),(10,'Emily','Torres','2019-03-23 00:00:00','11234591','11234591','1902004',1,'(97) 8976-6371','(17) 99621-2180',NULL,11,2),(11,'Lois','Cochran','2018-08-19 00:00:00','39300300','39300300','1902005',2,'(89) 5083-8141','(62) 92776-1460',NULL,12,2),(12,'Tyler','Carroll','2019-09-03 00:00:00','32854420','32854420','1902006',1,'(45) 5540-7364','(79) 92518-0444',NULL,13,2),(13,'Camden','Dyer','2018-07-22 00:00:00','28566835','28566835','1902007',2,'(56) 8605-1921','(97) 92210-7060',NULL,14,2),(14,'Dexter','Salas','2019-03-25 00:00:00','19731662','19731662','1902008',1,'(74) 1678-8274','(83) 99072-3378',NULL,15,2),(15,'Jasper','Gilbert','2018-12-17 00:00:00','36023390','36023390','1902009',2,'(87) 5675-8054','(22) 98466-8834',NULL,16,2),(16,'Halla','Pennington','2019-06-15 00:00:00','6880123','6880123','1902010',2,'(97) 8658-0058','(98) 97054-7301',NULL,17,2),(17,'Graham','Salinas','2019-06-03 00:00:00','37524798','37524798','1902011',1,'(84) 2844-3465','(84) 98418-4202',NULL,18,2),(18,'Barbara','Payne','2019-05-23 00:00:00','41746564','41746564','1902012',1,'(36) 4128-9004','(38) 97291-0710',NULL,19,2),(19,'Palmer','Moses','2019-04-29 00:00:00','12798238','12798238','1902013',1,'(23) 6870-5968','(30) 92882-0441',NULL,20,2),(20,'Mary','Burke','2019-06-20 00:00:00','50721430','50721430','1902014',1,'(99) 7643-0825','(58) 93194-4170',NULL,21,2),(21,'Simon','Mason','2020-02-20 00:00:00','11428237','11428237','1902015',1,'(79) 3245-0159','(84) 93930-4839',NULL,22,2),(22,'Paki','Hogan','2019-09-02 00:00:00','28557464','28557464','1902016',1,'(20) 9444-4487','(16) 95618-7995',NULL,23,2),(23,'Harrison','Rosario','2018-09-08 00:00:00','46098823','46098823','1902017',1,'(82) 9394-4095','(89) 96837-2208',NULL,24,2),(24,'Ira','Suarez','2019-06-04 00:00:00','46821098','46821098','1902018',2,'(80) 4689-3884','(27) 95196-8072',NULL,25,2),(25,'Martena','Bowen','2020-01-30 00:00:00','32508963','32508963','1902019',1,'(17) 3378-0677','(36) 96854-8678',NULL,26,2),(26,'Macaulay','Guerrero','2019-05-26 00:00:00','21295201','21295201','1902020',2,'(87) 8456-2642','(99) 92198-6567',NULL,27,2),(27,'Deacon','Kim','2019-05-19 00:00:00','27732192','27732192','1902021',1,'(96) 7457-9984','(80) 99656-7158',NULL,28,2),(28,'Trevor','Bray','2020-04-04 00:00:00','24260704','24260704','1902022',2,'(15) 3801-6133','(12) 91129-1141',NULL,29,2),(29,'Steel','Klein','2020-02-05 00:00:00','12483756','12483756','1902023',2,'(74) 5510-0112','(54) 91416-1894',NULL,30,2),(30,'Len','Soto','2020-01-25 00:00:00','23155617','23155617','1902024',2,'(25) 7387-1751','(42) 91202-2400',NULL,31,2),(31,'Wyoming','Buchanan','2018-06-20 00:00:00','27831949','27831949','1902025',1,'(45) 6786-8811','(67) 91752-9195',NULL,32,2),(32,'Xena','Goodman','2018-09-17 00:00:00','11877315','11877315','1902026',1,'(10) 8318-3313','(96) 90276-7247',NULL,33,2),(33,'Plato','Newton','2020-03-26 00:00:00','14253649','14253649','1902027',1,'(89) 7862-4028','(90) 98882-5362',NULL,34,2),(34,'Yoshio','Coffey','2020-01-05 00:00:00','34588836','34588836','1902028',1,'(14) 4687-7122','(61) 94438-8539',NULL,35,2),(35,'Medge','Horne','2020-01-30 00:00:00','47454554','47454554','1902029',1,'(11) 8439-7330','(26) 95062-0739',NULL,36,2),(36,'Lee','Leonard','2019-02-05 00:00:00','24371938','24371938','1902030',1,'(26) 9995-0091','(49) 98049-8893',NULL,37,2),(37,'Hayes','Booth','2020-02-27 00:00:00','13840441','13840441','1902031',2,'(64) 4986-8711','(92) 98641-6495',NULL,38,2),(38,'Anjolie','Navarro','2020-04-18 00:00:00','27328565','27328565','1902032',2,'(35) 3579-1016','(97) 98114-6717',NULL,39,2),(39,'Gage','Simpson','2020-02-16 00:00:00','17031007','17031007','1902033',2,'(48) 4531-5977','(78) 93624-1275',NULL,40,2),(40,'Dorian','Armstrong','2019-06-15 00:00:00','32729118','32729118','1902034',2,'(99) 9314-7480','(56) 91234-0087',NULL,41,2),(41,'Quintessa','Oneill','2019-08-23 00:00:00','47944911','47944911','1902035',2,'(84) 7623-3129','(45) 94288-9437',NULL,42,2),(42,'Alisa','Hyde','2018-05-14 00:00:00','48803493','48803493','1902036',2,'(46) 8450-1889','(77) 99951-1032',NULL,43,2),(43,'Bevis','Sanders','2020-05-03 00:00:00','32506756','32506756','1902037',1,'(59) 6681-9028','(95) 91451-4681',NULL,44,2),(44,'Ishmael','Middleton','2018-12-17 00:00:00','10538151','10538151','1902038',1,'(49) 9210-8645','(38) 97604-4241',NULL,45,2),(45,'Raven','Cummings','2019-02-02 00:00:00','7660759','7660759','1902039',2,'(45) 6594-1854','(66) 97787-3464',NULL,46,2),(46,'Hamilton','Castillo','2020-03-17 00:00:00','17999521','17999521','1902040',1,'(91) 8527-3233','(20) 92076-7226',NULL,47,2),(47,'Knox','Rosario','2019-12-13 00:00:00','49404424','49404424','1902041',2,'(99) 5104-0222','(30) 94219-7763',NULL,48,2),(48,'Dexter','Roberson','2019-04-04 00:00:00','29098515','29098515','1902042',2,'(49) 9742-2814','(55) 90510-5247',NULL,49,2),(49,'Merrill','Campbell','2019-09-11 00:00:00','18656139','18656139','1902043',2,'(53) 6368-4009','(22) 92411-7704',NULL,50,2),(50,'Amery','Santiago','2019-07-18 00:00:00','13521538','13521538','1902044',2,'(10) 4105-8542','(76) 98785-5385',NULL,51,2),(51,'Brenda','Mcintosh','2019-12-23 00:00:00','6289234','6289234','1902045',2,'(37) 7854-5506','(26) 94292-6422',NULL,52,2),(52,'Jescie','Cantrell','2020-01-16 00:00:00','27478123','27478123','1902046',2,'(41) 1687-8093','(44) 93733-3417',NULL,53,2),(53,'September','Workman','2018-12-01 00:00:00','20316513','20316513','1902047',2,'(67) 4005-0589','(89) 97079-8772',NULL,54,2),(54,'Kameko','Black','2019-10-15 00:00:00','32681180','32681180','1902048',2,'(39) 1477-1690','(51) 99314-6389',NULL,55,2),(55,'Ivan','House','2020-02-15 00:00:00','15485229','15485229','1902049',1,'(70) 3492-3850','(15) 95176-0612',NULL,56,2),(56,'Kathleen','Fulton','2020-02-23 00:00:00','25573461','25573461','1902050',2,'(72) 6486-3791','(82) 98750-1098',NULL,57,2),(57,'Vernon','Little','2019-07-23 00:00:00','24394214','24394214','1902051',1,'(84) 8772-5574','(47) 99343-5095',NULL,58,2),(58,'Virginia','Fuller','2018-07-30 00:00:00','38815838','38815838','1902052',2,'(78) 1985-4959','(97) 98675-2782',NULL,59,2),(59,'Carla','Camacho','2020-03-09 00:00:00','31048873','31048873','1902053',1,'(82) 7757-6435','(91) 92688-6962',NULL,60,2),(60,'Acton','Smith','2019-02-19 00:00:00','18747987','18747987','1902054',1,'(72) 7078-2472','(68) 99969-9267',NULL,61,2),(61,'Tarik','Hughes','2019-01-07 00:00:00','23126308','23126308','1902055',1,'(23) 1167-8950','(74) 92077-0721',NULL,62,2),(62,'Winter','Justice','2019-10-11 00:00:00','34038777','34038777','1902056',2,'(91) 8039-5276','(99) 90327-8631',NULL,63,2),(63,'Yvette','Dodson','2018-05-04 00:00:00','28480775','28480775','1902057',1,'(45) 2912-7812','(42) 96214-4145',NULL,64,2),(64,'Hiroko','Fernandez','2019-08-15 00:00:00','49725890','49725890','1902058',1,'(54) 2228-3972','(22) 97039-3595',NULL,65,2),(65,'Kiayada','Hull','2019-06-05 00:00:00','14973748','14973748','1902059',2,'(46) 8766-2208','(93) 96568-1673',NULL,66,2),(66,'Medge','Mcleod','2020-01-17 00:00:00','45360742','45360742','1902060',1,'(84) 3253-4554','(38) 96001-8412',NULL,67,2),(67,'Byron','Wolfe','2019-07-11 00:00:00','45950304','45950304','1902061',1,'(88) 6064-6716','(37) 98767-1107',NULL,68,2),(68,'Alyssa','Chen','2018-05-21 00:00:00','28674531','28674531','1902062',1,'(55) 1880-9509','(51) 91821-0310',NULL,69,2),(69,'Sean','Evans','2018-10-18 00:00:00','18782869','18782869','1902063',2,'(20) 2391-9417','(74) 92507-3828',NULL,70,2),(70,'Barclay','Pace','2018-10-20 00:00:00','30258949','30258949','1902064',2,'(35) 4409-6683','(45) 91083-0180',NULL,71,2),(71,'Wylie','Hodges','2019-11-18 00:00:00','6963850','6963850','1902065',2,'(65) 4518-2172','(24) 99016-4608',NULL,72,2),(72,'Macey','Lyons','2019-05-07 00:00:00','29884168','29884168','1902066',1,'(61) 2891-7969','(51) 93445-0047',NULL,73,2),(73,'Shaine','Mitchell','2020-04-03 00:00:00','22915120','22915120','1902067',1,'(78) 9524-5439','(85) 90741-9559',NULL,74,2),(74,'Myra','Sampson','2018-09-16 00:00:00','45802601','45802601','1902068',2,'(17) 9694-2241','(80) 92908-3424',NULL,75,2),(75,'Levi','English','2018-12-13 00:00:00','50435215','50435215','1902069',2,'(92) 3780-7140','(15) 90036-7198',NULL,76,2),(76,'Simon','Garner','2020-02-22 00:00:00','35253529','35253529','1902070',2,'(10) 1152-2127','(75) 98007-2037',NULL,77,2),(77,'Keegan','Kirby','2020-01-31 00:00:00','12915674','12915674','1902071',1,'(30) 9577-1273','(49) 94552-4337',NULL,78,2),(78,'Hiram','Cain','2019-01-31 00:00:00','44229070','44229070','1902072',1,'(11) 8419-6975','(72) 97025-0001',NULL,79,2),(79,'Gregory','Johns','2020-02-11 00:00:00','13412623','13412623','1902073',1,'(85) 7156-8336','(75) 98279-7497',NULL,80,2),(80,'Brandon','Barr','2020-04-22 00:00:00','29472868','29472868','1902074',1,'(52) 7277-3895','(32) 91306-6768',NULL,81,2),(81,'Adria','Good','2020-01-07 00:00:00','50437648','50437648','1902075',1,'(18) 2395-2203','(88) 96036-0760',NULL,82,2),(82,'Minerva','Cross','2018-05-11 00:00:00','19089326','19089326','1902076',2,'(12) 1618-5719','(41) 94140-6447',NULL,83,2),(83,'Dai','Rojas','2020-01-16 00:00:00','50305675','50305675','1902077',1,'(87) 6785-1577','(26) 98209-0534',NULL,84,2),(84,'Jerry','Casey','2018-06-28 00:00:00','49379752','49379752','1902078',2,'(93) 9674-3368','(72) 96185-9511',NULL,85,2),(85,'Lee','Roy','2020-01-04 00:00:00','9337149','9337149','1902079',2,'(51) 5212-8881','(60) 98751-5065',NULL,86,2),(86,'James','Larsen','2019-08-07 00:00:00','31887683','31887683','1902080',1,'(28) 9763-1923','(34) 94019-2154',NULL,87,2),(87,'Dean','Osborn','2018-11-01 00:00:00','32278507','32278507','1902081',1,'(37) 2543-0283','(32) 93230-1464',NULL,88,2),(88,'Warren','Bowman','2019-04-13 00:00:00','10184207','10184207','1902082',2,'(53) 9289-5439','(67) 99352-7762',NULL,89,2),(89,'Reece','Eaton','2019-11-20 00:00:00','6011371','6011371','1902083',1,'(50) 9164-7454','(31) 95598-7539',NULL,90,2),(90,'Leigh','Oliver','2019-11-23 00:00:00','42587655','42587655','1902084',2,'(50) 1510-8766','(89) 97192-2838',NULL,91,2),(91,'Wesley','King','2018-08-07 00:00:00','38149101','38149101','1902085',1,'(63) 2524-1538','(24) 93949-3302',NULL,92,2),(92,'Ryder','Olsen','2019-04-28 00:00:00','47673039','47673039','1902086',1,'(20) 7049-8966','(36) 96515-8996',NULL,93,2),(93,'Kadeem','Hall','2019-10-22 00:00:00','24425501','24425501','1902087',1,'(56) 3470-1270','(54) 97514-6402',NULL,94,2),(94,'Jane','Sweeney','2019-04-01 00:00:00','28321553','28321553','1902088',2,'(83) 6575-3945','(29) 94817-3784',NULL,95,2),(95,'Vivian','Woodard','2018-10-24 00:00:00','45150651','45150651','1902089',2,'(45) 9883-0420','(27) 90734-1701',NULL,96,2),(96,'Colt','Mcdonald','2019-07-06 00:00:00','30667311','30667311','1902090',2,'(39) 6560-5716','(95) 98806-9152',NULL,97,2),(97,'Kaseem','Fuentes','2019-01-08 00:00:00','49028145','49028145','1902091',2,'(82) 1329-1188','(16) 96035-9854',NULL,98,2),(98,'Zephr','Dotson','2019-09-21 00:00:00','20440874','20440874','1902092',2,'(97) 6554-2537','(59) 97252-6000',NULL,99,2),(99,'Libby','Mcgowan','2018-12-29 00:00:00','46155477','46155477','1902093',2,'(92) 7238-4697','(20) 96317-5986',NULL,100,2),(100,'Alexander','Jacobson','2018-05-22 00:00:00','22845909','22845909','1902094',2,'(18) 9445-8607','(35) 90784-4584',NULL,101,2),(101,'Baxter','Fuller','2018-11-22 00:00:00','16711082','16711082','1902095',1,'(61) 3948-0899','(77) 90493-2981',NULL,102,2),(102,'Acton','Pierce','2020-04-14 00:00:00','39964421','39964421','1902096',1,'(61) 2140-0011','(51) 93309-5161',NULL,103,2),(103,'Norman','Myers','2019-08-16 00:00:00','17880535','17880535','1902097',2,'(22) 6547-4597','(49) 90876-2393',NULL,104,2),(104,'Troy','Bell','2019-02-03 00:00:00','18601045','18601045','1902098',1,'(44) 6780-0351','(65) 92277-4767',NULL,105,2),(105,'Guinevere','Caldwell','2019-08-22 00:00:00','20281716','20281716','1902099',1,'(11) 6705-1245','(46) 91996-4820',NULL,106,2),(106,'Paloma','Skinner','2019-03-23 00:00:00','14335154','14335154','1902100',2,'(20) 1973-6184','(71) 97039-9638',NULL,107,2);
/*!40000 ALTER TABLE `pessoas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `planos`
--

DROP TABLE IF EXISTS `planos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `planos` (
  `pla_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `pla_qtd_totens` int(11) NOT NULL,
  `pla_qtd_tags` int(11) NOT NULL,
  `pla_preco_totens` double NOT NULL,
  `pla_preco_tags` double NOT NULL,
  `pla_estado` tinyint(4) NOT NULL,
  `ins_codigo` int(11) NOT NULL,
  PRIMARY KEY (`pla_codigo`),
  KEY `fk_planos_instituicoes1_idx` (`ins_codigo`),
  CONSTRAINT `fk_planos_instituicoes1` FOREIGN KEY (`ins_codigo`) REFERENCES `instituicoes` (`ins_codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `planos`
--

LOCK TABLES `planos` WRITE;
/*!40000 ALTER TABLE `planos` DISABLE KEYS */;
/*!40000 ALTER TABLE `planos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `presencas`
--

DROP TABLE IF EXISTS `presencas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `presencas` (
  `ses_codigo` int(11) NOT NULL,
  `ide_codigo` int(11) NOT NULL,
  `pre_horario_entrada` datetime NOT NULL,
  `pre_horario_saida` datetime DEFAULT NULL,
  `pre_sessao_automatico` tinyint(1) NOT NULL,
  PRIMARY KEY (`ses_codigo`,`ide_codigo`),
  KEY `fk_presencas_cartoes1_idx` (`ide_codigo`),
  KEY `fk_presencas_sessoes1_idx` (`ses_codigo`),
  CONSTRAINT `fk_presencas_cartoes1` FOREIGN KEY (`ide_codigo`) REFERENCES `identificadores` (`ide_codigo`),
  CONSTRAINT `fk_presencas_sessoes1` FOREIGN KEY (`ses_codigo`) REFERENCES `sessoes` (`ses_codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `presencas`
--

LOCK TABLES `presencas` WRITE;
/*!40000 ALTER TABLE `presencas` DISABLE KEYS */;
INSERT INTO `presencas` VALUES (2,109,'2019-08-05 15:51:36',NULL,1),(2,111,'2019-08-05 15:51:48',NULL,1),(2,112,'2019-08-05 15:51:53',NULL,1),(2,114,'2019-08-05 15:51:59',NULL,1);
/*!40000 ALTER TABLE `presencas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sessoes`
--

DROP TABLE IF EXISTS `sessoes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sessoes` (
  `ses_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `ses_horario_inicio` datetime NOT NULL,
  `ses_horario_fim` datetime DEFAULT NULL,
  `ses_sessao_automatico` tinyint(1) NOT NULL,
  `tot_codigo` int(11) DEFAULT NULL,
  `hev_codigo` int(11) NOT NULL,
  `eau_codigo` int(11) NOT NULL,
  PRIMARY KEY (`ses_codigo`),
  KEY `fk_sessoes_totens1_idx` (`tot_codigo`),
  KEY `fk_sessoes_horarios_eventos1_idx` (`hev_codigo`),
  KEY `fk_sessoes_enventos_auditores1_idx` (`eau_codigo`),
  CONSTRAINT `fk_sessoes_enventos_auditores1` FOREIGN KEY (`eau_codigo`) REFERENCES `eventos_auditores` (`eau_codigo`),
  CONSTRAINT `fk_sessoes_horarios_eventos1` FOREIGN KEY (`hev_codigo`) REFERENCES `horarios_eventos` (`hev_codigo`),
  CONSTRAINT `fk_sessoes_totens1` FOREIGN KEY (`tot_codigo`) REFERENCES `totens` (`tot_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sessoes`
--

LOCK TABLES `sessoes` WRITE;
/*!40000 ALTER TABLE `sessoes` DISABLE KEYS */;
INSERT INTO `sessoes` VALUES (1,'2019-04-26 22:09:00','2019-04-26 22:09:00',0,NULL,1,1),(2,'2019-08-05 15:51:09','2019-08-05 15:52:05',1,NULL,1,2);
/*!40000 ALTER TABLE `sessoes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipos_eventos`
--

DROP TABLE IF EXISTS `tipos_eventos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tipos_eventos` (
  `tev_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `tev_titulo` varchar(50) NOT NULL,
  PRIMARY KEY (`tev_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipos_eventos`
--

LOCK TABLES `tipos_eventos` WRITE;
/*!40000 ALTER TABLE `tipos_eventos` DISABLE KEYS */;
INSERT INTO `tipos_eventos` VALUES (1,'Disciplina'),(2,'Evento');
/*!40000 ALTER TABLE `tipos_eventos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipos_identificadores`
--

DROP TABLE IF EXISTS `tipos_identificadores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tipos_identificadores` (
  `tid_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `tid_titulo` varchar(45) NOT NULL,
  PRIMARY KEY (`tid_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipos_identificadores`
--

LOCK TABLES `tipos_identificadores` WRITE;
/*!40000 ALTER TABLE `tipos_identificadores` DISABLE KEYS */;
INSERT INTO `tipos_identificadores` VALUES (1,'Cartão RFID');
/*!40000 ALTER TABLE `tipos_identificadores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipos_usuarios`
--

DROP TABLE IF EXISTS `tipos_usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tipos_usuarios` (
  `tus_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `tus_titulo` varchar(45) NOT NULL,
  PRIMARY KEY (`tus_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipos_usuarios`
--

LOCK TABLES `tipos_usuarios` WRITE;
/*!40000 ALTER TABLE `tipos_usuarios` DISABLE KEYS */;
INSERT INTO `tipos_usuarios` VALUES (1,'Administrador'),(2,'Gerente Geral'),(3,'Gerente Cadastro'),(4,'Auditor'),(5,'Aluno');
/*!40000 ALTER TABLE `tipos_usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `totens`
--

DROP TABLE IF EXISTS `totens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `totens` (
  `tot_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `tot_nome` varchar(120) NOT NULL,
  `tot_numero_serie` varchar(50) NOT NULL,
  `tot_estado` tinyint(4) NOT NULL,
  `tot_operacao` tinyint(4) NOT NULL,
  `ins_codigo` int(11) NOT NULL,
  PRIMARY KEY (`tot_codigo`),
  KEY `fk_totens_instituicoes1_idx` (`ins_codigo`),
  CONSTRAINT `fk_totens_instituicoes1` FOREIGN KEY (`ins_codigo`) REFERENCES `instituicoes` (`ins_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `totens`
--

LOCK TABLES `totens` WRITE;
/*!40000 ALTER TABLE `totens` DISABLE KEYS */;
INSERT INTO `totens` VALUES (1,'Sala 11A','2019061800001',1,1,2);
/*!40000 ALTER TABLE `totens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `turmas`
--

DROP TABLE IF EXISTS `turmas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `turmas` (
  `usu_codigo` int(11) NOT NULL,
  `eau_codigo` int(11) NOT NULL,
  PRIMARY KEY (`usu_codigo`,`eau_codigo`),
  KEY `fk_turmas_usuarios1_idx` (`usu_codigo`),
  KEY `fk_turmas_envento_auditor1_idx` (`eau_codigo`),
  CONSTRAINT `fk_turmas_envento_auditor1` FOREIGN KEY (`eau_codigo`) REFERENCES `eventos_auditores` (`eau_codigo`),
  CONSTRAINT `fk_turmas_usuarios1` FOREIGN KEY (`usu_codigo`) REFERENCES `usuarios` (`usu_codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `turmas`
--

LOCK TABLES `turmas` WRITE;
/*!40000 ALTER TABLE `turmas` DISABLE KEYS */;
INSERT INTO `turmas` VALUES (5,1),(16,2),(20,1),(27,2),(36,2),(50,1);
/*!40000 ALTER TABLE `turmas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `usuarios` (
  `usu_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `usu_login` varchar(50) NOT NULL,
  `usu_senha` text NOT NULL,
  `usu_estado` tinyint(4) NOT NULL,
  `usu_data_criacao` datetime NOT NULL,
  `usu_data_desativacao` datetime DEFAULT NULL,
  `usu_primeiro_login` tinyint(4) NOT NULL,
  `usu_redefinir_senha` tinyint(4) NOT NULL,
  `pes_codigo` int(11) NOT NULL,
  `tus_codigo` int(11) NOT NULL,
  `gra_codigo` int(11) DEFAULT NULL,
  PRIMARY KEY (`usu_codigo`),
  UNIQUE KEY `login_UNIQUE` (`usu_login`),
  KEY `fk_usuarios_pessoas1_idx` (`pes_codigo`),
  KEY `fk_usuarios_tipo_usuario1_idx` (`tus_codigo`),
  KEY `fk_usuarios_grades1_idx` (`gra_codigo`),
  CONSTRAINT `fk_usuarios_grades1` FOREIGN KEY (`gra_codigo`) REFERENCES `grades` (`gra_codigo`),
  CONSTRAINT `fk_usuarios_pessoas1` FOREIGN KEY (`pes_codigo`) REFERENCES `pessoas` (`pes_codigo`),
  CONSTRAINT `fk_usuarios_tipo_usuario1` FOREIGN KEY (`tus_codigo`) REFERENCES `tipos_usuarios` (`tus_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=107 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,'adm@teste.com','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-01-12 00:00:00','0001-01-01 00:00:00',0,0,1,1,NULL),(2,'geral@teste.com','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-01-12 00:00:00','0001-01-01 00:00:00',0,0,2,2,NULL),(3,'cadastro@teste.com','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-01-12 00:00:00','0001-01-01 00:00:00',0,0,3,3,NULL),(4,'auditor@teste.com','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-01-12 00:00:00','0001-01-01 00:00:00',0,0,4,4,NULL),(5,'aluno@teste.com','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-01-12 00:00:00','0001-01-01 00:00:00',0,0,5,5,1),(6,'aluno2@teste.com','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-01-12 00:00:00','0001-01-01 00:00:00',0,0,6,5,1),(7,'at.augue@augue.ca','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-01-06 00:00:00',NULL,1,0,7,3,1),(8,'egestas.Aliquam@orci.edu','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-10-17 00:00:00',NULL,1,0,8,4,1),(9,'adipiscing@elitpellentesquea.net','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-10-28 00:00:00',NULL,1,0,9,5,1),(10,'pede.ultrices.a@nunc.com','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-03-23 00:00:00',NULL,1,0,10,5,1),(11,'auditor2@teste.com','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-08-19 00:00:00',NULL,1,0,11,4,1),(12,'semper@Integermollis.edu','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-09-03 00:00:00',NULL,1,0,12,2,1),(13,'nibh@Nuncmauriselit.com','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-07-22 00:00:00',NULL,1,0,13,4,1),(14,'orci.lobortis.augue@Donecest.co.uk','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-03-25 00:00:00',NULL,1,0,14,4,1),(15,'semper.rutrum@nonjustoProin.ca','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-12-17 00:00:00',NULL,1,0,15,4,1),(16,'nec.euismod@maurisInteger.co.uk','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-06-15 00:00:00',NULL,1,0,16,5,1),(17,'Morbi.sit@nuncinterdum.org','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-06-03 00:00:00',NULL,1,0,17,5,1),(18,'Aenean@lorem.com','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-05-23 00:00:00',NULL,1,0,18,5,1),(19,'urna@diamvelarcu.ca','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-04-29 00:00:00',NULL,1,0,19,5,1),(20,'Phasellus.nulla.Integer@vulputate.org','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-06-20 00:00:00',NULL,1,0,20,5,1),(21,'sit.amet@in.ca','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-02-20 00:00:00',NULL,1,0,21,5,1),(22,'turpis.Nulla.aliquet@lacuspedesagittis.com','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-09-02 00:00:00',NULL,1,0,22,5,1),(23,'quis.pede@velitinaliquet.edu','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-09-08 00:00:00',NULL,1,0,23,5,1),(24,'Nunc.ut.erat@a.co.uk','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-06-04 00:00:00',NULL,1,0,24,4,1),(25,'quis@luctusutpellentesque.org','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-01-30 00:00:00',NULL,1,0,25,5,1),(26,'lacinia.at.iaculis@utcursusluctus.net','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-05-26 00:00:00',NULL,1,0,26,5,1),(27,'nonummy.ut@vitae.edu','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-05-19 00:00:00',NULL,1,0,27,5,1),(28,'rutrum.urna.nec@odio.ca','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-04-04 00:00:00',NULL,1,0,28,5,1),(29,'tellus.faucibus.leo@vulputatelacusCras.net','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-02-05 00:00:00',NULL,1,0,29,5,1),(30,'Morbi.metus@Sednullaante.edu','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-01-25 00:00:00',NULL,1,0,30,5,1),(31,'Suspendisse.aliquet@nonenimMauris.com','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-06-20 00:00:00',NULL,1,0,31,4,1),(32,'orci.lacus.vestibulum@vitae.edu','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-09-17 00:00:00',NULL,1,0,32,4,1),(33,'mattis@consectetuer.ca','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-03-26 00:00:00',NULL,1,0,33,4,1),(34,'a.arcu@Vestibulum.ca','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-01-05 00:00:00',NULL,1,0,34,4,1),(35,'amet.diam@neque.ca','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-01-30 00:00:00',NULL,1,0,35,4,1),(36,'at.risus@iaculisnec.ca','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-02-05 00:00:00',NULL,1,0,36,5,1),(37,'vitae@vitaedolor.edu','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-02-27 00:00:00',NULL,1,0,37,4,1),(38,'diam.Duis@eusem.edu','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-04-18 00:00:00',NULL,1,0,38,4,1),(39,'tortor.Nunc.commodo@ac.edu','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-02-16 00:00:00',NULL,1,0,39,5,1),(40,'venenatis@eunibhvulputate.net','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-06-15 00:00:00',NULL,1,0,40,4,1),(41,'tellus.id@Proinsedturpis.co.uk','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-08-23 00:00:00',NULL,1,0,41,4,1),(42,'erat@elitNulla.org','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-05-14 00:00:00',NULL,1,0,42,4,1),(43,'mollis.lectus@ipsum.org','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-05-03 00:00:00',NULL,1,0,43,5,1),(44,'posuere.enim.nisl@nequesedsem.com','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-12-17 00:00:00',NULL,1,0,44,4,1),(45,'et@estNunc.com','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-02-02 00:00:00',NULL,1,0,45,4,1),(46,'Nunc.quis@Proindolor.net','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-03-17 00:00:00',NULL,1,0,46,5,1),(47,'Sed.eget@consectetueradipiscing.net','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-12-13 00:00:00',NULL,1,0,47,4,1),(48,'Donec.consectetuer@Inatpede.ca','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-04-04 00:00:00',NULL,1,0,48,5,1),(49,'et.ipsum@nullamagnamalesuada.co.uk','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-09-11 00:00:00',NULL,1,0,49,4,1),(50,'augue@purusmauris.co.uk','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-07-18 00:00:00',NULL,1,0,50,5,1),(51,'rhoncus@Donec.edu','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-12-23 00:00:00',NULL,1,0,51,5,1),(52,'at.nisi.Cum@utodio.co.uk','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-01-16 00:00:00',NULL,1,0,52,4,1),(53,'velit.Aliquam.nisl@Maecenasmi.org','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-12-01 00:00:00',NULL,1,0,53,5,1),(54,'malesuada.vel@purussapiengravida.edu','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-10-15 00:00:00',NULL,1,0,54,4,1),(55,'nisl.Quisque@lectus.edu','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-02-15 00:00:00',NULL,1,0,55,4,1),(56,'nisi@loremegetmollis.co.uk','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-02-23 00:00:00',NULL,1,0,56,4,1),(57,'semper@ultricesmaurisipsum.net','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-07-23 00:00:00',NULL,1,0,57,4,1),(58,'elit.fermentum.risus@dignissim.org','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-07-30 00:00:00',NULL,1,0,58,4,1),(59,'parturient.montes@sociosqu.com','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-03-09 00:00:00',NULL,1,0,59,4,1),(60,'in.faucibus.orci@mollislectus.com','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-02-19 00:00:00',NULL,1,0,60,5,1),(61,'lacus.Aliquam@habitantmorbitristique.net','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-01-07 00:00:00',NULL,1,0,61,4,1),(62,'mollis.dui.in@sollicitudinadipiscingligula.net','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-10-11 00:00:00',NULL,1,0,62,4,1),(63,'sodales@luctussitamet.edu','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-05-04 00:00:00',NULL,1,0,63,4,1),(64,'mauris.Integer.sem@elitfermentum.com','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-08-15 00:00:00',NULL,1,0,64,5,1),(65,'aliquet@Cumsociis.ca','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-06-05 00:00:00',NULL,1,0,65,5,1),(66,'eu.tellus@ac.org','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-01-17 00:00:00',NULL,1,0,66,4,1),(67,'nec@dictum.ca','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-07-11 00:00:00',NULL,1,0,67,4,1),(68,'Donec.felis.orci@dolor.edu','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-05-21 00:00:00',NULL,1,0,68,5,1),(69,'cursus.a.enim@quam.ca','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-10-18 00:00:00',NULL,1,0,69,5,1),(70,'Duis.dignissim.tempor@aliquetlobortis.co.uk','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-10-20 00:00:00',NULL,1,0,70,5,1),(71,'convallis.ligula.Donec@Pellentesquetincidunt.co.uk','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-11-18 00:00:00',NULL,1,0,71,5,1),(72,'Ut@vestibulummassa.co.uk','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-05-07 00:00:00',NULL,1,0,72,5,1),(73,'mauris.eu@loremipsumsodales.com','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-04-03 00:00:00',NULL,1,0,73,5,1),(74,'vestibulum.Mauris@nisl.edu','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-09-16 00:00:00',NULL,1,0,74,4,1),(75,'nunc.sed@sitametfaucibus.ca','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-12-13 00:00:00',NULL,1,0,75,5,1),(76,'aptent.taciti.sociosqu@elementum.ca','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-02-22 00:00:00',NULL,1,0,76,4,1),(77,'Lorem.ipsum@In.org','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-01-31 00:00:00',NULL,1,0,77,4,1),(78,'diam.Pellentesque@Proinsedturpis.com','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-01-31 00:00:00',NULL,1,0,78,4,1),(79,'adipiscing.lacus@egestasDuis.edu','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-02-11 00:00:00',NULL,1,0,79,5,1),(80,'elit@velitinaliquet.net','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-04-22 00:00:00',NULL,1,0,80,4,1),(81,'Suspendisse@dolor.edu','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-01-07 00:00:00',NULL,1,0,81,5,1),(82,'tellus@aliquam.org','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-05-11 00:00:00',NULL,1,0,82,4,1),(83,'erat@vel.net','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-01-16 00:00:00',NULL,1,0,83,4,1),(84,'arcu@Vivamus.com','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-06-28 00:00:00',NULL,1,0,84,5,1),(85,'Mauris@acfermentumvel.ca','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-01-04 00:00:00',NULL,1,0,85,5,1),(86,'In.ornare@pellentesque.edu','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-08-07 00:00:00',NULL,1,0,86,5,1),(87,'lacus@ipsumdolor.ca','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-11-01 00:00:00',NULL,1,0,87,4,1),(88,'arcu.ac.orci@tempordiam.net','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-04-13 00:00:00',NULL,1,0,88,4,1),(89,'venenatis@eleifend.co.uk','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-11-20 00:00:00',NULL,1,0,89,4,1),(90,'amet.risus.Donec@miacmattis.org','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-11-23 00:00:00',NULL,1,0,90,4,1),(91,'Nunc@quisurnaNunc.org','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-08-07 00:00:00',NULL,1,0,91,4,1),(92,'Suspendisse.ac@dictumeu.edu','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-04-28 00:00:00',NULL,1,0,92,4,1),(93,'mollis@enimEtiamimperdiet.edu','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-10-22 00:00:00',NULL,1,0,93,5,1),(94,'sed@nibh.net','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-04-01 00:00:00',NULL,1,0,94,4,1),(95,'vulputate.ullamcorper.magna@metussit.com','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-10-24 00:00:00',NULL,1,0,95,5,1),(96,'adipiscing.fringilla@aliquetvelvulputate.org','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-07-06 00:00:00',NULL,1,0,96,4,1),(97,'Nam@vitaealiquam.co.uk','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-01-08 00:00:00',NULL,1,0,97,5,1),(98,'quam.vel@et.ca','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-09-21 00:00:00',NULL,1,0,98,5,1),(99,'Vestibulum.ut@cubiliaCuraeDonec.com','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-12-29 00:00:00',NULL,1,0,99,5,1),(100,'ultrices.mauris@ultriciessem.org','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-05-22 00:00:00',NULL,1,0,100,4,1),(101,'sem@velit.ca','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2018-11-22 00:00:00',NULL,1,0,101,5,1),(102,'euismod.in@Proineget.edu','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2020-04-14 00:00:00',NULL,1,0,102,4,1),(103,'magna.Suspendisse.tristique@mollisPhasellus.org','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-08-16 00:00:00',NULL,1,0,103,5,1),(104,'at@ipsum.co.uk','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-02-03 00:00:00',NULL,1,0,104,4,1),(105,'enim@euodiotristique.net','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-08-22 00:00:00',NULL,1,0,105,5,1),(106,'sed.pede.nec@nectempusscelerisque.net','5d68217d0c3ddfc029f1f8f2e61a80a8256342f27893ff0fe55da861e75325d6f7c805a26cae587f01aee7980700e8f06422c233a0e2a8e9bf26aad0c39e00c6',1,'2019-03-23 00:00:00',NULL,1,0,106,5,1);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'passcenter'
--

--
-- Dumping routines for database 'passcenter'
--
/*!50003 DROP PROCEDURE IF EXISTS `InserirPresenca` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`passcenter`@`%` PROCEDURE `InserirPresenca`(IN vEau_codigo INT, IN vPes_codigo INT, IN list_of_ids TEXT, IN vPre_horario_entrada DATETIME, IN vPre_horario_saida DATETIME, IN vSes_codigo INT)
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
       
	END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InserirUsuario` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`passcenter`@`%` PROCEDURE `InserirUsuario`(
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
        
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Matricular` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`passcenter`@`%` PROCEDURE `Matricular`(IN usu_codigoP INT, IN gra_codigoP INT)
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
       
	END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `MigrarAno` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`passcenter`@`%` PROCEDURE `MigrarAno`(in vInstituicao int, in vPeriodo varchar(45))
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
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-06 11:51:08
