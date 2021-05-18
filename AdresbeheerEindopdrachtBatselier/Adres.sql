CREATE TABLE [dbo].[adres] (
    [id]                INT           NOT NULL,
    [straatID]          INT           NOT NULL,
    [huisnummer]        VARCHAR (100) NOT NULL,
    [appartementnummer] VARCHAR (100) NULL,
    [busnummer]         VARCHAR (100) NULL,
    [huisnummerlabel]   VARCHAR (100) NOT NULL,
    [adreslocatieID]    INT           NOT NULL,
    [postcode]          INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([straatID]) REFERENCES [dbo].[straat] ([id]),
    FOREIGN KEY ([adreslocatieID]) REFERENCES [dbo].[adreslocatie] ([id])
);

