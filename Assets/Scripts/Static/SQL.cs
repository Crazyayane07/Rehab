using UnityEngine;

namespace Rehab
{
    public static class SQL
    {
        public static string CONNESTION_STRING = "URI=file:" + Application.dataPath + "RDB.sqlite";
        public static string GET_ALL_USERS = "SELECT * FROM Users";
        public static string GET_ALL_RESULTS_OF_USER = "SELECT * FROM Results Where UserEmail=";

        /*
         CREATE TABLE IF NOT EXISTS Results(
  id INTEGER PRIMARY KEY,
  UserEmail TEXT NOT NULL,
  Date TEXT NULL,
  GameName TEXT NOT NULL, TimeResult TEXT NULL
)
         */
    }
}
