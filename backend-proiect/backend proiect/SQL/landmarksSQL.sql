--TRUNCATE TABLE [dbo].[Landmarks];
--GO
INSERT INTO [dbo].[Landmarks](Name, Description, CountryId) VALUES ('The Eiffel Tower', 
'A major symbol of Paris, the Eiffel Tower is located in the Champ de Mars park and was constructed from 1887 to 1889. 
The tower is 324 metres (1,063 ft) tall and the tallest structure in Paris.', 1);
GO
INSERT INTO [dbo].[Landmarks](Name, Description, CountryId) VALUES ('The Louvre Museum',
'The Louvre Museum is the world’s most-visited art museum, with a collection that spans works from ancient civilizations to the mid-19th century.
It is the home of some of the best-known works of art, including the Mona Lisa and the Venus de Milo.', 1);
GO
INSERT INTO [dbo].[Landmarks](Name, Description, CountryId) VALUES ('The Arc de Triomphe',
'The famous Arc de Triomphe stands in the center of the Place de l’Étoile(also known as Place Charles de Gaulle) in Paris, where 12 straight avenues meet, 
including the Champs-Élysées. This French monument was built between 1806 and 1836 to honour those who fought and died for France in the French Revolutionary 
and Napoleonic Wars. Beneath its vault lies the Tomb of the Unknown Soldier from World War I.', 1);
GO
INSERT INTO [dbo].[Landmarks](Name, Description, CountryId) VALUES ('Sacré-Cœur',
'Sacré-Cœur, or the "Sacred Heart" Basilica is a modern Catholic church located in Paris on top of Montmartre hill, the highest point in the city.
Its Construction began in 1875 and was completed in 1914.', 1);
GO
INSERT INTO [dbo].[Landmarks](Name, Description, CountryId) VALUES ('The Palace of Versailles',
'The Palace of Versailles is a former royal residence located in Versailles, about 12 miles (19 km) west of Paris.', 1);
GO


INSERT INTO [dbo].[Landmarks](Name, Description, CountryId) VALUES ('The Colosseum', 
'The Colosseum is an oval amphitheatre in the centre of the city of Rome, just east of the Roman Forum.
It is the largest ancient amphitheatre ever built, and is still the largest standing amphitheatre in the world today.', 2);
GO
INSERT INTO [dbo].[Landmarks](Name, Description, CountryId) VALUES ('The Roman Forum', 
'The Roman Forum, the most important archaeological site in Rome, was the center of the city in ancient Rome.
The first buildings were erected at the beginning of the 7th century BC, such as the Senate (Curia) or the temple of Saturn.
In the present day you can find here lots of ruins of ancient markets and administrative or religious buildings.', 2);
GO
INSERT INTO [dbo].[Landmarks](Name, Description, CountryId) VALUES ('Trevi Fountain', 
'The Trevi Fountain is the best known fountain in Europe and the biggest in Rome. 
Built between 1732 and 1762, it depicts the sea god Oceanus (Neptune), with horses, tritons, and shells.', 2);
GO
INSERT INTO [dbo].[Landmarks](Name, Description, CountryId) VALUES ('The Leaning Tower of Pisa', 
'The Leaning Tower of Pisa is the campanile, or freestanding bell tower, of the cathedral of the Italian city of Pisa, 
known worldwide for its nearly four-degree lean, the result of an unstable foundation.', 2);
GO
INSERT INTO [dbo].[Landmarks](Name, Description, CountryId) VALUES ('The Milan Cathedral', 
'The cathedral of Milan, called Duomo di Milano in Italian, is a vast Gothic-style cathedral, located in the heart of Milan.
It is the largest Gothic cathedral in the world and the largest church in Italy.', 2);
GO
INSERT INTO [dbo].[Landmarks](Name, Description, CountryId) VALUES ('Saint Mark’s Basilica', 
'Saint Mark’s Basilica is the cathedral church of the Roman Catholic Patriarchate of Venice in northern Italy.',2);
GO


INSERT INTO [dbo].[Landmarks](Name, Description, CountryId) VALUES ('The Acropolis of Athens', 
'The Acropolis of Athens is an ancient citadel located on a rocky outcrop above the city of Athens 
and contains the remains of several ancient buildings of great architectural and historical significance, the most famous being the Parthenon.', 3);
GO
INSERT INTO [dbo].[Landmarks](Name, Description, CountryId) VALUES ('Knossos', 
'Also referred to as Europe’s oldest city, Knossos is the largest Bronze Age archaeological site on the island of Crete. 
Here lays the ruins of the Knossos Palace, which served as the political and ceremonial centre of the city during the Minion Civilization in the Bronze Age.', 3);
GO
INSERT INTO [dbo].[Landmarks](Name, Description, CountryId) VALUES ('Palace of the Grand Master of the Knights', 
'The Palace of the Grand Master of the Knights is a medieval castle in the city of Rhodes, on the island of Rhodes in Greece.
It is one of the few examples of Gothic architecture in Greece.', 3);
GO
INSERT INTO [dbo].[Landmarks](Name, Description, CountryId) VALUES ('The Waterfalls of Edessa', 
'The Edessa Waterfalls are the main tourist attraction in Edessa, a city in northern Greece.', 3);
GO


INSERT INTO [dbo].[Landmarks](Name, Description, CountryId) VALUES ('The Great Pyramid of Giza', 
'The Great Pyramid of Giza is the oldest and largest of the pyramids in the Giza pyramid complex bordering present-day Giza in Greater Cairo, Egypt. 
It is the oldest of the Seven Wonders of the Ancient World, and the only one still in existence.', 4);
GO
INSERT INTO [dbo].[Landmarks](Name, Description, CountryId) VALUES ('The Great Sphinx of Giza', 
'The Great Sphinx of Giza is a limestone statue of a reclining sphinx, a mythical creature with the head of a man, and the body of a lion.
Facing directly from west to east, it stands in the Giza pyramid complex on the west bank of the Nile in Giza, Egypt.', 4);
GO
INSERT INTO [dbo].[Landmarks](Name, Description, CountryId) VALUES ('The Karnak Temple', 
'Other than the pyramids, the most popular place to visit in Egypt is the Karnak Temple complex in Luxor on the banks of the river Nile. 
Its construction began around 2000 BC and continued over millennia, making it the largest ancient religious site on earth.', 4);
GO
INSERT INTO [dbo].[Landmarks](Name, Description, CountryId) VALUES ('Abu Simbel', 
'Abu Simbel is an archaeological site comprising two massive rock temples in southern Egypt on the western bank of Lake Nasser. 
Their entrances are adorned with colossal standing guard statues. The temples were originally carved out of the mountainside 
during the reign of Pharaoh Ramesses The Great in the 13th century BC. The complex was relocated in its entirety by UNESCO in the 1960s 
to save it from being submerged during the creation of Lake Nasser, the artificial water reservoir formed after the building of the Aswan High Dam on the Nile River.', 4);
GO
INSERT INTO [dbo].[Landmarks](Name, Description, CountryId) VALUES ('Valley of the Kings', 
'The Valley of the Kings is one of the most important archeological sites in Egypt that is home to over 60 ancient tombs and burial chambers 
belonging to Pharaohs and powerful noble, including the likes of Tutankhamun, Seti I, and Ramses II. 
The Ancient Egyptians carved the tombs into rocks in the valley over a period of nearly 500 years from the 16th to 11th century BC.', 4);
GO


SELECT * FROM [dbo].[Landmarks];
GO

DBCC CHECKIDENT ('Landmarks', RESEED, 20);
GO


--Select IDENT_CURRENT ('Landmarks');
--Go
