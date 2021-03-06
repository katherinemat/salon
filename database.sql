USE [hair_salon]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 3/3/2017 1:43:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[notes] [varchar](255) NULL,
	[stylist_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[stylists]    Script Date: 3/3/2017 1:43:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stylists](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[clients] ON 

INSERT [dbo].[clients] ([id], [name], [notes], [stylist_id]) VALUES (3, N'Jamieson', N'curly hair', 0)
INSERT [dbo].[clients] ([id], [name], [notes], [stylist_id]) VALUES (2, N'Christina', N'be careful with bleach', 2)
SET IDENTITY_INSERT [dbo].[clients] OFF
SET IDENTITY_INSERT [dbo].[stylists] ON 

INSERT [dbo].[stylists] ([id], [name]) VALUES (3, N'Pat Hughes')
INSERT [dbo].[stylists] ([id], [name]) VALUES (2, N'Nicole')
SET IDENTITY_INSERT [dbo].[stylists] OFF
