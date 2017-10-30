CREATE TABLE [dbo].[Pais] (
    [PaisId]      INT           IDENTITY (1, 1) NOT NULL,
    [Nome]        VARCHAR (100) NOT NULL,
    [PaisAtualId] INT           NULL,
    CONSTRAINT [PK_Pais] PRIMARY KEY CLUSTERED ([PaisId] ASC),
    CONSTRAINT [FK_Pais_Pais] FOREIGN KEY ([PaisAtualId]) REFERENCES [dbo].[Pais] ([PaisId])
);

