--SET IDENTITY_INSERT [dbo].[Countries] ON;
--GO

--SET IDENTITY_INSERT [dbo].[Countries] OFF;
--GO

INSERT INTO [dbo].[Countries](Name) VALUES ('France');
GO
INSERT INTO [dbo].[Countries](Name) VALUES ('Italy');
GO
INSERT INTO [dbo].[Countries](Name) VALUES ('Greece');
GO
INSERT INTO [dbo].[Countries](Name) VALUES ('Egypt');
GO

SELECT * FROM [dbo].[Countries];
GO

DBCC CHECKIDENT ('Countries', RESEED, 4);
GO

--TRUNCATE TABLE [dbo].[Countries];
--GO