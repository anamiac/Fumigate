USE [Fumigate_Live]
GO

INSERT INTO [dbo].[Users] VALUES (1, 'Steve Jobs', 'Steve', 'steve.jobs@gmail.com')
INSERT INTO [dbo].[Users] VALUES (2, 'Bill Gates', 'Bill', 'bill.gates@gmail.com')
INSERT INTO [dbo].[Users] VALUES (3, 'Alan Turing', 'Alan', 'alan.turing@gmail.com')
INSERT INTO [dbo].[Users] VALUES (4, 'Charles Babbage', 'Charles', 'charles.babbage@gmail.com')

INSERT INTO [dbo].[Permissions] VALUES (1, 'Admin', 'Permission to create new users and assign new user rights.')
INSERT INTO [dbo].[Permissions] VALUES (1, 'Manager', 'Permission to assign Urgent Priorty to tickets.')    

INSERT INTO [dbo].[UserPermissionsLink] VALUES (1, 1, 1)
INSERT INTO [dbo].[UserPermissionsLink] VALUES (2, 2, 1)
INSERT INTO [dbo].[UserPermissionsLink] VALUES (3, 3, 2)
INSERT INTO [dbo].[UserPermissionsLink] VALUES (4, 2, 2)
INSERT INTO [dbo].[UserPermissionsLink] VALUES (5, 1, 2)

INSERT INTO [dbo].[Priority] VALUES (1, 'Low')
INSERT INTO [dbo].[Priority] VALUES (2, 'Medium')
INSERT INTO [dbo].[Priority] VALUES (3, 'High')
INSERT INTO [dbo].[Priority] VALUES (4, 'Urgent')

INSERT INTO [dbo].[Status] VALUES (1, 'Created')
INSERT INTO [dbo].[Status] VALUES (2, 'Open')
INSERT INTO [dbo].[Status] VALUES (3, 'Answered')
INSERT INTO [dbo].[Status] VALUES (4, 'ReOpened')
INSERT INTO [dbo].[Status] VALUES (5, 'Closed')

insert into [dbo].Ticket values (1, 'F1.4', 4, '2020-03-24 00:00:00.000', 'Update Database Tables', 3)
insert into [dbo].Ticket values (2, 'F2.4', 4, '2020-03-24 00:00:00.000', 'Create View for Tickets and latest version', 2)

INSERT INTO [dbo].[TicketVersion] VALUES (1, 1, 1, 4, '2020-03-24 00:00:00.000', 1, 3, 'Creation')
INSERT INTO [dbo].[TicketVersion] VALUES (2, 2, 1, 3, '2020-03-24 00:00:00.000', 3, 4, 'Created several new Tables')
INSERT INTO [dbo].[TicketVersion] VALUES (3, 1, 2, 4, '2020-03-24 00:00:00.000', 1, 3, 'Creation')
GO
