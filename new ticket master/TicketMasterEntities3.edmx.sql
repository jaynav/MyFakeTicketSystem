
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/26/2012 14:43:29
-- Generated from EDMX file: C:\Users\5thinstall\documents\visual studio 2010\Projects\new ticket master\new ticket master\TicketMasterEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TicketMasters];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CreditCardInfo_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CreditCardInfoes] DROP CONSTRAINT [FK_CreditCardInfo_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Event_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events] DROP CONSTRAINT [FK_Event_User];
GO
IF OBJECT_ID(N'[dbo].[FK_PaymentInfo_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaymentInfoes] DROP CONSTRAINT [FK_PaymentInfo_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CreditCardInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CreditCardInfoes];
GO
IF OBJECT_ID(N'[dbo].[Events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events];
GO
IF OBJECT_ID(N'[dbo].[PaymentInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentInfoes];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CreditCardInfoes'
CREATE TABLE [dbo].[CreditCardInfoes] (
    [CardAccountNumber] int IDENTITY(1,1)  NOT NULL,
    [ExpirationDate] datetime  NULL,
    [SecurityKey] nchar(3)  NULL,
    [UserFirstName] nchar(20)  NULL,
    [UserLastName] nchar(20)  NULL,
    [City] nchar(10)  NULL,
    [State] nchar(10)  NULL,
    [ZipCode] nchar(10)  NULL,
    [UserID] int  NULL,
    [AccountNumber] int NOT NULL
);
GO

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [EventId] int IDENTITY(1,1) NOT NULL,
    [EventName] nchar(10)  NULL,
    [EventCost] decimal(18,0)  NULL,
    [UserID] int  NULL
);
GO

-- Creating table 'PaymentInfoes'
CREATE TABLE [dbo].[PaymentInfoes] (
    [TicketNumber] int IDENTITY(1,1) NOT NULL,
    [PaymentMethod] nchar(10)  NULL,
    [PurchaseDate] datetime  NULL,
    [UserID] int  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [FirstName] nchar(30)  NOT NULL,
    [LastName] nchar(30)  NOT NULL,
    [StreetAddress] nchar(30)  NULL,
    [City] nchar(24)  NULL,
    [State] nchar(2)  NULL,
    [ZipCode] nchar(5)  NULL,
    [PhoneNumber] nchar(10)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AccountNumber] in table 'CreditCardInfoes'
ALTER TABLE [dbo].[CreditCardInfoes]
ADD CONSTRAINT [PK_CreditCardInfoes]
    PRIMARY KEY CLUSTERED ([AccountNumber] ASC);
GO

-- Creating primary key on [EventId] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([EventId] ASC);
GO

-- Creating primary key on [TicketNumber] in table 'PaymentInfoes'
ALTER TABLE [dbo].[PaymentInfoes]
ADD CONSTRAINT [PK_PaymentInfoes]
    PRIMARY KEY CLUSTERED ([TicketNumber] ASC);
GO

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserID] in table 'CreditCardInfoes'
ALTER TABLE [dbo].[CreditCardInfoes]
ADD CONSTRAINT [FK_CreditCardInfo_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CreditCardInfo_User'
CREATE INDEX [IX_FK_CreditCardInfo_User]
ON [dbo].[CreditCardInfoes]
    ([UserID]);
GO

-- Creating foreign key on [UserID] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_Event_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Event_User'
CREATE INDEX [IX_FK_Event_User]
ON [dbo].[Events]
    ([UserID]);
GO

-- Creating foreign key on [UserID] in table 'PaymentInfoes'
ALTER TABLE [dbo].[PaymentInfoes]
ADD CONSTRAINT [FK_PaymentInfo_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentInfo_User'
CREATE INDEX [IX_FK_PaymentInfo_User]
ON [dbo].[PaymentInfoes]
    ([UserID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------