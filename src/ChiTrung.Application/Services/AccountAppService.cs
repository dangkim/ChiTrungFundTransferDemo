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
    public class AccountAppService : IAccountAppService
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public AccountAppService(IMapper mapper,
                                  IAccountRepository accountRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<AccountViewModel> GetAll()
        {
            return _accountRepository.GetAll().ProjectTo<AccountViewModel>();
        }

        public AccountViewModel GetByAccCode(string accCode)
        {
            return _mapper.Map<AccountViewModel>(_accountRepository.GetByAccCode(accCode));
        }

        public void AddNewAccount(AccountViewModel accountViewModel)
        {
            var addNewAccountCommand = _mapper.Map<AddNewAccountCommand>(accountViewModel);
            Bus.SendCommand(addNewAccountCommand);
        }

        public void Update(AccountViewModel accountViewModel)
        {
            var updateCommand = _mapper.Map<UpdateAccountCommand>(accountViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
