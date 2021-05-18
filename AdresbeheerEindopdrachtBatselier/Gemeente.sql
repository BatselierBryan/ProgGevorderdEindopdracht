CREATE TABLE [dbo].[gemeente] (
    [NISCODE]      INT            NOT NULL,
    [gemeentenaam] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([NISCODE] ASC),
    CHECK ([NISCODE]>=(0) AND [NISCODE]<=(99999))
);

