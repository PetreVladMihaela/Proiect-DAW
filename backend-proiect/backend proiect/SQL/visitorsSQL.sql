INSERT INTO [dbo].[Visitors](Email, Password, FirstName, LastName, Role) VALUES ('EmailAdmin', 'parola', null, null, 'Admin');
GO

INSERT INTO [dbo].[Visitors](Email, Password, FirstName, LastName, Role) VALUES ('email', 'password', 'Rachel', 'Greyson', 'User');
GO

INSERT INTO [dbo].[Visitors](Email, Password, FirstName, LastName, Role) VALUES ('email1', 'p123', 'Lucas', 'Jonson', 'User');
GO

INSERT INTO [dbo].[Visitors](Email, Password, FirstName, LastName, Role) VALUES ('email2', 'p123', 'Sam', 'Taylor', 'User');
GO

INSERT INTO [dbo].[Visitors](Email, Password, FirstName, LastName, Role) VALUES ('test', 'p', null, 'Adams', 'User');
GO

SELECT * FROM [dbo].[Visitors];
GO

--DBCC CHECKIDENT ('Visitors', RESEED, 0);
--GO