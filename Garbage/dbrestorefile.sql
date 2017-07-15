USE [GuitarShopDEV]
GO
/****** Object:  Table [dbo].[AvailabilityType]    Script Date: 15.07.2017 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AvailabilityType](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_AvailabilityType_id]  DEFAULT (newid()),
	[Name] [varchar](150) NULL,
 CONSTRAINT [PK_AvailabilityType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 15.07.2017 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Brand](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_Brand_Id]  DEFAULT (newid()),
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 15.07.2017 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_Category_id]  DEFAULT (newid()),
	[ParentID] [uniqueidentifier] NULL CONSTRAINT [DF_Category_CategoryID]  DEFAULT (newid()),
	[Name] [varchar](200) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CategoryCharacteristic]    Script Date: 15.07.2017 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryCharacteristic](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_CategoryCharacteristic_id]  DEFAULT (newid()),
	[CategoryID] [uniqueidentifier] NULL,
	[CharacteristicID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_CategoryCharacteristic] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Characteristics]    Script Date: 15.07.2017 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Characteristics](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_Characteristics_id]  DEFAULT (newid()),
	[Name] [varchar](200) NULL,
 CONSTRAINT [PK_Characteristics] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CharValue]    Script Date: 15.07.2017 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CharValue](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_CharValue_id]  DEFAULT (newid()),
	[intVal] [int] NULL,
	[floatVal] [float] NULL,
	[strVal] [varchar](200) NULL,
 CONSTRAINT [PK_CharValue] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 15.07.2017 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Comment](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[ItemId] [uniqueidentifier] NULL,
	[UserId] [uniqueidentifier] NULL,
	[UserName] [varchar](50) NULL,
	[CommentTypeId] [uniqueidentifier] NULL,
	[Comment] [varchar](max) NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CommentType]    Script Date: 15.07.2017 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CommentType](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_CommentType_Id]  DEFAULT (newid()),
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_CommentType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 15.07.2017 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contacts](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_Contacts_id]  DEFAULT (newid()),
	[userId] [uniqueidentifier] NULL,
	[contactTypeId] [uniqueidentifier] NULL,
	[Value] [varchar](50) NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContactType]    Script Date: 15.07.2017 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContactType](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_ContactType_id]  DEFAULT (newid()),
	[name] [varchar](50) NULL,
 CONSTRAINT [PK_ContactType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Country]    Script Date: 15.07.2017 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Country](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_Country_id]  DEFAULT (newid()),
	[Name] [varchar](100) NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Curency]    Script Date: 15.07.2017 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Curency](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_Curency_id]  DEFAULT (newid()),
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Curency] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DeliveryType]    Script Date: 15.07.2017 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DeliveryType](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_DeliveryType_id]  DEFAULT (newid()),
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_DeliveryType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 15.07.2017 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Gender](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_Gender_id]  DEFAULT (newid()),
	[name] [varchar](50) NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GeneralNews]    Script Date: 15.07.2017 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GeneralNews](
	[id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_GeneralNews_id]  DEFAULT (newid()),
	[name] [varchar](50) NULL,
	[description] [varchar](max) NULL,
	[date] [datetime] NULL,
 CONSTRAINT [PK_GeneralNews] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Item]    Script Date: 15.07.2017 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Item](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_Item_id]  DEFAULT (newid()),
	[Name] [varchar](50) NULL,
	[Description] [varchar](500) NULL,
	[CategoryID] [uniqueidentifier] NULL,
	[BrandID] [uniqueidentifier] NULL,
	[ManufCountryID] [uniqueidentifier] NULL,
	[BrandCOuntryID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemCharacteristics]    Script Date: 15.07.2017 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemCharacteristics](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_ItemCharacteristics_id]  DEFAULT (newid()),
	[ItemID] [uniqueidentifier] NULL,
	[CharacteristicID] [uniqueidentifier] NULL,
	[CharVarID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_ItemCharacteristics] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ItemImage]    Script Date: 15.07.2017 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemImage](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[ItemId] [uniqueidentifier] NOT NULL,
	[ImageURL] [varchar](max) NULL,
	[VideoURL] [varchar](max) NULL,
 CONSTRAINT [PK_ItemImage] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Order]    Script Date: 15.07.2017 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_Order_Id]  DEFAULT (newid()),
	[StatusId] [uniqueidentifier] NULL,
	[UserId] [uniqueidentifier] NULL,
	[Comment] [varchar](500) NULL,
	[ContactId] [uniqueidentifier] NULL,
	[Name] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Address] [varchar](250) NULL,
	[Number] [varchar](50) NULL,
	[Date] [datetime] NULL,
	[DeliveryTypeId] [uniqueidentifier] NULL,
	[email] [varchar](250) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 15.07.2017 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_OrderItems_id]  DEFAULT (newid()),
	[ItemId] [uniqueidentifier] NOT NULL,
	[purposePriceId] [uniqueidentifier] NOT NULL,
	[OrderId] [uniqueidentifier] NOT NULL,
	[count] [int] NOT NULL,
	[purposeId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Purpose]    Script Date: 15.07.2017 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purpose](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_Purpose_id]  DEFAULT (newid()),
	[ItemId] [uniqueidentifier] NULL,
	[AvailabilityTypeID] [uniqueidentifier] NULL,
	[IsPromo] [bit] NULL,
 CONSTRAINT [PK_Purpose] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[purposePrice]    Script Date: 15.07.2017 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[purposePrice](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_purposePrice_id]  DEFAULT (newid()),
	[purposeId] [uniqueidentifier] NOT NULL,
	[price] [float] NULL,
	[date] [date] NULL,
	[curencyID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_purposePrice] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 15.07.2017 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_Role_id]  DEFAULT (newid()),
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[status]    Script Date: 15.07.2017 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[status](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_status_id]  DEFAULT (newid()),
	[name] [varchar](50) NULL,
 CONSTRAINT [PK_status] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[userRole]    Script Date: 15.07.2017 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userRole](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_userRole_id]  DEFAULT (newid()),
	[userId] [uniqueidentifier] NULL,
	[roleID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_userRole] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[users]    Script Date: 15.07.2017 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[users](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_users_id]  DEFAULT (newid()),
	[name] [varchar](50) NULL,
	[Lname] [varchar](50) NULL,
	[Login] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[email] [varchar](100) NULL,
	[birthDate] [date] NULL,
	[GenderID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[AvailabilityType] ([id], [Name]) VALUES (N'c9f3e4e0-d4de-4857-a282-1349caf63df4', N'Available')
INSERT [dbo].[AvailabilityType] ([id], [Name]) VALUES (N'0358605e-94a3-4f0f-b2f6-1f77c4ddc962', N'Not available')
INSERT [dbo].[AvailabilityType] ([id], [Name]) VALUES (N'a4c16f0c-f7fb-4751-9bdc-c1b94cd27236', N'Discontinue')
INSERT [dbo].[AvailabilityType] ([id], [Name]) VALUES (N'a3dc2b7a-7070-43a6-bc77-f7837cafdfef', N'Delivery time 3 days')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (N'5eaf6c25-5aaf-46c4-b302-112e1fa74af3', N'Fernandes')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (N'a111ed0e-0960-44a1-bbdc-12678b7ad31b', N'FillPro')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (N'3e728b39-b3d9-4d1f-9263-16172d529393', N'J&Dbrothers')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (N'6da6f476-4795-4130-a7b8-2b32e7c54f61', N'BCRich')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (N'95197f9c-ff80-4c6b-822c-412e6966f3df', N'Fender')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (N'818ac158-7eed-4339-a501-9164d6a99890', N'Ibanez')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (N'0a470578-d79a-457c-961a-cb2ec017c9a5', N'Gibson')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (N'47dbf889-23a4-4c9d-b7f5-d63ef5eb542b', N'Yamaha')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (N'93dfda45-13ce-4a36-9d20-dc0720f25e53', N'Jackson')
INSERT [dbo].[Category] ([id], [ParentID], [Name]) VALUES (N'dee1eeca-7cab-423f-84c0-03da47661a68', N'ba19562e-77ab-456e-8e28-1cfdf4e40fc2', N'Acoustic Bass Guitar')
INSERT [dbo].[Category] ([id], [ParentID], [Name]) VALUES (N'09d1e004-7d78-40d8-ae8c-0cfa4620b1a5', NULL, N'Strings')
INSERT [dbo].[Category] ([id], [ParentID], [Name]) VALUES (N'bc66c044-54c6-42d0-978d-191e21f3d8ee', N'ba19562e-77ab-456e-8e28-1cfdf4e40fc2', N'Electro-Acoustic Guitars')
INSERT [dbo].[Category] ([id], [ParentID], [Name]) VALUES (N'ba19562e-77ab-456e-8e28-1cfdf4e40fc2', NULL, N'Guitars')
INSERT [dbo].[Category] ([id], [ParentID], [Name]) VALUES (N'f0c77461-a40f-4236-ab8f-33c3d77957a7', N'ba19562e-77ab-456e-8e28-1cfdf4e40fc2', N'Electric Guitars')
INSERT [dbo].[Category] ([id], [ParentID], [Name]) VALUES (N'f869a9e7-47d1-4bd7-b371-82e291875653', N'bb0f640a-142e-464d-9f38-bce3e29633d1', N'Bass Amplifiers')
INSERT [dbo].[Category] ([id], [ParentID], [Name]) VALUES (N'c82701c8-6d0c-41b8-a333-883d97da8417', N'bb0f640a-142e-464d-9f38-bce3e29633d1', N'Guitar Amplifiers')
INSERT [dbo].[Category] ([id], [ParentID], [Name]) VALUES (N'78f331b0-5a0f-4d74-9976-933b33410a08', N'09d1e004-7d78-40d8-ae8c-0cfa4620b1a5', N'Bass Guitar Strings')
INSERT [dbo].[Category] ([id], [ParentID], [Name]) VALUES (N'7c64b12e-2a0d-4f81-a601-9b1281f84449', N'ba19562e-77ab-456e-8e28-1cfdf4e40fc2', N'Acoustic Guitars')
INSERT [dbo].[Category] ([id], [ParentID], [Name]) VALUES (N'7b763f67-92d0-4a63-81c5-9f1b30775219', N'09d1e004-7d78-40d8-ae8c-0cfa4620b1a5', N'Electric Guitars Strings')
INSERT [dbo].[Category] ([id], [ParentID], [Name]) VALUES (N'81b0c6b9-9d72-420e-85e8-b362f9a6401c', N'ba19562e-77ab-456e-8e28-1cfdf4e40fc2', N'Bass Guitar')
INSERT [dbo].[Category] ([id], [ParentID], [Name]) VALUES (N'bb0f640a-142e-464d-9f38-bce3e29633d1', NULL, N'ComboAndAmplifiers')
INSERT [dbo].[Category] ([id], [ParentID], [Name]) VALUES (N'e95292b5-a7a6-463e-a9f9-e1ff489e02b4', NULL, N'Pedals')
INSERT [dbo].[Category] ([id], [ParentID], [Name]) VALUES (N'dceb450d-5b28-4dfe-9a71-eea1da33b0a7', N'09d1e004-7d78-40d8-ae8c-0cfa4620b1a5', N'Acoustic Guitars Strings')
INSERT [dbo].[CategoryCharacteristic] ([id], [CategoryID], [CharacteristicID]) VALUES (N'c56ad2a1-6529-4a4f-a0db-01d1d811b60a', N'ba19562e-77ab-456e-8e28-1cfdf4e40fc2', N'b9bfbf38-a510-4d9a-b1a4-ec10f8e9b970')
INSERT [dbo].[CategoryCharacteristic] ([id], [CategoryID], [CharacteristicID]) VALUES (N'040cf1b9-173c-467b-add1-032d265bcc33', N'e95292b5-a7a6-463e-a9f9-e1ff489e02b4', N'ab7619f5-1fd5-45e5-ba3e-43bd2a354917')
INSERT [dbo].[CategoryCharacteristic] ([id], [CategoryID], [CharacteristicID]) VALUES (N'c8343714-1a23-4d89-b482-1cbc140ef834', N'ba19562e-77ab-456e-8e28-1cfdf4e40fc2', N'd7a10659-41ec-4fe2-be90-da982afad260')
INSERT [dbo].[CategoryCharacteristic] ([id], [CategoryID], [CharacteristicID]) VALUES (N'94690519-9998-4a21-9a19-32c567441912', N'ba19562e-77ab-456e-8e28-1cfdf4e40fc2', N'6e947e49-e56b-47ac-a8e6-dcac7ea53bee')
INSERT [dbo].[CategoryCharacteristic] ([id], [CategoryID], [CharacteristicID]) VALUES (N'd896d751-5fc3-475c-bf04-36ce3870c350', N'09d1e004-7d78-40d8-ae8c-0cfa4620b1a5', N'865e4c63-b3fe-4061-a4d4-60cf078f550a')
INSERT [dbo].[CategoryCharacteristic] ([id], [CategoryID], [CharacteristicID]) VALUES (N'3a35cc8f-9e57-448c-b558-3f3f3d13b2c2', N'ba19562e-77ab-456e-8e28-1cfdf4e40fc2', N'ab47b388-1c6f-487c-838b-6ba1f39674f3')
INSERT [dbo].[CategoryCharacteristic] ([id], [CategoryID], [CharacteristicID]) VALUES (N'b6610554-e33e-4416-8ba5-413f82893715', N'f0c77461-a40f-4236-ab8f-33c3d77957a7', N'7eb967cf-9289-4b8b-9e54-ce7b2c986c00')
INSERT [dbo].[CategoryCharacteristic] ([id], [CategoryID], [CharacteristicID]) VALUES (N'bcc34e79-6464-4416-b9d3-4cb83c96addf', N'ba19562e-77ab-456e-8e28-1cfdf4e40fc2', N'447aadff-1b3f-4ab9-9b44-178534768a5b')
INSERT [dbo].[CategoryCharacteristic] ([id], [CategoryID], [CharacteristicID]) VALUES (N'358ff754-ed2e-4121-9dcb-5cabc446e1d5', N'ba19562e-77ab-456e-8e28-1cfdf4e40fc2', N'8f7e02e9-5b1b-46c2-983d-937187903d4c')
INSERT [dbo].[CategoryCharacteristic] ([id], [CategoryID], [CharacteristicID]) VALUES (N'ee505b81-d4b7-447c-bf0b-6679c941da13', N'09d1e004-7d78-40d8-ae8c-0cfa4620b1a5', N'46098154-9e3a-4a06-b5b9-41eaff3c0b94')
INSERT [dbo].[CategoryCharacteristic] ([id], [CategoryID], [CharacteristicID]) VALUES (N'72b6d536-403d-4b3d-ab51-a4e969916c2c', N'ba19562e-77ab-456e-8e28-1cfdf4e40fc2', N'46098154-9e3a-4a06-b5b9-41eaff3c0b94')
INSERT [dbo].[CategoryCharacteristic] ([id], [CategoryID], [CharacteristicID]) VALUES (N'849251b8-db98-473a-813e-afeaf314660d', N'ba19562e-77ab-456e-8e28-1cfdf4e40fc2', N'1793b40b-4dc1-4f04-96dc-16190ce74d8c')
INSERT [dbo].[CategoryCharacteristic] ([id], [CategoryID], [CharacteristicID]) VALUES (N'73952dce-e829-46a1-b96f-b87c9cf3d3bc', N'bb0f640a-142e-464d-9f38-bce3e29633d1', N'd2f66dff-85ea-456d-829b-6b772781cb31')
INSERT [dbo].[CategoryCharacteristic] ([id], [CategoryID], [CharacteristicID]) VALUES (N'd64f3a75-3788-4772-875e-c81fa28f09e4', N'ba19562e-77ab-456e-8e28-1cfdf4e40fc2', N'92e998ec-4257-4efe-b864-24bc3fb9561a')
INSERT [dbo].[CategoryCharacteristic] ([id], [CategoryID], [CharacteristicID]) VALUES (N'22dcdf18-99e5-43a7-a93f-caedbc61370c', N'bc66c044-54c6-42d0-978d-191e21f3d8ee', N'7eb967cf-9289-4b8b-9e54-ce7b2c986c00')
INSERT [dbo].[CategoryCharacteristic] ([id], [CategoryID], [CharacteristicID]) VALUES (N'c2a9a347-7a40-4014-bad7-e4e03417e3f5', N'81b0c6b9-9d72-420e-85e8-b362f9a6401c', N'7eb967cf-9289-4b8b-9e54-ce7b2c986c00')
INSERT [dbo].[Characteristics] ([id], [Name]) VALUES (N'1793b40b-4dc1-4f04-96dc-16190ce74d8c', N'Bridge type')
INSERT [dbo].[Characteristics] ([id], [Name]) VALUES (N'447aadff-1b3f-4ab9-9b44-178534768a5b', N'Neck type')
INSERT [dbo].[Characteristics] ([id], [Name]) VALUES (N'92e998ec-4257-4efe-b864-24bc3fb9561a', N'Form')
INSERT [dbo].[Characteristics] ([id], [Name]) VALUES (N'46098154-9e3a-4a06-b5b9-41eaff3c0b94', N'Strings count')
INSERT [dbo].[Characteristics] ([id], [Name]) VALUES (N'ab7619f5-1fd5-45e5-ba3e-43bd2a354917', N'Pedal type')
INSERT [dbo].[Characteristics] ([id], [Name]) VALUES (N'865e4c63-b3fe-4061-a4d4-60cf078f550a', N'String type')
INSERT [dbo].[Characteristics] ([id], [Name]) VALUES (N'd2f66dff-85ea-456d-829b-6b772781cb31', N'Amp type')
INSERT [dbo].[Characteristics] ([id], [Name]) VALUES (N'ab47b388-1c6f-487c-838b-6ba1f39674f3', N'Tuners')
INSERT [dbo].[Characteristics] ([id], [Name]) VALUES (N'8f7e02e9-5b1b-46c2-983d-937187903d4c', N'Scale')
INSERT [dbo].[Characteristics] ([id], [Name]) VALUES (N'7eb967cf-9289-4b8b-9e54-ce7b2c986c00', N'Pickups type')
INSERT [dbo].[Characteristics] ([id], [Name]) VALUES (N'd7a10659-41ec-4fe2-be90-da982afad260', N'Color')
INSERT [dbo].[Characteristics] ([id], [Name]) VALUES (N'6e947e49-e56b-47ac-a8e6-dcac7ea53bee', N'Fretboard')
INSERT [dbo].[Characteristics] ([id], [Name]) VALUES (N'b9bfbf38-a510-4d9a-b1a4-ec10f8e9b970', N'Deck wood')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'1196cf3a-200a-4c5e-aca4-019fdc28ccd7', NULL, NULL, N'Maple')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'23d09543-0eba-481d-8fe4-070bbdd01d83', NULL, NULL, N'HS')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'19ee3be3-9506-40c2-af66-07cc57d1f4a2', NULL, NULL, N'SSS')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'0e4d8b0d-399e-407b-ba5d-09de502193b2', 12, NULL, NULL)
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'a5c91041-a89e-4c30-b4b9-14d4721fa146', NULL, NULL, N'Bolt on')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'be4dbd23-6d8d-40c8-9bfa-18e315dbe24f', NULL, NULL, N'Black')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'2932b323-7089-4a2b-8f78-2cd917af9877', NULL, NULL, N'Set neck')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'4ecc491e-950e-4551-89ed-2d30e61185c1', NULL, NULL, N'Neck through')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'55fdd7e8-ce3b-4127-bb64-3229ddd1af67', NULL, NULL, N'Bass pedal')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'7e0724e6-75ff-4574-9cc5-3bd88a8a7e07', NULL, NULL, N'Closed Box')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'f4f35b3c-d546-4430-bdac-4232e3e83eb6', NULL, NULL, N'Stratocaster')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'adb82fa6-1f9c-4b03-ba24-4eaf0dda403a', NULL, NULL, N'Mahogany')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'16914268-b6c4-4316-af07-547a669273a6', NULL, NULL, N'Green')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'506b2d83-91b8-4476-bb49-5683635904f4', NULL, NULL, N'Electric strings')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'09c65750-4b7d-4e6a-8b0e-5cbfff20e26f', 6, NULL, NULL)
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'bb7ff12d-8e2b-4f6a-a318-5f6bc72f230f', NULL, NULL, N'HSH')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'711929d0-eba4-4074-b2cc-616e0e8cfbee', NULL, 28, NULL)
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'3c951cd8-bc05-4ae0-b7a2-6296d911d0b9', NULL, 30, NULL)
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'39e96f0c-8824-4164-b27f-63b567d95736', NULL, NULL, N'Bass strings')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'dd7ce2da-4b99-4039-81bc-687fbff35028', NULL, NULL, N'HSS')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'51539602-982e-4786-b4e7-6b68b546834b', NULL, 34, NULL)
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'5b2e2a78-8727-40f9-a8db-6b9ddb3ea660', NULL, NULL, N'Floyd Rose')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'9d676496-1081-489b-be7b-732ee68025a1', NULL, NULL, N'Blue')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'd0fd662e-755e-4eb1-98a4-746aa4435af1', NULL, NULL, N'Basswood')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'63826e16-d395-4545-8fef-78a22644e421', NULL, NULL, N'Tube')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'742da97f-f13f-4762-8811-7af22ba0b9b9', NULL, 27, NULL)
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'8608e72c-f1d6-4ba4-b5f6-7b8845298227', NULL, 35, NULL)
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'a3fea846-237b-465a-93d5-7ff4d3ab88d8', NULL, NULL, N'Telecaster')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'1de783bc-ae8d-4e46-87cb-85431c70a5da', 7, NULL, NULL)
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'b28f3716-c6c0-4f57-a60e-8d43ad7369cf', NULL, NULL, N'Les Paul')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'e1f06b55-0244-4550-8ff9-8d6dd8649210', NULL, NULL, N'Superstrat')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'051bcbbe-fd71-4bad-9aa5-9129ba4dd0b8', NULL, NULL, N'Acoustic strings')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'dee1f2af-a514-4a4a-9178-a5394c7ae9ea', 5, NULL, NULL)
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'94488d23-3fa9-4a58-9c4b-a87dbb08e95f', NULL, NULL, N'Sealed')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'4169e34a-6a68-41cd-9d1e-a96ee916eb20', NULL, 26.5, NULL)
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'9072a5f8-6931-42ee-85e3-b27215dd91e8', NULL, NULL, N'Red')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'b696f242-ef4a-4d6e-9cfe-ba8179895513', NULL, 25.5, NULL)
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'2a503ce7-6faf-4e2d-9217-c20a2f546ca8', 4, NULL, NULL)
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'cb2a85d9-76b4-41d2-940d-c5682a8186fc', NULL, NULL, N'Guitar pedal')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'e25ef1aa-9fef-45bb-89e0-c99384b1804f', NULL, NULL, N'Rosewood')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'acc47863-6331-45a3-9255-d63be26baa54', NULL, NULL, N'SG')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'ced66cb1-f45e-4bed-8942-d8f29dc3bf00', NULL, NULL, N'Ebony')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'd3975bce-0998-4d64-8fce-ddd56e15d9ca', NULL, 24.75, NULL)
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'40da8a30-2de8-4b86-a0bb-ea16a7fc96a1', NULL, NULL, N'HH')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'5ec7d3cf-7cd1-4b09-81ad-ea5662419900', NULL, NULL, N'White')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'7c2c469a-dabb-4aae-88ad-eaee7040890a', NULL, NULL, N'Transistor')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'e50c5340-a88d-45a1-a20a-eb2b96052fac', 8, NULL, NULL)
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'77126016-d1c5-4949-ad2b-ed1a0437f91d', NULL, NULL, N'Sperzal Locking')
INSERT [dbo].[CharValue] ([id], [intVal], [floatVal], [strVal]) VALUES (N'f4cca812-9eac-4aac-b6a0-f9cf3bb9a416', NULL, NULL, N'Tune o Matic')
INSERT [dbo].[CommentType] ([Id], [Name]) VALUES (N'e75638c1-ede3-4651-be8f-3eee8b527a99', N'Question')
INSERT [dbo].[CommentType] ([Id], [Name]) VALUES (N'22744601-8182-4c53-8378-5d998bc2004e', N'Complaint')
INSERT [dbo].[CommentType] ([Id], [Name]) VALUES (N'af43ff3d-0c9b-47a5-b067-67f284695270', N'Proposal')
INSERT [dbo].[CommentType] ([Id], [Name]) VALUES (N'332e0982-7482-4d95-bb13-8905583aedd3', N'Comment')
INSERT [dbo].[Contacts] ([id], [userId], [contactTypeId], [Value]) VALUES (N'00dcdc08-33a7-4515-afe6-075a4185ae99', N'26ea779e-21ea-4999-98af-bc3b5d1ef068', N'953d65ba-d259-4467-833d-91b41b79f695', N'Kyiv, Khreschatyk 1')
INSERT [dbo].[Contacts] ([id], [userId], [contactTypeId], [Value]) VALUES (N'4cda3cd3-1d99-4b04-bc14-2b86154da754', N'6339b42c-3ef9-4c24-9f4c-82de9bbca566', N'9f91e8bc-6f45-444d-b965-521521d6010a', N'petrov@gmail.com')
INSERT [dbo].[Contacts] ([id], [userId], [contactTypeId], [Value]) VALUES (N'2c9fa535-e3ee-4e16-b184-52c3658fd446', N'086192ce-70e7-4410-b5d4-3f0f1486ea6a', N'7b961cba-7420-41c7-8f54-b49b83e5e7de', N'0991677007')
INSERT [dbo].[Contacts] ([id], [userId], [contactTypeId], [Value]) VALUES (N'c7d83bbb-09be-4fb4-8e78-aa9c42cca1f7', N'086192ce-70e7-4410-b5d4-3f0f1486ea6a', N'9f91e8bc-6f45-444d-b965-521521d6010a', N'wrider@gmail.com')
INSERT [dbo].[Contacts] ([id], [userId], [contactTypeId], [Value]) VALUES (N'9fed72a7-c7b6-4325-8f31-c1ad75664c9a', N'9e5b2abf-46a9-4500-a08b-bd18e468cda2', N'7b961cba-7420-41c7-8f54-b49b83e5e7de', N'0990123456')
INSERT [dbo].[ContactType] ([id], [name]) VALUES (N'9f91e8bc-6f45-444d-b965-521521d6010a', N'Email')
INSERT [dbo].[ContactType] ([id], [name]) VALUES (N'953d65ba-d259-4467-833d-91b41b79f695', N'Address')
INSERT [dbo].[ContactType] ([id], [name]) VALUES (N'7b961cba-7420-41c7-8f54-b49b83e5e7de', N'Phone')
INSERT [dbo].[Country] ([id], [Name]) VALUES (N'5bc086d7-538e-4cbf-8d82-0ce725e6bc11', N'Korea')
INSERT [dbo].[Country] ([id], [Name]) VALUES (N'3c2a50de-9dca-4435-8342-1f3e14bc1577', N'Japan')
INSERT [dbo].[Country] ([id], [Name]) VALUES (N'35fcd710-1c9b-4c5b-8566-4dcdc4bf3a5e', N'China')
INSERT [dbo].[Country] ([id], [Name]) VALUES (N'43c6ee07-e1a0-4427-94b8-924cf566fca7', N'USA')
INSERT [dbo].[Curency] ([id], [Name]) VALUES (N'be2e38e5-337d-4898-a54a-5072d2f2a894', N'RUB')
INSERT [dbo].[Curency] ([id], [Name]) VALUES (N'035c980b-d8c8-4126-ba7f-65a1992b301d', N'EUR')
INSERT [dbo].[Curency] ([id], [Name]) VALUES (N'37820566-d2f7-44e7-b550-9675d1fc8168', N'UAH')
INSERT [dbo].[Curency] ([id], [Name]) VALUES (N'23d17c67-8755-480a-ac67-ff7190f9b208', N'USD')
INSERT [dbo].[DeliveryType] ([id], [Name]) VALUES (N'a9aa9401-cf27-4196-9d8e-35e15fce1445', N'Address delivery')
INSERT [dbo].[DeliveryType] ([id], [Name]) VALUES (N'4554d7f9-863a-48e3-8584-788ddb60dcb0', N'Pickup')
INSERT [dbo].[Gender] ([id], [name]) VALUES (N'96676584-ed15-4991-900e-1403842591ef', N'Female')
INSERT [dbo].[Gender] ([id], [name]) VALUES (N'8de84309-62bb-49b4-8bd4-ce99295b8dcf', N'Male')
INSERT [dbo].[GeneralNews] ([id], [name], [description], [date]) VALUES (N'5c06f8d0-c49a-4238-b284-4ec61523f32a', N'We are opened', N'Some news', CAST(N'2017-07-12 03:59:48.723' AS DateTime))
INSERT [dbo].[GeneralNews] ([id], [name], [description], [date]) VALUES (N'f12b4170-3c2b-41b9-95b4-988a3992dffe', N'First news', N'123 123 123456', CAST(N'2017-07-12 04:00:15.163' AS DateTime))
INSERT [dbo].[Item] ([id], [Name], [Description], [CategoryID], [BrandID], [ManufCountryID], [BrandCOuntryID]) VALUES (N'983496eb-465f-4d29-8aa0-080a729997ec', N'121c', N'Some description about bass guitar here', N'7c64b12e-2a0d-4f81-a601-9b1281f84449', N'47dbf889-23a4-4c9d-b7f5-d63ef5eb542b', N'5bc086d7-538e-4cbf-8d82-0ce725e6bc11', N'43c6ee07-e1a0-4427-94b8-924cf566fca7')
INSERT [dbo].[Item] ([id], [Name], [Description], [CategoryID], [BrandID], [ManufCountryID], [BrandCOuntryID]) VALUES (N'da4aff3c-7aee-4a64-be3d-28024ecdc376', N'6895bc', N'Some description about bass guitar here', N'7c64b12e-2a0d-4f81-a601-9b1281f84449', N'6da6f476-4795-4130-a7b8-2b32e7c54f61', N'5bc086d7-538e-4cbf-8d82-0ce725e6bc11', N'43c6ee07-e1a0-4427-94b8-924cf566fca7')
INSERT [dbo].[Item] ([id], [Name], [Description], [CategoryID], [BrandID], [ManufCountryID], [BrandCOuntryID]) VALUES (N'9bf5d47f-f356-43a3-8104-28abcaa9112a', N'vortex X', N'Some description about bass guitar here', N'bc66c044-54c6-42d0-978d-191e21f3d8ee', N'5eaf6c25-5aaf-46c4-b302-112e1fa74af3', N'5bc086d7-538e-4cbf-8d82-0ce725e6bc11', N'43c6ee07-e1a0-4427-94b8-924cf566fca7')
INSERT [dbo].[Item] ([id], [Name], [Description], [CategoryID], [BrandID], [ManufCountryID], [BrandCOuntryID]) VALUES (N'2191688b-e599-4dbe-81c5-33d21ac69c21', N'b73', N'Some description about guitar amp here', N'f869a9e7-47d1-4bd7-b371-82e291875653', N'0a470578-d79a-457c-961a-cb2ec017c9a5', N'5bc086d7-538e-4cbf-8d82-0ce725e6bc11', N'43c6ee07-e1a0-4427-94b8-924cf566fca7')
INSERT [dbo].[Item] ([id], [Name], [Description], [CategoryID], [BrandID], [ManufCountryID], [BrandCOuntryID]) VALUES (N'73956afa-1669-4740-88b2-3df5f4851ff3', N'Lespaul 2235', N'Dima loh', N'f0c77461-a40f-4236-ab8f-33c3d77957a7', N'0a470578-d79a-457c-961a-cb2ec017c9a5', N'5bc086d7-538e-4cbf-8d82-0ce725e6bc11', N'43c6ee07-e1a0-4427-94b8-924cf566fca7')
INSERT [dbo].[Item] ([id], [Name], [Description], [CategoryID], [BrandID], [ManufCountryID], [BrandCOuntryID]) VALUES (N'1bd1f90c-91ee-4e26-a67b-4130b6caa96e', N'ex48', N'Some description about bass strings here', N'78f331b0-5a0f-4d74-9976-933b33410a08', N'0a470578-d79a-457c-961a-cb2ec017c9a5', N'3c2a50de-9dca-4435-8342-1f3e14bc1577', N'35fcd710-1c9b-4c5b-8566-4dcdc4bf3a5e')
INSERT [dbo].[Item] ([id], [Name], [Description], [CategoryID], [BrandID], [ManufCountryID], [BrandCOuntryID]) VALUES (N'0b50430e-6a2f-4b84-8c99-499dd88bee2a', N'stratocaster', N'Some description about electro guitar here', N'f0c77461-a40f-4236-ab8f-33c3d77957a7', N'95197f9c-ff80-4c6b-822c-412e6966f3df', N'3c2a50de-9dca-4435-8342-1f3e14bc1577', N'35fcd710-1c9b-4c5b-8566-4dcdc4bf3a5e')
INSERT [dbo].[Item] ([id], [Name], [Description], [CategoryID], [BrandID], [ManufCountryID], [BrandCOuntryID]) VALUES (N'5f09c75b-bcae-4083-aad4-4bb9eab2080b', N'b72', N'Some description about guitar amp here', N'c82701c8-6d0c-41b8-a333-883d97da8417', N'95197f9c-ff80-4c6b-822c-412e6966f3df', N'3c2a50de-9dca-4435-8342-1f3e14bc1577', N'35fcd710-1c9b-4c5b-8566-4dcdc4bf3a5e')
INSERT [dbo].[Item] ([id], [Name], [Description], [CategoryID], [BrandID], [ManufCountryID], [BrandCOuntryID]) VALUES (N'86e0f3f9-747d-4099-862e-5b80c100eb1d', N'superstart', N'Some description about electro guitar here', N'f0c77461-a40f-4236-ab8f-33c3d77957a7', N'95197f9c-ff80-4c6b-822c-412e6966f3df', N'3c2a50de-9dca-4435-8342-1f3e14bc1577', N'35fcd710-1c9b-4c5b-8566-4dcdc4bf3a5e')
INSERT [dbo].[Item] ([id], [Name], [Description], [CategoryID], [BrandID], [ManufCountryID], [BrandCOuntryID]) VALUES (N'ce2d114d-effe-4d66-b31c-6d06cf762cb3', N'b567', N'Some description about acoust strings here', N'dceb450d-5b28-4dfe-9a71-eea1da33b0a7', N'6da6f476-4795-4130-a7b8-2b32e7c54f61', N'3c2a50de-9dca-4435-8342-1f3e14bc1577', N'35fcd710-1c9b-4c5b-8566-4dcdc4bf3a5e')
INSERT [dbo].[Item] ([id], [Name], [Description], [CategoryID], [BrandID], [ManufCountryID], [BrandCOuntryID]) VALUES (N'65f8b9d4-210d-48dc-b14b-7483d7f66148', N'vortex deluxe', N'Some description about bass guitar here', N'bc66c044-54c6-42d0-978d-191e21f3d8ee', N'5eaf6c25-5aaf-46c4-b302-112e1fa74af3', N'3c2a50de-9dca-4435-8342-1f3e14bc1577', N'35fcd710-1c9b-4c5b-8566-4dcdc4bf3a5e')
INSERT [dbo].[Item] ([id], [Name], [Description], [CategoryID], [BrandID], [ManufCountryID], [BrandCOuntryID]) VALUES (N'cc21727f-0def-4c23-8a7f-7bbe2d799e1b', N'telekast', N'Some description about electro guitar here', N'f0c77461-a40f-4236-ab8f-33c3d77957a7', N'95197f9c-ff80-4c6b-822c-412e6966f3df', N'3c2a50de-9dca-4435-8342-1f3e14bc1577', N'35fcd710-1c9b-4c5b-8566-4dcdc4bf3a5e')
INSERT [dbo].[Item] ([id], [Name], [Description], [CategoryID], [BrandID], [ManufCountryID], [BrandCOuntryID]) VALUES (N'5ca2919c-50f4-4035-aad9-8cb93838060b', N'A74', N'Some description about guitar amp here', N'f869a9e7-47d1-4bd7-b371-82e291875653', N'95197f9c-ff80-4c6b-822c-412e6966f3df', N'35fcd710-1c9b-4c5b-8566-4dcdc4bf3a5e', N'3c2a50de-9dca-4435-8342-1f3e14bc1577')
INSERT [dbo].[Item] ([id], [Name], [Description], [CategoryID], [BrandID], [ManufCountryID], [BrandCOuntryID]) VALUES (N'ae650fe3-ce0e-44f6-b8f7-8eadd7b7523c', N'pro5', N'Some description about bass guitar here', N'81b0c6b9-9d72-420e-85e8-b362f9a6401c', N'a111ed0e-0960-44a1-bbdc-12678b7ad31b', N'35fcd710-1c9b-4c5b-8566-4dcdc4bf3a5e', N'3c2a50de-9dca-4435-8342-1f3e14bc1577')
INSERT [dbo].[Item] ([id], [Name], [Description], [CategoryID], [BrandID], [ManufCountryID], [BrandCOuntryID]) VALUES (N'9a2ad4ef-b25f-4760-988a-966872c6d738', N'r58', N'Some description about electro strings here', N'7b763f67-92d0-4a63-81c5-9f1b30775219', N'95197f9c-ff80-4c6b-822c-412e6966f3df', N'35fcd710-1c9b-4c5b-8566-4dcdc4bf3a5e', N'3c2a50de-9dca-4435-8342-1f3e14bc1577')
INSERT [dbo].[Item] ([id], [Name], [Description], [CategoryID], [BrandID], [ManufCountryID], [BrandCOuntryID]) VALUES (N'b28d3612-ff08-4fa8-a1f6-9a7e77d89e17', N'b5', N'Some description about bass guitar here', N'dee1eeca-7cab-423f-84c0-03da47661a68', N'93dfda45-13ce-4a36-9d20-dc0720f25e53', N'35fcd710-1c9b-4c5b-8566-4dcdc4bf3a5e', N'3c2a50de-9dca-4435-8342-1f3e14bc1577')
INSERT [dbo].[Item] ([id], [Name], [Description], [CategoryID], [BrandID], [ManufCountryID], [BrandCOuntryID]) VALUES (N'e5413b49-7e01-47c5-a60e-b43fb5b94543', N's52', N'Some description about bass strings here', N'78f331b0-5a0f-4d74-9976-933b33410a08', N'93dfda45-13ce-4a36-9d20-dc0720f25e53', N'35fcd710-1c9b-4c5b-8566-4dcdc4bf3a5e', N'3c2a50de-9dca-4435-8342-1f3e14bc1577')
INSERT [dbo].[Item] ([id], [Name], [Description], [CategoryID], [BrandID], [ManufCountryID], [BrandCOuntryID]) VALUES (N'48e234bb-cf39-4a27-ad6a-b45342a49963', N'RG4', N'Some description about bass guitar here', N'81b0c6b9-9d72-420e-85e8-b362f9a6401c', N'818ac158-7eed-4339-a501-9164d6a99890', N'43c6ee07-e1a0-4427-94b8-924cf566fca7', N'5bc086d7-538e-4cbf-8d82-0ce725e6bc11')
INSERT [dbo].[Item] ([id], [Name], [Description], [CategoryID], [BrandID], [ManufCountryID], [BrandCOuntryID]) VALUES (N'2c0a4cee-fe3e-47b3-928f-c1e9ffce1075', N'n58', N'Some description about acoust strings here', N'dceb450d-5b28-4dfe-9a71-eea1da33b0a7', N'47dbf889-23a4-4c9d-b7f5-d63ef5eb542b', N'43c6ee07-e1a0-4427-94b8-924cf566fca7', N'5bc086d7-538e-4cbf-8d82-0ce725e6bc11')
INSERT [dbo].[Item] ([id], [Name], [Description], [CategoryID], [BrandID], [ManufCountryID], [BrandCOuntryID]) VALUES (N'814a6d0d-fac9-4c0e-af3f-ca6cda4c5695', N'r52', N'Some description about electro strings here', N'7b763f67-92d0-4a63-81c5-9f1b30775219', N'5eaf6c25-5aaf-46c4-b302-112e1fa74af3', N'43c6ee07-e1a0-4427-94b8-924cf566fca7', N'5bc086d7-538e-4cbf-8d82-0ce725e6bc11')
INSERT [dbo].[Item] ([id], [Name], [Description], [CategoryID], [BrandID], [ManufCountryID], [BrandCOuntryID]) VALUES (N'242578f8-7935-4a53-b80d-e010c3176ab7', N'jd56', N'Some description about bass guitar here', N'dee1eeca-7cab-423f-84c0-03da47661a68', N'3e728b39-b3d9-4d1f-9263-16172d529393', N'43c6ee07-e1a0-4427-94b8-924cf566fca7', N'5bc086d7-538e-4cbf-8d82-0ce725e6bc11')
INSERT [dbo].[Item] ([id], [Name], [Description], [CategoryID], [BrandID], [ManufCountryID], [BrandCOuntryID]) VALUES (N'2e4c9eac-1ce3-483c-ba1e-ea9c0d941a2e', N'b722', N'Some description about guitar amp here', N'c82701c8-6d0c-41b8-a333-883d97da8417', N'0a470578-d79a-457c-961a-cb2ec017c9a5', N'43c6ee07-e1a0-4427-94b8-924cf566fca7', N'5bc086d7-538e-4cbf-8d82-0ce725e6bc11')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'4c1ee060-572f-4044-bd28-00753b8bc179', N'da4aff3c-7aee-4a64-be3d-28024ecdc376', N'447aadff-1b3f-4ab9-9b44-178534768a5b', N'a5c91041-a89e-4c30-b4b9-14d4721fa146')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'80ab236d-ba8e-4d35-8df6-0441486d176d', N'9bf5d47f-f356-43a3-8104-28abcaa9112a', N'92e998ec-4257-4efe-b864-24bc3fb9561a', N'b28f3716-c6c0-4f57-a60e-8d43ad7369cf')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'fd1e358b-1b39-4bf0-a5a9-04f2aa468bff', N'814a6d0d-fac9-4c0e-af3f-ca6cda4c5695', N'865e4c63-b3fe-4061-a4d4-60cf078f550a', N'506b2d83-91b8-4476-bb49-5683635904f4')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'7cbb0da2-0127-48da-9b20-06d37845e418', N'0b50430e-6a2f-4b84-8c99-499dd88bee2a', N'6e947e49-e56b-47ac-a8e6-dcac7ea53bee', N'e25ef1aa-9fef-45bb-89e0-c99384b1804f')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'b74466d6-a7c5-4dff-a28f-07144ed99e49', N'983496eb-465f-4d29-8aa0-080a729997ec', N'b9bfbf38-a510-4d9a-b1a4-ec10f8e9b970', N'adb82fa6-1f9c-4b03-ba24-4eaf0dda403a')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'eec66d19-df9f-40eb-99fb-093bbee38825', N'e5413b49-7e01-47c5-a60e-b43fb5b94543', N'865e4c63-b3fe-4061-a4d4-60cf078f550a', N'39e96f0c-8824-4164-b27f-63b567d95736')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'80bc59f4-26c1-481f-9b02-0c760b32daa5', N'65f8b9d4-210d-48dc-b14b-7483d7f66148', N'ab47b388-1c6f-487c-838b-6ba1f39674f3', N'7e0724e6-75ff-4574-9cc5-3bd88a8a7e07')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'f291dd4c-575e-4164-8310-114ea53a766c', N'9a2ad4ef-b25f-4760-988a-966872c6d738', N'865e4c63-b3fe-4061-a4d4-60cf078f550a', N'506b2d83-91b8-4476-bb49-5683635904f4')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'33c722f4-190a-4067-ac0a-116ea98fce4b', N'ae650fe3-ce0e-44f6-b8f7-8eadd7b7523c', N'b9bfbf38-a510-4d9a-b1a4-ec10f8e9b970', N'1196cf3a-200a-4c5e-aca4-019fdc28ccd7')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'e3f8102f-8363-4062-ba9a-12b869f30e28', N'0b50430e-6a2f-4b84-8c99-499dd88bee2a', N'7eb967cf-9289-4b8b-9e54-ce7b2c986c00', N'19ee3be3-9506-40c2-af66-07cc57d1f4a2')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'b713ad93-4025-417f-ac11-141190d3a658', N'e5413b49-7e01-47c5-a60e-b43fb5b94543', N'd7a10659-41ec-4fe2-be90-da982afad260', N'be4dbd23-6d8d-40c8-9bfa-18e315dbe24f')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'543145b6-eafb-4d28-bfc5-152060c0572e', N'9bf5d47f-f356-43a3-8104-28abcaa9112a', N'8f7e02e9-5b1b-46c2-983d-937187903d4c', N'b696f242-ef4a-4d6e-9cfe-ba8179895513')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'56eb668a-aecb-4f26-967f-1556de075b46', N'9bf5d47f-f356-43a3-8104-28abcaa9112a', N'447aadff-1b3f-4ab9-9b44-178534768a5b', N'2932b323-7089-4a2b-8f78-2cd917af9877')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'b67cda0a-af8d-4ea5-904e-189e459e35aa', N'73956afa-1669-4740-88b2-3df5f4851ff3', N'46098154-9e3a-4a06-b5b9-41eaff3c0b94', N'09c65750-4b7d-4e6a-8b0e-5cbfff20e26f')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'69ac1343-7e03-4551-b2fe-1f3a8b17b489', N'242578f8-7935-4a53-b80d-e010c3176ab7', N'ab47b388-1c6f-487c-838b-6ba1f39674f3', N'77126016-d1c5-4949-ad2b-ed1a0437f91d')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'63843954-dde1-499b-ab4e-1fab8599fd65', N'9bf5d47f-f356-43a3-8104-28abcaa9112a', N'46098154-9e3a-4a06-b5b9-41eaff3c0b94', N'09c65750-4b7d-4e6a-8b0e-5cbfff20e26f')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'0ce47de0-4653-4588-bfee-217301223244', N'983496eb-465f-4d29-8aa0-080a729997ec', N'ab47b388-1c6f-487c-838b-6ba1f39674f3', N'94488d23-3fa9-4a58-9c4b-a87dbb08e95f')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'3e96c469-44ed-410b-9a52-2342b90d16aa', N'da4aff3c-7aee-4a64-be3d-28024ecdc376', N'd7a10659-41ec-4fe2-be90-da982afad260', N'16914268-b6c4-4316-af07-547a669273a6')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'0ef304f9-64d2-4db3-bf77-2bd97eeb8e50', N'ae650fe3-ce0e-44f6-b8f7-8eadd7b7523c', N'46098154-9e3a-4a06-b5b9-41eaff3c0b94', N'e50c5340-a88d-45a1-a20a-eb2b96052fac')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'44acb5e4-69f4-4ed0-9394-2bfc5021f35b', N'da4aff3c-7aee-4a64-be3d-28024ecdc376', N'b9bfbf38-a510-4d9a-b1a4-ec10f8e9b970', N'1196cf3a-200a-4c5e-aca4-019fdc28ccd7')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'8560b96f-7473-46ec-aa05-2e7d9232c2ba', N'9bf5d47f-f356-43a3-8104-28abcaa9112a', N'1793b40b-4dc1-4f04-96dc-16190ce74d8c', N'f4cca812-9eac-4aac-b6a0-f9cf3bb9a416')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'22b4b489-fd87-4baa-afb2-2e82fbc73d64', N'242578f8-7935-4a53-b80d-e010c3176ab7', N'92e998ec-4257-4efe-b864-24bc3fb9561a', N'a3fea846-237b-465a-93d5-7ff4d3ab88d8')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'56792de3-6b0e-459e-8dc4-2ef36cf87735', N'0b50430e-6a2f-4b84-8c99-499dd88bee2a', N'447aadff-1b3f-4ab9-9b44-178534768a5b', N'a5c91041-a89e-4c30-b4b9-14d4721fa146')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'f913d67b-1b1f-44d3-8348-2f6dcdca2367', N'2c0a4cee-fe3e-47b3-928f-c1e9ffce1075', N'865e4c63-b3fe-4061-a4d4-60cf078f550a', N'051bcbbe-fd71-4bad-9aa5-9129ba4dd0b8')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'683d9d08-747b-48a8-bc8c-314558f02956', N'242578f8-7935-4a53-b80d-e010c3176ab7', N'b9bfbf38-a510-4d9a-b1a4-ec10f8e9b970', N'd0fd662e-755e-4eb1-98a4-746aa4435af1')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'36dcc50f-ee73-4919-a022-3471a44068e0', N'48e234bb-cf39-4a27-ad6a-b45342a49963', N'ab47b388-1c6f-487c-838b-6ba1f39674f3', N'94488d23-3fa9-4a58-9c4b-a87dbb08e95f')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'9b5b9038-0b07-49c7-b731-34c761f4e312', N'0b50430e-6a2f-4b84-8c99-499dd88bee2a', N'8f7e02e9-5b1b-46c2-983d-937187903d4c', N'b696f242-ef4a-4d6e-9cfe-ba8179895513')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'712df6b9-fa72-4ac5-bab8-36f18f543339', N'5ca2919c-50f4-4035-aad9-8cb93838060b', N'd2f66dff-85ea-456d-829b-6b772781cb31', N'7c2c469a-dabb-4aae-88ad-eaee7040890a')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'c10fe7e6-98b0-457c-887d-3779f261e8df', N'1bd1f90c-91ee-4e26-a67b-4130b6caa96e', N'865e4c63-b3fe-4061-a4d4-60cf078f550a', N'39e96f0c-8824-4164-b27f-63b567d95736')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'ab4b2fe3-02c6-4482-9f13-38a917565826', N'ae650fe3-ce0e-44f6-b8f7-8eadd7b7523c', N'7eb967cf-9289-4b8b-9e54-ce7b2c986c00', N'40da8a30-2de8-4b86-a0bb-ea16a7fc96a1')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'6552b83b-1de1-46ac-9733-39fe1bb66a9b', N'0b50430e-6a2f-4b84-8c99-499dd88bee2a', N'b9bfbf38-a510-4d9a-b1a4-ec10f8e9b970', N'1196cf3a-200a-4c5e-aca4-019fdc28ccd7')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'731afd82-e7dd-4fe0-9178-3c3bdedeaf01', N'48e234bb-cf39-4a27-ad6a-b45342a49963', N'447aadff-1b3f-4ab9-9b44-178534768a5b', N'a5c91041-a89e-4c30-b4b9-14d4721fa146')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'b76863fe-af24-46aa-84a2-3cc0197a264c', N'983496eb-465f-4d29-8aa0-080a729997ec', N'8f7e02e9-5b1b-46c2-983d-937187903d4c', N'b696f242-ef4a-4d6e-9cfe-ba8179895513')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'05ce1706-1a66-4317-8004-420d9afd4e65', N'9bf5d47f-f356-43a3-8104-28abcaa9112a', N'ab47b388-1c6f-487c-838b-6ba1f39674f3', N'77126016-d1c5-4949-ad2b-ed1a0437f91d')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'd274ee2c-d922-492c-a473-4ac7cc22c246', N'65f8b9d4-210d-48dc-b14b-7483d7f66148', N'8f7e02e9-5b1b-46c2-983d-937187903d4c', N'711929d0-eba4-4074-b2cc-616e0e8cfbee')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'e00257f4-0eb3-42f6-9135-4c6af2226407', N'b28d3612-ff08-4fa8-a1f6-9a7e77d89e17', N'92e998ec-4257-4efe-b864-24bc3fb9561a', N'b28f3716-c6c0-4f57-a60e-8d43ad7369cf')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'bcfc7a44-2ae2-4acd-8ce2-4d1dda855431', N'da4aff3c-7aee-4a64-be3d-28024ecdc376', N'1793b40b-4dc1-4f04-96dc-16190ce74d8c', N'f4cca812-9eac-4aac-b6a0-f9cf3bb9a416')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'3d6644c6-85c4-4427-a07b-4e4eddaa4710', N'48e234bb-cf39-4a27-ad6a-b45342a49963', N'92e998ec-4257-4efe-b864-24bc3fb9561a', N'e1f06b55-0244-4550-8ff9-8d6dd8649210')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'99ab12d5-efa9-41b9-aabc-54a7e1c7b5a1', N'242578f8-7935-4a53-b80d-e010c3176ab7', N'6e947e49-e56b-47ac-a8e6-dcac7ea53bee', N'e25ef1aa-9fef-45bb-89e0-c99384b1804f')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'32f22393-8656-48a2-9574-57d991ea11e6', N'242578f8-7935-4a53-b80d-e010c3176ab7', N'8f7e02e9-5b1b-46c2-983d-937187903d4c', N'8608e72c-f1d6-4ba4-b5f6-7b8845298227')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'7184fe84-c302-4606-8665-58f380393e6e', N'da4aff3c-7aee-4a64-be3d-28024ecdc376', N'8f7e02e9-5b1b-46c2-983d-937187903d4c', N'742da97f-f13f-4762-8811-7af22ba0b9b9')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'87829ab1-6be0-4831-86d4-5aa6726051e1', N'73956afa-1669-4740-88b2-3df5f4851ff3', N'8f7e02e9-5b1b-46c2-983d-937187903d4c', N'd3975bce-0998-4d64-8fce-ddd56e15d9ca')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'63608069-db2d-4018-8c53-5d24b2d42a89', N'e5413b49-7e01-47c5-a60e-b43fb5b94543', N'6e947e49-e56b-47ac-a8e6-dcac7ea53bee', N'e25ef1aa-9fef-45bb-89e0-c99384b1804f')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'ae0f812a-968a-4bbc-9974-5fbb22002de9', N'48e234bb-cf39-4a27-ad6a-b45342a49963', N'8f7e02e9-5b1b-46c2-983d-937187903d4c', N'51539602-982e-4786-b4e7-6b68b546834b')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'712cdee9-7f1f-49a5-908c-60f1467bd6fa', N'983496eb-465f-4d29-8aa0-080a729997ec', N'd7a10659-41ec-4fe2-be90-da982afad260', N'9d676496-1081-489b-be7b-732ee68025a1')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'c927f7ac-84a3-4545-9b41-61d77e8cc162', N'e5413b49-7e01-47c5-a60e-b43fb5b94543', N'b9bfbf38-a510-4d9a-b1a4-ec10f8e9b970', N'd0fd662e-755e-4eb1-98a4-746aa4435af1')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'334e43d5-6adc-42ac-9721-62750a397727', N'ae650fe3-ce0e-44f6-b8f7-8eadd7b7523c', N'6e947e49-e56b-47ac-a8e6-dcac7ea53bee', N'ced66cb1-f45e-4bed-8942-d8f29dc3bf00')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'9fec36e9-278e-455a-91e2-62cb2deda0c9', N'b28d3612-ff08-4fa8-a1f6-9a7e77d89e17', N'8f7e02e9-5b1b-46c2-983d-937187903d4c', N'51539602-982e-4786-b4e7-6b68b546834b')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'6bf27e67-40c6-4b4c-96fb-63b52edff418', N'0b50430e-6a2f-4b84-8c99-499dd88bee2a', N'd7a10659-41ec-4fe2-be90-da982afad260', N'16914268-b6c4-4316-af07-547a669273a6')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'83937d0a-ea34-4838-947f-65edd2decaf1', N'983496eb-465f-4d29-8aa0-080a729997ec', N'46098154-9e3a-4a06-b5b9-41eaff3c0b94', N'09c65750-4b7d-4e6a-8b0e-5cbfff20e26f')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'c38a2201-06e3-4c1e-aa66-665dfb055c94', N'0b50430e-6a2f-4b84-8c99-499dd88bee2a', N'92e998ec-4257-4efe-b864-24bc3fb9561a', N'f4f35b3c-d546-4430-bdac-4232e3e83eb6')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'110c5252-7863-4925-ba84-673398ae0d1f', N'814a6d0d-fac9-4c0e-af3f-ca6cda4c5695', N'46098154-9e3a-4a06-b5b9-41eaff3c0b94', N'1de783bc-ae8d-4e46-87cb-85431c70a5da')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'bec7dcca-15aa-4bf1-aa51-68f67b41ed3e', N'73956afa-1669-4740-88b2-3df5f4851ff3', N'd7a10659-41ec-4fe2-be90-da982afad260', N'9d676496-1081-489b-be7b-732ee68025a1')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'a6be2990-0412-4410-8803-6a64396436ac', N'73956afa-1669-4740-88b2-3df5f4851ff3', N'6e947e49-e56b-47ac-a8e6-dcac7ea53bee', N'e25ef1aa-9fef-45bb-89e0-c99384b1804f')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'09dfcf7c-6257-4ce0-b5f3-6c3d7b41bf86', N'65f8b9d4-210d-48dc-b14b-7483d7f66148', N'b9bfbf38-a510-4d9a-b1a4-ec10f8e9b970', N'adb82fa6-1f9c-4b03-ba24-4eaf0dda403a')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'47042787-9910-47a5-bc04-6efd0a5d3a4a', N'ae650fe3-ce0e-44f6-b8f7-8eadd7b7523c', N'1793b40b-4dc1-4f04-96dc-16190ce74d8c', N'f4cca812-9eac-4aac-b6a0-f9cf3bb9a416')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'2029996f-ac8f-4373-a107-72d3618e870c', N'48e234bb-cf39-4a27-ad6a-b45342a49963', N'46098154-9e3a-4a06-b5b9-41eaff3c0b94', N'2a503ce7-6faf-4e2d-9217-c20a2f546ca8')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'3e92d3ab-89b7-4e90-b358-79103731f9e3', N'0b50430e-6a2f-4b84-8c99-499dd88bee2a', N'ab47b388-1c6f-487c-838b-6ba1f39674f3', N'7e0724e6-75ff-4574-9cc5-3bd88a8a7e07')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'2a4f85a3-3822-4432-8d71-791468c03ba0', N'73956afa-1669-4740-88b2-3df5f4851ff3', N'b9bfbf38-a510-4d9a-b1a4-ec10f8e9b970', N'adb82fa6-1f9c-4b03-ba24-4eaf0dda403a')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'b3b62f44-b420-488a-90e9-7b8276713d1b', N'983496eb-465f-4d29-8aa0-080a729997ec', N'6e947e49-e56b-47ac-a8e6-dcac7ea53bee', N'e25ef1aa-9fef-45bb-89e0-c99384b1804f')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'498fe3dd-c0e4-4587-8055-7d8d99a418c4', N'9bf5d47f-f356-43a3-8104-28abcaa9112a', N'b9bfbf38-a510-4d9a-b1a4-ec10f8e9b970', N'adb82fa6-1f9c-4b03-ba24-4eaf0dda403a')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'0236c9c5-5c32-4aca-9cc3-7e86c65d64be', N'2c0a4cee-fe3e-47b3-928f-c1e9ffce1075', N'46098154-9e3a-4a06-b5b9-41eaff3c0b94', N'09c65750-4b7d-4e6a-8b0e-5cbfff20e26f')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'de16ca34-8041-4b70-9a95-7fb405fa11f0', N'983496eb-465f-4d29-8aa0-080a729997ec', N'447aadff-1b3f-4ab9-9b44-178534768a5b', N'a5c91041-a89e-4c30-b4b9-14d4721fa146')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'dbf10e04-638e-4845-9eda-805ed6b7b0e8', N'242578f8-7935-4a53-b80d-e010c3176ab7', N'd7a10659-41ec-4fe2-be90-da982afad260', N'9d676496-1081-489b-be7b-732ee68025a1')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'95499ec0-e969-405f-8de7-81ea0a7b33fd', N'2e4c9eac-1ce3-483c-ba1e-ea9c0d941a2e', N'd2f66dff-85ea-456d-829b-6b772781cb31', N'7c2c469a-dabb-4aae-88ad-eaee7040890a')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'811a4af5-d0eb-42c6-b3bd-860060a6284e', N'65f8b9d4-210d-48dc-b14b-7483d7f66148', N'46098154-9e3a-4a06-b5b9-41eaff3c0b94', N'e50c5340-a88d-45a1-a20a-eb2b96052fac')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'2bbb50b9-e887-46f0-95cd-867c0cb4d7f4', N'48e234bb-cf39-4a27-ad6a-b45342a49963', N'b9bfbf38-a510-4d9a-b1a4-ec10f8e9b970', N'd0fd662e-755e-4eb1-98a4-746aa4435af1')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'e1d01974-c2ea-4966-9538-8be99244284b', N'73956afa-1669-4740-88b2-3df5f4851ff3', N'92e998ec-4257-4efe-b864-24bc3fb9561a', N'b28f3716-c6c0-4f57-a60e-8d43ad7369cf')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'4ab089fc-c0f6-43da-be2d-8f6c84d648b7', N'983496eb-465f-4d29-8aa0-080a729997ec', N'92e998ec-4257-4efe-b864-24bc3fb9561a', N'e1f06b55-0244-4550-8ff9-8d6dd8649210')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'688956ab-fa93-405e-b50d-904a29766c87', N'242578f8-7935-4a53-b80d-e010c3176ab7', N'46098154-9e3a-4a06-b5b9-41eaff3c0b94', N'2a503ce7-6faf-4e2d-9217-c20a2f546ca8')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'e320baff-faf0-4495-978c-91d02e16b78a', N'9bf5d47f-f356-43a3-8104-28abcaa9112a', N'6e947e49-e56b-47ac-a8e6-dcac7ea53bee', N'ced66cb1-f45e-4bed-8942-d8f29dc3bf00')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'90f74590-34a4-42a2-9f13-93f08f93b801', N'ae650fe3-ce0e-44f6-b8f7-8eadd7b7523c', N'8f7e02e9-5b1b-46c2-983d-937187903d4c', N'8608e72c-f1d6-4ba4-b5f6-7b8845298227')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'726eae20-48aa-4e5f-b32f-9619e4ad4c01', N'2191688b-e599-4dbe-81c5-33d21ac69c21', N'd2f66dff-85ea-456d-829b-6b772781cb31', N'63826e16-d395-4545-8fef-78a22644e421')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'c1231f4e-5071-4176-9500-985fd15f5872', N'48e234bb-cf39-4a27-ad6a-b45342a49963', N'7eb967cf-9289-4b8b-9e54-ce7b2c986c00', N'40da8a30-2de8-4b86-a0bb-ea16a7fc96a1')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'c8d6d7b4-34f2-4f60-92ce-996357d20c80', N'48e234bb-cf39-4a27-ad6a-b45342a49963', N'1793b40b-4dc1-4f04-96dc-16190ce74d8c', N'f4cca812-9eac-4aac-b6a0-f9cf3bb9a416')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'a3c96e38-b29e-4880-b489-9acff3e83802', N'65f8b9d4-210d-48dc-b14b-7483d7f66148', N'447aadff-1b3f-4ab9-9b44-178534768a5b', N'4ecc491e-950e-4551-89ed-2d30e61185c1')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'9798553a-1118-49ed-8c99-9b1ccc78a9e7', N'ce2d114d-effe-4d66-b31c-6d06cf762cb3', N'46098154-9e3a-4a06-b5b9-41eaff3c0b94', N'09c65750-4b7d-4e6a-8b0e-5cbfff20e26f')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'e6c2cbb9-54e3-42b7-958e-9d6c5421bf95', N'65f8b9d4-210d-48dc-b14b-7483d7f66148', N'7eb967cf-9289-4b8b-9e54-ce7b2c986c00', N'40da8a30-2de8-4b86-a0bb-ea16a7fc96a1')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'b7546293-aec8-45ee-b6fa-9fe98ffbf88c', N'e5413b49-7e01-47c5-a60e-b43fb5b94543', N'46098154-9e3a-4a06-b5b9-41eaff3c0b94', N'dee1f2af-a514-4a4a-9178-a5394c7ae9ea')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'5fc1eade-87df-4b8e-ae82-a2608c1971c6', N'ae650fe3-ce0e-44f6-b8f7-8eadd7b7523c', N'ab47b388-1c6f-487c-838b-6ba1f39674f3', N'7e0724e6-75ff-4574-9cc5-3bd88a8a7e07')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'f5757686-71e1-4957-b70e-a38c7a002986', N'0b50430e-6a2f-4b84-8c99-499dd88bee2a', N'46098154-9e3a-4a06-b5b9-41eaff3c0b94', N'09c65750-4b7d-4e6a-8b0e-5cbfff20e26f')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'7040c736-4f66-46d4-a47d-a5fde255a016', N'1bd1f90c-91ee-4e26-a67b-4130b6caa96e', N'46098154-9e3a-4a06-b5b9-41eaff3c0b94', N'dee1f2af-a514-4a4a-9178-a5394c7ae9ea')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'53083c95-6898-40c4-b25e-a87eff511210', N'73956afa-1669-4740-88b2-3df5f4851ff3', N'447aadff-1b3f-4ab9-9b44-178534768a5b', N'2932b323-7089-4a2b-8f78-2cd917af9877')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'c65a2ebb-4bb5-4434-a9d6-a99217c8cc2b', N'65f8b9d4-210d-48dc-b14b-7483d7f66148', N'd7a10659-41ec-4fe2-be90-da982afad260', N'be4dbd23-6d8d-40c8-9bfa-18e315dbe24f')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'6b698f4d-3543-429d-b1b2-a9a9b4431573', N'242578f8-7935-4a53-b80d-e010c3176ab7', N'1793b40b-4dc1-4f04-96dc-16190ce74d8c', N'f4cca812-9eac-4aac-b6a0-f9cf3bb9a416')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'f7f77dbd-19fd-48e3-b002-aab61e758f03', N'0b50430e-6a2f-4b84-8c99-499dd88bee2a', N'1793b40b-4dc1-4f04-96dc-16190ce74d8c', N'5b2e2a78-8727-40f9-a8db-6b9ddb3ea660')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'cab18693-6efa-4291-bd59-ab75194439ba', N'e5413b49-7e01-47c5-a60e-b43fb5b94543', N'ab47b388-1c6f-487c-838b-6ba1f39674f3', N'7e0724e6-75ff-4574-9cc5-3bd88a8a7e07')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'448bd65c-7bf3-4117-b6c2-ae2e248d1500', N'9bf5d47f-f356-43a3-8104-28abcaa9112a', N'd7a10659-41ec-4fe2-be90-da982afad260', N'5ec7d3cf-7cd1-4b09-81ad-ea5662419900')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'3d2097a9-8c76-4f33-a6d6-b1eb9d22302c', N'ae650fe3-ce0e-44f6-b8f7-8eadd7b7523c', N'd7a10659-41ec-4fe2-be90-da982afad260', N'be4dbd23-6d8d-40c8-9bfa-18e315dbe24f')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'f86288ce-2c71-4ea5-9ddc-b2f91c34a30e', N'65f8b9d4-210d-48dc-b14b-7483d7f66148', N'6e947e49-e56b-47ac-a8e6-dcac7ea53bee', N'ced66cb1-f45e-4bed-8942-d8f29dc3bf00')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'd232ff39-38d2-4a45-8f88-b4b04888b56c', N'65f8b9d4-210d-48dc-b14b-7483d7f66148', N'92e998ec-4257-4efe-b864-24bc3fb9561a', N'e1f06b55-0244-4550-8ff9-8d6dd8649210')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'40913a0b-7c24-4b7d-9aed-b67f0f6624db', N'65f8b9d4-210d-48dc-b14b-7483d7f66148', N'1793b40b-4dc1-4f04-96dc-16190ce74d8c', N'5b2e2a78-8727-40f9-a8db-6b9ddb3ea660')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'6233448a-ccf6-445d-b106-ba3fd77e55ce', N'983496eb-465f-4d29-8aa0-080a729997ec', N'1793b40b-4dc1-4f04-96dc-16190ce74d8c', N'5b2e2a78-8727-40f9-a8db-6b9ddb3ea660')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'0d5fb50c-c3ca-4e02-b4e6-c67bd594c74d', N'da4aff3c-7aee-4a64-be3d-28024ecdc376', N'ab47b388-1c6f-487c-838b-6ba1f39674f3', N'77126016-d1c5-4949-ad2b-ed1a0437f91d')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'062ddbb9-c097-4c56-a4d0-cac8a2d819c7', N'73956afa-1669-4740-88b2-3df5f4851ff3', N'7eb967cf-9289-4b8b-9e54-ce7b2c986c00', N'40da8a30-2de8-4b86-a0bb-ea16a7fc96a1')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'069720c6-1b68-4d4d-bc72-ce76bbcd38a3', N'ce2d114d-effe-4d66-b31c-6d06cf762cb3', N'865e4c63-b3fe-4061-a4d4-60cf078f550a', N'051bcbbe-fd71-4bad-9aa5-9129ba4dd0b8')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'3e6dc7f6-7d8e-43f1-a65e-d64dc354140f', N'ae650fe3-ce0e-44f6-b8f7-8eadd7b7523c', N'92e998ec-4257-4efe-b864-24bc3fb9561a', N'e1f06b55-0244-4550-8ff9-8d6dd8649210')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'd23d2a9b-1cdb-4780-ab42-d7add4c2a44a', N'5f09c75b-bcae-4083-aad4-4bb9eab2080b', N'd2f66dff-85ea-456d-829b-6b772781cb31', N'63826e16-d395-4545-8fef-78a22644e421')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'5be7b328-fe13-433f-a797-d88fbe58fa70', N'da4aff3c-7aee-4a64-be3d-28024ecdc376', N'6e947e49-e56b-47ac-a8e6-dcac7ea53bee', N'ced66cb1-f45e-4bed-8942-d8f29dc3bf00')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'0520bfa4-3bf4-4843-b9a9-d958228b99fc', N'b28d3612-ff08-4fa8-a1f6-9a7e77d89e17', N'1793b40b-4dc1-4f04-96dc-16190ce74d8c', N'f4cca812-9eac-4aac-b6a0-f9cf3bb9a416')
GO
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'3bd592e4-e796-4f1b-a854-e0d625f2a000', N'b28d3612-ff08-4fa8-a1f6-9a7e77d89e17', N'46098154-9e3a-4a06-b5b9-41eaff3c0b94', N'e50c5340-a88d-45a1-a20a-eb2b96052fac')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'a9450f96-5446-4c10-b967-e3234410e93c', N'48e234bb-cf39-4a27-ad6a-b45342a49963', N'd7a10659-41ec-4fe2-be90-da982afad260', N'16914268-b6c4-4316-af07-547a669273a6')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'25e31681-8b35-4248-83c0-e4b93e901ba2', N'9bf5d47f-f356-43a3-8104-28abcaa9112a', N'7eb967cf-9289-4b8b-9e54-ce7b2c986c00', N'19ee3be3-9506-40c2-af66-07cc57d1f4a2')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'257b1a1d-cfb7-48f2-934b-e4d1d67503a3', N'242578f8-7935-4a53-b80d-e010c3176ab7', N'447aadff-1b3f-4ab9-9b44-178534768a5b', N'2932b323-7089-4a2b-8f78-2cd917af9877')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'42f89948-087c-4261-8af0-e7f952e7248f', N'48e234bb-cf39-4a27-ad6a-b45342a49963', N'6e947e49-e56b-47ac-a8e6-dcac7ea53bee', N'ced66cb1-f45e-4bed-8942-d8f29dc3bf00')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'e3d467a9-e510-473b-b3b2-eb439ca54155', N'73956afa-1669-4740-88b2-3df5f4851ff3', N'1793b40b-4dc1-4f04-96dc-16190ce74d8c', N'f4cca812-9eac-4aac-b6a0-f9cf3bb9a416')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'7a4d0024-a280-4b7f-9277-ed7f98727df6', N'da4aff3c-7aee-4a64-be3d-28024ecdc376', N'46098154-9e3a-4a06-b5b9-41eaff3c0b94', N'1de783bc-ae8d-4e46-87cb-85431c70a5da')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'ec3ded64-9320-4865-ba26-eedbf95318ca', N'b28d3612-ff08-4fa8-a1f6-9a7e77d89e17', N'46098154-9e3a-4a06-b5b9-41eaff3c0b94', N'e50c5340-a88d-45a1-a20a-eb2b96052fac')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'dea7f2e4-8422-43f3-b1ce-f3aa0632c879', N'da4aff3c-7aee-4a64-be3d-28024ecdc376', N'92e998ec-4257-4efe-b864-24bc3fb9561a', N'acc47863-6331-45a3-9255-d63be26baa54')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'06b26334-faa4-46f6-a1d0-f3aedeee2608', N'73956afa-1669-4740-88b2-3df5f4851ff3', N'ab47b388-1c6f-487c-838b-6ba1f39674f3', N'77126016-d1c5-4949-ad2b-ed1a0437f91d')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'5fee75b5-f0ff-439e-8115-fc1312d72d60', N'e5413b49-7e01-47c5-a60e-b43fb5b94543', N'447aadff-1b3f-4ab9-9b44-178534768a5b', N'a5c91041-a89e-4c30-b4b9-14d4721fa146')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'760a86d8-70eb-4017-9230-fc97176aac6e', N'ae650fe3-ce0e-44f6-b8f7-8eadd7b7523c', N'447aadff-1b3f-4ab9-9b44-178534768a5b', N'2932b323-7089-4a2b-8f78-2cd917af9877')
INSERT [dbo].[ItemCharacteristics] ([id], [ItemID], [CharacteristicID], [CharVarID]) VALUES (N'b8d5ad93-f35b-4ff8-99af-fd2a84a6f1aa', N'9a2ad4ef-b25f-4760-988a-966872c6d738', N'46098154-9e3a-4a06-b5b9-41eaff3c0b94', N'1de783bc-ae8d-4e46-87cb-85431c70a5da')
INSERT [dbo].[Order] ([Id], [StatusId], [UserId], [Comment], [ContactId], [Name], [LastName], [Phone], [Address], [Number], [Date], [DeliveryTypeId], [email]) VALUES (N'6cbcfe70-15fd-4dcd-ad7d-358e1f6b20ec', N'bd0fab88-5764-4615-84b8-48e05155c9da', NULL, N'com com com', NULL, N'Alexey', N'Zheleznichenko', N'0930804261', N'st Peterburg', NULL, CAST(N'2017-07-13 23:40:47.773' AS DateTime), N'a9aa9401-cf27-4196-9d8e-35e15fce1445', N'AlexeyZheleznichenko@gmail.com')
INSERT [dbo].[Order] ([Id], [StatusId], [UserId], [Comment], [ContactId], [Name], [LastName], [Phone], [Address], [Number], [Date], [DeliveryTypeId], [email]) VALUES (N'c3b061e8-2700-4353-bfbb-41725a9ce7ef', N'bd0fab88-5764-4615-84b8-48e05155c9da', NULL, N'zzzzzzz', NULL, N'sdfsdfs', N'sdfsdfsdf', N'sdfsdfsdf', N'st Peterburg', NULL, CAST(N'2017-07-14 05:21:13.057' AS DateTime), N'4554d7f9-863a-48e3-8584-788ddb60dcb0', N'aaa@aaa.com.ua')
INSERT [dbo].[Order] ([Id], [StatusId], [UserId], [Comment], [ContactId], [Name], [LastName], [Phone], [Address], [Number], [Date], [DeliveryTypeId], [email]) VALUES (N'b953bba0-528f-4deb-bacd-a8f2134d04dd', N'bd0fab88-5764-4615-84b8-48e05155c9da', NULL, N'retererterterte etr erter ertert', NULL, N'Yuri', N'Hovanskiy', N'1234567', N'st Peterburg', NULL, CAST(N'2017-07-13 23:43:27.227' AS DateTime), N'4554d7f9-863a-48e3-8584-788ddb60dcb0', N'aaa@aaa.com.ua')
INSERT [dbo].[Order] ([Id], [StatusId], [UserId], [Comment], [ContactId], [Name], [LastName], [Phone], [Address], [Number], [Date], [DeliveryTypeId], [email]) VALUES (N'24310741-ff95-4bc9-b7ab-af50b3be7381', N'bd0fab88-5764-4615-84b8-48e05155c9da', NULL, N'asap', NULL, N'SomeName', N'SomeLastName', N'0991122333', N'SomeCity', NULL, CAST(N'2017-07-14 15:11:02.500' AS DateTime), N'a9aa9401-cf27-4196-9d8e-35e15fce1445', N'azaza@gmail.com')
INSERT [dbo].[Order] ([Id], [StatusId], [UserId], [Comment], [ContactId], [Name], [LastName], [Phone], [Address], [Number], [Date], [DeliveryTypeId], [email]) VALUES (N'ac7e5367-bd1b-4a2f-88cb-b9ff174a9807', N'bd0fab88-5764-4615-84b8-48e05155c9da', NULL, NULL, NULL, N'Dmitry', N'Volkovsky', N'0991677007', N'kiev someStreet', NULL, CAST(N'2017-07-14 14:28:21.143' AS DateTime), N'4554d7f9-863a-48e3-8584-788ddb60dcb0', N'dima.bleed@gmail.com')
INSERT [dbo].[Order] ([Id], [StatusId], [UserId], [Comment], [ContactId], [Name], [LastName], [Phone], [Address], [Number], [Date], [DeliveryTypeId], [email]) VALUES (N'1279eead-ef49-4139-9351-ca9f03806de8', N'bd0fab88-5764-4615-84b8-48e05155c9da', NULL, N'Govniht', NULL, N'Govno', N'Govnishen', N'666-66-66', N'govnishe', NULL, CAST(N'2017-07-15 14:45:42.680' AS DateTime), N'a9aa9401-cf27-4196-9d8e-35e15fce1445', N'govniwe@gov.no')
INSERT [dbo].[OrderItems] ([id], [ItemId], [purposePriceId], [OrderId], [count], [purposeId]) VALUES (N'abcf8b06-8a6a-49e1-82b8-1a02387283b9', N'9a2ad4ef-b25f-4760-988a-966872c6d738', N'09aa9159-2f95-4b50-a797-32655e9ef89f', N'b953bba0-528f-4deb-bacd-a8f2134d04dd', 1, N'91efdbc4-e48c-4405-a64b-6c108d36ec62')
INSERT [dbo].[OrderItems] ([id], [ItemId], [purposePriceId], [OrderId], [count], [purposeId]) VALUES (N'c338eeda-fdd3-4565-a84e-1cb971684e69', N'86e0f3f9-747d-4099-862e-5b80c100eb1d', N'9b808a74-91fe-4d6d-9f8e-328cbddecb6f', N'c3b061e8-2700-4353-bfbb-41725a9ce7ef', 2, N'89b15327-fd62-4e89-8370-1293e0a4cf08')
INSERT [dbo].[OrderItems] ([id], [ItemId], [purposePriceId], [OrderId], [count], [purposeId]) VALUES (N'0e0c6638-bedf-43e9-a904-476ac4ab5116', N'0b50430e-6a2f-4b84-8c99-499dd88bee2a', N'b6195700-a295-474b-bede-a08b07bb4c6e', N'6cbcfe70-15fd-4dcd-ad7d-358e1f6b20ec', 1, N'04e2bf52-09d6-4f77-9cfe-5edc8b820746')
INSERT [dbo].[OrderItems] ([id], [ItemId], [purposePriceId], [OrderId], [count], [purposeId]) VALUES (N'6bb7a61a-3c5b-49de-aac5-7651a4194d37', N'73956afa-1669-4740-88b2-3df5f4851ff3', N'8cb11dd5-cbaa-4b40-9fce-9e17b34aa31f', N'b953bba0-528f-4deb-bacd-a8f2134d04dd', 2, N'9ea5f70e-7c47-49d6-af6a-f840bf82524d')
INSERT [dbo].[OrderItems] ([id], [ItemId], [purposePriceId], [OrderId], [count], [purposeId]) VALUES (N'f1be969a-39ea-4c2b-8f4e-9c314256fc4d', N'0b50430e-6a2f-4b84-8c99-499dd88bee2a', N'b6195700-a295-474b-bede-a08b07bb4c6e', N'1279eead-ef49-4139-9351-ca9f03806de8', 1, N'04e2bf52-09d6-4f77-9cfe-5edc8b820746')
INSERT [dbo].[OrderItems] ([id], [ItemId], [purposePriceId], [OrderId], [count], [purposeId]) VALUES (N'fb261316-bd83-4187-bbfd-b4e1ed7ceaa7', N'da4aff3c-7aee-4a64-be3d-28024ecdc376', N'99812281-1615-42e2-8568-88ee055bd58e', N'1279eead-ef49-4139-9351-ca9f03806de8', 1, N'd9380ae2-00f5-41f8-a557-ecdd7a2071b0')
INSERT [dbo].[OrderItems] ([id], [ItemId], [purposePriceId], [OrderId], [count], [purposeId]) VALUES (N'cb4cef40-c2fe-45d7-81b6-de6954864eb3', N'b28d3612-ff08-4fa8-a1f6-9a7e77d89e17', N'edf9d52d-a4b0-41fd-b80f-7bd8cf9ed7ed', N'24310741-ff95-4bc9-b7ab-af50b3be7381', 1, N'12475403-000b-4a7a-a6eb-774c99089784')
INSERT [dbo].[OrderItems] ([id], [ItemId], [purposePriceId], [OrderId], [count], [purposeId]) VALUES (N'36a09a48-3e06-4740-ac37-fd4efda3bde2', N'cc21727f-0def-4c23-8a7f-7bbe2d799e1b', N'93aaf61c-72cc-433c-9dd2-fa2b2d24a481', N'ac7e5367-bd1b-4a2f-88cb-b9ff174a9807', 1, N'ad0f22b9-51ae-416a-abf7-f2fe056da125')
INSERT [dbo].[Purpose] ([id], [ItemId], [AvailabilityTypeID], [IsPromo]) VALUES (N'88ab622f-9262-41fc-af2d-04ddfc42450a', N'1bd1f90c-91ee-4e26-a67b-4130b6caa96e', N'c9f3e4e0-d4de-4857-a282-1349caf63df4', 0)
INSERT [dbo].[Purpose] ([id], [ItemId], [AvailabilityTypeID], [IsPromo]) VALUES (N'6635f17a-e9d4-4508-924d-058bdd44e51a', N'48e234bb-cf39-4a27-ad6a-b45342a49963', N'a4c16f0c-f7fb-4751-9bdc-c1b94cd27236', 0)
INSERT [dbo].[Purpose] ([id], [ItemId], [AvailabilityTypeID], [IsPromo]) VALUES (N'89b15327-fd62-4e89-8370-1293e0a4cf08', N'86e0f3f9-747d-4099-862e-5b80c100eb1d', N'c9f3e4e0-d4de-4857-a282-1349caf63df4', 0)
INSERT [dbo].[Purpose] ([id], [ItemId], [AvailabilityTypeID], [IsPromo]) VALUES (N'7d56771f-7704-4c4a-898c-1a61882d8e75', N'814a6d0d-fac9-4c0e-af3f-ca6cda4c5695', N'a3dc2b7a-7070-43a6-bc77-f7837cafdfef', 0)
INSERT [dbo].[Purpose] ([id], [ItemId], [AvailabilityTypeID], [IsPromo]) VALUES (N'117912b0-8d01-44b4-bd22-32e8f9c63a76', N'2e4c9eac-1ce3-483c-ba1e-ea9c0d941a2e', N'a3dc2b7a-7070-43a6-bc77-f7837cafdfef', 0)
INSERT [dbo].[Purpose] ([id], [ItemId], [AvailabilityTypeID], [IsPromo]) VALUES (N'64898159-4900-48c5-b6c8-46585f83347b', N'ae650fe3-ce0e-44f6-b8f7-8eadd7b7523c', N'0358605e-94a3-4f0f-b2f6-1f77c4ddc962', 0)
INSERT [dbo].[Purpose] ([id], [ItemId], [AvailabilityTypeID], [IsPromo]) VALUES (N'04e2bf52-09d6-4f77-9cfe-5edc8b820746', N'0b50430e-6a2f-4b84-8c99-499dd88bee2a', N'c9f3e4e0-d4de-4857-a282-1349caf63df4', 0)
INSERT [dbo].[Purpose] ([id], [ItemId], [AvailabilityTypeID], [IsPromo]) VALUES (N'54f32b75-7225-4e0a-994e-631d94b51d2a', N'ce2d114d-effe-4d66-b31c-6d06cf762cb3', N'c9f3e4e0-d4de-4857-a282-1349caf63df4', 0)
INSERT [dbo].[Purpose] ([id], [ItemId], [AvailabilityTypeID], [IsPromo]) VALUES (N'e9407834-1db9-4684-b80f-6583831c2312', N'2191688b-e599-4dbe-81c5-33d21ac69c21', N'c9f3e4e0-d4de-4857-a282-1349caf63df4', 0)
INSERT [dbo].[Purpose] ([id], [ItemId], [AvailabilityTypeID], [IsPromo]) VALUES (N'91efdbc4-e48c-4405-a64b-6c108d36ec62', N'9a2ad4ef-b25f-4760-988a-966872c6d738', N'0358605e-94a3-4f0f-b2f6-1f77c4ddc962', 0)
INSERT [dbo].[Purpose] ([id], [ItemId], [AvailabilityTypeID], [IsPromo]) VALUES (N'12475403-000b-4a7a-a6eb-774c99089784', N'b28d3612-ff08-4fa8-a1f6-9a7e77d89e17', N'0358605e-94a3-4f0f-b2f6-1f77c4ddc962', 0)
INSERT [dbo].[Purpose] ([id], [ItemId], [AvailabilityTypeID], [IsPromo]) VALUES (N'002cee06-7ef4-4717-8168-830e3b38a864', N'5f09c75b-bcae-4083-aad4-4bb9eab2080b', N'c9f3e4e0-d4de-4857-a282-1349caf63df4', 0)
INSERT [dbo].[Purpose] ([id], [ItemId], [AvailabilityTypeID], [IsPromo]) VALUES (N'3408cd7a-8872-44db-957b-8423dd8dd4f9', N'2c0a4cee-fe3e-47b3-928f-c1e9ffce1075', N'a4c16f0c-f7fb-4751-9bdc-c1b94cd27236', 0)
INSERT [dbo].[Purpose] ([id], [ItemId], [AvailabilityTypeID], [IsPromo]) VALUES (N'53dce097-ec4e-476f-a108-8450ea0e24de', N'e5413b49-7e01-47c5-a60e-b43fb5b94543', N'a4c16f0c-f7fb-4751-9bdc-c1b94cd27236', 0)
INSERT [dbo].[Purpose] ([id], [ItemId], [AvailabilityTypeID], [IsPromo]) VALUES (N'5074cd8b-0f59-47d4-ad1e-96b5bcf00443', N'983496eb-465f-4d29-8aa0-080a729997ec', N'c9f3e4e0-d4de-4857-a282-1349caf63df4', 0)
INSERT [dbo].[Purpose] ([id], [ItemId], [AvailabilityTypeID], [IsPromo]) VALUES (N'd3ad3d3e-712b-4ae8-8b52-9f80d3058121', N'242578f8-7935-4a53-b80d-e010c3176ab7', N'a3dc2b7a-7070-43a6-bc77-f7837cafdfef', 0)
INSERT [dbo].[Purpose] ([id], [ItemId], [AvailabilityTypeID], [IsPromo]) VALUES (N'57b54164-c888-4f06-a751-cf0bfcf745f1', N'9bf5d47f-f356-43a3-8104-28abcaa9112a', N'c9f3e4e0-d4de-4857-a282-1349caf63df4', 0)
INSERT [dbo].[Purpose] ([id], [ItemId], [AvailabilityTypeID], [IsPromo]) VALUES (N'fc0b0c52-e2ff-45cf-95f1-d65dfda0612c', N'65f8b9d4-210d-48dc-b14b-7483d7f66148', N'c9f3e4e0-d4de-4857-a282-1349caf63df4', 1)
INSERT [dbo].[Purpose] ([id], [ItemId], [AvailabilityTypeID], [IsPromo]) VALUES (N'd9380ae2-00f5-41f8-a557-ecdd7a2071b0', N'da4aff3c-7aee-4a64-be3d-28024ecdc376', N'c9f3e4e0-d4de-4857-a282-1349caf63df4', 0)
INSERT [dbo].[Purpose] ([id], [ItemId], [AvailabilityTypeID], [IsPromo]) VALUES (N'ad0f22b9-51ae-416a-abf7-f2fe056da125', N'cc21727f-0def-4c23-8a7f-7bbe2d799e1b', N'c9f3e4e0-d4de-4857-a282-1349caf63df4', 0)
INSERT [dbo].[Purpose] ([id], [ItemId], [AvailabilityTypeID], [IsPromo]) VALUES (N'9ea5f70e-7c47-49d6-af6a-f840bf82524d', N'73956afa-1669-4740-88b2-3df5f4851ff3', N'c9f3e4e0-d4de-4857-a282-1349caf63df4', 0)
INSERT [dbo].[Purpose] ([id], [ItemId], [AvailabilityTypeID], [IsPromo]) VALUES (N'335016d7-47e8-41d8-9716-fd2e8cdeaa03', N'5ca2919c-50f4-4035-aad9-8cb93838060b', N'c9f3e4e0-d4de-4857-a282-1349caf63df4', 1)
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'0f3f52e7-8146-49a5-bfe1-024ff4a41774', N'64898159-4900-48c5-b6c8-46585f83347b', 500, CAST(N'2017-06-01' AS Date), N'23d17c67-8755-480a-ac67-ff7190f9b208')
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'f7889706-acfe-4822-bf08-10c3159b8d19', N'5074cd8b-0f59-47d4-ad1e-96b5bcf00443', 120, CAST(N'2017-06-01' AS Date), N'035c980b-d8c8-4126-ba7f-65a1992b301d')
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'e376cd16-3785-4dda-987a-29441f6a1c4a', N'e9407834-1db9-4684-b80f-6583831c2312', 7500, CAST(N'2017-06-01' AS Date), N'37820566-d2f7-44e7-b550-9675d1fc8168')
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'd18e3b45-e143-4fed-a169-310bb85bb015', N'57b54164-c888-4f06-a751-cf0bfcf745f1', 10000, CAST(N'2017-06-01' AS Date), N'be2e38e5-337d-4898-a54a-5072d2f2a894')
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'f58969f9-47f9-48ec-9224-3144daa58b71', N'88ab622f-9262-41fc-af2d-04ddfc42450a', 100, CAST(N'2017-06-01' AS Date), N'23d17c67-8755-480a-ac67-ff7190f9b208')
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'09aa9159-2f95-4b50-a797-32655e9ef89f', N'91efdbc4-e48c-4405-a64b-6c108d36ec62', 8000, CAST(N'2017-06-01' AS Date), N'37820566-d2f7-44e7-b550-9675d1fc8168')
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'9b808a74-91fe-4d6d-9f8e-328cbddecb6f', N'89b15327-fd62-4e89-8370-1293e0a4cf08', 500, CAST(N'2017-06-08' AS Date), N'23d17c67-8755-480a-ac67-ff7190f9b208')
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'040d2061-8f5c-4af9-b15a-36e23decd36f', N'117912b0-8d01-44b4-bd22-32e8f9c63a76', 400, CAST(N'2017-06-01' AS Date), N'23d17c67-8755-480a-ac67-ff7190f9b208')
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'1c1ab585-ceda-45e7-a1a4-39ee0f7a8368', N'7d56771f-7704-4c4a-898c-1a61882d8e75', 300, CAST(N'2017-06-01' AS Date), N'23d17c67-8755-480a-ac67-ff7190f9b208')
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'9c1220b7-c815-41e6-bcf5-3e41b9bcec3d', N'7d56771f-7704-4c4a-898c-1a61882d8e75', 290, CAST(N'2017-06-01' AS Date), N'23d17c67-8755-480a-ac67-ff7190f9b208')
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'5d18548f-4147-4b9b-9f78-40b8358aae45', N'117912b0-8d01-44b4-bd22-32e8f9c63a76', 390, CAST(N'2017-06-01' AS Date), N'23d17c67-8755-480a-ac67-ff7190f9b208')
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'e45e3d24-f5df-4f21-9f06-58547bfbdb91', N'54f32b75-7225-4e0a-994e-631d94b51d2a', 5000, CAST(N'2017-06-01' AS Date), N'37820566-d2f7-44e7-b550-9675d1fc8168')
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'72c6a0e9-b606-42c7-be79-5dc0978e0967', N'd3ad3d3e-712b-4ae8-8b52-9f80d3058121', 130, CAST(N'2017-06-01' AS Date), N'035c980b-d8c8-4126-ba7f-65a1992b301d')
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'c4827af9-e487-4c18-bd5d-746df9117819', N'6635f17a-e9d4-4508-924d-058bdd44e51a', 200, CAST(N'2017-06-01' AS Date), N'23d17c67-8755-480a-ac67-ff7190f9b208')
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'edf9d52d-a4b0-41fd-b80f-7bd8cf9ed7ed', N'12475403-000b-4a7a-a6eb-774c99089784', 50, CAST(N'2017-06-01' AS Date), N'37820566-d2f7-44e7-b550-9675d1fc8168')
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'fc99cf27-e231-406e-8623-7c36aafe3b1d', N'6635f17a-e9d4-4508-924d-058bdd44e51a', 190, CAST(N'2017-06-01' AS Date), N'23d17c67-8755-480a-ac67-ff7190f9b208')
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'994deaef-8dc0-4060-bf8f-7ce3bd4ee8d6', N'002cee06-7ef4-4717-8168-830e3b38a864', 70, CAST(N'2017-06-01' AS Date), N'035c980b-d8c8-4126-ba7f-65a1992b301d')
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'ce610ff5-0c33-47b7-b254-85afce6fda73', N'53dce097-ec4e-476f-a108-8450ea0e24de', 90, CAST(N'2017-06-01' AS Date), N'035c980b-d8c8-4126-ba7f-65a1992b301d')
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'99812281-1615-42e2-8568-88ee055bd58e', N'd9380ae2-00f5-41f8-a557-ecdd7a2071b0', 15000, CAST(N'2017-06-01' AS Date), N'be2e38e5-337d-4898-a54a-5072d2f2a894')
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'f84bf324-44ab-4378-adc3-9d05c42c0098', N'3408cd7a-8872-44db-957b-8423dd8dd4f9', 60, CAST(N'2017-06-01' AS Date), N'035c980b-d8c8-4126-ba7f-65a1992b301d')
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'8cb11dd5-cbaa-4b40-9fce-9e17b34aa31f', N'9ea5f70e-7c47-49d6-af6a-f840bf82524d', 25000, CAST(N'2017-06-01' AS Date), N'be2e38e5-337d-4898-a54a-5072d2f2a894')
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'aea0d154-8859-4684-961d-9ecd5995debb', N'fc0b0c52-e2ff-45cf-95f1-d65dfda0612c', 11000, CAST(N'2017-06-01' AS Date), N'be2e38e5-337d-4898-a54a-5072d2f2a894')
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'b6195700-a295-474b-bede-a08b07bb4c6e', N'04e2bf52-09d6-4f77-9cfe-5edc8b820746', 2500, CAST(N'2017-06-01' AS Date), N'37820566-d2f7-44e7-b550-9675d1fc8168')
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'6d3377f5-eb3d-469e-9765-b7c5a4a3beb9', N'88ab622f-9262-41fc-af2d-04ddfc42450a', 90, CAST(N'2017-06-01' AS Date), N'23d17c67-8755-480a-ac67-ff7190f9b208')
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'bea4a17c-4445-412d-a92b-ca9584b69e65', N'335016d7-47e8-41d8-9716-fd2e8cdeaa03', 30000, CAST(N'2017-06-01' AS Date), N'be2e38e5-337d-4898-a54a-5072d2f2a894')
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'7ec513a3-d2a0-4e76-94dd-cecd242af717', N'64898159-4900-48c5-b6c8-46585f83347b', 490, CAST(N'2017-06-01' AS Date), N'23d17c67-8755-480a-ac67-ff7190f9b208')
INSERT [dbo].[purposePrice] ([id], [purposeId], [price], [date], [curencyID]) VALUES (N'93aaf61c-72cc-433c-9dd2-fa2b2d24a481', N'ad0f22b9-51ae-416a-abf7-f2fe056da125', 600, CAST(N'2017-06-08' AS Date), N'23d17c67-8755-480a-ac67-ff7190f9b208')
INSERT [dbo].[Role] ([id], [Name]) VALUES (N'93341fcf-0fdc-4a85-aac4-0198ed93d696', N'Manager')
INSERT [dbo].[Role] ([id], [Name]) VALUES (N'c28c127b-f693-46ac-bad4-307fb5d09025', N'User')
INSERT [dbo].[Role] ([id], [Name]) VALUES (N'3e3964b4-425f-4f12-86ae-a582647a3e16', N'Admin')
INSERT [dbo].[Role] ([id], [Name]) VALUES (N'966731ec-413f-4b36-96e2-a6dccb8d9786', N'Content manager')
INSERT [dbo].[status] ([id], [name]) VALUES (N'41faf4c9-0634-466f-920a-2bcc20713fd1', N'Shipped')
INSERT [dbo].[status] ([id], [name]) VALUES (N'bd0fab88-5764-4615-84b8-48e05155c9da', N'New')
INSERT [dbo].[status] ([id], [name]) VALUES (N'7c8fac7d-62bb-486d-b2b8-5a810dbbd796', N'In process')
INSERT [dbo].[status] ([id], [name]) VALUES (N'a9a39fa1-2e0a-4c4b-938f-5dd598a4e121', N'Delivered')
INSERT [dbo].[status] ([id], [name]) VALUES (N'e335a99a-fdd9-45b1-982b-ad54abdd7948', N'Closed')
INSERT [dbo].[userRole] ([id], [userId], [roleID]) VALUES (N'9eb4e49e-336c-45ae-b7e4-0c54bb5b3f86', N'26ea779e-21ea-4999-98af-bc3b5d1ef068', N'3e3964b4-425f-4f12-86ae-a582647a3e16')
INSERT [dbo].[userRole] ([id], [userId], [roleID]) VALUES (N'8ae93a3b-1dde-40a7-ace6-50086aefbb64', N'9e5b2abf-46a9-4500-a08b-bd18e468cda2', N'c28c127b-f693-46ac-bad4-307fb5d09025')
INSERT [dbo].[userRole] ([id], [userId], [roleID]) VALUES (N'ce2d3ee0-261c-4379-bb01-c09d592c46dd', N'086192ce-70e7-4410-b5d4-3f0f1486ea6a', N'3e3964b4-425f-4f12-86ae-a582647a3e16')
INSERT [dbo].[userRole] ([id], [userId], [roleID]) VALUES (N'8e463c03-9663-46b9-bb35-c29c4ae31345', N'6339b42c-3ef9-4c24-9f4c-82de9bbca566', N'93341fcf-0fdc-4a85-aac4-0198ed93d696')
INSERT [dbo].[users] ([id], [name], [Lname], [Login], [Password], [email], [birthDate], [GenderID]) VALUES (N'086192ce-70e7-4410-b5d4-3f0f1486ea6a', N'Dmitry', N'Volkovsky', N'wrider', N'1111', N'wrider@gmail.com', CAST(N'1991-10-01' AS Date), N'96676584-ed15-4991-900e-1403842591ef')
INSERT [dbo].[users] ([id], [name], [Lname], [Login], [Password], [email], [birthDate], [GenderID]) VALUES (N'6339b42c-3ef9-4c24-9f4c-82de9bbca566', N'Ivan', N'Petrov', N'petrovlogin', N'1111', N'petrov@gmail.com', CAST(N'1990-01-01' AS Date), N'8de84309-62bb-49b4-8bd4-ce99295b8dcf')
INSERT [dbo].[users] ([id], [name], [Lname], [Login], [Password], [email], [birthDate], [GenderID]) VALUES (N'26ea779e-21ea-4999-98af-bc3b5d1ef068', N'Alexey', N'Zheleznichenko', N'akiles', N'100101001', N'alexeyzheleznichenko@gmail.com', CAST(N'1991-07-28' AS Date), N'8de84309-62bb-49b4-8bd4-ce99295b8dcf')
INSERT [dbo].[users] ([id], [name], [Lname], [Login], [Password], [email], [birthDate], [GenderID]) VALUES (N'9e5b2abf-46a9-4500-a08b-bd18e468cda2', N'Masha', N'Ivanova', N'ivanovalogin', N'1111', N'ivanovao@gmail.com', CAST(N'1990-01-01' AS Date), N'96676584-ed15-4991-900e-1403842591ef')
ALTER TABLE [dbo].[Comment] ADD  CONSTRAINT [DF_Comment_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[ItemImage] ADD  CONSTRAINT [DF_ItemImage_id]  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_Category1] FOREIGN KEY([ParentID])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_Category1]
GO
ALTER TABLE [dbo].[CategoryCharacteristic]  WITH CHECK ADD  CONSTRAINT [FK_CategoryCharacteristic_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[CategoryCharacteristic] CHECK CONSTRAINT [FK_CategoryCharacteristic_Category]
GO
ALTER TABLE [dbo].[CategoryCharacteristic]  WITH CHECK ADD  CONSTRAINT [FK_CategoryCharacteristic_Characteristics] FOREIGN KEY([CharacteristicID])
REFERENCES [dbo].[Characteristics] ([id])
GO
ALTER TABLE [dbo].[CategoryCharacteristic] CHECK CONSTRAINT [FK_CategoryCharacteristic_Characteristics]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_CommentType] FOREIGN KEY([CommentTypeId])
REFERENCES [dbo].[CommentType] ([Id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_CommentType]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Item] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Item]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_users] FOREIGN KEY([UserId])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_users]
GO
ALTER TABLE [dbo].[Contacts]  WITH CHECK ADD  CONSTRAINT [FK_Contacts_ContactType] FOREIGN KEY([contactTypeId])
REFERENCES [dbo].[ContactType] ([id])
GO
ALTER TABLE [dbo].[Contacts] CHECK CONSTRAINT [FK_Contacts_ContactType]
GO
ALTER TABLE [dbo].[Contacts]  WITH CHECK ADD  CONSTRAINT [FK_Contacts_users] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[Contacts] CHECK CONSTRAINT [FK_Contacts_users]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Brand] FOREIGN KEY([BrandID])
REFERENCES [dbo].[Brand] ([Id])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_Brand]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_Category]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Country] FOREIGN KEY([ManufCountryID])
REFERENCES [dbo].[Country] ([id])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_Country]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Country1] FOREIGN KEY([BrandCOuntryID])
REFERENCES [dbo].[Country] ([id])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_Country1]
GO
ALTER TABLE [dbo].[ItemCharacteristics]  WITH CHECK ADD  CONSTRAINT [FK_ItemCharacteristics_Characteristics] FOREIGN KEY([CharacteristicID])
REFERENCES [dbo].[Characteristics] ([id])
GO
ALTER TABLE [dbo].[ItemCharacteristics] CHECK CONSTRAINT [FK_ItemCharacteristics_Characteristics]
GO
ALTER TABLE [dbo].[ItemCharacteristics]  WITH CHECK ADD  CONSTRAINT [FK_ItemCharacteristics_CharValue] FOREIGN KEY([CharVarID])
REFERENCES [dbo].[CharValue] ([id])
GO
ALTER TABLE [dbo].[ItemCharacteristics] CHECK CONSTRAINT [FK_ItemCharacteristics_CharValue]
GO
ALTER TABLE [dbo].[ItemCharacteristics]  WITH CHECK ADD  CONSTRAINT [FK_ItemCharacteristics_Item] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Item] ([id])
GO
ALTER TABLE [dbo].[ItemCharacteristics] CHECK CONSTRAINT [FK_ItemCharacteristics_Item]
GO
ALTER TABLE [dbo].[ItemImage]  WITH CHECK ADD  CONSTRAINT [FK_ItemImage_Item] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([id])
GO
ALTER TABLE [dbo].[ItemImage] CHECK CONSTRAINT [FK_ItemImage_Item]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_DeliveryType] FOREIGN KEY([DeliveryTypeId])
REFERENCES [dbo].[DeliveryType] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_DeliveryType]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[status] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_status]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_users] FOREIGN KEY([UserId])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_users]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Item] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([id])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Item]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Order]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Purpose] FOREIGN KEY([purposeId])
REFERENCES [dbo].[Purpose] ([id])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Purpose]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_purposePrice] FOREIGN KEY([purposePriceId])
REFERENCES [dbo].[purposePrice] ([id])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_purposePrice]
GO
ALTER TABLE [dbo].[Purpose]  WITH CHECK ADD  CONSTRAINT [FK_Purpose_AvailabilityType] FOREIGN KEY([AvailabilityTypeID])
REFERENCES [dbo].[AvailabilityType] ([id])
GO
ALTER TABLE [dbo].[Purpose] CHECK CONSTRAINT [FK_Purpose_AvailabilityType]
GO
ALTER TABLE [dbo].[Purpose]  WITH CHECK ADD  CONSTRAINT [FK_Purpose_Item] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([id])
GO
ALTER TABLE [dbo].[Purpose] CHECK CONSTRAINT [FK_Purpose_Item]
GO
ALTER TABLE [dbo].[purposePrice]  WITH CHECK ADD  CONSTRAINT [FK_purposePrice_Curency] FOREIGN KEY([curencyID])
REFERENCES [dbo].[Curency] ([id])
GO
ALTER TABLE [dbo].[purposePrice] CHECK CONSTRAINT [FK_purposePrice_Curency]
GO
ALTER TABLE [dbo].[purposePrice]  WITH CHECK ADD  CONSTRAINT [FK_purposePrice_Purpose] FOREIGN KEY([purposeId])
REFERENCES [dbo].[Purpose] ([id])
GO
ALTER TABLE [dbo].[purposePrice] CHECK CONSTRAINT [FK_purposePrice_Purpose]
GO
ALTER TABLE [dbo].[userRole]  WITH CHECK ADD  CONSTRAINT [FK_userRole_Role] FOREIGN KEY([roleID])
REFERENCES [dbo].[Role] ([id])
GO
ALTER TABLE [dbo].[userRole] CHECK CONSTRAINT [FK_userRole_Role]
GO
ALTER TABLE [dbo].[userRole]  WITH CHECK ADD  CONSTRAINT [FK_userRole_users] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[userRole] CHECK CONSTRAINT [FK_userRole_users]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_Gender] FOREIGN KEY([GenderID])
REFERENCES [dbo].[Gender] ([id])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_Gender]
GO
