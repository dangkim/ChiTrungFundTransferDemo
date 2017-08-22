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
    public class WithdrawalAppService : IWithdrawalAppService
    {
        private readonly IMapper _mapper;
        private readonly IWithdrawalRepository _withdrawalRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public WithdrawalAppService(IMapper mapper,
                                  IWithdrawalRepository withdrawalRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _withdrawalRepository = withdrawalRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<WithdrawalViewModel> GetAll()
        {
            return _withdrawalRepository.GetAll().ProjectTo<WithdrawalViewModel>();
        }

        public WithdrawalViewModel GetByWitCode(string witCode)
        {
            return _mapper.Map<WithdrawalViewModel>(_withdrawalRepository.GetByWitCode(witCode));
        }

        public void WithdrawalAtm(WithdrawalViewModel withdrawalViewModel)
        {
            var withdrawalAtmCommand = _mapper.Map<WithdrawalAtmCommand>(withdrawalViewModel);
            Bus.SendCommand(withdrawalAtmCommand);
        }

        public void FundTransfer(FundTransferViewModel fundTransferViewModel)
        {
            var fundTransferCommand = _mapper.Map<FundTransferCommand>(fundTransferViewModel);
            Bus.SendCommand(fundTransferCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
