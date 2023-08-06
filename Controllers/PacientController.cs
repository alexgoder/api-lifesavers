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




// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_lifesavers.Controllers
{ 
    [Route("api/[controller]")]
    public class PacientController : Controller
    {
        //readonly SqlConnection connection = new SqlConnection(@"server=lifesavers.database.windows.net; Username=lifesaversadmin; Password=Admin1311; database=lifesaversdb");
        //private SqlConnection connection=new SqlConnection();
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
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM dbo.Pacienti", connection);
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

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        
        [HttpPost]
        public string Post(string array)
        {
            const int nume = 0;
            const int CNP = 1;
            const int codMedic = 2;
            const int varsta = 3;
            const int afectiune = 4;
            const int recomandari = 5;
            const int nrTel = 6;
            string num = "nimic";
            string cod = "11";
            string []atributArray=new string[7];
            int i = 0;
            atributArray = array.Split(',');
            SqlConnection connection = new SqlConnection("Server=tcp:lifesavers.database.windows.net,1433;Initial Catalog=lifesaversdb;Persist Security Info=False;User ID=lifesaversadmin;Password=Admin1311;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            Pacient pacientModel = new Pacient();
            //pacientModel = JsonConvert.DeserializeObject<Pacient>(obiect);
            

            if (array!=null)
            { 
                string command = @"Insert into dbo.Pacienti(CNP,Cod_medic,Nume,Varsta,Afectiuni,Recomandari,Numar_telefon) VALUES('"
               + atributArray[CNP] + @"','"
               + atributArray[codMedic] + @"','"
               + atributArray[nume] + @"',"
               + int.Parse(atributArray[varsta]) + @",'"
               + atributArray[afectiune] + @"','"
               + atributArray[recomandari] + @"','"
               + atributArray[nrTel] + @"')";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                
                i = sqlCommand.ExecuteNonQuery();
            }
            
            if (i == 1)
            {
                return "Posted ok";
            }
            else
            {
                return "nume: " + num +" cod medic: " + cod;
            }
        }

        // PUT api/values/5
        [HttpPut]
        public string Put([FromBody]int id, [FromBody]string value,[FromBody]string tip)
        {
            int status = 0;
            SqlConnection connection = new SqlConnection("Server=tcp:lifesavers.database.windows.net,1433;Initial Catalog=lifesaversdb;Persist Security Info=False;User ID=lifesaversadmin;Password=Admin1311;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            if (tip == "afectiuni")
            {
                string command = @"update dbo.Pacienti set Afectiuni='"
            + value + @"' where CNP='"
            + id + @"'";
                SqlCommand sqlCommand = new(command, connection);
                status = sqlCommand.ExecuteNonQuery();
            }
            if(tip == "recomandari")
            {
                string command = @"update dbo.Pacienti set Recomandari='"
            + value + @"' where CNP='"
            + id + @"'";
                SqlCommand sqlCommand = new(command, connection);
                status = sqlCommand.ExecuteNonQuery();
            }
            if (status!=0)
            {
                return "put ok";
            }
            else
            {
                return "put not ok";
            }
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SqlConnection connection = initConnection();
        }
    }
}

