/* ===========================
   0) DATABASE + LOGIN + USER
=========================== */
USE master;
GO

-- Crear la base de datos si no existe
IF DB_ID('SAMDESIGN') IS NULL
BEGIN
    CREATE DATABASE SAMDESIGN;
END
GO

-- Crear LOGIN (nivel servidor)
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'ADMIN_SAMDESIGN')
BEGIN
    CREATE LOGIN ADMIN_SAMDESIGN WITH PASSWORD = 'SAMDESIGN';
END
GO

-- Crear USER dentro de la base SAMDESIGN
USE SAMDESIGN;
GO

IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'ADMIN_SAMDESIGN')
BEGIN
    CREATE USER ADMIN_SAMDESIGN FOR LOGIN ADMIN_SAMDESIGN;
END
GO

-- Crear esquema SAMDESIGN
IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'SAMDESIGN')
BEGIN
    EXEC ('CREATE SCHEMA SAMDESIGN AUTHORIZATION ADMIN_SAMDESIGN;');
END
GO

-- Permisos estilo DBO dentro de la base de datos
ALTER ROLE db_owner ADD MEMBER ADMIN_SAMDESIGN;
GO

USE SAMDESIGN;
GO

/* ===========================
   STATUS
=========================== */
CREATE TABLE SAMDESIGN.STATUS_TB (
    Status_ID    INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_STATUS_ID PRIMARY KEY,
    Description  NVARCHAR(255) NULL,
    Created_By   NVARCHAR(50) NULL,
    Created_On   DATETIME2 NULL,
    Modified_By  NVARCHAR(50) NULL,
    Modified_On  DATETIME2 NULL
);
GO

/* ===========================
   CUSTOMER
=========================== */
CREATE TABLE SAMDESIGN.CUSTOMER_TB (
    Customer_ID           INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_CUSTOMER_ID PRIMARY KEY,
    Customer_Name         NVARCHAR(100) NULL,
    Customer_Email        NVARCHAR(100) NOT NULL,
    Customer_Phone_number NVARCHAR(50) NULL,
    Status_ID             INT NULL,
    Created_By            NVARCHAR(50) NULL,
    Created_On            DATETIME2 NULL,
    Modified_On           DATETIME2 NULL,
    Modified_By           NVARCHAR(50) NULL,

    CONSTRAINT FK_CUSTOMER_STATUS FOREIGN KEY (Status_ID)
        REFERENCES SAMDESIGN.STATUS_TB(Status_ID)
);
GO

/* ===========================
   CITY
=========================== */
CREATE TABLE SAMDESIGN.CITY_ADDRESS_TB (
    City_ID     INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_CITY_ID PRIMARY KEY,
    Name        NVARCHAR(255) NULL,
    Status_ID   INT NULL,
    Created_By  NVARCHAR(50) NULL,
    Created_On  DATETIME2 NULL,
    Modified_By NVARCHAR(50) NULL,
    Modified_On DATETIME2 NULL,

    CONSTRAINT FK_CITY_STATUS FOREIGN KEY (Status_ID)
        REFERENCES SAMDESIGN.STATUS_TB(Status_ID)
);
GO

/* ===========================
   STATE
=========================== */
CREATE TABLE SAMDESIGN.STATE_ADDRESS_TB (
    State_ID    INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_STATE_ID PRIMARY KEY,
    Name        NVARCHAR(255) NULL,
    Status_ID   INT NULL,
    Created_By  NVARCHAR(50) NULL,
    Created_On  DATETIME2 NULL,
    Modified_By NVARCHAR(50) NULL,
    Modified_On DATETIME2 NULL,

    CONSTRAINT FK_STATE_STATUS FOREIGN KEY (Status_ID)
        REFERENCES SAMDESIGN.STATUS_TB(Status_ID)
);
GO

/* ===========================
   COUNTRIES
=========================== */
CREATE TABLE SAMDESIGN.COUNTRIES_TB (
    Country_ID  INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_COUNTRY_ID PRIMARY KEY,
    Name        NVARCHAR(255) NULL,
    Status_ID   INT NULL,
    Created_By  NVARCHAR(50) NULL,
    Created_On  DATETIME2 NULL,
    Modified_By NVARCHAR(50) NULL,
    Modified_On DATETIME2 NULL,

    CONSTRAINT FK_COUNTRY_STATUS FOREIGN KEY (Status_ID)
        REFERENCES SAMDESIGN.STATUS_TB(Status_ID)
);
GO

/* ===========================
   ADDRESS
=========================== */
CREATE TABLE SAMDESIGN.ADDRESS_TB (
    Address_ID   INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ADDRESS_ID PRIMARY KEY,
    Address      NVARCHAR(250) NULL,
    ID_State     INT NULL,
    ID_City      INT NULL,
    ZIP_Code     INT NULL,
    ID_Country   INT NULL,
    Status_ID    INT NULL,
    Created_By   NVARCHAR(100) NULL,
    Created_On   DATETIME2 NOT NULL CONSTRAINT DF_ADDRESS_CREATED_ON DEFAULT SYSDATETIME(),
    Modified_By  NVARCHAR(100) NULL,
    Modified_On  DATETIME2 NULL,
    ID_Customer  INT NULL,

    CONSTRAINT FK_ADDRESS_STATE FOREIGN KEY (ID_State)
        REFERENCES SAMDESIGN.STATE_ADDRESS_TB(State_ID),

    CONSTRAINT FK_ADDRESS_CITY FOREIGN KEY (ID_City)
        REFERENCES SAMDESIGN.CITY_ADDRESS_TB(City_ID),

    CONSTRAINT FK_ADDRESS_COUNTRY FOREIGN KEY (ID_Country)
        REFERENCES SAMDESIGN.COUNTRIES_TB(Country_ID),

    CONSTRAINT FK_ADDRESS_STATUS FOREIGN KEY (Status_ID)
        REFERENCES SAMDESIGN.STATUS_TB(Status_ID),

    CONSTRAINT FK_ADDRESS_CUSTOMER FOREIGN KEY (ID_Customer)
        REFERENCES SAMDESIGN.CUSTOMER_TB(Customer_ID)
);
GO



/* ===========================
   CATEGORY_TYPE_TB
=========================== */

CREATE TABLE SAMDESIGN.CATEGORY_TYPE_TB (
    Category_ID  INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_CATEGORY_ID PRIMARY KEY,
    Description  NVARCHAR(255) NULL,
    Comments     NVARCHAR(255) NULL,
    Status_ID    INT NULL,
    Created_By   NVARCHAR(50) NULL,
    Created_On   DATETIME2 NULL,
    Modified_By  NVARCHAR(50) NULL,
    Modified_On  DATETIME2 NULL,

    CONSTRAINT FK_CATEGORY_TYPE_STATUS_ID FOREIGN KEY (Status_ID)
        REFERENCES SAMDESIGN.STATUS_TB(Status_ID)
);
GO



/* ===========================
   VENDOR_TB
=========================== */

CREATE TABLE SAMDESIGN.VENDOR_TB (
    Vendor_ID          INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_VENDOR_ID PRIMARY KEY,
    Vendor_Name        NVARCHAR(100) NULL,
    Vendor_Address_ID  INT NULL,
    Vendor_eMail       NVARCHAR(100) NOT NULL CONSTRAINT UQ_VENDOR_EMAIL UNIQUE (Vendor_eMail),
    Vendor_Balance     DECIMAL(18,2) NULL,
    Created_By         NVARCHAR(50) NULL,
    Created_On         DATETIME2 NULL,
    Modified_By        NVARCHAR(50) NULL,
    Modified_On        DATETIME2 NULL,
    Status_ID          INT NULL,

    CONSTRAINT FK_VENDOR_STATUS_ID FOREIGN KEY (Status_ID)
        REFERENCES SAMDESIGN.STATUS_TB(Status_ID)
);
GO

/* ===========================
   PAYMENT_METHOD_TB
=========================== */

CREATE TABLE SAMDESIGN.PAYMENT_METHOD_TB (
    Payment_Method_ID   INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_PAYMENT_METHOD_ID PRIMARY KEY,
    Payment_Method_Name NVARCHAR(255) NULL,
    Description         NVARCHAR(255) NULL,
    Status_ID           INT NULL,
    Created_By          NVARCHAR(50) NULL,
    Created_On          DATETIME2 NULL,
    Modified_By         NVARCHAR(50) NULL,
    Modified_On         DATETIME2 NULL,

    CONSTRAINT FK_PAYMENT_METHOD_STATUS FOREIGN KEY (Status_ID)
        REFERENCES SAMDESIGN.STATUS_TB(Status_ID)
);
GO

/* ===========================
   PRODUCT_TB
=========================== */

CREATE TABLE SAMDESIGN.PRODUCT_TB (
    Product_ID       INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_PRODUCT_ID PRIMARY KEY,
    Description      NVARCHAR(255) NULL,
    Category_Type_ID INT NULL,
    Comments         NVARCHAR(255) NULL,
    Unit_price       DECIMAL(18,2) NULL,
    Image_path       NVARCHAR(4000) NULL,
    Status_ID        INT NULL,
    Created_By       NVARCHAR(50) NULL,
    Created_On       DATETIME2 NULL,
    Modified_By      NVARCHAR(50) NULL,
    Modified_On      DATETIME2 NULL,

    CONSTRAINT FK_PRODUCT_CATEGORY FOREIGN KEY (Category_Type_ID)
        REFERENCES SAMDESIGN.CATEGORY_TYPE_TB(Category_ID),

    CONSTRAINT FK_PRODUCT_STATUS FOREIGN KEY (Status_ID)
        REFERENCES SAMDESIGN.STATUS_TB(Status_ID)
);
GO


/* ===========================
   INVENTORY_TB
=========================== */

CREATE TABLE SAMDESIGN.INVENTORY_TB (
    Inventory_ID   INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_INVENTORY_ID PRIMARY KEY,
    Description    NVARCHAR(255) NULL,
    Status_ID      INT NULL,
    Created_By     NVARCHAR(50) NULL,
    Created_On     DATETIME2 NULL,
    Modified_By    NVARCHAR(50) NULL,
    Modified_On    DATETIME2 NULL,

    CONSTRAINT FK_INVENTORY_STATUS FOREIGN KEY (Status_ID)
        REFERENCES SAMDESIGN.STATUS_TB(Status_ID)
);
GO


/* ===========================
   INVENTORY_LINES_TB
=========================== */

CREATE TABLE SAMDESIGN.INVENTORY_LINES_TB (
    Inventory_Lines_ID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_INVENTORY_LINES_ID PRIMARY KEY,
    Inventory_ID       INT NULL,
    Product_ID         INT NULL,
    Comments           NVARCHAR(500) NULL,
    Quantity_Stocked   INT NULL,
    Quantity_Reserved  INT NULL,
    Status_ID          INT NULL,
    Last_ReStocked     DATETIME2 NULL,
    Created_By         NVARCHAR(100) NULL,
    Created_On         DATETIME2 NOT NULL CONSTRAINT DF_INV_LINES_CREATED_ON DEFAULT SYSDATETIME(),
    Modified_By        NVARCHAR(100) NULL,
    Modified_On        DATETIME2 NULL,

    CONSTRAINT FK_INV_LINES_INVENTORY FOREIGN KEY (Inventory_ID)
        REFERENCES SAMDESIGN.INVENTORY_TB(Inventory_ID),

    CONSTRAINT FK_INV_LINES_PRODUCT FOREIGN KEY (Product_ID)
        REFERENCES SAMDESIGN.PRODUCT_TB(Product_ID),

    CONSTRAINT FK_INV_LINES_STATUS FOREIGN KEY (Status_ID)
        REFERENCES SAMDESIGN.STATUS_TB(Status_ID)
);
GO


/* ===========================
   ORDER_TB
=========================== */

CREATE TABLE SAMDESIGN.ORDER_TB (
    Order_ID          NVARCHAR(100) NOT NULL CONSTRAINT PK_ORDER_ID PRIMARY KEY,
    Customer_ID       INT NULL,
    Order_Date        DATETIME2 NULL,
    Order_Amount      DECIMAL(18,2) NULL,
    Order_Tax         DECIMAL(18,2) NULL,
    Comments          NVARCHAR(255) NULL,
    Dispatch          BIT NOT NULL CONSTRAINT DF_ORDER_DISPATCH DEFAULT 0,
    Fullfield         BIT NOT NULL CONSTRAINT DF_ORDER_FULLFIELD DEFAULT 0,
    Status_ID         INT NULL,
    Payment_Method_ID INT NULL,
    Created_On        DATETIME2 NULL,
    Created_By        NVARCHAR(50) NULL,
    Modified_On       DATETIME2 NULL,
    Modified_By       NVARCHAR(50) NULL,
    address_id        INT NULL,

    CONSTRAINT FK_ORDER_CUSTOMER FOREIGN KEY (Customer_ID)
        REFERENCES SAMDESIGN.CUSTOMER_TB(Customer_ID),

    CONSTRAINT FK_ORDER_STATUS FOREIGN KEY (Status_ID)
        REFERENCES SAMDESIGN.STATUS_TB(Status_ID),

    CONSTRAINT FK_ORDER_PAYMENT_METHOD FOREIGN KEY (Payment_Method_ID)
        REFERENCES SAMDESIGN.PAYMENT_METHOD_TB(Payment_Method_ID),

    CONSTRAINT FK_ORDER_ADDRESS FOREIGN KEY (address_id)
        REFERENCES SAMDESIGN.ADDRESS_TB(Address_ID)
);
GO


/* ===========================
   ORDER_LINES_TB
=========================== */

CREATE TABLE SAMDESIGN.ORDER_LINES_TB (
    Order_Line_ID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ORDER_LINE_ID PRIMARY KEY,
    Order_ID      NVARCHAR(100) NULL,
    Product_ID    INT NULL,
    Qty_Item      INT NULL,
    Comments      NVARCHAR(255) NULL,
    Status_ID     INT NULL,
    Total_Price   DECIMAL(18,2) NULL,
    Created_On    DATETIME2 NULL,
    Created_By    NVARCHAR(50) NULL,
    Modified_On   DATETIME2 NULL,
    Modified_By   NVARCHAR(50) NULL,

    CONSTRAINT FK_ORDER_LINES_ORDER FOREIGN KEY (Order_ID)
        REFERENCES SAMDESIGN.ORDER_TB(Order_ID),

    CONSTRAINT FK_ORDER_LINES_PRODUCT FOREIGN KEY (Product_ID)
        REFERENCES SAMDESIGN.PRODUCT_TB(Product_ID),

    CONSTRAINT FK_ORDER_LINES_STATUS FOREIGN KEY (Status_ID)
        REFERENCES SAMDESIGN.STATUS_TB(Status_ID)
);
GO


/* ===========================
   BILLING_TB
=========================== */

CREATE TABLE SAMDESIGN.BILLING_TB (
    Billing_ID          INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_BILLING_ID PRIMARY KEY,
    Order_ID            NVARCHAR(100) NULL,
    Customer_ID         INT NULL,
    Invoiced_Address_ID INT NULL,
    Billing_Date        DATETIME2 NULL,
    Total_Amount        DECIMAL(18,2) NULL,
    Comments            NVARCHAR(255) NULL,
    Status_ID           INT NULL,
    Payment_Method_ID   INT NULL,
    Created_On          DATETIME2 NULL,
    Created_By          NVARCHAR(50) NULL,
    Modified_On         DATETIME2 NULL,
    Modified_By         NVARCHAR(50) NULL,

    CONSTRAINT FK_BILLING_ORDER FOREIGN KEY (Order_ID)
        REFERENCES SAMDESIGN.ORDER_TB(Order_ID),

    CONSTRAINT FK_BILLING_CUSTOMER FOREIGN KEY (Customer_ID)
        REFERENCES SAMDESIGN.CUSTOMER_TB(Customer_ID),

    CONSTRAINT FK_BILLING_STATUS FOREIGN KEY (Status_ID)
        REFERENCES SAMDESIGN.STATUS_TB(Status_ID),

    CONSTRAINT FK_BILLING_PAYMENT_METHOD FOREIGN KEY (Payment_Method_ID)
        REFERENCES SAMDESIGN.PAYMENT_METHOD_TB(Payment_Method_ID)
);
GO


/* ===========================
   CART_TB
=========================== */

CREATE TABLE SAMDESIGN.CART_TB (
    Cart_ID           INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_CART_ID PRIMARY KEY,
    Customer_ID       INT NULL,
    Address_ID        INT NULL,
    Order_Date        DATETIME2 NULL,
    Comments          NVARCHAR(255) NULL,
    Status_ID         INT NULL,
    Payment_Method_ID INT NULL,
    Created_On        DATETIME2 NULL,
    Created_By        NVARCHAR(50) NULL,
    Modified_On       DATETIME2 NULL,
    Modified_By       NVARCHAR(50) NULL,

    CONSTRAINT FK_CART_CUSTOMER FOREIGN KEY (Customer_ID)
        REFERENCES SAMDESIGN.CUSTOMER_TB(Customer_ID),

    CONSTRAINT FK_CART_ADDRESS FOREIGN KEY (Address_ID)
        REFERENCES SAMDESIGN.ADDRESS_TB(Address_ID),

    CONSTRAINT FK_CART_STATUS FOREIGN KEY (Status_ID)
        REFERENCES SAMDESIGN.STATUS_TB(Status_ID),

    CONSTRAINT FK_CART_PAYMENT_METHOD FOREIGN KEY (Payment_Method_ID)
        REFERENCES SAMDESIGN.PAYMENT_METHOD_TB(Payment_Method_ID)
);
GO


/* ===========================
   CART_LINES_TB
=========================== */

CREATE TABLE SAMDESIGN.CART_LINES_TB (
    Cart_Line_ID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_CART_LINE_ID PRIMARY KEY,
    Cart_ID      INT NULL,
    Product_ID   INT NULL,
    Qty_Item     INT NULL,
    Comments     NVARCHAR(255) NULL,
    Status_ID    INT NULL,
    Total_Price  DECIMAL(18,2) NULL,
    Created_On   DATETIME2 NULL,
    Created_By   NVARCHAR(50) NULL,
    Modified_On  DATETIME2 NULL,
    Modified_By  NVARCHAR(50) NULL,

    CONSTRAINT FK_CART_LINES_CART FOREIGN KEY (Cart_ID)
        REFERENCES SAMDESIGN.CART_TB(Cart_ID),

    CONSTRAINT FK_CART_LINES_PRODUCT FOREIGN KEY (Product_ID)
        REFERENCES SAMDESIGN.PRODUCT_TB(Product_ID),

    CONSTRAINT FK_CART_LINES_STATUS FOREIGN KEY (Status_ID)
        REFERENCES SAMDESIGN.STATUS_TB(Status_ID)
);
GO
