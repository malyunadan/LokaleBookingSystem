SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE IF EXISTS [dbo].[Booking];
DROP TABLE IF EXISTS [dbo].[Bruger];
DROP TABLE IF EXISTS [dbo].[Lokale];
DROP TABLE IF EXISTS [dbo].[Rolle];
GO

-- Tabel: Rolle
CREATE TABLE Rolle (
    RolleID INT PRIMARY KEY,
    Navn NVARCHAR(50) NOT NULL UNIQUE
);
GO

-- Indsæt roller
INSERT INTO Rolle (RolleID, Navn) VALUES 
(1, 'Admin'),
(2, 'Elev'),
(3, 'Lærer');
GO

-- Tabel: Bruger
CREATE TABLE Bruger (
    ID INT PRIMARY KEY,
    Brugernavn NVARCHAR(50) NOT NULL UNIQUE,
    Adgangskode NVARCHAR(255) NOT NULL,
    RolleID INT FOREIGN KEY REFERENCES Rolle(RolleID),
    GruppeID NVARCHAR(50)
);
GO

-- Tabel: Lokale
CREATE TABLE Lokale (
    ID INT PRIMARY KEY,
    Navn NVARCHAR(50) NOT NULL,
    Type NVARCHAR(50),
    Kapacitet NVARCHAR(50),
    Udstyr NVARCHAR(100),
    Tilgængelighed BIT,
    HarSmartboard BIT,
    Maksbookinger INT
);
GO

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
GO

-- Indsæt testdata i Bruger
INSERT INTO Bruger (ID, Brugernavn, Adgangskode, RolleID, GruppeID) VALUES
(1, N'Nasra', '12345678', 1, 'G1'),  -- Admin
(2, N'Samira','87654321', 3, 'G2'),  -- Lærer
(3, N'Signe', '11223344', 2, 'G3');  -- Elev
GO

-- Indsæt testdata i Lokale
INSERT INTO Lokale (ID, Navn, Type, Kapacitet, Udstyr, Tilgængelighed, HarSmartboard, Maksbookinger) VALUES
(1, N'Mødelokale A', N'MoedeLokale', '30', 'Projektor, Whiteboard', 1, 1, 3),
(2, N'Mødelokale B', N'MoedeLokale', '4', 'Whiteboard', 1, 0, 2),
(3, N'Mødelokale C', N'MoedeLokale', '10', 'Smartboard', 1, 1, 2);
GO

-- Indsæt testdata i Booking
INSERT INTO Booking (ID, Brugernavn, BrugerID, LokaleID, StartTid, SlutTid, GruppeID, HarSmartboard) VALUES
(1, N'Nasra', 1, 1, '2025-05-20 10:00:00', '2025-05-20 12:00:00', 'G1', 1),
(2, N'Samira', 2, 2, '2025-05-20 14:00:00', '2025-05-20 16:00:00', 'G2', 0),
(3, N'Signe', 3, 3, '2025-05-21 09:00:00', '2025-05-21 11:00:00', 'G3', 1);
GO