INSERT INTO [dbo].[Locations](City, Address, LandmarkId) VALUES ('Paris', 'Champ de Mars, 5 Avenue Anatole France, 75007 Paris', 1);
GO

INSERT INTO [dbo].[Locations](City, Address, LandmarkId) VALUES ('Paris', 'Rue de Rivoli, 75001 Paris', 2);
GO

INSERT INTO [dbo].[Locations](City, Address, LandmarkId) VALUES ('Paris', 'Place Charles de Gaulle, 75008 Paris', 3);
GO

INSERT INTO [dbo].[Locations](City, Address, LandmarkId) VALUES ('Paris', '35 Rue du Chevalier de la Barre, 75018 Paris', 4);
GO

INSERT INTO [dbo].[Locations](City, Address, LandmarkId) VALUES ('Versailles', 'Place d’Armes, 78000 Versailles', 5);
GO

INSERT INTO [dbo].[Locations](City, Address, LandmarkId) VALUES ('Rome', 'Piazza del Colosseo, 1, 00184 Roma RM', 6);
GO

INSERT INTO [dbo].[Locations](City, Address, LandmarkId) VALUES ('Rome', 'Via della Salara Vecchia, 5/6, 00186 Roma RM', 7);
GO

INSERT INTO [dbo].[Locations](City, Address, LandmarkId) VALUES ('Rome', 'Piazza di Trevi, 00187 Roma RM', 8);
GO

INSERT INTO [dbo].[Locations](City, Address, LandmarkId) VALUES ('Pisa', 'Piazza del Duomo, 56126 Pisa PI', 9);
GO

INSERT INTO [dbo].[Locations](City, Address, LandmarkId) VALUES ('Milan', 'P.za del Duomo, 20122 Milano MI', 10);
GO

INSERT INTO [dbo].[Locations](City, Address, LandmarkId) VALUES ('Venice', 'P.za San Marco, 328, 30100 Venezia VE', 11);
GO


INSERT INTO [dbo].[Locations](City, Address, LandmarkId) VALUES ('Athens', 'Athens 105 58', 12);
GO

INSERT INTO [dbo].[Locations](City, Address, LandmarkId) VALUES ('Iraklion', null, 13);
GO

INSERT INTO [dbo].[Locations](City, Address, LandmarkId) VALUES ('Rhodes', 'Ippoton, Rodos 851 00', 14);
GO

INSERT INTO [dbo].[Locations](City, Address, LandmarkId) VALUES ('Edessa', 'Tsimiski 2, Edessa 582 00', 15);
GO

INSERT INTO [dbo].[Locations](City, Address, LandmarkId) VALUES ('Giza ', 'Al Haram, Nazlet El-Semman, Al Giza Desert, Giza Governorate, Middle Egypt', 16);
GO

INSERT INTO [dbo].[Locations](City, Address, LandmarkId) VALUES ('Giza ', 'Al Haram, Al Giza Desert, Giza Governorate, Middle Egypt', 17);
GO

INSERT INTO [dbo].[Locations](City, Address, LandmarkId) VALUES ('Luxor ', 'El-Karnak, Luxor, Luxor Governorate, Upper Egypt', 18);
GO

INSERT INTO [dbo].[Locations](City, Address, LandmarkId) VALUES (null, 'Abu Simbel Village, Aswan Governorate, Upper Egypt', 19);
GO

INSERT INTO [dbo].[Locations](City, Address, LandmarkId) VALUES ('Luxor', null, 20);
GO


SELECT * FROM [dbo].[Locations];
GO

DBCC CHECKIDENT ('Locations', RESEED, 20);
GO