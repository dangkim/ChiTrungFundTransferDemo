using AutoMapper;
using ChiTrung.Application.ViewModels;
using ChiTrung.Domain.Models;

namespace ChiTrung.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<Client, ClientViewModel>();
            CreateMap<Bank, BankViewModel>();
            CreateMap<Account, AccountViewModel>();
            CreateMap<Atm, AtmViewModel>();
            CreateMap<Deposit, DepositViewModel>();
            CreateMap<Withdrawal, WithdrawalViewModel>();
            CreateMap<GameEvents, GameEventsViewModel>();
        }
    }
}
