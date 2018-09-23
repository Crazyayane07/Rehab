using Rehab.Popups.UsersList;

namespace Rehab.Popups
{
    public class UsersListPanel : MonoBehaviour2
    {
        public UserPanel[] panels;

        public void SetUp()
        {
            SetUpPanels();
        }

        private void SetUpPanels()
        {
            var users = DatabaseService.GetUsers();

            for (int i = 0; i < users.Count; i++)
            {
                panels[i].SetUp(users[i]);
            }
            for (int j = users.Count; j < panels.Length; j++)
            {
                panels[j].gameObject.SetActive(false);
            }
        }
    }
}
