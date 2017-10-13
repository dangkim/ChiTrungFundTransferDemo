using System;
using System.Collections.Generic;
using ChiTrung.Application.EventSourcedNormalizers;
using ChiTrung.Application.ViewModels;
using System.Threading.Tasks;

namespace ChiTrung.Application.Interfaces
{
    public interface IClientAppService : IDisposable
    {
        void AddNewClient(ClientViewModel clientViewModel);
        Task<IEnumerable<ClientViewModel>> GetClientByName(string name);
        ClientViewModel GetClientById(int clientId);
        void Update(ClientViewModel clientViewModel);
    }
}
