using HWPostSystem.Models;
using HWPostSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HWPostSystem.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public string[] UserRoles { get; private set; }
        //Fields
        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;
        public UserAccountModel CurrentUserAccount
        {
            get { return _currentUserAccount; }
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }
        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            LoadCurrentUserData();
        }

        private void LoadCurrentUserData()
        {
            // @#4050302Bb

            //var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            try
            {
                var userName = Thread.CurrentPrincipal?.Identity.Name;

                if (userName != null)
                {
                    // Retrieve the current principal
                    var principal = Thread.CurrentPrincipal as GenericPrincipal;

                    // Print all roles
                    if (principal != null)
                    {
                        UserRoles = principal.IsInRole("Admin") ? new[] { "Admin", "User", "Manager" } : new[] { "User", "Manager" };

                        foreach (var role in UserRoles)
                        {
                            Trace.WriteLine("UserRoles: " + role);
                        }
                        // Alternatively, you can loop through roles if needed:
                        // UserRoles = principal.Identity is GenericIdentity identity ? identity.Claims.Select(c => c.Value).ToArray() : new string[0];
                    }
                    else
                    {
                        UserRoles = new string[0]; // No roles found
                    }

                    CurrentUserAccount.Username = userName;
                    CurrentUserAccount.DisplayName = $"Welcome {userName} {userName} ;)";
                    CurrentUserAccount.ProfilePicture = null;
                }
                else
                {
                    CurrentUserAccount.DisplayName = "Invalid user, not logged in";
                    //Hide child views.
                }
            }
            catch (Exception exp)
            {
                Trace.TraceError($"Exception: {exp.Message}");
                //throw;
            }
            
            
        }
        public class CustomPrincipal : IPrincipal
        {
            public IIdentity Identity { get; private set; }
            public string[] Roles { get; private set; }

            public CustomPrincipal(IIdentity identity, string[] roles)
            {
                Identity = identity ?? throw new ArgumentNullException(nameof(identity));
                Roles = roles ?? Array.Empty<string>();
            }

            public bool IsInRole(string role)
            {
                return Array.Exists(Roles, r => r.Equals(role, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
