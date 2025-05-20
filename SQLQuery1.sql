SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE IF EXISTS [dbo].[Bruger];
DROP TABLE IF EXISTS [dbo].[Lokale];
DROP TABLE IF EXISTS [dbo].[Booking];

-- Tabel: Bruger
CREATE TABLE Bruger (
    ID INT PRIMARY KEY,
    Brugernavn NVARCHAR(50) NOT NULL UNIQUE,
    Adgangskode NVARCHAR(255) NOT NULL,
    Rolle NVARCHAR(50) NOT NULL,
    GruppeID NVARCHAR(50)
);

-- Tabel: Lokale
CREATE TABLE Lokale (
    ID INT PRIMARY KEY,
    Navn NVARCHAR(50),
    Type NVARCHAR(50),
    Kapacitet NVARCHAR(50),
    Udstyr NVARCHAR(100),
    Tilgængelighed BIT,
    HarSmartboard BIT,
    Maksbookinger INT
);

-- Tabel: Booking
CREATE TABLE Booking (
    ID INT PRIMARY KEY,
    Brugernavn NVARCHAR(50),
    BrugerID INT FOREIGN KEY REFERENCES Bruger(ID),
    LokaleID INT FOREIGN KEY REFERENCES Lokale(ID),
    StartTid DATETIME,
    SlutTid DATETIME,
    GruppeID NVARCHAR(50),
    HarSmartboard BIT
);

-- Brugere
INSERT INTO [dbo].[Bruger] VALUES (1, N'Nasra', '12345678', 0)
INSERT INTO [dbo].[Bruger] VALUES (2, N'Samira','87654321', 1)
INSERT INTO [dbo].[Bruger] VALUES (3, N'Signe', '11223344', 2)

-- Lokaler
INSERT INTO [dbo].[Lokale] VALUES (1, N'Mødelokale A', N'MoedeLokale', 30)
INSERT INTO [dbo].[Lokale] VALUES (2, N'Mødelokale B', N'MoedeLokale', 4)
INSERT INTO [dbo].[Lokale] VALUES (3, N'Mødelokale C', N'MoedeLokale', 10)

-- Bookinger
INSERT INTO [dbo].[Booking] VALUES (1, 1, 1, '2025-05-20 10:00:00', 2, 1)
INSERT INTO [dbo].[Booking] VALUES (2, 2, 2, '2025-05-20 14:00:00', 2, 0)
INSERT INTO [dbo].[Booking] VALUES (3, 3, 3, '2025-05-21 09:00:00', 2, 1)

