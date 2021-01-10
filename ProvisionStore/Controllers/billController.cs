using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProvisionStore.Controllers
{
    public class billController : Controller
    {
        // GET: bill
        string connectionString = @"Data Source = DESKTOP-73QEMIP\SQLEXPRESS; Initial Catalog = billGenerator; Integrated Security=True";

        
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Products", sqlCon);
                sqlDa.Fill(dtblProduct);
            }
            return View(dtblProduct);
        }
    }
}