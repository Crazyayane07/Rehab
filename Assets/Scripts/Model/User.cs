
namespace Assets.Model
{
    public class User
    {
        private string email;
        private string name;
        private string surname;

        public string Email { get { return email; } }
        public string Name { get { return name; } }
        public string Surname { get { return surname; } }

        public User(string email, string name, string surname)
        {
            this.email = email;
            this.name = name;
            this.surname = surname;
        }
    }
}
