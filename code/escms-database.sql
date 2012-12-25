-- MySQL dump 10.13  Distrib 5.5.9, for Win32 (x86)
--
-- Host: localhost    Database: escmsdatabase
-- ------------------------------------------------------
-- Server version	5.5.15

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
-- Current Database: `escmsdatabase`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `escmsdatabase` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `escmsdatabase`;

--
-- Table structure for table `application_register`
--

DROP TABLE IF EXISTS `application_register`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `application_register` (
  `apps_no` varchar(45) NOT NULL,
  `payment_id` varchar(45) DEFAULT NULL,
  `customerId` varchar(45) DEFAULT NULL,
  `received_date` datetime DEFAULT NULL,
  `estimateId` double DEFAULT NULL,
  `service_connection_no` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`apps_no`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `application_register`
--

LOCK TABLES `application_register` WRITE;
/*!40000 ALTER TABLE `application_register` DISABLE KEYS */;
INSERT INTO `application_register` VALUES ('41060.7617141435','41061.5446031829','41057.7643898495','2012-05-10 00:00:00',NULL,NULL),('41061.6123127315','41061.5446031829','41057.7643898495','2012-06-01 00:00:00',NULL,NULL),('41061.6124610069','41060.7607365278','41061.5303934491','2012-06-01 00:00:00',NULL,NULL),('41061.7829116319','41061.7826581597','41061.748149919','2012-06-01 00:00:00',NULL,NULL),('41062.4768278472','41061.7826581597','41061.748149919','2012-06-02 00:00:00',NULL,NULL),('41062.6626866551','41060.7603281366','41057.7643898495','2012-06-02 00:00:00',NULL,NULL),('41062.6636453241','41062.6634656019','41062.6632496991','2012-06-02 00:00:00',NULL,NULL),('41064.5601650463','41064.5591444792','41064.5587864468','2012-06-04 00:00:00',NULL,NULL),('41070.8224898148','41067.5490634491','41067.5377024074','2012-06-17 00:00:00',NULL,NULL),('41070.8254263889','41060.7603281366','41057.7643898495','2012-06-24 00:00:00',NULL,NULL),('41070.8276574769','41060.7603281366','41057.7643898495','2012-06-30 00:00:00',NULL,NULL),('41071.7921266898','41060.7603281366','41057.7643898495','2012-06-11 00:00:00',NULL,NULL),('41074.8322333796','41074.8319925463','41074.8317805903','2012-06-14 00:00:00',NULL,NULL),('41074.8494012616','41074.8489608796','41074.8484225694','2012-06-14 00:00:00',NULL,NULL),('41076.6291415972','41076.6287258912','41076.6280868171','2012-06-16 00:00:00',NULL,NULL),('41109.8730028357','41109.872568125','41109.8720209144','2012-07-19 00:00:00',NULL,NULL);
/*!40000 ALTER TABLE `application_register` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contractor`
--

DROP TABLE IF EXISTS `contractor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contractor` (
  `id` varchar(45) NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `address` varchar(45) DEFAULT NULL,
  `contact` varchar(45) DEFAULT NULL,
  `contract_details` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contractor`
--

LOCK TABLES `contractor` WRITE;
/*!40000 ALTER TABLE `contractor` DISABLE KEYS */;
INSERT INTO `contractor` VALUES ('41052.3615614468','Anirban Sadhukhan','Behala','9098789098','Due 5900'),('41052.7211475347','Sher Khan','Maniktala','0945467654','20000'),('41061.5411961458','Hashem Ali','Badar','8978987978','Advance 3000'),('41061.7549604977','Rabin Hood','Amazonpur','45565676546','4500');
/*!40000 ALTER TABLE `contractor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customer` (
  `id` varchar(45) NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `address` varchar(45) DEFAULT NULL,
  `contact` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` VALUES ('41057.7643898495','Ashok Majumder','Machalandapur','8979797979'),('41061.5303934491','Sajid Khan','Pakisthan','9878987678'),('41061.748149919','Amitava Roy','Hridaypur','9804567654'),('41061.7566040625','Dhrubo Sengupt','Arambag','9876789876'),('41062.6632496991','Sukanta Dey','Guma Habra','9898889988'),('41064.5587864468','Debanjan Chakraborty','Salt Lake','9984576007'),('41067.5377024074','Biplab Dhar','Barasat','9809876789'),('41071.8597513426','Kakali Ghosh','Badu','9098909870'),('41074.7568137037','Bikashi Kali Ghosh','Guma Habra','9098789098'),('41074.8317805903','amit paul','kolkata','87654'),('41074.8484225694','Kunal Mondal','Madhyamgram','9890989098'),('41076.6280868171','Indra Nabin','hridaypur','9876123456'),('41109.8720209144','saikat','madhyamgram','9230456789');
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `employee` (
  `id` varchar(45) NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `address` varchar(45) DEFAULT NULL,
  `contact` varchar(45) DEFAULT NULL,
  `post_type` varchar(45) DEFAULT NULL,
  `doj` datetime DEFAULT NULL,
  `department` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES ('41057.7661228472','Rabin Dasgupta','Bidhannagar','9090009878','2','2012-05-16 00:00:00','Other'),('41061.5381311574','Saptak Halder','Madhyamgram','89688676867','0','2012-06-07 00:00:00','Billing'),('41061.7883842361','Milon Marik','Bardawn','8988888888','2','2012-06-13 00:00:00','Billing'),('41067.553504838','Kuntal Mondal','Bankura','8789890987','2','2011-10-01 00:00:00','Other'),('41074.8182861111','Amit Khan','Delhi','9098987890','2','2012-06-14 00:00:00','Billing');
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `estimate`
--

DROP TABLE IF EXISTS `estimate`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `estimate` (
  `appNo` varchar(45) NOT NULL,
  `estimator` varchar(45) DEFAULT 'TBA',
  `wireLength` double DEFAULT '0',
  `angleType` varchar(45) DEFAULT 'Short',
  `angleWeight` double DEFAULT '0',
  `amountQuotation` double DEFAULT '0',
  `contractor` varchar(45) DEFAULT 'TBA',
  PRIMARY KEY (`appNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estimate`
--

LOCK TABLES `estimate` WRITE;
/*!40000 ALTER TABLE `estimate` DISABLE KEYS */;
INSERT INTO `estimate` VALUES ('41060.7617141435','Rabin',0,'Short',0,0,'TBA'),('41061.6123127315','Milon Marik',22,'0',122,122,'TBA'),('41061.6124610069','Milon',19,'0',12,13,'TBA'),('41061.7829116319','Saptak Halder',222,'1',232,332,'TBA'),('41062.4768278472','Saptak Halder',100,'1',200,300,'Anirban Sadhukhan'),('41074.759595625','Kuntal Mondal',30,'1',40,100,'TBA'),('41074.8322333796','Amit Khan',77,'1',777,777,'TBA'),('41074.8494012616','Rabin Dasgupta',330,'0',44,35,'Rabin Hood'),('41076.6291415972','Milon Marik',990,'1',800,6660,'Hashem Ali'),('41109.8730028357','Rabin Dasgupta',120,'0',450,8000,'Hashem Ali');
/*!40000 ALTER TABLE `estimate` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `meter_ger`
--

DROP TABLE IF EXISTS `meter_ger`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `meter_ger` (
  `id` varchar(45) NOT NULL,
  `connection_no` varchar(45) DEFAULT NULL,
  `connection_name` varchar(45) DEFAULT NULL,
  `address` varchar(100) DEFAULT NULL,
  `contact` varchar(12) DEFAULT NULL,
  `meter_no` varchar(45) DEFAULT NULL,
  `seal_no` varchar(45) DEFAULT NULL,
  `issue_date` datetime DEFAULT NULL,
  `work_assign_to` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `meter_ger`
--

LOCK TABLES `meter_ger` WRITE;
/*!40000 ALTER TABLE `meter_ger` DISABLE KEYS */;
/*!40000 ALTER TABLE `meter_ger` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `meter_register`
--

DROP TABLE IF EXISTS `meter_register`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `meter_register` (
  `id` varchar(45) NOT NULL,
  `connection_no` varchar(45) DEFAULT NULL,
  `connection_name` varchar(45) DEFAULT NULL,
  `address` varchar(100) DEFAULT NULL,
  `contact` varchar(12) DEFAULT NULL,
  `meter_no` varchar(45) DEFAULT NULL,
  `seal_no` varchar(45) DEFAULT NULL,
  `issue_date` datetime DEFAULT NULL,
  `work_assign_to` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `meter_register`
--

LOCK TABLES `meter_register` WRITE;
/*!40000 ALTER TABLE `meter_register` DISABLE KEYS */;
/*!40000 ALTER TABLE `meter_register` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payment`
--

DROP TABLE IF EXISTS `payment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `payment` (
  `id` varchar(45) NOT NULL,
  `customerId` varchar(45) DEFAULT NULL,
  `amount` double DEFAULT NULL,
  `dop` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payment`
--

LOCK TABLES `payment` WRITE;
/*!40000 ALTER TABLE `payment` DISABLE KEYS */;
INSERT INTO `payment` VALUES ('41060.7603281366','41057.7643898495',7880,'2012-05-27 00:00:00'),('41060.7607365278','41061.5303934491',111,'2012-05-31 00:00:00'),('41061.5446031829','41057.7643898495',500,'2012-06-01 00:00:00'),('41061.7582123843','41061.7566040625',6789,'2012-06-15 00:00:00'),('41061.7826581597','41061.748149919',555,'2012-05-31 00:00:00'),('41062.662453831','41061.748149919',300,'2012-06-02 00:00:00'),('41062.6634656019','41062.6632496991',7000,'2012-06-02 00:00:00'),('41064.5591444792','41064.5587864468',777,'2012-06-04 00:00:00'),('41067.5490634491','41067.5377024074',798,'2012-06-07 00:00:00'),('41071.8599448843','41071.8597513426',9000,'2012-06-11 00:00:00'),('41074.759365787','41074.7568137037',1000,'2012-06-14 00:00:00'),('41074.8319925463','41074.8317805903',888,'2012-06-14 00:00:00'),('41074.8489608796','41074.8484225694',9900,'2012-06-14 00:00:00'),('41076.6287258912','41076.6280868171',700,'2012-06-13 00:00:00'),('41109.872568125','41109.8720209144',500,'2012-07-19 00:00:00');
/*!40000 ALTER TABLE `payment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `service_connection_register`
--

DROP TABLE IF EXISTS `service_connection_register`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `service_connection_register` (
  `id` varchar(45) NOT NULL,
  `apps_no` varchar(45) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `address` varchar(100) DEFAULT NULL,
  `contact` varchar(12) DEFAULT NULL,
  `wire_length` varchar(45) DEFAULT NULL,
  `initial_deposite_amount` double DEFAULT NULL,
  `angle_type` varchar(45) DEFAULT NULL,
  `angle_weight` varchar(45) DEFAULT NULL,
  `quotation_amount` double DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `service_connection_register`
--

LOCK TABLES `service_connection_register` WRITE;
/*!40000 ALTER TABLE `service_connection_register` DISABLE KEYS */;
/*!40000 ALTER TABLE `service_connection_register` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2012-07-21 21:44:00
