USE master
GO
CREATE DATABASE [MercedesStore]
GO
USE [MercedesStore]
GO
CREATE TABLE tblRoles(
	[roleID] [varchar](50) PRIMARY KEY,
	[roleName] [varchar](100) NULL,
	[status] [bit] NULL,
)
GO
CREATE TABLE tblUsers(
	[userID] [varchar](50) PRIMARY KEY,
	[fullName] [varchar](100) NULL,
	[password] [varchar](50) NULL,
	[phone] [varchar](10) NULL,
	[address] [varchar](1000) NULL,
	[email] [varchar](50) NULL,
	[birthDate] [date] NULL,
	[createDate] [date] NULL,
	[roleID] [varchar](50) REFERENCES tblRoles,
	[status] [bit] NULL,
	)
GO
CREATE TABLE tblOrders(
	[orderID] [int] IDENTITY(1,1) PRIMARY KEY,
	[dateOrder] [date] NULL,
	[total] [float] NULL,
	[userID] [varchar](50) REFERENCES tblUsers,
	[status] [bit] NULL,
	)
GO
CREATE TABLE tblCategories(
	[categoryID] [int] IDENTITY(1,1) PRIMARY KEY,
	[categoryName] [varchar](100) NULL,
	[status] [bit] NULL,
	)
GO
CREATE TABLE tblCars(
	[carID] [int] IDENTITY(1,1) PRIMARY KEY,
	[name] [varchar](1000) NULL,
	[color] [varchar](100) NULL,
	[price] [float] NULL,
	[quantity] [int] NULL,
	[image] [varchar](8000) NULL,
	[description] [varchar](8000) NULL,
	[categoryID] [int] REFERENCES [tblCategories],
	[status] [bit] NULL
	)
GO
CREATE TABLE tblOrderDetails(
	[ordDetailID] [int] IDENTITY(1,1) PRIMARY KEY,
	[carID] [int]  REFERENCES [tblCars],
	[orderID] [int]  REFERENCES [tblOrders],
	[quantity] [int] NULL,
	[price] [float] NULL,
	[status] [bit] NULL,
	)
