CREATE TABLE [dbo].[Bruger] (
    [ID]          INT            NOT NULL,
    [Brugernavn]  NVARCHAR (50)  NOT NULL,
    [Adgangskode] NVARCHAR (255) NOT NULL,
    [RolleID]     INT            NULL,
    [GruppeID]    NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    UNIQUE NONCLUSTERED ([Brugernavn] ASC),
    FOREIGN KEY ([RolleID]) REFERENCES [dbo].[Rolle] ([RolleID])
);

