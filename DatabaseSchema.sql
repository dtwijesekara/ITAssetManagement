USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'ITAssetManagementDB')
BEGIN
    CREATE DATABASE ITAssetManagementDB;
END
GO

USE ITAssetManagementDB;
GO

IF OBJECT_ID('dbo.tbl_Assets',          'U') IS NOT NULL DROP TABLE dbo.tbl_Assets;
IF OBJECT_ID('dbo.tbl_Vulnerabilities', 'U') IS NOT NULL DROP TABLE dbo.tbl_Vulnerabilities;
IF OBJECT_ID('dbo.tbl_Employees',       'U') IS NOT NULL DROP TABLE dbo.tbl_Employees;
IF OBJECT_ID('dbo.tbl_Users',           'U') IS NOT NULL DROP TABLE dbo.tbl_Users;
GO

CREATE TABLE dbo.tbl_Users
(
    UserID       INT IDENTITY(1,1) NOT NULL,
    Username     NVARCHAR(50)      NOT NULL,
    PasswordHash NVARCHAR(256)     NOT NULL,
    Role         NVARCHAR(50)      NOT NULL DEFAULT 'ReadOnly',

    CONSTRAINT PK_tbl_Users          PRIMARY KEY CLUSTERED (UserID ASC),
    CONSTRAINT UQ_tbl_Users_Username UNIQUE (Username),
    CONSTRAINT CHK_Role CHECK (Role IN ('Admin', 'Auditor', 'ReadOnly'))
);
GO

CREATE TABLE dbo.tbl_Employees
(
    EmpID      INT IDENTITY(1,1) NOT NULL,
    FullName   NVARCHAR(100)     NOT NULL,
    Department NVARCHAR(100)     NOT NULL,

    CONSTRAINT PK_tbl_Employees PRIMARY KEY CLUSTERED (EmpID ASC)
);
GO

CREATE TABLE dbo.tbl_Assets
(
    AssetID            INT IDENTITY(1,1) NOT NULL,
    AssetType          NVARCHAR(50)      NOT NULL,
    MakeModel          NVARCHAR(150)     NOT NULL,
    OS_Version         NVARCHAR(100)     NOT NULL,
    AssignedTo_EmpID   INT               NULL,
    IPAddress          NVARCHAR(45)      NULL,
    MACAddress         NVARCHAR(17)      NULL,
    HasEncryptedDisk   BIT               NOT NULL DEFAULT 0,
    IsCorpManaged      BIT               NOT NULL DEFAULT 0,
    HasDefaultCreds    BIT               NOT NULL DEFAULT 0,
    HasFirewallEnabled BIT               NOT NULL DEFAULT 1,
    FirmwareVersion    NVARCHAR(50)      NULL,

    CONSTRAINT PK_tbl_Assets PRIMARY KEY CLUSTERED (AssetID ASC),
    CONSTRAINT FK_tbl_Assets_tbl_Employees
        FOREIGN KEY (AssignedTo_EmpID)
        REFERENCES dbo.tbl_Employees (EmpID)
        ON DELETE SET NULL
        ON UPDATE CASCADE
);
GO

CREATE TABLE dbo.tbl_Vulnerabilities
(
    VulnID                INT IDENTITY(1,1) NOT NULL,
    Deprecated_OS_Version NVARCHAR(100)     NOT NULL,
    ThreatLevel           NVARCHAR(20)      NOT NULL,
    Description           NVARCHAR(500)     NULL,

    CONSTRAINT PK_tbl_Vulnerabilities PRIMARY KEY CLUSTERED (VulnID ASC),
    CONSTRAINT CHK_ThreatLevel CHECK (ThreatLevel IN ('Critical', 'High', 'Medium', 'Low'))
);
GO

INSERT INTO dbo.tbl_Users (Username, PasswordHash, Role) VALUES
('admin',   '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 'Admin'),
('auditor', '5b92db4dfb561dc69c949f34d36f5db0f8b30811be3a2949d85c5001279e9b1a', 'Auditor');
GO

INSERT INTO dbo.tbl_Employees (FullName, Department) VALUES
('Kasun Perera',    'IT Department'),
('Nimali Fernando', 'Finance'),
('Ruwan Silva',     'HR'),
('Amaya Jayawardena','Engineering'),
('Tharindu Bandara','Operations');
GO

INSERT INTO dbo.tbl_Assets
    (AssetType, MakeModel, OS_Version, AssignedTo_EmpID, IPAddress, MACAddress,
     HasEncryptedDisk, IsCorpManaged, HasDefaultCreds, HasFirewallEnabled, FirmwareVersion)
VALUES
('Laptop', 'Dell Latitude E7450',  'Windows 7',           1, '192.168.1.101', 'A1:B2:C3:D4:E5:F6', 0, 0, 0, 1, NULL),
('Laptop', 'HP EliteBook 840 G3',  'Windows XP',          2, '192.168.1.102', 'B2:C3:D4:E5:F6:A1', 0, 0, 0, 1, NULL),
('Laptop', 'Lenovo ThinkPad T460', 'Windows 10 1507',     3, '192.168.1.103', 'C3:D4:E5:F6:A1:B2', 1, 0, 0, 1, NULL),
('Laptop', 'Dell XPS 15 9500',     'Windows 11 23H2',     4, '192.168.1.104', 'D4:E5:F6:A1:B2:C3', 1, 1, 0, 1, NULL),
('Laptop', 'Apple MacBook Pro M2', 'macOS Ventura 13.6',  5, '192.168.1.105', 'E5:F6:A1:B2:C3:D4', 1, 1, 0, 1, NULL),
('Router', 'Cisco RV340',          'IOS 15.1',            NULL, '192.168.1.1',  'F6:A1:B2:C3:D4:E5', 0, 0, 1, 0, '15.1.2'),
('Router', 'Ubiquiti EdgeRouter 4','EdgeOS 2.0.9',        NULL, '192.168.1.2',  'A1:C3:E5:B2:D4:F6', 0, 0, 0, 1, '2.0.9');
GO

INSERT INTO dbo.tbl_Vulnerabilities (Deprecated_OS_Version, ThreatLevel, Description) VALUES
('Windows 7',           'Critical', 'End-of-life. No security patches since Jan 2020.'),
('Windows XP',          'Critical', 'End-of-life. Extremely vulnerable, no vendor support.'),
('Windows 10 1507',     'High',     'Version 1507 reached end of service.'),
('Windows Server 2008', 'Critical', 'End-of-life. No extended support.'),
('Ubuntu 18.04',        'Medium',   'Approaching end of standard support.'),
('IOS 15.1',            'High',     'Cisco IOS 15.1 has known RCE vulnerabilities.');
GO

PRINT 'Schema and seed data applied successfully.';
GO
