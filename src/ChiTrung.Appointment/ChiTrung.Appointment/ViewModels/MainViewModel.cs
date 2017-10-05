using System.ComponentModel;
using Caliburn.Micro;
using System.Runtime.CompilerServices;

namespace ChiTrung.AppointmentManager.ViewModels
{
    public class MainViewModel : Screen
    {
        private string _firstName;
        private string _lastName;
        private string _email;

        public MainViewModel()
        {
            FirstName = "Hello World!";
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                Set(ref _firstName, value);
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                Set(ref _lastName, value);
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                Set(ref _email, value);
            }
        }
    }
}
