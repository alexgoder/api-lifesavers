using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class EcgController : Controller
    {
        private static SqlConnection initConnection()
        {

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "lifesavers.database.windows.net";
            builder.UserID = "lifesaversadmin";
            builder.Password = "Admin1311";
            builder.InitialCatalog = "lifesaversdb";
            SqlConnection con = new SqlConnection(builder.ConnectionString);
            return con;
        }


        // GET: api/values
        [HttpGet]
        public string Get()
        {
            SqlConnection connection = new SqlConnection("Server=tcp:lifesavers.database.windows.net,1433;Initial Catalog=lifesaversdb;Persist Security Info=False;User ID=lifesaversadmin;Password=Admin1311;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM dbo.Puls", connection);
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


        [HttpPut("{id}")]
        public string Put(int id, string value)
        {
            SqlConnection connection = new SqlConnection("Server=tcp:lifesavers.database.windows.net,1433;Initial Catalog=lifesaversdb;Persist Security Info=False;User ID=lifesaversadmin;Password=Admin1311;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            string command = @"SET IDENTITY_INSERT [dbo].[ECG] ON\n
                    update dbo.ECG set Valoare='"
               + value + @"' where CNP_Pacient='"
               + id + @"'\n
                SET IDENTITY_INSERT [dbo].[ECG] OFF";

            SqlCommand sqlCommand = new SqlCommand(command, connection);
            int i=sqlCommand.ExecuteNonQuery();
            if (i == 1)
                return "put ok";
            else
                return "Failed";
        }
    }
}

