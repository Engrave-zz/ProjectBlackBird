/********************************************************************************
Create WSC_Application server principal, if not exists
********************************************************************************/
USE [master];
GO
SET NOCOUNT ON;
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.server_principals sp WHERE sp.name ='WSC_Application')
    CREATE LOGIN [WSC_Application] WITH PASSWORD=N'WSC_Application', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

/********************************************************************************
Create database
********************************************************************************/
IF EXISTS (SELECT TOP 1 1 FROM sys.databases WHERE name = 'WSC')
BEGIN
    ALTER DATABASE WSC SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [WSC];
END
GO

CREATE DATABASE [WSC]
GO
ALTER DATABASE [WSC] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WSC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WSC] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WSC] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WSC] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WSC] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WSC] SET ARITHABORT OFF 
GO
ALTER DATABASE [WSC] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WSC] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [WSC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WSC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WSC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WSC] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WSC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WSC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WSC] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WSC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WSC] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WSC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WSC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WSC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WSC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WSC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WSC] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WSC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WSC] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WSC] SET  MULTI_USER 
GO
ALTER DATABASE [WSC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WSC] SET DB_CHAINING OFF 
GO
ALTER AUTHORIZATION ON DATABASE::[WSC] TO [sa]
GO
USE [master]
GO
ALTER DATABASE [WSC] SET  READ_WRITE 
GO
USE [WSC]
GO

/********************************************************************************
Create database principal and grant access
********************************************************************************/
CREATE USER [WSC_Application] FOR LOGIN [WSC_Application] WITH DEFAULT_SCHEMA=[dbo]
GO
EXEC sys.sp_addrolemember
	@rolename = 'db_owner',
	@membername = 'WSC_Application';
GO
/********************************************************************************
Create tables
********************************************************************************/

CREATE TABLE tblPersonType
(
    PersonTypeId INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_tblPersonType_personTypeId PRIMARY KEY CLUSTERED (personTypeId),
    personType VARCHAR(100) NOT NULL
);
GO
/*-----------------------------------------------------------------------------*/
CREATE TABLE tblPaymentMethod
(
    paymentMethodId UNIQUEIDENTIFIER CONSTRAINT DF_tblPaymentMethod_paymentMethodId DEFAULT (NEWID()),
    paymentMethod VARCHAR(100) NOT NULL,
    CONSTRAINT PK_tblPaymentMethod_paymentMethodId PRIMARY KEY CLUSTERED (paymentMethodId)
);
GO
/*-----------------------------------------------------------------------------*/
CREATE TABLE tblInvoiceStatus
(
    invoiceStatusId UNIQUEIDENTIFIER CONSTRAINT DF_tblInvoiceStatus_invoiceStatusId DEFAULT (NEWID()),
    invoiceStatus VARCHAR(100) NOT NULL,
    CONSTRAINT PK_tblInvoiceStatus_invoiceStatusId PRIMARY KEY CLUSTERED (invoiceStatusId)
);
GO
/*-----------------------------------------------------------------------------*/
CREATE TABLE tblOrderStatus
(
    orderStatusId INT IDENTITY(1,1) CONSTRAINT PK_tblOrderStatus_orderStatusId PRIMARY KEY CLUSTERED (orderStatusId),
    orderStatus VARCHAR(100) NOT NULL
);
GO
/*-----------------------------------------------------------------------------*/
CREATE TABLE tblInscriptionType
(
    inscriptionTypeId INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_tblInscriptionType_inscriptionTypeId PRIMARY KEY CLUSTERED (inscriptionTypeId),
    inscriptionType VARCHAR(100) NOT NULL
);
GO
/*-----------------------------------------------------------------------------*/
CREATE TABLE tblPerson
(
    personId UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_tblPerson_personId DEFAULT (NEWID()),
    personFirstName VARCHAR(100) NOT NULL,
    personLastName VARCHAR(100) NOT NULL,
    personPhone CHAR(10) NULL,
    personEmail VARCHAR(255) NULL,
    personTypeId INT NOT NULL,
    CONSTRAINT PK_tblPerson_personId PRIMARY KEY CLUSTERED (personId),
	CONSTRAINT FK_tblPersonType_personTypeId FOREIGN KEY (personTypeId) REFERENCES tblPersonType(personTypeId)
);
GO
/*-----------------------------------------------------------------------------*/
CREATE TABLE tblOrder
(
    orderId UNIQUEIDENTIFIER CONSTRAINT DF_tblOrder_orderId DEFAULT (NEWID()),
    orderEntryDate DATETIME NOT NULL CONSTRAINT DF_tblOrder_orderEntryDate DEFAULT (GETDATE()),
    orderFulfillDate DATETIME NULL,
    orderStatusId int NOT NULL,
    personId UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT PK_tblOrder_orderId PRIMARY KEY CLUSTERED (orderId),
    CONSTRAINT FK_tblOrder_orderStatusId FOREIGN KEY (orderStatusId) REFERENCES tblOrderStatus(orderStatusId),
    CONSTRAINT FK_tblOrder_personId FOREIGN KEY (personId) REFERENCES tblPerson(personId)
);
GO
/*-----------------------------------------------------------------------------*/
CREATE TABLE tblInvoice
(
    invoiceId UNIQUEIDENTIFIER CONSTRAINT DF_tblInvoice_invoiceId DEFAULT (NEWID()),
    invoiceTotal MONEY NOT NULL,
    invoiceBalance MONEY NOT NULL,
    orderId UNIQUEIDENTIFIER NOT NULL,
    invoiceStatusId UNIQUEIDENTIFIER NOT NULL,
    --add FK for OrderId
    CONSTRAINT PK_tblInvoice_invoiceId PRIMARY KEY CLUSTERED (invoiceId),
    CONSTRAINT FK_tblInvoice_invoiceStatusId FOREIGN KEY (invoiceStatusId) REFERENCES tblInvoiceStatus(invoiceStatusId),
    CONSTRAINT FK_tblInvoice_orderId FOREIGN KEY (orderId) REFERENCES tblOrder(orderId)
);
GO
/*-----------------------------------------------------------------------------*/
CREATE TABLE tblPaymentVerificationStatus
(
    paymentVerificationStatusId UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_tblPaymentVerificationStatus_paymentVerificationStatusId DEFAULT (NEWID()),
    paymentVerificationStatus VARCHAR(100) NOT NULL,
    CONSTRAINT PK_tblPaymentVerificationStatus_paymentVerificationStatusId PRIMARY KEY CLUSTERED (paymentVerificationStatusId)
);
GO
/*-----------------------------------------------------------------------------*/
CREATE TABLE tblInventoryItemStatus
(
	inventoryItemStatusId INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_tblInventoryItemStatus_inventoryItemStatusId PRIMARY KEY CLUSTERED (inventoryItemStatusId),
	inventoryItemStatus VARCHAR(100) NOT NULL,

);
GO
/*-----------------------------------------------------------------------------*/
CREATE TABLE tblPaymentType
(
    paymentTypeId UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_tblPaymentType_paymentTypeId DEFAULT (NEWID()),
    paymentType VARCHAR(100) NOT NULL,
    CONSTRAINT PK_tblPaymentType_paymentTypeId PRIMARY KEY CLUSTERED (paymentTypeId)
);
GO
/*-----------------------------------------------------------------------------*/
CREATE TABLE tblPayment
(
    paymentId UNIQUEIDENTIFIER CONSTRAINT DF_tblPayment_paymentId DEFAULT (NEWID()),
    payeeId UNIQUEIDENTIFIER NOT NULL,
    paymentDate DATETIME NOT NULL,
    invoiceId UNIQUEIDENTIFIER NOT NULL,
    paymentMethodId UNIQUEIDENTIFIER NOT NULL,
    paymentVerificationStatusId UNIQUEIDENTIFIER NOT NULL,
    paymentTypeId UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT PK_tblPayment_paymentId PRIMARY KEY CLUSTERED (paymentId),
    CONSTRAINT FK_tblPayment_payeeId FOREIGN KEY (payeeId) REFERENCES tblPerson(personId),
    CONSTRAINT FK_tblPayment_paymentMethodId FOREIGN KEY (paymentMethodId) REFERENCES tblPaymentMethod(paymentMethodId),
    CONSTRAINT FK_tblPayment_paymentVerificationStatusId FOREIGN KEY (paymentVerificationStatusId) REFERENCES tblPaymentVerificationStatus(paymentVerificationStatusId),
    CONSTRAINT FK_tblPayment_paymentTypeId FOREIGN KEY (paymentTypeId) REFERENCES tblPaymentType(paymentTypeId)
);
GO
/*-----------------------------------------------------------------------------*/
CREATE TABLE tblUserAccess
(
    userId UNIQUEIDENTIFIER CONSTRAINT DF_tblUserAccess_userId DEFAULT (NEWID()),
    userName VARCHAR(100) NOT NULL,
    userPassword VARCHAR(100) NOT NULL,
	permissionToken INT NOT NULL,
    personId UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_tblUserAccess_personId FOREIGN KEY (personId) REFERENCES tblPerson(personId),
    CONSTRAINT PK_tblUserAccess_userId PRIMARY KEY CLUSTERED (userId)
);
CREATE UNIQUE INDEX UQ_tblUserAccess_userName ON tblUserAccess (userName);
GO
/*-----------------------------------------------------------------------------*/
CREATE TABLE tblCatalogItem
(
    catalogItemId UNIQUEIDENTIFIER CONSTRAINT DF_tblCatalogItem_catalogItemId DEFAULT (NEWID()),
    itemName VARCHAR(100) NOT NULL,
	manufacturer VARCHAR(100) NOT NULL,
	numberInscriptionLines INT NOT NULL,
	numberLineCharacters INT NOT NULL,
	itemCost DECIMAL(5,2) NOT NULL,
	itemRetailPrice DECIMAL(5,2) NOT NULL,
	inscriptionTypeId INT NOT NULL,
	CONSTRAINT PK_tblCatalogItem_catalogItemId PRIMARY KEY CLUSTERED (catalogItemId),
	CONSTRAINT FK_tblCatalogItem_inscriptionTypeId FOREIGN KEY (inscriptionTypeId) REFERENCES tblInscriptionType(inscriptionTypeId)
);
CREATE UNIQUE INDEX UQ_tblCatalogItem_itemName ON tblCatalogItem(itemName)
GO
/*-----------------------------------------------------------------------------*/
CREATE TABLE tblInventoryItem
(
    inventoryItemId UNIQUEIDENTIFIER CONSTRAINT DF_tblInventoryItem_inventoryItemId DEFAULT (NEWID()),
	catalogItemId UNIQUEIDENTIFIER NOT NULL,
	orderId UNIQUEIDENTIFIER NULL,
    inventoryItemStatusId INT NOT NULL,
	CONSTRAINT PK_tblInventoryItem_inventoryItemId PRIMARY KEY CLUSTERED (inventoryItemId),
	CONSTRAINT FK_tblInventoryItem_orderId FOREIGN KEY (orderId) REFERENCES tblOrder(orderId),
	CONSTRAINT FK_tblInventoryItem_catalogItemId FOREIGN KEY (catalogItemId) REFERENCES tblCatalogItem(catalogItemId),
	CONSTRAINT FK_tblCatalogItem_inventoryItemStatusId FOREIGN KEY (inventoryItemStatusId) REFERENCES tblInventoryItemStatus(inventoryItemStatusId)
);
GO
/*-----------------------------------------------------------------------------*/
CREATE TABLE tblNotificationType
(
    notificationTypeId INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_tblNotificationType_notificationTypeId PRIMARY KEY CLUSTERED (notificationTypeId),
    notificationType VARCHAR(100) NOT NULL
);
GO
/*-----------------------------------------------------------------------------*/
CREATE TABLE tblAddressType
(
    addressTypeId INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_tblAddressType_addressTypeId PRIMARY KEY CLUSTERED (addressTypeId),
    addressType VARCHAR(100) NOT NULL
);
GO
/*-----------------------------------------------------------------------------*/
CREATE TABLE tblJobRoleToNotificationType
(
    jobRoleToNotificationTypeId INT IDENTITY(1,1),
    notificationTypeId INT NOT NULL,
    permissionEnum VARCHAR(25) NOT NULL,
    CONSTRAINT PK_tblJobRoleToNotificationType_jobRoleToNotificationTypeId PRIMARY KEY CLUSTERED (jobRoleToNotificationTypeId),
    CONSTRAINT FK_tblJobRoleToNotificationType_notificationTypeId FOREIGN KEY (notificationTypeId) REFERENCES tblNotificationType(notificationTypeId)
);
GO
/*-----------------------------------------------------------------------------*/
CREATE TABLE tblNotification
(
    notificationId UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_tblNotification_notificationId DEFAULT (NEWID()),
    notificationMessage VARCHAR(1000) NOT NULL,
    orderId UNIQUEIDENTIFIER NOT NULL,
    notificationTypeId INT NOT NULL,
    isRead BIT NOT NULL CONSTRAINT DF_tblNotification_isRead DEFAULT (0),
    CONSTRAINT PK_tblNotification_notificationId PRIMARY KEY CLUSTERED (notificationId),
    CONSTRAINT FK_tblNotification_orderId FOREIGN KEY (orderId) REFERENCES tblOrder(orderId),
    CONSTRAINT FK_tblNotification_notificationTypeId FOREIGN KEY (notificationTypeId) REFERENCES tblNotificationType(notificationTypeId)
);
CREATE NONCLUSTERED INDEX IX_tblNotification_isRead ON tblNotification(isRead DESC);
GO
/*-----------------------------------------------------------------------------*/
CREATE TABLE tblCustomer
(
    customerId UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_tblCustomer_customerId DEFAULT (NEWID()),
    personId UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT PK_tblCustomer_customerId PRIMARY KEY CLUSTERED (customerId),
    CONSTRAINT FK_tblCustomer_personId FOREIGN KEY (personId) REFERENCES tblPerson(personId)
);
GO
/*-----------------------------------------------------------------------------*/
CREATE TABLE tblEmployee
(
    employeeId UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_tblEmployee_employeeId DEFAULT (NEWID()),
    personId UNIQUEIDENTIFIER NOT NULL,
    userId UNIQUEIDENTIFIER NULL,
    CONSTRAINT PK_tblEmployee_employeeId PRIMARY KEY CLUSTERED (employeeId),
    CONSTRAINT FK_tblEmployee_personId FOREIGN KEY (personId) REFERENCES tblPerson(personId),
    CONSTRAINT FK_tblEmployee_userId FOREIGN KEY (userId) REFERENCES tblUserAccess(userId)
);
GO
/*-----------------------------------------------------------------------------*/
CREATE TABLE tblAddress
(
    addressId UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_tblAddress_addressId DEFAULT (NEWID()),
	personId UNIQUEIDENTIFIER NOT NULL,
    streetNumber INT NOT NULL,
    streetName VARCHAR(100) NOT NULL,
	addressCity VARCHAR(100) NOT NULL,
	addressState VARCHAR(2) NOT NULL,
	addressZip VARCHAR(5) NOT NULL,
	addressTypeId INT NOT NULL,
    CONSTRAINT PK_tblAddress_addressId PRIMARY KEY CLUSTERED (addressId),
    CONSTRAINT FK_tblAddress_personId FOREIGN KEY (personId) REFERENCES tblPerson(personId),
	CONSTRAINT FK_tblAddress_addressTypeId FOREIGN KEY (addressTypeId) REFERENCES tblAddressType(addressTypeId)
);
GO
/*-----------------------------------------------------------------------------*/
CREATE TABLE tblOrderItem
(
    orderItemId UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_tblOrderItem_orderItemId DEFAULT (NEWID()),
    itemInscription NVARCHAR(1000) NOT NULL,
    catalogItemId UNIQUEIDENTIFIER NOT NULL,
    quantityOrdered SMALLINT NOT NULL CONSTRAINT DF_tblOrderItem_quantityOrdered DEFAULT (0),
    orderId UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT PK_tblOrderItem_addressId PRIMARY KEY CLUSTERED (orderItemId),
    CONSTRAINT FK_tblOrderItem_catalogItemId FOREIGN KEY (catalogItemId) REFERENCES tblCatalogItem(catalogItemId),
    CONSTRAINT FK_tblOrderItem_orderId FOREIGN KEY (orderId) REFERENCES tblOrder(orderId)
);
GO
/*-----------------------------------------------------------------------------*/
/********************************************************************************
Create stored procedures
********************************************************************************/

/***ADDRESS PROCEDURES*****************************************************************************************ADDRESS PROCEDURES***/

CREATE PROCEDURE dbo.spInserttblAddress
(
    @addressId UNIQUEIDENTIFIER,
    @personId UNIQUEIDENTIFIER,
    @streetNumber INT,
    @streetName VARCHAR(100),
    @addressCity VARCHAR(100),
	@addressState VARCHAR(2),
	@addressZip VARCHAR(5),
	@addressTypeId INT

)
AS
BEGIN
    INSERT INTO tblAddress
	   (addressId, personId, streetNumber, streetName, addressCity, addressState, addressZip, addressTypeId)
    VALUES (@addressId, @personId, @streetNumber, @streetName, @addressCity, @addressState, @addressZip, @addressTypeId);
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spGettblAddressByPersonId
(
    @personId UNIQUEIDENTIFIER
)
AS
BEGIN
    SELECT [addressId]
		,[personId]
		,[StreetNumber]
		,[streetName]
		,[addressCity]
		,[addressState]
		,[addressZip]
		,[addressTypeId]
	 FROM [dbo].[tblAddress]
	 WHERE personId = @personId;
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spUpdatetblAddressByAddressId
(
    @addressId UNIQUEIDENTIFIER,
    @personId UNIQUEIDENTIFIER,
    @streetNumber INT,
    @streetName VARCHAR(100),
    @addressCity VARCHAR(100),
	@addressState VARCHAR(2),
	@addressZip VARCHAR(5),
	@addressTypeId INT

)
AS
BEGIN
    UPDATE tblAddress
    SET addressId = @addressId,
	   personId = @personId,
	   streetNumber = @streetNumber,
	   streetName = @streetName,
	   addressCity = @addressCity,
	   addressState = @addressState,
	   addressZip = @addressZip,
	   addressTypeId = @addressTypeId
    WHERE addressId = @AddressId;
END
GO
/*-----------------------------------------------------------------------------*/

/***ORDER ITEM PROCEDURES***********************************************************************************ORDER ITEM PROCEDURES***/

CREATE PROCEDURE dbo.spGettblOrderItemByOrderItemId
(
    @orderItemId UNIQUEIDENTIFIER
)
AS
BEGIN
    SELECT [orderItemId]
		,[itemInscription]
		,[catalogItemId]
		,[quantityOrdered]
		,[orderId]
	 FROM [dbo].[tblOrderItem]
	 WHERE orderItemId = @orderItemId;
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spGettblOrderItemByOrderId
(
    @orderId UNIQUEIDENTIFIER
)
AS
BEGIN
    SELECT [orderItemId]
		,[itemInscription]
		,[catalogItemId]
		,[quantityOrdered]
		,[orderId]
	 FROM [dbo].[tblOrderItem]
	 WHERE orderId = @orderId;
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spInserttblOrderItemId
(
	@orderItemId UNIQUEIDENTIFIER,
	@orderId UNIQUEIDENTIFIER,
	@itemInscription NVARCHAR(1000),
	@catelogItemId UNIQUEIDENTIFIER,
	@quantityOrdered SMALLINT
)
AS
BEGIN
	INSERT INTO tblOrderItem (orderItemId, orderId, itemInscription, catalogItemId, quantityOrdered)
	VALUES (@orderItemId, @orderId, @itemInscription, @catelogItemId, @quantityOrdered)
END
GO
/*-----------------------------------------------------------------------------*/
/***ORDER PROCEDURES*********************************************************************************************ORDER PROCEDURES***/

CREATE PROCEDURE dbo.spInserttblOrder
(
    @orderId UNIQUEIDENTIFIER,
    @orderEntryDate DATETIME,
    @orderFulfillDate DATETIME = NULL,
	@orderStatusId INT,
	@personId UNIQUEIDENTIFIER
)
AS
BEGIN
    INSERT INTO tblOrder (orderId, orderEntryDate, orderFulfillDate, orderStatusId, personId)
    VALUES (@orderId, @orderEntryDate, @orderFulfillDate, @orderStatusId, @personId);
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spGettblOrderByOrderId
(
    @orderId UNIQUEIDENTIFIER
)
AS
BEGIN
    SELECT [orderId]
		,[orderEntryDate]
		,[orderFulfillDate]
		,[orderStatusId]
		,[personId]
	 FROM [dbo].[tblOrder]
	 WHERE [orderId] = @orderId;
END
Go
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spGettblOrderByOrderStatusId
(
    @orderStatusId INT
)
AS
BEGIN
    SELECT [orderId]
		,[orderEntryDate]
		,[orderFulfillDate]
		,[orderStatusId]
		,[personId]
	 FROM [dbo].[tblOrder]
	 WHERE [orderStatusId] = @orderStatusId;
END
Go
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spGettblOrderByInventoryItemId
(
    @inventoryItemId UNIQUEIDENTIFIER
)
AS
BEGIN
    SELECT O.[orderId]
		,O.[orderEntryDate]
		,O.[orderFulfillDate]
		,O.[orderStatusId]
		,O.[personId]
	 FROM tblOrder O
	 INNER JOIN tblInventoryItem II ON II.orderId = O.orderId
	 WHERE [inventoryItemId] = @inventoryItemId;
END
Go
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spGettblOrderByCustomerLastName
(
    @lastName VARCHAR(100)
)
AS
BEGIN
    SELECT O.[orderId]
		,O.[orderEntryDate]
		,O.[orderFulfillDate]
		,O.[orderStatusId]
		,O.[personId]
	 FROM tblOrder O
	 INNER JOIN tblPerson P ON P.personId = O.personId
	 WHERE [personLastName] = @lastName;
END
Go
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spGettblOrders
AS
BEGIN
    SELECT [orderId]
		,[orderEntryDate]
		,[orderFulfillDate]
		,[orderStatusId]
		,[personId]
	 FROM [dbo].[tblOrder]
END
Go
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spUpdatetblOrderByOrderId
(
    @orderId UNIQUEIDENTIFIER,
    @orderEntryDate DATETIME,
    @orderFulfillDate DATETIME = NULL,
    @orderStatusId int,
    @personId UNIQUEIDENTIFIER
)
AS
BEGIN
    UPDATE tblOrder
    SET personId = @personId,
	   orderEntryDate = @orderEntryDate,
	   orderFulfillDate = @orderFulfillDate,
	   orderStatusId = @orderStatusId
    WHERE orderId = @orderId;
END
GO
/*-----------------------------------------------------------------------------*/
/***NOTIFICATION PROCEDURES*******************************************************************************NOTIFICATION PROCEDURES***/

CREATE PROCEDURE dbo.spGettblNotificationsByJobRoleAndIsRead
(
    @permissionEnum VARCHAR(25),
    @isRead BIT = 0
)
AS
BEGIN
    SELECT N.[notificationId], N.[notificationMessage], N.[orderId], N.[notificationTypeId], N.[isRead]
    FROM tblNotification N
    INNER JOIN tblNotificationType NT ON NT.notificationTypeId = N.notificationTypeId
    INNER JOIN tblJobRoleToNotificationType JR ON JR.notificationTypeId = N.notificationTypeId
    WHERE JR.permissionEnum = @permissionEnum
	   AND isRead = @isRead;
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spGettblNotificationsByNotificationId
(
    @notificationId UNIQUEIDENTIFIER
)
AS
BEGIN
    SELECT N.[notificationId], N.[notificationMessage], N.[orderId], N.[notificationTypeId], N.[isRead]
    FROM tblNotification N
    WHERE notificationId = @notificationId;
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spDeletetblNotificationByNotificationId
(
    @notificationId UNIQUEIDENTIFIER
)
AS
BEGIN
    DELETE
    FROM tblNotification
    WHERE notificationId = @notificationId;
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spGettblNotificationsByJobRole
(
    @permissionEnum VARCHAR(25)
)
AS
BEGIN
    SELECT N.[notificationId], N.[notificationMessage], N.[orderId], N.[notificationTypeId], N.[isRead]
    FROM tblNotification N
    INNER JOIN tblNotificationType NT ON NT.notificationTypeId = N.notificationTypeId
    INNER JOIN tblJobRoleToNotificationType JR ON JR.notificationTypeId = N.notificationTypeId
    WHERE JR.permissionEnum = @permissionEnum;
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spUpdatetblNotificationByNotificationId
(
	@notificationId UNIQUEIDENTIFIER,
    @orderId UNIQUEIDENTIFIER,
    @notificationMessage NVARCHAR(1000),
    @notificationTypeId INT,
    @isRead BIT
)
AS
BEGIN
	UPDATE tblNotification
	SET notificationId = @notificationId,
	   orderId = @orderId,
	   notificationMessage = @notificationMessage,
	   notificationTypeId = @notificationTypeId,
	   isRead = @isRead
	WHERE notificationId = @NotificationId;
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spInserttblNotification
(
    @notificationId UNIQUEIDENTIFIER,
    @orderId UNIQUEIDENTIFIER,
    @notificationMessage NVARCHAR(1000),
    @notificationTypeId INT,
    @isRead BIT
)
AS
BEGIN
    INSERT INTO tblNotification
	   (notificationId, orderId, notificationMessage,notificationTypeId,isRead)
    VALUES (@notificationId,@orderId ,@notificationMessage ,@notificationTypeId,@isRead );
END
GO
/*-----------------------------------------------------------------------------*/

/***CATALOG ITEM PROCEDURES*******************************************************************************CATALOG ITEM PROCEDURES***/

CREATE PROCEDURE dbo.spGettblCatalogItemStockCount
(
    @catalogItemId UNIQUEIDENTIFIER
)
AS
BEGIN
    SELECT CAST(COUNT(*) AS INT) as [NumberInStock]
    FROM tblInventoryItem
    WHERE catalogItemId = @catalogItemId
	   AND orderId IS NULL; --NULL orderId equates to not claimed (sold)
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spGettblCatalogItemByItemName
(
    @itemName VARCHAR(100)
)
AS
BEGIN
    SELECT [catalogItemId]
		,[itemName]
		,[manufacturer]
		,[numberInscriptionLines]
		,[numberLineCharacters]
		,[itemCost]
		,[itemRetailPrice]
		,[inscriptionTypeId]
    FROM [dbo].[tblCatalogItem]
    WHERE itemName = @itemName;
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spGettblCatalogItemByCatalogItemId
(
    @catalogItemId VARCHAR(100)
)
AS
BEGIN
    SELECT [catalogItemId]
		,[itemName]
		,[manufacturer]
		,[numberInscriptionLines]
		,[numberLineCharacters]
		,[itemCost]
		,[itemRetailPrice]
		,[inscriptionTypeId]
    FROM [dbo].[tblCatalogItem]
    WHERE catalogItemId = @catalogItemId;
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spGettblCatalogItemByManufacturer
(
    @manufacturer VARCHAR(100)
)
AS
BEGIN
    SELECT [catalogItemId]
		,[itemName]
		,[manufacturer]
		,[numberInscriptionLines]
		,[numberLineCharacters]
		,[itemCost]
		,[itemRetailPrice]
		,[inscriptionTypeId]
    FROM [dbo].[tblCatalogItem]
    WHERE manufacturer = @manufacturer;
END
GO
/*-----------------------------------------------------------------------------*/
/***CUSTOMER PROCEDURES***************************************************************************************CUSTOMER PROCEDURES***/

CREATE PROCEDURE dbo.spGettblCustomerByPersonLastName
(
    @personLastName VARCHAR(100)
)
AS
BEGIN
    SELECT C.[customerId], 
		C.[personId]
    FROM tblCustomer C
    INNER JOIN tblPerson P ON P.personId = C.personId
    WHERE P.personLastName = @personLastName;
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spGettblCustomerByPersonFirstName
(
    @personFirstName VARCHAR(100)
)
AS
BEGIN
    SELECT C.[customerId], 
		C.[personId]
    FROM tblCustomer C
    INNER JOIN tblPerson P ON P.personId = C.personId
    WHERE P.personFirstName = @personFirstName;
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spGettblCustomerByPersonPhone
(
    @personPhone VARCHAR(11)
)
AS
BEGIN
    SELECT C.[customerId], 
		P.[personId]
    FROM tblCustomer C
    INNER JOIN tblPerson P ON P.personId = C.personId
    WHERE P.personPhone = @personPhone;
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spGettblCustomerByCustomerId
(
    @customerId UNIQUEIDENTIFIER
)
AS
BEGIN
    SELECT C.[customerId], 
		C.[personId]
    FROM tblCustomer C
    WHERE C.customerId = @customerId;
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spGettblCustomerByPersonId
(
    @personId UNIQUEIDENTIFIER
)
AS
BEGIN
    SELECT C.[customerId], 
		C.[personId]
    FROM tblCustomer C
    WHERE C.personId = @personId;
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spGettblCustomerByPersonEmail
(
    @personEmail VARCHAR(255)
)
AS
BEGIN
    SELECT C.[customerId], 
		C.[personId]
    FROM tblCustomer C
    INNER JOIN tblPerson P ON P.personId = C.personId
    WHERE P.personEmail = @personEmail;
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spInserttblCustomer
(
    @customerId UNIQUEIDENTIFIER,
    @personId UNIQUEIDENTIFIER    
)
AS
BEGIN
    INSERT INTO tblCustomer
	   (customerId, personId)
    VALUES (@customerId, @personId);
END
GO
/*-----------------------------------------------------------------------------*/
/***PERSON PROCEDURES*******************************************************************************************PERSON PROCEDURES***/

CREATE PROCEDURE dbo.spGettblPersonByUserId
(
    @userId UNIQUEIDENTIFIER
)
AS
BEGIN
    SELECT P.personId, personFirstName, personLastName, personPhone,
	   personEmail, personTypeId
    FROM tblPerson P
    INNER JOIN tblUserAccess UA ON UA.personId = P.personId
    WHERE UA.userId = @userId;
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spGettblPersonByPersonId
(
    @personId UNIQUEIDENTIFIER
)
AS
BEGIN
    SELECT personId, personFirstName, personLastName, personPhone,
	   personEmail, personTypeId
    FROM tblPerson
    WHERE personId = @personId;
	END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spUpdatetblPersonByPersonId
(
    @personId UNIQUEIDENTIFIER,
    @personFirstName VARCHAR(100),
    @personLastName VARCHAR(100),
    @personPhone CHAR(10),
    @personEmail VARCHAR(255),
    @personTypeId INT
)
AS
BEGIN
    UPDATE tblPerson
    SET personFirstName = @personFirstName,
	   personLastName = @personLastName,
	   personPhone = @personPhone,
	   personEmail = @personEmail,
	   personTypeId = @personTypeId
    WHERE personId = @personId;
END
GO
/*-----------------------------------------------------------------------------*/

CREATE PROCEDURE dbo.spInserttblPerson
(
    @personId UNIQUEIDENTIFIER,
    @personFirstName VARCHAR(100),
    @personLastName VARCHAR(100),
    @personPhone CHAR(10),
    @personEmail VARCHAR(255),
    @personTypeID INT
)
AS
BEGIN
    INSERT INTO tblPerson
	   (personId, personFirstName, personLastName, personPhone,
	   personEmail, personTypeID)
    VALUES (@personId,@personFirstName ,@personLastName ,@personPhone
		  ,@personEmail,@personTypeID );
END
GO
/*-----------------------------------------------------------------------------*/

/***USER ACCESSS PROCEDURES********************************************************************************USER ACCESS PROCEDURES***/

CREATE PROCEDURE dbo.spDeletetblUserAccessByUsername
(
    @username VARCHAR(100)
)
AS
BEGIN
    DELETE
    FROM tblUserAccess
    WHERE userName = @username;
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spUpdatetblUserAccessByUserId
(
    @userId UNIQUEIDENTIFIER,
    @userName VARCHAR(100),
    @userPassword VARCHAR(100),
	@permissionToken INT,
    @personId UNIQUEIDENTIFIER
)
AS
BEGIN
    UPDATE tblUserAccess
    SET userName = @userName,
	   userPassword = @userPassword,
	   permissionToken = @permissionToken,
	   personId = @personId
    WHERE userId = @userId;
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spInserttblUserAccess
(
    @userId UNIQUEIDENTIFIER,
    @userName VARCHAR(100),
    @userPassword VARCHAR(100),
	@permissionToken INT,
    @personId UNIQUEIDENTIFIER
)
AS
BEGIN
    INSERT INTO tblUserAccess (userId, userName, userPassword, permissionToken, personId)
    VALUES (@userId, @userName, @userPassword, @permissionToken, @personId);
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spGettblUserAccessByUserName
(
    @userName VARCHAR(100)
)
AS
BEGIN
    SELECT userId, userName, userPassword, permissionToken, personId
    FROM tblUserAccess
    WHERE userName = @userName;
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spGettblUserAccess
AS
BEGIN
    SELECT userId, userName, userPassword, permissionToken, personId
    FROM tblUserAccess;
END
GO
/*-----------------------------------------------------------------------------*/

/***INVENTORY ITEM PROCEDURES***************************************************************************INVENTORY ITEM PROCEDURES***/

CREATE PROCEDURE dbo.spDeletetblInventoryItemByInventoryItemId
(
    @inventoryItemId UNIQUEIDENTIFIER
)
AS
BEGIN
    DELETE
    FROM tblInventoryItem
    WHERE inventoryItemId = @inventoryItemId;
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spUpdatetblInventoryItemByInventoryItemId
(
	@inventoryItemId UNIQUEIDENTIFIER,
	@catalogItemId UNIQUEIDENTIFIER,
	@orderId UNIQUEIDENTIFIER = NULL,
	@inventoryItemStatusId INT
)
AS
BEGIN
	UPDATE tblInventoryItem
	SET catalogItemId = @catalogItemId,
	   orderId = @orderId,
	   inventoryItemStatusId = @inventoryItemStatusId
	WHERE inventoryItemId = @inventoryItemId;
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spInserttblInventoryItem
(
    @inventoryItemId UNIQUEIDENTIFIER,
    @catalogItemId UNIQUEIDENTIFIER,
    @orderId UNIQUEIDENTIFIER,
	@inventoryItemStatusId INT
)
AS
BEGIN
    INSERT INTO tblInventoryItem (inventoryItemId, catalogItemId, orderId, inventoryItemStatusId)
    VALUES (@inventoryItemId, @catalogItemId, @orderId, @inventoryItemStatusId);
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spGettblInventoryItemByInventoryItemIdAndInventoryItemStatusId
(
    @inventoryItemId UNIQUEIDENTIFIER,
	@inventoryItemStatusId INT
)
AS
BEGIN
    SELECT inventoryItemId, orderId, catalogItemId, inventoryItemStatusId
    FROM tblInventoryItem
    WHERE inventoryItemId = @inventoryItemId AND inventoryItemStatusId = @inventoryItemStatusId;
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spGettblInventoryItemByInventoryItemId
(
    @inventoryItemId UNIQUEIDENTIFIER
)
AS
BEGIN
    SELECT inventoryItemId, orderId, catalogItemId, inventoryItemStatusId
    FROM tblInventoryItem
    WHERE inventoryItemId = @inventoryItemId
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spGettblInventoryItemByItemName
(
    @itemName VARCHAR(100),
	@inventoryItemStatusId INT
)
AS
BEGIN
    SELECT inv.inventoryItemId, inv.orderId, inv.catalogItemId, inv.inventoryItemStatusId
    FROM tblInventoryItem inv
    INNER JOIN tblCatalogItem cat ON cat.catalogItemId = inv.catalogItemId
    WHERE cat.itemName = @itemName AND inv.inventoryItemStatusId = @inventoryItemStatusId;
END
GO
/*-----------------------------------------------------------------------------*/

CREATE PROCEDURE dbo.spGettblInventoryItemByCatalogItemId
(
    @catalogItemId UNIQUEIDENTIFIER
)
AS
BEGIN
    SELECT inv.inventoryItemId, inv.orderId, inv.catalogItemId, inv.inventoryItemStatusId
    FROM tblInventoryItem inv
    WHERE inv.catalogItemId = @catalogItemId
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spGettblInventoryItemByCatalogItemIdAndInventoryItemStatusId
(
    @catalogItemId UNIQUEIDENTIFIER,
	@inventoryItemStatusId INT
)
AS
BEGIN
    SELECT inv.inventoryItemId, inv.orderId, inv.catalogItemId, inv.inventoryItemStatusId
    FROM tblInventoryItem inv
    WHERE inv.catalogItemId = @catalogItemId AND inventoryItemStatusId = @inventoryItemStatusId;
END
GO
/*-----------------------------------------------------------------------------*/
CREATE PROCEDURE dbo.spGettblInventoryItemByManufacturer
(
    @manufacturer VARCHAR(100),
	@inventoryItemStatusId INT
)
AS
BEGIN
    SELECT inv.inventoryItemId, inv.orderId, inv.catalogItemId, inv.inventoryItemStatusId
    FROM tblInventoryItem inv
    INNER JOIN tblCatalogItem cat ON cat.catalogItemId = inv.catalogItemId
    WHERE cat.manufacturer = @manufacturer AND inv.inventoryItemStatusId = @inventoryItemStatusId;
END
GO
/*-----------------------------------------------------------------------------*/









/********************************************************************************
Load test data
********************************************************************************/


/***LOOK-UP TABLE INSERTS***************************************************************************LOOK-UP TABLE INSERTS***/

SET IDENTITY_INSERT tblAddressType ON
MERGE tblAddressType AS [target]
USING   (
		  SELECT 0, 'Mailing'
		  UNION ALL
		  SELECT 1, 'Billing'
	   ) AS [source] ([addressTypeId], [addressType])
ON ([target].addressTypeId = [source].[addressTypeId])
WHEN MATCHED
    THEN UPDATE SET [target].[addressType] = [source].[addressType]
WHEN NOT MATCHED BY TARGET
    THEN INSERT (addressTypeId, [addressType])
		  VALUES ([source].[addressTypeId], [source].[addressType])
WHEN NOT MATCHED BY SOURCE
    THEN DELETE;
SET IDENTITY_INSERT tblAddressType OFF
GO

SET IDENTITY_INSERT tblPersonType ON
MERGE tblPersonType AS [target]
USING   (
		  SELECT 0, 'Employee'
		  UNION ALL
		  SELECT 1, 'Customer'
		  UNION ALL
		  SELECT 2, 'OperationsManager'
		  UNION ALL
		  SELECT 3, 'SalesPerson'
		  UNION ALL
		  SELECT 4, 'WorkSpecialist'
		  UNION ALL
		  SELECT 5, 'StockClerk'
	   ) AS [source] ([personTypeId], [personType])
ON ([target].personTypeId = [source].[personTypeId])
WHEN MATCHED
    THEN UPDATE SET [target].[personType] = [source].[personType]
WHEN NOT MATCHED BY TARGET
    THEN INSERT (personTypeId, [personType])
		  VALUES ([source].[personTypeId], [source].[personType])
WHEN NOT MATCHED BY SOURCE
    THEN DELETE;
SET IDENTITY_INSERT tblPersonType OFF
GO

SET IDENTITY_INSERT tblInscriptionType ON
MERGE tblInscriptionType AS [target]
USING   (
		  SELECT 1, 'Printable'
		  UNION ALL
		  SELECT 2, 'Engraveable'
	   ) AS [source] ([inscriptionTypeId], [inscriptionType])
ON ([target].inscriptionTypeId = [source].[inscriptionTypeId])
WHEN MATCHED
    THEN UPDATE SET [target].[inscriptionType] = [source].[inscriptionType]
WHEN NOT MATCHED BY TARGET
    THEN INSERT (inscriptionTypeId, [inscriptionType])
		  VALUES ([source].[inscriptionTypeId], [source].[inscriptionType])
WHEN NOT MATCHED BY SOURCE
    THEN DELETE;
SET IDENTITY_INSERT tblInscriptionType OFF
GO

SET IDENTITY_INSERT tblInventoryItemStatus ON
MERGE tblInventoryItemStatus AS [target]
USING   (
		  SELECT 0, 'Stock'
		  UNION ALL
		  SELECT 1, 'Sold'
		  UNION ALL
		  SELECT 2, 'Delivered'
	   ) AS [source] ([inventoryItemStatusId], [inventoryItemStatus])
ON ([target].inventoryItemStatusId = [source].[inventoryItemStatusId])
WHEN MATCHED
    THEN UPDATE SET [target].[inventoryItemStatus] = [source].[inventoryItemStatus]
WHEN NOT MATCHED BY TARGET
    THEN INSERT (inventoryItemStatusId, [inventoryItemStatus])
		  VALUES ([source].[inventoryItemStatusId], [source].[inventoryItemStatus])
WHEN NOT MATCHED BY SOURCE
    THEN DELETE;
SET IDENTITY_INSERT tblInventoryItemStatus OFF
GO

SET IDENTITY_INSERT tblOrderStatus ON
MERGE tblOrderStatus AS [target]
USING   (
		  SELECT 1, 'Submitted'
		  UNION ALL
		  SELECT 2, 'Failed Validation'
		  UNION ALL
		  SELECT 3, 'Work Complete'
		  UNION ALL
		  SELECT 4, 'Delivered'
		  UNION ALL
		  SELECT 5, 'En Route'
		  UNION ALL
		  SELECT 6, 'Complete'
	   ) AS [source] (orderStatusId, orderStatus)
ON ([target].orderStatusId = [source].orderStatusId)
WHEN MATCHED
    THEN UPDATE SET [target].orderStatus = [source].orderStatus
WHEN NOT MATCHED BY TARGET
    THEN INSERT (orderStatusId, orderStatus)
		  VALUES ([source].orderStatusId, [source].orderStatus)
WHEN NOT MATCHED BY SOURCE
    THEN DELETE;
SET IDENTITY_INSERT tblOrderStatus OFF
GO

SET IDENTITY_INSERT tblNotificationType ON
MERGE tblNotificationType AS [target]
USING   (
		  SELECT 1, 'New Sale'
		  UNION ALL
		  SELECT 2, 'Invalid Payment'
		  UNION ALL
		  SELECT 3, 'Media Pull'
		  UNION ALL
		  SELECT 4, 'Restock Item'
		  UNION ALL
		  SELECT 5, 'Expected Delivery'
		  UNION ALL
		  SELECT 6, 'Media Sent'
		  UNION ALL
		  SELECT 7, 'Inscription Complete'
		  UNION ALL
		  SELECT 8, 'Failed Quality Control'
		  UNION ALL
		  SELECT 9, 'Work Complete'
		  UNION ALL
		  SELECT 10, 'En Route'
		  UNION ALL
		  SELECT 11, 'Delivered'
		  UNION ALL
		  SELECT 12, 'Order Complete'
	   ) AS [source] ([notificationTypeId], [notificationType])
ON ([target].[notificationTypeId] = [source].[notificationTypeId])
WHEN MATCHED
    THEN UPDATE SET [target].[notificationType] = [source].[notificationType]
WHEN NOT MATCHED BY TARGET
    THEN INSERT ([notificationTypeId], [notificationType])
		  VALUES ([source].[notificationTypeId], [source].[notificationType])
WHEN NOT MATCHED BY SOURCE
    THEN DELETE;
SET IDENTITY_INSERT tblNotificationType OFF
GO

SET IDENTITY_INSERT [dbo].[tblJobRoleToNotificationType] ON
MERGE [tblJobRoleToNotificationType] AS [target]
USING   (
		  SELECT 1, 1, 'OperationsManager'
		  UNION ALL
		  SELECT 2, 2, 'SalesPerson'
		  UNION ALL
		  SELECT 3, 3, 'StockClerk'
		  UNION ALL
		  SELECT 4, 4, 'StockClerk'
		  UNION ALL
		  SELECT 5, 5, 'SalesPerson'
		  UNION ALL
		  SELECT 6, 6, 'WorkSpecialist'
		  UNION ALL
		  SELECT 7, 7, 'SalesPerson'
		  UNION ALL
		  SELECT 8, 8, 'OperationsManager'
		  UNION ALL
		  SELECT 9, 9, 'OperationsManager'
		  UNION ALL
		  SELECT 10, 10, 'WorkSpecialist'
		  UNION ALL
		  SELECT 11, 11, 'OperationsManager'
		  UNION ALL
		  SELECT 12, 12, 'SalesPerson'
		  UNION ALL
		  SELECT 13, 12, 'OperationsManager'
		  UNION ALL
		  SELECT 14, 1, 'WorkSpecialist'
	   ) AS [source] ([jobRoleToNotificationTypeId], [notificationTypeId], [permissionEnum])
ON ([target].[jobRoleToNotificationTypeId] = [source].[jobRoleToNotificationTypeId])
WHEN MATCHED
    THEN UPDATE SET [target].[notificationTypeId] = [source].[notificationTypeId],
				[target].[permissionEnum] = [source].[permissionEnum]
WHEN NOT MATCHED BY TARGET
    THEN INSERT ([jobRoleToNotificationTypeId], [notificationTypeId], [permissionEnum])
		  VALUES ([source].[jobRoleToNotificationTypeId], [source].[notificationTypeId], [source].[permissionEnum])
WHEN NOT MATCHED BY SOURCE
    THEN DELETE;
SET IDENTITY_INSERT [dbo].[tblJobRoleToNotificationType] OFF
GO


/***EMPLOYEE/USER/CUSTOMER INSERTS***************************************************************************EMPLOYEE/USER INSERTS***/

INSERT INTO tblPerson (personId, personFirstName, personLastName, personPhone, personEmail, personTypeId)
VALUES ('7EC7732B-39F8-4CEA-9B86-D0D59F68E7C1', 'Kelly', 'Reyes', '2036230492', 'kreyes134gmail.com', 2)

INSERT INTO tblUserAccess (userId, userName, userPassword, personId, permissionToken)
VALUES ('C52CBB68-DD5C-40E5-9709-AC8DB98E1A9F', 'kreyes', 'CDFD439E6FBD42EC06B7F507DC2FAB58', '7EC7732B-39F8-4CEA-9B86-D0D59F68E7C1', 30)


INSERT INTO tblPerson (personId, personFirstName, personLastName, personPhone, personEmail, personTypeId)
VALUES ('3C3FAC41-3E87-4329-8387-B223C0BDD727', 'Adam', 'Fike', '7701234567', 'ecliptic007@yahoo.com', 2);

INSERT INTO tblUserAccess (userId, userName, userPassword, personId, permissionToken)
VALUES('C42DFFD7-3816-4678-A8B4-FCA1953D51BA', 'afike', 'CC03E747A6AFBBCBF8BE7668ACFEBEE5', '3C3FAC41-3E87-4329-8387-B223C0BDD727', 30);


INSERT INTO tblPerson (personId, personFirstName, personLastName, personPhone, personEmail, personTypeId)
VALUES ('275DDB2C-9217-4CD5-98DB-A814207608F3', 'Jeremy', 'Keat', '7701113333', 'jer_kmail@yahoo.com', 3);

INSERT INTO tblUserAccess (userId, userName, userPassword, personId, permissionToken)
VALUES('1DEE4F43-86DF-4837-BCBD-CA3E5C647942', 'jkeat', 'CC03E747A6AFBBCBF8BE7668ACFEBEE5', '275DDB2C-9217-4CD5-98DB-A814207608F3', 8);

INSERT INTO tblPerson (personId, personFirstName, personLastName, personPhone, personEmail, personTypeId)
VALUES ('3376F9E9-5C93-4402-9D31-B1761C1C9463', 'Dy', 'Waer', '7701112222', 'aczeheart@gmail.com', 4);

INSERT INTO tblUserAccess (userId, userName, userPassword, personId, permissionToken)
VALUES('1CF7FC9E-BD4F-425F-B290-13AC65161C86', 'dwaer', 'CC03E747A6AFBBCBF8BE7668ACFEBEE5', '3376F9E9-5C93-4402-9D31-B1761C1C9463', 4);


INSERT INTO tblPerson (personId, personFirstName, personLastName, personPhone, personEmail, personTypeId)
VALUES ('DE0CB7AA-6AA0-4263-BBD4-6AC966684D86', 'Sal', 'Rio', '8871112268', 'sRios3@gmail.com', 5);

INSERT INTO tblUserAccess (userId, userName, userPassword, personId, permissionToken)
VALUES('740BE8D7-E7D9-415E-8576-9684ED12A86A', 'srio', 'CC03E747A6AFBBCBF8BE7668ACFEBEE5', 'DE0CB7AA-6AA0-4263-BBD4-6AC966684D86', 2);


INSERT INTO tblPerson (personId, personFirstName, personLastName, personPhone, personEmail, personTypeId)
VALUES ('27A921BB-F01D-4DCC-B3CE-38457A8BF4BA', 'Jane', 'Smith', '6789985746', 'Jane.Smith@gmail.com', 1);

INSERT INTO tblCustomer (customerId, personId)
VALUES ('2DB403C3-1EC6-426B-B0BB-6EE0C115F52B', '27A921BB-F01D-4DCC-B3CE-38457A8BF4BA')


INSERT INTO tblPerson (personId, personFirstName, personLastName, personPhone, personEmail, personTypeId)
VALUES ('8CF55860-2D3C-473C-B251-B8173863964F', 'Raegan', 'Taylor', '4048875478', 'raegan.taylor@gmail.com', 1);

INSERT INTO tblCustomer (customerId, personId)
VALUES ('F98C0068-4205-4EC2-9C31-47714BF5E174', '8CF55860-2D3C-473C-B251-B8173863964F');


INSERT INTO tblPerson (personId, personFirstName, personLastName, personPhone, personEmail, personTypeId)
VALUES ('09FB881C-A515-4EA4-AD5D-299E2211055F', 'Mickey', 'Mouse', '7705446328', 'MMouse@gmail.com', 1);

INSERT INTO tblCustomer (customerId, personId)
VALUES ('02293FC9-AD10-489C-AD93-C08AB90F4038', '09FB881C-A515-4EA4-AD5D-299E2211055F');

GO


/***ADDRESS INSERTS*************************************************************************************ADDRESS INSERTS***/
INSERT INTO tblAddress(addressId, personId, streetNumber, streetName, addressCity, addressState,
						addressZip, addressTypeId)
VALUES('0B4228D1-907F-4121-98B9-327AC1DE5FC1', '27A921BB-F01D-4DCC-B3CE-38457A8BF4BA', '7465', 'Jonestown Ave', 'Lilburn', 'GA', '30047', 0),
('23BB434B-4741-47EC-8B33-1917189C43C6', '27A921BB-F01D-4DCC-B3CE-38457A8BF4BA', '9785', 'Smithtown Ave', 'Lilburn', 'GA', '30047', 1),
('B50E711B-F03F-4B2D-90FF-64F881F8511B', '8CF55860-2D3C-473C-B251-B8173863964F', '1122', 'Creek Wood Dr', 'Lilburn', 'GA', '30047', 0),
('A648F6F8-F5AF-4A99-BCBC-DB78F816297C', '8CF55860-2D3C-473C-B251-B8173863964F', '1122', 'Creek Wood Dr', 'Lilburn', 'GA', '30047', 1),
('DA59F986-0D8D-40B8-B2F4-7A31D1C0586B', '09FB881C-A515-4EA4-AD5D-299E2211055F', '85496', 'Wesley Oak Place', 'Duluth', 'GA', '30096', 0),
('0E84881B-A6F7-4F46-A80B-0AE1F84CFFAB', '09FB881C-A515-4EA4-AD5D-299E2211055F', '1525', 'Station Center Blvd', 'Suwanee', 'GA', '30024', 1);


GO


/***CATALOG ITEM INSERTS***************************************************************************CATALOG ITEM INSERTS***/

INSERT INTO [dbo].[tblCatalogItem]
           ([catalogItemId]
           ,[itemName]
           ,[manufacturer]
           ,[numberInscriptionLines]
           ,[numberLineCharacters]
           ,[itemCost]
           ,[itemRetailPrice]
           ,[inscriptionTypeId])
VALUES( '68247790-E78D-4AB4-8507-BD5E9E09F1BA' , 
        'Large Gold Plaque' , 
        'Plaques R Us' , 
        5 , 
        25 , 
        29.99 , 
        9.99 , 
        2
      ),
	  ( '43D31E60-C445-43C0-B5A5-047FCEAAB7AA' , 
        'Small Gold Plaque' , 
        'Plaques R Us' , 
        3 , 
        25 , 
        23.99 , 
        7.99 , 
        2
      ),
	  ( '147D76CD-BFA0-4A90-AB5D-A71A93D39ED6' , 
        'Large Silver Plaque' , 
        'Plaques R Us' , 
        5 , 
        25 , 
        29.99 , 
        9.99 , 
        2
      ),
	  ( '73985425-DB6A-4F4A-A07D-5151391CD189' , 
        'Small Silver Plaque' , 
        'Plaques R Us' , 
        3 , 
        25 , 
        23.99 , 
        7.99 , 
        2
      ),
    ( '1E209A7C-C7F5-4954-A2E5-F31797313DDA' , 
        'Baseball Hat' , 
        'Hats R Us' , 
        1 , 
        15 , 
        19.99 , 
        5.99 , 
        1
      ),
	  ( '2CECCA45-868F-4F35-B750-94199F1F686D' , 
        'Top Hat' , 
        'Hats R Us' , 
        1 , 
        15 , 
        24.99 , 
        8.99 , 
        1
      ),
	  ( '3405FDD0-3D97-465B-802F-23C416523C4D' , 
        'Visor' , 
        'Hats R Us' , 
        1 , 
        10 , 
        17.99 , 
        4.99 , 
        1
      );


/***ORDER INSERTS*****************************************************************************************ORDER INSERTS***/

INSERT INTO [dbo].[tblOrder]
           ([orderId]
           ,[orderEntryDate]
           ,[orderFulfillDate]
           ,[orderStatusId]
           ,[personId])
     VALUES
         ('7F70F68B-E942-4D20-AC40-E017B0CF4892'      /*2 items*/
           ,DATEADD(dd,-1,GETDATE())
           ,NULL
           ,2
           ,'7EC7732B-39F8-4CEA-9B86-D0D59F68E7C1'),
		 ('1093B637-FC99-4323-A8C6-B32862A5C551'      /*1 item*/
           ,DATEADD(dd,-1,GETDATE())
           ,NULL
           ,1
           ,'8CF55860-2D3C-473C-B251-B8173863964F'),
		 ('0881970E-53B1-4843-9DB3-B382C436F983'      /*3 items*/
           ,DATEADD(dd,-1,GETDATE())
           ,NULL
           ,1
           ,'27A921BB-F01D-4DCC-B3CE-38457A8BF4BA'),
		 ('39D740F9-4FD0-4654-BF40-0DE4CD657360'      /*1 items*/
           ,DATEADD(dd,-1,GETDATE())
           ,NULL
           ,1
           ,'09FB881C-A515-4EA4-AD5D-299E2211055F')
;

GO


/***INVENTORY ITEM INSERTS***********************************************************************INVENTORY ITEM INSERTS***/

INSERT INTO tblInventoryItem( inventoryItemId , 
                              catalogItemId , 
                              orderId ,
							  inventoryItemStatusId
                            )
      /**************Baseball Hats*************/
VALUES( 'A5F3DC71-3619-4C11-BAD5-6159B106F991' , 
        '1E209A7C-C7F5-4954-A2E5-F31797313DDA' , 
        NULL ,
		0
      ) ,
	  ( '526308AB-9AC8-4B29-825D-F5DFAAF4E9B2' , 
        '1E209A7C-C7F5-4954-A2E5-F31797313DDA' , 
        '7F70F68B-E942-4D20-AC40-E017B0CF4892' ,
		1
      ),
	  ( 'A5F3DC71-3619-4C11-BAD5-1159B106F992' , 
        '1E209A7C-C7F5-4954-A2E5-F31797313DDA' , 
        '1093B637-FC99-4323-A8C6-B32862A5C551' ,
		0
      ) ,
	  ( 'A5F2DC71-3619-4C11-BAD5-1159B106F993' , 
        '1E209A7C-C7F5-4954-A2E5-F31797313DDA' , 
        NULL ,
		0
      ) ,
	  ( 'A5F2DC71-3619-9C11-BAD5-1159B106F994' , 
        '1E209A7C-C7F5-4954-A2E5-F31797313DDA' , 
        NULL ,
		0
      ) , 
	  /*****************Visors*****************/
	  ( 'C2B802E2-6F54-41A3-9AD4-A8D668A4E17F' , 
        '3405FDD0-3D97-465B-802F-23C416523C4D' , 
        '7F70F68B-E942-4D20-AC40-E017B0CF4892' ,
		1
      ),
	  ( '7FD4DE44-8849-46FD-848C-FFE4B19C35B2', 
        '3405FDD0-3D97-465B-802F-23C416523C4D' , 
        '0881970E-53B1-4843-9DB3-B382C436F983' ,
		0
      ),
	  ( '0B9003CB-6473-48CD-95E6-88D4471ACBB7' , 
        '3405FDD0-3D97-465B-802F-23C416523C4D' , 
        Null ,
		0
      ),
	  ( 'D5E052F8-CE05-4B61-A58C-65327E3128E2' , 
        '3405FDD0-3D97-465B-802F-23C416523C4D' , 
        Null ,
		0
      ),
	  ( 'E463C629-53AD-41BC-9D3F-31C7D44835B3' , 
        '3405FDD0-3D97-465B-802F-23C416523C4D' , 
        Null ,
		0
      ),
	  ( '63B2B037-10F4-4E86-BA12-2C6DFC7C58B9' , 
        '3405FDD0-3D97-465B-802F-23C416523C4D' , 
        Null ,
		0
      ),
	  /****************Top Hats****************/
	  ( '7AD0A5A5-41D9-4EDC-A636-07CBDC99C0AE' , 
        '2CECCA45-868F-4F35-B750-94199F1F686D' , 
        Null ,
		0
      ),
	  ( 'FC6AD41C-03ED-493C-A1B5-258ADA1951D8' , 
        '2CECCA45-868F-4F35-B750-94199F1F686D' , 
        Null ,
		0
      ),
	  ( 'CE0D1E96-E45A-4529-9F27-7591E5174BFC' , 
        '2CECCA45-868F-4F35-B750-94199F1F686D' , 
        Null ,
		0
      ),
	  ( 'E61380A2-EC27-4076-ACE5-861820204714' , 
        '2CECCA45-868F-4F35-B750-94199F1F686D' , 
        Null ,
		0
      ),
	  ( '736E3082-5FE9-44EB-B364-D36FB7015097' , 
        '2CECCA45-868F-4F35-B750-94199F1F686D' , 
        Null ,
		0
      ),
	  /***********Large Gold Palques***********/
	  ( '4B6D8E72-CD3F-4A81-B6F8-3046335AAD80' , 
        '68247790-E78D-4AB4-8507-BD5E9E09F1BA' , 
        Null ,
		0
      ),
	  ( 'A5F3DC71-3619-4C11-BAD5-6159B106F996' , 
        '68247790-E78D-4AB4-8507-BD5E9E09F1BA' , 
        NULL ,
		0
      ) ,
	  ( 'CCBEE338-0B2D-4FEF-B9DF-5B639AC03A91' , 
        '68247790-E78D-4AB4-8507-BD5E9E09F1BA' , 
        '0881970E-53B1-4843-9DB3-B382C436F983' ,
		0
      ),
	  ( '6C607716-A3A1-40B4-A452-66C927A4810C' , 
        '68247790-E78D-4AB4-8507-BD5E9E09F1BA' , 
        Null ,
		0
      ),
	  ( '715A7A8D-DD4D-4064-9CD9-7A16CD8ADBB3' , 
        '68247790-E78D-4AB4-8507-BD5E9E09F1BA' , 
        Null ,
		0
      ),
	  ( '9FA7A043-786D-4CD6-892A-D2EAF67759D4' , 
        '68247790-E78D-4AB4-8507-BD5E9E09F1BA' , 
        Null ,
		0
      ),
	  /**********Small Silver Palques**********/
	  ( '363816B5-E875-4947-AFA1-2B7E54E10E5A' , 
        '73985425-DB6A-4F4A-A07D-5151391CD189' , 
        '39D740F9-4FD0-4654-BF40-0DE4CD657360' ,
		0
      ),
	  ( 'CE120BE2-FBE5-40D6-B452-63B015A21882' , 
        '73985425-DB6A-4F4A-A07D-5151391CD189' , 
        Null ,
		0
      ),
	  ( '9C471250-10DB-4B9E-BD00-7C66C8280E1E' , 
        '73985425-DB6A-4F4A-A07D-5151391CD189' , 
        Null ,
		0
      ),
	  ( '82C2D0AE-57DB-4ED9-B78A-D1547B9F6B68' , 
        '73985425-DB6A-4F4A-A07D-5151391CD189' , 
        Null ,
		0
      );

 GO


/***ORDER ITEM INSERTS*******************************************************************************ORDER ITEM INSERTS***/

INSERT INTO [dbo].[tblOrderItem]
           ([orderItemId]
           ,[itemInscription]
           ,[catalogItemId]
           ,[quantityOrdered]
           ,[orderId])
     VALUES
         ('4FD3EC3E-607B-45ED-ACA8-5C437D154EB7'
           ,'I Love Hamburgers'
           ,'3405FDD0-3D97-465B-802F-23C416523C4D'
           ,2
           ,'7F70F68B-E942-4D20-AC40-E017B0CF4892'),
		 ('18A1B9CF-6974-4DEC-8E88-01380051385E'
           ,'made up inscription 2'
           ,'1E209A7C-C7F5-4954-A2E5-F31797313DDA'
           ,2
           ,'7F70F68B-E942-4D20-AC40-E017B0CF4892'),
		 ('42363210-881D-4C10-AA70-988B32B217F0'
           ,'John Doe is the best!'
           ,'43D31E60-C445-43C0-B5A5-047FCEAAB7AA'
           ,2
           ,'0881970E-53B1-4843-9DB3-B382C436F983'),
		 ('2AC0A1F7-A4FF-4014-B1C8-36DFF99140D1'
           ,'Love It'
           ,'68247790-E78D-4AB4-8507-BD5E9E09F1BA'
           ,2
           ,'0881970E-53B1-4843-9DB3-B382C436F983'),
		 ('E3928EBF-35EE-462F-8DE6-884627D8D441'
           ,'Atlanta'
           ,'3405FDD0-3D97-465B-802F-23C416523C4D'
           ,2
           ,'0881970E-53B1-4843-9DB3-B382C436F983'),
		 ('261A3B21-0AE8-499F-AB9D-0103346A7AFE'
           ,'Johnny'
           ,'1E209A7C-C7F5-4954-A2E5-F31797313DDA'
           ,2
           ,'1093B637-FC99-4323-A8C6-B32862A5C551'),
		 ('9C4E549F-6ABD-419E-B430-175253AD66F6'
           ,'Top Sales Performer 2014'
           ,'73985425-DB6A-4F4A-A07D-5151391CD189'
           ,2
           ,'39D740F9-4FD0-4654-BF40-0DE4CD657360');

		   
GO


/***NOTIFICATION INSERTS***************************************************************************NOTIFICATION INSERTS***/

INSERT INTO [dbo].[tblNotification]
           ([notificationId]
           ,[notificationMessage]
           ,[orderId]
           ,[notificationTypeId]
		 ,[isRead])
     VALUES
           ('4545218E-7632-4706-B09D-D3BB7BD4ADC2'
           ,'New Sale: A new order has been placed!'
           ,'7F70F68B-E942-4D20-AC40-E017B0CF4892'
		 ,1
		 ,0),
		 ('C0AA3CB0-3DDA-42BC-8777-30A8B7AC7EAD'
           ,'Invalid Payment: The payment for this order is invalid!.'
           ,'7F70F68B-E942-4D20-AC40-E017B0CF4892'
		 ,2
		 ,0),
		 ('4B3975D2-4A25-42F6-A0EE-519A9099E641'
           ,'Media Pull: Please pull the media for this order.
Catalog Item Id: 1E209A7C-C7F5-4954-A2E5-F31797313DDA
Catalog Item Id: 3405FDD0-3D97-465B-802F-23C416523C4D'
           ,'7F70F68B-E942-4D20-AC40-E017B0CF4892'
		 ,3
		 ,0),
		 ('99A06DB4-697E-4F88-8802-135D91AC884D'
           ,'Restock Item:  Please restock the unavailable item(s) on this order.'
           ,'7F70F68B-E942-4D20-AC40-E017B0CF4892'
		 ,4
		 ,0),
		 ('BCF1A3BB-75C2-45D7-895C-F3FCE5B9CB24'
           ,'Expected Delivery: The ETA for your requested item(s) is 7/7/2014.'
           ,'7F70F68B-E942-4D20-AC40-E017B0CF4892'
		 ,5
		 ,0),
		 ('D93126D9-9B29-4BDD-BC08-4A99D599D9F4'
           ,'Media Sent: Your requested media has been sent to you.  It should be arriving within an hour.'
           ,'7F70F68B-E942-4D20-AC40-E017B0CF4892'
		 ,6
		 ,0),
		 ('DD4F27DA-3B6A-4A7F-927E-EDAF1B57C993'
           ,'Inscription Complete: The requested items on this order have been printed/engraved.'
           ,'7F70F68B-E942-4D20-AC40-E017B0CF4892'
		 ,7
		 ,0),('BC61FF63-6A9F-4090-8AA9-2B7030C5E262'
           ,'Failed Quality Control: One or more items on this order have failed QC.'
           ,'7F70F68B-E942-4D20-AC40-E017B0CF4892'
		 ,8
		 ,0),
		 ('C112A749-63EB-49C6-B28B-29DAD63ABEBE'
           ,'Work Complete: The requested work has been completed.'
           ,'7F70F68B-E942-4D20-AC40-E017B0CF4892'
		 ,9
		 ,0),
		 ('071450F8-0C37-49D0-AB1A-EA3E0B0E9E89'
           ,'En Route: Your items have been ordered from the vendor and are en route to WSC''s stock room.'
           ,'7F70F68B-E942-4D20-AC40-E017B0CF4892'
		 ,10
		 ,0),
		 ('500EE89A-8E1E-45E4-AEEF-EBAAEE4F8A5A'
           ,'Delivered: Your order has been delivered.'
           ,'1093B637-FC99-4323-A8C6-B32862A5C551'
		 ,11
		 ,0),
		 ('59384C7E-C1E7-4D6A-B95B-5D72ECBC9F51'
           ,'Order Complete: This order has been completed successfully.'
           ,'1093B637-FC99-4323-A8C6-B32862A5C551'
		 ,12
		 ,0)
GO

