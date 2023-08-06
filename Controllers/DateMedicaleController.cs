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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_lifesavers.Controllers
{
    [Route("api/[controller]")]
    public class DateMedicaleController : Controller
    {

        [HttpGet]
        public string Get()
        {
            SqlConnection connection = new SqlConnection("Server=tcp:lifesavers.database.windows.net,1433;Initial Catalog=lifesaversdb;Persist Security Info=False;User ID=lifesaversadmin;Password=Admin1311;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM dbo.Date_medicale", connection);
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
            int status=0;
            SqlCommand sqlCommand;
            SqlConnection connection = new SqlConnection("Server=tcp:lifesavers.database.windows.net,1433;Initial Catalog=lifesaversdb;Persist Security Info=False;User ID=lifesaversadmin;Password=Admin1311;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            if (value=="alergii")
            {
                string command = @"SET IDENTITY_INSERT [dbo].[Date_medicale] ON\n
                    update dbo.ECG set Alergii='"
               + value + @"' where CNP_Pacient='"
               + id + @"'\n
                SET IDENTITY_INSERT [dbo].[Date_medicale] OFF";
                sqlCommand = new SqlCommand(command, connection);
                status = sqlCommand.ExecuteNonQuery();
            }
            if (value == "istoric")
            {
                string command = @"SET IDENTITY_INSERT [dbo].[Date_medicale] ON\n
                    update dbo.ECG set Istoric_medical='"
               + value + @"' where CNP_Pacient='"
               + id + @"'\n
                SET IDENTITY_INSERT [dbo].[Date_medicale] OFF";
                sqlCommand = new SqlCommand(command, connection);
                status = sqlCommand.ExecuteNonQuery();
            }
            if (value == "consult")
            {
                string command = @"SET IDENTITY_INSERT [dbo].[Date_medicale] ON\n
                    update dbo.ECG set Consultatii_cardiologice='"
               + value + @"' where CNP_Pacient='"
               + id + @"'\n
                SET IDENTITY_INSERT [dbo].[Date_medicale] OFF";
                sqlCommand = new SqlCommand(command, connection);
                status = sqlCommand.ExecuteNonQuery();
            }

            if (status == 1)
                return "Put ok";
            else
                return "Failed";
        }
    }
}

