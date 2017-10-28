CREATE TABLE [dbo].[item] (
    [id]                INT            IDENTITY (1, 1) NOT NULL,
    [name]              NVARCHAR (60)  NOT NULL,
    [category_id]       INT            NOT NULL,
    [brand_id]          INT            NOT NULL,
    [total_stock]       INT            NULL,
    [available_stock]   INT            NOT NULL,
    [data_time_added]   DATETIME       NOT NULL,
    [date_time_updated] DATETIME       NULL,
    [added_by]          NVARCHAR (100) NOT NULL,
    [updated_by]        NVARCHAR (100) NULL,
    CONSTRAINT [PK__item__3213E83F69B6BDF9] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK__item__brand_id__1CF15040] FOREIGN KEY ([brand_id]) REFERENCES [dbo].[brand] ([id]),
    CONSTRAINT [FK__item__category_i__1BFD2C07] FOREIGN KEY ([category_id]) REFERENCES [dbo].[category] ([id])
);

