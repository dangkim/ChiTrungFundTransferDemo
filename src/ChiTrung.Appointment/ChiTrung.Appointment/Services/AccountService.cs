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
        private const string ApiUrlRegister = "api/v1/Account/Register";
        private const string ApiUrlLogin = "api/v1/Account";
        private const string ApiUrlCustomer = "api/v1/customer-management";

        public AccountService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<RegisterModel> RegisterAsync(string userName, string password)
        {
            var builder = new UriBuilder(GlobalSetting.Instance.RegisterEndpoint)
            {
                Path = ApiUrlRegister
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

        public async Task<RegisterModel> LoginAsync(string userName, string password)
        {
            var builder = new UriBuilder(GlobalSetting.Instance.RegisterEndpoint)
            {
                Path = ApiUrlLogin
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

        public async Task<IEnumerable<CustomerModel>> GetCustomerAsync()
        {
            var builder = new UriBuilder(GlobalSetting.Instance.RegisterEndpoint)
            {
                Path = ApiUrlCustomer
            };

            var uri = builder.ToString();

            IEnumerable<CustomerModel> aa = null;
            var result = await _requestProvider.PostAsync(uri, aa);

            return result;
        }
    }
}
