USE [Shopping Online]
GO
/****** Object:  Table [dbo].[Attributes]    Script Date: 12/7/2021 12:27:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attributes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](128) NULL,
 CONSTRAINT [PK_Attributes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttributeValues]    Script Date: 12/7/2021 12:27:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttributeValues](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AttributeId] [int] NULL,
	[Name] [nvarchar](128) NULL,
 CONSTRAINT [PK_AttributeValues] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Catalogs]    Script Date: 12/7/2021 12:27:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Catalogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[SiteTitle] [nvarchar](128) NULL,
	[MetaKeywords] [nvarchar](158) NULL,
	[MetaDescription] [nvarchar](158) NULL,
	[ParentId] [int] NULL,
	[SortOder] [int] NULL,
	[Visibility] [bit] NOT NULL,
 CONSTRAINT [PK_Catalogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 12/7/2021 12:27:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](128) NULL,
	[CustomerPhone] [nvarchar](128) NULL,
	[CustomerEmail] [nvarchar](128) NULL,
	[CustomerAddress] [nvarchar](128) NULL,
	[CustomerCity] [nvarchar](128) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 12/7/2021 12:27:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OderId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 12/7/2021 12:27:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[OderDate] [datetime] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductAttributes]    Script Date: 12/7/2021 12:27:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductAttributes](
	[ProductId] [int] NOT NULL,
	[AttributeValueId] [int] NOT NULL,
 CONSTRAINT [PK_ProductAttributes] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[AttributeValueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 12/7/2021 12:27:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](128) NULL,
	[CatalogId] [int] NULL,
	[Description] [nvarchar](128) NULL,
	[Content] [ntext] NULL,
	[Price] [decimal](18, 2) NULL,
	[PromotionPrice] [decimal](18, 2) NULL,
	[Image] [nvarchar](128) NULL,
	[ThumbImage] [nvarchar](128) NULL,
	[ImageList] [nvarchar](max) NULL,
	[MetaDescription] [nvarchar](158) NULL,
	[SiteTitle] [nvarchar](128) NULL,
	[MetaKeywords] [nvarchar](158) NULL,
	[ViewCount] [int] NULL,
	[Warranty] [int] NULL,
	[Video] [nvarchar](128) NULL,
	[DateCreated] [datetime] NULL,
	[UserCreated] [int] NULL,
	[DateModified] [datetime] NULL,
	[UserModified] [int] NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Attributes] ON 

INSERT [dbo].[Attributes] ([Id], [Name]) VALUES (1, N'Kích thước')
INSERT [dbo].[Attributes] ([Id], [Name]) VALUES (2, N'Màu Sắc')
SET IDENTITY_INSERT [dbo].[Attributes] OFF
GO
SET IDENTITY_INSERT [dbo].[AttributeValues] ON 

INSERT [dbo].[AttributeValues] ([Id], [AttributeId], [Name]) VALUES (1, 1, N'S')
INSERT [dbo].[AttributeValues] ([Id], [AttributeId], [Name]) VALUES (2, 1, N'M ')
INSERT [dbo].[AttributeValues] ([Id], [AttributeId], [Name]) VALUES (3, 1, N'L ')
INSERT [dbo].[AttributeValues] ([Id], [AttributeId], [Name]) VALUES (4, 1, N'XL')
INSERT [dbo].[AttributeValues] ([Id], [AttributeId], [Name]) VALUES (5, 1, N'XLL')
INSERT [dbo].[AttributeValues] ([Id], [AttributeId], [Name]) VALUES (6, 2, N'Red')
INSERT [dbo].[AttributeValues] ([Id], [AttributeId], [Name]) VALUES (7, 2, N'Blue')
INSERT [dbo].[AttributeValues] ([Id], [AttributeId], [Name]) VALUES (8, 2, N'Blacl')
SET IDENTITY_INSERT [dbo].[AttributeValues] OFF
GO
SET IDENTITY_INSERT [dbo].[Catalogs] ON 

INSERT [dbo].[Catalogs] ([Id], [Name], [SiteTitle], [MetaKeywords], [MetaDescription], [ParentId], [SortOder], [Visibility]) VALUES (1, N'Áo nam', N' ', NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Catalogs] OFF
GO
ALTER TABLE [dbo].[AttributeValues]  WITH CHECK ADD  CONSTRAINT [FK_AttributeValues_Attributes] FOREIGN KEY([AttributeId])
REFERENCES [dbo].[Attributes] ([Id])
GO
ALTER TABLE [dbo].[AttributeValues] CHECK CONSTRAINT [FK_AttributeValues_Attributes]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([OderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [dbo].[ProductAttributes]  WITH CHECK ADD  CONSTRAINT [FK_ProductAttributes_AttributeValues] FOREIGN KEY([AttributeValueId])
REFERENCES [dbo].[AttributeValues] ([Id])
GO
ALTER TABLE [dbo].[ProductAttributes] CHECK CONSTRAINT [FK_ProductAttributes_AttributeValues]
GO
ALTER TABLE [dbo].[ProductAttributes]  WITH CHECK ADD  CONSTRAINT [FK_ProductAttributes_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ProductAttributes] CHECK CONSTRAINT [FK_ProductAttributes_Products]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Catalogs] FOREIGN KEY([CatalogId])
REFERENCES [dbo].[Catalogs] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Catalogs]
GO
