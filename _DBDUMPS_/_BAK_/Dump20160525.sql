CREATE DATABASE  IF NOT EXISTS `sys_pos` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `sys_pos`;
-- MySQL dump 10.13  Distrib 5.5.16, for Win32 (x86)
--
-- Host: localhost    Database: sys_pos
-- ------------------------------------------------------
-- Server version	5.5.28

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `account_credit`
--

DROP TABLE IF EXISTS `account_credit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `account_credit` (
  `credit_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `credit_sales_id` int(10) unsigned NOT NULL,
  `credit_duedate` date NOT NULL,
  `credit_nominal` double NOT NULL,
  `credit_paid` tinyint(4) unsigned DEFAULT NULL,
  PRIMARY KEY (`credit_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `account_credit`
--

LOCK TABLES `account_credit` WRITE;
/*!40000 ALTER TABLE `account_credit` DISABLE KEYS */;
/*!40000 ALTER TABLE `account_credit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `account_debt`
--

DROP TABLE IF EXISTS `account_debt`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `account_debt` (
  `debt_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `debt_purchase_id` int(10) unsigned NOT NULL,
  `debt_duedate` date NOT NULL,
  `debt_nominal` double NOT NULL,
  `debt_paid` tinyint(3) unsigned DEFAULT NULL,
  PRIMARY KEY (`debt_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `account_debt`
--

LOCK TABLES `account_debt` WRITE;
/*!40000 ALTER TABLE `account_debt` DISABLE KEYS */;
/*!40000 ALTER TABLE `account_debt` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `account_journal`
--

DROP TABLE IF EXISTS `account_journal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `account_journal` (
  `journal_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `account_id` smallint(5) unsigned NOT NULL,
  `journal_date` date NOT NULL,
  `account_nominal` double NOT NULL,
  `branch_id` tinyint(3) unsigned NOT NULL,
  `journal_description` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`journal_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `account_journal`
--

LOCK TABLES `account_journal` WRITE;
/*!40000 ALTER TABLE `account_journal` DISABLE KEYS */;
/*!40000 ALTER TABLE `account_journal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cashier_log`
--

DROP TABLE IF EXISTS `cashier_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cashier_log` (
  `ID` smallint(5) unsigned NOT NULL AUTO_INCREMENT,
  `USER_ID` tinyint(3) unsigned DEFAULT NULL,
  `DATE_LOGIN` datetime DEFAULT NULL,
  `DATE_LOGOUT` datetime DEFAULT NULL,
  `AMOUNT_START` double DEFAULT NULL,
  `AMOUNT_END` double DEFAULT NULL,
  `ACCOUNT_ID` smallint(5) unsigned DEFAULT NULL,
  `COMMENT` varchar(100) DEFAULT NULL,
  `TOTAL_CASH_TRANSACTION` double DEFAULT '0',
  `TOTAL_NON_CASH_TRANSACTION` double DEFAULT '0',
  `TOTAL_OTHER_TRANSACTION` double DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cashier_log`
--

LOCK TABLES `cashier_log` WRITE;
/*!40000 ALTER TABLE `cashier_log` DISABLE KEYS */;
INSERT INTO `cashier_log` VALUES (1,2,'2016-04-30 00:10:00','2016-04-30 14:34:00',1000,0,NULL,NULL,0,0,0),(2,2,'2016-04-30 11:35:00','2016-04-30 14:32:00',0,0,NULL,NULL,0,0,0),(3,2,'2016-04-30 14:35:00','2016-04-30 14:42:00',10000,10000,NULL,'AAAAA',0,0,0),(4,2,'2016-04-30 14:44:00','2016-04-30 14:47:00',10000,10000,NULL,'AAAAA',0,0,0),(5,2,'2016-04-30 14:55:00','2016-04-30 14:55:00',10000,123,NULL,'AAA',0,0,0),(6,2,'2016-04-30 18:53:00','2016-05-02 12:15:00',10000,10000,NULL,'',20000,0,0),(7,2,'2016-05-02 12:17:00','2016-05-02 12:25:00',10000,20000,NULL,'',1200,200,0),(8,2,'2016-05-02 12:32:00','2016-05-02 12:42:00',10000,2000,NULL,'',0,0,-20000),(9,2,'2016-05-16 18:10:00','2016-05-16 18:10:00',1000,1000,NULL,'',0,0,0);
/*!40000 ALTER TABLE `cashier_log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `credit`
--

DROP TABLE IF EXISTS `credit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `credit` (
  `CREDIT_ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `SALES_INVOICE` varchar(30) DEFAULT NULL,
  `PM_INVOICE` varchar(30) DEFAULT NULL,
  `CREDIT_DUE_DATE` date DEFAULT NULL,
  `CREDIT_NOMINAL` double DEFAULT '0',
  `CREDIT_PAID` tinyint(3) unsigned DEFAULT NULL,
  PRIMARY KEY (`CREDIT_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `credit`
--

LOCK TABLES `credit` WRITE;
/*!40000 ALTER TABLE `credit` DISABLE KEYS */;
INSERT INTO `credit` VALUES (1,NULL,'PM-1','2016-04-09',0,0),(2,NULL,'PM-2','2016-04-18',120,0),(3,'SLO00001-1',NULL,'2016-04-18',957.5,1),(5,'SLO00001-2',NULL,'2016-04-18',217.25,1),(6,NULL,'PM-3','2016-04-19',100,0),(7,'SLO00001-3',NULL,'2016-04-21',1925,0),(8,'SLO00001-4',NULL,'2016-04-27',20000,0),(9,'SLO00001-5',NULL,'2016-04-27',20000,1),(10,'SLO00001-6',NULL,'2016-04-27',20000,1),(11,'SLO00001-7',NULL,'2016-04-27',20000,1),(12,'SLO00001-8',NULL,'2016-04-27',60300,1),(13,'SLO00001-9',NULL,'2016-04-27',20200,1),(14,'-1',NULL,'2016-04-30',100,1),(16,'SLO001-1',NULL,'2016-04-30',20000,1),(17,'SLO001-2',NULL,'2016-05-02',1200,1),(18,'SLO001-3',NULL,'2016-05-02',200,1),(19,'SLO001-4',NULL,'2016-05-02',100,1),(20,'SLO001-5',NULL,'2016-05-02',100,1),(21,'SLO001-6',NULL,'2016-05-02',200,1),(22,'SLO001-7',NULL,'2016-05-02',200,1),(23,NULL,'PM-4','2016-05-10',200,0),(24,NULL,'PM-5','2016-05-12',2200,0),(25,NULL,'PM-6','2016-05-12',100,0),(26,NULL,'PM-7','2016-05-12',100,0),(27,NULL,'PM-8','2016-05-12',200,0),(28,NULL,'PM-9','2016-05-12',100,0),(29,NULL,'PM-10','2016-05-12',200,0),(30,NULL,'PM-11','2016-05-12',100,0);
/*!40000 ALTER TABLE `credit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer_product_disc`
--

DROP TABLE IF EXISTS `customer_product_disc`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customer_product_disc` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `CUSTOMER_ID` smallint(6) DEFAULT NULL,
  `PRODUCT_ID` varchar(50) DEFAULT NULL,
  `DISC_1` double unsigned DEFAULT '0',
  `DISC_2` double unsigned DEFAULT '0',
  `DISC_RP` double unsigned DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer_product_disc`
--

LOCK TABLES `customer_product_disc` WRITE;
/*!40000 ALTER TABLE `customer_product_disc` DISABLE KEYS */;
INSERT INTO `customer_product_disc` VALUES (1,1,'PROD-3',1.25,0,0),(2,1,'PROD-1',1.25,0,50),(3,1,'PROD-4',0,0,0);
/*!40000 ALTER TABLE `customer_product_disc` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `daily_journal`
--

DROP TABLE IF EXISTS `daily_journal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `daily_journal` (
  `journal_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `account_id` smallint(5) unsigned NOT NULL,
  `journal_datetime` datetime NOT NULL,
  `journal_nominal` double NOT NULL,
  `branch_id` tinyint(3) unsigned DEFAULT NULL,
  `journal_description` varchar(100) DEFAULT NULL,
  `user_id` tinyint(3) unsigned NOT NULL,
  `pm_id` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY (`journal_id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `daily_journal`
--

LOCK TABLES `daily_journal` WRITE;
/*!40000 ALTER TABLE `daily_journal` DISABLE KEYS */;
INSERT INTO `daily_journal` VALUES (1,1,'2016-04-18 00:00:00',957.5,NULL,'PEMBAYARAN SLO00001-1',1,1),(2,1,'2016-04-18 00:00:00',217.25,NULL,'PEMBAYARAN SLO00001-2',1,1),(3,1,'2016-04-21 00:00:00',1925,NULL,'PEMBAYARAN SLO00001-3',1,1),(4,1,'2016-04-25 00:00:00',20000,NULL,'PEMBAYARAN SLO00001-4',1,1),(5,1,'2016-04-27 00:00:00',20000,NULL,'PEMBAYARAN SLO00001-5',1,1),(6,1,'2016-04-27 00:00:00',20000,NULL,'PEMBAYARAN SLO00001-6',1,1),(7,1,'2016-04-27 00:00:00',20000,NULL,'PEMBAYARAN SLO00001-7',1,1),(8,1,'2016-04-27 00:00:00',60300,NULL,'PEMBAYARAN SLO00001-8',1,1),(9,1,'2016-04-27 00:00:00',20200,NULL,'PEMBAYARAN SLO00001-9',1,1),(10,1,'2016-04-30 00:00:00',100,NULL,'PEMBAYARAN -1',1,1),(11,1,'2016-04-30 23:30:00',20000,NULL,'PEMBAYARAN SLO001-1',1,1),(12,1,'2016-05-02 12:19:00',1200,NULL,'PEMBAYARAN SLO001-2',2,1),(13,6,'2016-05-02 00:00:00',-1000,0,'BAYAR TAGIHAN AIR',2,1),(14,10,'2016-05-02 12:41:00',-10000,0,'BEBAN PERUT',2,1),(15,8,'2016-05-02 12:41:00',-10000,0,'BEBAN LISTRIK',2,1),(16,1,'2016-05-02 00:00:00',100,NULL,'PEMBAYARAN SLO001-4',1,1),(17,1,'2016-05-02 00:00:00',100,NULL,'PEMBAYARAN SLO001-5',1,1),(18,1,'2016-05-02 00:00:00',200,NULL,'PEMBAYARAN SLO001-6',1,1),(19,1,'2016-05-02 00:00:00',200,NULL,'PEMBAYARAN SLO001-7',1,1);
/*!40000 ALTER TABLE `daily_journal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `debt`
--

DROP TABLE IF EXISTS `debt`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `debt` (
  `DEBT_ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PURCHASE_INVOICE` varchar(30) DEFAULT NULL,
  `DEBT_DUE_DATE` date DEFAULT NULL,
  `DEBT_NOMINAL` double DEFAULT '0',
  `DEBT_PAID` tinyint(3) unsigned DEFAULT '0',
  PRIMARY KEY (`DEBT_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `debt`
--

LOCK TABLES `debt` WRITE;
/*!40000 ALTER TABLE `debt` DISABLE KEYS */;
INSERT INTO `debt` VALUES (1,'PR-2','2016-04-28',20000,0),(2,'PO-2','2016-04-28',2000,0),(3,'PO-4','2016-04-18',10000,1),(4,'PO-5','2016-04-21',20000,0),(5,'PO-8','2016-04-26',3000,0),(6,'PR-8','2016-05-04',1800,0);
/*!40000 ALTER TABLE `debt` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_account`
--

DROP TABLE IF EXISTS `master_account`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `master_account` (
  `id` smallint(6) NOT NULL AUTO_INCREMENT,
  `account_id` int(10) unsigned NOT NULL,
  `account_name` varchar(50) NOT NULL,
  `account_type_id` tinyint(3) unsigned NOT NULL,
  `account_active` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `account_name_UNIQUE` (`account_name`),
  UNIQUE KEY `account_id_UNIQUE` (`account_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_account`
--

LOCK TABLES `master_account` WRITE;
/*!40000 ALTER TABLE `master_account` DISABLE KEYS */;
INSERT INTO `master_account` VALUES (1,1,'PENDAPATAN TUNAI PENJUALAN',1,1),(2,2,'PENDAPATAN BCA PENJUALAN',1,1),(3,3,'PIUTANG PENJUALAN',1,1),(4,4,'BEBAN GAJI PUSAT',2,1),(5,5,'BEBAN LISTRIK PUSAT',2,1),(6,6,'BEBAN AIR',2,1),(7,7,'PENDAPATAN LAIN-LAIN',1,1),(8,8,'BEBAN LAIN-LAIN',2,1),(9,10,'BEBAN',2,1);
/*!40000 ALTER TABLE `master_account` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_account_type`
--

DROP TABLE IF EXISTS `master_account_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `master_account_type` (
  `account_type_id` tinyint(3) unsigned NOT NULL AUTO_INCREMENT,
  `account_type_name` varchar(45) NOT NULL,
  PRIMARY KEY (`account_type_id`),
  UNIQUE KEY `account_type_name_UNIQUE` (`account_type_name`),
  UNIQUE KEY `account_type_id_UNIQUE` (`account_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_account_type`
--

LOCK TABLES `master_account_type` WRITE;
/*!40000 ALTER TABLE `master_account_type` DISABLE KEYS */;
INSERT INTO `master_account_type` VALUES (2,'CREDIT'),(1,'DEBET');
/*!40000 ALTER TABLE `master_account_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_branch`
--

DROP TABLE IF EXISTS `master_branch`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `master_branch` (
  `BRANCH_ID` tinyint(3) unsigned NOT NULL AUTO_INCREMENT,
  `BRANCH_NAME` varchar(50) NOT NULL,
  `BRANCH_ADDRESS_1` varchar(50) DEFAULT NULL,
  `BRANCH_ADDRESS_2` varchar(50) DEFAULT NULL,
  `BRANCH_ADDRESS_CITY` varchar(50) DEFAULT NULL,
  `BRANCH_TELEPHONE` varchar(15) DEFAULT NULL,
  `BRANCH_IP4` varchar(15) NOT NULL,
  `BRANCH_ACTIVE` tinyint(1) unsigned DEFAULT NULL,
  PRIMARY KEY (`BRANCH_ID`),
  UNIQUE KEY `BRANCH_NAME_UNIQUE` (`BRANCH_NAME`),
  UNIQUE KEY `BRANCH_IP4_UNIQUE` (`BRANCH_IP4`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_branch`
--

LOCK TABLES `master_branch` WRITE;
/*!40000 ALTER TABLE `master_branch` DISABLE KEYS */;
INSERT INTO `master_branch` VALUES (1,'CABANG SOLO BARU','SOLO BARU','','SOLO','','192.168.1.104',1),(2,'CABANG KRATONAN','KRATONAN','','','','192.111.111.111',1);
/*!40000 ALTER TABLE `master_branch` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_category`
--

DROP TABLE IF EXISTS `master_category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `master_category` (
  `CATEGORY_ID` tinyint(3) unsigned NOT NULL AUTO_INCREMENT,
  `CATEGORY_NAME` varchar(50) DEFAULT NULL,
  `CATEGORY_DESCRIPTION` varchar(100) DEFAULT NULL,
  `CATEGORY_ACTIVE` tinyint(3) unsigned DEFAULT NULL,
  PRIMARY KEY (`CATEGORY_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_category`
--

LOCK TABLES `master_category` WRITE;
/*!40000 ALTER TABLE `master_category` DISABLE KEYS */;
INSERT INTO `master_category` VALUES (1,'PROMOSI','DIJUAL PROMOSI',1),(2,'OBRAL','JUALAN OBRAL',1),(3,'RUSAK','BARANG RUSAK',1);
/*!40000 ALTER TABLE `master_category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_change_id`
--

DROP TABLE IF EXISTS `master_change_id`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `master_change_id` (
  `CHANGE_ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `CHANGE_ID_DESCRIPTION` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`CHANGE_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8 COMMENT='	';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_change_id`
--

LOCK TABLES `master_change_id` WRITE;
/*!40000 ALTER TABLE `master_change_id` DISABLE KEYS */;
INSERT INTO `master_change_id` VALUES (1,'LOGIN'),(2,'LOGOUT'),(3,'INSERT'),(4,'UPDATE'),(5,'SET NON ACTIVE'),(6,'CASHIER LOGIN'),(7,'CASHIER LOGOUT'),(8,'PAYMENT CREDIT'),(9,'PAYMENT DEBT');
/*!40000 ALTER TABLE `master_change_id` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_customer`
--

DROP TABLE IF EXISTS `master_customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `master_customer` (
  `CUSTOMER_ID` smallint(5) unsigned NOT NULL AUTO_INCREMENT,
  `CUSTOMER_FULL_NAME` varchar(50) DEFAULT NULL,
  `CUSTOMER_ADDRESS1` varchar(50) DEFAULT NULL,
  `CUSTOMER_ADDRESS2` varchar(50) DEFAULT NULL,
  `CUSTOMER_ADDRESS_CITY` varchar(50) DEFAULT NULL,
  `CUSTOMER_PHONE` varchar(15) DEFAULT NULL,
  `CUSTOMER_FAX` varchar(15) DEFAULT NULL,
  `CUSTOMER_EMAIL` varchar(50) DEFAULT NULL,
  `CUSTOMER_ACTIVE` tinyint(3) unsigned DEFAULT NULL,
  `CUSTOMER_JOINED_DATE` date DEFAULT NULL,
  `CUSTOMER_TOTAL_SALES_COUNT` int(11) DEFAULT NULL,
  `CUSTOMER_GROUP` tinyint(3) unsigned DEFAULT NULL,
  PRIMARY KEY (`CUSTOMER_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_customer`
--

LOCK TABLES `master_customer` WRITE;
/*!40000 ALTER TABLE `master_customer` DISABLE KEYS */;
INSERT INTO `master_customer` VALUES (1,'ANDRI','JALAN SUKA SUKA','SUKA MAKAN','SUKARATA','081','123','ANDRI@ANDRI.COM',1,'2016-04-09',1900,3);
/*!40000 ALTER TABLE `master_customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_group`
--

DROP TABLE IF EXISTS `master_group`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `master_group` (
  `GROUP_ID` tinyint(3) unsigned NOT NULL AUTO_INCREMENT,
  `GROUP_USER_NAME` varchar(50) NOT NULL,
  `GROUP_USER_DESCRIPTION` varchar(100) NOT NULL,
  `GROUP_USER_ACTIVE` tinyint(1) unsigned NOT NULL,
  `GROUP_IS_CASHIER` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`GROUP_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_group`
--

LOCK TABLES `master_group` WRITE;
/*!40000 ALTER TABLE `master_group` DISABLE KEYS */;
INSERT INTO `master_group` VALUES (1,'GLOBAL_ADMIN','GLOBAL ADMIN GROUP',1,0),(2,'KASIR','AKSES HANYA MODUL PENJUALAN',1,1);
/*!40000 ALTER TABLE `master_group` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_message`
--

DROP TABLE IF EXISTS `master_message`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `master_message` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `STATUS` tinyint(3) unsigned DEFAULT NULL,
  `MODULE_ID` smallint(5) unsigned DEFAULT NULL,
  `IDENTIFIER_NO` varchar(45) DEFAULT NULL,
  `MSG_DATETIME_CREATED` datetime DEFAULT NULL,
  `MSG_CONTENT` varchar(200) DEFAULT NULL,
  `MSG_DATETIME_READ` datetime DEFAULT NULL,
  `MSG_READ_USER_ID` tinyint(3) unsigned DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_message`
--

LOCK TABLES `master_message` WRITE;
/*!40000 ALTER TABLE `master_message` DISABLE KEYS */;
INSERT INTO `master_message` VALUES (6,1,37,'SLO00001-3','2016-04-21 00:00:00','SALES INVOICE [SLO00001-3] JATUH TEMPO TGL 21-April-2016',NULL,NULL),(7,1,31,'PO-5','2016-04-21 00:00:00','PURCHASE ORDER [PO-5] JATUH TEMPO TGL 21-April-2016',NULL,NULL),(8,1,46,'SLO00001-3','2016-04-21 00:00:00','PEMBAYARAN SALES INVOICE [SLO00001-3] [CEK 123] SEBESAR Rp100,00 JATUH TEMPO',NULL,NULL),(9,1,48,'PO-5','2016-04-21 00:00:00','PEMBAYARAN PURCASE ORDER [PO-5] [BG001] SEBESAR Rp100,00 JATUH TEMPO',NULL,NULL),(10,1,30,'RO-3','2016-04-21 00:00:00','REQUEST ORDER [RO-3] EXPIRED PADA TGL 22-April-2016',NULL,NULL),(11,1,37,'SLO00001-3','2016-04-21 00:00:00','SALES INVOICE [SLO00001-3] JATUH TEMPO TGL 21-April-2016','2016-05-11 00:00:00',1),(12,1,31,'PO-5','2016-04-21 00:00:00','PURCHASE ORDER [PO-5] JATUH TEMPO TGL 21-April-2016',NULL,NULL),(13,1,46,'SLO00001-3','2016-04-21 00:00:00','PEMBAYARAN SALES INVOICE [SLO00001-3] [CEK 123] SEBESAR Rp100,00 JATUH TEMPO',NULL,NULL),(14,1,48,'PO-5','2016-04-21 00:00:00','PEMBAYARAN PURCASE ORDER [PO-5] [BG001] SEBESAR Rp100,00 JATUH TEMPO',NULL,NULL),(15,1,30,'RO-3','2016-04-21 00:00:00','REQUEST ORDER [RO-3] EXPIRED PADA TGL 22-April-2016','2016-05-11 00:00:00',1),(16,0,31,'PO-5','2016-04-21 00:00:00','PURCHASE ORDER [PO-5] JATUH TEMPO TGL 21-April-2016',NULL,NULL),(17,1,9,'PROD-1','2016-04-22 00:00:00','PRODUCT_ID [PROD-1] SUDAH MENDEKATI LIMIT','2016-04-22 00:00:00',1),(18,0,9,'PROD-2','2016-04-22 00:00:00','PRODUCT_ID [PROD-2] SUDAH MENDEKATI LIMIT',NULL,NULL),(19,1,46,'SLO00001-3','2016-04-22 00:00:00','PEMBAYARAN SALES INVOICE [SLO00001-3] [BG 100 BCA] SEBESAR Rp100,00 JATUH TEMPO',NULL,NULL),(20,0,46,'SLO00001-3','2016-04-22 00:00:00','PEMBAYARAN SALES INVOICE [SLO00001-3] [BG 100 BCA] SEBESAR Rp100,00 JATUH TEMPO',NULL,NULL),(21,1,9,'PROD-4','2016-04-22 00:00:00','PRODUCT_ID [PROD-4] SUDAH MENDEKATI LIMIT','2016-04-22 00:00:00',1),(22,0,9,'PROD-4','2016-04-22 00:00:00','PRODUCT_ID [PROD-4] SUDAH MENDEKATI LIMIT',NULL,NULL),(23,1,9,'PROD-1','2016-04-22 00:00:00','PRODUCT_ID [PROD-1] SUDAH MENDEKATI LIMIT','2016-04-23 00:00:00',1),(24,1,9,'PROD-1','2016-04-23 00:00:00','PRODUCT_ID [PROD-1] SUDAH MENDEKATI LIMIT','2016-04-23 00:00:00',1),(25,1,9,'PROD-1','2016-04-23 00:00:00','PRODUCT_ID [PROD-1] SUDAH MENDEKATI LIMIT','2016-04-23 00:00:00',1),(26,1,9,'PROD-1','2016-04-23 00:00:00','PRODUCT_ID [PROD-1] SUDAH MENDEKATI LIMIT','2016-04-23 00:00:00',1),(27,0,9,'PROD-1','2016-04-25 00:00:00','PRODUCT_ID [PROD-1] SUDAH MENDEKATI LIMIT',NULL,NULL),(28,0,31,'PO-8','2016-04-26 00:00:00','PURCHASE ORDER [PO-8] JATUH TEMPO TGL 26-April-2016',NULL,NULL),(29,0,37,'SLO00001-4','2016-04-27 00:00:00','SALES INVOICE [SLO00001-4] JATUH TEMPO TGL 27-April-2016',NULL,NULL),(30,0,31,'PR-2','2016-04-28 00:00:00','PURCHASE ORDER [PR-2] JATUH TEMPO TGL 28-April-2016',NULL,NULL),(31,0,31,'PO-2','2016-04-28 00:00:00','PURCHASE ORDER [PO-2] JATUH TEMPO TGL 28-April-2016',NULL,NULL),(32,0,31,'PR-8','2016-05-04 00:00:00','PURCHASE ORDER [PR-8] JATUH TEMPO TGL 04-May-2016',NULL,NULL),(33,1,9,'PROD-3','2016-05-07 00:00:00','PRODUCT_ID [PROD-3] SUDAH MENDEKATI LIMIT','2016-05-07 00:00:00',1),(34,1,9,'PROD-3','2016-05-07 00:00:00','PRODUCT_ID [PROD-3] SUDAH MENDEKATI LIMIT','2016-05-07 00:00:00',1),(35,0,37,'SLO00001-3','2016-05-11 00:00:00','SALES INVOICE [SLO00001-3] JATUH TEMPO TGL 21-April-2016',NULL,NULL),(36,0,30,'RO-3','2016-05-16 00:00:00','REQUEST ORDER [RO-3] EXPIRED PADA TGL 22-April-2016',NULL,NULL),(37,0,30,'RO-6','2016-05-16 00:00:00','REQUEST ORDER [RO-6] EXPIRED PADA TGL 10-May-2016',NULL,NULL),(38,0,30,'RO-5','2016-05-16 00:00:00','REQUEST ORDER [RO-5] EXPIRED PADA TGL 08-May-2016',NULL,NULL),(39,0,30,'RO-7','2016-05-16 00:00:00','REQUEST ORDER [RO-7] EXPIRED PADA TGL 10-May-2016',NULL,NULL),(40,0,30,'RO-8','2016-05-16 00:00:00','REQUEST ORDER [RO-8] EXPIRED PADA TGL 09-May-2016',NULL,NULL),(41,0,30,'RO-11','2016-05-16 00:00:00','REQUEST ORDER [RO-11] EXPIRED PADA TGL 13-May-2016',NULL,NULL),(42,0,30,'RO-14','2016-05-16 00:00:00','REQUEST ORDER [RO-14] EXPIRED PADA TGL 12-May-2016',NULL,NULL);
/*!40000 ALTER TABLE `master_message` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_module`
--

DROP TABLE IF EXISTS `master_module`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `master_module` (
  `MODULE_ID` smallint(5) unsigned NOT NULL AUTO_INCREMENT,
  `MODULE_NAME` varchar(50) DEFAULT NULL,
  `MODULE_DESCRIPTION` varchar(100) DEFAULT NULL,
  `MODULE_FEATURES` tinyint(3) unsigned DEFAULT NULL,
  `MODULE_ACTIVE` tinyint(3) unsigned DEFAULT NULL,
  PRIMARY KEY (`MODULE_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=50 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_module`
--

LOCK TABLES `master_module` WRITE;
/*!40000 ALTER TABLE `master_module` DISABLE KEYS */;
INSERT INTO `master_module` VALUES (1,'MANAJEMEN SISTEM',NULL,1,1),(2,'DATABASE',NULL,1,1),(3,'MANAJEMEN USER',NULL,3,1),(4,'MANAJEMEN CABANG',NULL,3,1),(5,'SINKRONISASI INFORMASI',NULL,1,1),(6,'PENGATURAN PRINTER',NULL,1,1),(7,'PENGATURAN GAMBAR LATAR',NULL,1,1),(8,'GUDANG',NULL,1,1),(9,'PRODUK',NULL,1,1),(10,'TAMBAH / UPDATE PRODUK',NULL,3,1),(11,'PENGATURAN HARGA PRODUK',NULL,1,1),(12,'PENGATURAN LIMIT STOK',NULL,1,1),(13,'PENGATURAN KATEGORI PRODUK',NULL,1,1),(14,'PECAH SATUAN PRODUK',NULL,1,1),(15,'PENGATURAN NOMOR RAK',NULL,1,1),(16,'KATEGORI PRODUK',NULL,3,1),(17,'SATUAN PRODUK',NULL,1,1),(18,'TAMBAH / UPDATE SATUAN',NULL,1,1),(19,'PENGATURAN KONVERSI SATUAN',NULL,1,1),(20,'STOK OPNAME',NULL,1,1),(21,'PENYESUAIAN STOK',NULL,1,1),(22,'MUTASI BARANG',NULL,1,1),(23,'TAMBAH / UPDATE MUTASI BARANG',NULL,3,1),(24,'CEK PERMINTAAN BARANG',NULL,1,1),(25,'PENERIMAAN BARANG',NULL,1,1),(26,'PENERIMAAN BARANG DARI MUTASI',NULL,1,1),(27,'PENERIMAAN BARANG DARI PO',NULL,1,1),(28,'PEMBELIAN',NULL,1,1),(29,'SUPPLIER',NULL,1,1),(30,'REQUEST ORDER',NULL,3,1),(31,'PURCHASE ORDER',NULL,3,1),(32,'REPRINT REQUEST ORDER',NULL,1,1),(33,'RETUR PEMBELIAN KE SUPPLIER',NULL,1,1),(34,'RETUR PERMINTAAN KE PUSAT',NULL,1,1),(35,'PENJUALAN',NULL,1,1),(36,'PELANGGAN',NULL,3,1),(37,'TRANSAKSI PENJUALAN',NULL,1,1),(38,'SET NO FAKTUR',NULL,1,1),(39,'RETUR PENJUALAN',NULL,1,1),(40,'RETUR PENJUALAN BY INVOICE',NULL,1,1),(41,'RETUR PENJUALAN BY STOK',NULL,1,1),(42,'KEUANGAN',NULL,1,1),(43,'PENGATURAN NO AKUN',NULL,3,1),(44,'TRANSAKSI',NULL,1,1),(45,'TAMBAH TRANSAKSI HARIAN',NULL,1,1),(46,'PEMBAYARAN PIUTANG',NULL,1,1),(47,'PEMBAYARAN PIUTANG MUTASI',NULL,1,1),(48,'PEMBAYARAN HUTANG KE SUPPLIER',NULL,1,1),(49,'PENGATURAN LIMIT PAJAK',NULL,1,1);
/*!40000 ALTER TABLE `master_module` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_product`
--

DROP TABLE IF EXISTS `master_product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `master_product` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PRODUCT_ID` varchar(50) DEFAULT '',
  `PRODUCT_BARCODE` int(10) unsigned DEFAULT '0',
  `PRODUCT_NAME` varchar(50) DEFAULT '',
  `PRODUCT_DESCRIPTION` varchar(100) DEFAULT '',
  `PRODUCT_BASE_PRICE` double DEFAULT '0',
  `PRODUCT_RETAIL_PRICE` double DEFAULT '0',
  `PRODUCT_BULK_PRICE` double DEFAULT '0',
  `PRODUCT_WHOLESALE_PRICE` double DEFAULT '0',
  `PRODUCT_PHOTO_1` varchar(50) DEFAULT '',
  `UNIT_ID` smallint(5) unsigned DEFAULT '0',
  `PRODUCT_STOCK_QTY` double DEFAULT '0',
  `PRODUCT_LIMIT_STOCK` double DEFAULT '0',
  `PRODUCT_SHELVES` varchar(5) DEFAULT '--00',
  `PRODUCT_ACTIVE` tinyint(3) unsigned DEFAULT '0',
  `PRODUCT_BRAND` varchar(50) DEFAULT '',
  `PRODUCT_IS_SERVICE` tinyint(3) unsigned DEFAULT '0',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `PRODUCT_ID_UNIQUE` (`PRODUCT_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_product`
--

LOCK TABLES `master_product` WRITE;
/*!40000 ALTER TABLE `master_product` DISABLE KEYS */;
INSERT INTO `master_product` VALUES (1,'PROD-1',2680923471,'SAPU LIDI','SAPU UNTUK NYAPU',1000,100000,1000,100,'PROD-1.jpg',1,100,101,'AA11',1,'SWALLOW',0),(2,'PROD-2',3408074444,'KAIN PEL','KAIN BUAT NGEPEL',100,20000,10000,1000,' ',1,325,310,'DD22',1,'ADIDAS',0),(5,'PROD-3',4017033181,'LIDI','SAPU DIPECAH JADI LIDI',200,1000,100,10,' ',2,100,0,'--00',1,' ',0),(6,'PROD-4',0,'KEMUCING SUPER',' ',100,100,100,100,'',1,100,0,'--00',1,'',0);
/*!40000 ALTER TABLE `master_product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_supplier`
--

DROP TABLE IF EXISTS `master_supplier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `master_supplier` (
  `SUPPLIER_ID` smallint(5) unsigned NOT NULL AUTO_INCREMENT,
  `SUPPLIER_FULL_NAME` varchar(50) DEFAULT NULL,
  `SUPPLIER_ADDRESS1` varchar(50) DEFAULT NULL,
  `SUPPLIER_ADDRESS2` varchar(50) DEFAULT NULL,
  `SUPPLIER_ADDRESS_CITY` varchar(50) DEFAULT NULL,
  `SUPPLIER_PHONE` varchar(15) DEFAULT NULL,
  `SUPPLIER_FAX` varchar(15) DEFAULT NULL,
  `SUPPLIER_EMAIL` varchar(50) DEFAULT NULL,
  `SUPPLIER_ACTIVE` tinyint(3) unsigned DEFAULT NULL,
  PRIMARY KEY (`SUPPLIER_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_supplier`
--

LOCK TABLES `master_supplier` WRITE;
/*!40000 ALTER TABLE `master_supplier` DISABLE KEYS */;
INSERT INTO `master_supplier` VALUES (1,'SAPU LIDI PERMAI',' ',' ',' ',' ',' ',' ',1);
/*!40000 ALTER TABLE `master_supplier` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_unit`
--

DROP TABLE IF EXISTS `master_unit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `master_unit` (
  `UNIT_ID` smallint(5) unsigned NOT NULL AUTO_INCREMENT,
  `UNIT_NAME` varchar(50) DEFAULT NULL,
  `UNIT_DESCRIPTION` varchar(100) DEFAULT NULL,
  `UNIT_ACTIVE` tinyint(3) unsigned DEFAULT NULL,
  PRIMARY KEY (`UNIT_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_unit`
--

LOCK TABLES `master_unit` WRITE;
/*!40000 ALTER TABLE `master_unit` DISABLE KEYS */;
INSERT INTO `master_unit` VALUES (1,'BIJI','PER BIJI',1),(2,'BATANG','PER BATANG',1);
/*!40000 ALTER TABLE `master_unit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_user`
--

DROP TABLE IF EXISTS `master_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `master_user` (
  `ID` tinyint(3) unsigned NOT NULL AUTO_INCREMENT,
  `USER_NAME` varchar(15) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `USER_PASSWORD` varchar(15) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `USER_FULL_NAME` varchar(50) DEFAULT NULL,
  `USER_PHONE` varchar(15) DEFAULT NULL,
  `USER_ACTIVE` tinyint(1) unsigned DEFAULT NULL,
  `GROUP_ID` tinyint(3) unsigned DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `USER_NAME_UNIQUE` (`USER_NAME`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='	';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_user`
--

LOCK TABLES `master_user` WRITE;
/*!40000 ALTER TABLE `master_user` DISABLE KEYS */;
INSERT INTO `master_user` VALUES (1,'ADMIN','admin','ADMIN','1',1,1),(2,'KASIR','kasir123','KASIR','',1,2);
/*!40000 ALTER TABLE `master_user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payment_credit`
--

DROP TABLE IF EXISTS `payment_credit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `payment_credit` (
  `payment_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `credit_id` int(11) NOT NULL,
  `payment_date` date NOT NULL,
  `pm_id` tinyint(3) NOT NULL,
  `payment_nominal` double NOT NULL,
  `payment_description` varchar(100) DEFAULT NULL,
  `payment_confirmed` tinyint(3) DEFAULT NULL,
  `payment_invalid` tinyint(4) DEFAULT '0',
  `payment_confirmed_date` date DEFAULT NULL,
  `payment_due_date` date DEFAULT NULL,
  PRIMARY KEY (`payment_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payment_credit`
--

LOCK TABLES `payment_credit` WRITE;
/*!40000 ALTER TABLE `payment_credit` DISABLE KEYS */;
INSERT INTO `payment_credit` VALUES (1,0,'2016-04-18',1,217.25,NULL,1,0,'2016-04-18',NULL),(2,7,'2016-04-21',1,100,'CEK 123',1,0,'2016-04-21','2016-04-21'),(3,7,'2016-04-22',5,100,'BG 100 BCA',0,0,NULL,'2016-04-22');
/*!40000 ALTER TABLE `payment_credit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payment_debt`
--

DROP TABLE IF EXISTS `payment_debt`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `payment_debt` (
  `payment_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `debt_id` int(11) NOT NULL,
  `payment_date` date NOT NULL,
  `pm_id` tinyint(3) NOT NULL,
  `payment_nominal` double NOT NULL,
  `payment_description` varchar(100) DEFAULT NULL,
  `payment_confirmed` tinyint(3) DEFAULT '0',
  `payment_invalid` tinyint(4) DEFAULT '0',
  `payment_confirmed_date` date DEFAULT NULL,
  `payment_due_date` date DEFAULT NULL,
  PRIMARY KEY (`payment_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payment_debt`
--

LOCK TABLES `payment_debt` WRITE;
/*!40000 ALTER TABLE `payment_debt` DISABLE KEYS */;
INSERT INTO `payment_debt` VALUES (1,1,'2016-04-18',1,1000,'BG BANK ABCD NO BG #123456',1,0,'2016-04-18','2016-04-20'),(2,4,'2016-04-21',1,100,'BG001',1,0,'2016-04-21','2016-04-21');
/*!40000 ALTER TABLE `payment_debt` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payment_method`
--

DROP TABLE IF EXISTS `payment_method`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `payment_method` (
  `pm_id` tinyint(4) NOT NULL AUTO_INCREMENT,
  `pm_name` varchar(15) NOT NULL,
  `pm_description` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`pm_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payment_method`
--

LOCK TABLES `payment_method` WRITE;
/*!40000 ALTER TABLE `payment_method` DISABLE KEYS */;
INSERT INTO `payment_method` VALUES (1,'TUNAI','TUNAI'),(2,'KARTU KREDIT','KARTU KREDIT'),(3,'KARTU DEBIT','KARTU DEBIT'),(4,'TRANSFER','TRANSFER BANK'),(5,'BG','BILYET GIRO'),(6,'CEK','CEK');
/*!40000 ALTER TABLE `payment_method` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_adjustment`
--

DROP TABLE IF EXISTS `product_adjustment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product_adjustment` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PRODUCT_ID` varchar(30) DEFAULT NULL,
  `PRODUCT_ADJUSTMENT_DATE` date DEFAULT NULL,
  `PRODUCT_OLD_STOCK_QTY` double DEFAULT NULL,
  `PRODUCT_NEW_STOCK_QTY` double DEFAULT NULL,
  `PRODUCT_ADJUSTMENT_DESCRIPTION` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_adjustment`
--

LOCK TABLES `product_adjustment` WRITE;
/*!40000 ALTER TABLE `product_adjustment` DISABLE KEYS */;
INSERT INTO `product_adjustment` VALUES (1,'PROD-1','2016-04-09',99,90,''),(2,'PROD-2','2016-04-09',100,0,''),(3,'PROD-3','2016-04-09',60,0,''),(4,'PROD-1','2016-04-09',90,100,' '),(5,'PROD-2','2016-04-18',0,100,' '),(6,'PROD-2','2016-04-18',100,10,' '),(7,'PROD-3','2016-04-18',0,100,' '),(8,'PROD-4','2016-05-10',0,100,' ');
/*!40000 ALTER TABLE `product_adjustment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_category`
--

DROP TABLE IF EXISTS `product_category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product_category` (
  `PRODUCT_ID` varchar(50) NOT NULL,
  `CATEGORY_ID` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY (`PRODUCT_ID`,`CATEGORY_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_category`
--

LOCK TABLES `product_category` WRITE;
/*!40000 ALTER TABLE `product_category` DISABLE KEYS */;
INSERT INTO `product_category` VALUES ('PROD-1',1),('PROD-1',2),('PROD-1',3),('PROD-2',1),('PROD-2',2),('PROD-4',2);
/*!40000 ALTER TABLE `product_category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_loss`
--

DROP TABLE IF EXISTS `product_loss`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product_loss` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PL_DATETIME` date DEFAULT NULL,
  `PRODUCT_ID` int(10) unsigned DEFAULT NULL,
  `PRODUCT_QTY` double DEFAULT NULL,
  `NEW_PRODUCT_ID` int(10) unsigned DEFAULT NULL,
  `NEW_PRODUCT_QTY` double DEFAULT NULL,
  `TOTAL_LOSS` double DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_loss`
--

LOCK TABLES `product_loss` WRITE;
/*!40000 ALTER TABLE `product_loss` DISABLE KEYS */;
/*!40000 ALTER TABLE `product_loss` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products_mutation_detail`
--

DROP TABLE IF EXISTS `products_mutation_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `products_mutation_detail` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PM_INVOICE` varchar(30) DEFAULT NULL,
  `PRODUCT_ID` varchar(50) DEFAULT NULL,
  `PRODUCT_BASE_PRICE` double DEFAULT NULL,
  `PRODUCT_QTY` double DEFAULT NULL,
  `PM_SUBTOTAL` double DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products_mutation_detail`
--

LOCK TABLES `products_mutation_detail` WRITE;
/*!40000 ALTER TABLE `products_mutation_detail` DISABLE KEYS */;
INSERT INTO `products_mutation_detail` VALUES (1,'PM-1','PROD-1',10,0,0),(2,'PM-2','PROD-1',10,10,100),(3,'PM-2','PROD-3',1,20,20),(4,'PM-3','PROD-2',100,1,100),(5,'PM-4','PROD-4',100,2,200),(6,'PM-5','PROD-4',100,22,2200),(7,'PM-6','PROD-2',100,1,100),(8,'PM-7','PROD-4',100,1,100),(9,'PM-8','PROD-3',200,1,200),(10,'PM-9','PROD-2',100,1,100),(11,'PM-10','PROD-2',100,2,200),(12,'PM-11','PROD-2',100,1,100);
/*!40000 ALTER TABLE `products_mutation_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products_mutation_header`
--

DROP TABLE IF EXISTS `products_mutation_header`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `products_mutation_header` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PM_INVOICE` varchar(30) DEFAULT NULL,
  `BRANCH_ID_FROM` tinyint(3) unsigned DEFAULT NULL,
  `BRANCH_ID_TO` tinyint(3) unsigned DEFAULT NULL,
  `PM_DATETIME` date DEFAULT NULL,
  `PM_TOTAL` double DEFAULT NULL,
  `RO_INVOICE` varchar(30) DEFAULT NULL,
  `PM_RECEIVED` tinyint(4) unsigned DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products_mutation_header`
--

LOCK TABLES `products_mutation_header` WRITE;
/*!40000 ALTER TABLE `products_mutation_header` DISABLE KEYS */;
INSERT INTO `products_mutation_header` VALUES (1,'PM-1',0,1,'2016-04-09',0,'',1),(2,'PM-2',0,1,'2016-04-18',120,'RO-2',1),(3,'PM-3',0,1,'2016-04-19',100,'',0),(4,'PM-4',0,1,'2016-05-10',200,'RO-4',0),(5,'PM-5',0,1,'2016-05-12',2200,'',0),(6,'PM-6',0,1,'2016-05-12',100,'',0),(7,'PM-7',0,1,'2016-05-12',100,'',0),(8,'PM-8',0,1,'2016-05-12',200,'',0),(9,'PM-9',0,1,'2016-05-12',100,'',1),(10,'PM-10',0,1,'2016-05-12',200,'RO-12',0),(11,'PM-11',0,1,'2016-05-12',100,'RO-13',1);
/*!40000 ALTER TABLE `products_mutation_header` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products_received_detail`
--

DROP TABLE IF EXISTS `products_received_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `products_received_detail` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PR_INVOICE` varchar(30) DEFAULT NULL,
  `PRODUCT_ID` varchar(50) DEFAULT NULL,
  `PRODUCT_BASE_PRICE` double DEFAULT NULL,
  `PRODUCT_QTY` double DEFAULT NULL,
  `PRODUCT_ACTUAL_QTY` double DEFAULT NULL,
  `PR_SUBTOTAL` varchar(45) DEFAULT NULL,
  `PRODUCT_PRICE_CHANGE` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products_received_detail`
--

LOCK TABLES `products_received_detail` WRITE;
/*!40000 ALTER TABLE `products_received_detail` DISABLE KEYS */;
INSERT INTO `products_received_detail` VALUES (1,'PR-1','PROD-1',10,10,10,'100',0),(2,'PR-1','PROD-3',1,20,20,'20',0),(3,'PR-2','PROD-1',1000,20,20,'20000',0),(4,'PR-3','PROD-3',200,10,10,'2000',1),(5,'PR-4','PROD-1',1000,11,11,'11000',0),(6,'PR-5','PROD-2',100,100,100,'10000',0),(7,'PR-6','PROD-2',100,200,200,'20000',0),(8,'PR-7','PROD-2',100,10,10,'1000',0),(9,'PR-7','PROD-4',100,20,20,'2000',0),(10,'PR-8','PROD-2',100,12,12,'1200',0),(11,'PR-8','PROD-3',200,3,3,'600',0),(13,'PR-9','PROD-2',100,1,1,'100',0),(14,'PR-11','PROD-2',100,1,1,'100',0);
/*!40000 ALTER TABLE `products_received_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products_received_header`
--

DROP TABLE IF EXISTS `products_received_header`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `products_received_header` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PR_INVOICE` varchar(30) DEFAULT NULL,
  `PR_FROM` tinyint(3) unsigned DEFAULT NULL,
  `PR_TO` tinyint(3) unsigned DEFAULT NULL,
  `PR_DATE` date DEFAULT NULL,
  `PR_TOTAL` double DEFAULT NULL,
  `PM_INVOICE` varchar(30) DEFAULT NULL,
  `PURCHASE_INVOICE` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `PR_INVOICE_UNIQUE` (`PR_INVOICE`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8 COMMENT='		';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products_received_header`
--

LOCK TABLES `products_received_header` WRITE;
/*!40000 ALTER TABLE `products_received_header` DISABLE KEYS */;
INSERT INTO `products_received_header` VALUES (1,'PR-1',0,1,'2016-04-18',120,'PM-2',NULL),(2,'PR-2',1,0,'2016-04-18',20000,NULL,'PR-2'),(3,'PR-3',1,0,'2016-04-18',2000,NULL,'PO-2'),(4,'PR-4',1,0,'2016-04-18',11000,NULL,'PO-3'),(5,'PR-5',1,0,'2016-04-18',10000,NULL,'PO-4'),(6,'PR-6',1,0,'2016-04-21',20000,NULL,'PO-5'),(7,'PR-7',1,0,'2016-04-25',3000,NULL,'PO-8'),(8,'PR-8',0,0,'2016-05-04',1800,NULL,'PR-8'),(11,'PR-9',0,1,'2016-05-12',100,'PM-9',NULL),(12,'PR-11',0,1,'2016-05-12',100,'PM-11',NULL);
/*!40000 ALTER TABLE `products_received_header` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `purchase_detail`
--

DROP TABLE IF EXISTS `purchase_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `purchase_detail` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PURCHASE_INVOICE` varchar(30) DEFAULT NULL,
  `PRODUCT_ID` varchar(50) DEFAULT NULL,
  `PRODUCT_PRICE` double DEFAULT NULL,
  `PRODUCT_QTY` double DEFAULT NULL,
  `PURCHASE_SUBTOTAL` double DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase_detail`
--

LOCK TABLES `purchase_detail` WRITE;
/*!40000 ALTER TABLE `purchase_detail` DISABLE KEYS */;
INSERT INTO `purchase_detail` VALUES (1,'PO-1','PROD-1',10,100,1000),(2,'PR-2','PROD-1',1000,20,20000),(3,'PO-2','PROD-3',200,10,2000),(4,'PO-3','PROD-1',1000,11,11000),(5,'PO-4','PROD-2',100,100,10000),(6,'PO-5','PROD-2',100,200,20000),(9,'PO-6','PROD-2',100,20,2000),(10,'PO-6','PROD-4',100,1,100),(11,'PO-7','PROD-2',100,10,1000),(12,'PO-8','PROD-2',100,10,1000),(13,'PO-8','PROD-4',100,20,2000),(14,'PR-8','PROD-2',100,12,1200),(15,'PR-8','PROD-3',200,3,600);
/*!40000 ALTER TABLE `purchase_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `purchase_detail_tax`
--

DROP TABLE IF EXISTS `purchase_detail_tax`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `purchase_detail_tax` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PURCHASE_INVOICE` varchar(30) DEFAULT NULL,
  `PRODUCT_ID` varchar(50) DEFAULT NULL,
  `PRODUCT_PRICE` double DEFAULT NULL,
  `PRODUCT_QTY` double DEFAULT NULL,
  `PURCHASE_SUBTOTAL` double DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase_detail_tax`
--

LOCK TABLES `purchase_detail_tax` WRITE;
/*!40000 ALTER TABLE `purchase_detail_tax` DISABLE KEYS */;
INSERT INTO `purchase_detail_tax` VALUES (1,'PO-8','PROD-2',100,10,1000),(2,'PO-8','PROD-4',100,20,2000),(3,'PR-8','PROD-2',100,12,1200),(4,'PR-8','PROD-3',200,3,600);
/*!40000 ALTER TABLE `purchase_detail_tax` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `purchase_header`
--

DROP TABLE IF EXISTS `purchase_header`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `purchase_header` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PURCHASE_INVOICE` varchar(30) DEFAULT NULL,
  `SUPPLIER_ID` smallint(5) unsigned DEFAULT NULL,
  `PURCHASE_DATETIME` date DEFAULT NULL,
  `PURCHASE_TOTAL` double DEFAULT NULL,
  `PURCHASE_TERM_OF_PAYMENT` tinyint(3) unsigned DEFAULT NULL,
  `PURCHASE_TERM_OF_PAYMENT_DURATION` double unsigned DEFAULT '0',
  `PURCHASE_DATE_RECEIVED` date DEFAULT NULL,
  `PURCHASE_TERM_OF_PAYMENT_DATE` date DEFAULT NULL,
  `PURCHASE_PAID` tinyint(3) unsigned DEFAULT '0',
  `PURCHASE_SENT` tinyint(3) unsigned DEFAULT '0',
  `PURCHASE_RECEIVED` tinyint(3) unsigned DEFAULT '0',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `PURCHASE_INVOICE_UNIQUE` (`PURCHASE_INVOICE`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase_header`
--

LOCK TABLES `purchase_header` WRITE;
/*!40000 ALTER TABLE `purchase_header` DISABLE KEYS */;
INSERT INTO `purchase_header` VALUES (1,'PO-1',1,'2016-04-10',1000,1,10,NULL,NULL,0,1,0),(2,'PR-2',1,'2016-04-18',20000,1,10,'2016-04-18','2016-04-28',0,1,1),(3,'PO-2',1,'2016-04-18',2000,1,10,'2016-04-18','2016-04-28',0,1,1),(4,'PO-3',1,'2016-04-18',11000,0,0,NULL,NULL,1,1,1),(5,'PO-4',1,'2016-04-18',10000,0,0,'2016-04-18','2016-04-18',1,1,1),(6,'PO-5',1,'2016-04-21',20000,1,0,'2016-04-21','2016-04-21',0,1,1),(8,'PO-6',1,'2016-04-25',2100,1,2,NULL,NULL,0,1,0),(9,'PO-7',1,'2016-04-25',1000,1,1,NULL,NULL,0,1,0),(10,'PO-8',1,'2016-04-25',3000,1,1,'2016-04-25','2016-04-26',0,1,1),(11,'PR-8',0,'2016-05-04',1800,1,0,'2016-05-04','2016-05-04',0,1,1);
/*!40000 ALTER TABLE `purchase_header` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `purchase_header_tax`
--

DROP TABLE IF EXISTS `purchase_header_tax`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `purchase_header_tax` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PURCHASE_INVOICE` varchar(30) DEFAULT NULL,
  `SUPPLIER_ID` smallint(5) unsigned DEFAULT NULL,
  `PURCHASE_DATETIME` date DEFAULT NULL,
  `PURCHASE_TOTAL` double DEFAULT NULL,
  `PURCHASE_TERM_OF_PAYMENT` tinyint(3) unsigned DEFAULT NULL,
  `PURCHASE_TERM_OF_PAYMENT_DURATION` double unsigned DEFAULT '0',
  `PURCHASE_DATE_RECEIVED` date DEFAULT NULL,
  `PURCHASE_TERM_OF_PAYMENT_DATE` date DEFAULT NULL,
  `PURCHASE_PAID` tinyint(3) unsigned DEFAULT '0',
  `PURCHASE_SENT` tinyint(3) unsigned DEFAULT '0',
  `PURCHASE_RECEIVED` tinyint(3) unsigned DEFAULT '0',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `PURCHASE_INVOICE_UNIQUE` (`PURCHASE_INVOICE`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase_header_tax`
--

LOCK TABLES `purchase_header_tax` WRITE;
/*!40000 ALTER TABLE `purchase_header_tax` DISABLE KEYS */;
INSERT INTO `purchase_header_tax` VALUES (1,'PO-8',1,'2016-04-25',3000,1,1,'2016-04-25','2016-04-26',0,1,1),(2,'PR-8',0,'2016-05-04',1800,1,0,'2016-05-04','2016-05-04',0,1,1);
/*!40000 ALTER TABLE `purchase_header_tax` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `request_order_detail`
--

DROP TABLE IF EXISTS `request_order_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `request_order_detail` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `RO_INVOICE` varchar(30) DEFAULT NULL,
  `PRODUCT_ID` varchar(50) DEFAULT NULL,
  `PRODUCT_BASE_PRICE` double DEFAULT NULL,
  `RO_QTY` double DEFAULT NULL,
  `RO_SUBTOTAL` double DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `request_order_detail`
--

LOCK TABLES `request_order_detail` WRITE;
/*!40000 ALTER TABLE `request_order_detail` DISABLE KEYS */;
INSERT INTO `request_order_detail` VALUES (2,'RO-1','PROD-1',10,20,200),(3,'RO-2','PROD-1',10,10,100),(4,'RO-2','PROD-3',1,20,20),(6,'RO-3','PROD-2',100,22,2200),(11,'RO-4','PROD-4',100,2,200),(12,'RO-6','PROD-4',100,22,2200),(13,'RO-5','PROD-2',100,1000,100000),(14,'RO-7','PROD-3',200,11,2200),(15,'RO-8','PROD-2',100,22,2200),(16,'RO-11','PROD-2',100,2,200),(17,'RO-12','PROD-2',100,2,200),(18,'RO-13','PROD-2',100,1,100),(19,'RO-14','PROD-2',100,0,0),(20,'RO-15','PROD-2',100,1,100);
/*!40000 ALTER TABLE `request_order_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `request_order_header`
--

DROP TABLE IF EXISTS `request_order_header`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `request_order_header` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `RO_INVOICE` varchar(30) DEFAULT NULL,
  `RO_BRANCH_ID_FROM` tinyint(3) unsigned DEFAULT NULL,
  `RO_BRANCH_ID_TO` tinyint(3) unsigned DEFAULT NULL,
  `RO_DATETIME` date DEFAULT NULL,
  `RO_TOTAL` double DEFAULT NULL,
  `RO_EXPIRED` date DEFAULT NULL,
  `RO_ACTIVE` tinyint(4) DEFAULT NULL,
  `RO_EXPORTED` tinyint(4) unsigned DEFAULT '0',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `RO_INVOICE_UNIQUE` (`RO_INVOICE`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `request_order_header`
--

LOCK TABLES `request_order_header` WRITE;
/*!40000 ALTER TABLE `request_order_header` DISABLE KEYS */;
INSERT INTO `request_order_header` VALUES (1,'RO-1',0,1,'2016-04-09',200,'2016-04-19',0,1),(2,'RO-2',0,1,'2016-04-18',120,'2016-04-28',0,1),(3,'RO-3',0,1,'2016-04-21',2200,'2016-04-22',1,1),(4,'RO-4',0,1,'2016-05-07',200,'2016-05-09',0,1),(5,'RO-6',0,1,'2016-05-08',2200,'2016-05-10',1,1),(7,'RO-5',0,1,'2016-05-07',100000,'2016-05-08',1,1),(8,'RO-7',0,1,'2016-05-09',2200,'2016-05-10',1,1),(9,'RO-8',0,1,'2016-05-09',2200,'2016-05-09',1,1),(10,'RO-11',0,1,'2016-05-12',200,'2016-05-13',1,0),(11,'RO-12',0,1,'2016-05-12',200,'2016-05-13',0,1),(12,'RO-13',0,1,'2016-05-12',100,'2016-05-12',0,1),(13,'RO-14',0,1,'2016-05-12',0,'2016-05-12',1,1),(14,'RO-15',0,1,'2016-05-12',100,'2016-05-13',0,1);
/*!40000 ALTER TABLE `request_order_header` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `return_purchase_detail`
--

DROP TABLE IF EXISTS `return_purchase_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `return_purchase_detail` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `RP_ID` varchar(30) DEFAULT NULL,
  `PRODUCT_ID` varchar(50) DEFAULT NULL,
  `PRODUCT_BASEPRICE` double DEFAULT '0',
  `PRODUCT_QTY` double DEFAULT '0',
  `RP_DESCRIPTION` varchar(100) DEFAULT NULL,
  `RP_SUBTOTAL` double DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `return_purchase_detail`
--

LOCK TABLES `return_purchase_detail` WRITE;
/*!40000 ALTER TABLE `return_purchase_detail` DISABLE KEYS */;
INSERT INTO `return_purchase_detail` VALUES (1,'RT-1','PROD-3',200,10,' ',2000),(2,'RT-2','PROD-1',1000,10,' ',10000);
/*!40000 ALTER TABLE `return_purchase_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `return_purchase_header`
--

DROP TABLE IF EXISTS `return_purchase_header`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `return_purchase_header` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `RP_ID` varchar(30) DEFAULT NULL,
  `SUPPLIER_ID` smallint(5) unsigned DEFAULT NULL,
  `RP_DATE` date DEFAULT NULL,
  `RP_TOTAL` double DEFAULT '0',
  `RP_PROCESSED` tinyint(3) unsigned DEFAULT '0',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `RP_INVOICE_UNIQUE` (`RP_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `return_purchase_header`
--

LOCK TABLES `return_purchase_header` WRITE;
/*!40000 ALTER TABLE `return_purchase_header` DISABLE KEYS */;
INSERT INTO `return_purchase_header` VALUES (1,'RT-1',1,'2016-04-18',2000,1),(2,'RT-2',1,'2016-04-18',10000,1);
/*!40000 ALTER TABLE `return_purchase_header` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `return_sales_detail`
--

DROP TABLE IF EXISTS `return_sales_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `return_sales_detail` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `RS_INVOICE` varchar(30) DEFAULT NULL,
  `PRODUCT_ID` varchar(50) DEFAULT NULL,
  `PRODUCT_SALES_PRICE` double DEFAULT '0',
  `PRODUCT_SALES_QTY` double DEFAULT '0',
  `PRODUCT_RETURN_QTY` double DEFAULT '0',
  `RS_DESCRIPTION` varchar(100) DEFAULT NULL,
  `RS_SUBTOTAL` double DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `return_sales_detail`
--

LOCK TABLES `return_sales_detail` WRITE;
/*!40000 ALTER TABLE `return_sales_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `return_sales_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `return_sales_header`
--

DROP TABLE IF EXISTS `return_sales_header`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `return_sales_header` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `RS_INVOICE` varchar(30) DEFAULT NULL,
  `SALES_INVOICE` varchar(30) DEFAULT NULL,
  `CUSTOMER_ID` smallint(5) unsigned DEFAULT NULL,
  `RS_DATETIME` date DEFAULT NULL,
  `RS_TOTAL` double DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `return_sales_header`
--

LOCK TABLES `return_sales_header` WRITE;
/*!40000 ALTER TABLE `return_sales_header` DISABLE KEYS */;
/*!40000 ALTER TABLE `return_sales_header` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sales_detail`
--

DROP TABLE IF EXISTS `sales_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sales_detail` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `SALES_INVOICE` varchar(30) DEFAULT NULL,
  `PRODUCT_ID` varchar(50) DEFAULT NULL,
  `PRODUCT_SALES_PRICE` double DEFAULT '0',
  `PRODUCT_QTY` double DEFAULT '0',
  `PRODUCT_DISC1` double DEFAULT '0',
  `PRODUCT_DISC2` double DEFAULT '0',
  `PRODUCT_DISC_RP` double DEFAULT '0',
  `SALES_SUBTOTAL` double DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales_detail`
--

LOCK TABLES `sales_detail` WRITE;
/*!40000 ALTER TABLE `sales_detail` DISABLE KEYS */;
INSERT INTO `sales_detail` VALUES (1,'SLO00001-1','PROD-3',10,2,0,0,0,20),(2,'SLO00001-1','PROD-1',100,10,1.25,0,50,937.5),(4,'SLO00001-2','PROD-3',10,22,1.25,0,0,217.25),(5,'SLO00001-3','PROD-1',100,20,1.25,0,50,1925),(6,'SLO00001-4','PROD-2',10000,2,0,0,0,20000),(7,'SLO00001-5','PROD-2',20000,1,0,0,0,20000),(8,'SLO00001-6','PROD-2',20000,1,0,0,0,20000),(9,'SLO00001-7','PROD-2',20000,1,0,0,0,20000),(10,'SLO00001-8','PROD-2',20000,1,0,0,0,20000),(11,'SLO00001-8','PROD-2',20000,2,0,0,0,40000),(12,'SLO00001-8','PROD-4',100,3,0,0,0,300),(13,'SLO00001-9','PROD-2',20000,1,0,0,0,20000),(14,'SLO00001-9','PROD-4',100,2,0,0,0,200),(15,'-1','PROD-4',100,1,0,0,0,100),(17,'SLO001-1','PROD-2',20000,1,0,0,0,20000),(18,'SLO001-2','PROD-4',100,2,0,0,0,200),(19,'SLO001-2','PROD-3',1000,1,0,0,0,1000),(20,'SLO001-3','PROD-4',100,2,0,0,0,200),(21,'SLO001-4','PROD-4',100,1,0,0,0,100),(22,'SLO001-5','PROD-4',100,1,0,0,0,100),(23,'SLO001-6','PROD-4',100,2,0,0,0,200),(24,'SLO001-7','PROD-4',100,2,0,0,0,200);
/*!40000 ALTER TABLE `sales_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sales_detail_tax`
--

DROP TABLE IF EXISTS `sales_detail_tax`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sales_detail_tax` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `SALES_INVOICE` varchar(30) DEFAULT NULL,
  `PRODUCT_ID` varchar(50) DEFAULT NULL,
  `PRODUCT_SALES_PRICE` double DEFAULT '0',
  `PRODUCT_QTY` double DEFAULT '0',
  `PRODUCT_DISC1` double DEFAULT '0',
  `PRODUCT_DISC2` double DEFAULT '0',
  `PRODUCT_DISC_RP` double DEFAULT '0',
  `SALES_SUBTOTAL` double DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales_detail_tax`
--

LOCK TABLES `sales_detail_tax` WRITE;
/*!40000 ALTER TABLE `sales_detail_tax` DISABLE KEYS */;
INSERT INTO `sales_detail_tax` VALUES (1,'SLO00001-4','PROD-2',10000,2,0,0,0,20000),(2,'SLO00001-5','PROD-2',20000,1,0,0,0,20000),(3,'SLO00001-7','PROD-2',20000,1,0,0,0,20000),(4,'SLO00001-9','PROD-2',20000,1,0,0,0,20000),(5,'SLO00001-9','PROD-4',100,2,0,0,0,200),(6,'-1','PROD-4',100,1,0,0,0,100),(7,'SLO001-2','PROD-4',100,2,0,0,0,200),(8,'SLO001-2','PROD-3',1000,1,0,0,0,1000);
/*!40000 ALTER TABLE `sales_detail_tax` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sales_header`
--

DROP TABLE IF EXISTS `sales_header`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sales_header` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `SALES_INVOICE` varchar(30) DEFAULT NULL,
  `CUSTOMER_ID` smallint(5) unsigned DEFAULT '0',
  `SALES_DATE` datetime DEFAULT NULL,
  `SALES_TOTAL` double DEFAULT '0',
  `SALES_DISCOUNT_FINAL` double DEFAULT '0',
  `SALES_TOP` tinyint(3) unsigned DEFAULT '0',
  `SALES_TOP_DATE` date DEFAULT NULL,
  `SALES_PAID` tinyint(3) unsigned DEFAULT '0',
  `SALES_PAYMENT` double unsigned DEFAULT '0',
  `SALES_PAYMENT_CHANGE` double unsigned DEFAULT '0',
  `SALES_PAYMENT_METHOD` tinyint(3) unsigned DEFAULT '0',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `SALES_INVOICE_UNIQUE` (`SALES_INVOICE`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales_header`
--

LOCK TABLES `sales_header` WRITE;
/*!40000 ALTER TABLE `sales_header` DISABLE KEYS */;
INSERT INTO `sales_header` VALUES (1,'SLO00001-1',1,'2016-04-18 00:00:00',957.5,0,1,'2016-04-18',1,1000,42.5,0),(3,'SLO00001-2',1,'2016-04-18 00:00:00',217.25,0,1,'2016-04-18',1,500,282.75,0),(4,'SLO00001-3',1,'2016-04-21 00:00:00',1925,0,0,'2016-04-21',0,0,0,0),(5,'SLO00001-4',0,'2016-04-25 00:00:00',20000,0,0,'2016-04-27',0,0,0,0),(6,'SLO00001-5',0,'2016-04-27 00:00:00',20000,0,1,'2016-04-27',1,100000,80000,0),(7,'SLO00001-6',0,'2016-04-27 00:00:00',20000,0,1,'2016-04-27',1,990000,970000,0),(8,'SLO00001-7',0,'2016-04-27 00:00:00',20000,0,1,'2016-04-27',1,100000,80000,0),(9,'SLO00001-8',0,'2016-04-27 00:00:00',60300,0,1,'2016-04-27',1,70000,9700,0),(10,'SLO00001-9',0,'2016-04-27 00:00:00',20200,0,1,'2016-04-27',1,100000,79800,0),(11,'-1',0,'2016-04-30 00:00:00',100,0,1,'2016-04-30',1,200,100,0),(14,'SLO001-1',0,'2016-04-30 23:30:00',20000,0,1,'2016-04-30',1,25000,5000,0),(16,'SLO001-2',0,'2016-05-02 12:19:00',1200,0,1,'2016-05-02',1,1200,0,0),(17,'SLO001-3',0,'2016-05-02 12:20:00',200,0,1,'2016-05-02',1,200,0,1),(18,'SLO001-4',0,'2016-05-02 00:00:00',100,0,1,'2016-05-02',1,200,100,0),(19,'SLO001-5',1,'2016-05-02 00:00:00',100,0,1,'2016-05-02',1,100,0,0),(20,'SLO001-6',0,'2016-05-02 00:00:00',200,0,1,'2016-05-02',1,200,0,0),(21,'SLO001-7',1,'2016-05-02 00:00:00',200,0,1,'2016-05-02',1,300,100,0);
/*!40000 ALTER TABLE `sales_header` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sales_header_tax`
--

DROP TABLE IF EXISTS `sales_header_tax`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sales_header_tax` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `SALES_INVOICE` varchar(30) DEFAULT NULL,
  `CUSTOMER_ID` smallint(5) unsigned DEFAULT '0',
  `SALES_DATE` datetime DEFAULT NULL,
  `SALES_TOTAL` double DEFAULT '0',
  `SALES_DISCOUNT_FINAL` double DEFAULT '0',
  `SALES_TOP` tinyint(3) unsigned DEFAULT '0',
  `SALES_TOP_DATE` date DEFAULT NULL,
  `SALES_PAID` tinyint(3) unsigned DEFAULT '0',
  `SALES_PAYMENT` double unsigned DEFAULT '0',
  `SALES_PAYMENT_CHANGE` double unsigned DEFAULT '0',
  `SALES_PAYMENT_METHOD` tinyint(3) unsigned DEFAULT '0',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `SALES_INVOICE_UNIQUE` (`SALES_INVOICE`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales_header_tax`
--

LOCK TABLES `sales_header_tax` WRITE;
/*!40000 ALTER TABLE `sales_header_tax` DISABLE KEYS */;
INSERT INTO `sales_header_tax` VALUES (1,'SLO00001-4',0,'2016-04-25 00:00:00',20000,0,0,'2016-04-27',0,0,0,0),(2,'SLO00001-5',0,'2016-04-27 00:00:00',20000,0,1,'2016-04-27',1,100000,80000,0),(3,'SLO00001-7',0,'2016-04-27 00:00:00',20000,0,1,'2016-04-27',1,100000,80000,0),(4,'SLO00001-9',0,'2016-04-27 00:00:00',20200,0,1,'2016-04-27',1,100000,79800,0),(5,'-1',0,'2016-04-30 00:00:00',100,0,1,'2016-04-30',1,200,100,0),(6,'SLO001-2',0,'2016-05-02 12:19:00',1200,0,1,'2016-05-02',1,1200,0,0);
/*!40000 ALTER TABLE `sales_header_tax` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_config`
--

DROP TABLE IF EXISTS `sys_config`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sys_config` (
  `id` tinyint(3) unsigned NOT NULL,
  `no_faktur` varchar(30) NOT NULL DEFAULT '',
  `branch_id` tinyint(3) unsigned DEFAULT NULL,
  `HQ_IP4` varchar(15) DEFAULT NULL,
  `store_name` varchar(50) DEFAULT NULL,
  `store_address` varchar(100) DEFAULT NULL,
  `store_phone` varchar(20) DEFAULT NULL,
  `store_email` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_config`
--

LOCK TABLES `sys_config` WRITE;
/*!40000 ALTER TABLE `sys_config` DISABLE KEYS */;
INSERT INTO `sys_config` VALUES (1,'SLO001',0,'127.0.0.1',NULL,NULL,NULL,NULL),(2,'',1,'192.168.1.104','TOKO BARU','ALAMAT BARU','12345','11@11.com');
/*!40000 ALTER TABLE `sys_config` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_config_tax`
--

DROP TABLE IF EXISTS `sys_config_tax`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sys_config_tax` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PERSENTASE_PENJUALAN` int(11) DEFAULT '0',
  `PERSENTASE_PEMBELIAN` int(11) DEFAULT '0',
  `AVERAGE_PENJUALAN_HARIAN` double DEFAULT '0',
  `AVERAGE_PEMBELIAN_HARIAN` double DEFAULT '0',
  `RASIO_TOLERANSI` double DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_config_tax`
--

LOCK TABLES `sys_config_tax` WRITE;
/*!40000 ALTER TABLE `sys_config_tax` DISABLE KEYS */;
INSERT INTO `sys_config_tax` VALUES (1,50,50,0,0,0);
/*!40000 ALTER TABLE `sys_config_tax` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `temp_master_product`
--

DROP TABLE IF EXISTS `temp_master_product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `temp_master_product` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PRODUCT_ID` varchar(50) DEFAULT NULL,
  `PRODUCT_BARCODE` int(10) unsigned DEFAULT NULL,
  `PRODUCT_NAME` varchar(50) DEFAULT NULL,
  `PRODUCT_DESCRIPTION` varchar(100) DEFAULT NULL,
  `PRODUCT_BASE_PRICE` double DEFAULT NULL,
  `PRODUCT_RETAIL_PRICE` double DEFAULT NULL,
  `PRODUCT_BULK_PRICE` double DEFAULT NULL,
  `PRODUCT_WHOLESALE_PRICE` double DEFAULT NULL,
  `UNIT_ID` smallint(5) unsigned DEFAULT '0',
  `PRODUCT_IS_SERVICE` tinyint(3) unsigned DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `PRODUCT_ID_UNIQUE` (`PRODUCT_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `temp_master_product`
--

LOCK TABLES `temp_master_product` WRITE;
/*!40000 ALTER TABLE `temp_master_product` DISABLE KEYS */;
INSERT INTO `temp_master_product` VALUES (1,'PROD-1',2680923471,'SAPU LIDI','SAPU UNTUK NYAPU',1000,100000,1000,100,1,0),(2,'PROD-2',3408074444,'KAIN PEL','KAIN BUAT NGEPEL',100,20000,10000,1000,1,0),(3,'PROD-3',4017033181,'LIDI','SAPU DIPECAH JADI LIDI',200,1000,100,10,2,0),(4,'PROD-4',0,'KEMUCING SUPER',' ',100,100,100,100,1,0);
/*!40000 ALTER TABLE `temp_master_product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `temp_product_category`
--

DROP TABLE IF EXISTS `temp_product_category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `temp_product_category` (
  `PRODUCT_ID` varchar(50) NOT NULL,
  `CATEGORY_ID` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY (`PRODUCT_ID`,`CATEGORY_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `temp_product_category`
--

LOCK TABLES `temp_product_category` WRITE;
/*!40000 ALTER TABLE `temp_product_category` DISABLE KEYS */;
INSERT INTO `temp_product_category` VALUES ('PROD-1',1),('PROD-1',2),('PROD-1',3),('PROD-2',1),('PROD-2',2),('PROD-4',2);
/*!40000 ALTER TABLE `temp_product_category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unit_convert`
--

DROP TABLE IF EXISTS `unit_convert`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `unit_convert` (
  `CONVERT_UNIT_ID_1` smallint(5) unsigned NOT NULL,
  `CONVERT_UNIT_ID_2` smallint(5) unsigned NOT NULL,
  `CONVERT_MULTIPLIER` float DEFAULT NULL,
  PRIMARY KEY (`CONVERT_UNIT_ID_1`,`CONVERT_UNIT_ID_2`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unit_convert`
--

LOCK TABLES `unit_convert` WRITE;
/*!40000 ALTER TABLE `unit_convert` DISABLE KEYS */;
INSERT INTO `unit_convert` VALUES (1,2,10);
/*!40000 ALTER TABLE `unit_convert` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_access_management`
--

DROP TABLE IF EXISTS `user_access_management`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user_access_management` (
  `ID` smallint(5) unsigned NOT NULL AUTO_INCREMENT,
  `GROUP_ID` tinyint(3) unsigned DEFAULT NULL,
  `MODULE_ID` smallint(5) unsigned DEFAULT NULL,
  `USER_ACCESS_OPTION` tinyint(3) unsigned DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=99 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_access_management`
--

LOCK TABLES `user_access_management` WRITE;
/*!40000 ALTER TABLE `user_access_management` DISABLE KEYS */;
INSERT INTO `user_access_management` VALUES (1,1,1,1),(2,1,2,1),(3,1,3,6),(4,1,4,6),(5,1,5,1),(6,1,6,1),(7,1,7,1),(8,1,8,1),(9,1,9,1),(10,1,10,6),(11,1,11,1),(12,1,12,1),(13,1,13,1),(14,1,14,1),(15,1,15,1),(16,1,16,6),(17,1,17,1),(18,1,18,1),(19,1,19,1),(20,1,20,1),(21,1,21,1),(22,1,22,1),(23,1,23,6),(24,1,24,1),(25,1,25,1),(26,1,26,1),(27,1,27,1),(28,1,28,1),(29,1,29,1),(30,1,30,6),(31,1,31,6),(32,1,32,1),(33,1,33,1),(34,1,34,1),(35,1,35,1),(36,1,36,6),(37,1,37,1),(38,1,38,1),(39,1,39,1),(40,1,40,1),(41,1,41,1),(42,1,42,1),(43,1,43,6),(44,1,44,1),(45,1,45,1),(46,1,46,1),(47,1,47,1),(48,1,48,1),(49,2,1,0),(50,2,2,0),(51,2,3,0),(52,2,4,0),(53,2,5,0),(54,2,6,0),(55,2,7,0),(56,2,8,0),(57,2,9,0),(58,2,10,0),(59,2,11,0),(60,2,12,0),(61,2,13,0),(62,2,14,0),(63,2,15,0),(64,2,16,0),(65,2,17,0),(66,2,18,0),(67,2,19,0),(68,2,20,0),(69,2,21,0),(70,2,22,0),(71,2,23,0),(72,2,24,0),(73,2,25,0),(74,2,26,0),(75,2,27,0),(76,2,28,0),(77,2,29,0),(78,2,30,0),(79,2,31,0),(80,2,32,0),(81,2,33,0),(82,2,34,0),(83,2,35,1),(84,2,36,6),(85,2,37,1),(86,2,38,0),(87,2,39,1),(88,2,40,1),(89,2,41,1),(90,2,42,1),(91,2,43,0),(92,2,44,1),(93,2,45,1),(94,2,46,1),(95,2,47,0),(96,2,48,0),(97,1,49,1),(98,2,49,0);
/*!40000 ALTER TABLE `user_access_management` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_change_log`
--

DROP TABLE IF EXISTS `user_change_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user_change_log` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `USER_ID` tinyint(3) unsigned DEFAULT NULL,
  `MODULE_ID` smallint(6) DEFAULT NULL,
  `CHANGE_ID` tinyint(3) unsigned DEFAULT NULL,
  `CHANGE_DATETIME` datetime DEFAULT NULL,
  `CHANGE_DESCRIPTION` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_change_log`
--

LOCK TABLES `user_change_log` WRITE;
/*!40000 ALTER TABLE `user_change_log` DISABLE KEYS */;
/*!40000 ALTER TABLE `user_change_log` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-05-25 23:40:49
