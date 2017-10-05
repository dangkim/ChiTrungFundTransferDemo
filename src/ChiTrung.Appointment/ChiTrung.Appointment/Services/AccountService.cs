using ChiTrung.AppointmentManager.Models;
using ChiTrung.AppointmentManager.RequestProviders;
using ChiTrung.AppointmentManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiTrung.AppointmentManager.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRequestProvider _requestProvider;
        private const string ApiUrlBase = "api/v1/Account/Register";

        public AccountService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<RegisterModel> RegisterAsync(string userName, string password)
        {
            var builder = new UriBuilder(GlobalSetting.Instance.RegisterEndpoint)
            {
                Path = ApiUrlBase
            };

            var uri = builder.ToString();

            var result = await _requestProvider.PostAsync(uri, new RegisterModel
            {
                UserName = userName,
                Password = password,
                ConfirmPassword = password
            });

            return result;
        }
    }
}
