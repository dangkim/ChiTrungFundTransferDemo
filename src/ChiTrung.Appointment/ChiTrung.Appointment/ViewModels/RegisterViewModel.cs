using Caliburn.Micro;
using ChiTrung.AppointmentManager.Models;
using ChiTrung.AppointmentManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiTrung.AppointmentManager.ViewModels
{
    public class RegisterViewModel : Screen
    {
        private string _userName;
        private string _password;
        private string _validationUserNameText;
        private string _validationPasswordText;
        private bool _isUserNameInValid;
        private bool _isPasswordInValid;
        private IAccountService _accountService;

        public RegisterViewModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                Set(ref _userName, value);
                CheckUserNameValidation();
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                Set(ref _password, value);
                CheckPassWordValidation();
            }
        }

        public string ValidationUserNameText
        {
            get { return _validationUserNameText; }
            set
            {
                Set(ref _validationUserNameText, value);
            }
        }

        public string ValidationPasswordText
        {
            get { return _validationPasswordText; }
            set
            {
                Set(ref _validationPasswordText, value);
            }
        }

        public bool IsUserNameInValid
        {
            get { return _isUserNameInValid; }
            set
            {
                Set(ref _isUserNameInValid, value);
            }
        }

        public bool IsPasswordInValid
        {
            get { return _isPasswordInValid; }
            set
            {
                Set(ref _isPasswordInValid, value);
            }
        }

        private void CheckUserNameValidation()
        {
            if (string.IsNullOrEmpty(UserName))
            {
                IsUserNameInValid = true;
                ValidationUserNameText = "Enter user name";
            }
            else
            {
                IsPasswordInValid = false;
                ValidationUserNameText = string.Empty;
            }
        }

        private void CheckPassWordValidation()
        {
            if (string.IsNullOrEmpty(Password))
            {
                IsPasswordInValid = true;
                ValidationPasswordText = "Enter the password";
            }
            else
            {
                IsPasswordInValid = false;
                ValidationPasswordText = string.Empty;
            }
        }

        public async Task RegisterAsync()
        {
            var a = await _accountService.RegisterAsync(UserName, Password);
        }
    }
}
