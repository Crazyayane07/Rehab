using UnityEngine;

namespace Rehab
{
    public static class SQL
    {
        public static string CONNESTION_STRING = "URI=file:" + Application.dataPath + "RDB.sqlite";
        public static string GET_ALL_USERS = "SELECT * FROM Users";
    }
}
