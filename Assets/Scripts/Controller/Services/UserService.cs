using System;

namespace Rehab.Services
{
    public interface IUserService
    {
        Action OnSelect { get; set; }

        void Select(string email);
    }

    public class UserService : IUserService
    {
        public Action OnSelect { get; set; }

        public void Select(string email)
        {
            Selected.USER = email;

            if(OnSelect != null)
                OnSelect.Invoke();
        }
    }
}
