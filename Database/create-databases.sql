DROP DATABASE IF EXISTS `nuvem_db`;
CREATE DATABASE `nuvem_db`; 
USE `nuvem_db`;

SET NAMES utf8 ;
SET character_set_client = utf8mb4 ;

CREATE TABLE `pharmacies` (
  `id` varchar(36) NOT NULL,
  `name` varchar(50) NOT NULL,
  `address` varchar(50) NOT NULL,
  `city` varchar(50) NOT NULL,
  `state` char(2) NOT NULL,
  `zip` varchar(5) NOT NULL,
  `filledprescriptions` int(9) DEFAULT(0) NOT NULL,
  `creationdate` datetime DEFAULT(now()) NOT NULL,
  `updatedate` datetime DEFAULT(now()) NOT NULL,
  `deletiondate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
INSERT INTO `pharmacies` VALUES ('3d80141a-0542-4f37-8dc8-ad186dd929c0','MediCare Pharmacy','123 Main Street','Willowville','NY','12345',DEFAULT,DEFAULT,DEFAULT,DEFAULT);
INSERT INTO `pharmacies` VALUES ('a9fbd9bc-0ada-4d07-86aa-5a4522201530','Wellness Rx Pharmacy','456 Elm Avenue','Healthville','CA','67890',DEFAULT,DEFAULT,DEFAULT,DEFAULT);
INSERT INTO `pharmacies` VALUES ('a0cda06b-eaac-4146-9a63-0ad2cb8cdfa8','Vitality Pharmacy','789 Oak Road','Lifetown','TX','54321',DEFAULT,DEFAULT,DEFAULT,DEFAULT);
INSERT INTO `pharmacies` VALUES ('fd84cd2b-95f6-4706-b217-468adfe1ebf9','ApotheCare Pharmacy','987 Maple Lane','Remedyville','FL','45678',DEFAULT,DEFAULT,DEFAULT,DEFAULT);
INSERT INTO `pharmacies` VALUES ('c7a64b5b-baf7-4a2b-8245-ced86b06eac2','Healing Hands Pharmacy','654 Pine Street','Cureville','IL','78901',DEFAULT,DEFAULT,DEFAULT,DEFAULT);
