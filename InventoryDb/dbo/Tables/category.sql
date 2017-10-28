CREATE TABLE [dbo].[category] (
    [id]                INT            IDENTITY (1, 1) NOT NULL,
    [name]              NVARCHAR (500) NOT NULL,
    [data_time_added]   DATETIME       NOT NULL,
    [date_time_updated] DATETIME       NULL,
    [added_by]          NVARCHAR (100) NOT NULL,
    [updated_by]        NVARCHAR (100) NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([id] ASC)
);

