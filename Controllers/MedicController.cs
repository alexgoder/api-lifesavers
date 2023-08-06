using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Data;
using Newtonsoft.Json;
using Proiect_Ip_API.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_lifesavers.Controllers
{
    [Route("api/[controller]")]
    public class MedicController : Controller
    {
        [HttpGet]
        public string Get()
        {
            SqlConnection connection = new SqlConnection("Server=tcp:lifesavers.database.windows.net,1433;Initial Catalog=lifesaversdb;Persist Security Info=False;User ID=lifesaversadmin;Password=Admin1311;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM dbo.Medici", connection);
            DataTable dataTable = new DataTable();
            //DbDataAdapter dataAdapter = new DbDataAdapter();
            dataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dataTable);
            }
            else
            {
                return "No data found";
            }
        }
    }
}

