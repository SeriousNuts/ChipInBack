using ChipIn.models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipIn
{
    public class UserRepository : IUserRepository
    {
        public List<User> GetAllUserByPartName(string partname)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            string sql = "SELECT * from public.user_ where "+ "Id_" + " = " + id.ToString(); 
            User user = new User();

            NpgsqlConnection conn = new NpgsqlConnection("Host = localhost; Port = 5432; Database = ChipIn; Username = postgres; Password = 1234");
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            conn.Open(); //Открываем соединение.
            var result = comm.ExecuteScalar(); //Выполняем нашу команду.
            conn.Close(); //Закрываем соединение.
            return user;

        }

        public void SetUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
