CREATE TABLE [dbo].[brand] (
    [id]                INT            IDENTITY (1, 1) NOT NULL,
    [name]              NVARCHAR (60)  NOT NULL,
    [category_id]       INT            NOT NULL,
    [data_time_added]   DATETIME       NOT NULL,
    [date_time_updated] DATETIME       NULL,
    [added_by]          NVARCHAR (100) NOT NULL,
    [updated_by]        NVARCHAR (100) NULL,
    CONSTRAINT [PK__brand__3213E83FFF8620E4] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK__brand__category___1920BF5C] FOREIGN KEY ([category_id]) REFERENCES [dbo].[category] ([id])
);

