using Mono.Data.Sqlite;
using Rehab.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace Rehab.Services
{
    public interface IDatabaseService
    {
        List<User> GetUsers();
        void AddUser(User user, Action onSuccess);
        void SubUser(string email, Action onSuccess);
    }

    public class DatabaseService : IDatabaseService
    {
        public void SubUser(string email, Action onSuccess)
        {
            using (IDbConnection dbConnection = new SqliteConnection(SQL.CONNESTION_STRING))
                {
                    dbConnection.Open();
                    using (IDbCommand dbCmd = dbConnection.CreateCommand())
                    {
                        string sqlQuery = "SELECT * from Users;";
                        dbCmd.CommandText = sqlQuery;
                        string sqlQuery2 = "";

                        using (IDataReader reader = dbCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.GetString(0).Equals(email))
                                    sqlQuery2 += "delete from Users where Email=\"" + email + "\";";
                            }
                        }
                        dbCmd.CommandText = sqlQuery2;
                        dbCmd.ExecuteScalar();
                    }
                    onSuccess();
                    dbConnection.Close();
                }
        }

        public void AddUser(User user, Action onSuccess)
        {
                bool exists = false;
                using (IDbConnection dbConnection = new SqliteConnection(SQL.CONNESTION_STRING))
                {
                    dbConnection.Open();
                    using (IDbCommand dbCmd = dbConnection.CreateCommand())
                    {
                        string sqlQuery = "SELECT * FROM Users;";
                        dbCmd.CommandText = sqlQuery;
                        string sqlQuery2 = "";

                        using (IDataReader reader = dbCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.GetString(0).Equals(user.Email))
                                    exists = true;
                            }
                        }
                        if (!exists)
                            sqlQuery2 += "INSERT INTO Users VALUES(\"" + user.Email + "\",\"" + user.Name + "\",\"" + user.Surname + "\");";

                        dbCmd.CommandText = sqlQuery2;
                        dbCmd.ExecuteScalar();

                        if (!exists)
                            onSuccess();
                    }
                    dbConnection.Close();
                }
        }

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
