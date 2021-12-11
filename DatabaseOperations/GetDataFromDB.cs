using Npgsql;

namespace DatabaseOperations
{
    public class GetDataFromDB
    {
        private readonly string connectionString = "Host=localhost;Port=5432;Database=ChipIn;Username=postgres;Password=1234";

        string GetFromDB(string SQLREQUEST) 
        {
            NpgsqlConnection con = new NpgsqlConnection(connectionString);
            NpgsqlCommand com = new NpgsqlCommand(SQLREQUEST, con);
            string result = "";
            con.Open();
            NpgsqlDataReader reader;
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    result = reader.GetString(0);
                }
                catch (Exception ex) 
                {
                    result = "something went wrong" + ex;
                }

            }
            con.Close();
            
            return result;
        }
    }
}