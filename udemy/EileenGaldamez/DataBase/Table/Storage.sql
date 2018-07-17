USE [EileenGaldamez]
GO

CREATE TABLE dbo.tblProductType(
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	name VARCHAR(100) NOT NULL,
	detail VARCHAR(255),
	createDate DATETIME DEFAULT GETDATE(),
	upDateDate DATETIME,
	deleteDate DATETIME,
	[state] VARCHAR(20) DEFAULT 'Active'
);

CREATE TABLE dbo.tblProduct(
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	code VARCHAR(25) NOT NULL,
	name VARCHAR(255) NOT NULL,
	unit VARCHAR(100),
	idProductType INT,
	detail VARCHAR(255),
	createDate DATETIME DEFAULT GETDATE(),
	upDateDate DATETIME,
	deleteDate DATETIME,
	[state] VARCHAR(20) DEFAULT 'Active'
);

CREATE TABLE dbo.tblFileManager(
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	[fileName] VARCHAR(100),
	fileType VARCHAR(50),
	fileSize INT,
	fileFile IMAGE,
	fileDetail VARCHAR(255),
	createDate DATETIME DEFAULT GETDATE(),
	upDateDate DATETIME,
	deleteDate DATETIME,
	[state] VARCHAR(20) DEFAULT 'Active'
);

CREATE TABLE dbo.tblCellarArea(
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	name VARCHAR(100) NOT NULL,
	detail VARCHAR(255),
	createDate DATETIME DEFAULT GETDATE(),
	upDateDate DATETIME,
	deleteDate DATETIME,
	[state] VARCHAR(20) DEFAULT 'Active'
);

CREATE TABLE dbo.tblCategory(
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	name VARCHAR(100) NOT NULL,
	idCategory int,
	idCellarArea INT,
	detail VARCHAR(255),
	createDate DATETIME DEFAULT GETDATE(),
	upDateDate DATETIME,
	deleteDate DATETIME,
	[state] VARCHAR(20) DEFAULT 'Active'
);

CREATE TABLE dbo.tblTypePermission(
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	name VARCHAR(100) NOT NULL,
	detail VARCHAR(255),
	numberLevel INT,
	createDate DATETIME DEFAULT GETDATE(),
	upDateDate DATETIME,
	deleteDate DATETIME,
	[state] VARCHAR(20) DEFAULT 'Active'
);


CREATE TABLE dbo.tblUserType(
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	name VARCHAR(100) NOT NULL,
	detail VARCHAR(255),
	createDate DATETIME DEFAULT GETDATE(),
	upDateDate DATETIME,
	deleteDate DATETIME,
	[state] VARCHAR(20) DEFAULT 'Active'
);

CREATE TABLE dbo.tblProvider (
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	companyName VARCHAR(100), 
	detail VARCHAR(255),
	createDate DATETIME DEFAULT GETDATE(),
	upDateDate DATETIME,
	deleteDate DATETIME,
	[state] VARCHAR(20) DEFAULT 'Active'
);

CREATE TABLE dbo.tblContactInformation(
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	FirstName VARCHAR(100),
	LastName VARCHAR(100),
	phoneNumber int,
	cellPhone int,
	faxPhone int,
	email VARCHAR(100),
	detail VARCHAR(255),
	createDate DATETIME DEFAULT GETDATE(),
	upDateDate DATETIME,
	deleteDate DATETIME,
	[state] VARCHAR(20) DEFAULT 'Active'
);

CREATE TABLE dbo.tblProverContactInformation (
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	idProvider int,
	idContactInformation int,
	createDate DATETIME DEFAULT GETDATE(),
	upDateDate DATETIME,
	deleteDate DATETIME,
	[state] VARCHAR(20) DEFAULT 'Active'
);

CREATE TABLE dbo.tblUser (
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	[user] VARCHAR(100),
	[password] text,
	createDate DATETIME DEFAULT GETDATE(),
	upDateDate DATETIME,
	deleteDate DATETIME,
	[state] VARCHAR(20) DEFAULT 'Active'
);

CREATE TABLE dbo.tblEmployee(
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	firstName VARCHAR(100),
	lastName VARCHAR(100),
	email VARCHAR(100),
	idUserType INT,
	idUser INT,
	createDate DATETIME DEFAULT GETDATE(),
	upDateDate DATETIME,
	deleteDate DATETIME,
	[state] VARCHAR(20) DEFAULT 'Active'
);

CREATE TABLE dbo.tblUserConfiguration (
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	idUser INT,
	idTypePermission INT,
	idCellarArea INT,
	idAssignmentType INT,
	idAnchorAssignmentType INT,
	createDate DATETIME DEFAULT GETDATE(),
	upDateDate DATETIME,
	deleteDate DATETIME,
	[state] VARCHAR(20) DEFAULT 'Active'
);

----------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE dbo.tblCellar(
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	amount int,
	idProduct INT,
	idcellarArea INT,
	[min] INT,
	[max] INT,
	detail VARCHAR(255),
	createDate DATETIME DEFAULT GETDATE(),
	upDateDate DATETIME,
	deleteDate DATETIME,
	[state] VARCHAR(20) DEFAULT 'Active'
);

CREATE TABLE dbo.tblTransaction (
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	amount int,
	idProvide INT, 
	detail VARCHAR(255),
	createDate DATETIME DEFAULT GETDATE(),
	upDateDate DATETIME,
	deleteDate DATETIME,
	[state] VARCHAR(20) DEFAULT 'Active'
);
----------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------
-- Cellar Assignation dowlo....
----------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE dbo.tblTransactionType(
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	name VARCHAR(100) NOT NULL,
	detail VARCHAR(255),
	createDate DATETIME DEFAULT GETDATE(),
	upDateDate DATETIME,
	deleteDate DATETIME,
	[state] VARCHAR(20) DEFAULT 'Active'
);

CREATE TABLE dbo.tblAssignment (
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	amount INT,
	loan INT,
	idProduct INT, 
	[min] INT,
	[max] INT,
	idEmployee INT,
	idCategory INT, 
	detail VARCHAR(255),
	createDate DATETIME DEFAULT GETDATE(),
	upDateDate DATETIME,
	deleteDate DATETIME,
	[state] VARCHAR(20) DEFAULT 'Active'
);

CREATE TABLE dbo.tblTransactionConfigurate (
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	idTransaction INT,
	idTransactionType INT,
	idAnchorTransaction INT,
	detail VARCHAR(255),
	createDate DATETIME DEFAULT GETDATE(),
	upDateDate DATETIME,
	deleteDate DATETIME,
	[state] VARCHAR(20) DEFAULT 'Active'
);

CREATE TABLE dbo.tblDownloadAssignment (
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	amount int,
	idProduct INT, 
	idEmployee INT, 
	detail VARCHAR(255),
	createDate DATETIME DEFAULT GETDATE(),
	upDateDate DATETIME,
	deleteDate DATETIME,
	[state] VARCHAR(20) DEFAULT 'Active'
);

CREATE TABLE dbo.tblLoanAssignment (
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	idProducto INT,
	[stateProduct] VARCHAR(25),
	dateLoan DATETIME,
	detailLoan VARCHAR(255),
	dateReturn DATETIME,
	detailReturn VARCHAR(255),
	idAssignment INT,
	idEmployee INT, 
	detail VARCHAR(255),
	createDate DATETIME DEFAULT GETDATE(),
	upDateDate DATETIME,
	deleteDate DATETIME,
	[state] VARCHAR(20) DEFAULT 'Active'
);

CREATE TABLE dbo.tblProductFileManager (
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	idProduct INT,
	idFileManager INT,
	createDate DATETIME DEFAULT GETDATE(),
	upDateDate DATETIME,
	deleteDate DATETIME,
	[state] VARCHAR(20) DEFAULT 'Active'
);

CREATE TABLE dbo.tblLoanAssignmentFileManager (
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	idLoanAssignment INT,
	idFileManager INT,
	createDate DATETIME DEFAULT GETDATE(),
	upDateDate DATETIME,
	deleteDate DATETIME,
	[state] VARCHAR(20) DEFAULT 'Active'
);

----------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------
-- new changes 
----------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE dbo.tblConditionProduct(
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	name VARCHAR(100) NOT NULL,
	detail VARCHAR(255),
	createDate DATETIME DEFAULT GETDATE(),
	upDateDate DATETIME,
	deleteDate DATETIME,
	[state] VARCHAR(20) DEFAULT 'Active'
);

CREATE TABLE dbo.tblTransactionTypeConditionDetail(
	id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	amount INT,
	idTransactionType INT,
	idTransactionAnchor INT,
	idCondition INT,
	createDate DATETIME DEFAULT GETDATE(),
	upDateDate DATETIME,
	deleteDate DATETIME,
	[state] VARCHAR(20) DEFAULT 'Active'
);

ALTER TABLE dbo.tblTransaction ADD idConditionProduct int, expeditionDate date;
ALTER TABLE dbo.tblDownloadAssignment ADD idCategory INT;
ALTER TABLE dbo.tblLoanAssignment ADD idCategory INT;

----------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------