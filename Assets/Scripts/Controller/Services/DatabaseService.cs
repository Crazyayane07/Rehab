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
        void DeleteTestResults(string email);

        void AddResult(string email, string date, string gameName, string timeResult);
        List<Result> GetUserResult(string email);
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
            Selected.USER = null;
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

        public void AddResult(string email, string date, string gameName, string timeResult)
        {
            using (IDbConnection dbConnection = new SqliteConnection(SQL.CONNESTION_STRING))
            {
                dbConnection.Open();
                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    string sqlQuery2 = "";

                    sqlQuery2 += "INSERT INTO Results(UserEmail, Date, GameName, TimeResult) VALUES(\"" + email + "\",\"" + date + "\",\"" + gameName + "\",\"" + timeResult + "\");";

                    dbCmd.CommandText = sqlQuery2;
                    dbCmd.ExecuteScalar();
                }
                dbConnection.Close();
            }
        }

        public List<Result> GetUserResult(string email)
        {
            List<Result> results = new List<Result>();

            using (IDbConnection dbConnection = new SqliteConnection(SQL.CONNESTION_STRING))
            {
                dbConnection.Open();

                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    dbCmd.CommandText = SQL.GET_ALL_RESULTS_OF_USER+"'"+Selected.USER.Email+"'";

                    using (IDataReader reader = dbCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(new Result(reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4)));
                        }
                        dbConnection.Close();
                        reader.Close();
                    }
                }
            }
            return results;
        }

        public void DeleteTestResults(string email)
        {
            using (IDbConnection dbConnection = new SqliteConnection(SQL.CONNESTION_STRING))
            {
                dbConnection.Open();
                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    string sqlQuery2 = "";
                   
                    sqlQuery2 += "DELETE FROM Results WHERE UserEmail = " + "'" + email + "'";

                    dbCmd.CommandText = sqlQuery2;
                    dbCmd.ExecuteScalar();
                }
                dbConnection.Close();
            }
        }
    }
}
