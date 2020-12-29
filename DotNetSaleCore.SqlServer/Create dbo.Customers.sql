USE [DotNetSaleCore]
GO

/****** 개체: Table [dbo].[Customers] 스크립트 날짜: 2020-12-27 오후 12:29:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customers] (
    [CustomerId]     INT            IDENTITY (1, 1) NOT NULL,
    [CustomerName]   NVARCHAR (50)  NULL,
    [EmailAddress]   NVARCHAR (50)  NULL,
    [Address]        NVARCHAR (100) NULL,
    [AddressDetail]  NVARCHAR (100) NULL,
    [Phone1]         NVARCHAR (4)   NULL,
    [Phone2]         NVARCHAR (4)   NULL,
    [Phone3]         NVARCHAR (4)   NULL,
    [Mobile1]        NVARCHAR (4)   NULL,
    [Mobile2]        NVARCHAR (4)   NULL,
    [Mobile3]        NVARCHAR (4)   NULL,
    [Zip]            NVARCHAR (255) NULL,
    [Ssn1]           CHAR (6)       NULL,
    [Ssn2]           CHAR (7)       NULL,
    [MemberDivision] INT            NULL,
    [FirstName]      NVARCHAR (255) NULL,
    [LastName]       NVARCHAR (255) NULL,
    [Gender]         NVARCHAR (255) NULL,
    [City]           NVARCHAR (255) NULL,
    [CreatedBy]      NVARCHAR (255) NULL,
    [Created]        DATETIME       NULL,
    [ModifiedBy]     NVARCHAR (255) NULL,
    [Modified]       DATETIME       NULL
);