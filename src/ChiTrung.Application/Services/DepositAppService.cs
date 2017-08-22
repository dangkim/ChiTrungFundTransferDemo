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

namespace ChiTrung.Application.Services
{
    public class DepositAppService : IDepositAppService
    {
        private readonly IMapper _mapper;
        private readonly IDepositRepository _depositRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public DepositAppService(IMapper mapper,
                                  IDepositRepository depositRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _depositRepository = depositRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<DepositViewModel> GetAll()
        {
            return _depositRepository.GetAll().ProjectTo<DepositViewModel>();
        }

        public DepositViewModel GetByDepCode(int depCode)
        {
            return _mapper.Map<DepositViewModel>(_depositRepository.GetByDepCode(depCode));
        }

        public void DepositMoney(DepositViewModel depositViewModel)
        {
            var depositMoneyCommand = _mapper.Map<DepositMoneyCommand>(depositViewModel);
            Bus.SendCommand(depositMoneyCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
