-- MySQL dump 10.13  Distrib 8.0.28, for Linux (x86_64)
--
-- Host: localhost    Database: labaratory2
-- ------------------------------------------------------
-- Server version	8.0.28-0ubuntu0.20.04.3

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `usersData`
--

DROP TABLE IF EXISTS `usersData`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usersData` (
  `id` int NOT NULL AUTO_INCREMENT,
  `modelT` varchar(50) NOT NULL,
  `countT` int unsigned NOT NULL,
  `brandT` varchar(10) NOT NULL,
  `comment` varchar(100) NOT NULL,
  `adressC` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `nameC` varchar(50) NOT NULL,
  `buyPlace` varchar(50) NOT NULL,
  `country` varchar(15) NOT NULL,
  `phone` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `email` varchar(50) NOT NULL,
  `theDay` varchar(20) NOT NULL,
  `fast` tinyint NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usersData`
--

LOCK TABLES `usersData` WRITE;
/*!40000 ALTER TABLE `usersData` DISABLE KEYS */;
INSERT INTO `usersData` VALUES (1,'Телефон',1,'Samsung','Не работает кнопка включения.','ул. Перова Поля д. 2','Крутой Бобер','в официальном магазине','отечественное','+7 (916) 947-68-30','BelousVikV@mpei.ru','Понедельник',1),(4,'Планшет',1,'Apple','Не работает кнопка включения.','ул. Перова Поля д. 2','Крутой Бобер','в неофициальном магазине','импортное','+7 (916) 947-68-30','BelousVikV@mpei.ru','Среда',1),(5,'Телефон',2,'Huawei','Сломался экран','ул. Перова Поля д. 10','Дерево','нет данных','импортное','+7 (916) 789-12-11','artderevo@mail.ru','Суббота',0),(6,'Ноутбук',1,'Apple','Сломался аккумулятор','ул. Бобра д. 11','Футболисты','в неофициальном магазине','отечественное','+7 (916) 950-88-33','football@mail.ru','Пятница',1),(7,'Телефон',5,'Apple','Требуется замена аккумуляторов','ул. Перова Поля д. 8','Живая река','в официальном магазине','импортное','+7 (916) 888-91-00','admin@rivers.ru','Четверг',1),(8,'Планшет',2,'Huawei','Сломался экран','ул. Перова Поля д. 8','Каменный уголь','в неофициальном магазине','импортное','+7 (916) 999-01-11','admin@stone.ru','Воскресенье',0);
/*!40000 ALTER TABLE `usersData` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-04-08 16:40:08
