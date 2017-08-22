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
    public class BankAppService : IBankAppService
    {
        private readonly IMapper _mapper;
        private readonly IBankRepository _bankRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public BankAppService(IMapper mapper,
                                  IBankRepository bankRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _bankRepository = bankRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<BankViewModel> GetAll()
        {
            return _bankRepository.GetAll().ProjectTo<BankViewModel>();
        }

        public BankViewModel GetByBankCode(string bankCode)
        {
            return _mapper.Map<BankViewModel>(_bankRepository.GetByBankCode(bankCode));
        }

        public void AddNewBank(BankViewModel bankViewModel)
        {
            var addNewBankCommand = _mapper.Map<AddNewBankCommand>(bankViewModel);
            Bus.SendCommand(addNewBankCommand);
        }

        public void Update(BankViewModel customerViewModel)
        {
            var updateCommand = _mapper.Map<UpdateBankCommand>(customerViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
