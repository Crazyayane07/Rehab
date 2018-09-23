using Mono.Data.Sqlite;
using Rehab.Model;
using System.Collections.Generic;
using System.Data;

namespace Rehab.Services
{
    public interface IDatabaseService
    {
        List<User> GetUsers();
    }

    public class DatabaseService : IDatabaseService
    {
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (IDbConnection dbConnection = new SqliteConnection(SQL.CONNESTION_STRING))
            {
                dbConnection.Open();

                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    dbCmd.CommandText = SQL.GET_ALL_USERS;

                    using (IDataReader reader = dbCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User(reader.GetString(0),
                                reader.GetString(1),
                                reader.GetString(2)));
                        }
                        dbConnection.Close();
                        reader.Close();
                    }
                }
            }

            return users;
        }
    }
}
