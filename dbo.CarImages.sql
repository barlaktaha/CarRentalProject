CREATE TABLE [dbo].[CarImages] (
    [ImageId]   INT           IDENTITY (1, 1) NOT NULL,
    [CarId]     INT           NOT NULL,
    [ImagePath] VARCHAR (MAX) NOT NULL,
    [Date]      DATETIME      NOT NULL,
    CONSTRAINT [PK_CarImages] PRIMARY KEY CLUSTERED ([ImageId] ASC),
    CONSTRAINT [FK_CarImages_ToTable] FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([CarId])
);

