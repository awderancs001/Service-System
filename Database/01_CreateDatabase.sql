-- ============================================================
--  City Service Management System
--  Database Creation Script  (Final Version 3)
--  Run this entire file in SQL Server Management Studio (F5)
-- ============================================================

CREATE DATABASE ServiceSystemDB;
GO

USE ServiceSystemDB;
GO

-- ============================================================
--  TABLE 1: Users
--  People who log into the system
--  Role:
--    Admin  = full access + manage users
--    User   = can record and edit data
--    Viewer = read only, cannot change anything
-- ============================================================
CREATE TABLE Users (
    UserID       INT           IDENTITY(1,1) PRIMARY KEY,
    Username     NVARCHAR(50)  NOT NULL UNIQUE,
    PasswordHash NVARCHAR(256) NOT NULL,
    FullName     NVARCHAR(100) NOT NULL,
    Role         NVARCHAR(20)  NOT NULL
        CHECK (Role IN ('Admin', 'User', 'Viewer')),
    IsActive     BIT           NOT NULL DEFAULT 1,
    CreatedDate  DATETIME      NOT NULL DEFAULT GETDATE()
);
GO

-- ============================================================
--  TABLE 2: SystemSettings
--  Key-value store for company configuration
--  Easy to add new settings any time without changing the table
-- ============================================================
CREATE TABLE SystemSettings (
    SettingKey   NVARCHAR(100) NOT NULL PRIMARY KEY,
    SettingValue NVARCHAR(500) NULL,
    Description  NVARCHAR(300) NULL
);
GO

INSERT INTO SystemSettings (SettingKey, SettingValue, Description) VALUES
('CompanyName',           'City Service Company',  'Company name printed on every invoice'),
('CompanyNameKurdish',    '',                       'Company name in Kurdish for invoice'),
('CompanyPhone',          '',                       'Company phone on invoice'),
('CompanyAddress',        '',                       'Company address on invoice'),
('InvoicePrefix',         'INV',                    'Prefix for invoice numbers — result: INV-2024-0001'),
('LastInvoiceNumber',     '0',                      'Last used number — system increments this automatically'),
('DefaultElectricPrice',  '0.00',                   'Default price per kwh shown when opening electric form'),
('BackupFolderPath',      'C:\ServiceBackups\',     'Folder where backup files are saved'),
('AutoBackupEnabled',     '1',                      '1 = auto backup on | 0 = off'),
('AutoBackupIntervalDays','1',                      'How many days between auto backups');
GO

-- ============================================================
--  TABLE 3: Buildings
--  Block A, Block B, etc.
--  BuildingCategory: House or Apartment
--  This is new — without this we cannot group units by block
-- ============================================================
CREATE TABLE Buildings (
    BuildingID       INT           IDENTITY(1,1) PRIMARY KEY,
    BuildingName     NVARCHAR(100) NOT NULL UNIQUE,   -- e.g. "Block A", "Block B"
    BuildingCategory NVARCHAR(20)  NOT NULL
        CHECK (BuildingCategory IN ('House', 'Apartment')),
    Notes            NVARCHAR(300) NULL,
    CreatedDate      DATETIME      NOT NULL DEFAULT GETDATE(),
    CreatedBy        INT           NULL REFERENCES Users(UserID)
);
GO

-- ============================================================
--  TABLE 4: Units
--  Each house or apartment unit
--
--  KEY CHANGE from before:
--    - Added BuildingID  (which block this unit belongs to)
--    - Added UnitType    (A / B / C / D / E — the house/apt type)
--    - UNIQUE is now (BuildingID + UnitName) not just UnitName
--      because Block A and Block B can both have a unit named "101"
-- ============================================================
CREATE TABLE Units (
    UnitID               INT           IDENTITY(1,1) PRIMARY KEY,
    BuildingID           INT           NOT NULL REFERENCES Buildings(BuildingID),
    UnitName             NVARCHAR(100) NOT NULL,       -- e.g. "101", "Ground Floor"
    UnitType             NVARCHAR(5)   NULL,            -- A / B / C / D / E

    -- Owner
    OwnerFullName        NVARCHAR(100) NOT NULL,
    OwnerPhone           NVARCHAR(20)  NOT NULL,
    OwnerOtherPhone      NVARCHAR(20)  NULL,
    OwnerNation          NVARCHAR(50)  NULL,

    -- Tenant (only if unit is rented out)
    HasTenant            BIT           NOT NULL DEFAULT 0,
    TenantFullName       NVARCHAR(100) NULL,
    TenantPhone          NVARCHAR(20)  NULL,
    TenantOtherPhone     NVARCHAR(20)  NULL,
    TenantNation         NVARCHAR(50)  NULL,

    -- Monthly service fee for this specific unit (50 / 60 / 70 or other)
    MonthlyServiceAmount DECIMAL(10,2) NOT NULL DEFAULT 0,

    CreatedDate          DATETIME      NOT NULL DEFAULT GETDATE(),
    CreatedBy            INT           NULL REFERENCES Users(UserID),
    IsActive             BIT           NOT NULL DEFAULT 1,

    -- Unit name only needs to be unique WITHIN the same building
    CONSTRAINT UQ_Unit UNIQUE (BuildingID, UnitName)
);
GO

-- ============================================================
--  TABLE 5: MonthlyServiceBills
--  Monthly service fee charged to each unit
--  One row per unit per month — cannot charge same unit twice in same month
-- ============================================================
CREATE TABLE MonthlyServiceBills (
    BillID      INT           IDENTITY(1,1) PRIMARY KEY,
    UnitID      INT           NOT NULL REFERENCES Units(UnitID),
    BillMonth   DATE          NOT NULL,   -- Always 1st of month: 2024-04-01
    Amount      DECIMAL(10,2) NOT NULL,
    Notes       NVARCHAR(300) NULL,
    CreatedDate DATETIME      NOT NULL DEFAULT GETDATE(),
    CreatedBy   INT           NULL REFERENCES Users(UserID),

    CONSTRAINT UQ_ServiceBill UNIQUE (UnitID, BillMonth)
);
GO

-- ============================================================
--  TABLE 6: MaintenanceBills
--  Maintenance charges — can be different amount each time
--  No UNIQUE constraint: one unit can have multiple maintenance
--  jobs in the same month
-- ============================================================
CREATE TABLE MaintenanceBills (
    MaintenanceID INT           IDENTITY(1,1) PRIMARY KEY,
    UnitID        INT           NOT NULL REFERENCES Units(UnitID),
    BillMonth     DATE          NOT NULL,
    Amount        DECIMAL(10,2) NOT NULL,
    Description   NVARCHAR(300) NULL,
    CreatedDate   DATETIME      NOT NULL DEFAULT GETDATE(),
    CreatedBy     INT           NULL REFERENCES Users(UserID)
);
GO

-- ============================================================
--  TABLE 7: ElectricBills
--  Record meter readings — SQL calculates the amount for you
--  TotalAmount = (EndReading - BeginReading) * PricePerUnit
--  PERSISTED means SQL stores the result so it is fast to query
--  PricePerUnit is entered each time (can be different every month)
-- ============================================================
CREATE TABLE ElectricBills (
    ElectricID   INT           IDENTITY(1,1) PRIMARY KEY,
    UnitID       INT           NOT NULL REFERENCES Units(UnitID),
    BillMonth    DATE          NOT NULL,
    BeginReading DECIMAL(10,2) NOT NULL,
    EndReading   DECIMAL(10,2) NOT NULL,
    PricePerUnit DECIMAL(10,4) NOT NULL,
    TotalAmount  AS CAST((EndReading - BeginReading) * PricePerUnit AS DECIMAL(10,2)) PERSISTED,
    Notes        NVARCHAR(300) NULL,
    CreatedDate  DATETIME      NOT NULL DEFAULT GETDATE(),
    CreatedBy    INT           NULL REFERENCES Users(UserID),

    CONSTRAINT UQ_ElectricBill UNIQUE (UnitID, BillMonth)
);
GO

-- ============================================================
--  TABLE 8: Payments  (the "Receive Money" screen)
--  One row each time a unit pays money
--
--  KEY POINT — ForMonth and ToMonth:
--    If unit pays for ONE month:    ForMonth = 2024-04-01, ToMonth = NULL
--    If unit pays for THREE months: ForMonth = 2024-04-01, ToMonth = 2024-06-01
--  This lets the debtor report correctly know which months are covered
-- ============================================================
CREATE TABLE Payments (
    PaymentID   INT           IDENTITY(1,1) PRIMARY KEY,
    UnitID      INT           NOT NULL REFERENCES Units(UnitID),
    ForMonth    DATE          NOT NULL,   -- First (or only) month this payment covers
    ToMonth     DATE          NULL,       -- Last month covered. NULL = only ForMonth
    PaymentDate DATE          NOT NULL DEFAULT CAST(GETDATE() AS DATE),
    Amount      DECIMAL(10,2) NOT NULL,
    Comment     NVARCHAR(300) NULL,
    ReceivedBy  INT           NULL REFERENCES Users(UserID),
    CreatedDate DATETIME      NOT NULL DEFAULT GETDATE(),

    -- Make sure ToMonth is not before ForMonth (data quality check)
    CONSTRAINT CHK_PaymentMonths CHECK (ToMonth IS NULL OR ToMonth >= ForMonth)
);
GO

-- ============================================================
--  TABLE 9: Invoices
--  Official printed receipt given to the unit when they pay
--
--  DebtMonth / DebtToMonth: the range of months this invoice covers
--  If invoice is for one month: DebtMonth = April, DebtToMonth = NULL
--  If invoice is for 3 months:  DebtMonth = April, DebtToMonth = June
--
--  InvoiceContent: free text — write anything you want printed
--  CreatedByName: stored permanently so history stays correct
--                 even if the user account is later deleted
-- ============================================================
CREATE TABLE Invoices (
    InvoiceID      INT           IDENTITY(1,1) PRIMARY KEY,
    InvoiceNumber  NVARCHAR(50)  NOT NULL UNIQUE,   -- INV-2024-0001
    PaymentID      INT           NULL REFERENCES Payments(PaymentID),
    UnitID         INT           NOT NULL REFERENCES Units(UnitID),
    GiverName      NVARCHAR(100) NOT NULL,
    GiverNameKurdish NVARCHAR(100) NULL,
    ReceiverName   NVARCHAR(100) NOT NULL,
    ReceiverNameKurdish NVARCHAR(100) NULL,
    DebtMonth      DATE          NOT NULL,           -- First (or only) month on invoice
    DebtToMonth    DATE          NULL,               -- Last month if multi-month invoice
    PaymentDate    DATE          NOT NULL,
    Amount         DECIMAL(10,2) NOT NULL,
    BillType       NVARCHAR(20)  NOT NULL DEFAULT 'Mixed'
        CHECK (BillType IN ('Service', 'Maintenance', 'Electric', 'Mixed')),
    InvoiceContent        NVARCHAR(1000) NULL,       -- English free text
    InvoiceContentKurdish NVARCHAR(1000) NULL,       -- Kurdish free text
    CreatedBy      INT           NULL REFERENCES Users(UserID),
    CreatedByName  NVARCHAR(100) NULL,
    CreatedDate    DATETIME      NOT NULL DEFAULT GETDATE()
);
GO

-- ============================================================
--  TABLE 10: DeletedRecords
--  Every soft-delete is logged here
--  Admin can view and can permanently delete if needed
-- ============================================================
CREATE TABLE DeletedRecords (
    DeleteID          INT           IDENTITY(1,1) PRIMARY KEY,
    TableName         NVARCHAR(50)  NOT NULL,
    RecordID          INT           NOT NULL,
    RecordDescription NVARCHAR(500) NOT NULL,
    DeletedDate       DATETIME      NOT NULL DEFAULT GETDATE(),
    DeletedBy         INT           NULL REFERENCES Users(UserID),
    DeletedByName     NVARCHAR(100) NULL
);
GO

-- ============================================================
--  TABLE 11: UserFormPermissions
--  Per user, per form: can they open it? can they edit?
--  Viewer role: CanAccess=1, CanEdit=0 on all forms
-- ============================================================
CREATE TABLE UserFormPermissions (
    PermissionID INT           IDENTITY(1,1) PRIMARY KEY,
    UserID       INT           NOT NULL REFERENCES Users(UserID),
    FormName     NVARCHAR(50)  NOT NULL,
    CanAccess    BIT           NOT NULL DEFAULT 1,
    CanEdit      BIT           NOT NULL DEFAULT 0,

    CONSTRAINT UQ_UserForm UNIQUE (UserID, FormName)
);
GO

-- ============================================================
--  TABLE 12: BackupLog
--  Every backup is recorded — auto or manual
--  Lets admin see: when was last backup, did it succeed, where is file
-- ============================================================
CREATE TABLE BackupLog (
    BackupID   INT           IDENTITY(1,1) PRIMARY KEY,
    BackupDate DATETIME      NOT NULL DEFAULT GETDATE(),
    BackupPath NVARCHAR(500) NOT NULL,
    BackupType NVARCHAR(10)  NOT NULL DEFAULT 'Manual'
        CHECK (BackupType IN ('Auto', 'Manual')),
    IsSuccess  BIT           NOT NULL DEFAULT 1,
    Notes      NVARCHAR(300) NULL,
    CreatedBy  INT           NULL REFERENCES Users(UserID)
);
GO

-- ============================================================
--  DEFAULT ADMIN USER
--  Username: admin    Password: admin123
--  CHANGE THIS PASSWORD after first login!
-- ============================================================
INSERT INTO Users (Username, PasswordHash, FullName, Role, IsActive)
VALUES (
    'admin',
    '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9',
    'System Admin',
    'Admin',
    1
);
GO

-- ============================================================
--  VIEW: vw_UnitBalances
--  Each unit with: total charged, total paid, remaining balance
--  Used in dashboard and debtor reports
-- ============================================================
CREATE VIEW vw_UnitBalances AS
SELECT
    u.UnitID,
    b.BuildingName,
    b.BuildingCategory,
    u.UnitName,
    u.UnitType,
    u.OwnerFullName,
    u.OwnerPhone,
    u.HasTenant,
    u.TenantFullName,
    u.TenantPhone,
    u.MonthlyServiceAmount,

    ISNULL((SELECT SUM(Amount)      FROM MonthlyServiceBills WHERE UnitID = u.UnitID), 0) +
    ISNULL((SELECT SUM(Amount)      FROM MaintenanceBills    WHERE UnitID = u.UnitID), 0) +
    ISNULL((SELECT SUM(TotalAmount) FROM ElectricBills       WHERE UnitID = u.UnitID), 0)
    AS TotalCharged,

    ISNULL((SELECT SUM(Amount) FROM Payments WHERE UnitID = u.UnitID), 0)
    AS TotalPaid,

    (
        ISNULL((SELECT SUM(Amount)      FROM MonthlyServiceBills WHERE UnitID = u.UnitID), 0) +
        ISNULL((SELECT SUM(Amount)      FROM MaintenanceBills    WHERE UnitID = u.UnitID), 0) +
        ISNULL((SELECT SUM(TotalAmount) FROM ElectricBills       WHERE UnitID = u.UnitID), 0) -
        ISNULL((SELECT SUM(Amount)      FROM Payments            WHERE UnitID = u.UnitID), 0)
    ) AS Balance

FROM Units u
INNER JOIN Buildings b ON b.BuildingID = u.BuildingID
WHERE u.IsActive = 1;
GO

-- ============================================================
--  VIEW: vw_MonthlyDebtors
--  For a given month: which units have a service bill
--  and have NOT fully paid for that month
--
--  LOGIC for multi-month payments:
--    A unit is "paid" for month M if a payment exists where:
--    ForMonth <= M  AND  (ToMonth IS NULL AND ForMonth = M)
--                        OR (ToMonth >= M)
--    Simplified: ForMonth <= M AND ISNULL(ToMonth, ForMonth) >= M
-- ============================================================
CREATE VIEW vw_MonthlyDebtors AS
SELECT
    u.UnitID,
    b.BuildingName,
    u.UnitName,
    u.UnitType,
    u.OwnerFullName,
    u.OwnerPhone,
    u.TenantFullName,
    u.TenantPhone,
    sb.BillMonth,
    sb.Amount AS ServiceAmount,

    ISNULL((
        SELECT SUM(p.Amount)
        FROM Payments p
        WHERE p.UnitID = u.UnitID
          AND p.ForMonth <= sb.BillMonth
          AND ISNULL(p.ToMonth, p.ForMonth) >= sb.BillMonth
    ), 0) AS PaidForMonth,

    sb.Amount - ISNULL((
        SELECT SUM(p.Amount)
        FROM Payments p
        WHERE p.UnitID = u.UnitID
          AND p.ForMonth <= sb.BillMonth
          AND ISNULL(p.ToMonth, p.ForMonth) >= sb.BillMonth
    ), 0) AS MonthBalance

FROM Units u
INNER JOIN Buildings b         ON b.BuildingID = u.BuildingID
INNER JOIN MonthlyServiceBills sb ON sb.UnitID = u.UnitID
WHERE u.IsActive = 1;
GO

PRINT '==============================================';
PRINT ' Database ServiceSystemDB created successfully';
PRINT ' 12 Tables + 2 Views';
PRINT ' Default login:  admin / admin123';
PRINT ' IMPORTANT: Change password after first login!';
PRINT '==============================================';
GO
