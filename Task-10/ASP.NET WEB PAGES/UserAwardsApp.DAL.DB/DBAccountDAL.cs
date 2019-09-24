using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAwardsApp.DAL.Abstract;
using UserAwardsApp.Entities;

namespace UserAwardsApp.DAL.DB
{
    public class DBAccountDAL : IAccountDAL
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultDB"].ConnectionString;

        public Account AddAccount(Account account)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO dbo.[Accounts] ([ID], [Login], [Password], [Role]) VALUES (@ID, @Login, @Password, @Role)";

                command.Parameters.AddWithValue("@ID", account.ID);
                command.Parameters.AddWithValue("@Login", account.Login);
                command.Parameters.AddWithValue("@Password", account.Password);
                command.Parameters.AddWithValue("@Role", account.Role);

                connection.Open();

                if (command.ExecuteNonQuery() == 1)
                {
                    return account;
                }
            }
            throw new ArgumentException();
        }

        public bool DeSerializerJsonAccounts()
        {
            throw new NotImplementedException();
        }

        public bool EditAccount(Guid ID, string login, string password, string role)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE dbo.[Accounts] SET [Login]=@Login, [Password]=@Password, [Role]=@Role WHERE ID=@ID";

                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Role", role);

                connection.Open();

                return command.ExecuteNonQuery() == 1;

            }
        }

        public Account GetAccountByID(Guid ID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT [ID], [Login], [Password], [Role] FROM dbo.[Accounts] WHERE [ID]=@ID";

                command.Parameters.AddWithValue("@ID", ID);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return new Account()
                    {
                        ID = Guid.Parse(reader["ID"].ToString()),
                        Login = (string)reader["Login"],
                        Password = (string)reader["Password"],
                        Role = (string)reader["Role"],
                    };
                }
                throw new ArgumentException();
            }
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT [ID], [Login], [Password], [Role] FROM dbo.[Accounts]";
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Account()
                    {
                        ID = Guid.Parse(reader["ID"].ToString()),
                        Login = (string)reader["Login"],
                        Password = (string)reader["Password"],
                        Role = (string)reader["Role"],
                    };
                }
            }
        }

        public bool RemoveAccount(Guid ID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM dbo.[Accounts] WHERE [ID]=@ID";

                command.Parameters.AddWithValue("@ID", ID);

                connection.Open();

                return command.ExecuteNonQuery() == 1;

            }
        }

        public bool SerializerJsonAccounts()
        {
            throw new NotImplementedException();
        }
    }
}
