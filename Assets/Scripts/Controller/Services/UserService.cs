using Rehab.Model;
using System;

namespace Rehab.Services
{
    public interface IUserService
    {
        Action OnSelect { get; set; }

        void Select(User user);
    }

    public class UserService : IUserService
    {
        public Action OnSelect { get; set; }

        public void Select(User user)
        {
            Selected.USER = user;

            if(OnSelect != null)
                OnSelect.Invoke();
        }
    }
}
