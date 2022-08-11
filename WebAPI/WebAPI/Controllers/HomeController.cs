using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Class1 data)
        {
            int PageID = data.PageID;
            int ProjectID = data.ProjectID;
            string HelpTitle = data.HelpTitle;
            string HelpBody = data.HelpBody;
            int flag = 1;
            DataTable dt = new DataTable();
            string query = @"INSERT INTO dbo.HELP VALUES(
            " + PageID+ @",
            " + ProjectID + @",
            '" + HelpTitle + @"',
            '" + HelpBody + @"',
             " + flag + @"

            )";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HELPDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(dt);
            }

            return Redirect("/admin/index");
        }
    }
}
