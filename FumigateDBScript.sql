--Created by Joseph Dittli 3/24/2020.  This script can be used to re-create the database tables and objects.

USE [Fumigate_Live]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 3/24/2020 10:14:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Permissions](
	[Id] [int] NOT NULL,
	[Name] [nchar](10) NOT NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Priority](
	[Id] [int] NOT NULL,
	[Name] [nchar](20) NOT NULL,
 CONSTRAINT [PK_Priority] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Status](
	[Id] [int] NOT NULL,
	[Name] [nchar](20) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Users](
	[UserId] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Ticket](
	[TicketId] [int] NOT NULL,
	[TicketName] [nvarchar](50) NULL,
	[Author] [int] NOT NULL,
	[CreationDate] [datetime] NULL,
	[Title] [nvarchar](50) NULL,
	[Priority] [int] not NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD FOREIGN KEY([Author])
REFERENCES [dbo].[Users] ([UserId])
GO

ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD FOREIGN KEY([Priority])
REFERENCES [dbo].[Priority] ([Id])
GO


CREATE TABLE [dbo].[TicketVersion](
	[ID] [int] NOT NULL,
	[Version] [int] NOT NULL,
	[TicketId] [int] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[Status] [int] not NULL,
	[AssignedTo] [int] NOT NULL,
	[Comment] [text] NULL,
 CONSTRAINT [PK_TicketVersion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[TicketVersion]  WITH CHECK ADD FOREIGN KEY([AssignedTo])
REFERENCES [dbo].[Users] ([UserId])
GO

ALTER TABLE [dbo].[TicketVersion]  WITH CHECK ADD FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([UserId])
GO

ALTER TABLE [dbo].[TicketVersion]  WITH CHECK ADD FOREIGN KEY([TicketId])
REFERENCES [dbo].[Ticket] ([TicketId])
GO

ALTER TABLE [dbo].[TicketVersion]  WITH CHECK ADD FOREIGN KEY([Status])
REFERENCES [dbo].[Status] ([Id])
GO


CREATE TABLE [dbo].[UserPermissionsLink](
	[Id] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[PermissionId] [int] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UserPermissionsLink]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO

ALTER TABLE [dbo].[UserPermissionsLink]  WITH CHECK ADD FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permissions] ([Id])
GO

CREATE VIEW [dbo].[TicketGrid]
AS
SELECT        tick.TicketId, tick.TicketName, tick.Author, tick.CreationDate, tick.Title, tick.Priority, tVersion.ID, tVersion.Version, tVersion.TicketId AS Expr1, tVersion.ModifiedBy, tVersion.ModificationDate, tVersion.Status, tVersion.AssignedTo, 
                         tVersion.Comment
FROM            dbo.Ticket AS tick INNER JOIN
                         dbo.TicketVersion AS tVersion ON tick.TicketId = tVersion.TicketId
WHERE        (NOT EXISTS
                             (SELECT        ID, Version, TicketId, ModifiedBy, ModificationDate, Status, AssignedTo, Comment
                               FROM            dbo.TicketVersion AS tVersion2
                               WHERE        (TicketId = tVersion.TicketId) AND (Version > tVersion.Version)))
GO