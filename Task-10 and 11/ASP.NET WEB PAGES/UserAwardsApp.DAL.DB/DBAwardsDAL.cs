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
    public class DBAwardsDAL : IAwardsDAL
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultDB"].ConnectionString;

        public bool AddAward(Award award)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO dbo.[Awards] ([ID], [Name], [Image]) VALUES (@ID, @Name, @Image)";

                command.Parameters.AddWithValue("@ID", award.ID);
                command.Parameters.AddWithValue("@Name", award.Name);
                command.Parameters.AddWithValue("@Image", award.Image ?? System.Data.SqlTypes.SqlBinary.Null);

                connection.Open();

                return command.ExecuteNonQuery() == 1;
            }
        }

        public bool AddAwardToUser(Guid userID, Guid awardID)
        {

    //        INSERT INTO[dbo].[UserAwards]
    //    ([ID_Users]
    //      ,[ID_Awards])
    //SELECT[ID]

    // FROM[dbo].[Awards]
    //    WHERE[Awards].[ID] =' ' AND[UserAwards].[ID_Awards]!=''
            
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO [dbo].[UserAwards] ([ID_Users], [ID_Awards]) VALUES (@ID_Users, @ID_Awards)";
                command.Parameters.AddWithValue("@ID_Users", userID);
                command.Parameters.AddWithValue("@ID_Awards", awardID);

                connection.Open();

                return command.ExecuteNonQuery() > 0 ? true : false;
            }
        }

        public bool DeleteUserAwards(User user)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM dbo.UserAwards WHERE dbo.UserAwards.[ID_Users] = @ID_Users";

                command.Parameters.AddWithValue("ID_Users", user.ID);

                connection.Open();

                return command.ExecuteNonQuery() == 1;
            }
        }

        public bool DeSerializerJsonAwards()
        {
            throw new NotImplementedException();
        }

        public bool DeSerializerJsonAwardsOfUsers()
        {
            throw new NotImplementedException();
        }

        public bool EditAward(Guid ID, string Name)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE dbo.[Awards] SET [Name]=@Name WHERE ID=@ID";

                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Name", Name);

                connection.Open();

                return command.ExecuteNonQuery() == 1;

            }
        }

        public IEnumerable<Award> GetAllAwards()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT [ID], [Name], [Image] FROM dbo.[Awards]";
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var image = reader["Image"] is DBNull ? null : (byte[])reader["Image"];
                    yield return new Award()
                    {
                        ID = Guid.Parse(reader["ID"].ToString()),
                        Name = (string)reader["Name"],
                        Image = image,
                    };
                }
            }
        }

        public Award GetAward(Guid ID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT [ID], [Name], [Image] FROM dbo.[Awards] WHERE [ID]=@ID";

                command.Parameters.AddWithValue("@ID", ID);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var image = reader["Image"] is DBNull ? null : (byte[])reader["Image"];
                    return new Award()
                    {
                        ID = Guid.Parse(reader["ID"].ToString()),
                        Name = (string)reader["Name"],
                        Image = image,
                    };
                }
                throw new ArgumentException();
            }
        }

        public IEnumerable<Award> GetUserAwards(User user)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT dbo.[Awards].[ID], dbo.[Awards].[Name], dbo.[Awards].[Image] FROM dbo.[Awards] INNER JOIN dbo.[UserAwards] ON dbo.[Awards].[ID] = dbo.[UserAwards].[ID_Awards] WHERE dbo.[UserAwards].[ID_Users] = @ID_Users";

                command.Parameters.AddWithValue("ID_Users", user.ID);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var image = reader["Image"] is DBNull ? null : (byte[])reader["Image"];
                    yield return new Award()
                    {
                        ID = Guid.Parse(reader["ID"].ToString()),
                        Name = (string)reader["Name"],
                        Image = image,
                    };
                }
            }
        }

        public bool RemoveAward(Guid ID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM dbo.[Awards] WHERE [ID]=@ID";

                command.Parameters.AddWithValue("@ID", ID);

                connection.Open();

                return command.ExecuteNonQuery() == 1;

            }
        }

        public bool SerializerJsonAwards()
        {
            throw new NotImplementedException();
        }

        public bool SerializerJsonAwardsOfUsers()
        {
            throw new NotImplementedException();
        }
    }
}
