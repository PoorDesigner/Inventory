using Dapper;
using Inventory.Data;
using Inventory.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Inventory.Controllers
{
    public class ItemController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }


        // GET: Home/Create
        public JsonResult upsert_item(Item aItem, int incerement)
        {
            try
            {
                if (aItem.AvailableStock + incerement > aItem.TotalStock)
                {
                    return Json("Available stock cant be more than total stock", JsonRequestBehavior.AllowGet);
                }
                aItem.AvailableStock = aItem.AvailableStock + incerement;
                var xml = XMLExtentions.ToXElement<Item>(aItem);
                using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@item_xml", xml);
                    string sproc = "usp_upsert_item";
                    db.Execute(sproc, parameters, commandType: CommandType.StoredProcedure);
                    return Json("Item updated Successfully", JsonRequestBehavior.AllowGet);
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}