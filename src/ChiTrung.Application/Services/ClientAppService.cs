using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChiTrung.Application.EventSourcedNormalizers;
using ChiTrung.Application.Interfaces;
using ChiTrung.Application.ViewModels;
using ChiTrung.Domain.Commands;
using ChiTrung.Domain.Core.Bus;
using ChiTrung.Domain.Interfaces;
using ChiTrung.Infra.Data.Repository.EventSourcing;
using System.Threading.Tasks;

namespace ChiTrung.Application.Services
{
    public class ClientAppService : IClientAppService
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public ClientAppService(IMapper mapper,
                                  IClientRepository clientRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public void AddNewClient(ClientViewModel clientViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ClientViewModel>> GetClientByName(string name)
        {
            var data = await _clientRepository.GetClientByName(name);
            return _mapper.Map<IEnumerable<ClientViewModel>>(data);
        }

        public ClientViewModel GetClientById(int clientId)
        {
            return _mapper.Map<ClientViewModel>(_clientRepository.GetClientById(clientId));
        }

        public void Update(ClientViewModel clientViewModel)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
