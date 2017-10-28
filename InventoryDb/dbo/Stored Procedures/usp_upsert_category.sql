-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_upsert_category]
	 @item_xml xml
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;



merge Category as i
using
  (
    select 
			T.N.value('CategoryId[1]', 'int') as id,
			T.N.value('CategoryName[1]', 'varchar(60)') as name,
			
			'vivek' as added_by,
			'vivek' as updated_by
    from @item_xml.nodes('/Category') T(N)
  ) as S
on i.id = S.id
when matched then
  update set name = S.name
when not matched by target then   
insert (name, data_time_added, date_time_updated,added_by, updated_by) values(S.name,GETDATE(),GETDATE(),S.added_by, S.updated_by); 


END
