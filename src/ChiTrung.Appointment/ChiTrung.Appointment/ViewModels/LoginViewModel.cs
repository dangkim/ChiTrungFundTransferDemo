using System.ComponentModel;
using Caliburn.Micro;
using System.Runtime.CompilerServices;

namespace ChiTrung.AppointmentManager.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _userName;
        private string _password;

        public LoginViewModel()
        {
            UserName = "Hello World!";
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                Set(ref _userName, value);
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
            }
        }
    }
}
