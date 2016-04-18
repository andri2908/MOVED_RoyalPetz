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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `daily_journal`
--

DROP TABLE IF EXISTS `daily_journal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `daily_journal` (
  `journal_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `account_id` smallint(5) unsigned NOT NULL,
  `journal_datetime` date NOT NULL,
  `journal_nominal` double NOT NULL,
  `branch_id` tinyint(3) unsigned DEFAULT NULL,
  `journal_description` varchar(100) DEFAULT NULL,
  `user_id` tinyint(3) unsigned NOT NULL,
  `pm_id` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY (`journal_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

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
  PRIMARY KEY (`GROUP_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_group`
--

LOCK TABLES `master_group` WRITE;
/*!40000 ALTER TABLE `master_group` DISABLE KEYS */;
INSERT INTO `master_group` VALUES (1,'GLOBAL_ADMIN','GLOBAL ADMIN GROUP',1);
/*!40000 ALTER TABLE `master_group` ENABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_module`
--

LOCK TABLES `master_module` WRITE;
/*!40000 ALTER TABLE `master_module` DISABLE KEYS */;
INSERT INTO `master_module` VALUES (1,'MANAJEMEN SISTEM',NULL,1,1),(2,'DATABASE',NULL,1,1),(3,'MANAJEMEN USER',NULL,3,1),(4,'MANAJEMEN CABANG',NULL,3,1),(5,'SINKRONISASI INFORMASI',NULL,1,1),(6,'PENGATURAN PRINTER',NULL,1,1),(7,'PENGATURAN GAMBAR LATAR',NULL,1,1),(8,'GUDANG',NULL,1,1),(9,'PRODUK',NULL,1,1),(10,'TAMBAH / UPDATE PRODUK',NULL,3,1),(11,'PENGATURAN HARGA PRODUK',NULL,1,1),(12,'PENGATURAN LIMIT STOK',NULL,1,1),(13,'PENGATURAN KATEGORI PRODUK',NULL,1,1),(14,'PECAH SATUAN PRODUK',NULL,1,1),(15,'PENGATURAN NOMOR RAK',NULL,1,1),(16,'KATEGORI PRODUK',NULL,3,1),(17,'SATUAN PRODUK',NULL,1,1),(18,'TAMBAH / UPDATE SATUAN',NULL,1,1),(19,'PENGATURAN KONVERSI SATUAN',NULL,1,1),(20,'STOK OPNAME',NULL,1,1),(21,'PENYESUAIAN STOK',NULL,1,1),(22,'MUTASI BARANG',NULL,1,1),(23,'TAMBAH / UPDATE MUTASI BARANG',NULL,3,1),(24,'CEK PERMINTAAN BARANG',NULL,1,1),(25,'PENERIMAAN BARANG',NULL,1,1),(26,'PENERIMAAN BARANG DARI MUTASI',NULL,1,1),(27,'PENERIMAAN BARANG DARI PO',NULL,1,1),(28,'PEMBELIAN',NULL,1,1),(29,'SUPPLIER',NULL,1,1),(30,'REQUEST ORDER',NULL,3,1),(31,'PURCHASE ORDER',NULL,3,1),(32,'REPRINT REQUEST ORDER',NULL,1,1),(33,'RETUR PEMBELIAN KE SUPPLIER',NULL,1,1),(34,'RETUR PERMINTAAN KE PUSAT',NULL,1,1),(35,'PENJUALAN',NULL,1,1),(36,'PELANGGAN',NULL,3,1),(37,'TRANSAKSI PENJUALAN',NULL,1,1),(38,'SET NO FAKTUR',NULL,1,1),(39,'RETUR PENJUALAN',NULL,1,1),(40,'RETUR PENJUALAN BY INVOICE',NULL,1,1),(41,'RETUR PENJUALAN BY STOK',NULL,1,1),(42,'KEUANGAN',NULL,1,1),(43,'PENGATURAN NO AKUN',NULL,3,1),(44,'TRANSAKSI HARIAN',NULL,1,1),(45,'TAMBAH TRANSAKSI HARIAN',NULL,1,1),(46,'PEMBAYARAN PIUTANG',NULL,1,1),(47,'PEMBAYARAN PIUTANG MUTASI',NULL,1,1),(48,'PEMBAYARAN HUTANG KE SUPPLIER',NULL,1,1);
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='	';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_user`
--

LOCK TABLES `master_user` WRITE;
/*!40000 ALTER TABLE `master_user` DISABLE KEYS */;
INSERT INTO `master_user` VALUES (1,'ADMIN','admin','ADMIN','1',1,1);
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='		';
/*!40101 SET character_set_client = @saved_cs_client */;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

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
  `SALES_DATE` date DEFAULT NULL,
  `SALES_TOTAL` double DEFAULT '0',
  `SALES_DISCOUNT_FINAL` double DEFAULT '0',
  `SALES_TOP` tinyint(3) unsigned DEFAULT '0',
  `SALES_TOP_DATE` date DEFAULT NULL,
  `SALES_PAID` tinyint(3) unsigned DEFAULT '0',
  `SALES_PAYMENT` double unsigned DEFAULT '0',
  `SALES_PAYMENT_CHANGE` double unsigned DEFAULT '0',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `SALES_INVOICE_UNIQUE` (`SALES_INVOICE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

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
INSERT INTO `sys_config` VALUES (1,'SLO00001',0,'127.0.0.1',NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `sys_config` ENABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

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
) ENGINE=InnoDB AUTO_INCREMENT = 49 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `user_access_management`
--

LOCK TABLES `user_access_management` WRITE;
/*!40000 ALTER TABLE `user_access_management` DISABLE KEYS */;
INSERT INTO `user_access_management` VALUES (1,1,1,1),(2,1,2,1),(3,1,3,6),(4,1,4,6),(5,1,5,1),(6,1,6,1),(7,1,7,1),(8,1,8,1),(9,1,9,1),(10,1,10,6),(11,1,11,1),(12,1,12,1),(13,1,13,1),(14,1,14,1),(15,1,15,1),(16,1,16,6),(17,1,17,1),(18,1,18,1),(19,1,19,1),(20,1,20,1),(21,1,21,1),(22,1,22,1),(23,1,23,6),(24,1,24,1),(25,1,25,1),(26,1,26,1),(27,1,27,1),(28,1,28,1),(29,1,29,1),(30,1,30,6),(31,1,31,6),(32,1,32,1),(33,1,33,1),(34,1,34,1),(35,1,35,1),(36,1,36,6),(37,1,37,1),(38,1,38,1),(39,1,39,1),(40,1,40,1),(41,1,41,1),(42,1,42,1),(43,1,43,6),(44,1,44,1),(45,1,45,1),(46,1,46,1),(47,1,47,1),(48,1,48,1);
/*!40000 ALTER TABLE `user_access_management` ENABLE KEYS */;
UNLOCK TABLES;

/*!40101 SET character_set_client = @saved_cs_client */;

/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-04-09  1:47:16
