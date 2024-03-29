USE [timesheet]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 17.9.2020. 16:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 17.9.2020. 16:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
	[address] [nvarchar](50) NOT NULL,
	[city] [nvarchar](20) NOT NULL,
	[zip] [nvarchar](15) NOT NULL,
	[isDeleted] [bit] NOT NULL,
	[countryID] [int] NOT NULL,
	[concurrency] [timestamp] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 17.9.2020. 16:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](40) NOT NULL,
	[short] [nvarchar](3) NOT NULL,
	[isActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 17.9.2020. 16:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
	[description] [nvarchar](60) NULL,
	[status] [varchar](10) NOT NULL,
	[isDeleted] [bit] NOT NULL,
	[clientID] [int] NOT NULL,
	[leadID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 17.9.2020. 16:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
	[weekly] [float] NOT NULL,
	[username] [nvarchar](20) NOT NULL,
	[email] [nvarchar](30) NOT NULL,
	[password] [char](64) NULL,
	[isActive] [bit] NOT NULL,
	[isAdmin] [bit] NOT NULL,
	[isDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Worktime]    Script Date: 17.9.2020. 16:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Worktime](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](60) NULL,
	[hours] [float] NOT NULL,
	[overtime] [float] NULL,
	[date] [date] NOT NULL,
	[clientID] [int] NOT NULL,
	[projectID] [int] NOT NULL,
	[userID] [int] NOT NULL,
	[categoryID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Client] ADD  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[Country] ADD  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[Project] ADD  DEFAULT ('active') FOR [status]
GO
ALTER TABLE [dbo].[Project] ADD  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD FOREIGN KEY([countryID])
REFERENCES [dbo].[Country] ([id])
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD FOREIGN KEY([clientID])
REFERENCES [dbo].[Client] ([id])
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD FOREIGN KEY([leadID])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Worktime]  WITH CHECK ADD FOREIGN KEY([categoryID])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Worktime]  WITH CHECK ADD FOREIGN KEY([clientID])
REFERENCES [dbo].[Client] ([id])
GO
ALTER TABLE [dbo].[Worktime]  WITH CHECK ADD FOREIGN KEY([projectID])
REFERENCES [dbo].[Project] ([id])
GO
ALTER TABLE [dbo].[Worktime]  WITH CHECK ADD FOREIGN KEY([userID])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD CHECK  (([status]='archived' OR [status]='inactive' OR [status]='active'))
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD CHECK  (([weekly]>=(0) AND [weekly]<=(112)))
GO
ALTER TABLE [dbo].[Worktime]  WITH CHECK ADD CHECK  (([hours]>=(0) AND [hours]<=(16)))
GO
ALTER TABLE [dbo].[Worktime]  WITH CHECK ADD CHECK  (([overtime]>=(0) AND [overtime]<=(8)))
GO
