using Rehab.Services.Authorization;
using Rehab.Static;
using UnityEngine;

namespace Rehab.Services
{
    public interface IAuthorizationService
    {
        void Authorize(AuthorizationCommands commands);
    }

    public class AuthorizationService : IAuthorizationService
    {
        public void Authorize(AuthorizationCommands commands)
        {
            if(PlayerPrefs.GetString(KeyWords.AdminKey) == "")
            {
                PlayerPrefs.SetString(KeyWords.AdminKey, commands.Name);
                commands.OnAuthorize();
            }
            else
            {
                if (PlayerPrefs.GetString(KeyWords.AdminKey) == commands.Name)
                    commands.OnAuthorize();
                else
                    commands.OnFail(KeyWords.Authorization_Error);
            }
        }
    }
}
