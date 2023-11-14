USE [MSM]
GO
/****** Object:  Table [dbo].[Bill1]    Script Date: 29/06/2021 3:21:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bill1](
	[sno] [bigint] IDENTITY(1,1) NOT NULL,
	[bautobill] [bigint] NOT NULL,
	[pname] [nchar](40) NOT NULL,
	[pquantity] [money] NULL,
	[mrp] [money] NOT NULL,
	[pid] [bigint] NULL,
	[total] [money] NULL,
	[createddate] [varchar](10) NULL,
	[editdate] [varchar](10) NULL,
	[unit] [varchar](20) NULL,
 CONSTRAINT [PK_Bill1] PRIMARY KEY CLUSTERED 
(
	[sno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Combodata]    Script Date: 29/06/2021 3:21:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Combodata](
	[num] [bigint] IDENTITY(1,1) NOT NULL,
	[states] [varchar](50) NULL,
	[ctype] [nchar](10) NULL,
 CONSTRAINT [PK_Combodata] PRIMARY KEY CLUSTERED 
(
	[num] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CompanyMaster]    Script Date: 29/06/2021 3:21:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyMaster](
	[cid] [bigint] IDENTITY(1,1) NOT NULL,
	[cname] [nchar](50) NULL,
	[regno] [nchar](15) NULL,
	[address] [nchar](50) NULL,
	[contact] [nchar](10) NULL,
	[email] [nchar](90) NULL,
	[city] [nchar](10) NULL,
	[country] [nchar](20) NULL,
 CONSTRAINT [PK_CompanyMaster] PRIMARY KEY CLUSTERED 
(
	[cid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[custobilldetail1]    Script Date: 29/06/2021 3:21:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[custobilldetail1](
	[autobill] [bigint] IDENTITY(1,1) NOT NULL,
	[mannualbill] [varchar](20) NULL,
	[CNO] [bigint] NULL,
	[Custoname] [varchar](99) NULL,
	[Address] [varchar](50) NULL,
	[State] [varchar](20) NULL,
	[City] [varchar](15) NULL,
	[Regno] [varchar](15) NULL,
	[Contactno] [nchar](15) NULL,
	[Custotype] [nchar](10) NULL,
	[date] [varchar](10) NULL,
	[Operator] [varchar](20) NULL,
	[Subtotal] [money] NULL,
	[discpc] [money] NULL,
	[discamt] [money] NULL,
	[balanceamt] [money] NULL,
	[taxpc] [money] NULL,
	[taxamt] [money] NULL,
	[totalamt] [money] NULL,
	[modifieddate] [varchar](10) NULL,
	[district] [varchar](20) NULL,
	[country] [varchar](30) NULL,
	[challanno] [varchar](20) NULL,
	[Email] [varchar](90) NULL,
	[inword] [varchar](200) NULL,
 CONSTRAINT [PK_custobilldetail1] PRIMARY KEY CLUSTERED 
(
	[autobill] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 29/06/2021 3:21:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[CNO] [bigint] IDENTITY(1,1) NOT NULL,
	[Address] [varchar](50) NULL,
	[State] [varchar](20) NULL,
	[City] [varchar](10) NULL,
	[Regno] [varchar](15) NULL,
	[Contactno] [nchar](15) NULL,
	[Email] [varchar](90) NULL,
	[Custotype] [nchar](10) NULL,
	[date] [varchar](10) NULL,
	[operator] [varchar](20) NULL,
	[modifiedby] [varchar](20) NULL,
	[district] [varchar](20) NULL,
	[country] [varchar](30) NULL,
	[Custoname] [varchar](99) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[internalprocess]    Script Date: 29/06/2021 3:21:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[internalprocess](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[pid] [bigint] NULL,
	[pname] [nchar](50) NULL,
	[quantity] [money] NULL,
	[itemcode] [varchar](50) NULL,
	[date] [nchar](10) NULL,
	[operator] [nchar](15) NULL,
	[modifieddate] [nchar](10) NULL,
	[modifiedby] [nchar](15) NULL,
	[nextprocess] [varchar](20) NULL,
	[status] [varchar](20) NULL,
 CONSTRAINT [PK_internalprocess] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[prcustomer]    Script Date: 29/06/2021 3:21:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[prcustomer](
	[vnum] [bigint] IDENTITY(1,1) NOT NULL,
	[custonum] [bigint] NULL,
	[vcustoname] [varchar](99) NULL,
	[purchasebillno] [nchar](15) NULL,
	[contactno] [nchar](15) NULL,
	[regno] [nchar](15) NULL,
	[address] [varchar](80) NULL,
	[country] [varchar](20) NULL,
	[purchasetype] [nchar](10) NULL,
	[voucherdate] [nchar](10) NULL,
	[purchasedate] [nchar](10) NULL,
	[modifieddate] [nchar](10) NULL,
	[operator] [nchar](20) NULL,
	[modifiedoperator] [nchar](20) NULL,
	[subtotal] [money] NULL,
	[dispc] [money] NULL,
	[discamt] [money] NULL,
	[balanceamt] [money] NULL,
	[taxpc] [money] NULL,
	[taxamt] [money] NULL,
	[totalamt] [money] NULL,
	[status] [varchar](50) NULL,
	[clearedby] [nchar](20) NULL,
	[cleareddate] [nchar](10) NULL,
	[prreasion] [varchar](200) NULL,
 CONSTRAINT [PK_prcustomer] PRIMARY KEY CLUSTERED 
(
	[vnum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[prproduct]    Script Date: 29/06/2021 3:21:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prproduct](
	[sno] [bigint] IDENTITY(1,1) NOT NULL,
	[pvnum] [bigint] NOT NULL,
	[pid] [bigint] NULL,
	[prodname] [nchar](40) NULL,
	[prodquantity] [money] NULL,
	[unit] [nchar](15) NULL,
	[purchaseprice] [money] NULL,
	[purchasetotal] [money] NULL,
	[createddate] [nchar](10) NULL,
	[modifieddate] [nchar](10) NULL,
 CONSTRAINT [PK_prproduct] PRIMARY KEY CLUSTERED 
(
	[sno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[purchasebill2]    Script Date: 29/06/2021 3:21:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[purchasebill2](
	[lno] [bigint] IDENTITY(1,1) NOT NULL,
	[pid] [bigint] NULL,
	[prodname] [nchar](40) NULL,
	[prodquantity] [money] NULL,
	[purchaseprice] [money] NULL,
	[purchasetotal] [money] NULL,
	[psno] [bigint] NULL,
	[createddate] [varchar](10) NULL,
	[editdate] [varchar](10) NULL,
	[unit] [varchar](20) NULL,
 CONSTRAINT [PK_purchasebill2] PRIMARY KEY CLUSTERED 
(
	[lno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[purchasebook2]    Script Date: 29/06/2021 3:21:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[purchasebook2](
	[sno] [bigint] IDENTITY(1,1) NOT NULL,
	[purchasebilno] [nchar](20) NULL,
	[pcno] [bigint] NULL,
	[pcustoname] [varchar](99) NULL,
	[pregno] [nchar](15) NULL,
	[paddress] [nchar](90) NULL,
	[pcontact] [nchar](15) NULL,
	[pcountry] [nchar](15) NULL,
	[ppurchasetype] [nchar](10) NULL,
	[ppurchasedate] [nchar](10) NULL,
	[pmodifieddate] [nchar](10) NULL,
	[poperator] [nchar](15) NULL,
	[psubtotal] [money] NULL,
	[pdiscpc] [money] NULL,
	[pdiscamt] [money] NULL,
	[pbalanceamt] [money] NULL,
	[ptax] [money] NULL,
	[ptaxamt] [money] NULL,
	[ptotalamt] [money] NULL,
	[billdate] [varchar](10) NULL,
 CONSTRAINT [PK_purchasebook2] PRIMARY KEY CLUSTERED 
(
	[sno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[readygoods]    Script Date: 29/06/2021 3:21:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[readygoods](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[pid] [bigint] NULL,
	[pname] [nchar](50) NULL,
	[quantity] [money] NULL,
	[motheritem] [nchar](10) NULL,
	[date] [nchar](10) NULL,
	[operator] [varchar](15) NULL,
	[nextprocess] [varchar](20) NULL,
 CONSTRAINT [PK_readygoods] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[recordbook]    Script Date: 29/06/2021 3:21:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[recordbook](
	[sno] [bigint] IDENTITY(1,1) NOT NULL,
	[pid] [bigint] NULL,
	[rname] [nchar](50) NULL,
	[rquantity] [money] NULL,
	[rprice] [money] NULL,
	[rpurchasebillno] [nchar](15) NULL,
	[rinvoiceno] [nchar](15) NULL,
	[rvoucherno] [nchar](15) NULL,
	[date] [nchar](10) NULL,
	[ruser] [nchar](50) NULL,
	[rstatus] [nchar](50) NULL,
	[rformtype] [nchar](40) NULL,
	[mannualbill] [nchar](15) NULL,
	[salebill] [nchar](15) NULL,
 CONSTRAINT [PK_recordbook] PRIMARY KEY CLUSTERED 
(
	[sno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[srcustomer]    Script Date: 29/06/2021 3:21:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[srcustomer](
	[srn] [bigint] IDENTITY(1,1) NOT NULL,
	[srreturnbillno] [nchar](20) NULL,
	[srcno] [bigint] NULL,
	[srcustoname] [varchar](99) NULL,
	[srregno] [nchar](15) NULL,
	[sraddress] [nchar](90) NULL,
	[srcontact] [nchar](15) NULL,
	[srcountry] [nchar](15) NULL,
	[srsaletype] [nchar](10) NULL,
	[srsaledate] [nchar](10) NULL,
	[srreturndate] [nchar](10) NULL,
	[srmodifieddate] [nchar](10) NULL,
	[sroperator] [nchar](15) NULL,
	[stsubtotal] [money] NULL,
	[srdispc] [money] NULL,
	[srdiscamt] [money] NULL,
	[srbalanceamt] [money] NULL,
	[srtaxpc] [money] NULL,
	[srtaxamt] [money] NULL,
	[sttotalamt] [money] NULL,
	[reason] [varchar](200) NULL,
 CONSTRAINT [PK_srcustomer] PRIMARY KEY CLUSTERED 
(
	[srn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[srproduct]    Script Date: 29/06/2021 3:21:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[srproduct](
	[rno] [bigint] IDENTITY(1,1) NOT NULL,
	[isrn] [bigint] NULL,
	[srpid] [bigint] NULL,
	[srprodname] [nchar](40) NULL,
	[srprodqnty] [money] NULL,
	[srunit] [varchar](20) NULL,
	[srpurchaseprice] [money] NULL,
	[srpurchasetotal] [money] NULL,
	[srcreateddate] [varchar](10) NULL,
	[sreditdate] [varchar](10) NULL,
 CONSTRAINT [PK_srproduct] PRIMARY KEY CLUSTERED 
(
	[rno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[stock]    Script Date: 29/06/2021 3:21:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[stock](
	[pid] [bigint] IDENTITY(1,1) NOT NULL,
	[pname] [nchar](40) NULL,
	[pquantity] [money] NULL,
	[pprice] [money] NULL,
	[pdescription] [nchar](50) NULL,
	[pbrand] [nchar](20) NULL,
	[pstatus] [varchar](20) NULL,
	[mrp] [money] NULL,
	[indate] [varchar](10) NULL,
	[usedby] [varchar](30) NULL,
	[modifiedby] [varchar](30) NULL,
	[unit] [varchar](20) NULL,
 CONSTRAINT [PK_stock] PRIMARY KEY CLUSTERED 
(
	[pid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 29/06/2021 3:21:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[userid] [bigint] IDENTITY(1,1) NOT NULL,
	[usrname] [varchar](20) NOT NULL,
	[loginid] [nchar](20) NOT NULL,
	[password] [varchar](7) NOT NULL,
	[dept] [nchar](10) NULL,
	[status] [nchar](10) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
