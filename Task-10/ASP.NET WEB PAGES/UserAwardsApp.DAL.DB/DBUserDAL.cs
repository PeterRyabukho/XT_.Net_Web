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
    public class DBUserDAL : IUserDAL
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultDB"].ConnectionString;

        public DBUserDAL()
        {

        }

        public User AddUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO dbo.[Users] ([ID], [Name], [DateOfBirth], [Image]) VALUES (@ID, @Name, @DateOfBirth, @Image)";

                command.Parameters.AddWithValue("@ID", user.ID);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                command.Parameters.AddWithValue("@Image", user.Image ?? System.Data.SqlTypes.SqlBinary.Null);

                connection.Open();

                if (command.ExecuteNonQuery() == 1)
                {
                    return user;
                }
            }
            return null;
        }

        public bool DeSerializerJsonUsers()
        {
            throw new NotImplementedException();
        }

        public bool EditUser(Guid ID, string Name, DateTime dOB)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE dbo.[Users] SET [Name]=@Name, [DateOfBirth]=@DateOfBirth WHERE ID=@ID";

                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@DateOfBirth", dOB);

                connection.Open();

                return command.ExecuteNonQuery() == 1;

            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT [ID], [Name], [DateOfBirth], [Image] FROM dbo.[Users]";
                connection.Open();

                var reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    var image = reader["Image"] is DBNull ? null : (byte[])reader["Image"];
                    yield return new User()
                    {
                        ID = Guid.Parse(reader["ID"].ToString()),
                        Name = (string)reader["Name"],
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                        Image = image,
                    };
                }
            }
        }

        public User GetUserByID(Guid ID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT [ID], [Name], [DateOfBirth], [Image] FROM dbo.[Users] WHERE [ID]=@ID";

                command.Parameters.AddWithValue("@ID", ID);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var image = reader["Image"] is DBNull ? null : (byte[])reader["Image"];
                    return new User()
                    {
                        ID = Guid.Parse(reader["ID"].ToString()),
                        Name = (string)reader["Name"],
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                        Image = image
                    };
                }
                throw new ArgumentException();
            }
        }

        public bool RemoveUser(Guid ID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM dbo.[Users] WHERE [ID]=@ID";

                command.Parameters.AddWithValue("@ID", ID);

                connection.Open();

                return command.ExecuteNonQuery() == 1;

            }
        }

        public bool SerializerJsonUsers()
        {
            throw new NotImplementedException();
        }
    }
}
