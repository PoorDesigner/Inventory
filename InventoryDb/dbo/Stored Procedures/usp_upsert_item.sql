-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_upsert_item]
	 @item_xml xml
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


merge item as i
using
  (
    select 
			T.N.value('ItemId[1]', 'int') as item_id,
			T.N.value('ItemName[1]', 'varchar(60)') as name,
			T.N.value('CategoryId[1]', 'int') as category_id,
			T.N.value('BrandId[1]', 'int') as brand_id,
			T.N.value('TotalStock[1]', 'int') as total_stock,
			T.N.value('AvailableStock[1]', 'int') as available_stock,
			'vivek' as added_by,
			'vivek' as updated_by
    from @item_xml.nodes('/Item') T(N)
  ) as S
on i.id = S.item_id
when matched then
  update set available_stock = S.available_stock;



END
