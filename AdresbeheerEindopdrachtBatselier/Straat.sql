CREATE TABLE [dbo].[straat] (
    [id]         INT            NOT NULL,
    [straatnaam] NVARCHAR (100) NOT NULL,
    [NISCODE]    INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([NISCODE]) REFERENCES [dbo].[gemeente] ([NISCODE])
);

