-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE get_all_items
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- select statements for procedure here
	SELECT 
		i.id AS ItemId,
		i.name AS ItemName,
		i.total_stock AS TotalStock,
		i.available_stock AS AvailableStock,
		b.name AS BrandName,
		b.id AS BrandId,
		c.id AS CategoryId,
		c.name AS CategoryName
	FROM item i 
	JOIN  brand b ON i.brand_id = b.id
	JOIN category c ON b.category_id = c.id
	
END
