
using UnityEngine;

namespace Rehab.Static
{
    public static class SQL
    {
        public static string CONNESTION_STRING = "URI=file:" + Application.dataPath + "/Settings/Database/RehabDB.sqlite";
        public static string GET_ALL_USERS = "SELECT * FROM Users";
    }
}
