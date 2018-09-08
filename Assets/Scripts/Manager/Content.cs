using Assets.Model;
using System.Collections.Generic;

namespace Rehab.Manager
{
    public class Content
    {
        public List<User> users;

        public Content()
        {
            InitUserList();
        }

        private void InitUserList()
        {
            users = new List<User>();

            var dbUsers = GameManager.DatabaseService.GetUsers();

            for(int i = 0; i < dbUsers.Count; i++)
            {
                users.Add(dbUsers[i]);
            }
        }
    }
}
