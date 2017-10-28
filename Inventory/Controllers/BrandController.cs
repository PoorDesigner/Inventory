using Inventory.Data;
using Inventory.Models;
using System.Web.Mvc;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Inventory.Controllers
{
    public class BrandController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult UpsertBrand(Brand category)
        {
            try
            {
                var xml = XMLExtentions.ToXElement<Category>(category);
                using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@item_xml", xml);
                    string sproc = "usp_upsert_category";
                    db.Execute(sproc, parameters, commandType: CommandType.StoredProcedure);
                    return Json("Category updated Successfully", JsonRequestBehavior.AllowGet);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}