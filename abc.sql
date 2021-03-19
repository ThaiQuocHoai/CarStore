USE [master]
GO
/****** Object:  Database [Mercedes]    Script Date: 3/19/2021 12:58:36 PM ******/
CREATE DATABASE [Mercedes]
GO
USE [Mercedes]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/19/2021 12:58:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Car]    Script Date: 3/19/2021 12:58:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Car](
	[CarId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Color] [nvarchar](max) NULL,
	[Price] [real] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Image] [nvarchar](max) NULL,
	[Decription] [nvarchar](max) NULL,
	[CategoryID] [int] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED 
(
	[CarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 3/19/2021 12:58:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 3/19/2021 12:58:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[DateOrder] [datetime2](7) NOT NULL,
	[Total] [real] NOT NULL,
	[UserID] [nvarchar](450) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 3/19/2021 12:58:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[CarID] [int] NOT NULL,
	[OrderID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [real] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[CarID] ASC,
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 3/19/2021 12:58:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [nvarchar](450) NOT NULL,
	[RoleName] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 3/19/2021 12:58:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [nvarchar](450) NOT NULL,
	[Fullname] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[BirthDate] [datetime2](7) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[RoleID] [nvarchar](450) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210318055705_Initial', N'5.0.4')
SET IDENTITY_INSERT [dbo].[Car] ON 

INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (1, N'A220', N'while', 32500, 100, N'https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/2020-mercedes-benz-a-class-mmp-1-1574357481.jpg?crop=0.885xw:0.659xh;0.00481xw,0.313xh&resize=1200:*', N'abc', 1, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (2, N'A220 4Matic', N'black', 34500, 1000, N'https://images.caricos.com/m/mercedes-benz/2019_mercedes-benz_a-class_sedan/images/2560x1440/2019_mercedes-benz_a-class_sedan_66_2560x1440.jpg', N'abc', 1, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (3, N'C300', N'red', 41400, 100, N'https://giaxenhap.com/wp-content/uploads/2019/05/mercedes-benz-c300-amg.jpg', N'abc', 1, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (4, N'C300 4Matic', N'green', 43400, 1000, N'https://i.pinimg.com/originals/93/a2/59/93a25968c8603b68c53c1ec49d6c7622.png', N'abc', 1, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (6, N'AMG C 43', N'black', 55950, 100, N'https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/2019-mercedes-amg-c43-mmp-1544738283.jpg', N'abc', 1, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (8, N'AMG C 63', N'while', 68100, 100, N'https://cimg3.ibsrv.net/ibimg/hgm/1920x1080-1/100/648/2019-mercedes-benz-c-class_100648451.jpg', N'abc', 1, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (10, N'Mercedes-Maybach S560 4Matic ', N'black', 173000, 100, N'https://mercedeshaxaco.com.vn/wp-content/uploads/Mercedes-Maybach-S560-4matic-noi-that-ngoai-that-2019-2020-mercedeshaxaco.com_.vn_.jpg', N'abc', 1, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (11, N'Mercedes-Maybach S650', N'black', 202550, 100, N'https://cdn.baogiaothong.vn/upload/images/2020-2/article_img/2020-06-12/mercedes-maybach-s650-night-edition-1-1591939849-width1004height565.jpg', N'abc', 1, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (12, N'S450', N'black', 91250, 100, N'https://xes450.com/wp-content/uploads/2018/08/mercedes-s450-1024x429.jpg', N'abc', 1, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (13, N'S450 4Matic', N'black', 94250, 100, N'https://mercedesvietnam.net/wp-content/uploads/2017/12/Mercedes-Maybach-S450-4matic-2018-2019-2.jpg', N'abc', 1, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (14, N'AMG S 63', N'black', 151600, 100, N'https://cdn.motor1.com/images/mgl/gpOQ4/s1/2021-mercedes-amg-s63-sedan-rendering.jpg', N'abc', 1, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (15, N'AMG E 63 S', N'black', 111750, 100, N'https://car-images.bauersecure.com/pagefiles/68234/zmer-002.jpg', N'abc', 2, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (16, N'AMG GT 53 4-Door', N'green', 99000, 100, N'https://autopro8.mediacdn.vn/2019/10/9/header-x290-53-amg17077sx005-hd-15705754963172104241529.jpg', N'abc', 2, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (17, N'AMG GT 63 4-Door', N'black', 136500, 100, N'https://cnet2.cbsistatic.com/img/i1xx11nzRGMe73kQZGsYO9RTPi8=/1200x675/2018/09/25/94da153a-4dd5-4748-b26c-af91d15018fc/2019-mercedes-amg-gt-63-s-4-door-coupe-1.jpg', N'abc', 2, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (18, N'AMG GT 63 S 4-Door', N'while', 159000, 100, N'https://1.bp.blogspot.com/-9PxHFiJD0Pg/Xlu02FsCRoI/AAAAAAAAL-c/saPon0WX6doqYyZW5pgpLqwZWCNZEYlQACNcBGAsYHQ/s1600/left%2Bside-front%2Bview.jpg', N'abc', 2, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (19, N'AMG GT', N'red', 115900, 100, N'https://images.alphacoders.com/908/thumb-1920-908255.jpg', N'abc', 2, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (21, N'AMG GT C', N'blue', 150900, 100, N'https://images.hgmsites.net/hug/2018-mercedes-amg-gt-c-roadster-edition-50_100593465_h.jpg', N'abc', 2, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (22, N'AMG GT R ', N'red', 162900, 100, N'https://whatcar.vn/media/2019/07/2020-mercedes-amg-gt-r-pro-15-1024x576.jpg', N'abc', 2, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (23, N'SLC 300', N'silver', 49950, 100, N'https://media.autoexpress.co.uk/image/private/s--Vpsdu8aW--/v1563183775/autoexpress/2016/05/dsc_0443.jpg', N'abc', 3, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (24, N'AMG SLC 43', N'while', 64650, 100, N'https://i.xeoto.com.vn/auto/mercedes-amg/slc43/2020/ngoai-that-mercedes-amg-slc43-55396.png', N'abc', 3, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (25, N'LS 450', N'black', 91000, 100, N'https://www.eautolease.com/wp-content/uploads/2020/01/2020-mercedes-benz-sl-class-sl-450-convertible-rwd-43887-gallery_image-0-14020_st1280_037.jpg', N'abc', 3, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (26, N'LS 550', N'silver', 114700, 100, N'https://gcm.moniteurautomobile.be/imgcontrol/c680-d465/clients/moniteur/content/medias/images/test_drives/8000/0/90/16C150_006.jpg', N'abc', 3, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (27, N'AMG G 63', N'Black', 147500, 100, N'https://mercedesblog.com/wp-content/uploads/2020/08/Mercedes-AMG-G63-Inkas-3.jpg', N'abc', 4, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (28, N'G 550', N'black', 123600, 100, N'https://s.aolcdn.com/commerce/autodata/images/USC70MBS852A021001.jpg', N'abc', 4, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (29, N'GLS 450', N'while', 75200, 100, N'https://cms-i.autodaily.vn/du-lieu/2020/09/24/GLS%20450/49.jpg', N'abc', 4, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (30, N'GLS 580', N'black ', 97800, 100, N'https://cms-i.autodaily.vn/du-lieu/2019/06/22/mercedes-benz-gls-580-2.jpg', N'abc', 4, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (31, N'GLC 350e 4Matic', N'black', 49990, 100, N'https://cdn.motor1.com/images/mgl/9wN0l/s1/essai-mercedes-glc-350e.jpg', N'abc', 5, 1)
INSERT [dbo].[Car] ([CarId], [Name], [Color], [Price], [Quantity], [Image], [Decription], [CategoryID], [Status]) VALUES (32, N'123', N'Red', 1, 0, N'sdf', N'sdf', 1, 1)
SET IDENTITY_INSERT [dbo].[Car] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Status]) VALUES (1, N'Sedans & Wagons', 1)
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Status]) VALUES (2, N'COUPE', 1)
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Status]) VALUES (3, N'Convertibles & Roadsters', 1)
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Status]) VALUES (4, N'SUVs', 1)
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Status]) VALUES (5, N'Hybrid & Electric', 1)
SET IDENTITY_INSERT [dbo].[Category] OFF
/****** Object:  Index [IX_Car_CategoryID]    Script Date: 3/19/2021 12:58:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Car_CategoryID] ON [dbo].[Car]
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Order_UserID]    Script Date: 3/19/2021 12:58:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Order_UserID] ON [dbo].[Order]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetail_OrderID]    Script Date: 3/19/2021 12:58:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetail_OrderID] ON [dbo].[OrderDetail]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_User_RoleID]    Script Date: 3/19/2021 12:58:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_User_RoleID] ON [dbo].[User]
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [FK_Car_Category_CategoryID] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [FK_Car_Category_CategoryID]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User_UserID]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Car_CarID] FOREIGN KEY([CarID])
REFERENCES [dbo].[Car] ([CarId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Car_CarID]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order_OrderID] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order_OrderID]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role_RoleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role_RoleID]
GO
USE [master]
GO
ALTER DATABASE [Mercedes] SET  READ_WRITE 
GO
