using Caliburn.Micro;
using ChiTrung.AppointmentManager.Models;
using ChiTrung.AppointmentManager.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Websockets;
using Xamarin.Forms;

namespace ChiTrung.AppointmentManager.ViewModels
{
    public class RegisterViewModel : Screen
    {
        private string _messageFromServer;
        private string _messageFromXM;
        private string _userName;
        private string _password;
        private string _validationUserNameText;
        private string _validationPasswordText;
        private bool _isUserNameInValid;
        private bool _isPasswordInValid;
        private IAccountService _accountService;

        private bool _echo, _failed;
        private readonly IWebSocketConnection _connection;

        public RegisterViewModel(IAccountService accountService)
        {
            _accountService = accountService;
            UserName = "waitmail06@gmail.com";
            Password = "10Th@nhtam";

            // Get a websocket from your PCL library via the factory
            _connection = WebSocketFactory.Create();
            _connection.OnOpened += Connection_OnOpened;
            _connection.OnMessage += Connection_OnMessage;
            _connection.OnClosed += Connection_OnClosed;
            _connection.OnError += Connection_OnError;
        }

        public string MessageFromServer
        {
            get { return _messageFromXM; }
            set
            {
                Set(ref _messageFromXM, value);
            }
        }

        public string MessageFromXM
        {
            get { return _messageFromServer; }
            set
            {
                Set(ref _messageFromServer, value);
            }
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
            var a = await _accountService.LoginAsync(UserName, Password);
            //var a = await _accountService.RegisterAsync(UserName, Password);
            //var authCookie = 
        }

        public async Task CustomerAsync()
        {
            var a = await _accountService.GetCustomerAsync();
            //var a = await _accountService.RegisterAsync(UserName, Password);
            //var authCookie = 
        }

        public async Task SendAsync()
        {
            _echo = false;
            _connection.Send(MessageFromXM);
            MessageFromXM = "";

            while (!_echo && !_failed)
            {
                await Task.Delay(10);
            }
        }

        protected override async void OnActivate()
        {
            base.OnActivate();

            _echo = _failed = false;

            Timeout();

            _connection.Open("ws://192.168.1.3:8081/");

            while (!_connection.IsOpen && !_failed)
            {
                await Task.Delay(10);
            }
        }

        private async void Timeout()
        {
            await Task.Delay(1200000);
            _failed = true;
            Debug.WriteLine("Timeout");
        }

        private static void Connection_OnClosed()
        {
            Debug.WriteLine("Closed !");
        }
        private void Connection_OnError(string obj)
        {
            _failed = true;
            Debug.WriteLine("ERROR " + obj);
        }

        private void Connection_OnOpened()
        {
            Debug.WriteLine("Opened !");
        }

        private void Connection_OnMessage(string obj)
        {
            _echo = true;
            Device.BeginInvokeOnMainThread(() =>
            {
                MessageFromServer = obj;
            });
        }
    }
}
