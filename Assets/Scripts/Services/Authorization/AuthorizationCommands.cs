
using System;

namespace Rehab.Services.Authorization
{
    public class AuthorizationCommands
    {
        private string name;
        private Action onAuthorize;
        private Action<string> onFail;

        public string Name { get { return name; } }
        public Action OnAuthorize { get { return onAuthorize; } }
        public Action<string> OnFail { get { return onFail; } }

        public AuthorizationCommands(string name, Action onAuthorize, Action<string> onFail)
        {
            this.name = name;
            this.onAuthorize = onAuthorize;
            this.onFail = onFail;
        }
    }
}
