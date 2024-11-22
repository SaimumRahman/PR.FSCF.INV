-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.5.25-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             12.8.0.6908
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Dumping structure for table invsafer.company
CREATE TABLE IF NOT EXISTS `company` (
  `CompanyID` int(11) NOT NULL AUTO_INCREMENT,
  `CompanyShortName` varchar(255) DEFAULT NULL,
  `CompanyName` varchar(255) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `CreateBy` int(11) DEFAULT NULL,
  `CreateOn` datetime DEFAULT NULL,
  `CreatePc` varchar(255) DEFAULT NULL,
  `UpdateBy` int(11) DEFAULT NULL,
  `UpdateOn` datetime DEFAULT NULL,
  `UpdatePc` varchar(255) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeleteBy` int(11) DEFAULT NULL,
  `DeleteOn` datetime DEFAULT NULL,
  `DeletePc` varchar(255) DEFAULT NULL,
  `Logo` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`CompanyID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Data exporting was unselected.

-- Dumping structure for table invsafer.core_refreshtoken
CREATE TABLE IF NOT EXISTS `core_refreshtoken` (
  `UserId` int(11) DEFAULT NULL,
  `Token` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Data exporting was unselected.

-- Dumping structure for table invsafer.fscd_users
CREATE TABLE IF NOT EXISTS `fscd_users` (
  `Id` varchar(255) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL DEFAULT 0,
  `PasswordHash` text DEFAULT NULL,
  `SecurityStamp` text DEFAULT NULL,
  `ConcurrencyStamp` text DEFAULT NULL,
  `PhoneNumber` varchar(256) DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL DEFAULT 0,
  `TwoFactorEnabled` tinyint(1) NOT NULL DEFAULT 0,
  `LockoutEnd` datetime DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL DEFAULT 0,
  `AccessFailedCount` int(11) NOT NULL DEFAULT 0,
  `EmpId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Data exporting was unselected.

-- Dumping structure for table invsafer.itembrand
CREATE TABLE IF NOT EXISTS `itembrand` (
  `ItemBrandID` int(11) NOT NULL AUTO_INCREMENT,
  `BrandName` varchar(255) NOT NULL,
  `CompanyID` int(11) DEFAULT NULL,
  `CreateBy` int(11) DEFAULT NULL,
  `CreateOn` datetime DEFAULT NULL,
  `CreatePc` varchar(255) DEFAULT NULL,
  `UpdateBy` int(11) DEFAULT NULL,
  `UpdateOn` datetime DEFAULT NULL,
  `UpdatePc` varchar(255) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0,
  `DeleteBy` int(11) DEFAULT NULL,
  `DeleteOn` datetime DEFAULT NULL,
  `DeletePc` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ItemBrandID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Data exporting was unselected.

-- Dumping structure for table invsafer.itemmaster
CREATE TABLE IF NOT EXISTS `itemmaster` (
  `ItemID` bigint(20) NOT NULL AUTO_INCREMENT,
  `ItemTypeID` int(11) DEFAULT NULL,
  `ItemName` varchar(255) NOT NULL,
  `UnitId` int(11) DEFAULT NULL,
  `ItemBrandID` int(11) DEFAULT NULL,
  `ItemModelID` int(11) DEFAULT NULL,
  `Barcode` varchar(255) DEFAULT NULL,
  `Description` text DEFAULT NULL,
  `StatusID` int(11) DEFAULT NULL,
  `CompanyID` int(11) DEFAULT NULL,
  `CreateBy` int(11) DEFAULT NULL,
  `CreateOn` datetime DEFAULT NULL,
  `CreatePc` varchar(255) DEFAULT NULL,
  `UpdateBy` int(11) DEFAULT NULL,
  `UpdateOn` datetime DEFAULT NULL,
  `UpdatePc` varchar(255) DEFAULT NULL,
  `IsDeleted` tinyint(1) DEFAULT NULL,
  `DeleteBy` int(11) DEFAULT NULL,
  `DeleteOn` datetime DEFAULT NULL,
  `DeletePc` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ItemID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Data exporting was unselected.

-- Dumping structure for table invsafer.itemmodel
CREATE TABLE IF NOT EXISTS `itemmodel` (
  `ItemModelID` int(11) NOT NULL AUTO_INCREMENT,
  `ModelName` varchar(255) NOT NULL,
  `Description` text DEFAULT NULL,
  `StatusID` int(11) DEFAULT NULL,
  `CompanyID` int(11) NOT NULL,
  `CreateBy` int(11) DEFAULT NULL,
  `CreateOn` datetime DEFAULT NULL,
  `CreatePc` varchar(255) DEFAULT NULL,
  `UpdateBy` int(11) DEFAULT NULL,
  `UpdateOn` datetime DEFAULT NULL,
  `UpdatePc` varchar(255) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0,
  `DeleteBy` int(11) DEFAULT NULL,
  `DeleteOn` datetime DEFAULT NULL,
  `DeletePc` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ItemModelID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Data exporting was unselected.

-- Dumping structure for table invsafer.itemserial
CREATE TABLE IF NOT EXISTS `itemserial` (
  `SerialId` int(11) NOT NULL AUTO_INCREMENT,
  `ItemId` int(11) DEFAULT NULL,
  `SerialNo` int(11) DEFAULT NULL,
  `StatusId` int(11) DEFAULT NULL,
  `IsReplaced` bit(1) DEFAULT NULL,
  `CompanyID` int(11) NOT NULL,
  `CreateBy` int(11) DEFAULT NULL,
  `CreateOn` datetime DEFAULT NULL,
  `CreatePc` varchar(255) DEFAULT NULL,
  `UpdateBy` int(11) DEFAULT NULL,
  `UpdateOn` datetime DEFAULT NULL,
  `UpdatePc` varchar(255) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0,
  `DeleteBy` int(11) DEFAULT NULL,
  `DeleteOn` datetime DEFAULT NULL,
  `DeletePc` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`SerialId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Data exporting was unselected.

-- Dumping structure for table invsafer.itemtype
CREATE TABLE IF NOT EXISTS `itemtype` (
  `ItemTypeID` int(11) NOT NULL AUTO_INCREMENT,
  `CustomCode` varchar(255) DEFAULT NULL,
  `ItemTypeName` varchar(255) DEFAULT NULL,
  `CompanyID` int(11) DEFAULT NULL,
  `CreateBy` int(11) DEFAULT NULL,
  `CreateOn` datetime DEFAULT NULL,
  `CreatePc` varchar(255) DEFAULT NULL,
  `UpdateBy` int(11) DEFAULT NULL,
  `UpdateOn` datetime DEFAULT NULL,
  `UpdatePc` varchar(255) DEFAULT NULL,
  `IsDeleted` tinyint(1) DEFAULT NULL,
  `DeleteBy` int(11) DEFAULT NULL,
  `DeleteOn` datetime DEFAULT NULL,
  `DeletePc` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ItemTypeID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Data exporting was unselected.

-- Dumping structure for table invsafer.status
CREATE TABLE IF NOT EXISTS `status` (
  `StatusID` int(11) NOT NULL AUTO_INCREMENT,
  `StatusName` varchar(255) NOT NULL,
  `IsActive` tinyint(1) DEFAULT NULL,
  `CompanyID` int(11) NOT NULL,
  `CreateBy` int(11) DEFAULT NULL,
  `CreateOn` datetime DEFAULT NULL,
  `CreatePc` varchar(255) DEFAULT NULL,
  `UpdateBy` int(11) DEFAULT NULL,
  `UpdateOn` datetime DEFAULT NULL,
  `UpdatePc` varchar(255) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0,
  `DeleteBy` int(11) DEFAULT NULL,
  `DeleteOn` datetime DEFAULT NULL,
  `DeletePc` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`StatusID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Data exporting was unselected.

-- Dumping structure for table invsafer.stockdetails
CREATE TABLE IF NOT EXISTS `stockdetails` (
  `StockDetailID` int(11) NOT NULL AUTO_INCREMENT,
  `StockMasterID` int(11) NOT NULL,
  `TransactionTypeID` int(11) NOT NULL,
  `TransactionID` int(11) NOT NULL,
  `ReceiveQty` decimal(18,2) DEFAULT NULL,
  `IssueQty` decimal(18,2) DEFAULT NULL,
  `IsActive` tinyint(1) DEFAULT NULL,
  `CompanyID` int(11) DEFAULT NULL,
  `CreateBy` int(11) DEFAULT NULL,
  `CreateOn` datetime DEFAULT NULL,
  `CreatePc` varchar(255) DEFAULT NULL,
  `UpdateBy` int(11) DEFAULT NULL,
  `UpdateOn` datetime DEFAULT NULL,
  `UpdatePc` varchar(255) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0,
  `DeleteBy` int(11) DEFAULT NULL,
  `DeleteOn` datetime DEFAULT NULL,
  `DeletePc` varchar(255) DEFAULT NULL,
  `SerialId` int(11) DEFAULT NULL,
  `TransactionNo` varchar(255) DEFAULT NULL,
  `Narration` text DEFAULT NULL,
  PRIMARY KEY (`StockDetailID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Data exporting was unselected.

-- Dumping structure for table invsafer.stockmaster
CREATE TABLE IF NOT EXISTS `stockmaster` (
  `StockID` int(11) NOT NULL AUTO_INCREMENT,
  `SupplierID` int(11) DEFAULT NULL,
  `ItemID` bigint(20) NOT NULL,
  `UOMID` int(11) NOT NULL,
  `ReceiveQty` decimal(18,2) DEFAULT NULL,
  `ReceiveValue` decimal(18,2) DEFAULT NULL,
  `LastReceiveDate` datetime DEFAULT NULL,
  `IssueQty` decimal(18,2) NOT NULL,
  `IssueValue` decimal(18,2) DEFAULT NULL,
  `LastIssueDate` datetime DEFAULT NULL,
  `CurrentRate` decimal(18,2) NOT NULL,
  `CurrentStock` decimal(18,2) DEFAULT NULL,
  `CurrentValue` decimal(18,2) DEFAULT NULL,
  `IsActive` tinyint(1) DEFAULT NULL,
  `CompanyID` int(11) DEFAULT NULL,
  `StationId` int(11) DEFAULT NULL,
  `CreateBy` int(11) DEFAULT NULL,
  `CreateOn` datetime DEFAULT NULL,
  `CreatePc` varchar(255) DEFAULT NULL,
  `UpdateBy` int(11) DEFAULT NULL,
  `UpdateOn` datetime DEFAULT NULL,
  `UpdatePc` varchar(255) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeleteBy` int(11) DEFAULT NULL,
  `DeleteOn` datetime DEFAULT NULL,
  `DeletePc` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`StockID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Data exporting was unselected.

-- Dumping structure for table invsafer.supplier
CREATE TABLE IF NOT EXISTS `supplier` (
  `supplierid` int(11) NOT NULL AUTO_INCREMENT,
  `suppliername` varchar(255) NOT NULL,
  `supplierlocation` varchar(255) DEFAULT NULL,
  `contactpersonname` varchar(255) DEFAULT NULL,
  `contactpersonnumber` varchar(50) DEFAULT NULL,
  `contactpersonemail` varchar(255) DEFAULT NULL,
  `remarks` text DEFAULT NULL,
  `companyid` int(11) NOT NULL,
  `createby` int(11) DEFAULT NULL,
  `createon` datetime DEFAULT NULL,
  `createpc` varchar(255) DEFAULT NULL,
  `updateby` int(11) DEFAULT NULL,
  `updateon` datetime DEFAULT NULL,
  `updatepc` varchar(255) DEFAULT NULL,
  `isdeleted` tinyint(1) NOT NULL DEFAULT 0,
  `deleteby` int(11) DEFAULT NULL,
  `deleteon` datetime DEFAULT NULL,
  `deletepc` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`supplierid`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Data exporting was unselected.

-- Dumping structure for table invsafer.transactiontypes
CREATE TABLE IF NOT EXISTS `transactiontypes` (
  `TransactionTypeID` int(11) NOT NULL AUTO_INCREMENT,
  `TransactionTypeName` varchar(255) NOT NULL,
  `StatusID` int(11) DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL,
  `CompanyID` int(11) NOT NULL,
  `CreateBy` int(11) DEFAULT NULL,
  `CreateOn` datetime DEFAULT NULL,
  `CreatePc` varchar(255) DEFAULT NULL,
  `UpdateBy` int(11) DEFAULT NULL,
  `UpdateOn` datetime DEFAULT NULL,
  `UpdatePc` varchar(255) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeleteBy` int(11) DEFAULT NULL,
  `DeleteOn` datetime DEFAULT NULL,
  `DeletePc` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`TransactionTypeID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Data exporting was unselected.

-- Dumping structure for table invsafer.uom
CREATE TABLE IF NOT EXISTS `uom` (
  `UOMID` int(11) NOT NULL AUTO_INCREMENT,
  `UOMName` varchar(255) NOT NULL,
  `UOMShortName` varchar(50) NOT NULL,
  `StatusID` int(11) DEFAULT NULL,
  `CompanyID` int(11) DEFAULT NULL,
  `CreateBy` int(11) DEFAULT NULL,
  `CreateOn` datetime DEFAULT NULL,
  `CreatePc` varchar(255) DEFAULT NULL,
  `UpdateBy` int(11) DEFAULT NULL,
  `UpdateOn` datetime DEFAULT NULL,
  `UpdatePc` varchar(255) DEFAULT NULL,
  `IsDeleted` tinyint(1) DEFAULT NULL,
  `DeleteBy` int(11) DEFAULT NULL,
  `DeleteOn` datetime DEFAULT NULL,
  `DeletePc` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`UOMID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Data exporting was unselected.

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
