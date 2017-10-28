using Inventory.Data;
using Inventory.Models;
using System.Web.Mvc;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Linq;
namespace Inventory.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {

            return View();
        }

        public JsonResult GetAllCategories()
        {
            var items = new List<Category>();
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                string sproc = "usp_get_all_categories";
                items = db.Query<Category>(sproc, commandType: CommandType.StoredProcedure).ToList();
                return Json(items, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Insert(string name)
        {
            return this.UpsertCategory(new Category()
            {
                CategoryName = name

            });
        }

        public JsonResult Update(string name, int id)
        {
            return this.UpsertCategory(new Category()
            {
                CategoryName = name,
                CategoryId = id
                
            });
        }

        public JsonResult UpsertCategory(Category category)
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