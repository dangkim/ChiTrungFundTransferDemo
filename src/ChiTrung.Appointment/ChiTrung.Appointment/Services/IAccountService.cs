using ChiTrung.AppointmentManager.Models;
using ChiTrung.AppointmentManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiTrung.AppointmentManager.Services
{
    public interface IAccountService
    {
        Task<RegisterModel> RegisterAsync(string userName, string password);
        Task<RegisterModel> LoginAsync(string userName, string password);
        Task<IEnumerable<CustomerModel>> GetCustomerAsync();
    }
}
