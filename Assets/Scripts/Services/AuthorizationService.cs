using System;
using UnityEngine;

namespace Rehab.Services
{
    public interface IAuthorizationService
    {
        void Authorize(string password, Action  onAuthorize, Action<string> onFail);
    }

    public class AuthorizationService : IAuthorizationService
    {
        public void Authorize(string password, Action onAuthorize, Action<string> onFail)
        {
            if (PlayerPrefs.GetString(Constans.AdminPassword) == password)
                onAuthorize();
            else
                onFail(Constans.AuthorizeError);
        }
    }
}
