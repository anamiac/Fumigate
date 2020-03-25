USE [Fumigate_Live]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 3/24/2020 10:14:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[UserId] [int] NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Rights] [nvarchar](50) NULL,
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
	[Priority] [int] NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD FOREIGN KEY([Author])
REFERENCES [dbo].[Users] ([UserId])
GO



CREATE TABLE [dbo].[TicketVersion](
	[ID] [int] NOT NULL,
	[Version] [int] NOT NULL,
	[TicketId] [int] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModificationDate] [datetime] NULL,
	[Status] [int] NULL,
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


