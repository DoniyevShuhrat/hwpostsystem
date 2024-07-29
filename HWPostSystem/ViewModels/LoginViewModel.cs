using HWPostSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HWPostSystem.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        // Fields
        private string _companyCode;
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        // Properties
        public string CompanyCode
        {
            get
            {
                return _companyCode;
            }
            set
            {
                _companyCode = value;
                OnPropertyChanged(nameof(CompanyCode));
            }
        }
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public SecureString Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged($"{nameof(ErrorMessage)}");
            }
        }
        public bool IsViewVisible
        {
            get => _isViewVisible;
            set
            {
                _isViewVisible = value;
                OnPropertyChanged($"{nameof(IsViewVisible)}");
            }
        }

        // -> Commands
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        // Constructor
        public LoginViewModel()
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(param => ExecuteRecoverPassCommand("", ""));
        }
        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                Password == null || Password.Length < 3 || CompanyCode == null || CompanyCode.Length < 2)
            {
                validData = false;
            }
            else
                validData = true;
            return validData;
        }

        private async void ExecuteLoginCommand(object obj)
        {
            ApiServices apiServices = new ApiServices();
            //var isValidUser = await apiServices.CheckLoginAsync(123, "Shuhrat", "123");
            var isValidUser = await apiServices.CheckLoginAsync(20241, "test", "@#4050302Bb");
            MessageBox.Show(isValidUser.ToString(), "Response:");
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "* Invalid username or password";
            }
            //var value = await apiServices.CheckLoginAsync(123, "Shuhrat", "");
            //throw new NotImplementedException();
        }

        private void ExecuteRecoverPassCommand(string username, string email)
        {
            //throw new NotImplementedException();
        }
    }
}
