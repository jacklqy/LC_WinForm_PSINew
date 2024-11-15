USE [master]
GO
/****** Object:  Database [PSIDBase]    Script Date: 2021/3/19 10:03:44 ******/
CREATE DATABASE [PSIDBase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PSIDBase', FILENAME = N'D:\PSIDBase.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PSIDBase_log', FILENAME = N'D:\PSIDBase_log.ldf' , SIZE = 112384KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PSIDBase] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PSIDBase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PSIDBase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PSIDBase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PSIDBase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PSIDBase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PSIDBase] SET ARITHABORT OFF 
GO
ALTER DATABASE [PSIDBase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PSIDBase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PSIDBase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PSIDBase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PSIDBase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PSIDBase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PSIDBase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PSIDBase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PSIDBase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PSIDBase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PSIDBase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PSIDBase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PSIDBase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PSIDBase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PSIDBase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PSIDBase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PSIDBase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PSIDBase] SET RECOVERY FULL 
GO
ALTER DATABASE [PSIDBase] SET  MULTI_USER 
GO
ALTER DATABASE [PSIDBase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PSIDBase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PSIDBase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PSIDBase] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PSIDBase', N'ON'
GO
USE [PSIDBase]
GO
/****** Object:  Table [dbo].[GoodsInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GoodsInfos](
	[GoodsId] [int] IDENTITY(1,1) NOT NULL,
	[GoodsNo] [varchar](50) NULL,
	[GoodsName] [nvarchar](100) NOT NULL,
	[GoodsPYNo] [varchar](50) NULL,
	[GoodsSName] [nvarchar](50) NULL,
	[GoodsTXNo] [varchar](50) NULL,
	[GUnit] [nvarchar](5) NOT NULL,
	[GTypeId] [int] NOT NULL,
	[GProperties] [nvarchar](50) NOT NULL,
	[IsStopped] [int] NOT NULL CONSTRAINT [DF_GoodsInfos_IsStopped]  DEFAULT ((0)),
	[RetailPrice] [decimal](18, 2) NULL,
	[LowPrice] [decimal](18, 2) NULL,
	[PrePrice] [decimal](18, 2) NULL,
	[Discount] [int] NOT NULL CONSTRAINT [DF_GoodsInfos_Discount]  DEFAULT ((100)),
	[BidPrice] [decimal](18, 2) NULL,
	[Remark] [nvarchar](500) NULL,
	[IsDeleted] [int] NOT NULL CONSTRAINT [DF_GoodsInfos_IsDeleted]  DEFAULT ((0)),
	[Creator] [nvarchar](20) NOT NULL,
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_GoodsInfos_ActTime]  DEFAULT (getdate()),
	[GoodsPic] [varchar](200) NULL,
 CONSTRAINT [PK_GoodsInfos] PRIMARY KEY CLUSTERED 
(
	[GoodsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GoodsTypeInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GoodsTypeInfos](
	[GTypeId] [int] IDENTITY(1,1) NOT NULL,
	[GTypeName] [nvarchar](50) NOT NULL,
	[ParentId] [int] NULL,
	[ParentName] [nvarchar](50) NULL,
	[GTypeNo] [varchar](50) NULL,
	[GTPYNo] [varchar](50) NULL,
	[GTOrder] [int] NOT NULL CONSTRAINT [DF_GoodsTypeInfos_GTOrder]  DEFAULT ((0)),
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_GoodsTypeInfos_ActTime]  DEFAULT (getdate()),
	[IsDeleted] [int] NOT NULL CONSTRAINT [DF_GoodsTypeInfos_IsDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK_GoodsTypeInfos] PRIMARY KEY CLUSTERED 
(
	[GTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GoodsUnitInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GoodsUnitInfos](
	[GUnitId] [int] IDENTITY(1,1) NOT NULL,
	[GUnitName] [nvarchar](5) NOT NULL,
	[GUnitPYNo] [varchar](10) NULL,
	[GUnitOrder] [int] NOT NULL CONSTRAINT [DF_GoodsUnitInfos_GUnitOrder]  DEFAULT ((0)),
	[IsDeleted] [int] NOT NULL CONSTRAINT [DF_GoodsUnitInfos_IsDeleted]  DEFAULT ((0)),
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_GoodsUnitInfos_ActTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_GoodsUnitInfos] PRIMARY KEY CLUSTERED 
(
	[GUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MenuInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MenuInfos](
	[MId] [int] IDENTITY(1,1) NOT NULL,
	[MName] [nvarchar](50) NOT NULL,
	[ParentId] [int] NULL,
	[MKey] [varchar](50) NULL,
	[MUrl] [varchar](200) NULL,
	[IsTop] [int] NOT NULL CONSTRAINT [DF_MenuInfos_IsTop]  DEFAULT ((0)),
	[MOrder] [int] NOT NULL CONSTRAINT [DF_MenuInfos_MOrder]  DEFAULT ((0)),
	[IsDeleted] [int] NOT NULL CONSTRAINT [DF_MenuInfos_IsDeleted]  DEFAULT ((0)),
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_MenuInfos_CreateTime]  DEFAULT (getdate()),
	[MDesp] [varchar](50) NULL,
 CONSTRAINT [PK_MenuInfos] PRIMARY KEY CLUSTERED 
(
	[MId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PerchaseGoodsInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerchaseGoodsInfos](
	[PerGoodsId] [int] IDENTITY(1,1) NOT NULL,
	[PerId] [int] NOT NULL,
	[GoodsId] [int] NOT NULL,
	[GUnit] [nvarchar](5) NOT NULL,
	[Count] [int] NOT NULL CONSTRAINT [DF_PerchaseGoodsInfos_Count]  DEFAULT ((0)),
	[PerPrice] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PerchaseGoodsInfos_PerPrice]  DEFAULT ((0.00)),
	[Amount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PerchaseGoodsInfos_Amount]  DEFAULT ((0.00)),
	[Remark] [nvarchar](500) NULL,
	[IsDeleted] [int] NOT NULL CONSTRAINT [DF_PerchaseGoodsInfos_IsDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK_PerchaseGoodsInfos] PRIMARY KEY CLUSTERED 
(
	[PerGoodsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PerchaseInStoreInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PerchaseInStoreInfos](
	[PerId] [int] IDENTITY(1,1) NOT NULL,
	[PerchaseNo] [varchar](50) NOT NULL,
	[UnitId] [int] NOT NULL,
	[StoreId] [int] NOT NULL,
	[DealPerson] [nvarchar](50) NOT NULL,
	[PayDesp] [nvarchar](200) NULL,
	[ThisAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PerchaseInStoreInfos_ThisAmount]  DEFAULT ((0.00)),
	[Remark] [nvarchar](500) NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PerchaseInStoreInfos_TotalAmount]  DEFAULT ((0.00)),
	[YHAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_PerchaseInStoreInfos_YHAmount]  DEFAULT ((0.00)),
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_PerchaseInStoreInfos_CreateTime]  DEFAULT (getdate()),
	[IsChecked] [int] NOT NULL CONSTRAINT [DF_PerchaseInStoreInfos_IsChecked]  DEFAULT ((0)),
	[IsPayed] [int] NOT NULL CONSTRAINT [DF_PerchaseInStoreInfos_IsPayed]  DEFAULT ((0)),
	[IsPayFull] [int] NOT NULL CONSTRAINT [DF_PerchaseInStoreInfos_IsPayFull]  DEFAULT ((0)),
	[CheckTime] [datetime] NULL,
	[CheckPerson] [nvarchar](50) NULL,
	[PayTime] [datetime] NULL,
	[IsDeleted] [int] NOT NULL CONSTRAINT [DF_PerchaseInStoreInfos_IsDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK_PerchaseInStoreInfos] PRIMARY KEY CLUSTERED 
(
	[PerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RegionInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegionInfos](
	[RegionId] [int] NOT NULL,
	[RegionName] [nvarchar](50) NULL,
	[ParentId] [int] NULL,
	[ParentName] [nvarchar](50) NULL,
	[RegionPYNo] [nvarchar](50) NULL,
	[RegionLevel] [int] NULL,
 CONSTRAINT [PK_RegionInfos] PRIMARY KEY CLUSTERED 
(
	[RegionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RememberedRecords]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RememberedRecords](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoginIP] [varchar](20) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[UserRealPwd] [varchar](50) NOT NULL,
	[ReOrder] [int] NOT NULL CONSTRAINT [DF_RememberedRecords_ReOrder]  DEFAULT ((1)),
 CONSTRAINT [PK_RememberedRecords] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RoleInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleInfos](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](20) NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[IsAdmin] [int] NULL CONSTRAINT [DF_RoleInfos_IsAdmin]  DEFAULT ((0)),
	[IsDeleted] [int] NOT NULL CONSTRAINT [DF_RoleInfos_IsDeleted]  DEFAULT ((0)),
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_RoleInfos_CreateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_RoleInfos] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleMenuInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMenuInfos](
	[RMId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[MId] [int] NOT NULL,
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_RoleMenuInfos_CreateTime]  DEFAULT (getdate()),
	[IsDeleted] [int] NULL CONSTRAINT [DF_RoleMenuInfos_IsDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK_RoleMenuInfos] PRIMARY KEY CLUSTERED 
(
	[RMId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleTMenuInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleTMenuInfos](
	[RTMenuId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[TMenuId] [int] NOT NULL,
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_RoleTMneuInfos_CreateTime]  DEFAULT (getdate()),
	[IsDeleted] [int] NOT NULL CONSTRAINT [DF_RoleTMenuInfos_IsDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK_RoleTMneuInfos] PRIMARY KEY CLUSTERED 
(
	[RTMenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SaleGoodsInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleGoodsInfos](
	[SaleGoodsId] [int] IDENTITY(1,1) NOT NULL,
	[SaleId] [int] NOT NULL,
	[GoodsId] [int] NOT NULL,
	[GUnit] [nvarchar](5) NOT NULL,
	[Count] [int] NOT NULL CONSTRAINT [DF_SaleGoodsInfos_Count]  DEFAULT ((0)),
	[SalePrice] [decimal](18, 2) NOT NULL CONSTRAINT [DF_SaleGoodsInfos_PerPrice]  DEFAULT ((0.00)),
	[Amount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_SaleGoodsInfos_Amount]  DEFAULT ((0.00)),
	[Remark] [nvarchar](500) NULL,
	[IsDeleted] [int] NOT NULL CONSTRAINT [DF_SaleGoodsInfos_IsDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK_SaleGoodsInfos] PRIMARY KEY CLUSTERED 
(
	[SaleGoodsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SaleOutStoreInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SaleOutStoreInfos](
	[SaleId] [int] IDENTITY(1,1) NOT NULL,
	[SaleOutNo] [varchar](50) NOT NULL,
	[UnitId] [int] NOT NULL,
	[StoreId] [int] NOT NULL,
	[DealPerson] [nvarchar](50) NOT NULL,
	[PayDesp] [nvarchar](200) NULL CONSTRAINT [DF_SaleOutStoreInfos_PayType]  DEFAULT ((1)),
	[ThisAmount] [decimal](18, 2) NULL CONSTRAINT [DF_SaleOutStoreInfos_ThisAmount]  DEFAULT ((0.00)),
	[Remark] [nvarchar](500) NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_SaleOutStoreInfos_TotalAmount]  DEFAULT ((0.00)),
	[YHAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_SaleOutStoreInfos_YHAmount]  DEFAULT ((0.00)),
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_SaleOutStoreInfos_CreateTime]  DEFAULT (getdate()),
	[IsChecked] [int] NOT NULL CONSTRAINT [DF_SaleOutStoreInfos_IsChecked]  DEFAULT ((0)),
	[IsPayed] [int] NOT NULL CONSTRAINT [DF_SaleOutStoreInfos_IsPayed]  DEFAULT ((0)),
	[IsPayFull] [int] NOT NULL CONSTRAINT [DF_SaleOutStoreInfos_IsPayFull]  DEFAULT ((0)),
	[CheckTime] [datetime] NULL,
	[CheckPerson] [nvarchar](50) NULL,
	[IsDeleted] [int] NOT NULL CONSTRAINT [DF_SaleOutStoreInfos_IsDeleted]  DEFAULT ((0)),
	[PayTime] [datetime] NULL,
 CONSTRAINT [PK_SaleOutStoreInfos] PRIMARY KEY CLUSTERED 
(
	[SaleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StockChangeInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockChangeInfos](
	[StockChangeId] [int] IDENTITY(1,1) NOT NULL,
	[CheckShId] [int] NOT NULL,
	[ShType] [int] NOT NULL,
	[StoreId] [int] NOT NULL,
	[GoodsId] [int] NOT NULL,
	[InCount] [int] NOT NULL CONSTRAINT [DF_StockChangeInfos_InCount]  DEFAULT ((0)),
	[OutCount] [int] NOT NULL CONSTRAINT [DF_StockChangeInfos_OutCount]  DEFAULT ((0)),
	[CurCount] [int] NOT NULL CONSTRAINT [DF_StockChangeInfos_CurCount]  DEFAULT ((0)),
 CONSTRAINT [PK_StocChangeInfos] PRIMARY KEY CLUSTERED 
(
	[StockChangeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StockStoreInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StockStoreInfos](
	[StockId] [int] IDENTITY(1,1) NOT NULL,
	[StockNo] [varchar](50) NOT NULL,
	[StoreId] [int] NOT NULL,
	[DealPerson] [nvarchar](50) NULL,
	[Remark] [nvarchar](500) NULL,
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_StockStoreInfos_CreateTime]  DEFAULT (getdate()),
	[IsChecked] [int] NOT NULL CONSTRAINT [DF_StockStoreInfos_IsNoUse]  DEFAULT ((0)),
	[CheckPerson] [nvarchar](50) NULL,
	[CheckTime] [datetime] NULL,
	[IsDeleted] [int] NOT NULL CONSTRAINT [DF_StockStoreInfos_IsDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK_StockStoreInfos] PRIMARY KEY CLUSTERED 
(
	[StockId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StoreGoodsStockInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoreGoodsStockInfos](
	[StoreGoodsId] [int] IDENTITY(1,1) NOT NULL,
	[StoreId] [int] NOT NULL,
	[GoodsId] [int] NOT NULL,
	[StCount] [int] NOT NULL CONSTRAINT [DF_StockInfos_StCount]  DEFAULT ((0)),
	[StAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_StockInfos_StAmount]  DEFAULT ((0.00)),
	[StPrice] [decimal](18, 2) NOT NULL CONSTRAINT [DF_StockInfos_StPrice]  DEFAULT ((0.00)),
	[CurCount] [int] NOT NULL CONSTRAINT [DF_StockInfos_CurCount]  DEFAULT ((0)),
	[StockAmount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_StockInfos_StockAmount]  DEFAULT ((0.00)),
	[StockUp] [int] NULL,
	[StockDown] [int] NOT NULL CONSTRAINT [DF_StoreGoodsInfos_StockDown]  DEFAULT ((0)),
	[Creator] [nvarchar](20) NOT NULL,
	[Createtime] [datetime] NOT NULL CONSTRAINT [DF_StockInfos_EditTime]  DEFAULT (getdate()),
	[IsDeleted] [int] NULL CONSTRAINT [DF_StoreGoodsStockInfos_IsDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK_StoreGoodsInfos] PRIMARY KEY CLUSTERED 
(
	[StoreGoodsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StoreInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StoreInfos](
	[StoreId] [int] IDENTITY(1,1) NOT NULL,
	[StoreNo] [varchar](50) NULL,
	[StoreName] [nvarchar](50) NOT NULL,
	[STypeId] [int] NOT NULL,
	[StorePYNo] [varchar](50) NULL,
	[StoreOrder] [int] NOT NULL CONSTRAINT [DF_StoreInfos_StoreOrder]  DEFAULT ((0)),
	[StoreRemark] [nvarchar](500) NULL,
	[IsDeleted] [int] NOT NULL CONSTRAINT [DF_StoreInfos_IsDeleted]  DEFAULT ((0)),
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_StoreInfos_ActTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_StoreInfos] PRIMARY KEY CLUSTERED 
(
	[StoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StoreTypeInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StoreTypeInfos](
	[STypeId] [int] IDENTITY(1,1) NOT NULL,
	[STypeName] [nvarchar](20) NOT NULL,
	[STPYNo] [varchar](50) NULL,
	[STypeOrder] [int] NOT NULL CONSTRAINT [DF_StoreTypeInfos_STypeOrder]  DEFAULT ((0)),
	[IsDeleted] [int] NOT NULL CONSTRAINT [DF_StoreTypeInfos_IsDeleted]  DEFAULT ((0)),
	[Creator] [nvarchar](20) NOT NULL,
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_StoreTypeInfos_ActTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_StoreTypeInfos] PRIMARY KEY CLUSTERED 
(
	[STypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StStockGoodsInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StStockGoodsInfos](
	[StStockId] [int] IDENTITY(1,1) NOT NULL,
	[StockId] [int] NOT NULL,
	[GoodsId] [int] NOT NULL,
	[StCount] [int] NULL CONSTRAINT [DF_StStockGoodsInfos_StCount]  DEFAULT ((0)),
	[StPrice] [decimal](18, 2) NULL CONSTRAINT [DF_StStockGoodsInfos_StPrice]  DEFAULT ((0.00)),
	[StAmount] [decimal](18, 2) NULL CONSTRAINT [DF_StStockGoodsInfos_StAmount]  DEFAULT ((0.00)),
	[IsDeleted] [int] NULL CONSTRAINT [DF_StStockGoodsInfos_IsDeleted]  DEFAULT ((0)),
	[Remark] [nvarchar](500) NULL,
 CONSTRAINT [PK_StStockGoodsInfos] PRIMARY KEY CLUSTERED 
(
	[StStockId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SysInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysInfos](
	[SysId] [int] NOT NULL,
	[SysName] [nvarchar](50) NULL,
	[IsOpened] [int] NOT NULL CONSTRAINT [DF_SysOpenInfos_IsOpened]  DEFAULT ((0)),
	[OpenTime] [datetime] NULL CONSTRAINT [DF_SysInfos_OpenTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_SysOpenInfos] PRIMARY KEY CLUSTERED 
(
	[SysId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ToolGroupInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ToolGroupInfos](
	[TGroupId] [int] IDENTITY(1,1) NOT NULL,
	[TGroupName] [nvarchar](50) NOT NULL,
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_ToolGroupInfos_CreateTime]  DEFAULT (getdate()),
	[IsDeleted] [int] NOT NULL CONSTRAINT [DF_ToolGroupInfos_IsDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK_ToolGroupInfos] PRIMARY KEY CLUSTERED 
(
	[TGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ToolMenuInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ToolMenuInfos](
	[TMenuId] [int] IDENTITY(1,1) NOT NULL,
	[TMenuName] [nvarchar](50) NOT NULL,
	[TMPic] [varchar](100) NULL,
	[TMOrder] [int] NOT NULL CONSTRAINT [DF_ToolMenuInfos_TMOrder]  DEFAULT ((0)),
	[TGroupId] [int] NOT NULL,
	[TMUrl] [varchar](200) NULL,
	[IsTop] [int] NOT NULL CONSTRAINT [DF_ToolMenuInfos_IsTop]  DEFAULT ((0)),
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_ToolMenuInfos_CreateTime]  DEFAULT (getdate()),
	[TMDesp] [varchar](50) NULL,
	[IsDeleted] [int] NOT NULL CONSTRAINT [DF_ToolMenuInfos_IsDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK_ToolMenuInfos] PRIMARY KEY CLUSTERED 
(
	[TMenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UnitInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UnitInfos](
	[UnitId] [int] IDENTITY(1,1) NOT NULL,
	[UnitName] [nvarchar](50) NOT NULL,
	[UnitPYNo] [varchar](50) NULL,
	[UTypeId] [int] NOT NULL,
	[UnitProperties] [nvarchar](50) NOT NULL,
	[RegionId] [int] NULL,
	[Address] [nvarchar](100) NULL,
	[FullAddress] [nvarchar](200) NULL,
	[UnitNo] [varchar](50) NULL,
	[ContactPerson] [nvarchar](50) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[Telephone] [varchar](50) NULL,
	[Fax] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[PostalCode] [varchar](50) NULL,
	[Remark] [nvarchar](1000) NULL,
	[IsNoVail] [int] NOT NULL CONSTRAINT [DF_UnitInfos_IsNoVail]  DEFAULT ((0)),
	[IsDeleted] [int] NOT NULL CONSTRAINT [DF_UnitInfos_IsDeleted]  DEFAULT ((0)),
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_UnitInfos_ActTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_UnitInfos] PRIMARY KEY CLUSTERED 
(
	[UnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UnitTypeInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UnitTypeInfos](
	[UTypeId] [int] IDENTITY(1,1) NOT NULL,
	[UTypeName] [nvarchar](50) NOT NULL,
	[ParentId] [int] NULL,
	[ParentName] [nvarchar](50) NULL,
	[UTypeNo] [varchar](50) NULL,
	[UTPYNo] [varchar](50) NULL,
	[UTOrder] [int] NOT NULL CONSTRAINT [DF_UnitTypeInffos_UTOrder]  DEFAULT ((0)),
	[IsDeleted] [int] NOT NULL CONSTRAINT [DF_UnitTypeInffos_IsDeleted]  DEFAULT ((0)),
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_UnitTypeInffos_ActTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_UnitTypeInffos] PRIMARY KEY CLUSTERED 
(
	[UTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserInfos](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[UserPwd] [varchar](50) NOT NULL,
	[UserState] [int] NOT NULL CONSTRAINT [DF_UserInfos_UserState]  DEFAULT ((0)),
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_UserInfos_CreateTime]  DEFAULT (getdate()),
	[IsDeleted] [int] NOT NULL CONSTRAINT [DF_UserInfos_IsDeleted]  DEFAULT ((0)),
	[LoginIp] [varchar](20) NULL,
	[LastLoginTime] [datetime] NULL,
	[LoginCount] [int] NOT NULL CONSTRAINT [DF_UserInfos_LoginCount]  DEFAULT ((0)),
	[UserRealPwd] [varchar](50) NULL,
 CONSTRAINT [PK_UserInfos] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRoleInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoleInfos](
	[URId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_UserRoleInfos_CreateTime]  DEFAULT (getdate()),
	[IsDeleted] [int] NOT NULL CONSTRAINT [DF_UserRoleInfos_IsDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK_UserRoleInfos] PRIMARY KEY CLUSTERED 
(
	[URId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[ViewStockGoodsQuery]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewStockGoodsQuery]
AS
SELECT   dbo.GoodsInfos.GoodsNo, dbo.GoodsInfos.GoodsName, dbo.GoodsInfos.GoodsTXNo, dbo.GoodsInfos.GUnit, 
                dbo.StoreInfos.StoreId, dbo.StoreInfos.StoreNo, dbo.StoreInfos.StoreName, dbo.GoodsInfos.GoodsId, 
                dbo.StoreGoodsStockInfos.CurCount, dbo.StoreGoodsStockInfos.StockAmount, dbo.StoreGoodsStockInfos.StCount, 
                dbo.StoreGoodsStockInfos.StAmount, dbo.StoreGoodsStockInfos.StPrice, dbo.StockStoreInfos.StockId, 
                dbo.StockStoreInfos.DealPerson, dbo.StockStoreInfos.Remark, dbo.StockStoreInfos.Creator, 
                dbo.StockStoreInfos.CreateTime, dbo.StockStoreInfos.IsChecked, dbo.StockStoreInfos.CheckPerson, 
                dbo.StockStoreInfos.CheckTime, dbo.StockStoreInfos.StockNo, dbo.GoodsInfos.GTypeId, dbo.GoodsInfos.IsStopped, 
                dbo.GoodsTypeInfos.GTypeName
FROM      dbo.GoodsInfos INNER JOIN
                dbo.StoreGoodsStockInfos ON dbo.GoodsInfos.GoodsId = dbo.StoreGoodsStockInfos.GoodsId INNER JOIN
                dbo.StoreInfos ON dbo.StoreGoodsStockInfos.StoreId = dbo.StoreInfos.StoreId INNER JOIN
                dbo.StockStoreInfos ON dbo.StoreInfos.StoreId = dbo.StockStoreInfos.StoreId INNER JOIN
                dbo.GoodsTypeInfos ON dbo.GoodsInfos.GTypeId = dbo.GoodsTypeInfos.GTypeId


GO
/****** Object:  View [dbo].[ViewStStockGoodsChangeInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewStStockGoodsChangeInfos]
AS
SELECT        dbo.StockChangeInfos.StockChangeId, dbo.StockChangeInfos.ShType, dbo.StockChangeInfos.StoreId, dbo.StockChangeInfos.GoodsId, dbo.StockChangeInfos.InCount, 
                         dbo.StockChangeInfos.OutCount, dbo.ViewStockGoodsQuery.GoodsNo, dbo.ViewStockGoodsQuery.GoodsName, dbo.ViewStockGoodsQuery.GoodsTXNo, 
                         dbo.ViewStockGoodsQuery.GUnit, dbo.ViewStockGoodsQuery.StoreNo, dbo.ViewStockGoodsQuery.StoreName, dbo.ViewStockGoodsQuery.StPrice, 
                         dbo.ViewStockGoodsQuery.StockId AS SheetId, dbo.ViewStockGoodsQuery.DealPerson, dbo.ViewStockGoodsQuery.Creator, dbo.ViewStockGoodsQuery.CreateTime, 
                         dbo.ViewStockGoodsQuery.IsChecked, dbo.ViewStockGoodsQuery.CheckPerson, dbo.ViewStockGoodsQuery.CheckTime, 
                         dbo.ViewStockGoodsQuery.StockNo AS SheetNo, dbo.StockChangeInfos.CurCount
FROM            dbo.ViewStockGoodsQuery INNER JOIN
                         dbo.StockChangeInfos ON dbo.ViewStockGoodsQuery.StoreId = dbo.StockChangeInfos.StoreId AND 
                         dbo.ViewStockGoodsQuery.GoodsId = dbo.StockChangeInfos.GoodsId AND dbo.ViewStockGoodsQuery.StockId = dbo.StockChangeInfos.CheckShId
WHERE        (dbo.StockChangeInfos.ShType = 3)



GO
/****** Object:  View [dbo].[ViewPerGoodsQuery]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewPerGoodsQuery]
AS
SELECT  p.UnitId, u.UnitNo, u.UnitName, pg.GoodsId, g.GoodsName, g.GoodsNo, g.GUnit, p.StoreId, s.StoreName, s.StoreNo, 
                   g.GTypeId, p.DealPerson, u.UTypeId, pg.Count, pg.PerPrice, pg.Amount, p.YHAmount, pg.PerId, p.PerchaseNo, p.Creator, 
                   p.CreateTime, p.IsChecked, p.CheckTime, p.CheckPerson, s.STypeId
FROM      dbo.PerchaseInStoreInfos AS p INNER JOIN
                   dbo.PerchaseGoodsInfos AS pg ON p.PerId = pg.PerId INNER JOIN
                   dbo.UnitInfos AS u ON u.UnitId = p.UnitId INNER JOIN
                   dbo.GoodsInfos AS g ON g.GoodsId = pg.GoodsId INNER JOIN
                   dbo.StoreInfos AS s ON s.StoreId = p.StoreId

GO
/****** Object:  View [dbo].[ViewPerStockGoodsChangeInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewPerStockGoodsChangeInfos]
AS
SELECT        dbo.StockChangeInfos.StockChangeId, dbo.StockChangeInfos.ShType, dbo.StockChangeInfos.GoodsId, dbo.StockChangeInfos.StoreId, dbo.StockChangeInfos.InCount, 
                         dbo.StockChangeInfos.OutCount, dbo.ViewPerGoodsQuery.PerId AS SheetId, dbo.ViewPerGoodsQuery.StoreName, dbo.ViewPerGoodsQuery.StoreNo, 
                         dbo.ViewPerGoodsQuery.DealPerson, dbo.ViewPerGoodsQuery.PerPrice AS Price, dbo.ViewPerGoodsQuery.PerchaseNo AS SheetNo, 
                         dbo.ViewPerGoodsQuery.Creator, dbo.ViewPerGoodsQuery.CreateTime, dbo.ViewPerGoodsQuery.IsChecked, dbo.ViewPerGoodsQuery.CheckTime, 
                         dbo.ViewPerGoodsQuery.CheckPerson, dbo.ViewPerGoodsQuery.GUnit, dbo.ViewPerGoodsQuery.GoodsName, dbo.ViewPerGoodsQuery.GoodsNo, 
                         dbo.ViewPerGoodsQuery.Count, dbo.StockChangeInfos.CurCount, dbo.ViewPerGoodsQuery.Amount
FROM            dbo.StockChangeInfos INNER JOIN
                         dbo.ViewPerGoodsQuery ON dbo.StockChangeInfos.CheckShId = dbo.ViewPerGoodsQuery.PerId AND 
                         dbo.StockChangeInfos.GoodsId = dbo.ViewPerGoodsQuery.GoodsId AND dbo.StockChangeInfos.StoreId = dbo.ViewPerGoodsQuery.StoreId
WHERE        (dbo.StockChangeInfos.ShType = 1)



GO
/****** Object:  View [dbo].[ViewSaleGoodsQuery]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewSaleGoodsQuery]
AS
SELECT  s.UnitId, u.UnitNo, u.UnitName, sg.GoodsId, g.GoodsName, g.GoodsNo, g.GUnit, s.StoreId, st.StoreName, st.StoreNo, 
                   g.GTypeId, s.DealPerson, u.UTypeId, sg.Count, sg.SalePrice, sg.Amount, s.YHAmount, sgs.StPrice, sgs.StAmount, 
                   s.SaleOutNo, s.SaleId, s.Creator, s.CreateTime, s.IsChecked, s.CheckTime, s.CheckPerson, st.STypeId, 
                   sgs.StockAmount
FROM      dbo.SaleOutStoreInfos AS s INNER JOIN
                   dbo.SaleGoodsInfos AS sg ON s.SaleId = sg.SaleId INNER JOIN
                   dbo.UnitInfos AS u ON u.UnitId = s.UnitId INNER JOIN
                   dbo.GoodsInfos AS g ON g.GoodsId = sg.GoodsId INNER JOIN
                   dbo.StoreInfos AS st ON s.StoreId = st.StoreId INNER JOIN
                   dbo.StoreGoodsStockInfos AS sgs ON sgs.GoodsId = sg.GoodsId AND sgs.StoreId = st.StoreId

GO
/****** Object:  View [dbo].[ViewSaleStockGoodsChangeInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewSaleStockGoodsChangeInfos]
AS
SELECT  dbo.StockChangeInfos.StockChangeId, dbo.StockChangeInfos.ShType, dbo.StockChangeInfos.StoreId, 
                   dbo.StockChangeInfos.GoodsId, dbo.StockChangeInfos.InCount, dbo.StockChangeInfos.OutCount, 
                   dbo.ViewSaleGoodsQuery.GoodsName, dbo.ViewSaleGoodsQuery.GoodsNo, dbo.ViewSaleGoodsQuery.GUnit, 
                   dbo.ViewSaleGoodsQuery.StoreName, dbo.ViewSaleGoodsQuery.StoreNo, dbo.ViewSaleGoodsQuery.DealPerson, 
                   dbo.ViewSaleGoodsQuery.SalePrice AS Price, dbo.ViewSaleGoodsQuery.Amount, 
                   dbo.ViewSaleGoodsQuery.SaleOutNo AS SheetNo, dbo.ViewSaleGoodsQuery.SaleId AS SheetId, 
                   dbo.ViewSaleGoodsQuery.Creator, dbo.ViewSaleGoodsQuery.CreateTime, dbo.ViewSaleGoodsQuery.IsChecked, 
                   dbo.ViewSaleGoodsQuery.CheckTime, dbo.ViewSaleGoodsQuery.CheckPerson, dbo.ViewSaleGoodsQuery.Count, 
                   dbo.StockChangeInfos.CurCount, dbo.ViewSaleGoodsQuery.StPrice, dbo.ViewSaleGoodsQuery.StockAmount
FROM      dbo.StockChangeInfos INNER JOIN
                   dbo.ViewSaleGoodsQuery ON dbo.StockChangeInfos.CheckShId = dbo.ViewSaleGoodsQuery.SaleId AND 
                   dbo.StockChangeInfos.StoreId = dbo.ViewSaleGoodsQuery.StoreId AND 
                   dbo.StockChangeInfos.GoodsId = dbo.ViewSaleGoodsQuery.GoodsId
WHERE   (dbo.StockChangeInfos.ShType = 2)

GO
/****** Object:  View [dbo].[ViewGoodsInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewGoodsInfos]
AS
SELECT        dbo.GoodsInfos.GoodsId, dbo.GoodsInfos.GoodsNo, dbo.GoodsInfos.GoodsName, dbo.GoodsInfos.GoodsPYNo, dbo.GoodsInfos.GoodsSName, 
                         dbo.GoodsInfos.GoodsTXNo, dbo.GoodsInfos.GUnit, dbo.GoodsInfos.GTypeId, dbo.GoodsInfos.GProperties, dbo.GoodsInfos.IsStopped, dbo.GoodsInfos.RetailPrice, 
                         dbo.GoodsInfos.Remark, dbo.GoodsInfos.IsDeleted, dbo.GoodsTypeInfos.GTypeName
FROM            dbo.GoodsInfos INNER JOIN
                         dbo.GoodsTypeInfos ON dbo.GoodsInfos.GTypeId = dbo.GoodsTypeInfos.GTypeId



GO
/****** Object:  View [dbo].[ViewMenuInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewMenuInfos]
AS
SELECT  m.MId, m.MName, m.ParentId, p.MName AS ParentName, m.MKey, m.MUrl, m.IsTop, m.MOrder, m.IsDeleted
FROM      dbo.MenuInfos AS m LEFT OUTER JOIN
                   dbo.MenuInfos AS p ON m.ParentId = p.MId


GO
/****** Object:  View [dbo].[ViewPerGoodsInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewPerGoodsInfos]
AS
SELECT        dbo.PerchaseGoodsInfos.PerGoodsId, dbo.PerchaseGoodsInfos.PerId, dbo.PerchaseGoodsInfos.GoodsId, dbo.PerchaseGoodsInfos.GUnit, dbo.GoodsInfos.GoodsNo, 
                         dbo.GoodsInfos.GoodsName, dbo.GoodsInfos.GoodsTXNo, dbo.PerchaseGoodsInfos.Count, dbo.PerchaseGoodsInfos.PerPrice, dbo.PerchaseGoodsInfos.Amount, 
                         dbo.PerchaseGoodsInfos.Remark, dbo.PerchaseGoodsInfos.IsDeleted
FROM            dbo.GoodsInfos INNER JOIN
                         dbo.PerchaseGoodsInfos ON dbo.GoodsInfos.GoodsId = dbo.PerchaseGoodsInfos.GoodsId



GO
/****** Object:  View [dbo].[ViewSaleGoodsInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewSaleGoodsInfos]
AS
SELECT        dbo.SaleGoodsInfos.SaleGoodsId, dbo.SaleGoodsInfos.SaleId, dbo.SaleGoodsInfos.GoodsId, dbo.SaleGoodsInfos.GUnit, dbo.GoodsInfos.GoodsNo, 
                         dbo.GoodsInfos.GoodsName, dbo.GoodsInfos.GoodsTXNo, dbo.SaleGoodsInfos.Count, dbo.SaleGoodsInfos.SalePrice, dbo.SaleGoodsInfos.Amount, 
                         dbo.SaleGoodsInfos.Remark, dbo.SaleGoodsInfos.IsDeleted
FROM            dbo.GoodsInfos INNER JOIN
                         dbo.SaleGoodsInfos ON dbo.GoodsInfos.GoodsId = dbo.SaleGoodsInfos.GoodsId



GO
/****** Object:  View [dbo].[ViewStoreInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewStoreInfos]
AS
SELECT        dbo.StoreInfos.StoreId, dbo.StoreInfos.StoreNo, dbo.StoreInfos.StoreName, dbo.StoreInfos.STypeId, dbo.StoreInfos.StorePYNo, dbo.StoreInfos.StoreOrder, 
                         dbo.StoreInfos.StoreRemark, dbo.StoreInfos.IsDeleted, dbo.StoreTypeInfos.STypeName
FROM            dbo.StoreInfos INNER JOIN
                         dbo.StoreTypeInfos ON dbo.StoreInfos.STypeId = dbo.StoreTypeInfos.STypeId



GO
/****** Object:  View [dbo].[ViewStoreStockUpDownInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewStoreStockUpDownInfos]
AS
SELECT        dbo.GoodsInfos.GoodsId, dbo.GoodsInfos.GoodsNo, dbo.GoodsInfos.GoodsName, dbo.GoodsInfos.GoodsTXNo, dbo.GoodsInfos.GUnit, 
                         dbo.StoreGoodsStockInfos.StockUp, dbo.StoreGoodsStockInfos.StockDown, dbo.StoreGoodsStockInfos.StoreId, dbo.StoreGoodsStockInfos.StoreGoodsId, 
                         dbo.StoreGoodsStockInfos.IsDeleted, dbo.GoodsInfos.GTypeId
FROM            dbo.GoodsInfos INNER JOIN
                         dbo.StoreGoodsStockInfos ON dbo.GoodsInfos.GoodsId = dbo.StoreGoodsStockInfos.GoodsId



GO
/****** Object:  View [dbo].[ViewStStockGoodsInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewStStockGoodsInfos]
AS
SELECT        dbo.GoodsInfos.GoodsId, dbo.GoodsInfos.GoodsNo, dbo.GoodsInfos.GoodsName, dbo.GoodsInfos.GoodsSName, dbo.GoodsInfos.GoodsTXNo, 
                         dbo.GoodsInfos.GUnit, dbo.StStockGoodsInfos.StockId, dbo.StStockGoodsInfos.StCount, dbo.StStockGoodsInfos.StPrice, dbo.StStockGoodsInfos.StAmount, 
                         dbo.StStockGoodsInfos.Remark, dbo.StStockGoodsInfos.StStockId, dbo.StStockGoodsInfos.IsDeleted
FROM            dbo.GoodsInfos INNER JOIN
                         dbo.StStockGoodsInfos ON dbo.GoodsInfos.GoodsId = dbo.StStockGoodsInfos.GoodsId



GO
/****** Object:  View [dbo].[ViewToolMenuInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewToolMenuInfos]
AS
SELECT  dbo.ToolMenuInfos.TMenuId, dbo.ToolMenuInfos.TMenuName, dbo.ToolMenuInfos.TMPic, dbo.ToolMenuInfos.TGroupId, 
                   dbo.ToolGroupInfos.TGroupName, dbo.ToolMenuInfos.TMUrl, dbo.ToolMenuInfos.IsDeleted, dbo.ToolMenuInfos.TMDesp, 
                   dbo.ToolMenuInfos.IsTop, dbo.ToolMenuInfos.TMOrder
FROM      dbo.ToolGroupInfos INNER JOIN
                   dbo.ToolMenuInfos ON dbo.ToolGroupInfos.TGroupId = dbo.ToolMenuInfos.TGroupId


GO
/****** Object:  View [dbo].[ViewUnitInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewUnitInfos]
AS
SELECT        dbo.UnitInfos.UnitId, dbo.UnitInfos.UnitName, dbo.UnitInfos.UnitPYNo, dbo.UnitInfos.UTypeId, dbo.UnitTypeInfos.UTypeName, dbo.UnitInfos.UnitProperties, 
                         dbo.UnitInfos.Address, dbo.UnitInfos.RegionId, dbo.UnitInfos.FullAddress, dbo.UnitInfos.UnitNo, dbo.UnitInfos.IsNoVail, dbo.UnitInfos.IsDeleted, 
                         dbo.UnitInfos.ContactPerson
FROM            dbo.UnitInfos INNER JOIN
                         dbo.UnitTypeInfos ON dbo.UnitInfos.UTypeId = dbo.UnitTypeInfos.UTypeId



GO
/****** Object:  View [dbo].[ViewUserRoleInfos]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewUserRoleInfos]
AS
SELECT        dbo.UserInfos.UserId, dbo.UserInfos.UserName, dbo.RoleInfos.RoleId, dbo.RoleInfos.RoleName, dbo.RoleInfos.IsAdmin
FROM            dbo.UserRoleInfos INNER JOIN
                         dbo.UserInfos ON dbo.UserRoleInfos.UserId = dbo.UserInfos.UserId INNER JOIN
                         dbo.RoleInfos ON dbo.UserRoleInfos.RoleId = dbo.RoleInfos.RoleId



GO
SET IDENTITY_INSERT [dbo].[GoodsInfos] ON 

INSERT [dbo].[GoodsInfos] ([GoodsId], [GoodsNo], [GoodsName], [GoodsPYNo], [GoodsSName], [GoodsTXNo], [GUnit], [GTypeId], [GProperties], [IsStopped], [RetailPrice], [LowPrice], [PrePrice], [Discount], [BidPrice], [Remark], [IsDeleted], [Creator], [CreateTime], [GoodsPic]) VALUES (1, N'YL10001', N'伊利牛奶-儿童成长奶', N'YLNN-ETCCN', N'伊利', N'', N'箱', 8, N'商品', 0, CAST(50.00 AS Decimal(18, 2)), CAST(45.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 100, CAST(0.00 AS Decimal(18, 2)), N'', 0, N'admin', CAST(N'2020-03-02 21:05:06.640' AS DateTime), N'imgs/products/20210126171719.jpg')
INSERT [dbo].[GoodsInfos] ([GoodsId], [GoodsNo], [GoodsName], [GoodsPYNo], [GoodsSName], [GoodsTXNo], [GUnit], [GTypeId], [GProperties], [IsStopped], [RetailPrice], [LowPrice], [PrePrice], [Discount], [BidPrice], [Remark], [IsDeleted], [Creator], [CreateTime], [GoodsPic]) VALUES (2, N'A10001', N'奥利奥饼干', N'ALABG', N'奥利奥', N'', N'袋', 7, N'商品', 0, CAST(3.50 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 100, CAST(0.00 AS Decimal(18, 2)), N'', 0, N'admin', CAST(N'2020-03-02 21:06:24.740' AS DateTime), NULL)
INSERT [dbo].[GoodsInfos] ([GoodsId], [GoodsNo], [GoodsName], [GoodsPYNo], [GoodsSName], [GoodsTXNo], [GUnit], [GTypeId], [GProperties], [IsStopped], [RetailPrice], [LowPrice], [PrePrice], [Discount], [BidPrice], [Remark], [IsDeleted], [Creator], [CreateTime], [GoodsPic]) VALUES (3, N'YL10001', N'韩版连衣裙公主款', N'HBLYQGZK', N'', N'', N'件', 3, N'商品', 0, CAST(59.90 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 100, CAST(0.00 AS Decimal(18, 2)), N'', 0, N'admin', CAST(N'2020-03-02 21:08:46.747' AS DateTime), NULL)
INSERT [dbo].[GoodsInfos] ([GoodsId], [GoodsNo], [GoodsName], [GoodsPYNo], [GoodsSName], [GoodsTXNo], [GUnit], [GTypeId], [GProperties], [IsStopped], [RetailPrice], [LowPrice], [PrePrice], [Discount], [BidPrice], [Remark], [IsDeleted], [Creator], [CreateTime], [GoodsPic]) VALUES (4, N'YR10001', N'优质羽绒服(红\白\蓝)', N'YZYRF(H\B\L)', N'羽绒服(', N'', N'件', 6, N'商品', 0, CAST(299.00 AS Decimal(18, 2)), CAST(259.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 100, CAST(0.00 AS Decimal(18, 2)), N'', 0, N'admin', CAST(N'2020-03-02 21:10:12.053' AS DateTime), NULL)
INSERT [dbo].[GoodsInfos] ([GoodsId], [GoodsNo], [GoodsName], [GoodsPYNo], [GoodsSName], [GoodsTXNo], [GUnit], [GTypeId], [GProperties], [IsStopped], [RetailPrice], [LowPrice], [PrePrice], [Discount], [BidPrice], [Remark], [IsDeleted], [Creator], [CreateTime], [GoodsPic]) VALUES (5, N'', N'蒙牛牛奶', N'MNNN', N'蒙牛', N'', N'箱', 7, N'商品', 0, CAST(50.00 AS Decimal(18, 2)), CAST(40.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 100, CAST(0.00 AS Decimal(18, 2)), N'', 0, N'admin', CAST(N'2020-03-06 11:51:08.040' AS DateTime), NULL)
INSERT [dbo].[GoodsInfos] ([GoodsId], [GoodsNo], [GoodsName], [GoodsPYNo], [GoodsSName], [GoodsTXNo], [GUnit], [GTypeId], [GProperties], [IsStopped], [RetailPrice], [LowPrice], [PrePrice], [Discount], [BidPrice], [Remark], [IsDeleted], [Creator], [CreateTime], [GoodsPic]) VALUES (6, N'', N'衬衣', N'CY', N'', N'', N'件', 4, N'商品', 0, CAST(39.00 AS Decimal(18, 2)), CAST(29.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 100, CAST(0.00 AS Decimal(18, 2)), N'', 0, N'admin', CAST(N'2020-03-06 15:48:20.657' AS DateTime), NULL)
INSERT [dbo].[GoodsInfos] ([GoodsId], [GoodsNo], [GoodsName], [GoodsPYNo], [GoodsSName], [GoodsTXNo], [GUnit], [GTypeId], [GProperties], [IsStopped], [RetailPrice], [LowPrice], [PrePrice], [Discount], [BidPrice], [Remark], [IsDeleted], [Creator], [CreateTime], [GoodsPic]) VALUES (7, N'TLS10001', N'特仑苏纯牛奶', N'TLSCNN', N'纯牛奶', N'', N'箱', 8, N'商品', 0, CAST(56.00 AS Decimal(18, 2)), CAST(45.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), 100, CAST(40.00 AS Decimal(18, 2)), N'特仑苏纯牛奶，12盒装，每盒250ml,无活动.', 0, N'admin', CAST(N'2020-06-29 10:02:59.937' AS DateTime), NULL)
INSERT [dbo].[GoodsInfos] ([GoodsId], [GoodsNo], [GoodsName], [GoodsPYNo], [GoodsSName], [GoodsTXNo], [GUnit], [GTypeId], [GProperties], [IsStopped], [RetailPrice], [LowPrice], [PrePrice], [Discount], [BidPrice], [Remark], [IsDeleted], [Creator], [CreateTime], [GoodsPic]) VALUES (1007, N'', N'早餐饼干', N'ZCBG', N'早餐饼', N'', N'盒', 13, N'商品', 0, CAST(5.00 AS Decimal(18, 2)), CAST(3.50 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 100, CAST(0.00 AS Decimal(18, 2)), N'', 0, N'admin', CAST(N'2020-07-09 21:31:40.007' AS DateTime), NULL)
INSERT [dbo].[GoodsInfos] ([GoodsId], [GoodsNo], [GoodsName], [GoodsPYNo], [GoodsSName], [GoodsTXNo], [GUnit], [GTypeId], [GProperties], [IsStopped], [RetailPrice], [LowPrice], [PrePrice], [Discount], [BidPrice], [Remark], [IsDeleted], [Creator], [CreateTime], [GoodsPic]) VALUES (1008, N'DXTX001', N'短袖T恤-白色', N'DXTX-BS', N'T恤-白色 学生', N'', N'件', 14, N'商品', 0, CAST(39.00 AS Decimal(18, 2)), CAST(29.90 AS Decimal(18, 2)), CAST(35.00 AS Decimal(18, 2)), 100, CAST(25.00 AS Decimal(18, 2)), N'', 0, N'admin', CAST(N'2020-09-27 11:52:56.917' AS DateTime), N'Imgs/products/20200927115925.jpg')
INSERT [dbo].[GoodsInfos] ([GoodsId], [GoodsNo], [GoodsName], [GoodsPYNo], [GoodsSName], [GoodsTXNo], [GUnit], [GTypeId], [GProperties], [IsStopped], [RetailPrice], [LowPrice], [PrePrice], [Discount], [BidPrice], [Remark], [IsDeleted], [Creator], [CreateTime], [GoodsPic]) VALUES (1009, N'CXTX001', N'长袖T恤', N'CXTX', N'', N'', N'件', 14, N'商品', 0, CAST(49.00 AS Decimal(18, 2)), CAST(39.00 AS Decimal(18, 2)), CAST(45.00 AS Decimal(18, 2)), 100, CAST(35.00 AS Decimal(18, 2)), N'', 0, N'admin', CAST(N'2020-09-27 12:02:05.033' AS DateTime), N'Imgs/products/20200927120158.jpg')
INSERT [dbo].[GoodsInfos] ([GoodsId], [GoodsNo], [GoodsName], [GoodsPYNo], [GoodsSName], [GoodsTXNo], [GUnit], [GTypeId], [GProperties], [IsStopped], [RetailPrice], [LowPrice], [PrePrice], [Discount], [BidPrice], [Remark], [IsDeleted], [Creator], [CreateTime], [GoodsPic]) VALUES (1010, N'MN10001', N'蒙牛酸奶--QQ星', N'MNSN--QQX', N'蒙牛酸奶', NULL, N'箱', 8, N'商品', 0, CAST(48.00 AS Decimal(18, 2)), CAST(42.00 AS Decimal(18, 2)), CAST(45.00 AS Decimal(18, 2)), 100, CAST(38.00 AS Decimal(18, 2)), N'蒙牛酸奶--QQ星蒙牛酸奶--QQ星', 0, N'admin', CAST(N'2021-01-26 17:48:55.530' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[GoodsInfos] OFF
SET IDENTITY_INSERT [dbo].[GoodsTypeInfos] ON 

INSERT [dbo].[GoodsTypeInfos] ([GTypeId], [GTypeName], [ParentId], [ParentName], [GTypeNo], [GTPYNo], [GTOrder], [Creator], [CreateTime], [IsDeleted]) VALUES (1, N'服装', 0, NULL, N'10001', N'FZ', 1, N'admin', CAST(N'2020-03-02 17:28:14.883' AS DateTime), 0)
INSERT [dbo].[GoodsTypeInfos] ([GTypeId], [GTypeName], [ParentId], [ParentName], [GTypeNo], [GTPYNo], [GTOrder], [Creator], [CreateTime], [IsDeleted]) VALUES (2, N'食品', 0, NULL, N'', N'SP', 2, N'admin', CAST(N'2020-03-02 17:28:30.813' AS DateTime), 0)
INSERT [dbo].[GoodsTypeInfos] ([GTypeId], [GTypeName], [ParentId], [ParentName], [GTypeNo], [GTPYNo], [GTOrder], [Creator], [CreateTime], [IsDeleted]) VALUES (3, N'春装1', 1, N'服装', N'', N'CZ1', 1, N'admin', CAST(N'2020-03-02 17:29:17.313' AS DateTime), 0)
INSERT [dbo].[GoodsTypeInfos] ([GTypeId], [GTypeName], [ParentId], [ParentName], [GTypeNo], [GTPYNo], [GTOrder], [Creator], [CreateTime], [IsDeleted]) VALUES (4, N'夏装', 1, N'服装', N'', N'XZ', 2, N'admin', CAST(N'2020-03-02 17:29:47.013' AS DateTime), 0)
INSERT [dbo].[GoodsTypeInfos] ([GTypeId], [GTypeName], [ParentId], [ParentName], [GTypeNo], [GTPYNo], [GTOrder], [Creator], [CreateTime], [IsDeleted]) VALUES (5, N'秋装', 1, N'服装', N'', N'QZ', 2, N'admin', CAST(N'2020-03-02 17:29:55.770' AS DateTime), 0)
INSERT [dbo].[GoodsTypeInfos] ([GTypeId], [GTypeName], [ParentId], [ParentName], [GTypeNo], [GTPYNo], [GTOrder], [Creator], [CreateTime], [IsDeleted]) VALUES (6, N'冬装', 1, N'服装', N'', N'DZ', 2, N'admin', CAST(N'2020-03-02 17:30:02.390' AS DateTime), 0)
INSERT [dbo].[GoodsTypeInfos] ([GTypeId], [GTypeName], [ParentId], [ParentName], [GTypeNo], [GTPYNo], [GTOrder], [Creator], [CreateTime], [IsDeleted]) VALUES (7, N'零食', 2, N'食品', N'', N'LS', 0, N'admin', CAST(N'2020-03-02 17:30:39.387' AS DateTime), 0)
INSERT [dbo].[GoodsTypeInfos] ([GTypeId], [GTypeName], [ParentId], [ParentName], [GTypeNo], [GTPYNo], [GTOrder], [Creator], [CreateTime], [IsDeleted]) VALUES (8, N'牛奶', 2, N'食品', N'', N'NN', 2, N'admin', CAST(N'2020-03-02 17:30:51.310' AS DateTime), 0)
INSERT [dbo].[GoodsTypeInfos] ([GTypeId], [GTypeName], [ParentId], [ParentName], [GTypeNo], [GTPYNo], [GTOrder], [Creator], [CreateTime], [IsDeleted]) VALUES (9, N'果汁', 2, N'食品', N'', N'GZ', 1, N'admin', CAST(N'2020-06-28 10:42:57.793' AS DateTime), 0)
INSERT [dbo].[GoodsTypeInfos] ([GTypeId], [GTypeName], [ParentId], [ParentName], [GTypeNo], [GTPYNo], [GTOrder], [Creator], [CreateTime], [IsDeleted]) VALUES (10, N'休闲套装', 4, N'夏装', N'', N'XXTZ', 1, N'admin', CAST(N'2020-06-28 10:50:35.827' AS DateTime), 0)
INSERT [dbo].[GoodsTypeInfos] ([GTypeId], [GTypeName], [ParentId], [ParentName], [GTypeNo], [GTPYNo], [GTOrder], [Creator], [CreateTime], [IsDeleted]) VALUES (11, N'运动品', 0, NULL, N'10003', N'YDP', 3, N'admin', CAST(N'2020-06-28 23:00:24.417' AS DateTime), 0)
INSERT [dbo].[GoodsTypeInfos] ([GTypeId], [GTypeName], [ParentId], [ParentName], [GTypeNo], [GTPYNo], [GTOrder], [Creator], [CreateTime], [IsDeleted]) VALUES (13, N'饼干', 2, N'食品', N'', N'BG', 4, N'admin', CAST(N'2020-07-09 21:13:48.120' AS DateTime), 0)
INSERT [dbo].[GoodsTypeInfos] ([GTypeId], [GTypeName], [ParentId], [ParentName], [GTypeNo], [GTPYNo], [GTOrder], [Creator], [CreateTime], [IsDeleted]) VALUES (14, N'T恤-女', 3, N'春装1', N'', N'TX-N', 0, N'admin', CAST(N'2020-09-21 16:22:47.810' AS DateTime), 0)
INSERT [dbo].[GoodsTypeInfos] ([GTypeId], [GTypeName], [ParentId], [ParentName], [GTypeNo], [GTPYNo], [GTOrder], [Creator], [CreateTime], [IsDeleted]) VALUES (15, N'休闲款-短袖', 14, N'T恤-女', N'', N'XXK-DX', 0, N'admin', CAST(N'2020-09-21 16:24:33.260' AS DateTime), 0)
INSERT [dbo].[GoodsTypeInfos] ([GTypeId], [GTypeName], [ParentId], [ParentName], [GTypeNo], [GTPYNo], [GTOrder], [Creator], [CreateTime], [IsDeleted]) VALUES (16, N'饮料', 2, N'食品', N'', N'YL', 0, N'admin', CAST(N'2020-09-21 22:52:06.730' AS DateTime), 0)
INSERT [dbo].[GoodsTypeInfos] ([GTypeId], [GTypeName], [ParentId], [ParentName], [GTypeNo], [GTPYNo], [GTOrder], [Creator], [CreateTime], [IsDeleted]) VALUES (17, N'球衣', 11, N'运动品', N'', N'QY', 1, N'admin', CAST(N'2020-09-25 16:27:06.963' AS DateTime), 1)
INSERT [dbo].[GoodsTypeInfos] ([GTypeId], [GTypeName], [ParentId], [ParentName], [GTypeNo], [GTPYNo], [GTOrder], [Creator], [CreateTime], [IsDeleted]) VALUES (18, N'女式春装', 1, N'服装', NULL, N'NSCZ', 6, N'admin', CAST(N'2021-01-25 17:37:19.003' AS DateTime), 0)
INSERT [dbo].[GoodsTypeInfos] ([GTypeId], [GTypeName], [ParentId], [ParentName], [GTypeNo], [GTPYNo], [GTOrder], [Creator], [CreateTime], [IsDeleted]) VALUES (19, N'T恤-男', 3, N'春装1', NULL, N'TX-N', 2, N'admin', CAST(N'2021-03-03 21:20:45.260' AS DateTime), 0)
INSERT [dbo].[GoodsTypeInfos] ([GTypeId], [GTypeName], [ParentId], [ParentName], [GTypeNo], [GTPYNo], [GTOrder], [Creator], [CreateTime], [IsDeleted]) VALUES (1019, N'春装2', 1, N'服装', N'100015', N'CZ2', 2, N'admin', CAST(N'2021-03-11 20:11:22.230' AS DateTime), 0)
INSERT [dbo].[GoodsTypeInfos] ([GTypeId], [GTypeName], [ParentId], [ParentName], [GTypeNo], [GTPYNo], [GTOrder], [Creator], [CreateTime], [IsDeleted]) VALUES (1020, N'休闲装', 3, N'春装1', NULL, N'XXZ', 0, N'admin', CAST(N'2021-03-11 20:12:25.343' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[GoodsTypeInfos] OFF
SET IDENTITY_INSERT [dbo].[GoodsUnitInfos] ON 

INSERT [dbo].[GoodsUnitInfos] ([GUnitId], [GUnitName], [GUnitPYNo], [GUnitOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (1, N'个', N'G', 9, 0, N'admin', CAST(N'2020-03-02 18:37:59.903' AS DateTime))
INSERT [dbo].[GoodsUnitInfos] ([GUnitId], [GUnitName], [GUnitPYNo], [GUnitOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (2, N'包', N'B', 2, 0, N'admin', CAST(N'2020-03-02 18:38:09.387' AS DateTime))
INSERT [dbo].[GoodsUnitInfos] ([GUnitId], [GUnitName], [GUnitPYNo], [GUnitOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (3, N'副', N'F', 6, 0, N'admin', CAST(N'2020-03-02 18:38:19.607' AS DateTime))
INSERT [dbo].[GoodsUnitInfos] ([GUnitId], [GUnitName], [GUnitPYNo], [GUnitOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (4, N'件', N'J', 4, 0, N'admin', CAST(N'2020-03-02 18:38:28.677' AS DateTime))
INSERT [dbo].[GoodsUnitInfos] ([GUnitId], [GUnitName], [GUnitPYNo], [GUnitOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (5, N'箱', N'X', 5, 0, N'admin', CAST(N'2020-03-02 18:38:36.600' AS DateTime))
INSERT [dbo].[GoodsUnitInfos] ([GUnitId], [GUnitName], [GUnitPYNo], [GUnitOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (6, N'盒', N'H', 6, 0, N'admin', CAST(N'2020-03-02 18:38:47.900' AS DateTime))
INSERT [dbo].[GoodsUnitInfos] ([GUnitId], [GUnitName], [GUnitPYNo], [GUnitOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (7, N'支', N'Z', 7, 0, N'admin', CAST(N'2020-03-02 18:39:05.323' AS DateTime))
INSERT [dbo].[GoodsUnitInfos] ([GUnitId], [GUnitName], [GUnitPYNo], [GUnitOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (8, N'双', N'S', 8, 0, N'admin', CAST(N'2020-03-02 18:39:21.673' AS DateTime))
INSERT [dbo].[GoodsUnitInfos] ([GUnitId], [GUnitName], [GUnitPYNo], [GUnitOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (9, N'袋', N'D', 9, 0, N'admin', CAST(N'2020-03-02 18:39:49.057' AS DateTime))
INSERT [dbo].[GoodsUnitInfos] ([GUnitId], [GUnitName], [GUnitPYNo], [GUnitOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (11, N'对', N'D', 1, 0, N'admin', CAST(N'2020-04-17 15:04:39.843' AS DateTime))
INSERT [dbo].[GoodsUnitInfos] ([GUnitId], [GUnitName], [GUnitPYNo], [GUnitOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (12, N'付', N'F', 5, 0, N'admin', CAST(N'2020-04-17 15:06:11.380' AS DateTime))
INSERT [dbo].[GoodsUnitInfos] ([GUnitId], [GUnitName], [GUnitPYNo], [GUnitOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (13, N'张', N'Z', 4, 0, N'', CAST(N'2020-07-01 21:27:16.867' AS DateTime))
INSERT [dbo].[GoodsUnitInfos] ([GUnitId], [GUnitName], [GUnitPYNo], [GUnitOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (14, N'只', N'Z', 10, 0, N'', CAST(N'2020-07-09 21:25:56.367' AS DateTime))
INSERT [dbo].[GoodsUnitInfos] ([GUnitId], [GUnitName], [GUnitPYNo], [GUnitOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (16, N'套', N'T', 11, 0, N'admin', CAST(N'2021-01-25 14:44:34.130' AS DateTime))
INSERT [dbo].[GoodsUnitInfos] ([GUnitId], [GUnitName], [GUnitPYNo], [GUnitOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (17, N'张1', N'Z1', 0, 1, N'admin', CAST(N'2021-03-11 20:49:41.707' AS DateTime))
SET IDENTITY_INSERT [dbo].[GoodsUnitInfos] OFF
SET IDENTITY_INSERT [dbo].[MenuInfos] ON 

INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (1, N'系统管理', 0, N'Alt+X', NULL, 0, 1, 0, N'admin', CAST(N'2020-02-07 17:31:35.863' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (2, N'基础资料', 0, N'Alt+B', NULL, 0, 2, 0, N'admin', CAST(N'2020-02-07 17:32:35.200' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (4, N'业务管理', 0, N'Alt+L', NULL, 0, 3, 0, N'admin', CAST(N'2020-02-07 17:34:22.517' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (5, N'查询中心', 0, N'Alt+Q', NULL, 0, 4, 0, N'admin', CAST(N'2020-02-07 17:40:32.110' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (6, N'退出系统', 0, N'Alt+E', NULL, 0, 5, 0, N'admin', CAST(N'2020-02-07 17:41:29.163' AS DateTime), N'ExitSystem')
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (7, N'菜单管理', 1, N'Ctrl+M', N'SM.FrmMenuList', 0, 2, 0, N'admin', CAST(N'2020-02-07 17:42:47.173' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (8, N'角色管理', 1, N'Ctrl+R', N'SM.FrmRoleList', 1, 2, 0, N'admin', CAST(N'2020-02-07 17:43:50.007' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (9, N'权限分配', 1, NULL, N'SM.FrmRight', 1, 4, 0, N'admin', CAST(N'2020-02-07 17:48:22.200' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (10, N'修改密码', 1, NULL, N'SM.FrmModifyPwd', 1, 5, 0, N'admin', CAST(N'2020-02-07 17:53:56.210' AS DateTime), N'ModifyPwd')
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (11, N'备份数据', 1, NULL, N'SM.FrmBackUpData', 1, 5, 0, N'admin', CAST(N'2020-02-07 17:54:30.643' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (13, N'用户管理', 1, N'', N'SM.FrmUserList', 1, 1, 0, N'admin', CAST(N'2020-02-07 17:55:31.927' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (15, N'商品信息', 2, N'', N'BM.FrmGoodsList', 0, 2, 0, N'admin', CAST(N'2020-02-11 21:12:52.580' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (16, N'往来单位类别', 2, N'', N'BM.FrmUnitTypeList', 1, 3, 0, N'admin', CAST(N'2020-02-13 14:20:34.790' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (17, N'仓库类别', 2, N'', N'BM.FrmStoreTypeList', 1, 4, 0, N'admin', CAST(N'2020-02-13 14:21:01.850' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (18, N'计量单位', 2, N'', N'BM.FrmGUnitList', 1, 5, 0, N'admin', CAST(N'2020-02-13 14:21:43.270' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (19, N'往来单位', 2, N'', N'BM.FrmUnitList', 0, 6, 0, N'admin', CAST(N'2020-02-13 14:23:40.153' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (20, N'仓库信息', 2, N'', N'BM.FrmStoreList', 0, 7, 0, N'admin', CAST(N'2020-02-13 14:24:41.937' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (21, N'采购入库', 4, N'Ctrl+P', N'Perchase.FrmPerchaseInStore', 0, 1, 0, N'admin', CAST(N'2020-02-17 12:06:42.797' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (22, N'销售出库', 4, N'Ctrl+S', N'Sale.FrmSaleOutStore', 0, 2, 0, N'admin', CAST(N'2020-02-17 12:07:26.340' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (23, N'采购查询', 5, N'', NULL, 0, 2, 0, N'admin', CAST(N'2020-02-17 12:08:26.160' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (24, N'销售查询', 5, N'', NULL, 0, 3, 0, N'admin', CAST(N'2020-02-17 12:08:37.777' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (25, N'库存查询', 5, N'', NULL, 0, 3, 0, N'admin', CAST(N'2020-02-17 12:08:50.730' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (26, N'采购--按供应商查询', 23, N'', N'Perchase.FrmPerchaseQueryBySupplier', 0, 1, 0, N'admin', CAST(N'2020-02-17 12:10:06.877' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (27, N'采购--按仓库查询', 23, N'', N'Perchase.FrmPerchaseQueryByStore', 0, 2, 0, N'admin', CAST(N'2020-02-17 12:10:29.037' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (28, N'采购--按商品查询', 23, N'', N'Perchase.FrmPerchaseQueryByGoods', 0, 3, 0, N'admin', CAST(N'2020-02-17 12:10:55.077' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (29, N'销售--按客户查询', 24, N'', N'Sale.FrmSaleQueryByCustomer', 0, 1, 0, N'admin', CAST(N'2020-02-17 12:11:57.040' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (30, N'销售--按仓库查询', 24, N'', N'Sale.FrmSaleQueryByStore', 0, 2, 0, N'admin', CAST(N'2020-02-17 12:12:36.710' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (31, N'设置库存上下限', 4, N'', N'Stock.FrmStockUpDownSet', 0, 3, 0, N'admin', CAST(N'2020-02-20 00:15:11.060' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (32, N'销售--按商品查询', 24, N'', N'Sale.FrmSaleQueryByGoods', 0, 3, 0, N'admin', CAST(N'2020-02-23 16:00:55.847' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (33, N'单据查询', 5, N'', N'QM.FrmSheetQuery', 0, 1, 0, N'admin', CAST(N'2020-02-23 16:02:18.697' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (34, N'期初库存设置', 2, N'', N'Stock.FrmStartStockInfo', 0, 8, 0, N'admin', CAST(N'2020-02-26 15:58:33.800' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (35, N'仓库库存查询', 25, N'', N'Stock.FrmStoreStockQuery', 0, 2, 0, N'admin', CAST(N'2020-02-26 16:01:01.223' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (37, N'期初开账', 2, N'', NULL, 0, 8, 0, N'admin', CAST(N'2020-03-03 16:00:39.973' AS DateTime), N'OpenSys')
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (38, N'反开账', 2, N'', NULL, 0, 8, 0, N'admin', CAST(N'2020-03-03 16:00:50.787' AS DateTime), N'UnOpenSys')
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (39, N'商品类别', 2, N'', N'BM.FrmGoodsTypeList', 1, 1, 0, N'admin', CAST(N'2020-03-05 21:42:09.140' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (42, N'工具菜单管理', 1, N'', N'SM.FrmToolMenuList', 0, 0, 0, N'admin', CAST(N'2020-04-08 16:03:19.550' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (43, N'选择供应商', 2, N'', N'BM.FrmChooseUnits', 0, 0, 1, N'admin', CAST(N'2020-07-01 21:17:40.177' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (45, N'系统设置', 1, N'Ctrl+V', NULL, 0, 8, 1, N'admin', CAST(N'2021-01-19 23:51:58.937' AS DateTime), NULL)
INSERT [dbo].[MenuInfos] ([MId], [MName], [ParentId], [MKey], [MUrl], [IsTop], [MOrder], [IsDeleted], [Creator], [CreateTime], [MDesp]) VALUES (46, N'系统设置', 1, NULL, NULL, 0, 0, 1, N'admin', CAST(N'2021-03-10 21:44:57.580' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[MenuInfos] OFF
SET IDENTITY_INSERT [dbo].[PerchaseGoodsInfos] ON 

INSERT [dbo].[PerchaseGoodsInfos] ([PerGoodsId], [PerId], [GoodsId], [GUnit], [Count], [PerPrice], [Amount], [Remark], [IsDeleted]) VALUES (1, 1, 2, N'袋', 500, CAST(2.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), N'', 0)
INSERT [dbo].[PerchaseGoodsInfos] ([PerGoodsId], [PerId], [GoodsId], [GUnit], [Count], [PerPrice], [Amount], [Remark], [IsDeleted]) VALUES (2, 1, 1, N'箱', 50, CAST(35.00 AS Decimal(18, 2)), CAST(1750.00 AS Decimal(18, 2)), N'', 0)
INSERT [dbo].[PerchaseGoodsInfos] ([PerGoodsId], [PerId], [GoodsId], [GUnit], [Count], [PerPrice], [Amount], [Remark], [IsDeleted]) VALUES (4, 4, 4, N'件', 10, CAST(160.00 AS Decimal(18, 2)), CAST(1600.00 AS Decimal(18, 2)), N'', 0)
INSERT [dbo].[PerchaseGoodsInfos] ([PerGoodsId], [PerId], [GoodsId], [GUnit], [Count], [PerPrice], [Amount], [Remark], [IsDeleted]) VALUES (5, 4, 3, N'件', 200, CAST(40.00 AS Decimal(18, 2)), CAST(8000.00 AS Decimal(18, 2)), N'', 0)
INSERT [dbo].[PerchaseGoodsInfos] ([PerGoodsId], [PerId], [GoodsId], [GUnit], [Count], [PerPrice], [Amount], [Remark], [IsDeleted]) VALUES (6, 5, 1, N'箱', 50, CAST(35.00 AS Decimal(18, 2)), CAST(1750.00 AS Decimal(18, 2)), N'', 0)
INSERT [dbo].[PerchaseGoodsInfos] ([PerGoodsId], [PerId], [GoodsId], [GUnit], [Count], [PerPrice], [Amount], [Remark], [IsDeleted]) VALUES (7, 6, 1, N'箱', 20, CAST(38.00 AS Decimal(18, 2)), CAST(760.00 AS Decimal(18, 2)), N'', 0)
INSERT [dbo].[PerchaseGoodsInfos] ([PerGoodsId], [PerId], [GoodsId], [GUnit], [Count], [PerPrice], [Amount], [Remark], [IsDeleted]) VALUES (8, 6, 5, N'箱', 30, CAST(35.00 AS Decimal(18, 2)), CAST(1050.00 AS Decimal(18, 2)), N'', 0)
INSERT [dbo].[PerchaseGoodsInfos] ([PerGoodsId], [PerId], [GoodsId], [GUnit], [Count], [PerPrice], [Amount], [Remark], [IsDeleted]) VALUES (9, 6, 7, N'箱', 30, CAST(40.00 AS Decimal(18, 2)), CAST(1200.00 AS Decimal(18, 2)), N'', 0)
INSERT [dbo].[PerchaseGoodsInfos] ([PerGoodsId], [PerId], [GoodsId], [GUnit], [Count], [PerPrice], [Amount], [Remark], [IsDeleted]) VALUES (10, 1007, 6, N'件', 100, CAST(30.00 AS Decimal(18, 2)), CAST(3000.00 AS Decimal(18, 2)), N'', 0)
INSERT [dbo].[PerchaseGoodsInfos] ([PerGoodsId], [PerId], [GoodsId], [GUnit], [Count], [PerPrice], [Amount], [Remark], [IsDeleted]) VALUES (11, 1007, 3, N'件', 50, CAST(35.00 AS Decimal(18, 2)), CAST(1750.00 AS Decimal(18, 2)), N'', 0)
INSERT [dbo].[PerchaseGoodsInfos] ([PerGoodsId], [PerId], [GoodsId], [GUnit], [Count], [PerPrice], [Amount], [Remark], [IsDeleted]) VALUES (12, 1007, 4, N'件', 20, CAST(200.00 AS Decimal(18, 2)), CAST(4000.00 AS Decimal(18, 2)), N'', 0)
INSERT [dbo].[PerchaseGoodsInfos] ([PerGoodsId], [PerId], [GoodsId], [GUnit], [Count], [PerPrice], [Amount], [Remark], [IsDeleted]) VALUES (13, 1009, 1, N'箱', 200, CAST(35.00 AS Decimal(18, 2)), CAST(7000.00 AS Decimal(18, 2)), N'', 0)
INSERT [dbo].[PerchaseGoodsInfos] ([PerGoodsId], [PerId], [GoodsId], [GUnit], [Count], [PerPrice], [Amount], [Remark], [IsDeleted]) VALUES (14, 1009, 5, N'箱', 100, CAST(39.00 AS Decimal(18, 2)), CAST(3900.00 AS Decimal(18, 2)), N'', 0)
INSERT [dbo].[PerchaseGoodsInfos] ([PerGoodsId], [PerId], [GoodsId], [GUnit], [Count], [PerPrice], [Amount], [Remark], [IsDeleted]) VALUES (15, 1009, 1010, N'箱', 200, CAST(42.00 AS Decimal(18, 2)), CAST(8400.00 AS Decimal(18, 2)), N'', 0)
SET IDENTITY_INSERT [dbo].[PerchaseGoodsInfos] OFF
SET IDENTITY_INSERT [dbo].[PerchaseInStoreInfos] ON 

INSERT [dbo].[PerchaseInStoreInfos] ([PerId], [PerchaseNo], [UnitId], [StoreId], [DealPerson], [PayDesp], [ThisAmount], [Remark], [TotalAmount], [YHAmount], [Creator], [CreateTime], [IsChecked], [IsPayed], [IsPayFull], [CheckTime], [CheckPerson], [PayTime], [IsDeleted]) VALUES (1, N'CGD-20200715-0001', 2, 1, N'罗丽', N'现金 500.00;银行卡 1000', CAST(1500.00 AS Decimal(18, 2)), N'', CAST(2750.00 AS Decimal(18, 2)), CAST(2750.00 AS Decimal(18, 2)), N'admin', CAST(N'2020-07-15 00:00:00.000' AS DateTime), 1, 1, 0, CAST(N'2020-07-15 15:45:15.630' AS DateTime), N'admin', CAST(N'2020-07-15 15:44:49.117' AS DateTime), 0)
INSERT [dbo].[PerchaseInStoreInfos] ([PerId], [PerchaseNo], [UnitId], [StoreId], [DealPerson], [PayDesp], [ThisAmount], [Remark], [TotalAmount], [YHAmount], [Creator], [CreateTime], [IsChecked], [IsPayed], [IsPayFull], [CheckTime], [CheckPerson], [PayTime], [IsDeleted]) VALUES (4, N'CGD-20201009-0001', 4, 1, N'王红', N'现金 1000;银行卡 3000', CAST(4000.00 AS Decimal(18, 2)), N'', CAST(9600.00 AS Decimal(18, 2)), CAST(9600.00 AS Decimal(18, 2)), N'admin', CAST(N'2020-10-09 00:00:00.000' AS DateTime), 3, 1, 0, CAST(N'2020-10-09 15:56:17.040' AS DateTime), N'admin', CAST(N'2020-10-09 10:53:36.907' AS DateTime), 0)
INSERT [dbo].[PerchaseInStoreInfos] ([PerId], [PerchaseNo], [UnitId], [StoreId], [DealPerson], [PayDesp], [ThisAmount], [Remark], [TotalAmount], [YHAmount], [Creator], [CreateTime], [IsChecked], [IsPayed], [IsPayFull], [CheckTime], [CheckPerson], [PayTime], [IsDeleted]) VALUES (5, N'CGD-20201019-0001', 2, 3, N'王红', N'', CAST(0.00 AS Decimal(18, 2)), N'', CAST(1750.00 AS Decimal(18, 2)), CAST(1750.00 AS Decimal(18, 2)), N'admin', CAST(N'2020-10-19 00:00:00.000' AS DateTime), 1, 0, 0, CAST(N'2020-10-19 10:48:14.433' AS DateTime), N'admin', NULL, 0)
INSERT [dbo].[PerchaseInStoreInfos] ([PerId], [PerchaseNo], [UnitId], [StoreId], [DealPerson], [PayDesp], [ThisAmount], [Remark], [TotalAmount], [YHAmount], [Creator], [CreateTime], [IsChecked], [IsPayed], [IsPayFull], [CheckTime], [CheckPerson], [PayTime], [IsDeleted]) VALUES (6, N'CGD-20210201-0001', 3, 2, N'王林', N'现金 100;银行卡 1000', CAST(1100.00 AS Decimal(18, 2)), NULL, CAST(3010.00 AS Decimal(18, 2)), CAST(3010.00 AS Decimal(18, 2)), N'admin', CAST(N'2021-02-01 00:00:00.000' AS DateTime), 3, 1, 0, CAST(N'2021-02-01 17:29:51.023' AS DateTime), N'admin', CAST(N'2021-02-01 17:09:54.510' AS DateTime), 0)
INSERT [dbo].[PerchaseInStoreInfos] ([PerId], [PerchaseNo], [UnitId], [StoreId], [DealPerson], [PayDesp], [ThisAmount], [Remark], [TotalAmount], [YHAmount], [Creator], [CreateTime], [IsChecked], [IsPayed], [IsPayFull], [CheckTime], [CheckPerson], [PayTime], [IsDeleted]) VALUES (1007, N'CGD-20210317-0001', 4, 1, N'Fresh', N'现金 500;银行卡 1000;微信 800', CAST(2300.00 AS Decimal(18, 2)), NULL, CAST(8750.00 AS Decimal(18, 2)), CAST(8750.00 AS Decimal(18, 2)), N'Fresh', CAST(N'2021-03-17 00:00:00.000' AS DateTime), 3, 1, 0, CAST(N'2021-03-17 20:53:32.047' AS DateTime), N'admin', CAST(N'2021-03-17 20:46:38.423' AS DateTime), 0)
INSERT [dbo].[PerchaseInStoreInfos] ([PerId], [PerchaseNo], [UnitId], [StoreId], [DealPerson], [PayDesp], [ThisAmount], [Remark], [TotalAmount], [YHAmount], [Creator], [CreateTime], [IsChecked], [IsPayed], [IsPayFull], [CheckTime], [CheckPerson], [PayTime], [IsDeleted]) VALUES (1009, N'CGD-20210318-0001', 2, 1, N'王丽', N'现金 2000;银行卡 3000', CAST(5000.00 AS Decimal(18, 2)), NULL, CAST(19300.00 AS Decimal(18, 2)), CAST(19300.00 AS Decimal(18, 2)), N'admin', CAST(N'2021-03-18 00:00:00.000' AS DateTime), 1, 1, 0, CAST(N'2021-03-18 21:26:37.183' AS DateTime), N'admin', CAST(N'2021-03-18 21:26:12.243' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[PerchaseInStoreInfos] OFF
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1, N'中国', 0, NULL, N'zg', 0)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2, N'北京', 1, N'中国', N'bj', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3, N'安徽', 1, N'中国', N'ah', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (4, N'福建', 1, N'中国', N'fj', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (5, N'甘肃', 1, N'中国', N'gs', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (6, N'广东', 1, N'中国', N'gd', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (7, N'广西', 1, N'中国', N'gx', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (8, N'贵州', 1, N'中国', N'gz', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (9, N'海南', 1, N'中国', N'hn', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (10, N'河北', 1, N'中国', N'hb', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (11, N'河南', 1, N'中国', N'hn', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (12, N'黑龙江', 1, N'中国', N'hlj', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (13, N'湖北', 1, N'中国', N'hb', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (14, N'湖南', 1, N'中国', N'hn', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (15, N'吉林', 1, N'中国', N'jl', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (16, N'江苏', 1, N'中国', N'js', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (17, N'江西', 1, N'中国', N'jx', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (18, N'辽宁', 1, N'中国', N'ln', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (19, N'内蒙古', 1, N'中国', N'nmg', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (20, N'宁夏', 1, N'中国', N'nx', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (21, N'青海', 1, N'中国', N'qh', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (22, N'山东', 1, N'中国', N'sd', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (23, N'山西', 1, N'中国', N'sx', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (24, N'陕西', 1, N'中国', N'sx', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (25, N'上海', 1, N'中国', N'sh', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (26, N'四川', 1, N'中国', N'sc', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (27, N'天津', 1, N'中国', N'tj', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (28, N'西藏', 1, N'中国', N'xc', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (29, N'新疆', 1, N'中国', N'xj', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (30, N'云南', 1, N'中国', N'yn', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (31, N'浙江', 1, N'中国', N'zj', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (32, N'重庆', 1, N'中国', N'zq', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (33, N'香港', 1, N'中国', N'xg', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (34, N'澳门', 1, N'中国', N'am', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (35, N'台湾', 1, N'中国', N'tw', 1)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (36, N'安庆', 3, N'安徽', N'aq', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (37, N'蚌埠', 3, N'安徽', N'bb', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (38, N'巢湖', 3, N'安徽', N'ch', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (39, N'池州', 3, N'安徽', N'cz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (40, N'滁州', 3, N'安徽', N'cz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (41, N'阜阳', 3, N'安徽', N'fy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (42, N'淮北', 3, N'安徽', N'hb', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (43, N'淮南', 3, N'安徽', N'hn', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (44, N'黄山', 3, N'安徽', N'hs', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (45, N'六安', 3, N'安徽', N'la', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (46, N'马鞍山', 3, N'安徽', N'mas', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (47, N'宿州', 3, N'安徽', N'xz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (48, N'铜陵', 3, N'安徽', N'tl', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (49, N'芜湖', 3, N'安徽', N'wh', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (50, N'宣城', 3, N'安徽', N'xc', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (51, N'亳州', 3, N'安徽', N'bz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (52, N'北京', 2, N'北京', N'bj', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (53, N'福州', 4, N'福建', N'fz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (54, N'龙岩', 4, N'福建', N'ly', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (55, N'南平', 4, N'福建', N'np', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (56, N'宁德', 4, N'福建', N'nd', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (57, N'莆田', 4, N'福建', N'pt', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (58, N'泉州', 4, N'福建', N'qz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (59, N'三明', 4, N'福建', N'sm', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (60, N'厦门', 4, N'福建', N'sm', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (61, N'漳州', 4, N'福建', N'zz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (62, N'兰州', 5, N'甘肃', N'lz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (63, N'白银', 5, N'甘肃', N'by', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (64, N'定西', 5, N'甘肃', N'dx', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (65, N'甘南', 5, N'甘肃', N'gn', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (66, N'嘉峪关', 5, N'甘肃', N'jyg', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (67, N'金昌', 5, N'甘肃', N'jc', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (68, N'酒泉', 5, N'甘肃', N'jq', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (69, N'临夏', 5, N'甘肃', N'lx', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (70, N'陇南', 5, N'甘肃', N'ln', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (71, N'平凉', 5, N'甘肃', N'pl', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (72, N'庆阳', 5, N'甘肃', N'qy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (73, N'天水', 5, N'甘肃', N'ts', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (74, N'武威', 5, N'甘肃', N'ww', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (75, N'张掖', 5, N'甘肃', N'zy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (76, N'广州', 6, N'广东', N'gz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (77, N'深圳', 6, N'广东', N'sz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (78, N'潮州', 6, N'广东', N'cz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (79, N'东莞', 6, N'广东', N'dg', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (80, N'佛山', 6, N'广东', N's', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (81, N'河源', 6, N'广东', N'hy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (82, N'惠州', 6, N'广东', N'hz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (83, N'江门', 6, N'广东', N'jm', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (84, N'揭阳', 6, N'广东', N'jy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (85, N'茂名', 6, N'广东', N'mm', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (86, N'梅州', 6, N'广东', N'mz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (87, N'清远', 6, N'广东', N'qy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (88, N'汕头', 6, N'广东', N'st', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (89, N'汕尾', 6, N'广东', N'sw', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (90, N'韶关', 6, N'广东', N'sg', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (91, N'阳江', 6, N'广东', N'yj', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (92, N'云浮', 6, N'广东', N'yf', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (93, N'湛江', 6, N'广东', N'zj', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (94, N'肇庆', 6, N'广东', N'zq', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (95, N'中山', 6, N'广东', N'zs', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (96, N'珠海', 6, N'广东', N'zh', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (97, N'南宁', 7, N'广西', N'nn', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (98, N'桂林', 7, N'广西', N'gl', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (99, N'百色', 7, N'广西', N'bs', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (100, N'北海', 7, N'广西', N'bh', 2)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (101, N'崇左', 7, N'广西', N'cz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (102, N'防城港', 7, N'广西', N'fcg', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (103, N'贵港', 7, N'广西', N'gg', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (104, N'河池', 7, N'广西', N'hc', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (105, N'贺州', 7, N'广西', N'hz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (106, N'来宾', 7, N'广西', N'lb', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (107, N'柳州', 7, N'广西', N'lz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (108, N'钦州', 7, N'广西', N'qz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (109, N'梧州', 7, N'广西', N'wz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (110, N'玉林', 7, N'广西', N'yl', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (111, N'贵阳', 8, N'贵州', N'gy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (112, N'安顺', 8, N'贵州', N'as', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (113, N'毕节', 8, N'贵州', N'bj', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (114, N'六盘水', 8, N'贵州', N'lps', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (115, N'黔东南', 8, N'贵州', N'qdn', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (116, N'黔南', 8, N'贵州', N'qn', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (117, N'黔西南', 8, N'贵州', N'qxn', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (118, N'铜仁', 8, N'贵州', N'tr', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (119, N'遵义', 8, N'贵州', N'zy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (120, N'海口', 9, N'海南', N'hk', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (121, N'三亚', 9, N'海南', N'sy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (122, N'白沙', 9, N'海南', N'bs', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (123, N'保亭', 9, N'海南', N'bt', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (124, N'昌江', 9, N'海南', N'cj', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (125, N'澄迈县', 9, N'海南', N'cmx', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (126, N'定安县', 9, N'海南', N'dax', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (127, N'东方', 9, N'海南', N'df', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (128, N'乐东', 9, N'海南', N'ld', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (129, N'临高县', 9, N'海南', N'lgx', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (130, N'陵水', 9, N'海南', N'ls', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (131, N'琼海', 9, N'海南', N'qh', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (132, N'琼中', 9, N'海南', N'qz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (133, N'屯昌县', 9, N'海南', N'tcx', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (134, N'万宁', 9, N'海南', N'wn', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (135, N'文昌', 9, N'海南', N'wc', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (136, N'五指山', 9, N'海南', N'wzs', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (137, N'儋州', 9, N'海南', N'dz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (138, N'石家庄', 10, N'河北', N'sjz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (139, N'保定', 10, N'河北', N'bd', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (140, N'沧州', 10, N'河北', N'cz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (141, N'承德', 10, N'河北', N'cd', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (142, N'邯郸', 10, N'河北', N'hd', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (143, N'衡水', 10, N'河北', N'hs', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (144, N'廊坊', 10, N'河北', N'lf', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (145, N'秦皇岛', 10, N'河北', N'qhd', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (146, N'唐山', 10, N'河北', N'ts', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (147, N'邢台', 10, N'河北', N'xt', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (148, N'张家口', 10, N'河北', N'zjk', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (149, N'郑州', 11, N'河南', N'zz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (150, N'洛阳', 11, N'河南', N'ly', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (151, N'开封', 11, N'河南', N'kf', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (152, N'安阳', 11, N'河南', N'ay', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (153, N'鹤壁', 11, N'河南', N'hb', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (154, N'济源', 11, N'河南', N'jy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (155, N'焦作', 11, N'河南', N'jz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (156, N'南阳', 11, N'河南', N'ny', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (157, N'平顶山', 11, N'河南', N'pds', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (158, N'三门峡', 11, N'河南', N'smx', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (159, N'商丘', 11, N'河南', N'sq', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (160, N'新乡', 11, N'河南', N'xx', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (161, N'信阳', 11, N'河南', N'xy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (162, N'许昌', 11, N'河南', N'xc', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (163, N'周口', 11, N'河南', N'zk', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (164, N'驻马店', 11, N'河南', N'zmd', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (165, N'漯河', 11, N'河南', N'lh', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (166, N'濮阳', 11, N'河南', N'py', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (167, N'哈尔滨', 12, N'黑龙江', N'heb', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (168, N'大庆', 12, N'黑龙江', N'dq', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (169, N'大兴安岭', 12, N'黑龙江', N'dxal', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (170, N'鹤岗', 12, N'黑龙江', N'hg', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (171, N'黑河', 12, N'黑龙江', N'hh', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (172, N'鸡西', 12, N'黑龙江', N'jx', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (173, N'佳木斯', 12, N'黑龙江', N'jms', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (174, N'牡丹江', 12, N'黑龙江', N'mdj', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (175, N'七台河', 12, N'黑龙江', N'qth', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (176, N'齐齐哈尔', 12, N'黑龙江', N'qqhe', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (177, N'双鸭山', 12, N'黑龙江', N'sys', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (178, N'绥化', 12, N'黑龙江', N'sh', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (179, N'伊春', 12, N'黑龙江', N'yc', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (180, N'武汉', 13, N'湖北', N'wh', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (181, N'仙桃', 13, N'湖北', N'xt', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (182, N'鄂州', 13, N'湖北', N'ez', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (183, N'黄冈', 13, N'湖北', N'hg', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (184, N'黄石', 13, N'湖北', N'hs', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (185, N'荆门', 13, N'湖北', N'jm', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (186, N'荆州', 13, N'湖北', N'jz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (187, N'潜江', 13, N'湖北', N'qj', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (188, N'神农架林区', 13, N'湖北', N'snjlq', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (189, N'十堰', 13, N'湖北', N'sy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (190, N'随州', 13, N'湖北', N'sz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (191, N'天门', 13, N'湖北', N'tm', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (192, N'咸宁', 13, N'湖北', N'xn', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (193, N'襄樊', 13, N'湖北', N'xf', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (194, N'孝感', 13, N'湖北', N'xg', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (195, N'宜昌', 13, N'湖北', N'yc', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (196, N'恩施', 13, N'湖北', N'es', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (197, N'长沙', 14, N'湖南', N'cs', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (198, N'张家界', 14, N'湖南', N'zjj', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (199, N'常德', 14, N'湖南', N'cd', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (200, N'郴州', 14, N'湖南', N'cz', 2)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (201, N'衡阳', 14, N'湖南', N'hy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (202, N'怀化', 14, N'湖南', N'hh', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (203, N'娄底', 14, N'湖南', N'ld', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (204, N'邵阳', 14, N'湖南', N'sy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (205, N'湘潭', 14, N'湖南', N'xt', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (206, N'湘西', 14, N'湖南', N'xx', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (207, N'益阳', 14, N'湖南', N'yy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (208, N'永州', 14, N'湖南', N'yz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (209, N'岳阳', 14, N'湖南', N'yy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (210, N'株洲', 14, N'湖南', N'zz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (211, N'长春', 15, N'吉林', N'cc', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (212, N'吉林', 15, N'吉林', N'jl', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (213, N'白城', 15, N'吉林', N'bc', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (214, N'白山', 15, N'吉林', N'bs', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (215, N'辽源', 15, N'吉林', N'ly', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (216, N'四平', 15, N'吉林', N'sp', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (217, N'松原', 15, N'吉林', N'sy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (218, N'通化', 15, N'吉林', N'th', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (219, N'延边', 15, N'吉林', N'yb', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (220, N'南京', 16, N'江苏', N'nj', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (221, N'苏州', 16, N'江苏', N'sz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (222, N'无锡', 16, N'江苏', N'wx', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (223, N'常州', 16, N'江苏', N'cz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (224, N'淮安', 16, N'江苏', N'ha', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (225, N'连云港', 16, N'江苏', N'lyg', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (226, N'南通', 16, N'江苏', N'nt', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (227, N'宿迁', 16, N'江苏', N'xq', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (228, N'泰州', 16, N'江苏', N'tz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (229, N'徐州', 16, N'江苏', N'xz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (230, N'盐城', 16, N'江苏', N'yc', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (231, N'扬州', 16, N'江苏', N'yz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (232, N'镇江', 16, N'江苏', N'zj', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (233, N'南昌', 17, N'江西', N'nc', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (234, N'抚州', 17, N'江西', N'fz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (235, N'赣州', 17, N'江西', N'gz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (236, N'吉安', 17, N'江西', N'ja', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (237, N'景德镇', 17, N'江西', N'jdz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (238, N'九江', 17, N'江西', N'jj', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (239, N'萍乡', 17, N'江西', N'px', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (240, N'上饶', 17, N'江西', N'sr', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (241, N'新余', 17, N'江西', N'xy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (242, N'宜春', 17, N'江西', N'yc', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (243, N'鹰潭', 17, N'江西', N'yt', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (244, N'沈阳', 18, N'辽宁', N'sy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (245, N'大连', 18, N'辽宁', N'dl', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (246, N'鞍山', 18, N'辽宁', N'as', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (247, N'本溪', 18, N'辽宁', N'bx', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (248, N'朝阳', 18, N'辽宁', N'cy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (249, N'丹东', 18, N'辽宁', N'dd', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (250, N'抚顺', 18, N'辽宁', N'fs', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (251, N'阜新', 18, N'辽宁', N'fx', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (252, N'葫芦岛', 18, N'辽宁', N'hld', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (253, N'锦州', 18, N'辽宁', N'jz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (254, N'辽阳', 18, N'辽宁', N'ly', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (255, N'盘锦', 18, N'辽宁', N'pj', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (256, N'铁岭', 18, N'辽宁', N'tl', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (257, N'营口', 18, N'辽宁', N'yk', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (258, N'呼和浩特', 19, N'内蒙古', N'hhht', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (259, N'阿拉善盟', 19, N'内蒙古', N'alsm', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (260, N'巴彦淖尔盟', 19, N'内蒙古', N'bynem', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (261, N'包头', 19, N'内蒙古', N'bt', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (262, N'赤峰', 19, N'内蒙古', N'cf', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (263, N'鄂尔多斯', 19, N'内蒙古', N'eeds', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (264, N'呼伦贝尔', 19, N'内蒙古', N'hlbe', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (265, N'通辽', 19, N'内蒙古', N'tl', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (266, N'乌海', 19, N'内蒙古', N'wh', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (267, N'乌兰察布市', 19, N'内蒙古', N'wlcbs', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (268, N'锡林郭勒盟', 19, N'内蒙古', N'xlglm', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (269, N'兴安盟', 19, N'内蒙古', N'xam', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (270, N'银川', 20, N'宁夏', N'yc', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (271, N'固原', 20, N'宁夏', N'gy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (272, N'石嘴山', 20, N'宁夏', N'szs', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (273, N'吴忠', 20, N'宁夏', N'wz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (274, N'中卫', 20, N'宁夏', N'zw', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (275, N'西宁', 21, N'青海', N'xn', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (276, N'果洛', 21, N'青海', N'gl', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (277, N'海北', 21, N'青海', N'hb', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (278, N'海东', 21, N'青海', N'hd', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (279, N'海南', 21, N'青海', N'hn', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (280, N'海西', 21, N'青海', N'hx', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (281, N'黄南', 21, N'青海', N'hn', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (282, N'玉树', 21, N'青海', N'ys', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (283, N'济南', 22, N'山东', N'jn', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (284, N'青岛', 22, N'山东', N'qd', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (285, N'滨州', 22, N'山东', N'bz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (286, N'德州', 22, N'山东', N'dz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (287, N'东营', 22, N'山东', N'dy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (288, N'菏泽', 22, N'山东', N'hz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (289, N'济宁', 22, N'山东', N'jn', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (290, N'莱芜', 22, N'山东', N'lw', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (291, N'聊城', 22, N'山东', N'lc', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (292, N'临沂', 22, N'山东', N'ly', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (293, N'日照', 22, N'山东', N'rz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (294, N'泰安', 22, N'山东', N'ta', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (295, N'威海', 22, N'山东', N'wh', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (296, N'潍坊', 22, N'山东', N'wf', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (297, N'烟台', 22, N'山东', N'yt', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (298, N'枣庄', 22, N'山东', N'zz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (299, N'淄博', 22, N'山东', N'zb', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (300, N'太原', 23, N'山西', N'ty', 2)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (301, N'长治', 23, N'山西', N'cz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (302, N'大同', 23, N'山西', N'dt', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (303, N'晋城', 23, N'山西', N'jc', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (304, N'晋中', 23, N'山西', N'jz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (305, N'临汾', 23, N'山西', N'lf', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (306, N'吕梁', 23, N'山西', N'll', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (307, N'朔州', 23, N'山西', N'sz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (308, N'忻州', 23, N'山西', N'xz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (309, N'阳泉', 23, N'山西', N'yq', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (310, N'运城', 23, N'山西', N'yc', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (311, N'西安', 24, N'陕西', N'xa', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (312, N'安康', 24, N'陕西', N'ak', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (313, N'宝鸡', 24, N'陕西', N'bj', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (314, N'汉中', 24, N'陕西', N'hz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (315, N'商洛', 24, N'陕西', N'sl', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (316, N'铜川', 24, N'陕西', N'tc', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (317, N'渭南', 24, N'陕西', N'wn', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (318, N'咸阳', 24, N'陕西', N'xy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (319, N'延安', 24, N'陕西', N'ya', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (320, N'榆林', 24, N'陕西', N'yl', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (321, N'上海', 25, N'上海', N'sh', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (322, N'成都', 26, N'四川', N'cd', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (323, N'绵阳', 26, N'四川', N'my', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (324, N'阿坝', 26, N'四川', N'ab', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (325, N'巴中', 26, N'四川', N'bz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (326, N'达州', 26, N'四川', N'dz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (327, N'德阳', 26, N'四川', N'dy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (328, N'甘孜', 26, N'四川', N'gz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (329, N'广安', 26, N'四川', N'ga', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (330, N'广元', 26, N'四川', N'gy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (331, N'乐山', 26, N'四川', N'ls', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (332, N'凉山', 26, N'四川', N'ls', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (333, N'眉山', 26, N'四川', N'ms', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (334, N'南充', 26, N'四川', N'nc', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (335, N'内江', 26, N'四川', N'nj', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (336, N'攀枝花', 26, N'四川', N'pzh', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (337, N'遂宁', 26, N'四川', N'sn', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (338, N'雅安', 26, N'四川', N'ya', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (339, N'宜宾', 26, N'四川', N'yb', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (340, N'资阳', 26, N'四川', N'zy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (341, N'自贡', 26, N'四川', N'zg', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (342, N'泸州', 26, N'四川', N'lz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (343, N'天津', 27, N'天津', N'tj', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (344, N'拉萨', 28, N'西藏', N'ls', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (345, N'阿里', 28, N'西藏', N'al', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (346, N'昌都', 28, N'西藏', N'cd', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (347, N'林芝', 28, N'西藏', N'lz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (348, N'那曲', 28, N'西藏', N'nq', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (349, N'日喀则', 28, N'西藏', N'rkz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (350, N'山南', 28, N'西藏', N'sn', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (351, N'乌鲁木齐', 29, N'新疆', N'wlmq', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (352, N'阿克苏', 29, N'新疆', N'aks', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (353, N'阿拉尔', 29, N'新疆', N'ale', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (354, N'巴音郭楞', 29, N'新疆', N'bygl', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (355, N'博尔塔拉', 29, N'新疆', N'betl', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (356, N'昌吉', 29, N'新疆', N'cj', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (357, N'哈密', 29, N'新疆', N'hm', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (358, N'和田', 29, N'新疆', N'ht', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (359, N'喀什', 29, N'新疆', N'ks', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (360, N'克拉玛依', 29, N'新疆', N'klmy', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (361, N'克孜勒苏', 29, N'新疆', N'kzls', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (362, N'石河子', 29, N'新疆', N'shz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (363, N'图木舒克', 29, N'新疆', N'tmsk', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (364, N'吐鲁番', 29, N'新疆', N'tlf', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (365, N'五家渠', 29, N'新疆', N'wjq', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (366, N'伊犁', 29, N'新疆', N'yl', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (367, N'昆明', 30, N'云南', N'km', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (368, N'怒江', 30, N'云南', N'nj', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (369, N'普洱', 30, N'云南', N'pe', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (370, N'丽江', 30, N'云南', N'lj', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (371, N'保山', 30, N'云南', N'bs', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (372, N'楚雄', 30, N'云南', N'cx', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (373, N'大理', 30, N'云南', N'dl', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (374, N'德宏', 30, N'云南', N'dh', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (375, N'迪庆', 30, N'云南', N'dq', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (376, N'红河', 30, N'云南', N'hh', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (377, N'临沧', 30, N'云南', N'lc', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (378, N'曲靖', 30, N'云南', N'qj', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (379, N'文山', 30, N'云南', N'ws', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (380, N'西双版纳', 30, N'云南', N'xsbn', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (381, N'玉溪', 30, N'云南', N'yx', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (382, N'昭通', 30, N'云南', N'zt', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (383, N'杭州', 31, N'浙江', N'hz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (384, N'湖州', 31, N'浙江', N'hz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (385, N'嘉兴', 31, N'浙江', N'jx', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (386, N'金华', 31, N'浙江', N'jh', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (387, N'丽水', 31, N'浙江', N'ls', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (388, N'宁波', 31, N'浙江', N'nb', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (389, N'绍兴', 31, N'浙江', N'sx', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (390, N'台州', 31, N'浙江', N'tz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (391, N'温州', 31, N'浙江', N'wz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (392, N'舟山', 31, N'浙江', N'zs', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (393, N'衢州', 31, N'浙江', N'qz', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (394, N'重庆', 32, N'重庆', N'zq', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (395, N'香港', 33, N'香港', N'xg', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (396, N'澳门', 34, N'澳门', N'am', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (397, N'台湾', 35, N'台湾', N'tw', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (398, N'迎江区', 36, N'安庆', N'yjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (399, N'大观区', 36, N'安庆', N'dgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (400, N'宜秀区', 36, N'安庆', N'yxq', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (401, N'桐城市', 36, N'安庆', N'tcs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (402, N'怀宁县', 36, N'安庆', N'hnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (403, N'枞阳县', 36, N'安庆', N'cyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (404, N'潜山县', 36, N'安庆', N'qsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (405, N'太湖县', 36, N'安庆', N'thx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (406, N'宿松县', 36, N'安庆', N'xsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (407, N'望江县', 36, N'安庆', N'wjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (408, N'岳西县', 36, N'安庆', N'yxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (409, N'中市区', 37, N'蚌埠', N'zsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (410, N'东市区', 37, N'蚌埠', N'dsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (411, N'西市区', 37, N'蚌埠', N'xsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (412, N'郊区', 37, N'蚌埠', N'jq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (413, N'怀远县', 37, N'蚌埠', N'hyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (414, N'五河县', 37, N'蚌埠', N'whx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (415, N'固镇县', 37, N'蚌埠', N'gzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (416, N'居巢区', 38, N'巢湖', N'jcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (417, N'庐江县', 38, N'巢湖', N'ljx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (418, N'无为县', 38, N'巢湖', N'wwx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (419, N'含山县', 38, N'巢湖', N'hsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (420, N'和县', 38, N'巢湖', N'hx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (421, N'贵池区', 39, N'池州', N'gcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (422, N'东至县', 39, N'池州', N'dzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (423, N'石台县', 39, N'池州', N'stx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (424, N'青阳县', 39, N'池州', N'qyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (425, N'琅琊区', 40, N'滁州', N'lyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (426, N'南谯区', 40, N'滁州', N'nqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (427, N'天长市', 40, N'滁州', N'tcs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (428, N'明光市', 40, N'滁州', N'mgs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (429, N'来安县', 40, N'滁州', N'lax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (430, N'全椒县', 40, N'滁州', N'qjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (431, N'定远县', 40, N'滁州', N'dyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (432, N'凤阳县', 40, N'滁州', N'fyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (433, N'蚌山区', 41, N'阜阳', N'bsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (434, N'龙子湖区', 41, N'阜阳', N'lzhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (435, N'禹会区', 41, N'阜阳', N'yhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (436, N'淮上区', 41, N'阜阳', N'hsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (437, N'颍州区', 41, N'阜阳', N'yzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (438, N'颍东区', 41, N'阜阳', N'ydq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (439, N'颍泉区', 41, N'阜阳', N'yqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (440, N'界首市', 41, N'阜阳', N'jss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (441, N'临泉县', 41, N'阜阳', N'lqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (442, N'太和县', 41, N'阜阳', N'thx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (443, N'阜南县', 41, N'阜阳', N'fnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (444, N'颖上县', 41, N'阜阳', N'ysx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (445, N'相山区', 42, N'淮北', N'xsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (446, N'杜集区', 42, N'淮北', N'djq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (447, N'烈山区', 42, N'淮北', N'lsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (448, N'濉溪县', 42, N'淮北', N'sxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (449, N'田家庵区', 43, N'淮南', N'tjaq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (450, N'大通区', 43, N'淮南', N'dtq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (451, N'谢家集区', 43, N'淮南', N'xjjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (452, N'八公山区', 43, N'淮南', N'bgsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (453, N'潘集区', 43, N'淮南', N'pjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (454, N'凤台县', 43, N'淮南', N'ftx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (455, N'屯溪区', 44, N'黄山', N'txq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (456, N'黄山区', 44, N'黄山', N'hsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (457, N'徽州区', 44, N'黄山', N'hzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (458, N'歙县', 44, N'黄山', N'xx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (459, N'休宁县', 44, N'黄山', N'xnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (460, N'黟县', 44, N'黄山', N'yx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (461, N'祁门县', 44, N'黄山', N'qmx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (462, N'金安区', 45, N'六安', N'jaq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (463, N'裕安区', 45, N'六安', N'yaq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (464, N'寿县', 45, N'六安', N'sx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (465, N'霍邱县', 45, N'六安', N'hqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (466, N'舒城县', 45, N'六安', N'scx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (467, N'金寨县', 45, N'六安', N'jzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (468, N'霍山县', 45, N'六安', N'hsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (469, N'雨山区', 46, N'马鞍山', N'ysq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (470, N'花山区', 46, N'马鞍山', N'hsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (471, N'金家庄区', 46, N'马鞍山', N'jjzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (472, N'当涂县', 46, N'马鞍山', N'dtx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (473, N'埇桥区', 47, N'宿州', N'yqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (474, N'砀山县', 47, N'宿州', N'dsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (475, N'萧县', 47, N'宿州', N'xx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (476, N'灵璧县', 47, N'宿州', N'lbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (477, N'泗县', 47, N'宿州', N'sx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (478, N'铜官山区', 48, N'铜陵', N'tgsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (479, N'狮子山区', 48, N'铜陵', N'szsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (480, N'郊区', 48, N'铜陵', N'jq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (481, N'铜陵县', 48, N'铜陵', N'tlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (482, N'镜湖区', 49, N'芜湖', N'jhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (483, N'弋江区', 49, N'芜湖', N'yjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (484, N'鸠江区', 49, N'芜湖', N'jjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (485, N'三山区', 49, N'芜湖', N'ssq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (486, N'芜湖县', 49, N'芜湖', N'whx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (487, N'繁昌县', 49, N'芜湖', N'fcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (488, N'南陵县', 49, N'芜湖', N'nlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (489, N'宣州区', 50, N'宣城', N'xzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (490, N'宁国市', 50, N'宣城', N'ngs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (491, N'郎溪县', 50, N'宣城', N'lxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (492, N'广德县', 50, N'宣城', N'gdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (493, N'泾县', 50, N'宣城', N'jx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (494, N'绩溪县', 50, N'宣城', N'jxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (495, N'旌德县', 50, N'宣城', N'jdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (496, N'涡阳县', 51, N'亳州', N'wyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (497, N'蒙城县', 51, N'亳州', N'mcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (498, N'利辛县', 51, N'亳州', N'lxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (499, N'谯城区', 51, N'亳州', N'qcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (500, N'东城区', 52, N'北京', N'dcq', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (501, N'西城区', 52, N'北京', N'xcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (502, N'海淀区', 52, N'北京', N'hdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (503, N'朝阳区', 52, N'北京', N'cyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (504, N'崇文区', 52, N'北京', N'cwq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (505, N'宣武区', 52, N'北京', N'xwq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (506, N'丰台区', 52, N'北京', N'ftq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (507, N'石景山区', 52, N'北京', N'sjsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (508, N'房山区', 52, N'北京', N'fsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (509, N'门头沟区', 52, N'北京', N'mtgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (510, N'通州区', 52, N'北京', N'tzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (511, N'顺义区', 52, N'北京', N'syq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (512, N'昌平区', 52, N'北京', N'cpq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (513, N'怀柔区', 52, N'北京', N'hrq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (514, N'平谷区', 52, N'北京', N'pgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (515, N'大兴区', 52, N'北京', N'dxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (516, N'密云县', 52, N'北京', N'myx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (517, N'延庆县', 52, N'北京', N'yqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (518, N'鼓楼区', 53, N'福州', N'glq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (519, N'台江区', 53, N'福州', N'tjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (520, N'仓山区', 53, N'福州', N'csq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (521, N'马尾区', 53, N'福州', N'mwq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (522, N'晋安区', 53, N'福州', N'jaq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (523, N'福清市', 53, N'福州', N'fqs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (524, N'长乐市', 53, N'福州', N'cls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (525, N'闽侯县', 53, N'福州', N'mhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (526, N'连江县', 53, N'福州', N'ljx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (527, N'罗源县', 53, N'福州', N'lyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (528, N'闽清县', 53, N'福州', N'mqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (529, N'永泰县', 53, N'福州', N'ytx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (530, N'平潭县', 53, N'福州', N'ptx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (531, N'新罗区', 54, N'龙岩', N'xlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (532, N'漳平市', 54, N'龙岩', N'zps', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (533, N'长汀县', 54, N'龙岩', N'ctx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (534, N'永定县', 54, N'龙岩', N'ydx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (535, N'上杭县', 54, N'龙岩', N'shx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (536, N'武平县', 54, N'龙岩', N'wpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (537, N'连城县', 54, N'龙岩', N'lcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (538, N'延平区', 55, N'南平', N'ypq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (539, N'邵武市', 55, N'南平', N'sws', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (540, N'武夷山市', 55, N'南平', N'wyss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (541, N'建瓯市', 55, N'南平', N'jos', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (542, N'建阳市', 55, N'南平', N'jys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (543, N'顺昌县', 55, N'南平', N'scx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (544, N'浦城县', 55, N'南平', N'pcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (545, N'光泽县', 55, N'南平', N'gzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (546, N'松溪县', 55, N'南平', N'sxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (547, N'政和县', 55, N'南平', N'zhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (548, N'蕉城区', 56, N'宁德', N'jcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (549, N'福安市', 56, N'宁德', N'fas', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (550, N'福鼎市', 56, N'宁德', N'fds', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (551, N'霞浦县', 56, N'宁德', N'xpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (552, N'古田县', 56, N'宁德', N'gtx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (553, N'屏南县', 56, N'宁德', N'pnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (554, N'寿宁县', 56, N'宁德', N'snx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (555, N'周宁县', 56, N'宁德', N'znx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (556, N'柘荣县', 56, N'宁德', N'zrx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (557, N'城厢区', 57, N'莆田', N'cxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (558, N'涵江区', 57, N'莆田', N'hjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (559, N'荔城区', 57, N'莆田', N'lcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (560, N'秀屿区', 57, N'莆田', N'xyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (561, N'仙游县', 57, N'莆田', N'xyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (562, N'鲤城区', 58, N'泉州', N'lcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (563, N'丰泽区', 58, N'泉州', N'fzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (564, N'洛江区', 58, N'泉州', N'ljq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (565, N'清濛开发区', 58, N'泉州', N'qmkfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (566, N'泉港区', 58, N'泉州', N'qgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (567, N'石狮市', 58, N'泉州', N'sss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (568, N'晋江市', 58, N'泉州', N'jjs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (569, N'南安市', 58, N'泉州', N'nas', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (570, N'惠安县', 58, N'泉州', N'hax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (571, N'安溪县', 58, N'泉州', N'axx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (572, N'永春县', 58, N'泉州', N'ycx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (573, N'德化县', 58, N'泉州', N'dhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (574, N'金门县', 58, N'泉州', N'jmx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (575, N'梅列区', 59, N'三明', N'mlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (576, N'三元区', 59, N'三明', N'syq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (577, N'永安市', 59, N'三明', N'yas', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (578, N'明溪县', 59, N'三明', N'mxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (579, N'清流县', 59, N'三明', N'qlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (580, N'宁化县', 59, N'三明', N'nhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (581, N'大田县', 59, N'三明', N'dtx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (582, N'尤溪县', 59, N'三明', N'yxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (583, N'沙县', 59, N'三明', N'sx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (584, N'将乐县', 59, N'三明', N'jlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (585, N'泰宁县', 59, N'三明', N'tnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (586, N'建宁县', 59, N'三明', N'jnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (587, N'思明区', 60, N'厦门', N'smq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (588, N'海沧区', 60, N'厦门', N'hcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (589, N'湖里区', 60, N'厦门', N'hlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (590, N'集美区', 60, N'厦门', N'jmq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (591, N'同安区', 60, N'厦门', N'taq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (592, N'翔安区', 60, N'厦门', N'xaq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (593, N'芗城区', 61, N'漳州', N'xcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (594, N'龙文区', 61, N'漳州', N'lwq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (595, N'龙海市', 61, N'漳州', N'lhs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (596, N'云霄县', 61, N'漳州', N'yxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (597, N'漳浦县', 61, N'漳州', N'zpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (598, N'诏安县', 61, N'漳州', N'zax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (599, N'长泰县', 61, N'漳州', N'ctx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (600, N'东山县', 61, N'漳州', N'dsx', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (601, N'南靖县', 61, N'漳州', N'njx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (602, N'平和县', 61, N'漳州', N'phx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (603, N'华安县', 61, N'漳州', N'hax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (604, N'皋兰县', 62, N'兰州', N'glx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (605, N'城关区', 62, N'兰州', N'cgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (606, N'七里河区', 62, N'兰州', N'qlhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (607, N'西固区', 62, N'兰州', N'xgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (608, N'安宁区', 62, N'兰州', N'anq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (609, N'红古区', 62, N'兰州', N'hgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (610, N'永登县', 62, N'兰州', N'ydx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (611, N'榆中县', 62, N'兰州', N'yzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (612, N'白银区', 63, N'白银', N'byq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (613, N'平川区', 63, N'白银', N'pcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (614, N'会宁县', 63, N'白银', N'hnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (615, N'景泰县', 63, N'白银', N'jtx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (616, N'靖远县', 63, N'白银', N'jyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (617, N'临洮县', 64, N'定西', N'ltx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (618, N'陇西县', 64, N'定西', N'lxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (619, N'通渭县', 64, N'定西', N'twx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (620, N'渭源县', 64, N'定西', N'wyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (621, N'漳县', 64, N'定西', N'zx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (622, N'岷县', 64, N'定西', N'mx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (623, N'安定区', 64, N'定西', N'adq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (624, N'安定区', 64, N'定西', N'adq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (625, N'合作市', 65, N'甘南', N'hzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (626, N'临潭县', 65, N'甘南', N'ltx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (627, N'卓尼县', 65, N'甘南', N'znx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (628, N'舟曲县', 65, N'甘南', N'zqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (629, N'迭部县', 65, N'甘南', N'dbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (630, N'玛曲县', 65, N'甘南', N'mqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (631, N'碌曲县', 65, N'甘南', N'lqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (632, N'夏河县', 65, N'甘南', N'xhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (633, N'嘉峪关市', 66, N'嘉峪关', N'jygs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (634, N'金川区', 67, N'金昌', N'jcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (635, N'永昌县', 67, N'金昌', N'ycx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (636, N'肃州区', 68, N'酒泉', N'szq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (637, N'玉门市', 68, N'酒泉', N'yms', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (638, N'敦煌市', 68, N'酒泉', N'dhs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (639, N'金塔县', 68, N'酒泉', N'jtx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (640, N'瓜州县', 68, N'酒泉', N'gzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (641, N'肃北', 68, N'酒泉', N'sb', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (642, N'阿克塞', 68, N'酒泉', N'aks', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (643, N'临夏市', 69, N'临夏', N'lxs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (644, N'临夏县', 69, N'临夏', N'lxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (645, N'康乐县', 69, N'临夏', N'klx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (646, N'永靖县', 69, N'临夏', N'yjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (647, N'广河县', 69, N'临夏', N'ghx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (648, N'和政县', 69, N'临夏', N'hzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (649, N'东乡族自治县', 69, N'临夏', N'dxzzzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (650, N'积石山', 69, N'临夏', N'jss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (651, N'成县', 70, N'陇南', N'cx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (652, N'徽县', 70, N'陇南', N'hx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (653, N'康县', 70, N'陇南', N'kx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (654, N'礼县', 70, N'陇南', N'lx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (655, N'两当县', 70, N'陇南', N'ldx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (656, N'文县', 70, N'陇南', N'wx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (657, N'西和县', 70, N'陇南', N'xhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (658, N'宕昌县', 70, N'陇南', N'dcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (659, N'武都区', 70, N'陇南', N'wdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (660, N'崇信县', 71, N'平凉', N'cxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (661, N'华亭县', 71, N'平凉', N'htx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (662, N'静宁县', 71, N'平凉', N'jnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (663, N'灵台县', 71, N'平凉', N'ltx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (664, N'崆峒区', 71, N'平凉', N'kdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (665, N'庄浪县', 71, N'平凉', N'zlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (666, N'泾川县', 71, N'平凉', N'jcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (667, N'合水县', 72, N'庆阳', N'hsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (668, N'华池县', 72, N'庆阳', N'hcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (669, N'环县', 72, N'庆阳', N'hx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (670, N'宁县', 72, N'庆阳', N'nx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (671, N'庆城县', 72, N'庆阳', N'qcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (672, N'西峰区', 72, N'庆阳', N'xfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (673, N'镇原县', 72, N'庆阳', N'zyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (674, N'正宁县', 72, N'庆阳', N'znx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (675, N'甘谷县', 73, N'天水', N'ggx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (676, N'秦安县', 73, N'天水', N'qax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (677, N'清水县', 73, N'天水', N'qsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (678, N'秦州区', 73, N'天水', N'qzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (679, N'麦积区', 73, N'天水', N'mjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (680, N'武山县', 73, N'天水', N'wsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (681, N'张家川', 73, N'天水', N'zjc', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (682, N'古浪县', 74, N'武威', N'glx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (683, N'民勤县', 74, N'武威', N'mqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (684, N'天祝', 74, N'武威', N'tz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (685, N'凉州区', 74, N'武威', N'lzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (686, N'高台县', 75, N'张掖', N'gtx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (687, N'临泽县', 75, N'张掖', N'lzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (688, N'民乐县', 75, N'张掖', N'mlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (689, N'山丹县', 75, N'张掖', N'sdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (690, N'肃南', 75, N'张掖', N'sn', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (691, N'甘州区', 75, N'张掖', N'gzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (692, N'从化市', 76, N'广州', N'chs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (693, N'天河区', 76, N'广州', N'thq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (694, N'东山区', 76, N'广州', N'dsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (695, N'白云区', 76, N'广州', N'byq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (696, N'海珠区', 76, N'广州', N'hzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (697, N'荔湾区', 76, N'广州', N'lwq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (698, N'越秀区', 76, N'广州', N'yxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (699, N'黄埔区', 76, N'广州', N'hpq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (700, N'番禺区', 76, N'广州', N'fyq', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (701, N'花都区', 76, N'广州', N'hdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (702, N'增城区', 76, N'广州', N'zcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (703, N'从化区', 76, N'广州', N'chq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (704, N'市郊', 76, N'广州', N'sj', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (705, N'福田区', 77, N'深圳', N'ftq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (706, N'罗湖区', 77, N'深圳', N'lhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (707, N'南山区', 77, N'深圳', N'nsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (708, N'宝安区', 77, N'深圳', N'baq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (709, N'龙岗区', 77, N'深圳', N'lgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (710, N'盐田区', 77, N'深圳', N'ytq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (711, N'湘桥区', 78, N'潮州', N'xqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (712, N'潮安县', 78, N'潮州', N'cax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (713, N'饶平县', 78, N'潮州', N'rpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (714, N'南城区', 79, N'东莞', N'ncq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (715, N'东城区', 79, N'东莞', N'dcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (716, N'万江区', 79, N'东莞', N'wjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (717, N'莞城区', 79, N'东莞', N'gcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (718, N'石龙镇', 79, N'东莞', N'slz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (719, N'虎门镇', 79, N'东莞', N'hmz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (720, N'麻涌镇', 79, N'东莞', N'myz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (721, N'道滘镇', 79, N'东莞', N'djz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (722, N'石碣镇', 79, N'东莞', N'sjz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (723, N'沙田镇', 79, N'东莞', N'stz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (724, N'望牛墩镇', 79, N'东莞', N'wndz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (725, N'洪梅镇', 79, N'东莞', N'hmz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (726, N'茶山镇', 79, N'东莞', N'csz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (727, N'寮步镇', 79, N'东莞', N'lbz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (728, N'大岭山镇', 79, N'东莞', N'dlsz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (729, N'大朗镇', 79, N'东莞', N'dlz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (730, N'黄江镇', 79, N'东莞', N'hjz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (731, N'樟木头', 79, N'东莞', N'zmt', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (732, N'凤岗镇', 79, N'东莞', N'fgz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (733, N'塘厦镇', 79, N'东莞', N'tsz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (734, N'谢岗镇', 79, N'东莞', N'xgz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (735, N'厚街镇', 79, N'东莞', N'hjz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (736, N'清溪镇', 79, N'东莞', N'qxz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (737, N'常平镇', 79, N'东莞', N'cpz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (738, N'桥头镇', 79, N'东莞', N'qtz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (739, N'横沥镇', 79, N'东莞', N'hlz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (740, N'东坑镇', 79, N'东莞', N'dkz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (741, N'企石镇', 79, N'东莞', N'qsz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (742, N'石排镇', 79, N'东莞', N'spz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (743, N'长安镇', 79, N'东莞', N'caz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (744, N'中堂镇', 79, N'东莞', N'ztz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (745, N'高埗镇', 79, N'东莞', N'gbz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (746, N'禅城区', 80, N'佛山', N'ccq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (747, N'南海区', 80, N'佛山', N'nhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (748, N'顺德区', 80, N'佛山', N'sdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (749, N'三水区', 80, N'佛山', N'ssq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (750, N'高明区', 80, N'佛山', N'gmq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (751, N'东源县', 81, N'河源', N'dyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (752, N'和平县', 81, N'河源', N'hpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (753, N'源城区', 81, N'河源', N'ycq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (754, N'连平县', 81, N'河源', N'lpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (755, N'龙川县', 81, N'河源', N'lcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (756, N'紫金县', 81, N'河源', N'zjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (757, N'惠阳区', 82, N'惠州', N'hyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (758, N'惠城区', 82, N'惠州', N'hcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (759, N'大亚湾', 82, N'惠州', N'dyw', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (760, N'博罗县', 82, N'惠州', N'blx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (761, N'惠东县', 82, N'惠州', N'hdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (762, N'龙门县', 82, N'惠州', N'lmx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (763, N'江海区', 83, N'江门', N'jhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (764, N'蓬江区', 83, N'江门', N'pjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (765, N'新会区', 83, N'江门', N'xhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (766, N'台山市', 83, N'江门', N'tss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (767, N'开平市', 83, N'江门', N'kps', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (768, N'鹤山市', 83, N'江门', N'hss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (769, N'恩平市', 83, N'江门', N'eps', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (770, N'榕城区', 84, N'揭阳', N'rcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (771, N'普宁市', 84, N'揭阳', N'pns', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (772, N'揭东县', 84, N'揭阳', N'jdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (773, N'揭西县', 84, N'揭阳', N'jxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (774, N'惠来县', 84, N'揭阳', N'hlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (775, N'茂南区', 85, N'茂名', N'mnq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (776, N'茂港区', 85, N'茂名', N'mgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (777, N'高州市', 85, N'茂名', N'gzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (778, N'化州市', 85, N'茂名', N'hzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (779, N'信宜市', 85, N'茂名', N'xys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (780, N'电白县', 85, N'茂名', N'dbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (781, N'梅县', 86, N'梅州', N'mx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (782, N'梅江区', 86, N'梅州', N'mjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (783, N'兴宁市', 86, N'梅州', N'xns', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (784, N'大埔县', 86, N'梅州', N'dpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (785, N'丰顺县', 86, N'梅州', N'fsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (786, N'五华县', 86, N'梅州', N'whx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (787, N'平远县', 86, N'梅州', N'pyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (788, N'蕉岭县', 86, N'梅州', N'jlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (789, N'清城区', 87, N'清远', N'qcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (790, N'英德市', 87, N'清远', N'yds', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (791, N'连州市', 87, N'清远', N'lzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (792, N'佛冈县', 87, N'清远', N'gx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (793, N'阳山县', 87, N'清远', N'ysx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (794, N'清新县', 87, N'清远', N'qxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (795, N'连山', 87, N'清远', N'ls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (796, N'连南', 87, N'清远', N'ln', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (797, N'南澳县', 88, N'汕头', N'nax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (798, N'潮阳区', 88, N'汕头', N'cyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (799, N'澄海区', 88, N'汕头', N'chq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (800, N'龙湖区', 88, N'汕头', N'lhq', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (801, N'金平区', 88, N'汕头', N'jpq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (802, N'濠江区', 88, N'汕头', N'hjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (803, N'潮南区', 88, N'汕头', N'cnq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (804, N'城区', 89, N'汕尾', N'cq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (805, N'陆丰市', 89, N'汕尾', N'lfs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (806, N'海丰县', 89, N'汕尾', N'hfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (807, N'陆河县', 89, N'汕尾', N'lhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (808, N'曲江县', 90, N'韶关', N'qjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (809, N'浈江区', 90, N'韶关', N'zjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (810, N'武江区', 90, N'韶关', N'wjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (811, N'曲江区', 90, N'韶关', N'qjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (812, N'乐昌市', 90, N'韶关', N'lcs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (813, N'南雄市', 90, N'韶关', N'nxs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (814, N'始兴县', 90, N'韶关', N'sxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (815, N'仁化县', 90, N'韶关', N'rhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (816, N'翁源县', 90, N'韶关', N'wyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (817, N'新丰县', 90, N'韶关', N'xfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (818, N'乳源', 90, N'韶关', N'ry', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (819, N'江城区', 91, N'阳江', N'jcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (820, N'阳春市', 91, N'阳江', N'ycs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (821, N'阳西县', 91, N'阳江', N'yxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (822, N'阳东县', 91, N'阳江', N'ydx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (823, N'云城区', 92, N'云浮', N'ycq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (824, N'罗定市', 92, N'云浮', N'lds', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (825, N'新兴县', 92, N'云浮', N'xxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (826, N'郁南县', 92, N'云浮', N'ynx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (827, N'云安县', 92, N'云浮', N'yax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (828, N'赤坎区', 93, N'湛江', N'ckq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (829, N'霞山区', 93, N'湛江', N'xsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (830, N'坡头区', 93, N'湛江', N'ptq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (831, N'麻章区', 93, N'湛江', N'mzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (832, N'廉江市', 93, N'湛江', N'ljs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (833, N'雷州市', 93, N'湛江', N'lzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (834, N'吴川市', 93, N'湛江', N'wcs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (835, N'遂溪县', 93, N'湛江', N'sxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (836, N'徐闻县', 93, N'湛江', N'xwx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (837, N'肇庆市', 94, N'肇庆', N'zqs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (838, N'高要市', 94, N'肇庆', N'gys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (839, N'四会市', 94, N'肇庆', N'shs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (840, N'广宁县', 94, N'肇庆', N'gnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (841, N'怀集县', 94, N'肇庆', N'hjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (842, N'封开县', 94, N'肇庆', N'fkx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (843, N'德庆县', 94, N'肇庆', N'dqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (844, N'石岐街道', 95, N'中山', N'sqjd', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (845, N'东区街道', 95, N'中山', N'dqjd', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (846, N'西区街道', 95, N'中山', N'xqjd', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (847, N'环城街道', 95, N'中山', N'hcjd', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (848, N'中山港街道', 95, N'中山', N'zsgjd', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (849, N'五桂山街道', 95, N'中山', N'wgsjd', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (850, N'香洲区', 96, N'珠海', N'xzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (851, N'斗门区', 96, N'珠海', N'dmq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (852, N'金湾区', 96, N'珠海', N'jwq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (853, N'邕宁区', 97, N'南宁', N'ynq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (854, N'青秀区', 97, N'南宁', N'qxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (855, N'兴宁区', 97, N'南宁', N'xnq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (856, N'良庆区', 97, N'南宁', N'lqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (857, N'西乡塘区', 97, N'南宁', N'xxtq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (858, N'江南区', 97, N'南宁', N'jnq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (859, N'武鸣县', 97, N'南宁', N'wmx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (860, N'隆安县', 97, N'南宁', N'lax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (861, N'马山县', 97, N'南宁', N'msx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (862, N'上林县', 97, N'南宁', N'slx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (863, N'宾阳县', 97, N'南宁', N'byx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (864, N'横县', 97, N'南宁', N'hx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (865, N'秀峰区', 98, N'桂林', N'xfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (866, N'叠彩区', 98, N'桂林', N'dcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (867, N'象山区', 98, N'桂林', N'xsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (868, N'七星区', 98, N'桂林', N'qxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (869, N'雁山区', 98, N'桂林', N'ysq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (870, N'阳朔县', 98, N'桂林', N'ysx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (871, N'临桂县', 98, N'桂林', N'lgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (872, N'灵川县', 98, N'桂林', N'lcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (873, N'全州县', 98, N'桂林', N'qzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (874, N'平乐县', 98, N'桂林', N'plx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (875, N'兴安县', 98, N'桂林', N'xax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (876, N'灌阳县', 98, N'桂林', N'gyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (877, N'荔浦县', 98, N'桂林', N'lpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (878, N'资源县', 98, N'桂林', N'zyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (879, N'永福县', 98, N'桂林', N'yfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (880, N'龙胜', 98, N'桂林', N'ls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (881, N'恭城', 98, N'桂林', N'gc', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (882, N'右江区', 99, N'百色', N'yjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (883, N'凌云县', 99, N'百色', N'lyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (884, N'平果县', 99, N'百色', N'pgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (885, N'西林县', 99, N'百色', N'xlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (886, N'乐业县', 99, N'百色', N'lyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (887, N'德保县', 99, N'百色', N'dbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (888, N'田林县', 99, N'百色', N'tlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (889, N'田阳县', 99, N'百色', N'tyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (890, N'靖西县', 99, N'百色', N'jxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (891, N'田东县', 99, N'百色', N'tdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (892, N'那坡县', 99, N'百色', N'npx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (893, N'隆林', 99, N'百色', N'll', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (894, N'海城区', 100, N'北海', N'hcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (895, N'银海区', 100, N'北海', N'yhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (896, N'铁山港区', 100, N'北海', N'tsgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (897, N'合浦县', 100, N'北海', N'hpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (898, N'江州区', 101, N'崇左', N'jzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (899, N'凭祥市', 101, N'崇左', N'pxs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (900, N'宁明县', 101, N'崇左', N'nmx', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (901, N'扶绥县', 101, N'崇左', N'fsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (902, N'龙州县', 101, N'崇左', N'lzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (903, N'大新县', 101, N'崇左', N'dxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (904, N'天等县', 101, N'崇左', N'tdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (905, N'港口区', 102, N'防城港', N'gkq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (906, N'防城区', 102, N'防城港', N'fcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (907, N'东兴市', 102, N'防城港', N'dxs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (908, N'上思县', 102, N'防城港', N'ssx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (909, N'港北区', 103, N'贵港', N'gbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (910, N'港南区', 103, N'贵港', N'gnq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (911, N'覃塘区', 103, N'贵港', N'ttq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (912, N'桂平市', 103, N'贵港', N'gps', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (913, N'平南县', 103, N'贵港', N'pnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (914, N'金城江区', 104, N'河池', N'jcjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (915, N'宜州市', 104, N'河池', N'yzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (916, N'天峨县', 104, N'河池', N'tex', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (917, N'凤山县', 104, N'河池', N'fsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (918, N'南丹县', 104, N'河池', N'ndx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (919, N'东兰县', 104, N'河池', N'dlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (920, N'都安', 104, N'河池', N'da', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (921, N'罗城', 104, N'河池', N'lc', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (922, N'巴马', 104, N'河池', N'bm', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (923, N'环江', 104, N'河池', N'hj', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (924, N'大化', 104, N'河池', N'dh', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (925, N'八步区', 105, N'贺州', N'bbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (926, N'钟山县', 105, N'贺州', N'zsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (927, N'昭平县', 105, N'贺州', N'zpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (928, N'富川', 105, N'贺州', N'fc', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (929, N'兴宾区', 106, N'来宾', N'xbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (930, N'合山市', 106, N'来宾', N'hss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (931, N'象州县', 106, N'来宾', N'xzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (932, N'武宣县', 106, N'来宾', N'wxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (933, N'忻城县', 106, N'来宾', N'xcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (934, N'金秀', 106, N'来宾', N'jx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (935, N'城中区', 107, N'柳州', N'czq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (936, N'鱼峰区', 107, N'柳州', N'yfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (937, N'柳北区', 107, N'柳州', N'lbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (938, N'柳南区', 107, N'柳州', N'lnq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (939, N'柳江县', 107, N'柳州', N'ljx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (940, N'柳城县', 107, N'柳州', N'lcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (941, N'鹿寨县', 107, N'柳州', N'lzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (942, N'融安县', 107, N'柳州', N'rax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (943, N'融水', 107, N'柳州', N'rs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (944, N'三江', 107, N'柳州', N'sj', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (945, N'钦南区', 108, N'钦州', N'qnq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (946, N'钦北区', 108, N'钦州', N'qbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (947, N'灵山县', 108, N'钦州', N'lsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (948, N'浦北县', 108, N'钦州', N'pbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (949, N'万秀区', 109, N'梧州', N'wxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (950, N'蝶山区', 109, N'梧州', N'dsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (951, N'长洲区', 109, N'梧州', N'czq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (952, N'岑溪市', 109, N'梧州', N'cxs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (953, N'苍梧县', 109, N'梧州', N'cwx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (954, N'藤县', 109, N'梧州', N'tx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (955, N'蒙山县', 109, N'梧州', N'msx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (956, N'玉州区', 110, N'玉林', N'yzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (957, N'北流市', 110, N'玉林', N'bls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (958, N'容县', 110, N'玉林', N'rx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (959, N'陆川县', 110, N'玉林', N'lcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (960, N'博白县', 110, N'玉林', N'bbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (961, N'兴业县', 110, N'玉林', N'xyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (962, N'南明区', 111, N'贵阳', N'nmq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (963, N'云岩区', 111, N'贵阳', N'yyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (964, N'花溪区', 111, N'贵阳', N'hxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (965, N'乌当区', 111, N'贵阳', N'wdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (966, N'白云区', 111, N'贵阳', N'byq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (967, N'小河区', 111, N'贵阳', N'xhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (968, N'金阳新区', 111, N'贵阳', N'jyxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (969, N'新天园区', 111, N'贵阳', N'xtyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (970, N'清镇市', 111, N'贵阳', N'qzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (971, N'开阳县', 111, N'贵阳', N'kyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (972, N'修文县', 111, N'贵阳', N'xwx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (973, N'息烽县', 111, N'贵阳', N'xfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (974, N'西秀区', 112, N'安顺', N'xxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (975, N'关岭', 112, N'安顺', N'gl', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (976, N'镇宁', 112, N'安顺', N'zn', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (977, N'紫云', 112, N'安顺', N'zy', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (978, N'平坝县', 112, N'安顺', N'pbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (979, N'普定县', 112, N'安顺', N'pdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (980, N'毕节市', 113, N'毕节', N'bjs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (981, N'大方县', 113, N'毕节', N'dfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (982, N'黔西县', 113, N'毕节', N'qxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (983, N'金沙县', 113, N'毕节', N'jsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (984, N'织金县', 113, N'毕节', N'zjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (985, N'纳雍县', 113, N'毕节', N'nyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (986, N'赫章县', 113, N'毕节', N'hzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (987, N'威宁', 113, N'毕节', N'wn', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (988, N'钟山区', 114, N'六盘水', N'zsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (989, N'六枝特区', 114, N'六盘水', N'lztq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (990, N'水城县', 114, N'六盘水', N'scx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (991, N'盘县', 114, N'六盘水', N'px', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (992, N'凯里市', 115, N'黔东南', N'kls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (993, N'黄平县', 115, N'黔东南', N'hpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (994, N'施秉县', 115, N'黔东南', N'sbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (995, N'三穗县', 115, N'黔东南', N'ssx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (996, N'镇远县', 115, N'黔东南', N'zyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (997, N'岑巩县', 115, N'黔东南', N'cgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (998, N'天柱县', 115, N'黔东南', N'tzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (999, N'锦屏县', 115, N'黔东南', N'jpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1000, N'剑河县', 115, N'黔东南', N'jhx', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1001, N'台江县', 115, N'黔东南', N'tjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1002, N'黎平县', 115, N'黔东南', N'lpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1003, N'榕江县', 115, N'黔东南', N'rjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1004, N'从江县', 115, N'黔东南', N'cjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1005, N'雷山县', 115, N'黔东南', N'lsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1006, N'麻江县', 115, N'黔东南', N'mjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1007, N'丹寨县', 115, N'黔东南', N'dzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1008, N'都匀市', 116, N'黔南', N'dys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1009, N'福泉市', 116, N'黔南', N'fqs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1010, N'荔波县', 116, N'黔南', N'lbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1011, N'贵定县', 116, N'黔南', N'gdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1012, N'瓮安县', 116, N'黔南', N'wax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1013, N'独山县', 116, N'黔南', N'dsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1014, N'平塘县', 116, N'黔南', N'ptx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1015, N'罗甸县', 116, N'黔南', N'ldx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1016, N'长顺县', 116, N'黔南', N'csx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1017, N'龙里县', 116, N'黔南', N'llx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1018, N'惠水县', 116, N'黔南', N'hsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1019, N'三都', 116, N'黔南', N'sd', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1020, N'兴义市', 117, N'黔西南', N'xys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1021, N'兴仁县', 117, N'黔西南', N'xrx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1022, N'普安县', 117, N'黔西南', N'pax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1023, N'晴隆县', 117, N'黔西南', N'qlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1024, N'贞丰县', 117, N'黔西南', N'zfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1025, N'望谟县', 117, N'黔西南', N'wmx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1026, N'册亨县', 117, N'黔西南', N'chx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1027, N'安龙县', 117, N'黔西南', N'alx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1028, N'铜仁市', 118, N'铜仁', N'trs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1029, N'江口县', 118, N'铜仁', N'jkx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1030, N'石阡县', 118, N'铜仁', N'sqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1031, N'思南县', 118, N'铜仁', N'snx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1032, N'德江县', 118, N'铜仁', N'djx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1033, N'玉屏', 118, N'铜仁', N'yp', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1034, N'印江', 118, N'铜仁', N'yj', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1035, N'沿河', 118, N'铜仁', N'yh', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1036, N'松桃', 118, N'铜仁', N'st', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1037, N'万山特区', 118, N'铜仁', N'wstq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1038, N'红花岗区', 119, N'遵义', N'hhgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1039, N'务川县', 119, N'遵义', N'wcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1040, N'道真县', 119, N'遵义', N'dzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1041, N'汇川区', 119, N'遵义', N'hcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1042, N'赤水市', 119, N'遵义', N'css', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1043, N'仁怀市', 119, N'遵义', N'rhs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1044, N'遵义县', 119, N'遵义', N'zyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1045, N'桐梓县', 119, N'遵义', N'tzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1046, N'绥阳县', 119, N'遵义', N'syx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1047, N'正安县', 119, N'遵义', N'zax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1048, N'凤冈县', 119, N'遵义', N'fgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1049, N'湄潭县', 119, N'遵义', N'mtx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1050, N'余庆县', 119, N'遵义', N'yqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1051, N'习水县', 119, N'遵义', N'xsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1052, N'道真', 119, N'遵义', N'dz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1053, N'务川', 119, N'遵义', N'wc', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1054, N'秀英区', 120, N'海口', N'xyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1055, N'龙华区', 120, N'海口', N'lhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1056, N'琼山区', 120, N'海口', N'qsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1057, N'美兰区', 120, N'海口', N'mlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1058, N'市区', 137, N'儋州', N'sq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1059, N'洋浦开发区', 137, N'儋州', N'ypkfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1060, N'那大镇', 137, N'儋州', N'ndz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1061, N'王五镇', 137, N'儋州', N'wwz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1062, N'雅星镇', 137, N'儋州', N'yxz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1063, N'大成镇', 137, N'儋州', N'dcz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1064, N'中和镇', 137, N'儋州', N'zhz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1065, N'峨蔓镇', 137, N'儋州', N'emz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1066, N'南丰镇', 137, N'儋州', N'nfz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1067, N'白马井镇', 137, N'儋州', N'bmjz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1068, N'兰洋镇', 137, N'儋州', N'lyz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1069, N'和庆镇', 137, N'儋州', N'hqz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1070, N'海头镇', 137, N'儋州', N'htz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1071, N'排浦镇', 137, N'儋州', N'ppz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1072, N'东成镇', 137, N'儋州', N'dcz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1073, N'光村镇', 137, N'儋州', N'gcz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1074, N'木棠镇', 137, N'儋州', N'mtz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1075, N'新州镇', 137, N'儋州', N'xzz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1076, N'三都镇', 137, N'儋州', N'sdz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1077, N'其他', 137, N'儋州', N'qt', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1078, N'长安区', 138, N'石家庄', N'caq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1079, N'桥东区', 138, N'石家庄', N'qdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1080, N'桥西区', 138, N'石家庄', N'qxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1081, N'新华区', 138, N'石家庄', N'xhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1082, N'裕华区', 138, N'石家庄', N'yhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1083, N'井陉矿区', 138, N'石家庄', N'jxkq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1084, N'高新区', 138, N'石家庄', N'gxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1085, N'辛集市', 138, N'石家庄', N'xjs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1086, N'藁城市', 138, N'石家庄', N'gcs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1087, N'晋州市', 138, N'石家庄', N'jzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1088, N'新乐市', 138, N'石家庄', N'xls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1089, N'鹿泉市', 138, N'石家庄', N'lqs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1090, N'井陉县', 138, N'石家庄', N'jxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1091, N'正定县', 138, N'石家庄', N'zdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1092, N'栾城县', 138, N'石家庄', N'lcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1093, N'行唐县', 138, N'石家庄', N'htx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1094, N'灵寿县', 138, N'石家庄', N'lsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1095, N'高邑县', 138, N'石家庄', N'gyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1096, N'深泽县', 138, N'石家庄', N'szx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1097, N'赞皇县', 138, N'石家庄', N'zhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1098, N'无极县', 138, N'石家庄', N'wjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1099, N'平山县', 138, N'石家庄', N'psx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1100, N'元氏县', 138, N'石家庄', N'ysx', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1101, N'赵县', 138, N'石家庄', N'zx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1102, N'新市区', 139, N'保定', N'xsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1103, N'南市区', 139, N'保定', N'nsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1104, N'北市区', 139, N'保定', N'bsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1105, N'涿州市', 139, N'保定', N'zzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1106, N'定州市', 139, N'保定', N'dzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1107, N'安国市', 139, N'保定', N'ags', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1108, N'高碑店市', 139, N'保定', N'gbds', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1109, N'满城县', 139, N'保定', N'mcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1110, N'清苑县', 139, N'保定', N'qyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1111, N'涞水县', 139, N'保定', N'lsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1112, N'阜平县', 139, N'保定', N'fpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1113, N'徐水县', 139, N'保定', N'xsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1114, N'定兴县', 139, N'保定', N'dxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1115, N'唐县', 139, N'保定', N'tx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1116, N'高阳县', 139, N'保定', N'gyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1117, N'容城县', 139, N'保定', N'rcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1118, N'涞源县', 139, N'保定', N'lyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1119, N'望都县', 139, N'保定', N'wdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1120, N'安新县', 139, N'保定', N'axx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1121, N'易县', 139, N'保定', N'yx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1122, N'曲阳县', 139, N'保定', N'qyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1123, N'蠡县', 139, N'保定', N'lx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1124, N'顺平县', 139, N'保定', N'spx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1125, N'博野县', 139, N'保定', N'byx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1126, N'雄县', 139, N'保定', N'xx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1127, N'运河区', 140, N'沧州', N'yhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1128, N'新华区', 140, N'沧州', N'xhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1129, N'泊头市', 140, N'沧州', N'bts', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1130, N'任丘市', 140, N'沧州', N'rqs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1131, N'黄骅市', 140, N'沧州', N'hhs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1132, N'河间市', 140, N'沧州', N'hjs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1133, N'沧县', 140, N'沧州', N'cx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1134, N'青县', 140, N'沧州', N'qx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1135, N'东光县', 140, N'沧州', N'dgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1136, N'海兴县', 140, N'沧州', N'hxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1137, N'盐山县', 140, N'沧州', N'ysx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1138, N'肃宁县', 140, N'沧州', N'snx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1139, N'南皮县', 140, N'沧州', N'npx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1140, N'吴桥县', 140, N'沧州', N'wqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1141, N'献县', 140, N'沧州', N'xx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1142, N'孟村', 140, N'沧州', N'mc', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1143, N'双桥区', 141, N'承德', N'sqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1144, N'双滦区', 141, N'承德', N'slq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1145, N'鹰手营子矿区', 141, N'承德', N'ysyzkq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1146, N'承德县', 141, N'承德', N'cdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1147, N'兴隆县', 141, N'承德', N'xlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1148, N'平泉县', 141, N'承德', N'pqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1149, N'滦平县', 141, N'承德', N'lpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1150, N'隆化县', 141, N'承德', N'lhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1151, N'丰宁', 141, N'承德', N'fn', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1152, N'宽城', 141, N'承德', N'kc', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1153, N'围场', 141, N'承德', N'wc', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1154, N'从台区', 142, N'邯郸', N'ctq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1155, N'复兴区', 142, N'邯郸', N'fxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1156, N'邯山区', 142, N'邯郸', N'hsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1157, N'峰峰矿区', 142, N'邯郸', N'ffkq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1158, N'武安市', 142, N'邯郸', N'was', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1159, N'邯郸县', 142, N'邯郸', N'hdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1160, N'临漳县', 142, N'邯郸', N'lzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1161, N'成安县', 142, N'邯郸', N'cax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1162, N'大名县', 142, N'邯郸', N'dmx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1163, N'涉县', 142, N'邯郸', N'sx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1164, N'磁县', 142, N'邯郸', N'cx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1165, N'肥乡县', 142, N'邯郸', N'fxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1166, N'永年县', 142, N'邯郸', N'ynx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1167, N'邱县', 142, N'邯郸', N'qx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1168, N'鸡泽县', 142, N'邯郸', N'jzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1169, N'广平县', 142, N'邯郸', N'gpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1170, N'馆陶县', 142, N'邯郸', N'gtx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1171, N'魏县', 142, N'邯郸', N'wx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1172, N'曲周县', 142, N'邯郸', N'qzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1173, N'桃城区', 143, N'衡水', N'tcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1174, N'冀州市', 143, N'衡水', N'jzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1175, N'深州市', 143, N'衡水', N'szs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1176, N'枣强县', 143, N'衡水', N'zqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1177, N'武邑县', 143, N'衡水', N'wyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1178, N'武强县', 143, N'衡水', N'wqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1179, N'饶阳县', 143, N'衡水', N'ryx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1180, N'安平县', 143, N'衡水', N'apx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1181, N'故城县', 143, N'衡水', N'gcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1182, N'景县', 143, N'衡水', N'jx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1183, N'阜城县', 143, N'衡水', N'fcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1184, N'安次区', 144, N'廊坊', N'acq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1185, N'广阳区', 144, N'廊坊', N'gyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1186, N'霸州市', 144, N'廊坊', N'bzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1187, N'三河市', 144, N'廊坊', N'shs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1188, N'固安县', 144, N'廊坊', N'gax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1189, N'永清县', 144, N'廊坊', N'yqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1190, N'香河县', 144, N'廊坊', N'xhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1191, N'大城县', 144, N'廊坊', N'dcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1192, N'文安县', 144, N'廊坊', N'wax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1193, N'大厂', 144, N'廊坊', N'dc', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1194, N'海港区', 145, N'秦皇岛', N'hgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1195, N'山海关区', 145, N'秦皇岛', N'shgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1196, N'北戴河区', 145, N'秦皇岛', N'bdhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1197, N'昌黎县', 145, N'秦皇岛', N'clx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1198, N'抚宁县', 145, N'秦皇岛', N'fnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1199, N'卢龙县', 145, N'秦皇岛', N'llx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1200, N'青龙', 145, N'秦皇岛', N'ql', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1201, N'路北区', 146, N'唐山', N'lbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1202, N'路南区', 146, N'唐山', N'lnq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1203, N'古冶区', 146, N'唐山', N'gyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1204, N'开平区', 146, N'唐山', N'kpq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1205, N'丰南区', 146, N'唐山', N'fnq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1206, N'丰润区', 146, N'唐山', N'frq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1207, N'遵化市', 146, N'唐山', N'zhs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1208, N'迁安市', 146, N'唐山', N'qas', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1209, N'滦县', 146, N'唐山', N'lx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1210, N'滦南县', 146, N'唐山', N'lnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1211, N'乐亭县', 146, N'唐山', N'ltx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1212, N'迁西县', 146, N'唐山', N'qxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1213, N'玉田县', 146, N'唐山', N'ytx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1214, N'唐海县', 146, N'唐山', N'thx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1215, N'桥东区', 147, N'邢台', N'qdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1216, N'桥西区', 147, N'邢台', N'qxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1217, N'南宫市', 147, N'邢台', N'ngs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1218, N'沙河市', 147, N'邢台', N'shs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1219, N'邢台县', 147, N'邢台', N'xtx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1220, N'临城县', 147, N'邢台', N'lcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1221, N'内丘县', 147, N'邢台', N'nqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1222, N'柏乡县', 147, N'邢台', N'bxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1223, N'隆尧县', 147, N'邢台', N'lyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1224, N'任县', 147, N'邢台', N'rx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1225, N'南和县', 147, N'邢台', N'nhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1226, N'宁晋县', 147, N'邢台', N'njx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1227, N'巨鹿县', 147, N'邢台', N'jlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1228, N'新河县', 147, N'邢台', N'xhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1229, N'广宗县', 147, N'邢台', N'gzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1230, N'平乡县', 147, N'邢台', N'pxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1231, N'威县', 147, N'邢台', N'wx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1232, N'清河县', 147, N'邢台', N'qhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1233, N'临西县', 147, N'邢台', N'lxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1234, N'桥西区', 148, N'张家口', N'qxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1235, N'桥东区', 148, N'张家口', N'qdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1236, N'宣化区', 148, N'张家口', N'xhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1237, N'下花园区', 148, N'张家口', N'xhyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1238, N'宣化县', 148, N'张家口', N'xhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1239, N'张北县', 148, N'张家口', N'zbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1240, N'康保县', 148, N'张家口', N'kbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1241, N'沽源县', 148, N'张家口', N'gyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1242, N'尚义县', 148, N'张家口', N'syx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1243, N'蔚县', 148, N'张家口', N'wx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1244, N'阳原县', 148, N'张家口', N'yyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1245, N'怀安县', 148, N'张家口', N'hax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1246, N'万全县', 148, N'张家口', N'wqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1247, N'怀来县', 148, N'张家口', N'hlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1248, N'涿鹿县', 148, N'张家口', N'zlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1249, N'赤城县', 148, N'张家口', N'ccx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1250, N'崇礼县', 148, N'张家口', N'clx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1251, N'金水区', 149, N'郑州', N'jsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1252, N'邙山区', 149, N'郑州', N'msq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1253, N'二七区', 149, N'郑州', N'eqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1254, N'管城区', 149, N'郑州', N'gcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1255, N'中原区', 149, N'郑州', N'zyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1256, N'上街区', 149, N'郑州', N'sjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1257, N'惠济区', 149, N'郑州', N'hjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1258, N'郑东新区', 149, N'郑州', N'zdxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1259, N'经济技术开发区', 149, N'郑州', N'jjjskfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1260, N'高新开发区', 149, N'郑州', N'gxkfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1261, N'出口加工区', 149, N'郑州', N'ckjgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1262, N'巩义市', 149, N'郑州', N'gys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1263, N'荥阳市', 149, N'郑州', N'yys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1264, N'新密市', 149, N'郑州', N'xms', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1265, N'新郑市', 149, N'郑州', N'xzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1266, N'登封市', 149, N'郑州', N'dfs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1267, N'中牟县', 149, N'郑州', N'zmx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1268, N'西工区', 150, N'洛阳', N'xgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1269, N'老城区', 150, N'洛阳', N'lcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1270, N'涧西区', 150, N'洛阳', N'jxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1271, N'瀍河回族区', 150, N'洛阳', N'chhzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1272, N'洛龙区', 150, N'洛阳', N'llq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1273, N'吉利区', 150, N'洛阳', N'jlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1274, N'偃师市', 150, N'洛阳', N'yss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1275, N'孟津县', 150, N'洛阳', N'mjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1276, N'新安县', 150, N'洛阳', N'xax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1277, N'栾川县', 150, N'洛阳', N'lcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1278, N'嵩县', 150, N'洛阳', N'sx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1279, N'汝阳县', 150, N'洛阳', N'ryx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1280, N'宜阳县', 150, N'洛阳', N'yyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1281, N'洛宁县', 150, N'洛阳', N'lnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1282, N'伊川县', 150, N'洛阳', N'ycx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1283, N'鼓楼区', 151, N'开封', N'glq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1284, N'龙亭区', 151, N'开封', N'ltq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1285, N'顺河回族区', 151, N'开封', N'shhzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1286, N'金明区', 151, N'开封', N'jmq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1287, N'禹王台区', 151, N'开封', N'ywtq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1288, N'杞县', 151, N'开封', N'qx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1289, N'通许县', 151, N'开封', N'txx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1290, N'尉氏县', 151, N'开封', N'wsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1291, N'开封县', 151, N'开封', N'kfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1292, N'兰考县', 151, N'开封', N'lkx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1293, N'北关区', 152, N'安阳', N'bgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1294, N'文峰区', 152, N'安阳', N'wfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1295, N'殷都区', 152, N'安阳', N'ydq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1296, N'龙安区', 152, N'安阳', N'laq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1297, N'林州市', 152, N'安阳', N'lzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1298, N'安阳县', 152, N'安阳', N'ayx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1299, N'汤阴县', 152, N'安阳', N'tyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1300, N'滑县', 152, N'安阳', N'hx', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1301, N'内黄县', 152, N'安阳', N'nhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1302, N'淇滨区', 153, N'鹤壁', N'qbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1303, N'山城区', 153, N'鹤壁', N'scq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1304, N'鹤山区', 153, N'鹤壁', N'hsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1305, N'浚县', 153, N'鹤壁', N'jx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1306, N'淇县', 153, N'鹤壁', N'qx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1307, N'济源市', 154, N'济源', N'jys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1308, N'解放区', 155, N'焦作', N'jfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1309, N'中站区', 155, N'焦作', N'zzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1310, N'马村区', 155, N'焦作', N'mcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1311, N'山阳区', 155, N'焦作', N'syq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1312, N'沁阳市', 155, N'焦作', N'qys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1313, N'孟州市', 155, N'焦作', N'mzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1314, N'修武县', 155, N'焦作', N'xwx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1315, N'博爱县', 155, N'焦作', N'bax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1316, N'武陟县', 155, N'焦作', N'wzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1317, N'温县', 155, N'焦作', N'wx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1318, N'卧龙区', 156, N'南阳', N'wlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1319, N'宛城区', 156, N'南阳', N'wcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1320, N'邓州市', 156, N'南阳', N'dzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1321, N'南召县', 156, N'南阳', N'nzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1322, N'方城县', 156, N'南阳', N'fcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1323, N'西峡县', 156, N'南阳', N'xxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1324, N'镇平县', 156, N'南阳', N'zpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1325, N'内乡县', 156, N'南阳', N'nxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1326, N'淅川县', 156, N'南阳', N'xcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1327, N'社旗县', 156, N'南阳', N'sqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1328, N'唐河县', 156, N'南阳', N'thx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1329, N'新野县', 156, N'南阳', N'xyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1330, N'桐柏县', 156, N'南阳', N'tbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1331, N'新华区', 157, N'平顶山', N'xhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1332, N'卫东区', 157, N'平顶山', N'wdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1333, N'湛河区', 157, N'平顶山', N'zhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1334, N'石龙区', 157, N'平顶山', N'slq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1335, N'舞钢市', 157, N'平顶山', N'wgs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1336, N'汝州市', 157, N'平顶山', N'rzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1337, N'宝丰县', 157, N'平顶山', N'bfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1338, N'叶县', 157, N'平顶山', N'yx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1339, N'鲁山县', 157, N'平顶山', N'lsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1340, N'郏县', 157, N'平顶山', N'jx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1341, N'湖滨区', 158, N'三门峡', N'hbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1342, N'义马市', 158, N'三门峡', N'yms', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1343, N'灵宝市', 158, N'三门峡', N'lbs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1344, N'渑池县', 158, N'三门峡', N'mcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1345, N'陕县', 158, N'三门峡', N'sx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1346, N'卢氏县', 158, N'三门峡', N'lsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1347, N'梁园区', 159, N'商丘', N'lyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1348, N'睢阳区', 159, N'商丘', N'syq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1349, N'永城市', 159, N'商丘', N'ycs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1350, N'民权县', 159, N'商丘', N'mqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1351, N'睢县', 159, N'商丘', N'sx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1352, N'宁陵县', 159, N'商丘', N'nlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1353, N'虞城县', 159, N'商丘', N'ycx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1354, N'柘城县', 159, N'商丘', N'zcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1355, N'夏邑县', 159, N'商丘', N'xyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1356, N'卫滨区', 160, N'新乡', N'wbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1357, N'红旗区', 160, N'新乡', N'hqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1358, N'凤泉区', 160, N'新乡', N'fqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1359, N'牧野区', 160, N'新乡', N'myq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1360, N'卫辉市', 160, N'新乡', N'whs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1361, N'辉县市', 160, N'新乡', N'hxs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1362, N'新乡县', 160, N'新乡', N'xxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1363, N'获嘉县', 160, N'新乡', N'hjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1364, N'原阳县', 160, N'新乡', N'yyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1365, N'延津县', 160, N'新乡', N'yjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1366, N'封丘县', 160, N'新乡', N'fqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1367, N'长垣县', 160, N'新乡', N'cyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1368, N'浉河区', 161, N'信阳', N'shq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1369, N'平桥区', 161, N'信阳', N'pqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1370, N'罗山县', 161, N'信阳', N'lsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1371, N'光山县', 161, N'信阳', N'gsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1372, N'新县', 161, N'信阳', N'xx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1373, N'商城县', 161, N'信阳', N'scx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1374, N'固始县', 161, N'信阳', N'gsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1375, N'潢川县', 161, N'信阳', N'hcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1376, N'淮滨县', 161, N'信阳', N'hbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1377, N'息县', 161, N'信阳', N'xx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1378, N'魏都区', 162, N'许昌', N'wdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1379, N'禹州市', 162, N'许昌', N'yzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1380, N'长葛市', 162, N'许昌', N'cgs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1381, N'许昌县', 162, N'许昌', N'xcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1382, N'鄢陵县', 162, N'许昌', N'ylx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1383, N'襄城县', 162, N'许昌', N'xcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1384, N'川汇区', 163, N'周口', N'chq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1385, N'项城市', 163, N'周口', N'xcs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1386, N'扶沟县', 163, N'周口', N'fgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1387, N'西华县', 163, N'周口', N'xhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1388, N'商水县', 163, N'周口', N'ssx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1389, N'沈丘县', 163, N'周口', N'sqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1390, N'郸城县', 163, N'周口', N'dcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1391, N'淮阳县', 163, N'周口', N'hyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1392, N'太康县', 163, N'周口', N'tkx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1393, N'鹿邑县', 163, N'周口', N'lyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1394, N'驿城区', 164, N'驻马店', N'ycq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1395, N'西平县', 164, N'驻马店', N'xpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1396, N'上蔡县', 164, N'驻马店', N'scx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1397, N'平舆县', 164, N'驻马店', N'pyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1398, N'正阳县', 164, N'驻马店', N'zyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1399, N'确山县', 164, N'驻马店', N'qsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1400, N'泌阳县', 164, N'驻马店', N'myx', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1401, N'汝南县', 164, N'驻马店', N'rnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1402, N'遂平县', 164, N'驻马店', N'spx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1403, N'新蔡县', 164, N'驻马店', N'xcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1404, N'郾城区', 165, N'漯河', N'ycq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1405, N'源汇区', 165, N'漯河', N'yhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1406, N'召陵区', 165, N'漯河', N'zlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1407, N'舞阳县', 165, N'漯河', N'wyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1408, N'临颍县', 165, N'漯河', N'lyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1409, N'华龙区', 166, N'濮阳', N'hlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1410, N'清丰县', 166, N'濮阳', N'qfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1411, N'南乐县', 166, N'濮阳', N'nlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1412, N'范县', 166, N'濮阳', N'fx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1413, N'台前县', 166, N'濮阳', N'tqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1414, N'濮阳县', 166, N'濮阳', N'pyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1415, N'道里区', 167, N'哈尔滨', N'dlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1416, N'南岗区', 167, N'哈尔滨', N'ngq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1417, N'动力区', 167, N'哈尔滨', N'dlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1418, N'平房区', 167, N'哈尔滨', N'pfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1419, N'香坊区', 167, N'哈尔滨', N'xfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1420, N'太平区', 167, N'哈尔滨', N'tpq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1421, N'道外区', 167, N'哈尔滨', N'dwq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1422, N'阿城区', 167, N'哈尔滨', N'acq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1423, N'呼兰区', 167, N'哈尔滨', N'hlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1424, N'松北区', 167, N'哈尔滨', N'sbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1425, N'尚志市', 167, N'哈尔滨', N'szs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1426, N'双城市', 167, N'哈尔滨', N'scs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1427, N'五常市', 167, N'哈尔滨', N'wcs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1428, N'方正县', 167, N'哈尔滨', N'fzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1429, N'宾县', 167, N'哈尔滨', N'bx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1430, N'依兰县', 167, N'哈尔滨', N'ylx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1431, N'巴彦县', 167, N'哈尔滨', N'byx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1432, N'通河县', 167, N'哈尔滨', N'thx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1433, N'木兰县', 167, N'哈尔滨', N'mlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1434, N'延寿县', 167, N'哈尔滨', N'ysx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1435, N'萨尔图区', 168, N'大庆', N'setq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1436, N'红岗区', 168, N'大庆', N'hgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1437, N'龙凤区', 168, N'大庆', N'lfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1438, N'让胡路区', 168, N'大庆', N'rhlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1439, N'大同区', 168, N'大庆', N'dtq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1440, N'肇州县', 168, N'大庆', N'zzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1441, N'肇源县', 168, N'大庆', N'zyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1442, N'林甸县', 168, N'大庆', N'ldx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1443, N'杜尔伯特', 168, N'大庆', N'debt', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1444, N'呼玛县', 169, N'大兴安岭', N'hmx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1445, N'漠河县', 169, N'大兴安岭', N'mhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1446, N'塔河县', 169, N'大兴安岭', N'thx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1447, N'兴山区', 170, N'鹤岗', N'xsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1448, N'工农区', 170, N'鹤岗', N'gnq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1449, N'南山区', 170, N'鹤岗', N'nsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1450, N'兴安区', 170, N'鹤岗', N'xaq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1451, N'向阳区', 170, N'鹤岗', N'xyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1452, N'东山区', 170, N'鹤岗', N'dsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1453, N'萝北县', 170, N'鹤岗', N'lbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1454, N'绥滨县', 170, N'鹤岗', N'sbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1455, N'爱辉区', 171, N'黑河', N'ahq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1456, N'五大连池市', 171, N'黑河', N'wdlcs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1457, N'北安市', 171, N'黑河', N'bas', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1458, N'嫩江县', 171, N'黑河', N'njx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1459, N'逊克县', 171, N'黑河', N'xkx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1460, N'孙吴县', 171, N'黑河', N'swx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1461, N'鸡冠区', 172, N'鸡西', N'jgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1462, N'恒山区', 172, N'鸡西', N'hsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1463, N'城子河区', 172, N'鸡西', N'czhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1464, N'滴道区', 172, N'鸡西', N'ddq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1465, N'梨树区', 172, N'鸡西', N'lsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1466, N'虎林市', 172, N'鸡西', N'hls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1467, N'密山市', 172, N'鸡西', N'mss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1468, N'鸡东县', 172, N'鸡西', N'jdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1469, N'前进区', 173, N'佳木斯', N'qjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1470, N'郊区', 173, N'佳木斯', N'jq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1471, N'向阳区', 173, N'佳木斯', N'xyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1472, N'东风区', 173, N'佳木斯', N'dfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1473, N'同江市', 173, N'佳木斯', N'tjs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1474, N'富锦市', 173, N'佳木斯', N'fjs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1475, N'桦南县', 173, N'佳木斯', N'hnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1476, N'桦川县', 173, N'佳木斯', N'hcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1477, N'汤原县', 173, N'佳木斯', N'tyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1478, N'抚远县', 173, N'佳木斯', N'fyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1479, N'爱民区', 174, N'牡丹江', N'amq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1480, N'东安区', 174, N'牡丹江', N'daq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1481, N'阳明区', 174, N'牡丹江', N'ymq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1482, N'西安区', 174, N'牡丹江', N'xaq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1483, N'绥芬河市', 174, N'牡丹江', N'sfhs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1484, N'海林市', 174, N'牡丹江', N'hls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1485, N'宁安市', 174, N'牡丹江', N'nas', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1486, N'穆棱市', 174, N'牡丹江', N'mls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1487, N'东宁县', 174, N'牡丹江', N'dnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1488, N'林口县', 174, N'牡丹江', N'lkx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1489, N'桃山区', 175, N'七台河', N'tsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1490, N'新兴区', 175, N'七台河', N'xxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1491, N'茄子河区', 175, N'七台河', N'qzhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1492, N'勃利县', 175, N'七台河', N'blx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1493, N'龙沙区', 176, N'齐齐哈尔', N'lsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1494, N'昂昂溪区', 176, N'齐齐哈尔', N'aaxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1495, N'铁峰区', 176, N'齐齐哈尔', N'tfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1496, N'建华区', 176, N'齐齐哈尔', N'jhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1497, N'富拉尔基区', 176, N'齐齐哈尔', N'flejq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1498, N'碾子山区', 176, N'齐齐哈尔', N'nzsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1499, N'梅里斯达斡尔区', 176, N'齐齐哈尔', N'mlsdweq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1500, N'讷河市', 176, N'齐齐哈尔', N'nhs', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1501, N'龙江县', 176, N'齐齐哈尔', N'ljx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1502, N'依安县', 176, N'齐齐哈尔', N'yax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1503, N'泰来县', 176, N'齐齐哈尔', N'tlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1504, N'甘南县', 176, N'齐齐哈尔', N'gnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1505, N'富裕县', 176, N'齐齐哈尔', N'fyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1506, N'克山县', 176, N'齐齐哈尔', N'ksx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1507, N'克东县', 176, N'齐齐哈尔', N'kdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1508, N'拜泉县', 176, N'齐齐哈尔', N'bqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1509, N'尖山区', 177, N'双鸭山', N'jsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1510, N'岭东区', 177, N'双鸭山', N'ldq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1511, N'四方台区', 177, N'双鸭山', N'sftq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1512, N'宝山区', 177, N'双鸭山', N'bsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1513, N'集贤县', 177, N'双鸭山', N'jxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1514, N'友谊县', 177, N'双鸭山', N'yyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1515, N'宝清县', 177, N'双鸭山', N'bqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1516, N'饶河县', 177, N'双鸭山', N'rhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1517, N'北林区', 178, N'绥化', N'blq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1518, N'安达市', 178, N'绥化', N'ads', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1519, N'肇东市', 178, N'绥化', N'zds', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1520, N'海伦市', 178, N'绥化', N'hls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1521, N'望奎县', 178, N'绥化', N'wkx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1522, N'兰西县', 178, N'绥化', N'lxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1523, N'青冈县', 178, N'绥化', N'qgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1524, N'庆安县', 178, N'绥化', N'qax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1525, N'明水县', 178, N'绥化', N'msx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1526, N'绥棱县', 178, N'绥化', N'slx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1527, N'伊春区', 179, N'伊春', N'ycq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1528, N'带岭区', 179, N'伊春', N'dlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1529, N'南岔区', 179, N'伊春', N'ncq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1530, N'金山屯区', 179, N'伊春', N'jstq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1531, N'西林区', 179, N'伊春', N'xlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1532, N'美溪区', 179, N'伊春', N'mxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1533, N'乌马河区', 179, N'伊春', N'wmhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1534, N'翠峦区', 179, N'伊春', N'clq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1535, N'友好区', 179, N'伊春', N'yhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1536, N'上甘岭区', 179, N'伊春', N'sglq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1537, N'五营区', 179, N'伊春', N'wyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1538, N'红星区', 179, N'伊春', N'hxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1539, N'新青区', 179, N'伊春', N'xqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1540, N'汤旺河区', 179, N'伊春', N'twhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1541, N'乌伊岭区', 179, N'伊春', N'wylq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1542, N'铁力市', 179, N'伊春', N'tls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1543, N'嘉荫县', 179, N'伊春', N'jyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1544, N'江岸区', 180, N'武汉', N'jaq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1545, N'武昌区', 180, N'武汉', N'wcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1546, N'江汉区', 180, N'武汉', N'jhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1547, N'硚口区', 180, N'武汉', N'qkq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1548, N'汉阳区', 180, N'武汉', N'hyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1549, N'青山区', 180, N'武汉', N'qsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1550, N'洪山区', 180, N'武汉', N'hsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1551, N'东西湖区', 180, N'武汉', N'dxhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1552, N'汉南区', 180, N'武汉', N'hnq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1553, N'蔡甸区', 180, N'武汉', N'cdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1554, N'江夏区', 180, N'武汉', N'jxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1555, N'黄陂区', 180, N'武汉', N'hbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1556, N'新洲区', 180, N'武汉', N'xzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1557, N'经济开发区', 180, N'武汉', N'jjkfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1558, N'仙桃市', 181, N'仙桃', N'xts', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1559, N'鄂城区', 182, N'鄂州', N'ecq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1560, N'华容区', 182, N'鄂州', N'hrq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1561, N'梁子湖区', 182, N'鄂州', N'lzhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1562, N'黄州区', 183, N'黄冈', N'hzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1563, N'麻城市', 183, N'黄冈', N'mcs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1564, N'武穴市', 183, N'黄冈', N'wxs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1565, N'团风县', 183, N'黄冈', N'tfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1566, N'红安县', 183, N'黄冈', N'hax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1567, N'罗田县', 183, N'黄冈', N'ltx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1568, N'英山县', 183, N'黄冈', N'ysx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1569, N'浠水县', 183, N'黄冈', N'xsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1570, N'蕲春县', 183, N'黄冈', N'qcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1571, N'黄梅县', 183, N'黄冈', N'hmx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1572, N'黄石港区', 184, N'黄石', N'hsgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1573, N'西塞山区', 184, N'黄石', N'xssq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1574, N'下陆区', 184, N'黄石', N'xlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1575, N'铁山区', 184, N'黄石', N'tsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1576, N'大冶市', 184, N'黄石', N'dys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1577, N'阳新县', 184, N'黄石', N'yxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1578, N'东宝区', 185, N'荆门', N'dbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1579, N'掇刀区', 185, N'荆门', N'ddq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1580, N'钟祥市', 185, N'荆门', N'zxs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1581, N'京山县', 185, N'荆门', N'jsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1582, N'沙洋县', 185, N'荆门', N'syx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1583, N'沙市区', 186, N'荆州', N'ssq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1584, N'荆州区', 186, N'荆州', N'jzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1585, N'石首市', 186, N'荆州', N'sss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1586, N'洪湖市', 186, N'荆州', N'hhs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1587, N'松滋市', 186, N'荆州', N'szs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1588, N'公安县', 186, N'荆州', N'gax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1589, N'监利县', 186, N'荆州', N'jlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1590, N'江陵县', 186, N'荆州', N'jlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1591, N'潜江市', 187, N'潜江', N'qjs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1592, N'神农架林区', 188, N'神农架林区', N'snjlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1593, N'张湾区', 189, N'十堰', N'zwq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1594, N'茅箭区', 189, N'十堰', N'mjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1595, N'丹江口市', 189, N'十堰', N'djks', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1596, N'郧县', 189, N'十堰', N'yx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1597, N'郧西县', 189, N'十堰', N'yxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1598, N'竹山县', 189, N'十堰', N'zsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1599, N'竹溪县', 189, N'十堰', N'zxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1600, N'房县', 189, N'十堰', N'fx', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1601, N'曾都区', 190, N'随州', N'cdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1602, N'广水市', 190, N'随州', N'gss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1603, N'天门市', 191, N'天门', N'tms', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1604, N'咸安区', 192, N'咸宁', N'xaq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1605, N'赤壁市', 192, N'咸宁', N'cbs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1606, N'嘉鱼县', 192, N'咸宁', N'jyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1607, N'通城县', 192, N'咸宁', N'tcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1608, N'崇阳县', 192, N'咸宁', N'cyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1609, N'通山县', 192, N'咸宁', N'tsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1610, N'襄城区', 193, N'襄樊', N'xcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1611, N'樊城区', 193, N'襄樊', N'fcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1612, N'襄阳区', 193, N'襄樊', N'xyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1613, N'老河口市', 193, N'襄樊', N'lhks', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1614, N'枣阳市', 193, N'襄樊', N'zys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1615, N'宜城市', 193, N'襄樊', N'ycs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1616, N'南漳县', 193, N'襄樊', N'nzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1617, N'谷城县', 193, N'襄樊', N'gcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1618, N'保康县', 193, N'襄樊', N'bkx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1619, N'孝南区', 194, N'孝感', N'xnq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1620, N'应城市', 194, N'孝感', N'ycs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1621, N'安陆市', 194, N'孝感', N'als', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1622, N'汉川市', 194, N'孝感', N'hcs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1623, N'孝昌县', 194, N'孝感', N'xcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1624, N'大悟县', 194, N'孝感', N'dwx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1625, N'云梦县', 194, N'孝感', N'ymx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1626, N'长阳', 195, N'宜昌', N'cy', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1627, N'五峰', 195, N'宜昌', N'wf', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1628, N'西陵区', 195, N'宜昌', N'xlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1629, N'伍家岗区', 195, N'宜昌', N'wjgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1630, N'点军区', 195, N'宜昌', N'djq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1631, N'猇亭区', 195, N'宜昌', N'xtq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1632, N'夷陵区', 195, N'宜昌', N'ylq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1633, N'宜都市', 195, N'宜昌', N'yds', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1634, N'当阳市', 195, N'宜昌', N'dys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1635, N'枝江市', 195, N'宜昌', N'zjs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1636, N'远安县', 195, N'宜昌', N'yax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1637, N'兴山县', 195, N'宜昌', N'xsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1638, N'秭归县', 195, N'宜昌', N'zgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1639, N'恩施市', 196, N'恩施', N'ess', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1640, N'利川市', 196, N'恩施', N'lcs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1641, N'建始县', 196, N'恩施', N'jsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1642, N'巴东县', 196, N'恩施', N'bdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1643, N'宣恩县', 196, N'恩施', N'xex', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1644, N'咸丰县', 196, N'恩施', N'xfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1645, N'来凤县', 196, N'恩施', N'lfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1646, N'鹤峰县', 196, N'恩施', N'hfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1647, N'岳麓区', 197, N'长沙', N'ylq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1648, N'芙蓉区', 197, N'长沙', N'frq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1649, N'天心区', 197, N'长沙', N'txq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1650, N'开福区', 197, N'长沙', N'kfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1651, N'雨花区', 197, N'长沙', N'yhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1652, N'开发区', 197, N'长沙', N'kfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1653, N'浏阳市', 197, N'长沙', N'lys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1654, N'长沙县', 197, N'长沙', N'csx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1655, N'望城县', 197, N'长沙', N'wcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1656, N'宁乡县', 197, N'长沙', N'nxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1657, N'永定区', 198, N'张家界', N'ydq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1658, N'武陵源区', 198, N'张家界', N'wlyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1659, N'慈利县', 198, N'张家界', N'clx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1660, N'桑植县', 198, N'张家界', N'szx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1661, N'武陵区', 199, N'常德', N'wlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1662, N'鼎城区', 199, N'常德', N'dcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1663, N'津市市', 199, N'常德', N'jss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1664, N'安乡县', 199, N'常德', N'axx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1665, N'汉寿县', 199, N'常德', N'hsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1666, N'澧县', 199, N'常德', N'lx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1667, N'临澧县', 199, N'常德', N'llx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1668, N'桃源县', 199, N'常德', N'tyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1669, N'石门县', 199, N'常德', N'smx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1670, N'北湖区', 200, N'郴州', N'bhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1671, N'苏仙区', 200, N'郴州', N'sxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1672, N'资兴市', 200, N'郴州', N'zxs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1673, N'桂阳县', 200, N'郴州', N'gyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1674, N'宜章县', 200, N'郴州', N'yzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1675, N'永兴县', 200, N'郴州', N'yxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1676, N'嘉禾县', 200, N'郴州', N'jhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1677, N'临武县', 200, N'郴州', N'lwx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1678, N'汝城县', 200, N'郴州', N'rcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1679, N'桂东县', 200, N'郴州', N'gdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1680, N'安仁县', 200, N'郴州', N'arx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1681, N'雁峰区', 201, N'衡阳', N'yfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1682, N'珠晖区', 201, N'衡阳', N'zhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1683, N'石鼓区', 201, N'衡阳', N'sgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1684, N'蒸湘区', 201, N'衡阳', N'zxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1685, N'南岳区', 201, N'衡阳', N'nyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1686, N'耒阳市', 201, N'衡阳', N'lys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1687, N'常宁市', 201, N'衡阳', N'cns', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1688, N'衡阳县', 201, N'衡阳', N'hyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1689, N'衡南县', 201, N'衡阳', N'hnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1690, N'衡山县', 201, N'衡阳', N'hsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1691, N'衡东县', 201, N'衡阳', N'hdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1692, N'祁东县', 201, N'衡阳', N'qdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1693, N'鹤城区', 202, N'怀化', N'hcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1694, N'靖州', 202, N'怀化', N'jz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1695, N'麻阳', 202, N'怀化', N'my', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1696, N'通道', 202, N'怀化', N'td', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1697, N'新晃', 202, N'怀化', N'xh', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1698, N'芷江', 202, N'怀化', N'zj', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1699, N'沅陵县', 202, N'怀化', N'ylx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1700, N'辰溪县', 202, N'怀化', N'cxx', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1701, N'溆浦县', 202, N'怀化', N'xpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1702, N'中方县', 202, N'怀化', N'zfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1703, N'会同县', 202, N'怀化', N'htx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1704, N'洪江市', 202, N'怀化', N'hjs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1705, N'娄星区', 203, N'娄底', N'lxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1706, N'冷水江市', 203, N'娄底', N'lsjs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1707, N'涟源市', 203, N'娄底', N'lys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1708, N'双峰县', 203, N'娄底', N'sfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1709, N'新化县', 203, N'娄底', N'xhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1710, N'城步', 204, N'邵阳', N'cb', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1711, N'双清区', 204, N'邵阳', N'sqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1712, N'大祥区', 204, N'邵阳', N'dxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1713, N'北塔区', 204, N'邵阳', N'btq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1714, N'武冈市', 204, N'邵阳', N'wgs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1715, N'邵东县', 204, N'邵阳', N'sdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1716, N'新邵县', 204, N'邵阳', N'xsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1717, N'邵阳县', 204, N'邵阳', N'syx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1718, N'隆回县', 204, N'邵阳', N'lhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1719, N'洞口县', 204, N'邵阳', N'dkx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1720, N'绥宁县', 204, N'邵阳', N'snx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1721, N'新宁县', 204, N'邵阳', N'xnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1722, N'岳塘区', 205, N'湘潭', N'ytq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1723, N'雨湖区', 205, N'湘潭', N'yhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1724, N'湘乡市', 205, N'湘潭', N'xxs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1725, N'韶山市', 205, N'湘潭', N'sss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1726, N'湘潭县', 205, N'湘潭', N'xtx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1727, N'吉首市', 206, N'湘西', N'jss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1728, N'泸溪县', 206, N'湘西', N'lxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1729, N'凤凰县', 206, N'湘西', N'fhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1730, N'花垣县', 206, N'湘西', N'hyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1731, N'保靖县', 206, N'湘西', N'bjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1732, N'古丈县', 206, N'湘西', N'gzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1733, N'永顺县', 206, N'湘西', N'ysx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1734, N'龙山县', 206, N'湘西', N'lsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1735, N'赫山区', 207, N'益阳', N'hsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1736, N'资阳区', 207, N'益阳', N'zyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1737, N'沅江市', 207, N'益阳', N'yjs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1738, N'南县', 207, N'益阳', N'nx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1739, N'桃江县', 207, N'益阳', N'tjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1740, N'安化县', 207, N'益阳', N'ahx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1741, N'江华', 208, N'永州', N'jh', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1742, N'冷水滩区', 208, N'永州', N'lstq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1743, N'零陵区', 208, N'永州', N'llq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1744, N'祁阳县', 208, N'永州', N'qyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1745, N'东安县', 208, N'永州', N'dax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1746, N'双牌县', 208, N'永州', N'spx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1747, N'道县', 208, N'永州', N'dx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1748, N'江永县', 208, N'永州', N'jyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1749, N'宁远县', 208, N'永州', N'nyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1750, N'蓝山县', 208, N'永州', N'lsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1751, N'新田县', 208, N'永州', N'xtx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1752, N'岳阳楼区', 209, N'岳阳', N'yylq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1753, N'君山区', 209, N'岳阳', N'jsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1754, N'云溪区', 209, N'岳阳', N'yxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1755, N'汨罗市', 209, N'岳阳', N'mls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1756, N'临湘市', 209, N'岳阳', N'lxs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1757, N'岳阳县', 209, N'岳阳', N'yyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1758, N'华容县', 209, N'岳阳', N'hrx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1759, N'湘阴县', 209, N'岳阳', N'xyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1760, N'平江县', 209, N'岳阳', N'pjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1761, N'天元区', 210, N'株洲', N'tyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1762, N'荷塘区', 210, N'株洲', N'htq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1763, N'芦淞区', 210, N'株洲', N'lsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1764, N'石峰区', 210, N'株洲', N'sfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1765, N'醴陵市', 210, N'株洲', N'lls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1766, N'株洲县', 210, N'株洲', N'zzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1767, N'攸县', 210, N'株洲', N'yx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1768, N'茶陵县', 210, N'株洲', N'clx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1769, N'炎陵县', 210, N'株洲', N'ylx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1770, N'朝阳区', 211, N'长春', N'cyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1771, N'宽城区', 211, N'长春', N'kcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1772, N'二道区', 211, N'长春', N'edq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1773, N'南关区', 211, N'长春', N'ngq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1774, N'绿园区', 211, N'长春', N'lyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1775, N'双阳区', 211, N'长春', N'syq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1776, N'净月潭开发区', 211, N'长春', N'jytkfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1777, N'高新技术开发区', 211, N'长春', N'gxjskfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1778, N'经济技术开发区', 211, N'长春', N'jjjskfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1779, N'汽车产业开发区', 211, N'长春', N'qccykfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1780, N'德惠市', 211, N'长春', N'dhs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1781, N'九台市', 211, N'长春', N'jts', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1782, N'榆树市', 211, N'长春', N'yss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1783, N'农安县', 211, N'长春', N'nax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1784, N'船营区', 212, N'吉林', N'cyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1785, N'昌邑区', 212, N'吉林', N'cyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1786, N'龙潭区', 212, N'吉林', N'ltq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1787, N'丰满区', 212, N'吉林', N'fmq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1788, N'蛟河市', 212, N'吉林', N'jhs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1789, N'桦甸市', 212, N'吉林', N'hds', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1790, N'舒兰市', 212, N'吉林', N'sls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1791, N'磐石市', 212, N'吉林', N'pss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1792, N'永吉县', 212, N'吉林', N'yjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1793, N'洮北区', 213, N'白城', N'tbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1794, N'洮南市', 213, N'白城', N'tns', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1795, N'大安市', 213, N'白城', N'das', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1796, N'镇赉县', 213, N'白城', N'zlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1797, N'通榆县', 213, N'白城', N'tyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1798, N'江源区', 214, N'白山', N'jyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1799, N'八道江区', 214, N'白山', N'bdjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1800, N'长白', 214, N'白山', N'cb', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1801, N'临江市', 214, N'白山', N'ljs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1802, N'抚松县', 214, N'白山', N'fsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1803, N'靖宇县', 214, N'白山', N'jyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1804, N'龙山区', 215, N'辽源', N'lsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1805, N'西安区', 215, N'辽源', N'xaq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1806, N'东丰县', 215, N'辽源', N'dfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1807, N'东辽县', 215, N'辽源', N'dlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1808, N'铁西区', 216, N'四平', N'txq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1809, N'铁东区', 216, N'四平', N'tdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1810, N'伊通', 216, N'四平', N'yt', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1811, N'公主岭市', 216, N'四平', N'gzls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1812, N'双辽市', 216, N'四平', N'sls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1813, N'梨树县', 216, N'四平', N'lsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1814, N'前郭尔罗斯', 217, N'松原', N'qgels', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1815, N'宁江区', 217, N'松原', N'njq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1816, N'长岭县', 217, N'松原', N'clx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1817, N'乾安县', 217, N'松原', N'qax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1818, N'扶余县', 217, N'松原', N'fyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1819, N'东昌区', 218, N'通化', N'dcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1820, N'二道江区', 218, N'通化', N'edjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1821, N'梅河口市', 218, N'通化', N'mhks', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1822, N'集安市', 218, N'通化', N'jas', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1823, N'通化县', 218, N'通化', N'thx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1824, N'辉南县', 218, N'通化', N'hnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1825, N'柳河县', 218, N'通化', N'lhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1826, N'延吉市', 219, N'延边', N'yjs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1827, N'图们市', 219, N'延边', N'tms', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1828, N'敦化市', 219, N'延边', N'dhs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1829, N'珲春市', 219, N'延边', N'hcs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1830, N'龙井市', 219, N'延边', N'ljs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1831, N'和龙市', 219, N'延边', N'hls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1832, N'安图县', 219, N'延边', N'atx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1833, N'汪清县', 219, N'延边', N'wqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1834, N'玄武区', 220, N'南京', N'xwq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1835, N'鼓楼区', 220, N'南京', N'glq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1836, N'白下区', 220, N'南京', N'bxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1837, N'建邺区', 220, N'南京', N'jyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1838, N'秦淮区', 220, N'南京', N'qhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1839, N'雨花台区', 220, N'南京', N'yhtq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1840, N'下关区', 220, N'南京', N'xgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1841, N'栖霞区', 220, N'南京', N'qxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1842, N'浦口区', 220, N'南京', N'pkq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1843, N'江宁区', 220, N'南京', N'jnq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1844, N'六合区', 220, N'南京', N'lhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1845, N'溧水县', 220, N'南京', N'lsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1846, N'高淳县', 220, N'南京', N'gcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1847, N'沧浪区', 221, N'苏州', N'clq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1848, N'金阊区', 221, N'苏州', N'jcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1849, N'平江区', 221, N'苏州', N'pjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1850, N'虎丘区', 221, N'苏州', N'hqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1851, N'吴中区', 221, N'苏州', N'wzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1852, N'相城区', 221, N'苏州', N'xcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1853, N'园区', 221, N'苏州', N'yq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1854, N'新区', 221, N'苏州', N'xq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1855, N'常熟市', 221, N'苏州', N'css', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1856, N'张家港市', 221, N'苏州', N'zjgs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1857, N'玉山镇', 221, N'苏州', N'ysz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1858, N'巴城镇', 221, N'苏州', N'bcz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1859, N'周市镇', 221, N'苏州', N'zsz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1860, N'陆家镇', 221, N'苏州', N'ljz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1861, N'花桥镇', 221, N'苏州', N'hqz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1862, N'淀山湖镇', 221, N'苏州', N'dshz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1863, N'张浦镇', 221, N'苏州', N'zpz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1864, N'周庄镇', 221, N'苏州', N'zzz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1865, N'千灯镇', 221, N'苏州', N'qdz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1866, N'锦溪镇', 221, N'苏州', N'jxz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1867, N'开发区', 221, N'苏州', N'kfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1868, N'吴江市', 221, N'苏州', N'wjs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1869, N'太仓市', 221, N'苏州', N'tcs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1870, N'崇安区', 222, N'无锡', N'caq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1871, N'北塘区', 222, N'无锡', N'btq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1872, N'南长区', 222, N'无锡', N'ncq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1873, N'锡山区', 222, N'无锡', N'xsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1874, N'惠山区', 222, N'无锡', N'hsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1875, N'滨湖区', 222, N'无锡', N'bhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1876, N'新区', 222, N'无锡', N'xq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1877, N'江阴市', 222, N'无锡', N'jys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1878, N'宜兴市', 222, N'无锡', N'yxs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1879, N'天宁区', 223, N'常州', N'tnq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1880, N'钟楼区', 223, N'常州', N'zlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1881, N'戚墅堰区', 223, N'常州', N'qsyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1882, N'郊区', 223, N'常州', N'jq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1883, N'新北区', 223, N'常州', N'xbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1884, N'武进区', 223, N'常州', N'wjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1885, N'溧阳市', 223, N'常州', N'lys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1886, N'金坛市', 223, N'常州', N'jts', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1887, N'清河区', 224, N'淮安', N'qhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1888, N'清浦区', 224, N'淮安', N'qpq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1889, N'楚州区', 224, N'淮安', N'czq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1890, N'淮阴区', 224, N'淮安', N'hyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1891, N'涟水县', 224, N'淮安', N'lsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1892, N'洪泽县', 224, N'淮安', N'hzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1893, N'盱眙县', 224, N'淮安', N'xyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1894, N'金湖县', 224, N'淮安', N'jhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1895, N'新浦区', 225, N'连云港', N'xpq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1896, N'连云区', 225, N'连云港', N'lyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1897, N'海州区', 225, N'连云港', N'hzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1898, N'赣榆县', 225, N'连云港', N'gyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1899, N'东海县', 225, N'连云港', N'dhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1900, N'灌云县', 225, N'连云港', N'gyx', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1901, N'灌南县', 225, N'连云港', N'gnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1902, N'崇川区', 226, N'南通', N'ccq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1903, N'港闸区', 226, N'南通', N'gzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1904, N'经济开发区', 226, N'南通', N'jjkfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1905, N'启东市', 226, N'南通', N'qds', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1906, N'如皋市', 226, N'南通', N'rgs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1907, N'通州市', 226, N'南通', N'tzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1908, N'海门市', 226, N'南通', N'hms', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1909, N'海安县', 226, N'南通', N'hax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1910, N'如东县', 226, N'南通', N'rdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1911, N'宿城区', 227, N'宿迁', N'xcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1912, N'宿豫区', 227, N'宿迁', N'xyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1913, N'宿豫县', 227, N'宿迁', N'xyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1914, N'沭阳县', 227, N'宿迁', N'syx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1915, N'泗阳县', 227, N'宿迁', N'syx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1916, N'泗洪县', 227, N'宿迁', N'shx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1917, N'海陵区', 228, N'泰州', N'hlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1918, N'高港区', 228, N'泰州', N'ggq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1919, N'兴化市', 228, N'泰州', N'xhs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1920, N'靖江市', 228, N'泰州', N'jjs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1921, N'泰兴市', 228, N'泰州', N'txs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1922, N'姜堰市', 228, N'泰州', N'jys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1923, N'云龙区', 229, N'徐州', N'ylq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1924, N'鼓楼区', 229, N'徐州', N'glq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1925, N'九里区', 229, N'徐州', N'jlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1926, N'贾汪区', 229, N'徐州', N'jwq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1927, N'泉山区', 229, N'徐州', N'qsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1928, N'新沂市', 229, N'徐州', N'xys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1929, N'邳州市', 229, N'徐州', N'pzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1930, N'丰县', 229, N'徐州', N'fx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1931, N'沛县', 229, N'徐州', N'px', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1932, N'铜山县', 229, N'徐州', N'tsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1933, N'睢宁县', 229, N'徐州', N'snx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1934, N'城区', 230, N'盐城', N'cq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1935, N'亭湖区', 230, N'盐城', N'thq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1936, N'盐都区', 230, N'盐城', N'ydq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1937, N'盐都县', 230, N'盐城', N'ydx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1938, N'东台市', 230, N'盐城', N'dts', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1939, N'大丰市', 230, N'盐城', N'dfs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1940, N'响水县', 230, N'盐城', N'xsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1941, N'滨海县', 230, N'盐城', N'bhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1942, N'阜宁县', 230, N'盐城', N'fnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1943, N'射阳县', 230, N'盐城', N'syx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1944, N'建湖县', 230, N'盐城', N'jhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1945, N'广陵区', 231, N'扬州', N'glq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1946, N'维扬区', 231, N'扬州', N'wyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1947, N'邗江区', 231, N'扬州', N'hjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1948, N'仪征市', 231, N'扬州', N'yzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1949, N'高邮市', 231, N'扬州', N'gys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1950, N'江都市', 231, N'扬州', N'jds', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1951, N'宝应县', 231, N'扬州', N'byx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1952, N'京口区', 232, N'镇江', N'jkq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1953, N'润州区', 232, N'镇江', N'rzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1954, N'丹徒区', 232, N'镇江', N'dtq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1955, N'丹阳市', 232, N'镇江', N'dys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1956, N'扬中市', 232, N'镇江', N'yzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1957, N'句容市', 232, N'镇江', N'jrs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1958, N'东湖区', 233, N'南昌', N'dhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1959, N'西湖区', 233, N'南昌', N'xhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1960, N'青云谱区', 233, N'南昌', N'qypq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1961, N'湾里区', 233, N'南昌', N'wlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1962, N'青山湖区', 233, N'南昌', N'qshq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1963, N'红谷滩新区', 233, N'南昌', N'hgtxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1964, N'昌北区', 233, N'南昌', N'cbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1965, N'高新区', 233, N'南昌', N'gxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1966, N'南昌县', 233, N'南昌', N'ncx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1967, N'新建县', 233, N'南昌', N'xjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1968, N'安义县', 233, N'南昌', N'ayx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1969, N'进贤县', 233, N'南昌', N'jxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1970, N'临川区', 234, N'抚州', N'lcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1971, N'南城县', 234, N'抚州', N'ncx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1972, N'黎川县', 234, N'抚州', N'lcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1973, N'南丰县', 234, N'抚州', N'nfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1974, N'崇仁县', 234, N'抚州', N'crx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1975, N'乐安县', 234, N'抚州', N'lax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1976, N'宜黄县', 234, N'抚州', N'yhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1977, N'金溪县', 234, N'抚州', N'jxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1978, N'资溪县', 234, N'抚州', N'zxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1979, N'东乡县', 234, N'抚州', N'dxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1980, N'广昌县', 234, N'抚州', N'gcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1981, N'章贡区', 235, N'赣州', N'zgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1982, N'于都县', 235, N'赣州', N'ydx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1983, N'瑞金市', 235, N'赣州', N'rjs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1984, N'南康市', 235, N'赣州', N'nks', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1985, N'赣县', 235, N'赣州', N'gx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1986, N'信丰县', 235, N'赣州', N'xfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1987, N'大余县', 235, N'赣州', N'dyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1988, N'上犹县', 235, N'赣州', N'syx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1989, N'崇义县', 235, N'赣州', N'cyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1990, N'安远县', 235, N'赣州', N'ayx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1991, N'龙南县', 235, N'赣州', N'lnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1992, N'定南县', 235, N'赣州', N'dnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1993, N'全南县', 235, N'赣州', N'qnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1994, N'宁都县', 235, N'赣州', N'ndx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1995, N'兴国县', 235, N'赣州', N'xgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1996, N'会昌县', 235, N'赣州', N'hcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1997, N'寻乌县', 235, N'赣州', N'xwx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1998, N'石城县', 235, N'赣州', N'scx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (1999, N'安福县', 236, N'吉安', N'afx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2000, N'吉州区', 236, N'吉安', N'jzq', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2001, N'青原区', 236, N'吉安', N'qyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2002, N'井冈山市', 236, N'吉安', N'jgss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2003, N'吉安县', 236, N'吉安', N'jax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2004, N'吉水县', 236, N'吉安', N'jsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2005, N'峡江县', 236, N'吉安', N'xjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2006, N'新干县', 236, N'吉安', N'xgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2007, N'永丰县', 236, N'吉安', N'yfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2008, N'泰和县', 236, N'吉安', N'thx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2009, N'遂川县', 236, N'吉安', N'scx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2010, N'万安县', 236, N'吉安', N'wax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2011, N'永新县', 236, N'吉安', N'yxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2012, N'珠山区', 237, N'景德镇', N'zsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2013, N'昌江区', 237, N'景德镇', N'cjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2014, N'乐平市', 237, N'景德镇', N'lps', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2015, N'浮梁县', 237, N'景德镇', N'flx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2016, N'浔阳区', 238, N'九江', N'xyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2017, N'庐山区', 238, N'九江', N'lsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2018, N'瑞昌市', 238, N'九江', N'rcs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2019, N'九江县', 238, N'九江', N'jjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2020, N'武宁县', 238, N'九江', N'wnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2021, N'修水县', 238, N'九江', N'xsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2022, N'永修县', 238, N'九江', N'yxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2023, N'德安县', 238, N'九江', N'dax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2024, N'星子县', 238, N'九江', N'xzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2025, N'都昌县', 238, N'九江', N'dcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2026, N'湖口县', 238, N'九江', N'hkx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2027, N'彭泽县', 238, N'九江', N'pzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2028, N'安源区', 239, N'萍乡', N'ayq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2029, N'湘东区', 239, N'萍乡', N'xdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2030, N'莲花县', 239, N'萍乡', N'lhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2031, N'芦溪县', 239, N'萍乡', N'lxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2032, N'上栗县', 239, N'萍乡', N'slx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2033, N'信州区', 240, N'上饶', N'xzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2034, N'德兴市', 240, N'上饶', N'dxs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2035, N'上饶县', 240, N'上饶', N'srx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2036, N'广丰县', 240, N'上饶', N'gfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2037, N'玉山县', 240, N'上饶', N'ysx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2038, N'铅山县', 240, N'上饶', N'qsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2039, N'横峰县', 240, N'上饶', N'hfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2040, N'弋阳县', 240, N'上饶', N'yyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2041, N'余干县', 240, N'上饶', N'ygx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2042, N'波阳县', 240, N'上饶', N'byx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2043, N'万年县', 240, N'上饶', N'wnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2044, N'婺源县', 240, N'上饶', N'wyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2045, N'渝水区', 241, N'新余', N'ysq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2046, N'分宜县', 241, N'新余', N'fyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2047, N'袁州区', 242, N'宜春', N'yzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2048, N'丰城市', 242, N'宜春', N'fcs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2049, N'樟树市', 242, N'宜春', N'zss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2050, N'高安市', 242, N'宜春', N'gas', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2051, N'奉新县', 242, N'宜春', N'fxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2052, N'万载县', 242, N'宜春', N'wzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2053, N'上高县', 242, N'宜春', N'sgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2054, N'宜丰县', 242, N'宜春', N'yfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2055, N'靖安县', 242, N'宜春', N'jax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2056, N'铜鼓县', 242, N'宜春', N'tgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2057, N'月湖区', 243, N'鹰潭', N'yhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2058, N'贵溪市', 243, N'鹰潭', N'gxs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2059, N'余江县', 243, N'鹰潭', N'yjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2060, N'沈河区', 244, N'沈阳', N'shq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2061, N'皇姑区', 244, N'沈阳', N'hgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2062, N'和平区', 244, N'沈阳', N'hpq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2063, N'大东区', 244, N'沈阳', N'ddq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2064, N'铁西区', 244, N'沈阳', N'txq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2065, N'苏家屯区', 244, N'沈阳', N'sjtq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2066, N'东陵区', 244, N'沈阳', N'dlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2067, N'沈北新区', 244, N'沈阳', N'sbxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2068, N'于洪区', 244, N'沈阳', N'yhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2069, N'浑南新区', 244, N'沈阳', N'hnxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2070, N'新民市', 244, N'沈阳', N'xms', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2071, N'辽中县', 244, N'沈阳', N'lzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2072, N'康平县', 244, N'沈阳', N'kpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2073, N'法库县', 244, N'沈阳', N'fkx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2074, N'西岗区', 245, N'大连', N'xgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2075, N'中山区', 245, N'大连', N'zsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2076, N'沙河口区', 245, N'大连', N'shkq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2077, N'甘井子区', 245, N'大连', N'gjzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2078, N'旅顺口区', 245, N'大连', N'lskq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2079, N'金州区', 245, N'大连', N'jzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2080, N'开发区', 245, N'大连', N'kfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2081, N'瓦房店市', 245, N'大连', N'wfds', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2082, N'普兰店市', 245, N'大连', N'plds', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2083, N'庄河市', 245, N'大连', N'zhs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2084, N'长海县', 245, N'大连', N'chx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2085, N'铁东区', 246, N'鞍山', N'tdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2086, N'铁西区', 246, N'鞍山', N'txq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2087, N'立山区', 246, N'鞍山', N'lsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2088, N'千山区', 246, N'鞍山', N'qsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2089, N'岫岩', 246, N'鞍山', N'xy', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2090, N'海城市', 246, N'鞍山', N'hcs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2091, N'台安县', 246, N'鞍山', N'tax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2092, N'本溪', 247, N'本溪', N'bx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2093, N'平山区', 247, N'本溪', N'psq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2094, N'明山区', 247, N'本溪', N'msq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2095, N'溪湖区', 247, N'本溪', N'xhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2096, N'南芬区', 247, N'本溪', N'nfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2097, N'桓仁', 247, N'本溪', N'hr', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2098, N'双塔区', 248, N'朝阳', N'stq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2099, N'龙城区', 248, N'朝阳', N'lcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2100, N'喀喇沁左翼蒙古族自治县', 248, N'朝阳', N'klqzymgzzzx', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2101, N'北票市', 248, N'朝阳', N'bps', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2102, N'凌源市', 248, N'朝阳', N'lys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2103, N'朝阳县', 248, N'朝阳', N'cyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2104, N'建平县', 248, N'朝阳', N'jpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2105, N'振兴区', 249, N'丹东', N'zxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2106, N'元宝区', 249, N'丹东', N'ybq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2107, N'振安区', 249, N'丹东', N'zaq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2108, N'宽甸', 249, N'丹东', N'kd', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2109, N'东港市', 249, N'丹东', N'dgs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2110, N'凤城市', 249, N'丹东', N'fcs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2111, N'顺城区', 250, N'抚顺', N'scq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2112, N'新抚区', 250, N'抚顺', N'xfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2113, N'东洲区', 250, N'抚顺', N'dzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2114, N'望花区', 250, N'抚顺', N'whq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2115, N'清原', 250, N'抚顺', N'qy', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2116, N'新宾', 250, N'抚顺', N'xb', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2117, N'抚顺县', 250, N'抚顺', N'fsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2118, N'阜新', 251, N'阜新', N'fx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2119, N'海州区', 251, N'阜新', N'hzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2120, N'新邱区', 251, N'阜新', N'xqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2121, N'太平区', 251, N'阜新', N'tpq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2122, N'清河门区', 251, N'阜新', N'qhmq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2123, N'细河区', 251, N'阜新', N'xhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2124, N'彰武县', 251, N'阜新', N'zwx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2125, N'龙港区', 252, N'葫芦岛', N'lgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2126, N'南票区', 252, N'葫芦岛', N'npq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2127, N'连山区', 252, N'葫芦岛', N'lsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2128, N'兴城市', 252, N'葫芦岛', N'xcs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2129, N'绥中县', 252, N'葫芦岛', N'szx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2130, N'建昌县', 252, N'葫芦岛', N'jcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2131, N'太和区', 253, N'锦州', N'thq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2132, N'古塔区', 253, N'锦州', N'gtq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2133, N'凌河区', 253, N'锦州', N'lhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2134, N'凌海市', 253, N'锦州', N'lhs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2135, N'北镇市', 253, N'锦州', N'bzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2136, N'黑山县', 253, N'锦州', N'hsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2137, N'义县', 253, N'锦州', N'yx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2138, N'白塔区', 254, N'辽阳', N'btq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2139, N'文圣区', 254, N'辽阳', N'wsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2140, N'宏伟区', 254, N'辽阳', N'hwq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2141, N'太子河区', 254, N'辽阳', N'tzhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2142, N'弓长岭区', 254, N'辽阳', N'gclq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2143, N'灯塔市', 254, N'辽阳', N'dts', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2144, N'辽阳县', 254, N'辽阳', N'lyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2145, N'双台子区', 255, N'盘锦', N'stzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2146, N'兴隆台区', 255, N'盘锦', N'xltq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2147, N'大洼县', 255, N'盘锦', N'dwx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2148, N'盘山县', 255, N'盘锦', N'psx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2149, N'银州区', 256, N'铁岭', N'yzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2150, N'清河区', 256, N'铁岭', N'qhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2151, N'调兵山市', 256, N'铁岭', N'tbss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2152, N'开原市', 256, N'铁岭', N'kys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2153, N'铁岭县', 256, N'铁岭', N'tlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2154, N'西丰县', 256, N'铁岭', N'xfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2155, N'昌图县', 256, N'铁岭', N'ctx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2156, N'站前区', 257, N'营口', N'zqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2157, N'西市区', 257, N'营口', N'xsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2158, N'鲅鱼圈区', 257, N'营口', N'byqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2159, N'老边区', 257, N'营口', N'lbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2160, N'盖州市', 257, N'营口', N'gzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2161, N'大石桥市', 257, N'营口', N'dsqs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2162, N'回民区', 258, N'呼和浩特', N'hmq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2163, N'玉泉区', 258, N'呼和浩特', N'yqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2164, N'新城区', 258, N'呼和浩特', N'xcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2165, N'赛罕区', 258, N'呼和浩特', N'shq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2166, N'清水河县', 258, N'呼和浩特', N'qshx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2167, N'土默特左旗', 258, N'呼和浩特', N'tmtzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2168, N'托克托县', 258, N'呼和浩特', N'tktx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2169, N'和林格尔县', 258, N'呼和浩特', N'hlgex', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2170, N'武川县', 258, N'呼和浩特', N'wcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2171, N'阿拉善左旗', 259, N'阿拉善盟', N'alszq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2172, N'阿拉善右旗', 259, N'阿拉善盟', N'alsyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2173, N'额济纳旗', 259, N'阿拉善盟', N'ejnq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2174, N'临河区', 260, N'巴彦淖尔盟', N'lhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2175, N'五原县', 260, N'巴彦淖尔盟', N'wyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2176, N'磴口县', 260, N'巴彦淖尔盟', N'dkx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2177, N'乌拉特前旗', 260, N'巴彦淖尔盟', N'wltqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2178, N'乌拉特中旗', 260, N'巴彦淖尔盟', N'wltzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2179, N'乌拉特后旗', 260, N'巴彦淖尔盟', N'wlthq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2180, N'杭锦后旗', 260, N'巴彦淖尔盟', N'hjhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2181, N'昆都仑区', 261, N'包头', N'kdlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2182, N'青山区', 261, N'包头', N'qsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2183, N'东河区', 261, N'包头', N'dhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2184, N'九原区', 261, N'包头', N'jyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2185, N'石拐区', 261, N'包头', N'sgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2186, N'白云矿区', 261, N'包头', N'bykq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2187, N'土默特右旗', 261, N'包头', N'tmtyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2188, N'固阳县', 261, N'包头', N'gyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2189, N'达尔罕茂明安联合旗', 261, N'包头', N'dehmmalhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2190, N'红山区', 262, N'赤峰', N'hsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2191, N'元宝山区', 262, N'赤峰', N'ybsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2192, N'松山区', 262, N'赤峰', N'ssq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2193, N'阿鲁科尔沁旗', 262, N'赤峰', N'alkeqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2194, N'巴林左旗', 262, N'赤峰', N'blzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2195, N'巴林右旗', 262, N'赤峰', N'blyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2196, N'林西县', 262, N'赤峰', N'lxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2197, N'克什克腾旗', 262, N'赤峰', N'ksktq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2198, N'翁牛特旗', 262, N'赤峰', N'wntq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2199, N'喀喇沁旗', 262, N'赤峰', N'klqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2200, N'宁城县', 262, N'赤峰', N'ncx', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2201, N'敖汉旗', 262, N'赤峰', N'ahq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2202, N'东胜区', 263, N'鄂尔多斯', N'dsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2203, N'达拉特旗', 263, N'鄂尔多斯', N'dltq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2204, N'准格尔旗', 263, N'鄂尔多斯', N'zgeq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2205, N'鄂托克前旗', 263, N'鄂尔多斯', N'etkqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2206, N'鄂托克旗', 263, N'鄂尔多斯', N'etkq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2207, N'杭锦旗', 263, N'鄂尔多斯', N'hjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2208, N'乌审旗', 263, N'鄂尔多斯', N'wsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2209, N'伊金霍洛旗', 263, N'鄂尔多斯', N'yjhlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2210, N'海拉尔区', 264, N'呼伦贝尔', N'hleq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2211, N'莫力达瓦', 264, N'呼伦贝尔', N'mldw', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2212, N'满洲里市', 264, N'呼伦贝尔', N'mzls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2213, N'牙克石市', 264, N'呼伦贝尔', N'ykss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2214, N'扎兰屯市', 264, N'呼伦贝尔', N'zlts', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2215, N'额尔古纳市', 264, N'呼伦贝尔', N'eegns', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2216, N'根河市', 264, N'呼伦贝尔', N'ghs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2217, N'阿荣旗', 264, N'呼伦贝尔', N'arq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2218, N'鄂伦春自治旗', 264, N'呼伦贝尔', N'elczzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2219, N'鄂温克族自治旗', 264, N'呼伦贝尔', N'ewkzzzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2220, N'陈巴尔虎旗', 264, N'呼伦贝尔', N'cbehq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2221, N'新巴尔虎左旗', 264, N'呼伦贝尔', N'xbehzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2222, N'新巴尔虎右旗', 264, N'呼伦贝尔', N'xbehyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2223, N'科尔沁区', 265, N'通辽', N'keqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2224, N'霍林郭勒市', 265, N'通辽', N'hlgls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2225, N'科尔沁左翼中旗', 265, N'通辽', N'keqzyzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2226, N'科尔沁左翼后旗', 265, N'通辽', N'keqzyhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2227, N'开鲁县', 265, N'通辽', N'klx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2228, N'库伦旗', 265, N'通辽', N'klq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2229, N'奈曼旗', 265, N'通辽', N'nmq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2230, N'扎鲁特旗', 265, N'通辽', N'zltq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2231, N'海勃湾区', 266, N'乌海', N'hbwq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2232, N'乌达区', 266, N'乌海', N'wdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2233, N'海南区', 266, N'乌海', N'hnq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2234, N'化德县', 267, N'乌兰察布市', N'hdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2235, N'集宁区', 267, N'乌兰察布市', N'jnq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2236, N'丰镇市', 267, N'乌兰察布市', N'fzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2237, N'卓资县', 267, N'乌兰察布市', N'zzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2238, N'商都县', 267, N'乌兰察布市', N'sdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2239, N'兴和县', 267, N'乌兰察布市', N'xhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2240, N'凉城县', 267, N'乌兰察布市', N'lcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2241, N'察哈尔右翼前旗', 267, N'乌兰察布市', N'cheyyqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2242, N'察哈尔右翼中旗', 267, N'乌兰察布市', N'cheyyzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2243, N'察哈尔右翼后旗', 267, N'乌兰察布市', N'cheyyhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2244, N'四子王旗', 267, N'乌兰察布市', N'szwq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2245, N'二连浩特市', 268, N'锡林郭勒盟', N'elhts', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2246, N'锡林浩特市', 268, N'锡林郭勒盟', N'xlhts', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2247, N'阿巴嘎旗', 268, N'锡林郭勒盟', N'abgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2248, N'苏尼特左旗', 268, N'锡林郭勒盟', N'sntzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2249, N'苏尼特右旗', 268, N'锡林郭勒盟', N'sntyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2250, N'东乌珠穆沁旗', 268, N'锡林郭勒盟', N'dwzmqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2251, N'西乌珠穆沁旗', 268, N'锡林郭勒盟', N'xwzmqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2252, N'太仆寺旗', 268, N'锡林郭勒盟', N'tpsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2253, N'镶黄旗', 268, N'锡林郭勒盟', N'xhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2254, N'正镶白旗', 268, N'锡林郭勒盟', N'zxbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2255, N'正蓝旗', 268, N'锡林郭勒盟', N'zlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2256, N'多伦县', 268, N'锡林郭勒盟', N'dlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2257, N'乌兰浩特市', 269, N'兴安盟', N'wlhts', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2258, N'阿尔山市', 269, N'兴安盟', N'aess', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2259, N'科尔沁右翼前旗', 269, N'兴安盟', N'keqyyqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2260, N'科尔沁右翼中旗', 269, N'兴安盟', N'keqyyzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2261, N'扎赉特旗', 269, N'兴安盟', N'zltq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2262, N'突泉县', 269, N'兴安盟', N'tqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2263, N'西夏区', 270, N'银川', N'xxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2264, N'金凤区', 270, N'银川', N'jfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2265, N'兴庆区', 270, N'银川', N'xqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2266, N'灵武市', 270, N'银川', N'lws', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2267, N'永宁县', 270, N'银川', N'ynx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2268, N'贺兰县', 270, N'银川', N'hlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2269, N'原州区', 271, N'固原', N'yzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2270, N'海原县', 271, N'固原', N'hyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2271, N'西吉县', 271, N'固原', N'xjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2272, N'隆德县', 271, N'固原', N'ldx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2273, N'泾源县', 271, N'固原', N'jyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2274, N'彭阳县', 271, N'固原', N'pyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2275, N'惠农县', 272, N'石嘴山', N'hnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2276, N'大武口区', 272, N'石嘴山', N'dwkq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2277, N'惠农区', 272, N'石嘴山', N'hnq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2278, N'陶乐县', 272, N'石嘴山', N'tlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2279, N'平罗县', 272, N'石嘴山', N'plx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2280, N'利通区', 273, N'吴忠', N'ltq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2281, N'中卫县', 273, N'吴忠', N'zwx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2282, N'青铜峡市', 273, N'吴忠', N'qtxs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2283, N'中宁县', 273, N'吴忠', N'znx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2284, N'盐池县', 273, N'吴忠', N'ycx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2285, N'同心县', 273, N'吴忠', N'txx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2286, N'沙坡头区', 274, N'中卫', N'sptq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2287, N'海原县', 274, N'中卫', N'hyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2288, N'中宁县', 274, N'中卫', N'znx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2289, N'城中区', 275, N'西宁', N'czq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2290, N'城东区', 275, N'西宁', N'cdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2291, N'城西区', 275, N'西宁', N'cxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2292, N'城北区', 275, N'西宁', N'cbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2293, N'湟中县', 275, N'西宁', N'hzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2294, N'湟源县', 275, N'西宁', N'hyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2295, N'大通', 275, N'西宁', N'dt', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2296, N'玛沁县', 276, N'果洛', N'mqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2297, N'班玛县', 276, N'果洛', N'bmx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2298, N'甘德县', 276, N'果洛', N'gdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2299, N'达日县', 276, N'果洛', N'drx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2300, N'久治县', 276, N'果洛', N'jzx', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2301, N'玛多县', 276, N'果洛', N'mdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2302, N'海晏县', 277, N'海北', N'hyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2303, N'祁连县', 277, N'海北', N'qlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2304, N'刚察县', 277, N'海北', N'gcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2305, N'门源', 277, N'海北', N'my', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2306, N'平安县', 278, N'海东', N'pax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2307, N'乐都县', 278, N'海东', N'ldx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2308, N'民和', 278, N'海东', N'mh', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2309, N'互助', 278, N'海东', N'hz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2310, N'化隆', 278, N'海东', N'hl', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2311, N'循化', 278, N'海东', N'xh', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2312, N'共和县', 279, N'海南', N'ghx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2313, N'同德县', 279, N'海南', N'tdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2314, N'贵德县', 279, N'海南', N'gdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2315, N'兴海县', 279, N'海南', N'xhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2316, N'贵南县', 279, N'海南', N'gnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2317, N'德令哈市', 280, N'海西', N'dlhs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2318, N'格尔木市', 280, N'海西', N'gems', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2319, N'乌兰县', 280, N'海西', N'wlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2320, N'都兰县', 280, N'海西', N'dlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2321, N'天峻县', 280, N'海西', N'tjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2322, N'同仁县', 281, N'黄南', N'trx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2323, N'尖扎县', 281, N'黄南', N'jzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2324, N'泽库县', 281, N'黄南', N'zkx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2325, N'河南蒙古族自治县', 281, N'黄南', N'hnmgzzzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2326, N'玉树县', 282, N'玉树', N'ysx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2327, N'杂多县', 282, N'玉树', N'zdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2328, N'称多县', 282, N'玉树', N'cdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2329, N'治多县', 282, N'玉树', N'zdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2330, N'囊谦县', 282, N'玉树', N'nqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2331, N'曲麻莱县', 282, N'玉树', N'qmlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2332, N'市中区', 283, N'济南', N'szq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2333, N'历下区', 283, N'济南', N'lxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2334, N'天桥区', 283, N'济南', N'tqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2335, N'槐荫区', 283, N'济南', N'hyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2336, N'历城区', 283, N'济南', N'lcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2337, N'长清区', 283, N'济南', N'cqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2338, N'章丘市', 283, N'济南', N'zqs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2339, N'平阴县', 283, N'济南', N'pyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2340, N'济阳县', 283, N'济南', N'jyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2341, N'商河县', 283, N'济南', N'shx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2342, N'市南区', 284, N'青岛', N'snq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2343, N'市北区', 284, N'青岛', N'sbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2344, N'城阳区', 284, N'青岛', N'cyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2345, N'四方区', 284, N'青岛', N'sfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2346, N'李沧区', 284, N'青岛', N'lcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2347, N'黄岛区', 284, N'青岛', N'hdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2348, N'崂山区', 284, N'青岛', N'lsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2349, N'胶州市', 284, N'青岛', N'jzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2350, N'即墨市', 284, N'青岛', N'jms', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2351, N'平度市', 284, N'青岛', N'pds', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2352, N'胶南市', 284, N'青岛', N'jns', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2353, N'莱西市', 284, N'青岛', N'lxs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2354, N'滨城区', 285, N'滨州', N'bcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2355, N'惠民县', 285, N'滨州', N'hmx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2356, N'阳信县', 285, N'滨州', N'yxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2357, N'无棣县', 285, N'滨州', N'wdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2358, N'沾化县', 285, N'滨州', N'zhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2359, N'博兴县', 285, N'滨州', N'bxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2360, N'邹平县', 285, N'滨州', N'zpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2361, N'德城区', 286, N'德州', N'dcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2362, N'陵县', 286, N'德州', N'lx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2363, N'乐陵市', 286, N'德州', N'lls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2364, N'禹城市', 286, N'德州', N'ycs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2365, N'宁津县', 286, N'德州', N'njx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2366, N'庆云县', 286, N'德州', N'qyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2367, N'临邑县', 286, N'德州', N'lyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2368, N'齐河县', 286, N'德州', N'qhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2369, N'平原县', 286, N'德州', N'pyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2370, N'夏津县', 286, N'德州', N'xjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2371, N'武城县', 286, N'德州', N'wcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2372, N'东营区', 287, N'东营', N'dyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2373, N'河口区', 287, N'东营', N'hkq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2374, N'垦利县', 287, N'东营', N'klx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2375, N'利津县', 287, N'东营', N'ljx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2376, N'广饶县', 287, N'东营', N'grx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2377, N'牡丹区', 288, N'菏泽', N'mdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2378, N'曹县', 288, N'菏泽', N'cx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2379, N'单县', 288, N'菏泽', N'dx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2380, N'成武县', 288, N'菏泽', N'cwx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2381, N'巨野县', 288, N'菏泽', N'jyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2382, N'郓城县', 288, N'菏泽', N'ycx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2383, N'鄄城县', 288, N'菏泽', N'jcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2384, N'定陶县', 288, N'菏泽', N'dtx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2385, N'东明县', 288, N'菏泽', N'dmx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2386, N'市中区', 289, N'济宁', N'szq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2387, N'任城区', 289, N'济宁', N'rcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2388, N'曲阜市', 289, N'济宁', N'qfs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2389, N'兖州市', 289, N'济宁', N'yzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2390, N'邹城市', 289, N'济宁', N'zcs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2391, N'微山县', 289, N'济宁', N'wsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2392, N'鱼台县', 289, N'济宁', N'ytx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2393, N'金乡县', 289, N'济宁', N'jxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2394, N'嘉祥县', 289, N'济宁', N'jxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2395, N'汶上县', 289, N'济宁', N'wsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2396, N'泗水县', 289, N'济宁', N'ssx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2397, N'梁山县', 289, N'济宁', N'lsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2398, N'莱城区', 290, N'莱芜', N'lcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2399, N'钢城区', 290, N'莱芜', N'gcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2400, N'东昌府区', 291, N'聊城', N'dcfq', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2401, N'临清市', 291, N'聊城', N'lqs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2402, N'阳谷县', 291, N'聊城', N'ygx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2403, N'莘县', 291, N'聊城', N'sx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2404, N'茌平县', 291, N'聊城', N'cpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2405, N'东阿县', 291, N'聊城', N'dax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2406, N'冠县', 291, N'聊城', N'gx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2407, N'高唐县', 291, N'聊城', N'gtx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2408, N'兰山区', 292, N'临沂', N'lsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2409, N'罗庄区', 292, N'临沂', N'lzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2410, N'河东区', 292, N'临沂', N'hdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2411, N'沂南县', 292, N'临沂', N'ynx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2412, N'郯城县', 292, N'临沂', N'tcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2413, N'沂水县', 292, N'临沂', N'ysx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2414, N'苍山县', 292, N'临沂', N'csx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2415, N'费县', 292, N'临沂', N'fx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2416, N'平邑县', 292, N'临沂', N'pyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2417, N'莒南县', 292, N'临沂', N'jnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2418, N'蒙阴县', 292, N'临沂', N'myx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2419, N'临沭县', 292, N'临沂', N'lsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2420, N'东港区', 293, N'日照', N'dgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2421, N'岚山区', 293, N'日照', N'lsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2422, N'五莲县', 293, N'日照', N'wlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2423, N'莒县', 293, N'日照', N'jx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2424, N'泰山区', 294, N'泰安', N'tsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2425, N'岱岳区', 294, N'泰安', N'dyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2426, N'新泰市', 294, N'泰安', N'xts', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2427, N'肥城市', 294, N'泰安', N'fcs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2428, N'宁阳县', 294, N'泰安', N'nyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2429, N'东平县', 294, N'泰安', N'dpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2430, N'荣成市', 295, N'威海', N'rcs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2431, N'乳山市', 295, N'威海', N'rss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2432, N'环翠区', 295, N'威海', N'hcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2433, N'文登市', 295, N'威海', N'wds', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2434, N'潍城区', 296, N'潍坊', N'wcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2435, N'寒亭区', 296, N'潍坊', N'htq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2436, N'坊子区', 296, N'潍坊', N'fzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2437, N'奎文区', 296, N'潍坊', N'kwq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2438, N'青州市', 296, N'潍坊', N'qzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2439, N'诸城市', 296, N'潍坊', N'zcs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2440, N'寿光市', 296, N'潍坊', N'sgs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2441, N'安丘市', 296, N'潍坊', N'aqs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2442, N'高密市', 296, N'潍坊', N'gms', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2443, N'昌邑市', 296, N'潍坊', N'cys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2444, N'临朐县', 296, N'潍坊', N'lqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2445, N'昌乐县', 296, N'潍坊', N'clx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2446, N'芝罘区', 297, N'烟台', N'zfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2447, N'福山区', 297, N'烟台', N'fsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2448, N'牟平区', 297, N'烟台', N'mpq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2449, N'莱山区', 297, N'烟台', N'lsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2450, N'开发区', 297, N'烟台', N'kfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2451, N'龙口市', 297, N'烟台', N'lks', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2452, N'莱阳市', 297, N'烟台', N'lys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2453, N'莱州市', 297, N'烟台', N'lzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2454, N'蓬莱市', 297, N'烟台', N'pls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2455, N'招远市', 297, N'烟台', N'zys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2456, N'栖霞市', 297, N'烟台', N'qxs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2457, N'海阳市', 297, N'烟台', N'hys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2458, N'长岛县', 297, N'烟台', N'cdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2459, N'市中区', 298, N'枣庄', N'szq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2460, N'山亭区', 298, N'枣庄', N'stq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2461, N'峄城区', 298, N'枣庄', N'ycq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2462, N'台儿庄区', 298, N'枣庄', N'tezq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2463, N'薛城区', 298, N'枣庄', N'xcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2464, N'滕州市', 298, N'枣庄', N'tzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2465, N'张店区', 299, N'淄博', N'zdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2466, N'临淄区', 299, N'淄博', N'lzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2467, N'淄川区', 299, N'淄博', N'zcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2468, N'博山区', 299, N'淄博', N'bsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2469, N'周村区', 299, N'淄博', N'zcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2470, N'桓台县', 299, N'淄博', N'htx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2471, N'高青县', 299, N'淄博', N'gqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2472, N'沂源县', 299, N'淄博', N'yyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2473, N'杏花岭区', 300, N'太原', N'xhlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2474, N'小店区', 300, N'太原', N'xdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2475, N'迎泽区', 300, N'太原', N'yzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2476, N'尖草坪区', 300, N'太原', N'jcpq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2477, N'万柏林区', 300, N'太原', N'wblq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2478, N'晋源区', 300, N'太原', N'jyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2479, N'高新开发区', 300, N'太原', N'gxkfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2480, N'民营经济开发区', 300, N'太原', N'myjjkfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2481, N'经济技术开发区', 300, N'太原', N'jjjskfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2482, N'清徐县', 300, N'太原', N'qxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2483, N'阳曲县', 300, N'太原', N'yqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2484, N'娄烦县', 300, N'太原', N'lfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2485, N'古交市', 300, N'太原', N'gjs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2486, N'城区', 301, N'长治', N'cq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2487, N'郊区', 301, N'长治', N'jq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2488, N'沁县', 301, N'长治', N'qx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2489, N'潞城市', 301, N'长治', N'lcs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2490, N'长治县', 301, N'长治', N'czx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2491, N'襄垣县', 301, N'长治', N'xyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2492, N'屯留县', 301, N'长治', N'tlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2493, N'平顺县', 301, N'长治', N'psx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2494, N'黎城县', 301, N'长治', N'lcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2495, N'壶关县', 301, N'长治', N'hgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2496, N'长子县', 301, N'长治', N'czx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2497, N'武乡县', 301, N'长治', N'wxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2498, N'沁源县', 301, N'长治', N'qyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2499, N'城区', 302, N'大同', N'cq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2500, N'矿区', 302, N'大同', N'kq', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2501, N'南郊区', 302, N'大同', N'njq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2502, N'新荣区', 302, N'大同', N'xrq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2503, N'阳高县', 302, N'大同', N'ygx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2504, N'天镇县', 302, N'大同', N'tzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2505, N'广灵县', 302, N'大同', N'glx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2506, N'灵丘县', 302, N'大同', N'lqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2507, N'浑源县', 302, N'大同', N'hyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2508, N'左云县', 302, N'大同', N'zyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2509, N'大同县', 302, N'大同', N'dtx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2510, N'城区', 303, N'晋城', N'cq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2511, N'高平市', 303, N'晋城', N'gps', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2512, N'沁水县', 303, N'晋城', N'qsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2513, N'阳城县', 303, N'晋城', N'ycx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2514, N'陵川县', 303, N'晋城', N'lcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2515, N'泽州县', 303, N'晋城', N'zzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2516, N'榆次区', 304, N'晋中', N'ycq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2517, N'介休市', 304, N'晋中', N'jxs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2518, N'榆社县', 304, N'晋中', N'ysx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2519, N'左权县', 304, N'晋中', N'zqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2520, N'和顺县', 304, N'晋中', N'hsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2521, N'昔阳县', 304, N'晋中', N'xyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2522, N'寿阳县', 304, N'晋中', N'syx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2523, N'太谷县', 304, N'晋中', N'tgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2524, N'祁县', 304, N'晋中', N'qx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2525, N'平遥县', 304, N'晋中', N'pyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2526, N'灵石县', 304, N'晋中', N'lsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2527, N'尧都区', 305, N'临汾', N'ydq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2528, N'侯马市', 305, N'临汾', N'hms', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2529, N'霍州市', 305, N'临汾', N'hzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2530, N'曲沃县', 305, N'临汾', N'qwx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2531, N'翼城县', 305, N'临汾', N'ycx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2532, N'襄汾县', 305, N'临汾', N'xfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2533, N'洪洞县', 305, N'临汾', N'hdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2534, N'吉县', 305, N'临汾', N'jx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2535, N'安泽县', 305, N'临汾', N'azx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2536, N'浮山县', 305, N'临汾', N'fsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2537, N'古县', 305, N'临汾', N'gx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2538, N'乡宁县', 305, N'临汾', N'xnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2539, N'大宁县', 305, N'临汾', N'dnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2540, N'隰县', 305, N'临汾', N'xx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2541, N'永和县', 305, N'临汾', N'yhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2542, N'蒲县', 305, N'临汾', N'px', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2543, N'汾西县', 305, N'临汾', N'fxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2544, N'离石市', 306, N'吕梁', N'lss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2545, N'离石区', 306, N'吕梁', N'lsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2546, N'孝义市', 306, N'吕梁', N'xys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2547, N'汾阳市', 306, N'吕梁', N'fys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2548, N'文水县', 306, N'吕梁', N'wsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2549, N'交城县', 306, N'吕梁', N'jcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2550, N'兴县', 306, N'吕梁', N'xx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2551, N'临县', 306, N'吕梁', N'lx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2552, N'柳林县', 306, N'吕梁', N'llx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2553, N'石楼县', 306, N'吕梁', N'slx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2554, N'岚县', 306, N'吕梁', N'lx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2555, N'方山县', 306, N'吕梁', N'fsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2556, N'中阳县', 306, N'吕梁', N'zyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2557, N'交口县', 306, N'吕梁', N'jkx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2558, N'朔城区', 307, N'朔州', N'scq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2559, N'平鲁区', 307, N'朔州', N'plq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2560, N'山阴县', 307, N'朔州', N'syx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2561, N'应县', 307, N'朔州', N'yx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2562, N'右玉县', 307, N'朔州', N'yyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2563, N'怀仁县', 307, N'朔州', N'hrx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2564, N'忻府区', 308, N'忻州', N'xfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2565, N'原平市', 308, N'忻州', N'yps', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2566, N'定襄县', 308, N'忻州', N'dxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2567, N'五台县', 308, N'忻州', N'wtx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2568, N'代县', 308, N'忻州', N'dx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2569, N'繁峙县', 308, N'忻州', N'fzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2570, N'宁武县', 308, N'忻州', N'nwx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2571, N'静乐县', 308, N'忻州', N'jlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2572, N'神池县', 308, N'忻州', N'scx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2573, N'五寨县', 308, N'忻州', N'wzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2574, N'岢岚县', 308, N'忻州', N'klx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2575, N'河曲县', 308, N'忻州', N'hqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2576, N'保德县', 308, N'忻州', N'bdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2577, N'偏关县', 308, N'忻州', N'pgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2578, N'城区', 309, N'阳泉', N'cq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2579, N'矿区', 309, N'阳泉', N'kq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2580, N'郊区', 309, N'阳泉', N'jq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2581, N'平定县', 309, N'阳泉', N'pdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2582, N'盂县', 309, N'阳泉', N'yx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2583, N'盐湖区', 310, N'运城', N'yhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2584, N'永济市', 310, N'运城', N'yjs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2585, N'河津市', 310, N'运城', N'hjs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2586, N'临猗县', 310, N'运城', N'lyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2587, N'万荣县', 310, N'运城', N'wrx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2588, N'闻喜县', 310, N'运城', N'wxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2589, N'稷山县', 310, N'运城', N'jsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2590, N'新绛县', 310, N'运城', N'xjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2591, N'绛县', 310, N'运城', N'jx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2592, N'垣曲县', 310, N'运城', N'yqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2593, N'夏县', 310, N'运城', N'xx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2594, N'平陆县', 310, N'运城', N'plx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2595, N'芮城县', 310, N'运城', N'rcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2596, N'莲湖区', 311, N'西安', N'lhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2597, N'新城区', 311, N'西安', N'xcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2598, N'碑林区', 311, N'西安', N'blq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2599, N'雁塔区', 311, N'西安', N'ytq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2600, N'灞桥区', 311, N'西安', N'bqq', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2601, N'未央区', 311, N'西安', N'wyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2602, N'阎良区', 311, N'西安', N'ylq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2603, N'临潼区', 311, N'西安', N'ltq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2604, N'长安区', 311, N'西安', N'caq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2605, N'蓝田县', 311, N'西安', N'ltx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2606, N'周至县', 311, N'西安', N'zzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2607, N'户县', 311, N'西安', N'hx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2608, N'高陵县', 311, N'西安', N'glx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2609, N'汉滨区', 312, N'安康', N'hbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2610, N'汉阴县', 312, N'安康', N'hyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2611, N'石泉县', 312, N'安康', N'sqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2612, N'宁陕县', 312, N'安康', N'nsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2613, N'紫阳县', 312, N'安康', N'zyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2614, N'岚皋县', 312, N'安康', N'lgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2615, N'平利县', 312, N'安康', N'plx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2616, N'镇坪县', 312, N'安康', N'zpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2617, N'旬阳县', 312, N'安康', N'xyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2618, N'白河县', 312, N'安康', N'bhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2619, N'陈仓区', 313, N'宝鸡', N'ccq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2620, N'渭滨区', 313, N'宝鸡', N'wbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2621, N'金台区', 313, N'宝鸡', N'jtq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2622, N'凤翔县', 313, N'宝鸡', N'fxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2623, N'岐山县', 313, N'宝鸡', N'qsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2624, N'扶风县', 313, N'宝鸡', N'ffx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2625, N'眉县', 313, N'宝鸡', N'mx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2626, N'陇县', 313, N'宝鸡', N'lx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2627, N'千阳县', 313, N'宝鸡', N'qyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2628, N'麟游县', 313, N'宝鸡', N'lyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2629, N'凤县', 313, N'宝鸡', N'fx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2630, N'太白县', 313, N'宝鸡', N'tbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2631, N'汉台区', 314, N'汉中', N'htq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2632, N'南郑县', 314, N'汉中', N'nzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2633, N'城固县', 314, N'汉中', N'cgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2634, N'洋县', 314, N'汉中', N'yx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2635, N'西乡县', 314, N'汉中', N'xxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2636, N'勉县', 314, N'汉中', N'mx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2637, N'宁强县', 314, N'汉中', N'nqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2638, N'略阳县', 314, N'汉中', N'lyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2639, N'镇巴县', 314, N'汉中', N'zbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2640, N'留坝县', 314, N'汉中', N'lbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2641, N'佛坪县', 314, N'汉中', N'px', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2642, N'商州区', 315, N'商洛', N'szq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2643, N'洛南县', 315, N'商洛', N'lnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2644, N'丹凤县', 315, N'商洛', N'dfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2645, N'商南县', 315, N'商洛', N'snx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2646, N'山阳县', 315, N'商洛', N'syx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2647, N'镇安县', 315, N'商洛', N'zax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2648, N'柞水县', 315, N'商洛', N'zsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2649, N'耀州区', 316, N'铜川', N'yzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2650, N'王益区', 316, N'铜川', N'wyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2651, N'印台区', 316, N'铜川', N'ytq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2652, N'宜君县', 316, N'铜川', N'yjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2653, N'临渭区', 317, N'渭南', N'lwq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2654, N'韩城市', 317, N'渭南', N'hcs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2655, N'华阴市', 317, N'渭南', N'hys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2656, N'华县', 317, N'渭南', N'hx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2657, N'潼关县', 317, N'渭南', N'tgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2658, N'大荔县', 317, N'渭南', N'dlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2659, N'合阳县', 317, N'渭南', N'hyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2660, N'澄城县', 317, N'渭南', N'ccx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2661, N'蒲城县', 317, N'渭南', N'pcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2662, N'白水县', 317, N'渭南', N'bsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2663, N'富平县', 317, N'渭南', N'fpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2664, N'秦都区', 318, N'咸阳', N'qdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2665, N'渭城区', 318, N'咸阳', N'wcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2666, N'杨陵区', 318, N'咸阳', N'ylq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2667, N'兴平市', 318, N'咸阳', N'xps', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2668, N'三原县', 318, N'咸阳', N'syx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2669, N'泾阳县', 318, N'咸阳', N'jyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2670, N'乾县', 318, N'咸阳', N'qx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2671, N'礼泉县', 318, N'咸阳', N'lqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2672, N'永寿县', 318, N'咸阳', N'ysx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2673, N'彬县', 318, N'咸阳', N'bx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2674, N'长武县', 318, N'咸阳', N'cwx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2675, N'旬邑县', 318, N'咸阳', N'xyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2676, N'淳化县', 318, N'咸阳', N'chx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2677, N'武功县', 318, N'咸阳', N'wgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2678, N'吴起县', 319, N'延安', N'wqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2679, N'宝塔区', 319, N'延安', N'btq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2680, N'延长县', 319, N'延安', N'ycx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2681, N'延川县', 319, N'延安', N'ycx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2682, N'子长县', 319, N'延安', N'zcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2683, N'安塞县', 319, N'延安', N'asx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2684, N'志丹县', 319, N'延安', N'zdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2685, N'甘泉县', 319, N'延安', N'gqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2686, N'富县', 319, N'延安', N'fx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2687, N'洛川县', 319, N'延安', N'lcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2688, N'宜川县', 319, N'延安', N'ycx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2689, N'黄龙县', 319, N'延安', N'hlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2690, N'黄陵县', 319, N'延安', N'hlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2691, N'榆阳区', 320, N'榆林', N'yyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2692, N'神木县', 320, N'榆林', N'smx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2693, N'府谷县', 320, N'榆林', N'fgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2694, N'横山县', 320, N'榆林', N'hsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2695, N'靖边县', 320, N'榆林', N'jbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2696, N'定边县', 320, N'榆林', N'dbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2697, N'绥德县', 320, N'榆林', N'sdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2698, N'米脂县', 320, N'榆林', N'mzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2699, N'佳县', 320, N'榆林', N'jx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2700, N'吴堡县', 320, N'榆林', N'wbx', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2701, N'清涧县', 320, N'榆林', N'qjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2702, N'子洲县', 320, N'榆林', N'zzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2703, N'长宁区', 321, N'上海', N'cnq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2704, N'闸北区', 321, N'上海', N'zbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2705, N'闵行区', 321, N'上海', N'mhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2706, N'徐汇区', 321, N'上海', N'xhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2707, N'浦东新区', 321, N'上海', N'pdxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2708, N'杨浦区', 321, N'上海', N'ypq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2709, N'普陀区', 321, N'上海', N'ptq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2710, N'静安区', 321, N'上海', N'jaq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2711, N'卢湾区', 321, N'上海', N'lwq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2712, N'虹口区', 321, N'上海', N'hkq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2713, N'黄浦区', 321, N'上海', N'hpq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2714, N'南汇区', 321, N'上海', N'nhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2715, N'松江区', 321, N'上海', N'sjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2716, N'嘉定区', 321, N'上海', N'jdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2717, N'宝山区', 321, N'上海', N'bsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2718, N'青浦区', 321, N'上海', N'qpq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2719, N'金山区', 321, N'上海', N'jsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2720, N'奉贤区', 321, N'上海', N'fxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2721, N'崇明县', 321, N'上海', N'cmx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2722, N'青羊区', 322, N'成都', N'qyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2723, N'锦江区', 322, N'成都', N'jjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2724, N'金牛区', 322, N'成都', N'jnq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2725, N'武侯区', 322, N'成都', N'whq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2726, N'成华区', 322, N'成都', N'chq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2727, N'龙泉驿区', 322, N'成都', N'lqyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2728, N'青白江区', 322, N'成都', N'qbjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2729, N'新都区', 322, N'成都', N'xdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2730, N'温江区', 322, N'成都', N'wjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2731, N'高新区', 322, N'成都', N'gxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2732, N'高新西区', 322, N'成都', N'gxxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2733, N'都江堰市', 322, N'成都', N'djys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2734, N'彭州市', 322, N'成都', N'pzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2735, N'邛崃市', 322, N'成都', N'qls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2736, N'崇州市', 322, N'成都', N'czs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2737, N'金堂县', 322, N'成都', N'jtx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2738, N'双流县', 322, N'成都', N'slx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2739, N'郫县', 322, N'成都', N'px', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2740, N'大邑县', 322, N'成都', N'dyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2741, N'蒲江县', 322, N'成都', N'pjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2742, N'新津县', 322, N'成都', N'xjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2743, N'都江堰市', 322, N'成都', N'djys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2744, N'彭州市', 322, N'成都', N'pzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2745, N'邛崃市', 322, N'成都', N'qls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2746, N'崇州市', 322, N'成都', N'czs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2747, N'金堂县', 322, N'成都', N'jtx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2748, N'双流县', 322, N'成都', N'slx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2749, N'郫县', 322, N'成都', N'px', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2750, N'大邑县', 322, N'成都', N'dyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2751, N'蒲江县', 322, N'成都', N'pjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2752, N'新津县', 322, N'成都', N'xjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2753, N'涪城区', 323, N'绵阳', N'fcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2754, N'游仙区', 323, N'绵阳', N'yxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2755, N'江油市', 323, N'绵阳', N'jys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2756, N'盐亭县', 323, N'绵阳', N'ytx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2757, N'三台县', 323, N'绵阳', N'stx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2758, N'平武县', 323, N'绵阳', N'pwx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2759, N'安县', 323, N'绵阳', N'ax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2760, N'梓潼县', 323, N'绵阳', N'ztx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2761, N'北川县', 323, N'绵阳', N'bcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2762, N'马尔康县', 324, N'阿坝', N'mekx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2763, N'汶川县', 324, N'阿坝', N'wcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2764, N'理县', 324, N'阿坝', N'lx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2765, N'茂县', 324, N'阿坝', N'mx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2766, N'松潘县', 324, N'阿坝', N'spx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2767, N'九寨沟县', 324, N'阿坝', N'jzgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2768, N'金川县', 324, N'阿坝', N'jcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2769, N'小金县', 324, N'阿坝', N'xjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2770, N'黑水县', 324, N'阿坝', N'hsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2771, N'壤塘县', 324, N'阿坝', N'rtx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2772, N'阿坝县', 324, N'阿坝', N'abx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2773, N'若尔盖县', 324, N'阿坝', N'regx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2774, N'红原县', 324, N'阿坝', N'hyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2775, N'巴州区', 325, N'巴中', N'bzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2776, N'通江县', 325, N'巴中', N'tjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2777, N'南江县', 325, N'巴中', N'njx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2778, N'平昌县', 325, N'巴中', N'pcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2779, N'通川区', 326, N'达州', N'tcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2780, N'万源市', 326, N'达州', N'wys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2781, N'达县', 326, N'达州', N'dx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2782, N'宣汉县', 326, N'达州', N'xhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2783, N'开江县', 326, N'达州', N'kjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2784, N'大竹县', 326, N'达州', N'dzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2785, N'渠县', 326, N'达州', N'qx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2786, N'旌阳区', 327, N'德阳', N'jyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2787, N'广汉市', 327, N'德阳', N'ghs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2788, N'什邡市', 327, N'德阳', N'sfs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2789, N'绵竹市', 327, N'德阳', N'mzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2790, N'罗江县', 327, N'德阳', N'ljx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2791, N'中江县', 327, N'德阳', N'zjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2792, N'康定县', 328, N'甘孜', N'kdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2793, N'丹巴县', 328, N'甘孜', N'dbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2794, N'泸定县', 328, N'甘孜', N'ldx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2795, N'炉霍县', 328, N'甘孜', N'lhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2796, N'九龙县', 328, N'甘孜', N'jlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2797, N'甘孜县', 328, N'甘孜', N'gzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2798, N'雅江县', 328, N'甘孜', N'yjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2799, N'新龙县', 328, N'甘孜', N'xlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2800, N'道孚县', 328, N'甘孜', N'dfx', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2801, N'白玉县', 328, N'甘孜', N'byx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2802, N'理塘县', 328, N'甘孜', N'ltx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2803, N'德格县', 328, N'甘孜', N'dgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2804, N'乡城县', 328, N'甘孜', N'xcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2805, N'石渠县', 328, N'甘孜', N'sqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2806, N'稻城县', 328, N'甘孜', N'dcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2807, N'色达县', 328, N'甘孜', N'sdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2808, N'巴塘县', 328, N'甘孜', N'btx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2809, N'得荣县', 328, N'甘孜', N'drx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2810, N'广安区', 329, N'广安', N'gaq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2811, N'华蓥市', 329, N'广安', N'hys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2812, N'岳池县', 329, N'广安', N'ycx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2813, N'武胜县', 329, N'广安', N'wsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2814, N'邻水县', 329, N'广安', N'lsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2815, N'利州区', 330, N'广元', N'lzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2816, N'元坝区', 330, N'广元', N'ybq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2817, N'朝天区', 330, N'广元', N'ctq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2818, N'旺苍县', 330, N'广元', N'wcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2819, N'青川县', 330, N'广元', N'qcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2820, N'剑阁县', 330, N'广元', N'jgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2821, N'苍溪县', 330, N'广元', N'cxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2822, N'峨眉山市', 331, N'乐山', N'emss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2823, N'乐山市', 331, N'乐山', N'lss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2824, N'犍为县', 331, N'乐山', N'jwx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2825, N'井研县', 331, N'乐山', N'jyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2826, N'夹江县', 331, N'乐山', N'jjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2827, N'沐川县', 331, N'乐山', N'mcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2828, N'峨边', 331, N'乐山', N'eb', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2829, N'马边', 331, N'乐山', N'mb', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2830, N'西昌市', 332, N'凉山', N'xcs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2831, N'盐源县', 332, N'凉山', N'yyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2832, N'德昌县', 332, N'凉山', N'dcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2833, N'会理县', 332, N'凉山', N'hlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2834, N'会东县', 332, N'凉山', N'hdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2835, N'宁南县', 332, N'凉山', N'nnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2836, N'普格县', 332, N'凉山', N'pgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2837, N'布拖县', 332, N'凉山', N'btx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2838, N'金阳县', 332, N'凉山', N'jyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2839, N'昭觉县', 332, N'凉山', N'zjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2840, N'喜德县', 332, N'凉山', N'xdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2841, N'冕宁县', 332, N'凉山', N'mnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2842, N'越西县', 332, N'凉山', N'yxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2843, N'甘洛县', 332, N'凉山', N'glx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2844, N'美姑县', 332, N'凉山', N'mgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2845, N'雷波县', 332, N'凉山', N'lbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2846, N'木里', 332, N'凉山', N'ml', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2847, N'东坡区', 333, N'眉山', N'dpq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2848, N'仁寿县', 333, N'眉山', N'rsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2849, N'彭山县', 333, N'眉山', N'psx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2850, N'洪雅县', 333, N'眉山', N'hyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2851, N'丹棱县', 333, N'眉山', N'dlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2852, N'青神县', 333, N'眉山', N'qsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2853, N'阆中市', 334, N'南充', N'lzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2854, N'南部县', 334, N'南充', N'nbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2855, N'营山县', 334, N'南充', N'ysx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2856, N'蓬安县', 334, N'南充', N'pax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2857, N'仪陇县', 334, N'南充', N'ylx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2858, N'顺庆区', 334, N'南充', N'sqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2859, N'高坪区', 334, N'南充', N'gpq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2860, N'嘉陵区', 334, N'南充', N'jlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2861, N'西充县', 334, N'南充', N'xcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2862, N'市中区', 335, N'内江', N'szq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2863, N'东兴区', 335, N'内江', N'dxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2864, N'威远县', 335, N'内江', N'wyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2865, N'资中县', 335, N'内江', N'zzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2866, N'隆昌县', 335, N'内江', N'lcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2867, N'东  区', 336, N'攀枝花', N'dq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2868, N'西  区', 336, N'攀枝花', N'xq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2869, N'仁和区', 336, N'攀枝花', N'rhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2870, N'米易县', 336, N'攀枝花', N'myx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2871, N'盐边县', 336, N'攀枝花', N'ybx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2872, N'船山区', 337, N'遂宁', N'csq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2873, N'安居区', 337, N'遂宁', N'ajq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2874, N'蓬溪县', 337, N'遂宁', N'pxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2875, N'射洪县', 337, N'遂宁', N'shx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2876, N'大英县', 337, N'遂宁', N'dyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2877, N'雨城区', 338, N'雅安', N'ycq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2878, N'名山县', 338, N'雅安', N'msx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2879, N'荥经县', 338, N'雅安', N'yjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2880, N'汉源县', 338, N'雅安', N'hyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2881, N'石棉县', 338, N'雅安', N'smx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2882, N'天全县', 338, N'雅安', N'tqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2883, N'芦山县', 338, N'雅安', N'lsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2884, N'宝兴县', 338, N'雅安', N'bxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2885, N'翠屏区', 339, N'宜宾', N'cpq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2886, N'宜宾县', 339, N'宜宾', N'ybx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2887, N'南溪县', 339, N'宜宾', N'nxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2888, N'江安县', 339, N'宜宾', N'jax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2889, N'长宁县', 339, N'宜宾', N'cnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2890, N'高县', 339, N'宜宾', N'gx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2891, N'珙县', 339, N'宜宾', N'gx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2892, N'筠连县', 339, N'宜宾', N'jlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2893, N'兴文县', 339, N'宜宾', N'xwx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2894, N'屏山县', 339, N'宜宾', N'psx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2895, N'雁江区', 340, N'资阳', N'yjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2896, N'简阳市', 340, N'资阳', N'jys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2897, N'安岳县', 340, N'资阳', N'ayx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2898, N'乐至县', 340, N'资阳', N'lzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2899, N'大安区', 341, N'自贡', N'daq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2900, N'自流井区', 341, N'自贡', N'zljq', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2901, N'贡井区', 341, N'自贡', N'gjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2902, N'沿滩区', 341, N'自贡', N'ytq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2903, N'荣县', 341, N'自贡', N'rx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2904, N'富顺县', 341, N'自贡', N'fsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2905, N'江阳区', 342, N'泸州', N'jyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2906, N'纳溪区', 342, N'泸州', N'nxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2907, N'龙马潭区', 342, N'泸州', N'lmtq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2908, N'泸县', 342, N'泸州', N'lx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2909, N'合江县', 342, N'泸州', N'hjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2910, N'叙永县', 342, N'泸州', N'xyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2911, N'古蔺县', 342, N'泸州', N'glx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2912, N'和平区', 343, N'天津', N'hpq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2913, N'河西区', 343, N'天津', N'hxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2914, N'南开区', 343, N'天津', N'nkq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2915, N'河北区', 343, N'天津', N'hbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2916, N'河东区', 343, N'天津', N'hdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2917, N'红桥区', 343, N'天津', N'hqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2918, N'东丽区', 343, N'天津', N'dlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2919, N'津南区', 343, N'天津', N'jnq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2920, N'西青区', 343, N'天津', N'xqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2921, N'北辰区', 343, N'天津', N'bcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2922, N'塘沽区', 343, N'天津', N'tgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2923, N'汉沽区', 343, N'天津', N'hgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2924, N'大港区', 343, N'天津', N'dgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2925, N'武清区', 343, N'天津', N'wqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2926, N'宝坻区', 343, N'天津', N'bdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2927, N'经济开发区', 343, N'天津', N'jjkfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2928, N'宁河县', 343, N'天津', N'nhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2929, N'静海县', 343, N'天津', N'jhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2930, N'蓟县', 343, N'天津', N'jx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2931, N'城关区', 344, N'拉萨', N'cgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2932, N'林周县', 344, N'拉萨', N'lzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2933, N'当雄县', 344, N'拉萨', N'dxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2934, N'尼木县', 344, N'拉萨', N'nmx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2935, N'曲水县', 344, N'拉萨', N'qsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2936, N'堆龙德庆县', 344, N'拉萨', N'dldqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2937, N'达孜县', 344, N'拉萨', N'dzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2938, N'墨竹工卡县', 344, N'拉萨', N'mzgkx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2939, N'噶尔县', 345, N'阿里', N'gex', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2940, N'普兰县', 345, N'阿里', N'plx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2941, N'札达县', 345, N'阿里', N'zdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2942, N'日土县', 345, N'阿里', N'rtx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2943, N'革吉县', 345, N'阿里', N'gjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2944, N'改则县', 345, N'阿里', N'gzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2945, N'措勤县', 345, N'阿里', N'cqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2946, N'昌都县', 346, N'昌都', N'cdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2947, N'江达县', 346, N'昌都', N'jdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2948, N'贡觉县', 346, N'昌都', N'gjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2949, N'类乌齐县', 346, N'昌都', N'lwqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2950, N'丁青县', 346, N'昌都', N'dqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2951, N'察雅县', 346, N'昌都', N'cyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2952, N'八宿县', 346, N'昌都', N'bxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2953, N'左贡县', 346, N'昌都', N'zgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2954, N'芒康县', 346, N'昌都', N'mkx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2955, N'洛隆县', 346, N'昌都', N'llx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2956, N'边坝县', 346, N'昌都', N'bbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2957, N'林芝县', 347, N'林芝', N'lzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2958, N'工布江达县', 347, N'林芝', N'gbjdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2959, N'米林县', 347, N'林芝', N'mlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2960, N'墨脱县', 347, N'林芝', N'mtx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2961, N'波密县', 347, N'林芝', N'bmx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2962, N'察隅县', 347, N'林芝', N'cyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2963, N'朗县', 347, N'林芝', N'lx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2964, N'那曲县', 348, N'那曲', N'nqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2965, N'嘉黎县', 348, N'那曲', N'jlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2966, N'比如县', 348, N'那曲', N'brx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2967, N'聂荣县', 348, N'那曲', N'nrx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2968, N'安多县', 348, N'那曲', N'adx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2969, N'申扎县', 348, N'那曲', N'szx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2970, N'索县', 348, N'那曲', N'sx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2971, N'班戈县', 348, N'那曲', N'bgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2972, N'巴青县', 348, N'那曲', N'bqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2973, N'尼玛县', 348, N'那曲', N'nmx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2974, N'日喀则市', 349, N'日喀则', N'rkzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2975, N'南木林县', 349, N'日喀则', N'nmlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2976, N'江孜县', 349, N'日喀则', N'jzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2977, N'定日县', 349, N'日喀则', N'drx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2978, N'萨迦县', 349, N'日喀则', N'sjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2979, N'拉孜县', 349, N'日喀则', N'lzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2980, N'昂仁县', 349, N'日喀则', N'arx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2981, N'谢通门县', 349, N'日喀则', N'xtmx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2982, N'白朗县', 349, N'日喀则', N'blx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2983, N'仁布县', 349, N'日喀则', N'rbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2984, N'康马县', 349, N'日喀则', N'kmx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2985, N'定结县', 349, N'日喀则', N'djx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2986, N'仲巴县', 349, N'日喀则', N'zbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2987, N'亚东县', 349, N'日喀则', N'ydx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2988, N'吉隆县', 349, N'日喀则', N'jlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2989, N'聂拉木县', 349, N'日喀则', N'nlmx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2990, N'萨嘎县', 349, N'日喀则', N'sgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2991, N'岗巴县', 349, N'日喀则', N'gbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2992, N'乃东县', 350, N'山南', N'ndx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2993, N'扎囊县', 350, N'山南', N'znx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2994, N'贡嘎县', 350, N'山南', N'ggx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2995, N'桑日县', 350, N'山南', N'srx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2996, N'琼结县', 350, N'山南', N'qjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2997, N'曲松县', 350, N'山南', N'qsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2998, N'措美县', 350, N'山南', N'cmx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (2999, N'洛扎县', 350, N'山南', N'lzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3000, N'加查县', 350, N'山南', N'jcx', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3001, N'隆子县', 350, N'山南', N'lzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3002, N'错那县', 350, N'山南', N'cnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3003, N'浪卡子县', 350, N'山南', N'lkzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3004, N'天山区', 351, N'乌鲁木齐', N'tsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3005, N'沙依巴克区', 351, N'乌鲁木齐', N'sybkq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3006, N'新市区', 351, N'乌鲁木齐', N'xsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3007, N'水磨沟区', 351, N'乌鲁木齐', N'smgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3008, N'头屯河区', 351, N'乌鲁木齐', N'tthq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3009, N'达坂城区', 351, N'乌鲁木齐', N'dbcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3010, N'米东区', 351, N'乌鲁木齐', N'mdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3011, N'乌鲁木齐县', 351, N'乌鲁木齐', N'wlmqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3012, N'阿克苏市', 352, N'阿克苏', N'akss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3013, N'温宿县', 352, N'阿克苏', N'wxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3014, N'库车县', 352, N'阿克苏', N'kcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3015, N'沙雅县', 352, N'阿克苏', N'syx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3016, N'新和县', 352, N'阿克苏', N'xhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3017, N'拜城县', 352, N'阿克苏', N'bcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3018, N'乌什县', 352, N'阿克苏', N'wsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3019, N'阿瓦提县', 352, N'阿克苏', N'awtx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3020, N'柯坪县', 352, N'阿克苏', N'kpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3021, N'阿拉尔市', 353, N'阿拉尔', N'ales', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3022, N'库尔勒市', 354, N'巴音郭楞', N'kels', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3023, N'轮台县', 354, N'巴音郭楞', N'ltx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3024, N'尉犁县', 354, N'巴音郭楞', N'wlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3025, N'若羌县', 354, N'巴音郭楞', N'rqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3026, N'且末县', 354, N'巴音郭楞', N'qmx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3027, N'焉耆', 354, N'巴音郭楞', N'yq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3028, N'和静县', 354, N'巴音郭楞', N'hjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3029, N'和硕县', 354, N'巴音郭楞', N'hsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3030, N'博湖县', 354, N'巴音郭楞', N'bhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3031, N'博乐市', 355, N'博尔塔拉', N'bls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3032, N'精河县', 355, N'博尔塔拉', N'jhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3033, N'温泉县', 355, N'博尔塔拉', N'wqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3034, N'呼图壁县', 356, N'昌吉', N'htbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3035, N'米泉市', 356, N'昌吉', N'mqs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3036, N'昌吉市', 356, N'昌吉', N'cjs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3037, N'阜康市', 356, N'昌吉', N'fks', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3038, N'玛纳斯县', 356, N'昌吉', N'mnsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3039, N'奇台县', 356, N'昌吉', N'qtx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3040, N'吉木萨尔县', 356, N'昌吉', N'jmsex', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3041, N'木垒', 356, N'昌吉', N'ml', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3042, N'哈密市', 357, N'哈密', N'hms', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3043, N'伊吾县', 357, N'哈密', N'ywx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3044, N'巴里坤', 357, N'哈密', N'blk', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3045, N'和田市', 358, N'和田', N'hts', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3046, N'和田县', 358, N'和田', N'htx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3047, N'墨玉县', 358, N'和田', N'myx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3048, N'皮山县', 358, N'和田', N'psx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3049, N'洛浦县', 358, N'和田', N'lpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3050, N'策勒县', 358, N'和田', N'clx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3051, N'于田县', 358, N'和田', N'ytx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3052, N'民丰县', 358, N'和田', N'mfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3053, N'喀什市', 359, N'喀什', N'kss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3054, N'疏附县', 359, N'喀什', N'sfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3055, N'疏勒县', 359, N'喀什', N'slx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3056, N'英吉沙县', 359, N'喀什', N'yjsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3057, N'泽普县', 359, N'喀什', N'zpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3058, N'莎车县', 359, N'喀什', N'scx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3059, N'叶城县', 359, N'喀什', N'ycx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3060, N'麦盖提县', 359, N'喀什', N'mgtx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3061, N'岳普湖县', 359, N'喀什', N'yphx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3062, N'伽师县', 359, N'喀什', N'gsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3063, N'巴楚县', 359, N'喀什', N'bcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3064, N'塔什库尔干', 359, N'喀什', N'tskeg', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3065, N'克拉玛依市', 360, N'克拉玛依', N'klmys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3066, N'阿图什市', 361, N'克孜勒苏', N'atss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3067, N'阿克陶县', 361, N'克孜勒苏', N'aktx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3068, N'阿合奇县', 361, N'克孜勒苏', N'ahqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3069, N'乌恰县', 361, N'克孜勒苏', N'wqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3070, N'石河子市', 362, N'石河子', N'shzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3071, N'图木舒克市', 363, N'图木舒克', N'tmsks', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3072, N'吐鲁番市', 364, N'吐鲁番', N'tlfs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3073, N'鄯善县', 364, N'吐鲁番', N'ssx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3074, N'托克逊县', 364, N'吐鲁番', N'tkxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3075, N'五家渠市', 365, N'五家渠', N'wjqs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3076, N'阿勒泰市', 366, N'伊犁', N'alts', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3077, N'布克赛尔', 366, N'伊犁', N'bkse', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3078, N'伊宁市', 366, N'伊犁', N'yns', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3079, N'布尔津县', 366, N'伊犁', N'bejx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3080, N'奎屯市', 366, N'伊犁', N'kts', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3081, N'乌苏市', 366, N'伊犁', N'wss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3082, N'额敏县', 366, N'伊犁', N'emx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3083, N'富蕴县', 366, N'伊犁', N'fyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3084, N'伊宁县', 366, N'伊犁', N'ynx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3085, N'福海县', 366, N'伊犁', N'fhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3086, N'霍城县', 366, N'伊犁', N'hcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3087, N'沙湾县', 366, N'伊犁', N'swx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3088, N'巩留县', 366, N'伊犁', N'glx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3089, N'哈巴河县', 366, N'伊犁', N'hbhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3090, N'托里县', 366, N'伊犁', N'tlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3091, N'青河县', 366, N'伊犁', N'qhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3092, N'新源县', 366, N'伊犁', N'xyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3093, N'裕民县', 366, N'伊犁', N'ymx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3094, N'和布克赛尔', 366, N'伊犁', N'hbkse', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3095, N'吉木乃县', 366, N'伊犁', N'jmnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3096, N'昭苏县', 366, N'伊犁', N'zsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3097, N'特克斯县', 366, N'伊犁', N'tksx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3098, N'尼勒克县', 366, N'伊犁', N'nlkx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3099, N'察布查尔', 366, N'伊犁', N'cbce', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3100, N'盘龙区', 367, N'昆明', N'plq', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3101, N'五华区', 367, N'昆明', N'whq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3102, N'官渡区', 367, N'昆明', N'gdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3103, N'西山区', 367, N'昆明', N'xsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3104, N'东川区', 367, N'昆明', N'dcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3105, N'安宁市', 367, N'昆明', N'ans', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3106, N'呈贡县', 367, N'昆明', N'cgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3107, N'晋宁县', 367, N'昆明', N'jnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3108, N'富民县', 367, N'昆明', N'fmx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3109, N'宜良县', 367, N'昆明', N'ylx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3110, N'嵩明县', 367, N'昆明', N'smx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3111, N'石林县', 367, N'昆明', N'slx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3112, N'禄劝', 367, N'昆明', N'lq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3113, N'寻甸', 367, N'昆明', N'xd', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3114, N'兰坪', 368, N'怒江', N'lp', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3115, N'泸水县', 368, N'怒江', N'lsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3116, N'福贡县', 368, N'怒江', N'fgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3117, N'贡山', 368, N'怒江', N'gs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3118, N'宁洱', 369, N'普洱', N'ne', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3119, N'思茅区', 369, N'普洱', N'smq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3120, N'墨江', 369, N'普洱', N'mj', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3121, N'景东', 369, N'普洱', N'jd', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3122, N'景谷', 369, N'普洱', N'jg', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3123, N'镇沅', 369, N'普洱', N'zy', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3124, N'江城', 369, N'普洱', N'jc', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3125, N'孟连', 369, N'普洱', N'ml', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3126, N'澜沧', 369, N'普洱', N'lc', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3127, N'西盟', 369, N'普洱', N'xm', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3128, N'古城区', 370, N'丽江', N'gcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3129, N'宁蒗', 370, N'丽江', N'nl', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3130, N'玉龙', 370, N'丽江', N'yl', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3131, N'永胜县', 370, N'丽江', N'ysx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3132, N'华坪县', 370, N'丽江', N'hpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3133, N'隆阳区', 371, N'保山', N'lyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3134, N'施甸县', 371, N'保山', N'sdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3135, N'腾冲县', 371, N'保山', N'tcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3136, N'龙陵县', 371, N'保山', N'llx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3137, N'昌宁县', 371, N'保山', N'cnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3138, N'楚雄市', 372, N'楚雄', N'cxs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3139, N'双柏县', 372, N'楚雄', N'sbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3140, N'牟定县', 372, N'楚雄', N'mdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3141, N'南华县', 372, N'楚雄', N'nhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3142, N'姚安县', 372, N'楚雄', N'yax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3143, N'大姚县', 372, N'楚雄', N'dyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3144, N'永仁县', 372, N'楚雄', N'yrx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3145, N'元谋县', 372, N'楚雄', N'ymx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3146, N'武定县', 372, N'楚雄', N'wdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3147, N'禄丰县', 372, N'楚雄', N'lfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3148, N'大理市', 373, N'大理', N'dls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3149, N'祥云县', 373, N'大理', N'xyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3150, N'宾川县', 373, N'大理', N'bcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3151, N'弥渡县', 373, N'大理', N'mdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3152, N'永平县', 373, N'大理', N'ypx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3153, N'云龙县', 373, N'大理', N'ylx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3154, N'洱源县', 373, N'大理', N'eyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3155, N'剑川县', 373, N'大理', N'jcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3156, N'鹤庆县', 373, N'大理', N'hqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3157, N'漾濞', 373, N'大理', N'yb', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3158, N'南涧', 373, N'大理', N'nj', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3159, N'巍山', 373, N'大理', N'ws', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3160, N'潞西市', 374, N'德宏', N'lxs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3161, N'瑞丽市', 374, N'德宏', N'rls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3162, N'梁河县', 374, N'德宏', N'lhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3163, N'盈江县', 374, N'德宏', N'yjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3164, N'陇川县', 374, N'德宏', N'lcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3165, N'香格里拉县', 375, N'迪庆', N'xgllx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3166, N'德钦县', 375, N'迪庆', N'dqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3167, N'维西', 375, N'迪庆', N'wx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3168, N'泸西县', 376, N'红河', N'lxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3169, N'蒙自县', 376, N'红河', N'mzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3170, N'个旧市', 376, N'红河', N'gjs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3171, N'开远市', 376, N'红河', N'kys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3172, N'绿春县', 376, N'红河', N'lcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3173, N'建水县', 376, N'红河', N'jsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3174, N'石屏县', 376, N'红河', N'spx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3175, N'弥勒县', 376, N'红河', N'mlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3176, N'元阳县', 376, N'红河', N'yyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3177, N'红河县', 376, N'红河', N'hhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3178, N'金平', 376, N'红河', N'jp', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3179, N'河口', 376, N'红河', N'hk', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3180, N'屏边', 376, N'红河', N'pb', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3181, N'临翔区', 377, N'临沧', N'lxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3182, N'凤庆县', 377, N'临沧', N'fqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3183, N'云县', 377, N'临沧', N'yx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3184, N'永德县', 377, N'临沧', N'ydx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3185, N'镇康县', 377, N'临沧', N'zkx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3186, N'双江', 377, N'临沧', N'sj', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3187, N'耿马', 377, N'临沧', N'gm', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3188, N'沧源', 377, N'临沧', N'cy', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3189, N'麒麟区', 378, N'曲靖', N'qlq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3190, N'宣威市', 378, N'曲靖', N'xws', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3191, N'马龙县', 378, N'曲靖', N'mlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3192, N'陆良县', 378, N'曲靖', N'llx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3193, N'师宗县', 378, N'曲靖', N'szx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3194, N'罗平县', 378, N'曲靖', N'lpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3195, N'富源县', 378, N'曲靖', N'fyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3196, N'会泽县', 378, N'曲靖', N'hzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3197, N'沾益县', 378, N'曲靖', N'zyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3198, N'文山县', 379, N'文山', N'wsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3199, N'砚山县', 379, N'文山', N'ysx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3200, N'西畴县', 379, N'文山', N'xcx', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3201, N'麻栗坡县', 379, N'文山', N'mlpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3202, N'马关县', 379, N'文山', N'mgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3203, N'丘北县', 379, N'文山', N'qbx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3204, N'广南县', 379, N'文山', N'gnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3205, N'富宁县', 379, N'文山', N'fnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3206, N'景洪市', 380, N'西双版纳', N'jhs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3207, N'勐海县', 380, N'西双版纳', N'mhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3208, N'勐腊县', 380, N'西双版纳', N'mlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3209, N'红塔区', 381, N'玉溪', N'htq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3210, N'江川县', 381, N'玉溪', N'jcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3211, N'澄江县', 381, N'玉溪', N'cjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3212, N'通海县', 381, N'玉溪', N'thx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3213, N'华宁县', 381, N'玉溪', N'hnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3214, N'易门县', 381, N'玉溪', N'ymx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3215, N'峨山', 381, N'玉溪', N'es', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3216, N'新平', 381, N'玉溪', N'xp', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3217, N'元江', 381, N'玉溪', N'yj', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3218, N'昭阳区', 382, N'昭通', N'zyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3219, N'鲁甸县', 382, N'昭通', N'ldx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3220, N'巧家县', 382, N'昭通', N'qjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3221, N'盐津县', 382, N'昭通', N'yjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3222, N'大关县', 382, N'昭通', N'dgx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3223, N'永善县', 382, N'昭通', N'ysx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3224, N'绥江县', 382, N'昭通', N'sjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3225, N'镇雄县', 382, N'昭通', N'zxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3226, N'彝良县', 382, N'昭通', N'ylx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3227, N'威信县', 382, N'昭通', N'wxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3228, N'水富县', 382, N'昭通', N'sfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3229, N'西湖区', 383, N'杭州', N'xhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3230, N'上城区', 383, N'杭州', N'scq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3231, N'下城区', 383, N'杭州', N'xcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3232, N'拱墅区', 383, N'杭州', N'gsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3233, N'滨江区', 383, N'杭州', N'bjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3234, N'江干区', 383, N'杭州', N'jgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3235, N'萧山区', 383, N'杭州', N'xsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3236, N'余杭区', 383, N'杭州', N'yhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3237, N'市郊', 383, N'杭州', N'sj', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3238, N'建德市', 383, N'杭州', N'jds', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3239, N'富阳市', 383, N'杭州', N'fys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3240, N'临安市', 383, N'杭州', N'las', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3241, N'桐庐县', 383, N'杭州', N'tlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3242, N'淳安县', 383, N'杭州', N'cax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3243, N'吴兴区', 384, N'湖州', N'wxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3244, N'南浔区', 384, N'湖州', N'nxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3245, N'德清县', 384, N'湖州', N'dqx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3246, N'长兴县', 384, N'湖州', N'cxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3247, N'安吉县', 384, N'湖州', N'ajx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3248, N'南湖区', 385, N'嘉兴', N'nhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3249, N'秀洲区', 385, N'嘉兴', N'xzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3250, N'海宁市', 385, N'嘉兴', N'hns', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3251, N'嘉善县', 385, N'嘉兴', N'jsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3252, N'平湖市', 385, N'嘉兴', N'phs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3253, N'桐乡市', 385, N'嘉兴', N'txs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3254, N'海盐县', 385, N'嘉兴', N'hyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3255, N'婺城区', 386, N'金华', N'wcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3256, N'金东区', 386, N'金华', N'jdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3257, N'兰溪市', 386, N'金华', N'lxs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3258, N'市区', 386, N'金华', N'sq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3259, N'佛堂镇', 386, N'金华', N'tz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3260, N'上溪镇', 386, N'金华', N'sxz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3261, N'义亭镇', 386, N'金华', N'ytz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3262, N'大陈镇', 386, N'金华', N'dcz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3263, N'苏溪镇', 386, N'金华', N'sxz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3264, N'赤岸镇', 386, N'金华', N'caz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3265, N'东阳市', 386, N'金华', N'dys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3266, N'永康市', 386, N'金华', N'yks', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3267, N'武义县', 386, N'金华', N'wyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3268, N'浦江县', 386, N'金华', N'pjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3269, N'磐安县', 386, N'金华', N'pax', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3270, N'莲都区', 387, N'丽水', N'ldq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3271, N'龙泉市', 387, N'丽水', N'lqs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3272, N'青田县', 387, N'丽水', N'qtx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3273, N'缙云县', 387, N'丽水', N'jyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3274, N'遂昌县', 387, N'丽水', N'scx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3275, N'松阳县', 387, N'丽水', N'syx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3276, N'云和县', 387, N'丽水', N'yhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3277, N'庆元县', 387, N'丽水', N'qyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3278, N'景宁', 387, N'丽水', N'jn', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3279, N'海曙区', 388, N'宁波', N'hsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3280, N'江东区', 388, N'宁波', N'jdq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3281, N'江北区', 388, N'宁波', N'jbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3282, N'镇海区', 388, N'宁波', N'zhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3283, N'北仑区', 388, N'宁波', N'blq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3284, N'鄞州区', 388, N'宁波', N'yzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3285, N'余姚市', 388, N'宁波', N'yys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3286, N'慈溪市', 388, N'宁波', N'cxs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3287, N'奉化市', 388, N'宁波', N'fhs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3288, N'象山县', 388, N'宁波', N'xsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3289, N'宁海县', 388, N'宁波', N'nhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3290, N'越城区', 389, N'绍兴', N'ycq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3291, N'上虞市', 389, N'绍兴', N'sys', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3292, N'嵊州市', 389, N'绍兴', N'szs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3293, N'绍兴县', 389, N'绍兴', N'sxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3294, N'新昌县', 389, N'绍兴', N'xcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3295, N'诸暨市', 389, N'绍兴', N'zjs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3296, N'椒江区', 390, N'台州', N'jjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3297, N'黄岩区', 390, N'台州', N'hyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3298, N'路桥区', 390, N'台州', N'lqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3299, N'温岭市', 390, N'台州', N'wls', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3300, N'临海市', 390, N'台州', N'lhs', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3301, N'玉环县', 390, N'台州', N'yhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3302, N'三门县', 390, N'台州', N'smx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3303, N'天台县', 390, N'台州', N'ttx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3304, N'仙居县', 390, N'台州', N'xjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3305, N'鹿城区', 391, N'温州', N'lcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3306, N'龙湾区', 391, N'温州', N'lwq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3307, N'瓯海区', 391, N'温州', N'ohq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3308, N'瑞安市', 391, N'温州', N'ras', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3309, N'乐清市', 391, N'温州', N'lqs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3310, N'洞头县', 391, N'温州', N'dtx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3311, N'永嘉县', 391, N'温州', N'yjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3312, N'平阳县', 391, N'温州', N'pyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3313, N'苍南县', 391, N'温州', N'cnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3314, N'文成县', 391, N'温州', N'wcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3315, N'泰顺县', 391, N'温州', N'tsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3316, N'定海区', 392, N'舟山', N'dhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3317, N'普陀区', 392, N'舟山', N'ptq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3318, N'岱山县', 392, N'舟山', N'dsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3319, N'嵊泗县', 392, N'舟山', N'ssx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3320, N'衢州市', 393, N'衢州', N'qzs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3321, N'江山市', 393, N'衢州', N'jss', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3322, N'常山县', 393, N'衢州', N'csx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3323, N'开化县', 393, N'衢州', N'khx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3324, N'龙游县', 393, N'衢州', N'lyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3325, N'合川区', 394, N'重庆', N'hcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3326, N'江津区', 394, N'重庆', N'jjq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3327, N'南川区', 394, N'重庆', N'ncq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3328, N'永川区', 394, N'重庆', N'ycq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3329, N'南岸区', 394, N'重庆', N'naq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3330, N'渝北区', 394, N'重庆', N'ybq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3331, N'万盛区', 394, N'重庆', N'wsq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3332, N'大渡口区', 394, N'重庆', N'ddkq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3333, N'万州区', 394, N'重庆', N'wzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3334, N'北碚区', 394, N'重庆', N'bbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3335, N'沙坪坝区', 394, N'重庆', N'spbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3336, N'巴南区', 394, N'重庆', N'bnq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3337, N'涪陵区', 394, N'重庆', N'flq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3338, N'江北区', 394, N'重庆', N'jbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3339, N'九龙坡区', 394, N'重庆', N'jlpq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3340, N'渝中区', 394, N'重庆', N'yzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3341, N'黔江开发区', 394, N'重庆', N'qjkfq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3342, N'长寿区', 394, N'重庆', N'csq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3343, N'双桥区', 394, N'重庆', N'sqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3344, N'綦江县', 394, N'重庆', N'qjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3345, N'潼南县', 394, N'重庆', N'tnx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3346, N'铜梁县', 394, N'重庆', N'tlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3347, N'大足县', 394, N'重庆', N'dzx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3348, N'荣昌县', 394, N'重庆', N'rcx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3349, N'璧山县', 394, N'重庆', N'bsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3350, N'垫江县', 394, N'重庆', N'djx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3351, N'武隆县', 394, N'重庆', N'wlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3352, N'丰都县', 394, N'重庆', N'fdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3353, N'城口县', 394, N'重庆', N'ckx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3354, N'梁平县', 394, N'重庆', N'lpx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3355, N'开县', 394, N'重庆', N'kx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3356, N'巫溪县', 394, N'重庆', N'wxx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3357, N'巫山县', 394, N'重庆', N'wsx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3358, N'奉节县', 394, N'重庆', N'fjx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3359, N'云阳县', 394, N'重庆', N'yyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3360, N'忠县', 394, N'重庆', N'zx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3361, N'石柱', 394, N'重庆', N'sz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3362, N'彭水', 394, N'重庆', N'ps', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3363, N'酉阳', 394, N'重庆', N'yy', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3364, N'秀山', 394, N'重庆', N'xs', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3365, N'沙田区', 395, N'香港', N'stq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3366, N'东区', 395, N'香港', N'dq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3367, N'观塘区', 395, N'香港', N'gtq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3368, N'黄大仙区', 395, N'香港', N'hdxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3369, N'九龙城区', 395, N'香港', N'jlcq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3370, N'屯门区', 395, N'香港', N'tmq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3371, N'葵青区', 395, N'香港', N'kqq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3372, N'元朗区', 395, N'香港', N'ylq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3373, N'深水埗区', 395, N'香港', N'ssbq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3374, N'西贡区', 395, N'香港', N'xgq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3375, N'大埔区', 395, N'香港', N'dpq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3376, N'湾仔区', 395, N'香港', N'wzq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3377, N'油尖旺区', 395, N'香港', N'yjwq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3378, N'北区', 395, N'香港', N'bq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3379, N'南区', 395, N'香港', N'nq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3380, N'荃湾区', 395, N'香港', N'qwq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3381, N'中西区', 395, N'香港', N'zxq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3382, N'离岛区', 395, N'香港', N'ldq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3383, N'澳门', 396, N'澳门', N'am', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3384, N'台北', 397, N'台湾', N'tb', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3385, N'高雄', 397, N'台湾', N'gx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3386, N'基隆', 397, N'台湾', N'jl', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3387, N'台中', 397, N'台湾', N'tz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3388, N'台南', 397, N'台湾', N'tn', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3389, N'新竹', 397, N'台湾', N'xz', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3390, N'嘉义', 397, N'台湾', N'jy', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3391, N'宜兰县', 397, N'台湾', N'ylx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3392, N'桃园县', 397, N'台湾', N'tyx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3393, N'苗栗县', 397, N'台湾', N'mlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3394, N'彰化县', 397, N'台湾', N'zhx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3395, N'南投县', 397, N'台湾', N'ntx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3396, N'云林县', 397, N'台湾', N'ylx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3397, N'屏东县', 397, N'台湾', N'pdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3398, N'台东县', 397, N'台湾', N'tdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3399, N'花莲县', 397, N'台湾', N'hlx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3400, N'澎湖县', 397, N'台湾', N'phx', 3)
GO
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3401, N'合肥', 3, N'安徽', N'hf', 2)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3402, N'庐阳区', 3401, N'合肥', N'lyq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3403, N'瑶海区', 3401, N'合肥', N'yhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3404, N'蜀山区', 3401, N'合肥', N'ssq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3405, N'包河区', 3401, N'合肥', N'bhq', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3406, N'长丰县', 3401, N'合肥', N'cfx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3407, N'肥东县', 3401, N'合肥', N'fdx', 3)
INSERT [dbo].[RegionInfos] ([RegionId], [RegionName], [ParentId], [ParentName], [RegionPYNo], [RegionLevel]) VALUES (3408, N'肥西县', 3401, N'合肥', N'fxx', 3)
SET IDENTITY_INSERT [dbo].[RememberedRecords] ON 

INSERT [dbo].[RememberedRecords] ([Id], [LoginIP], [UserName], [UserRealPwd], [ReOrder]) VALUES (1, N'192.168.0.103', N'admin', N'admin1', 1)
INSERT [dbo].[RememberedRecords] ([Id], [LoginIP], [UserName], [UserRealPwd], [ReOrder]) VALUES (2, N'192.168.0.103', N'lyc005', N'1234', 2)
INSERT [dbo].[RememberedRecords] ([Id], [LoginIP], [UserName], [UserRealPwd], [ReOrder]) VALUES (3, N'192.168.0.101', N'admin', N'admin1', 1)
INSERT [dbo].[RememberedRecords] ([Id], [LoginIP], [UserName], [UserRealPwd], [ReOrder]) VALUES (4, N'', N'admin', N'admin1', 1)
INSERT [dbo].[RememberedRecords] ([Id], [LoginIP], [UserName], [UserRealPwd], [ReOrder]) VALUES (5, N'192.168.0.102', N'admin', N'admin', 1)
INSERT [dbo].[RememberedRecords] ([Id], [LoginIP], [UserName], [UserRealPwd], [ReOrder]) VALUES (6, N'192.168.0.102', N'lyc005', N'1234', 2)
SET IDENTITY_INSERT [dbo].[RememberedRecords] OFF
SET IDENTITY_INSERT [dbo].[RoleInfos] ON 

INSERT [dbo].[RoleInfos] ([RoleId], [RoleName], [Remark], [IsAdmin], [IsDeleted], [Creator], [CreateTime]) VALUES (1, N'超级管理员', N'拥有所有操作权限，拥有一切权力。', 1, 0, N'admin', CAST(N'2020-02-07 15:18:29.930' AS DateTime))
INSERT [dbo].[RoleInfos] ([RoleId], [RoleName], [Remark], [IsAdmin], [IsDeleted], [Creator], [CreateTime]) VALUES (2, N'系统管理员', N'主要负责系统管理模块功能。', 0, 0, N'admin', CAST(N'2020-02-10 18:33:24.183' AS DateTime))
INSERT [dbo].[RoleInfos] ([RoleId], [RoleName], [Remark], [IsAdmin], [IsDeleted], [Creator], [CreateTime]) VALUES (4, N'采购员', N'进行采购工作。', 0, 1, N'admin', CAST(N'2020-03-06 15:36:55.717' AS DateTime))
INSERT [dbo].[RoleInfos] ([RoleId], [RoleName], [Remark], [IsAdmin], [IsDeleted], [Creator], [CreateTime]) VALUES (6, N'采购员', N'负责产品采购工作。', 0, 0, N'admin', CAST(N'2020-04-01 15:47:54.647' AS DateTime))
INSERT [dbo].[RoleInfos] ([RoleId], [RoleName], [Remark], [IsAdmin], [IsDeleted], [Creator], [CreateTime]) VALUES (7, N'销售员', N'负责销售工作，还有一些业务处理。。。。', 0, 0, N'admin', CAST(N'2020-06-24 10:29:48.417' AS DateTime))
INSERT [dbo].[RoleInfos] ([RoleId], [RoleName], [Remark], [IsAdmin], [IsDeleted], [Creator], [CreateTime]) VALUES (9, N'业务员', N'负责业务一切事务。还有一些另外的事务。', 0, 0, N'admin', CAST(N'2021-01-20 09:18:39.223' AS DateTime))
INSERT [dbo].[RoleInfos] ([RoleId], [RoleName], [Remark], [IsAdmin], [IsDeleted], [Creator], [CreateTime]) VALUES (10, N'仓库管理员', N'管理仓库一切事务', 0, 0, N'admin', CAST(N'2021-03-10 21:48:41.417' AS DateTime))
SET IDENTITY_INSERT [dbo].[RoleInfos] OFF
SET IDENTITY_INSERT [dbo].[RoleMenuInfos] ON 

INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (228, 2, 1, N'admin', CAST(N'2020-06-24 10:13:30.760' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (229, 2, 7, N'admin', CAST(N'2020-06-24 10:13:30.770' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (230, 2, 8, N'admin', CAST(N'2020-06-24 10:13:30.780' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (232, 2, 10, N'admin', CAST(N'2020-06-24 10:13:30.793' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (233, 2, 11, N'admin', CAST(N'2020-06-24 10:13:30.803' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (234, 2, 13, N'admin', CAST(N'2020-06-24 10:13:30.810' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (235, 2, 2, N'admin', CAST(N'2020-06-24 10:13:30.817' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (236, 2, 15, N'admin', CAST(N'2020-06-24 10:13:30.823' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (237, 2, 16, N'admin', CAST(N'2020-06-24 10:13:30.833' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (238, 2, 17, N'admin', CAST(N'2020-06-24 10:13:30.840' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (239, 2, 18, N'admin', CAST(N'2020-06-24 10:13:30.850' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (240, 2, 19, N'admin', CAST(N'2020-06-24 10:13:30.857' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (241, 2, 20, N'admin', CAST(N'2020-06-24 10:13:30.863' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (242, 2, 34, N'admin', CAST(N'2020-06-24 10:13:30.870' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (243, 2, 39, N'admin', CAST(N'2020-06-24 10:13:30.880' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (250, 2, 6, N'admin', CAST(N'2020-06-24 10:13:30.933' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (255, 2, 37, N'admin', CAST(N'2020-07-08 22:24:20.750' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (256, 2, 38, N'admin', CAST(N'2020-07-08 22:24:53.280' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (259, 6, 1, N'admin', CAST(N'2021-01-24 19:10:07.733' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (260, 6, 10, N'admin', CAST(N'2021-01-24 19:10:07.740' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (261, 6, 4, N'admin', CAST(N'2021-01-24 19:10:07.750' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (262, 6, 21, N'admin', CAST(N'2021-01-24 19:10:07.760' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (263, 6, 5, N'admin', CAST(N'2021-01-24 19:10:07.767' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (264, 6, 23, N'admin', CAST(N'2021-01-24 19:10:07.777' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (265, 6, 26, N'admin', CAST(N'2021-01-24 19:10:07.783' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (266, 6, 27, N'admin', CAST(N'2021-01-24 19:10:07.790' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (267, 6, 28, N'admin', CAST(N'2021-01-24 19:10:07.800' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (268, 6, 6, N'admin', CAST(N'2021-01-24 19:10:07.810' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (269, 2, 9, N'admin', CAST(N'2021-03-03 21:13:06.863' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (270, 2, 42, N'admin', CAST(N'2021-03-03 21:13:06.863' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (271, 10, 1, N'admin', CAST(N'2021-03-10 21:50:44.793' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (272, 10, 10, N'admin', CAST(N'2021-03-10 21:50:44.803' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (273, 10, 2, N'admin', CAST(N'2021-03-10 21:50:44.817' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (274, 10, 17, N'admin', CAST(N'2021-03-10 21:50:44.830' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (275, 10, 20, N'admin', CAST(N'2021-03-10 21:50:44.840' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (276, 10, 4, N'admin', CAST(N'2021-03-10 21:50:44.853' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (277, 10, 31, N'admin', CAST(N'2021-03-10 21:50:44.863' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (278, 10, 5, N'admin', CAST(N'2021-03-10 21:50:44.877' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (279, 10, 25, N'admin', CAST(N'2021-03-10 21:50:44.890' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (280, 10, 35, N'admin', CAST(N'2021-03-10 21:50:44.903' AS DateTime), 0)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MId], [Creator], [CreateTime], [IsDeleted]) VALUES (281, 10, 6, N'admin', CAST(N'2021-03-10 21:50:44.917' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[RoleMenuInfos] OFF
SET IDENTITY_INSERT [dbo].[RoleTMenuInfos] ON 

INSERT [dbo].[RoleTMenuInfos] ([RTMenuId], [RoleId], [TMenuId], [Creator], [CreateTime], [IsDeleted]) VALUES (28, 2, 6, N'admin', CAST(N'2020-06-24 10:13:30.957' AS DateTime), 0)
INSERT [dbo].[RoleTMenuInfos] ([RTMenuId], [RoleId], [TMenuId], [Creator], [CreateTime], [IsDeleted]) VALUES (29, 2, 1, N'admin', CAST(N'2021-03-03 21:14:01.283' AS DateTime), 0)
INSERT [dbo].[RoleTMenuInfos] ([RTMenuId], [RoleId], [TMenuId], [Creator], [CreateTime], [IsDeleted]) VALUES (30, 2, 5, N'admin', CAST(N'2021-03-03 21:14:01.283' AS DateTime), 0)
INSERT [dbo].[RoleTMenuInfos] ([RTMenuId], [RoleId], [TMenuId], [Creator], [CreateTime], [IsDeleted]) VALUES (31, 2, 7, N'admin', CAST(N'2021-03-03 21:14:01.283' AS DateTime), 0)
INSERT [dbo].[RoleTMenuInfos] ([RTMenuId], [RoleId], [TMenuId], [Creator], [CreateTime], [IsDeleted]) VALUES (32, 2, 10, N'admin', CAST(N'2021-03-03 21:14:01.283' AS DateTime), 0)
INSERT [dbo].[RoleTMenuInfos] ([RTMenuId], [RoleId], [TMenuId], [Creator], [CreateTime], [IsDeleted]) VALUES (33, 10, 4, N'admin', CAST(N'2021-03-10 21:50:44.940' AS DateTime), 0)
INSERT [dbo].[RoleTMenuInfos] ([RTMenuId], [RoleId], [TMenuId], [Creator], [CreateTime], [IsDeleted]) VALUES (34, 10, 6, N'admin', CAST(N'2021-03-10 21:50:44.950' AS DateTime), 0)
INSERT [dbo].[RoleTMenuInfos] ([RTMenuId], [RoleId], [TMenuId], [Creator], [CreateTime], [IsDeleted]) VALUES (35, 10, 8, N'admin', CAST(N'2021-03-10 21:50:44.963' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[RoleTMenuInfos] OFF
SET IDENTITY_INSERT [dbo].[SaleGoodsInfos] ON 

INSERT [dbo].[SaleGoodsInfos] ([SaleGoodsId], [SaleId], [GoodsId], [GUnit], [Count], [SalePrice], [Amount], [Remark], [IsDeleted]) VALUES (1, 1, 1, N'箱', 30, CAST(50.00 AS Decimal(18, 2)), CAST(1500.00 AS Decimal(18, 2)), N'', 0)
INSERT [dbo].[SaleGoodsInfos] ([SaleGoodsId], [SaleId], [GoodsId], [GUnit], [Count], [SalePrice], [Amount], [Remark], [IsDeleted]) VALUES (2, 2, 2, N'袋', 500, CAST(5.00 AS Decimal(18, 2)), CAST(2500.00 AS Decimal(18, 2)), N'', 0)
INSERT [dbo].[SaleGoodsInfos] ([SaleGoodsId], [SaleId], [GoodsId], [GUnit], [Count], [SalePrice], [Amount], [Remark], [IsDeleted]) VALUES (3, 2, 1, N'箱', 50, CAST(56.00 AS Decimal(18, 2)), CAST(2800.00 AS Decimal(18, 2)), N'', 0)
INSERT [dbo].[SaleGoodsInfos] ([SaleGoodsId], [SaleId], [GoodsId], [GUnit], [Count], [SalePrice], [Amount], [Remark], [IsDeleted]) VALUES (4, 4, 1, N'箱', 10, CAST(49.00 AS Decimal(18, 2)), CAST(490.00 AS Decimal(18, 2)), N'', 0)
INSERT [dbo].[SaleGoodsInfos] ([SaleGoodsId], [SaleId], [GoodsId], [GUnit], [Count], [SalePrice], [Amount], [Remark], [IsDeleted]) VALUES (6, 5, 2, N'袋', 300, CAST(3.50 AS Decimal(18, 2)), CAST(1050.00 AS Decimal(18, 2)), N'', 0)
INSERT [dbo].[SaleGoodsInfos] ([SaleGoodsId], [SaleId], [GoodsId], [GUnit], [Count], [SalePrice], [Amount], [Remark], [IsDeleted]) VALUES (7, 4, 5, N'箱', 50, CAST(39.00 AS Decimal(18, 2)), CAST(1950.00 AS Decimal(18, 2)), N'', 0)
INSERT [dbo].[SaleGoodsInfos] ([SaleGoodsId], [SaleId], [GoodsId], [GUnit], [Count], [SalePrice], [Amount], [Remark], [IsDeleted]) VALUES (8, 4, 1010, N'箱', 100, CAST(42.00 AS Decimal(18, 2)), CAST(4200.00 AS Decimal(18, 2)), N'', 0)
INSERT [dbo].[SaleGoodsInfos] ([SaleGoodsId], [SaleId], [GoodsId], [GUnit], [Count], [SalePrice], [Amount], [Remark], [IsDeleted]) VALUES (9, 6, 1, N'箱', 50, CAST(45.00 AS Decimal(18, 2)), CAST(2250.00 AS Decimal(18, 2)), N'', 0)
INSERT [dbo].[SaleGoodsInfos] ([SaleGoodsId], [SaleId], [GoodsId], [GUnit], [Count], [SalePrice], [Amount], [Remark], [IsDeleted]) VALUES (10, 6, 5, N'箱', 80, CAST(50.00 AS Decimal(18, 2)), CAST(4000.00 AS Decimal(18, 2)), N'', 0)
INSERT [dbo].[SaleGoodsInfos] ([SaleGoodsId], [SaleId], [GoodsId], [GUnit], [Count], [SalePrice], [Amount], [Remark], [IsDeleted]) VALUES (11, 8, 5, N'箱', 30, CAST(50.00 AS Decimal(18, 2)), CAST(1500.00 AS Decimal(18, 2)), N'', 0)
SET IDENTITY_INSERT [dbo].[SaleGoodsInfos] OFF
SET IDENTITY_INSERT [dbo].[SaleOutStoreInfos] ON 

INSERT [dbo].[SaleOutStoreInfos] ([SaleId], [SaleOutNo], [UnitId], [StoreId], [DealPerson], [PayDesp], [ThisAmount], [Remark], [TotalAmount], [YHAmount], [Creator], [CreateTime], [IsChecked], [IsPayed], [IsPayFull], [CheckTime], [CheckPerson], [IsDeleted], [PayTime]) VALUES (1, N'XSD-20200715-0001', 1, 1, N'罗丽', N'现金 1500.00', CAST(1500.00 AS Decimal(18, 2)), N'', CAST(1500.00 AS Decimal(18, 2)), CAST(1500.00 AS Decimal(18, 2)), N'admin', CAST(N'2020-07-15 00:00:00.000' AS DateTime), 3, 1, 1, CAST(N'2020-07-15 15:49:50.480' AS DateTime), N'admin', 0, CAST(N'2020-07-15 15:48:41.560' AS DateTime))
INSERT [dbo].[SaleOutStoreInfos] ([SaleId], [SaleOutNo], [UnitId], [StoreId], [DealPerson], [PayDesp], [ThisAmount], [Remark], [TotalAmount], [YHAmount], [Creator], [CreateTime], [IsChecked], [IsPayed], [IsPayFull], [CheckTime], [CheckPerson], [IsDeleted], [PayTime]) VALUES (2, N'XSD-20201010-0001', 1, 1, N'刘明', N'现金 3000', CAST(3000.00 AS Decimal(18, 2)), N'', CAST(5300.00 AS Decimal(18, 2)), CAST(5300.00 AS Decimal(18, 2)), N'admin', CAST(N'2020-10-10 00:00:00.000' AS DateTime), 3, 1, 0, CAST(N'2020-10-10 22:10:12.167' AS DateTime), N'admin', 0, CAST(N'2020-10-10 16:35:31.947' AS DateTime))
INSERT [dbo].[SaleOutStoreInfos] ([SaleId], [SaleOutNo], [UnitId], [StoreId], [DealPerson], [PayDesp], [ThisAmount], [Remark], [TotalAmount], [YHAmount], [Creator], [CreateTime], [IsChecked], [IsPayed], [IsPayFull], [CheckTime], [CheckPerson], [IsDeleted], [PayTime]) VALUES (4, N'XSD-20210201-0001', 3, 2, N'刘丽', N'现金 100;银行卡 500', CAST(600.00 AS Decimal(18, 2)), NULL, CAST(6640.00 AS Decimal(18, 2)), CAST(6640.00 AS Decimal(18, 2)), N'admin', CAST(N'2021-02-01 00:00:00.000' AS DateTime), 3, 1, 0, CAST(N'2021-03-18 21:20:58.100' AS DateTime), N'admin', 0, CAST(N'2021-03-18 21:20:47.677' AS DateTime))
INSERT [dbo].[SaleOutStoreInfos] ([SaleId], [SaleOutNo], [UnitId], [StoreId], [DealPerson], [PayDesp], [ThisAmount], [Remark], [TotalAmount], [YHAmount], [Creator], [CreateTime], [IsChecked], [IsPayed], [IsPayFull], [CheckTime], [CheckPerson], [IsDeleted], [PayTime]) VALUES (5, N'XSD-20210317-0001', 3, 1, N'Fresh', N'现金 1050.00', CAST(1050.00 AS Decimal(18, 2)), NULL, CAST(1050.00 AS Decimal(18, 2)), CAST(1050.00 AS Decimal(18, 2)), N'Fresh', CAST(N'2021-03-17 00:00:00.000' AS DateTime), 3, 1, 1, CAST(N'2021-03-17 21:18:31.640' AS DateTime), N'admin', 0, CAST(N'2021-03-17 21:15:26.967' AS DateTime))
INSERT [dbo].[SaleOutStoreInfos] ([SaleId], [SaleOutNo], [UnitId], [StoreId], [DealPerson], [PayDesp], [ThisAmount], [Remark], [TotalAmount], [YHAmount], [Creator], [CreateTime], [IsChecked], [IsPayed], [IsPayFull], [CheckTime], [CheckPerson], [IsDeleted], [PayTime]) VALUES (6, N'XSD-20210318-0001', 3, 1, N'王丽', N'现金 1000;银行卡 2000', CAST(3000.00 AS Decimal(18, 2)), NULL, CAST(6250.00 AS Decimal(18, 2)), CAST(6250.00 AS Decimal(18, 2)), N'admin', CAST(N'2021-03-18 00:00:00.000' AS DateTime), 1, 1, 0, CAST(N'2021-03-18 22:25:20.303' AS DateTime), N'admin', 0, CAST(N'2021-03-18 21:30:45.507' AS DateTime))
INSERT [dbo].[SaleOutStoreInfos] ([SaleId], [SaleOutNo], [UnitId], [StoreId], [DealPerson], [PayDesp], [ThisAmount], [Remark], [TotalAmount], [YHAmount], [Creator], [CreateTime], [IsChecked], [IsPayed], [IsPayFull], [CheckTime], [CheckPerson], [IsDeleted], [PayTime]) VALUES (8, N'CGD-20210318-0002', 1, 1, N'王为', N'现金 500', CAST(500.00 AS Decimal(18, 2)), NULL, CAST(1500.00 AS Decimal(18, 2)), CAST(1500.00 AS Decimal(18, 2)), N'admin', CAST(N'2021-03-18 00:00:00.000' AS DateTime), 0, 1, 0, NULL, NULL, 0, CAST(N'2021-03-18 23:07:12.457' AS DateTime))
SET IDENTITY_INSERT [dbo].[SaleOutStoreInfos] OFF
SET IDENTITY_INSERT [dbo].[StockChangeInfos] ON 

INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (1, 1, 3, 1, 2, 1000, 0, 1000)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (2, 1, 3, 1, 1, 100, 0, 100)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (3, 2, 3, 3, 6, 100, 0, 100)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (4, 2, 3, 3, 4, 50, 0, 50)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (5, 2, 3, 3, 3, 100, 0, 100)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (6, 1, 1, 1, 2, 500, 0, 1500)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (7, 1, 1, 1, 1, 50, 0, 150)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (8, 1, 2, 1, 1, 0, 30, 120)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (9, 1, 2, 1, 1, 0, -30, 150)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (14, 4, 1, 1, 4, 10, 0, 10)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (15, 4, 1, 1, 3, 200, 0, 200)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (16, 4, 1, 1, 4, -10, 0, 0)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (17, 4, 1, 1, 3, -200, 0, 0)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (18, 3, 3, 1, 2, 100, 0, 1600)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (19, 3, 3, 1, 1, 20, 0, 170)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (20, 3, 3, 1, 2, -100, 0, 1500)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (21, 3, 3, 1, 1, -20, 0, 150)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (24, 2, 2, 1, 2, 0, 500, 1000)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (25, 2, 2, 1, 1, 0, 50, 100)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (28, 2, 2, 1, 2, 0, -500, 1500)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (29, 2, 2, 1, 1, 0, -50, 150)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (30, 5, 1, 3, 1, 50, 0, 50)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (31, 6, 1, 2, 1, 20, 0, 20)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (32, 6, 1, 2, 5, 30, 0, 30)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (33, 6, 1, 2, 7, 30, 0, 30)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (34, 6, 1, 2, 1, -20, 0, 0)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (35, 6, 1, 2, 5, -30, 0, 0)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (36, 6, 1, 2, 7, -30, 0, 0)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (37, 6, 1, 2, 1, 20, 0, 20)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (38, 6, 1, 2, 5, 30, 0, 30)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (39, 6, 1, 2, 7, 30, 0, 30)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (40, 6, 1, 2, 1, 20, 0, 20)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (41, 6, 1, 2, 5, 30, 0, 30)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (42, 6, 1, 2, 7, 30, 0, 30)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (43, 6, 1, 2, 1, -20, 0, 0)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (44, 6, 1, 2, 5, -30, 0, 0)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (45, 6, 1, 2, 7, -30, 0, 0)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (46, 5, 3, 2, 1, 100, 0, 100)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (47, 5, 3, 2, 2, 500, 0, 500)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (51, 5, 3, 2, 1, -100, 0, 0)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (52, 5, 3, 2, 2, -500, 0, 0)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (53, 1007, 1, 1, 6, 100, 0, 100)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (54, 1007, 1, 1, 3, 50, 0, 50)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (55, 1007, 1, 1, 4, 20, 0, 20)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (56, 1007, 1, 1, 6, -100, 0, 0)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (57, 1007, 1, 1, 3, -50, 0, 0)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (58, 1007, 1, 1, 4, -20, 0, 0)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (59, 5, 2, 1, 2, 0, 300, 1200)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (60, 5, 2, 1, 2, 0, -300, 1500)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (67, 1009, 1, 1, 1, 200, 0, 350)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (68, 1009, 1, 1, 5, 100, 0, 100)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (69, 1009, 1, 1, 1010, 200, 0, 200)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (77, 6, 2, 1, 1, 0, 50, 250)
INSERT [dbo].[StockChangeInfos] ([StockChangeId], [CheckShId], [ShType], [StoreId], [GoodsId], [InCount], [OutCount], [CurCount]) VALUES (78, 6, 2, 1, 5, 0, 80, 20)
SET IDENTITY_INSERT [dbo].[StockChangeInfos] OFF
SET IDENTITY_INSERT [dbo].[StockStoreInfos] ON 

INSERT [dbo].[StockStoreInfos] ([StockId], [StockNo], [StoreId], [DealPerson], [Remark], [Creator], [CreateTime], [IsChecked], [CheckPerson], [CheckTime], [IsDeleted]) VALUES (1, N'KCD-20200715-0001', 1, N'罗丽', N'', N'admin', CAST(N'2020-07-15 00:00:00.000' AS DateTime), 1, N'admin', CAST(N'2020-07-15 15:36:24.147' AS DateTime), 0)
INSERT [dbo].[StockStoreInfos] ([StockId], [StockNo], [StoreId], [DealPerson], [Remark], [Creator], [CreateTime], [IsChecked], [CheckPerson], [CheckTime], [IsDeleted]) VALUES (2, N'KCD-20200715-0002', 3, N'罗丽', N'', N'admin', CAST(N'2020-07-15 00:00:00.000' AS DateTime), 1, N'admin', CAST(N'2020-07-15 15:41:12.560' AS DateTime), 0)
INSERT [dbo].[StockStoreInfos] ([StockId], [StockNo], [StoreId], [DealPerson], [Remark], [Creator], [CreateTime], [IsChecked], [CheckPerson], [CheckTime], [IsDeleted]) VALUES (3, N'KCD-20201004-0001', 1, N'王红', N'', N'admin', CAST(N'2020-10-04 00:00:00.000' AS DateTime), 3, N'admin', CAST(N'2020-10-09 16:24:46.340' AS DateTime), 0)
INSERT [dbo].[StockStoreInfos] ([StockId], [StockNo], [StoreId], [DealPerson], [Remark], [Creator], [CreateTime], [IsChecked], [CheckPerson], [CheckTime], [IsDeleted]) VALUES (4, N'KCD-20201004-0002', 3, N'刘明', N'', N'admin', CAST(N'2020-10-04 00:00:00.000' AS DateTime), 2, NULL, NULL, 0)
INSERT [dbo].[StockStoreInfos] ([StockId], [StockNo], [StoreId], [DealPerson], [Remark], [Creator], [CreateTime], [IsChecked], [CheckPerson], [CheckTime], [IsDeleted]) VALUES (5, N'KCD-20210312-0001', 2, N'王红', NULL, N'王红', CAST(N'2021-03-12 00:00:00.000' AS DateTime), 3, N'admin', CAST(N'2021-03-12 21:43:21.453' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[StockStoreInfos] OFF
SET IDENTITY_INSERT [dbo].[StoreGoodsStockInfos] ON 

INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1, 1, 1, 100, CAST(3500.00 AS Decimal(18, 2)), CAST(35.00 AS Decimal(18, 2)), 250, CAST(8750.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-03-02 21:05:06.650' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (2, 2, 1, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), 2000, 0, N'admin', CAST(N'2020-03-02 21:05:06.657' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (3, 3, 1, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 50, CAST(1750.00 AS Decimal(18, 2)), 800, 0, N'admin', CAST(N'2020-03-02 21:05:06.663' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (4, 0, 1, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 320, CAST(11260.00 AS Decimal(18, 2)), 5000, 5, N'admin', CAST(N'2020-03-02 21:05:06.670' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (5, 1, 2, 1000, CAST(2000.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 1500, CAST(3000.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-03-02 21:06:24.753' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (6, 2, 2, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), 500, 0, N'admin', CAST(N'2020-03-02 21:06:24.760' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (7, 3, 2, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), 800, 0, N'admin', CAST(N'2020-03-02 21:06:24.767' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (8, 0, 2, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1500, CAST(3000.00 AS Decimal(18, 2)), 5000, 5, N'admin', CAST(N'2020-03-02 21:06:24.773' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (9, 1, 3, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-03-02 21:08:46.760' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (10, 2, 3, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), 0, 10, N'admin', CAST(N'2020-03-02 21:08:46.770' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (11, 3, 3, 100, CAST(3500.00 AS Decimal(18, 2)), CAST(35.00 AS Decimal(18, 2)), 100, CAST(3500.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-03-02 21:08:46.780' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (12, 0, 3, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 100, CAST(3500.00 AS Decimal(18, 2)), 5000, 5, N'admin', CAST(N'2020-03-02 21:08:46.787' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (13, 1, 4, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-03-02 21:10:12.067' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (14, 2, 4, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), 0, 10, N'admin', CAST(N'2020-03-02 21:10:12.073' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (15, 3, 4, 50, CAST(7500.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), 50, CAST(7500.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-03-02 21:10:12.080' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (16, 0, 4, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 50, CAST(7500.00 AS Decimal(18, 2)), 500, 10, N'admin', CAST(N'2020-03-02 21:10:12.087' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (17, 5, 1, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-03-03 17:43:19.023' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (18, 5, 2, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-03-03 17:43:19.030' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (19, 5, 3, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-03-03 17:43:19.040' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (20, 5, 4, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-03-03 17:43:19.047' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (21, 1, 5, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 20, CAST(780.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-03-06 11:51:08.043' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (22, 2, 5, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), 0, 10, N'admin', CAST(N'2020-03-06 11:51:08.043' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (23, 3, 5, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-03-06 11:51:08.043' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (24, 5, 5, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-03-06 11:51:08.043' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (25, 0, 5, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), -30, CAST(1830.00 AS Decimal(18, 2)), 5000, 0, N'admin', CAST(N'2020-03-06 11:51:08.043' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (26, 1, 6, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-03-06 15:48:20.673' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (27, 2, 6, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-03-06 15:48:20.683' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (28, 3, 6, 100, CAST(3000.00 AS Decimal(18, 2)), CAST(30.00 AS Decimal(18, 2)), 100, CAST(3000.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-03-06 15:48:20.717' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (29, 5, 6, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-03-06 15:48:20.717' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (30, 0, 6, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 100, CAST(3000.00 AS Decimal(18, 2)), 5000, 0, N'admin', CAST(N'2020-03-06 15:48:20.720' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (31, 1, 7, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-06-29 10:02:59.943' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (32, 2, 7, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-06-29 10:02:59.950' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (33, 3, 7, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-06-29 10:02:59.957' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (34, 5, 7, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-06-29 10:02:59.963' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (35, 0, 7, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 30, CAST(1200.00 AS Decimal(18, 2)), 5000, 0, N'admin', CAST(N'2020-06-29 10:02:59.970' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1031, 1, 1007, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), 1000, 10, N'admin', CAST(N'2020-07-09 21:31:40.017' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1032, 2, 1007, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-07-09 21:31:40.027' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1033, 3, 1007, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-07-09 21:31:40.033' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1034, 5, 1007, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-07-09 21:31:40.043' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1036, 0, 1007, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), 0, 8, N'admin', CAST(N'2020-07-09 21:31:40.057' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1037, 1006, 1, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), 100, 0, N'admin', CAST(N'2020-07-15 16:42:35.753' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1038, 1006, 2, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-07-15 16:42:35.760' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1039, 1006, 3, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-07-15 16:42:35.767' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1040, 1006, 4, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-07-15 16:42:35.770' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1041, 1006, 5, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-07-15 16:42:35.777' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1042, 1006, 6, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-07-15 16:42:35.790' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1043, 1006, 7, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-07-15 16:42:35.797' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1044, 1006, 1007, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-07-15 16:42:35.803' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1045, 1, 1008, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-27 11:52:56.920' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1046, 2, 1008, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-27 11:52:56.927' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1047, 3, 1008, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-27 11:52:56.930' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1048, 5, 1008, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-27 11:52:56.933' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1050, 1006, 1008, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-27 11:52:56.940' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1051, 0, 1008, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), 0, 8, N'admin', CAST(N'2020-09-27 11:52:56.947' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1052, 1, 1009, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-27 12:02:05.037' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1053, 2, 1009, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-27 12:02:05.043' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1054, 3, 1009, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-27 12:02:05.047' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1055, 5, 1009, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-27 12:02:05.050' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1057, 1006, 1009, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-27 12:02:05.060' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1058, 0, 1009, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), 800, 0, N'admin', CAST(N'2020-09-27 12:02:05.063' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1059, 1007, 1, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-30 11:21:05.990' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1060, 1007, 2, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-30 11:21:05.993' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1061, 1007, 3, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-30 11:21:05.997' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1062, 1007, 4, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-30 11:21:06.000' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1063, 1007, 5, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-30 11:21:06.003' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1064, 1007, 6, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-30 11:21:06.010' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1065, 1007, 7, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-30 11:21:06.013' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1066, 1007, 1008, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-30 11:21:06.017' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1067, 1007, 1009, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-30 11:21:06.020' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1068, 1008, 1, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-30 11:21:42.520' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1069, 1008, 2, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-30 11:21:42.523' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1070, 1008, 3, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-30 11:21:42.527' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1071, 1008, 4, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-30 11:21:42.530' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1072, 1008, 5, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-30 11:21:42.533' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1073, 1008, 6, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-30 11:21:42.540' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1074, 1008, 7, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-30 11:21:42.543' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1075, 1008, 1008, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-30 11:21:42.550' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1076, 1008, 1009, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2020-09-30 11:21:42.553' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1077, 1007, 1007, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2021-01-26 14:55:57.573' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1078, 1008, 1007, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2021-01-26 14:55:57.577' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1079, 1, 1010, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 200, CAST(8400.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2021-01-26 17:48:55.537' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1080, 2, 1010, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2021-01-26 17:48:55.543' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1081, 3, 1010, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2021-01-26 17:48:55.547' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1082, 5, 1010, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2021-01-26 17:48:55.557' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1083, 1006, 1010, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2021-01-26 17:48:55.560' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1084, 1007, 1010, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2021-01-26 17:48:55.567' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1085, 1008, 1010, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2021-01-26 17:48:55.570' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1086, 0, 1010, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 200, CAST(8400.00 AS Decimal(18, 2)), 800, 0, N'admin', CAST(N'2021-01-26 17:48:55.577' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1087, 1009, 1, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2021-01-26 23:24:52.680' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1088, 1009, 2, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2021-01-26 23:24:52.683' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1089, 1009, 3, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2021-01-26 23:24:52.690' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1090, 1009, 4, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2021-01-26 23:24:52.693' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1091, 1009, 5, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2021-01-26 23:24:52.700' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1092, 1009, 6, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2021-01-26 23:24:52.703' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1093, 1009, 7, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2021-01-26 23:24:52.710' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1094, 1009, 1007, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2021-01-26 23:24:52.713' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1095, 1009, 1008, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2021-01-26 23:24:52.720' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1096, 1009, 1009, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2021-01-26 23:24:52.723' AS DateTime), 0)
INSERT [dbo].[StoreGoodsStockInfos] ([StoreGoodsId], [StoreId], [GoodsId], [StCount], [StAmount], [StPrice], [CurCount], [StockAmount], [StockUp], [StockDown], [Creator], [Createtime], [IsDeleted]) VALUES (1097, 1009, 1010, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, 0, N'admin', CAST(N'2021-01-26 23:24:52.730' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[StoreGoodsStockInfos] OFF
SET IDENTITY_INSERT [dbo].[StoreInfos] ON 

INSERT [dbo].[StoreInfos] ([StoreId], [StoreNo], [StoreName], [STypeId], [StorePYNo], [StoreOrder], [StoreRemark], [IsDeleted], [Creator], [CreateTime]) VALUES (1, N'10001', N'第一主仓库123', 1, N'DYZCK123', 1, N'公司产品第一主要存储仓库。111', 0, N'admin', CAST(N'2020-03-02 20:27:36.107' AS DateTime))
INSERT [dbo].[StoreInfos] ([StoreId], [StoreNo], [StoreName], [STypeId], [StorePYNo], [StoreOrder], [StoreRemark], [IsDeleted], [Creator], [CreateTime]) VALUES (2, N'10002', N'第二仓库', 1, N'DECK', 2, N'公司第二存储仓库。', 0, N'admin', CAST(N'2020-03-02 20:28:52.337' AS DateTime))
INSERT [dbo].[StoreInfos] ([StoreId], [StoreNo], [StoreName], [STypeId], [StorePYNo], [StoreOrder], [StoreRemark], [IsDeleted], [Creator], [CreateTime]) VALUES (3, N'20001', N'上海第一仓库', 2, N'SHDYCK', 1, N'上海分部产品第一存储仓库，所有产品首选存放在该仓库。', 0, N'admin', CAST(N'2020-03-02 20:30:16.533' AS DateTime))
INSERT [dbo].[StoreInfos] ([StoreId], [StoreNo], [StoreName], [STypeId], [StorePYNo], [StoreOrder], [StoreRemark], [IsDeleted], [Creator], [CreateTime]) VALUES (5, N'30001', N'第一临时库', 3, N'DYLSK', 4, N'货物临时存放第一仓库。', 0, N'admin', CAST(N'2020-03-03 17:43:19.013' AS DateTime))
INSERT [dbo].[StoreInfos] ([StoreId], [StoreNo], [StoreName], [STypeId], [StorePYNo], [StoreOrder], [StoreRemark], [IsDeleted], [Creator], [CreateTime]) VALUES (1006, N'30003', N'第三临时仓库', 3, N'DSLSCK', 3, N'第三临时存放仓库。', 0, N'admin', CAST(N'2020-07-15 16:42:35.747' AS DateTime))
INSERT [dbo].[StoreInfos] ([StoreId], [StoreNo], [StoreName], [STypeId], [StorePYNo], [StoreOrder], [StoreRemark], [IsDeleted], [Creator], [CreateTime]) VALUES (1007, N'30002', N'第二临时仓库', 3, N'DELSCK', 5, N'第二临时存储仓库。', 0, N'admin', CAST(N'2020-09-30 11:21:05.983' AS DateTime))
INSERT [dbo].[StoreInfos] ([StoreId], [StoreNo], [StoreName], [STypeId], [StorePYNo], [StoreOrder], [StoreRemark], [IsDeleted], [Creator], [CreateTime]) VALUES (1008, N'30003', N'第二临时仓库', 1005, N'DELSCK', 5, N'第二临时存储仓库。', 0, N'admin', CAST(N'2020-09-30 11:21:42.513' AS DateTime))
INSERT [dbo].[StoreInfos] ([StoreId], [StoreNo], [StoreName], [STypeId], [StorePYNo], [StoreOrder], [StoreRemark], [IsDeleted], [Creator], [CreateTime]) VALUES (1009, N'30004', N'第三临时仓库', 1005, N'DSLSCK', 2, N'新增第三临时仓库', 0, N'admin', CAST(N'2021-01-26 23:24:52.673' AS DateTime))
SET IDENTITY_INSERT [dbo].[StoreInfos] OFF
SET IDENTITY_INSERT [dbo].[StoreTypeInfos] ON 

INSERT [dbo].[StoreTypeInfos] ([STypeId], [STypeName], [STPYNo], [STypeOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (1, N'公司总仓库', N'GSZCK', 1, 0, N'admin', CAST(N'2020-03-02 18:23:07.293' AS DateTime))
INSERT [dbo].[StoreTypeInfos] ([STypeId], [STypeName], [STPYNo], [STypeOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (2, N'外地仓库', N'WDCK', 2, 0, N'admin', CAST(N'2020-03-02 18:23:16.520' AS DateTime))
INSERT [dbo].[StoreTypeInfos] ([STypeId], [STypeName], [STPYNo], [STypeOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (3, N'临时第二仓库', N'LSDECK', 3, 0, N'admin', CAST(N'2020-03-02 18:23:24.460' AS DateTime))
INSERT [dbo].[StoreTypeInfos] ([STypeId], [STypeName], [STPYNo], [STypeOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (1005, N'新增仓库', N'XZCK', 4, 0, N'admin', CAST(N'2020-09-23 09:55:55.320' AS DateTime))
INSERT [dbo].[StoreTypeInfos] ([STypeId], [STypeName], [STPYNo], [STypeOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (1006, N'重点仓库', N'ZDCK', 5, 0, N'admin', CAST(N'2020-09-30 09:55:34.900' AS DateTime))
INSERT [dbo].[StoreTypeInfos] ([STypeId], [STypeName], [STPYNo], [STypeOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (1007, N'上海总仓库', N'SHZCK', 6, 0, N'admin', CAST(N'2021-01-25 21:08:18.750' AS DateTime))
INSERT [dbo].[StoreTypeInfos] ([STypeId], [STypeName], [STPYNo], [STypeOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (1008, N'四川总仓库', N'SCZCK', 7, 0, N'admin', CAST(N'2021-01-26 21:56:27.357' AS DateTime))
SET IDENTITY_INSERT [dbo].[StoreTypeInfos] OFF
SET IDENTITY_INSERT [dbo].[StStockGoodsInfos] ON 

INSERT [dbo].[StStockGoodsInfos] ([StStockId], [StockId], [GoodsId], [StCount], [StPrice], [StAmount], [IsDeleted], [Remark]) VALUES (1, 1, 2, 1000, CAST(2.00 AS Decimal(18, 2)), CAST(2000.00 AS Decimal(18, 2)), 0, N'')
INSERT [dbo].[StStockGoodsInfos] ([StStockId], [StockId], [GoodsId], [StCount], [StPrice], [StAmount], [IsDeleted], [Remark]) VALUES (2, 1, 1, 100, CAST(35.00 AS Decimal(18, 2)), CAST(3500.00 AS Decimal(18, 2)), 0, N'')
INSERT [dbo].[StStockGoodsInfos] ([StStockId], [StockId], [GoodsId], [StCount], [StPrice], [StAmount], [IsDeleted], [Remark]) VALUES (3, 2, 6, 100, CAST(30.00 AS Decimal(18, 2)), CAST(3000.00 AS Decimal(18, 2)), 0, N'')
INSERT [dbo].[StStockGoodsInfos] ([StStockId], [StockId], [GoodsId], [StCount], [StPrice], [StAmount], [IsDeleted], [Remark]) VALUES (4, 2, 4, 50, CAST(150.00 AS Decimal(18, 2)), CAST(7500.00 AS Decimal(18, 2)), 0, N'')
INSERT [dbo].[StStockGoodsInfos] ([StStockId], [StockId], [GoodsId], [StCount], [StPrice], [StAmount], [IsDeleted], [Remark]) VALUES (5, 2, 3, 100, CAST(35.00 AS Decimal(18, 2)), CAST(3500.00 AS Decimal(18, 2)), 0, N'')
INSERT [dbo].[StStockGoodsInfos] ([StStockId], [StockId], [GoodsId], [StCount], [StPrice], [StAmount], [IsDeleted], [Remark]) VALUES (6, 3, 2, 100, CAST(2.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), 0, N'')
INSERT [dbo].[StStockGoodsInfos] ([StStockId], [StockId], [GoodsId], [StCount], [StPrice], [StAmount], [IsDeleted], [Remark]) VALUES (7, 3, 1, 20, CAST(40.00 AS Decimal(18, 2)), CAST(800.00 AS Decimal(18, 2)), 0, N'')
INSERT [dbo].[StStockGoodsInfos] ([StStockId], [StockId], [GoodsId], [StCount], [StPrice], [StAmount], [IsDeleted], [Remark]) VALUES (8, 4, 3, 200, CAST(39.00 AS Decimal(18, 2)), CAST(7800.00 AS Decimal(18, 2)), 0, N'')
INSERT [dbo].[StStockGoodsInfos] ([StStockId], [StockId], [GoodsId], [StCount], [StPrice], [StAmount], [IsDeleted], [Remark]) VALUES (9, 4, 4, 20, CAST(300.00 AS Decimal(18, 2)), CAST(6000.00 AS Decimal(18, 2)), 0, N'')
INSERT [dbo].[StStockGoodsInfos] ([StStockId], [StockId], [GoodsId], [StCount], [StPrice], [StAmount], [IsDeleted], [Remark]) VALUES (10, 5, 1, 100, CAST(35.00 AS Decimal(18, 2)), CAST(3500.00 AS Decimal(18, 2)), 0, N'')
INSERT [dbo].[StStockGoodsInfos] ([StStockId], [StockId], [GoodsId], [StCount], [StPrice], [StAmount], [IsDeleted], [Remark]) VALUES (11, 5, 2, 500, CAST(2.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), 0, N'')
SET IDENTITY_INSERT [dbo].[StStockGoodsInfos] OFF
INSERT [dbo].[SysInfos] ([SysId], [SysName], [IsOpened], [OpenTime]) VALUES (1, N'默认账套', 1, CAST(N'2021-03-12 21:14:37.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[ToolGroupInfos] ON 

INSERT [dbo].[ToolGroupInfos] ([TGroupId], [TGroupName], [Creator], [CreateTime], [IsDeleted]) VALUES (1, N'基本信息', N'admin', CAST(N'2020-02-10 10:45:57.997' AS DateTime), 0)
INSERT [dbo].[ToolGroupInfos] ([TGroupId], [TGroupName], [Creator], [CreateTime], [IsDeleted]) VALUES (2, N'业务处理', N'admin', CAST(N'2020-02-10 10:46:10.237' AS DateTime), 0)
INSERT [dbo].[ToolGroupInfos] ([TGroupId], [TGroupName], [Creator], [CreateTime], [IsDeleted]) VALUES (3, N'查询操作', N'admin', CAST(N'2020-02-10 10:46:38.207' AS DateTime), 0)
INSERT [dbo].[ToolGroupInfos] ([TGroupId], [TGroupName], [Creator], [CreateTime], [IsDeleted]) VALUES (4, N'用户操作', N'admin', CAST(N'2020-02-10 10:46:57.690' AS DateTime), 0)
INSERT [dbo].[ToolGroupInfos] ([TGroupId], [TGroupName], [Creator], [CreateTime], [IsDeleted]) VALUES (5, N'系统操作', N'admin', CAST(N'2020-02-10 10:47:11.997' AS DateTime), 0)
INSERT [dbo].[ToolGroupInfos] ([TGroupId], [TGroupName], [Creator], [CreateTime], [IsDeleted]) VALUES (6, N'菜单操作', N'admin', CAST(N'2020-03-05 21:39:59.643' AS DateTime), 0)
INSERT [dbo].[ToolGroupInfos] ([TGroupId], [TGroupName], [Creator], [CreateTime], [IsDeleted]) VALUES (8, N'入库操作', N'admin', CAST(N'2020-04-13 10:39:18.577' AS DateTime), 0)
INSERT [dbo].[ToolGroupInfos] ([TGroupId], [TGroupName], [Creator], [CreateTime], [IsDeleted]) VALUES (10, N'期初设置11', N'admin', CAST(N'2021-01-20 23:56:46.570' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[ToolGroupInfos] OFF
SET IDENTITY_INSERT [dbo].[ToolMenuInfos] ON 

INSERT [dbo].[ToolMenuInfos] ([TMenuId], [TMenuName], [TMPic], [TMOrder], [TGroupId], [TMUrl], [IsTop], [Creator], [CreateTime], [TMDesp], [IsDeleted]) VALUES (1, N'商品信息', N'Imgs/goods.png', 1, 1, N'BM.FrmGoodsList', 0, N'admin', CAST(N'2020-02-10 10:47:43.147' AS DateTime), NULL, 0)
INSERT [dbo].[ToolMenuInfos] ([TMenuId], [TMenuName], [TMPic], [TMOrder], [TGroupId], [TMUrl], [IsTop], [Creator], [CreateTime], [TMDesp], [IsDeleted]) VALUES (2, N'采购入库', NULL, 1, 2, N'Perchase.FrmPerchaseInStore', 0, N'admin', CAST(N'2020-02-10 10:48:34.110' AS DateTime), NULL, 0)
INSERT [dbo].[ToolMenuInfos] ([TMenuId], [TMenuName], [TMPic], [TMOrder], [TGroupId], [TMUrl], [IsTop], [Creator], [CreateTime], [TMDesp], [IsDeleted]) VALUES (3, N'销售出库', NULL, 2, 2, N'Sale.FrmSaleOutStore', 0, N'admin', CAST(N'2020-02-10 10:55:24.627' AS DateTime), NULL, 0)
INSERT [dbo].[ToolMenuInfos] ([TMenuId], [TMenuName], [TMPic], [TMOrder], [TGroupId], [TMUrl], [IsTop], [Creator], [CreateTime], [TMDesp], [IsDeleted]) VALUES (4, N'库存查询', NULL, 1, 3, N'Stock.FrmStoreStockQuery', 0, N'admin', CAST(N'2020-02-10 10:57:05.627' AS DateTime), NULL, 0)
INSERT [dbo].[ToolMenuInfos] ([TMenuId], [TMenuName], [TMPic], [TMOrder], [TGroupId], [TMUrl], [IsTop], [Creator], [CreateTime], [TMDesp], [IsDeleted]) VALUES (5, N'更换操作员', NULL, 1, 5, NULL, 0, N'admin', CAST(N'2020-02-10 10:57:41.247' AS DateTime), N'ChangeActor', 0)
INSERT [dbo].[ToolMenuInfos] ([TMenuId], [TMenuName], [TMPic], [TMOrder], [TGroupId], [TMUrl], [IsTop], [Creator], [CreateTime], [TMDesp], [IsDeleted]) VALUES (6, N'退出系统', NULL, 1, 5, NULL, 0, N'admin', CAST(N'2020-02-10 10:58:05.480' AS DateTime), N'ExitSystem', 0)
INSERT [dbo].[ToolMenuInfos] ([TMenuId], [TMenuName], [TMPic], [TMOrder], [TGroupId], [TMUrl], [IsTop], [Creator], [CreateTime], [TMDesp], [IsDeleted]) VALUES (7, N'刷新菜单', NULL, 2, 6, NULL, 0, N'admin', CAST(N'2020-03-05 21:29:10.760' AS DateTime), N'RefreshMenu', 0)
INSERT [dbo].[ToolMenuInfos] ([TMenuId], [TMenuName], [TMPic], [TMOrder], [TGroupId], [TMUrl], [IsTop], [Creator], [CreateTime], [TMDesp], [IsDeleted]) VALUES (8, N'仓库信息', N'Imgs/scfb.png', 2, 1, N'BM.FrmStoreList', 0, N'admin', CAST(N'2020-07-01 15:52:41.163' AS DateTime), NULL, 0)
INSERT [dbo].[ToolMenuInfos] ([TMenuId], [TMenuName], [TMPic], [TMOrder], [TGroupId], [TMUrl], [IsTop], [Creator], [CreateTime], [TMDesp], [IsDeleted]) VALUES (9, N'往来单位', N'imgs/action.png', 3, 1, N'BM.FrmUnitList', 0, N'admin', CAST(N'2020-07-08 20:57:01.410' AS DateTime), NULL, 0)
INSERT [dbo].[ToolMenuInfos] ([TMenuId], [TMenuName], [TMPic], [TMOrder], [TGroupId], [TMUrl], [IsTop], [Creator], [CreateTime], [TMDesp], [IsDeleted]) VALUES (10, N'期初入库', NULL, 0, 1, NULL, 0, N'admin', CAST(N'2021-01-20 21:52:08.243' AS DateTime), NULL, 0)
SET IDENTITY_INSERT [dbo].[ToolMenuInfos] OFF
SET IDENTITY_INSERT [dbo].[UnitInfos] ON 

INSERT [dbo].[UnitInfos] ([UnitId], [UnitName], [UnitPYNo], [UTypeId], [UnitProperties], [RegionId], [Address], [FullAddress], [UnitNo], [ContactPerson], [PhoneNumber], [Telephone], [Fax], [Email], [PostalCode], [Remark], [IsNoVail], [IsDeleted], [Creator], [CreateTime]) VALUES (1, N'绵阳众诚科技', N'MYZCKJ', 6, N'客户', 323, N'崇尚国际1-15-8', N'四川绵阳崇尚国际1-15-8', N'MY0001', N'李明', N'', N'13897684567', N'', N'', N'62100', N'崇尚国际1-15-8', 0, 0, N'admin', CAST(N'2020-03-02 20:36:17.023' AS DateTime))
INSERT [dbo].[UnitInfos] ([UnitId], [UnitName], [UnitPYNo], [UTypeId], [UnitProperties], [RegionId], [Address], [FullAddress], [UnitNo], [ContactPerson], [PhoneNumber], [Telephone], [Fax], [Email], [PostalCode], [Remark], [IsNoVail], [IsDeleted], [Creator], [CreateTime]) VALUES (2, N'成都食品批发部', N'CDSPPFB', 3, N'供应商', 322, N'河花池一部', N'四川成都河花池一部', N'CD10001', N'刘丽', N'', N'', N'', N'', N'', N'河花池一部', 0, 0, N'admin', CAST(N'2020-03-02 20:37:53.657' AS DateTime))
INSERT [dbo].[UnitInfos] ([UnitId], [UnitName], [UnitPYNo], [UTypeId], [UnitProperties], [RegionId], [Address], [FullAddress], [UnitNo], [ContactPerson], [PhoneNumber], [Telephone], [Fax], [Email], [PostalCode], [Remark], [IsNoVail], [IsDeleted], [Creator], [CreateTime]) VALUES (3, N'上海电子科技', N'SHDZKJ', 8, N'客户', 25, N'', N'上海', N'SH0001', N'吴军', N'', N'', N'', N'', N'', N'', 0, 0, N'admin', CAST(N'2020-03-02 20:40:04.423' AS DateTime))
INSERT [dbo].[UnitInfos] ([UnitId], [UnitName], [UnitPYNo], [UTypeId], [UnitProperties], [RegionId], [Address], [FullAddress], [UnitNo], [ContactPerson], [PhoneNumber], [Telephone], [Fax], [Email], [PostalCode], [Remark], [IsNoVail], [IsDeleted], [Creator], [CreateTime]) VALUES (4, N'绵阳帅克', N'MYSK', 3, N'供应商既客户', 323, N'电子商城', N'四川绵阳电子商城', N'MY10002', N'', N'', N'', N'', N'', N'', N'主要经营电子产品批发', 1, 0, N'admin', CAST(N'2020-03-02 20:45:17.610' AS DateTime))
INSERT [dbo].[UnitInfos] ([UnitId], [UnitName], [UnitPYNo], [UTypeId], [UnitProperties], [RegionId], [Address], [FullAddress], [UnitNo], [ContactPerson], [PhoneNumber], [Telephone], [Fax], [Email], [PostalCode], [Remark], [IsNoVail], [IsDeleted], [Creator], [CreateTime]) VALUES (5, N'绵阳帅克科技', N'MYSKKJ', 3, N'供应商', 323, N'科技立交桥', N'四川绵阳科技立交桥', N'MY0002', N'王力', N'', N'', N'', N'', N'', N'科技立交桥', 0, 0, N'admin', CAST(N'2020-03-02 21:01:35.253' AS DateTime))
INSERT [dbo].[UnitInfos] ([UnitId], [UnitName], [UnitPYNo], [UTypeId], [UnitProperties], [RegionId], [Address], [FullAddress], [UnitNo], [ContactPerson], [PhoneNumber], [Telephone], [Fax], [Email], [PostalCode], [Remark], [IsNoVail], [IsDeleted], [Creator], [CreateTime]) VALUES (1006, N'新电科技有限公司', N'XDKJYXGS', 12, N'供应商', 2722, N'天府一段14号', N'四川成都青羊区天府一段14号', N'CD10002', N'王红', N'', N'13456879098', N'', N'wanghong@163.com', N'', N'天府一段122号', 0, 0, N'admin', CAST(N'2020-09-29 10:52:49.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[UnitInfos] OFF
SET IDENTITY_INSERT [dbo].[UnitTypeInfos] ON 

INSERT [dbo].[UnitTypeInfos] ([UTypeId], [UTypeName], [ParentId], [ParentName], [UTypeNo], [UTPYNo], [UTOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (1, N'供应商', 0, NULL, N'U0001', N'GYS', 1, 0, N'admin', CAST(N'2020-03-02 17:51:43.057' AS DateTime))
INSERT [dbo].[UnitTypeInfos] ([UTypeId], [UTypeName], [ParentId], [ParentName], [UTypeNo], [UTPYNo], [UTOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (2, N'客户', 0, NULL, N'U0002', N'KH', 2, 0, N'admin', CAST(N'2020-03-02 17:51:58.953' AS DateTime))
INSERT [dbo].[UnitTypeInfos] ([UTypeId], [UTypeName], [ParentId], [ParentName], [UTypeNo], [UTPYNo], [UTOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (3, N'四川供应商', 1, N'供应商', N'U00011', N'SCGYS', 1, 0, N'admin', CAST(N'2020-03-02 17:53:59.487' AS DateTime))
INSERT [dbo].[UnitTypeInfos] ([UTypeId], [UTypeName], [ParentId], [ParentName], [UTypeNo], [UTPYNo], [UTOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (4, N'江苏供应商', 1, N'供应商', N'U00012', N'JSGYS', 2, 0, N'admin', CAST(N'2020-03-02 17:54:14.190' AS DateTime))
INSERT [dbo].[UnitTypeInfos] ([UTypeId], [UTypeName], [ParentId], [ParentName], [UTypeNo], [UTPYNo], [UTOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (5, N'上海供应商', 1, N'供应商', N'U00013', N'SHGYS', 2, 1, N'admin', CAST(N'2020-03-02 17:54:29.797' AS DateTime))
INSERT [dbo].[UnitTypeInfos] ([UTypeId], [UTypeName], [ParentId], [ParentName], [UTypeNo], [UTPYNo], [UTOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (6, N'绵阳客户', 2, N'客户', N'U00021', N'MYKH', 1, 0, N'admin', CAST(N'2020-03-02 17:55:05.393' AS DateTime))
INSERT [dbo].[UnitTypeInfos] ([UTypeId], [UTypeName], [ParentId], [ParentName], [UTypeNo], [UTPYNo], [UTOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (7, N'成都客户', 2, N'客户', N'U00022', N'CDKH', 2, 0, N'admin', CAST(N'2020-03-02 17:55:19.243' AS DateTime))
INSERT [dbo].[UnitTypeInfos] ([UTypeId], [UTypeName], [ParentId], [ParentName], [UTypeNo], [UTPYNo], [UTOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (8, N'上海客户', 2, N'客户', N'U00023', N'SHKH', 3, 0, N'admin', CAST(N'2020-03-02 17:55:30.973' AS DateTime))
INSERT [dbo].[UnitTypeInfos] ([UTypeId], [UTypeName], [ParentId], [ParentName], [UTypeNo], [UTPYNo], [UTOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (9, N'江苏客户', 2, N'客户', N'U00024', N'JSKH', 3, 0, N'admin', CAST(N'2020-03-02 17:55:45.867' AS DateTime))
INSERT [dbo].[UnitTypeInfos] ([UTypeId], [UTypeName], [ParentId], [ParentName], [UTypeNo], [UTPYNo], [UTOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (10, N'河北直销供应商', 1, N'供应商', N'U00014', N'HBZXGYS', 4, 0, N'admin', CAST(N'2020-06-28 15:06:52.980' AS DateTime))
INSERT [dbo].[UnitTypeInfos] ([UTypeId], [UTypeName], [ParentId], [ParentName], [UTypeNo], [UTPYNo], [UTOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (11, N'江西供应商', 1, N'供应商', N'U00015', N'JXGYS', 5, 0, N'admin', CAST(N'2020-09-24 10:25:35.590' AS DateTime))
INSERT [dbo].[UnitTypeInfos] ([UTypeId], [UTypeName], [ParentId], [ParentName], [UTypeNo], [UTPYNo], [UTOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (12, N'成都供应商', 3, N'四川供应商', N'U000111', N'CDGYS', 2, 0, N'admin', CAST(N'2020-09-24 10:27:43.400' AS DateTime))
INSERT [dbo].[UnitTypeInfos] ([UTypeId], [UTypeName], [ParentId], [ParentName], [UTypeNo], [UTPYNo], [UTOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (13, N'绵阳供应商', 3, N'四川供应商', N'U000112', N'MYGYS', 2, 0, N'admin', CAST(N'2020-09-28 16:41:01.970' AS DateTime))
INSERT [dbo].[UnitTypeInfos] ([UTypeId], [UTypeName], [ParentId], [ParentName], [UTypeNo], [UTPYNo], [UTOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (14, N'德阳供应商', 3, N'四川供应商', N'U000113', N'DYGYS', 3, 0, N'admin', CAST(N'2021-01-25 22:42:52.203' AS DateTime))
INSERT [dbo].[UnitTypeInfos] ([UTypeId], [UTypeName], [ParentId], [ParentName], [UTypeNo], [UTPYNo], [UTOrder], [IsDeleted], [Creator], [CreateTime]) VALUES (15, N'上海供应商001', 1, N'供应商', N'U00016', N'SHGYS001', 6, 0, N'admin', CAST(N'2021-03-02 16:18:44.150' AS DateTime))
SET IDENTITY_INSERT [dbo].[UnitTypeInfos] OFF
SET IDENTITY_INSERT [dbo].[UserInfos] ON 

INSERT [dbo].[UserInfos] ([UserId], [UserName], [UserPwd], [UserState], [Creator], [CreateTime], [IsDeleted], [LoginIp], [LastLoginTime], [LoginCount], [UserRealPwd]) VALUES (1, N'admin', N'e00cf25ad42683b3df678c61f42c6bda', 1, N'admin', CAST(N'2020-02-27 20:39:46.570' AS DateTime), 0, N'192.168.0.105', CAST(N'2021-03-19 10:00:55.850' AS DateTime), 630, N'admin')
INSERT [dbo].[UserInfos] ([UserId], [UserName], [UserPwd], [UserState], [Creator], [CreateTime], [IsDeleted], [LoginIp], [LastLoginTime], [LoginCount], [UserRealPwd]) VALUES (2, N'sysLyc', N'e10adc3949ba59abbe56e057f20f883e', 0, N'admin', CAST(N'2020-02-28 14:11:58.197' AS DateTime), 1, N'192.168.1.6', CAST(N'2021-01-24 23:04:22.320' AS DateTime), 0, NULL)
INSERT [dbo].[UserInfos] ([UserId], [UserName], [UserPwd], [UserState], [Creator], [CreateTime], [IsDeleted], [LoginIp], [LastLoginTime], [LoginCount], [UserRealPwd]) VALUES (3, N'lwb0211', N'827ccb0eea8a706c4c34a16891f84e7b', 1, N'admin', CAST(N'2020-03-02 17:17:22.427' AS DateTime), 0, N'192.168.1.6', CAST(N'2021-01-24 00:00:00.000' AS DateTime), 0, NULL)
INSERT [dbo].[UserInfos] ([UserId], [UserName], [UserPwd], [UserState], [Creator], [CreateTime], [IsDeleted], [LoginIp], [LastLoginTime], [LoginCount], [UserRealPwd]) VALUES (4, N'lyc001', N'e10adc3949ba59abbe56e057f20f883e', 1, N'admin', CAST(N'2020-03-06 11:37:43.087' AS DateTime), 0, NULL, NULL, 0, NULL)
INSERT [dbo].[UserInfos] ([UserId], [UserName], [UserPwd], [UserState], [Creator], [CreateTime], [IsDeleted], [LoginIp], [LastLoginTime], [LoginCount], [UserRealPwd]) VALUES (5, N'lyc002', N'e10adc3949ba59abbe56e057f20f883e', 0, N'admin', CAST(N'2020-03-24 14:41:39.427' AS DateTime), 1, NULL, NULL, 0, NULL)
INSERT [dbo].[UserInfos] ([UserId], [UserName], [UserPwd], [UserState], [Creator], [CreateTime], [IsDeleted], [LoginIp], [LastLoginTime], [LoginCount], [UserRealPwd]) VALUES (6, N'lyc003', N'81dc9bdb52d04dc20036dbd8313ed055', 0, N'admin', CAST(N'2020-03-24 14:47:19.673' AS DateTime), 1, NULL, NULL, 0, NULL)
INSERT [dbo].[UserInfos] ([UserId], [UserName], [UserPwd], [UserState], [Creator], [CreateTime], [IsDeleted], [LoginIp], [LastLoginTime], [LoginCount], [UserRealPwd]) VALUES (7, N'lwb002', N'e10adc3949ba59abbe56e057f20f883e', 1, N'admin', CAST(N'2020-07-01 16:11:15.343' AS DateTime), 0, NULL, NULL, 0, NULL)
INSERT [dbo].[UserInfos] ([UserId], [UserName], [UserPwd], [UserState], [Creator], [CreateTime], [IsDeleted], [LoginIp], [LastLoginTime], [LoginCount], [UserRealPwd]) VALUES (8, N'lwb004', N'202cb962ac59075b964b07152d234b70', 0, N'admin', CAST(N'2020-11-13 11:54:47.520' AS DateTime), 0, NULL, NULL, 0, NULL)
INSERT [dbo].[UserInfos] ([UserId], [UserName], [UserPwd], [UserState], [Creator], [CreateTime], [IsDeleted], [LoginIp], [LastLoginTime], [LoginCount], [UserRealPwd]) VALUES (9, N'lyc005', N'81dc9bdb52d04dc20036dbd8313ed055', 1, N'admin', CAST(N'2021-01-25 11:17:15.723' AS DateTime), 0, N'192.168.0.102', CAST(N'2021-03-05 22:00:56.543' AS DateTime), 3, N'1234')
INSERT [dbo].[UserInfos] ([UserId], [UserName], [UserPwd], [UserState], [Creator], [CreateTime], [IsDeleted], [LoginIp], [LastLoginTime], [LoginCount], [UserRealPwd]) VALUES (10, N'Lyc010', N'e10adc3949ba59abbe56e057f20f883e', 1, N'admin', CAST(N'2021-03-10 20:29:06.247' AS DateTime), 0, NULL, NULL, 0, N'123456')
SET IDENTITY_INSERT [dbo].[UserInfos] OFF
SET IDENTITY_INSERT [dbo].[UserRoleInfos] ON 

INSERT [dbo].[UserRoleInfos] ([URId], [UserId], [RoleId], [Creator], [CreateTime], [IsDeleted]) VALUES (1, 1, 1, N'admin', CAST(N'2020-03-02 10:11:58.850' AS DateTime), 0)
INSERT [dbo].[UserRoleInfos] ([URId], [UserId], [RoleId], [Creator], [CreateTime], [IsDeleted]) VALUES (2, 3, 2, N'admin', CAST(N'2020-03-02 17:17:22.447' AS DateTime), 0)
INSERT [dbo].[UserRoleInfos] ([URId], [UserId], [RoleId], [Creator], [CreateTime], [IsDeleted]) VALUES (5, 3, 6, N'admin', CAST(N'2020-03-06 15:29:47.847' AS DateTime), 1)
INSERT [dbo].[UserRoleInfos] ([URId], [UserId], [RoleId], [Creator], [CreateTime], [IsDeleted]) VALUES (6, 4, 6, N'lwb0211', CAST(N'2020-03-06 17:51:01.430' AS DateTime), 1)
INSERT [dbo].[UserRoleInfos] ([URId], [UserId], [RoleId], [Creator], [CreateTime], [IsDeleted]) VALUES (8, 6, 2, N'admin', CAST(N'2020-03-24 14:47:19.700' AS DateTime), 1)
INSERT [dbo].[UserRoleInfos] ([URId], [UserId], [RoleId], [Creator], [CreateTime], [IsDeleted]) VALUES (10, 5, 2, N'admin', CAST(N'2020-03-24 15:41:39.323' AS DateTime), 1)
INSERT [dbo].[UserRoleInfos] ([URId], [UserId], [RoleId], [Creator], [CreateTime], [IsDeleted]) VALUES (11, 7, 6, N'admin', CAST(N'2020-07-01 16:11:15.353' AS DateTime), 0)
INSERT [dbo].[UserRoleInfos] ([URId], [UserId], [RoleId], [Creator], [CreateTime], [IsDeleted]) VALUES (13, 8, 2, N'admin', CAST(N'2020-11-13 11:54:47.530' AS DateTime), 0)
INSERT [dbo].[UserRoleInfos] ([URId], [UserId], [RoleId], [Creator], [CreateTime], [IsDeleted]) VALUES (14, 9, 2, N'admin', CAST(N'2021-01-25 11:17:15.733' AS DateTime), 0)
INSERT [dbo].[UserRoleInfos] ([URId], [UserId], [RoleId], [Creator], [CreateTime], [IsDeleted]) VALUES (16, 9, 6, N'admin', CAST(N'2021-01-25 11:22:22.033' AS DateTime), 0)
INSERT [dbo].[UserRoleInfos] ([URId], [UserId], [RoleId], [Creator], [CreateTime], [IsDeleted]) VALUES (17, 10, 6, N'admin', CAST(N'2021-03-10 20:29:06.257' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[UserRoleInfos] OFF
/****** Object:  StoredProcedure [dbo].[makePerNo]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[makePerNo]
as
declare @newPerNo varchar(20)
select @newPerNo =(select top 1 PerchaseNo from PerchaseInStoreInfos where convert(varchar(8),getdate(),112)=substring(PerchaseNo,5,8)order by PerchaseNo desc)
if (@newPerNo is null)  
 begin   
 set @newPerNo='CGD-'+convert(varchar(8),getdate(),112)+'-0001'   
 end
 else  
 begin   
 --set @newPerNo=convert(varchar(20),(convert(int,@newPerNo)+1)) 
 declare @len int,@lastNo int,@strLastNo varchar(4),@n int,@tempNo varchar(4)
 set @lastNo=convert(int,substring(@newPerNo,14,4))+1
set @len=len(@lastNo)
set @tempNo=@lastNo
-- if (@len =1)
-- begin 
--    set @strLastNo='000'+ convert(varchar(4),@lastNo);
--end
-- else if (@len =2) 
-- begin
--  set @strLastNo='00'+convert(varchar(4),@lastNo);
--  end
-- else if  (@len =3 )
-- begin
-- set @strLastNo='0'+ convert(varchar(4),@lastNo);
-- end
set @n=0;
while @n<(4-@len)
begin
    set @tempNo='0'+ convert(varchar,@tempNo);
	set @n=@n+1
end
set @strLastNo=@tempNo
 set @newPerNo='CGD-'+convert(varchar(8),getdate(),112)+'-'+@strLastNo
 end
 select @newPerNo



GO
/****** Object:  StoredProcedure [dbo].[makeSaleNo]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[makeSaleNo]
as
declare @newSaleNo varchar(20)
select @newSaleNo =(select top 1 SaleOutNo from SaleOutStoreInfos where convert(varchar(8),getdate(),112)=substring(SaleOutNo,5,8)order by SaleOutNo desc)
if (@newSaleNo is null)  
 begin   
 set @newSaleNo='XSD-'+convert(varchar(8),getdate(),112)+'-0001'   
 end
 else  
 begin   
 declare @len int,@lastNo int,@strLastNo varchar(4)
 set @lastNo=convert(int,substring(@newSaleNo,14,4))+1
 set @len=len(@lastNo)
 if (@len =1)
 begin 
    set @strLastNo='000'+ convert(varchar(4),@lastNo);
end
 else if (@len =2) 
 begin
  set @strLastNo='00'+convert(varchar(4),@lastNo);
  end
 else if  (@len =3 )
 begin
 set @strLastNo='0'+ convert(varchar(4),@lastNo);
 end
 set @newSaleNo='CGD-'+convert(varchar(8),getdate(),112)+'-'+@strLastNo
 end
 select @newSaleNo



GO
/****** Object:  StoredProcedure [dbo].[makeStockNo]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[makeStockNo]
as
declare @newStockNo varchar(20)
select @newStockNo =(select top 1 StockNo from StockStoreInfos where convert(varchar(8),getdate(),112)=substring(StockNo,5,8)order by StockNo desc)
if (@newStockNo is null)  
 begin   
 set @newStockNo='KCD-'+convert(varchar(8),getdate(),112)+'-0001'   
 end
 else  
 begin   
 declare @len int,@lastNo int,@strLastNo varchar(4)
 set @lastNo=convert(int,substring(@newStockNo,14,4))+1
 set @len=len(@lastNo)
 if (@len =1)
 begin 
    set @strLastNo='000'+ convert(varchar(4),@lastNo);
end
 else if (@len =2) 
 begin
  set @strLastNo='00'+convert(varchar(4),@lastNo);
  end
 else if  (@len =3 )
 begin
 set @strLastNo='0'+ convert(varchar(4),@lastNo);
 end
 set @newStockNo='KCD-'+convert(varchar(8),getdate(),112)+'-'+@strLastNo
 end
 select @newStockNo



GO
/****** Object:  StoredProcedure [dbo].[proc_GetGoodsPage]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[proc_GetGoodsPage]
@typeId int,
@keywords nvarchar(200),
@sql nvarchar(max),
@startIndex int,
@endIndex int
as
begin
   declare @sqlPage nvarchar(max),@strWhere varchar(max)
   set  @strWhere='';
   if @typeId>0
     set @strWhere= 'and (GTypeId='+convert(varchar,@typeId)+' or GTypeId in (select GTypeId from GoodsTypeInfos where ParentId='+convert(varchar,@typeId)+'))';
   if @keywords <> ''
     set @strWhere+=' and (GoodsNo like ''%'+@keywords+'%'' or GoodsName like ''%'+@keywords+'%'' or GoodsPYNo like ''%'+@keywords+'%'')';
   set @sqlPage='WITH temp AS ('+@sql+@strWhere+') SELECT count(*) FROM temp;';
   set @sqlPage=@sqlPage+'with temp as ('+@sql+@strWhere+') SELECT * FROM temp WHERE Id BETWEEN '+CONVERT(varchar,@startIndex)+' AND '+CONVERT(varchar,@endIndex) ;
   exec (@sqlPage);
end

GO
/****** Object:  StoredProcedure [dbo].[proc_GetUnitPage]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[proc_GetUnitPage]
@typeId int,
@keywords nvarchar(200),
@sql nvarchar(max),
@startIndex int,
@endIndex int
as
begin
   declare @sqlPage nvarchar(max),@strWhere varchar(max)
   set  @strWhere='';
   if @typeId>0
     set @strWhere= 'and (UTypeId='+convert(varchar,@typeId)+' or UTypeId in (select UTypeId from UnitTypeInfos where ParentId='+convert(varchar,@typeId)+'))';
   if @keywords <> ''
     set @strWhere+=' and (UnitNo like ''%'+@keywords+'%'' or UnitName like ''%'+@keywords+'%'' or UnitPYNo like ''%'+@keywords+'%'' or FullAddress like ''%'+@keywords+'%'' or ContactPerson like ''%'+@keywords+'%'')';
   set @sqlPage='WITH temp AS ('+@sql+@strWhere+') SELECT count(*) FROM temp;';
   set @sqlPage=@sqlPage+'with temp as ('+@sql+@strWhere+') SELECT * FROM temp WHERE Id BETWEEN '+CONVERT(varchar,@startIndex)+' AND '+CONVERT(varchar,@endIndex) ;
   exec (@sqlPage);
end



GO
/****** Object:  StoredProcedure [dbo].[proc_Page]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[proc_Page]
@sql nvarchar(max),
@startIndex int,
@endIndex int
as
begin
   declare @sqlPage nvarchar(max)
   set @sqlPage='WITH temp AS ('+@sql+') SELECT count(*) FROM temp;';
   set @sqlPage=@sqlPage+'with temp as ('+@sql+') SELECT * FROM temp WHERE row BETWEEN '+CONVERT(varchar,@startIndex)+' AND '+CONVERT(varchar,@endIndex) ;
   exec (@sqlPage);
end


GO
/****** Object:  StoredProcedure [dbo].[sp_BackupDB]    Script Date: 2021/3/19 10:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[sp_BackupDB]
     @savePath nvarchar(4000) -- 备份数据库保存位置(目录)   
     ,@dbName nvarchar(4000) -- 需要进行备份的数据库
     ,@bakName nvarchar(4000) -- 备份文件的名称(不含扩展名)
 as begin
     declare @sql nvarchar(4000)
     /* 验证路径 */
     if(charindex('/',reverse(@savePath))!=1) begin
         set @savePath=@savePath+'/'
     end
     /* 拼SQL并执行 */
     set @sql='backup database '+@dbName+' to disk='''+@savePath+@bakName+'.bak'''
     exec sp_executesql @sql
     
     /* 返回执行结果(1=成功,0=失败) */
     if(@@error=0) begin
         return 1
     end
     return 0
 end



GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[21] 2[31] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "GoodsInfos"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 133
               Right = 199
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "GoodsTypeInfos"
            Begin Extent = 
               Top = 6
               Left = 237
               Bottom = 133
               Right = 392
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewGoodsInfos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewGoodsInfos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[1] 2[12] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "m"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 227
            End
            DisplayFlags = 280
            TopColumn = 7
         End
         Begin Table = "p"
            Begin Extent = 
               Top = 7
               Left = 275
               Bottom = 170
               Right = 454
            End
            DisplayFlags = 280
            TopColumn = 4
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 2484
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewMenuInfos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewMenuInfos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[12] 2[29] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "GoodsInfos"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 133
               Right = 199
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "PerchaseGoodsInfos"
            Begin Extent = 
               Top = 6
               Left = 237
               Bottom = 133
               Right = 387
            End
            DisplayFlags = 280
            TopColumn = 7
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewPerGoodsInfos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewPerGoodsInfos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[57] 4[3] 3[16] 2) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "p"
            Begin Extent = 
               Top = 22
               Left = 98
               Bottom = 149
               Right = 287
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "pg"
            Begin Extent = 
               Top = 0
               Left = 376
               Bottom = 127
               Right = 526
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "u"
            Begin Extent = 
               Top = 217
               Left = 228
               Bottom = 373
               Right = 422
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "g"
            Begin Extent = 
               Top = 182
               Left = 471
               Bottom = 382
               Right = 698
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "s"
            Begin Extent = 
               Top = 216
               Left = 16
               Bottom = 343
               Right = 172
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 2100
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewPerGoodsQuery'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewPerGoodsQuery'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[46] 4[5] 2[48] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "StockChangeInfos"
            Begin Extent = 
               Top = 44
               Left = 112
               Bottom = 171
               Right = 281
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "ViewPerGoodsQuery"
            Begin Extent = 
               Top = 9
               Left = 463
               Bottom = 244
               Right = 677
            End
            DisplayFlags = 280
            TopColumn = 10
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewPerStockGoodsChangeInfos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewPerStockGoodsChangeInfos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "GoodsInfos"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 133
               Right = 199
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "SaleGoodsInfos"
            Begin Extent = 
               Top = 6
               Left = 237
               Bottom = 133
               Right = 391
            End
            DisplayFlags = 280
            TopColumn = 7
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewSaleGoodsInfos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewSaleGoodsInfos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[56] 4[7] 2[31] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "s"
            Begin Extent = 
               Top = 0
               Left = 81
               Bottom = 127
               Right = 241
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "sg"
            Begin Extent = 
               Top = 7
               Left = 522
               Bottom = 160
               Right = 676
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "u"
            Begin Extent = 
               Top = 206
               Left = 0
               Bottom = 333
               Right = 167
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "g"
            Begin Extent = 
               Top = 78
               Left = 274
               Bottom = 205
               Right = 435
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "st"
            Begin Extent = 
               Top = 266
               Left = 266
               Bottom = 441
               Right = 456
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "sgs"
            Begin Extent = 
               Top = 216
               Left = 669
               Bottom = 373
               Right = 872
            End
            DisplayFlags = 280
            TopColumn = 6
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
    ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewSaleGoodsQuery'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'     Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewSaleGoodsQuery'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewSaleGoodsQuery'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[68] 4[6] 2[25] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -342
         Left = 0
      End
      Begin Tables = 
         Begin Table = "StockChangeInfos"
            Begin Extent = 
               Top = 438
               Left = 117
               Bottom = 707
               Right = 331
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ViewSaleGoodsQuery"
            Begin Extent = 
               Top = 367
               Left = 621
               Bottom = 754
               Right = 913
            End
            DisplayFlags = 280
            TopColumn = 14
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewSaleStockGoodsChangeInfos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewSaleStockGoodsChangeInfos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[38] 4[5] 2[57] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "GoodsInfos"
            Begin Extent = 
               Top = 6
               Left = 185
               Bottom = 133
               Right = 346
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "StoreGoodsStockInfos"
            Begin Extent = 
               Top = 0
               Left = 475
               Bottom = 127
               Right = 637
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "StoreInfos"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 265
               Right = 194
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "StockStoreInfos"
            Begin Extent = 
               Top = 193
               Left = 426
               Bottom = 320
               Right = 584
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "GoodsTypeInfos"
            Begin Extent = 
               Top = 11
               Left = 0
               Bottom = 138
               Right = 155
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
      ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewStockGoodsQuery'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'   Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewStockGoodsQuery'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewStockGoodsQuery'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "StoreInfos"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 133
               Right = 194
            End
            DisplayFlags = 280
            TopColumn = 6
         End
         Begin Table = "StoreTypeInfos"
            Begin Extent = 
               Top = 6
               Left = 232
               Bottom = 133
               Right = 385
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewStoreInfos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewStoreInfos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[44] 4[17] 2[25] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -96
         Left = 0
      End
      Begin Tables = 
         Begin Table = "GoodsInfos"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 133
               Right = 199
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "StoreGoodsStockInfos"
            Begin Extent = 
               Top = 6
               Left = 237
               Bottom = 133
               Right = 399
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2535
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewStoreStockUpDownInfos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewStoreStockUpDownInfos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[50] 4[6] 2[30] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ViewStockGoodsQuery"
            Begin Extent = 
               Top = 42
               Left = 172
               Bottom = 238
               Right = 334
            End
            DisplayFlags = 280
            TopColumn = 8
         End
         Begin Table = "StockChangeInfos"
            Begin Extent = 
               Top = 9
               Left = 456
               Bottom = 176
               Right = 657
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewStStockGoodsChangeInfos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewStStockGoodsChangeInfos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[52] 4[22] 2[12] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "GoodsInfos"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 133
               Right = 199
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "StStockGoodsInfos"
            Begin Extent = 
               Top = 6
               Left = 237
               Bottom = 179
               Right = 472
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewStStockGoodsInfos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewStStockGoodsInfos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ToolGroupInfos"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 216
               Right = 254
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ToolMenuInfos"
            Begin Extent = 
               Top = 7
               Left = 289
               Bottom = 265
               Right = 547
            End
            DisplayFlags = 280
            TopColumn = 3
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewToolMenuInfos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewToolMenuInfos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "UnitInfos"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 133
               Right = 205
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UnitTypeInfos"
            Begin Extent = 
               Top = 6
               Left = 243
               Bottom = 133
               Right = 398
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewUnitInfos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewUnitInfos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "UserRoleInfos"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 133
               Right = 188
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "UserInfos"
            Begin Extent = 
               Top = 6
               Left = 226
               Bottom = 116
               Right = 370
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "RoleInfos"
            Begin Extent = 
               Top = 6
               Left = 408
               Bottom = 133
               Right = 558
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewUserRoleInfos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewUserRoleInfos'
GO
USE [master]
GO
ALTER DATABASE [PSIDBase] SET  READ_WRITE 
GO
