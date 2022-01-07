using Newtonsoft.Json;
using Npgsql;
using System.Data;

namespace DatabaseOperations
{
    public class GetDataFromDB
    {
        private readonly string connectionString = "Host=localhost;Port=5432;Database=ChipIn;Username=postgres;Password=1234";

       public string getOneStringFromDB(string SQLREQUEST) 
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);

            DataTable data = new DataTable();
            NpgsqlDataReader npgsqlDataReader;
            //NpgsqlCommand comm = new NpgsqlCommand(SQLREQUEST, conn);
            conn.Open(); //Открываем соединение.
            using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(SQLREQUEST, conn))
            {
                npgsqlDataReader = npgsqlCommand.ExecuteReader();
                data.Load(npgsqlDataReader);
                npgsqlDataReader.Close();
                conn.Close();
            }         
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            if (JSONString == "[]")
            {
                JSONString = "Nothing found";
            }
            
            return JSONString;
        }
        public List<string> getStringsFromDB(string SQLREQUEST)
        {   
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            List<string> datafromdb = new List<string>();
            DataTable data = new DataTable();          
            string JSONString = string.Empty;
            conn.Open();
            using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(SQLREQUEST, conn))
            {
                using (NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader())
                {
                    data.Load(npgsqlDataReader);
                    JSONString = JsonConvert.SerializeObject(data);
                    JSONString.Replace(@"\", "");
                    datafromdb.Add(JSONString);   
                }
                
                conn.Close();
            }
            
            return datafromdb;
        }
    }
}