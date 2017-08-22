using AutoMapper;
using ChiTrung.Application.ViewModels;
using ChiTrung.Domain.Commands;

namespace ChiTrung.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, RegisterNewCustomerCommand>()
                .ConstructUsing(c => new RegisterNewCustomerCommand(c.Name, c.Email, c.BirthDate));
            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
                .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));

            CreateMap<BankViewModel, AddNewBankCommand>()
                .ConstructUsing(b => new AddNewBankCommand(b.BankCode, b.BankName));
            CreateMap<BankViewModel, UpdateBankCommand>()
                .ConstructUsing(b => new UpdateBankCommand(b.BankCode, b.BankName));

            CreateMap<AccountViewModel, AddNewAccountCommand>()
                .ConstructUsing(a => new AddNewAccountCommand(a.AccCode, a.BankCode, a.CusId));
            CreateMap<AccountViewModel, UpdateAccountCommand>()
                .ConstructUsing(a => new UpdateAccountCommand(a.AccCode, a.BankCode, a.CusId));

            CreateMap<AtmViewModel, AddNewAtmCommand>()
                .ConstructUsing(c => new AddNewAtmCommand(c.AtmCode, c.BankCode, c.AtmName));
            CreateMap<AtmViewModel, UpdateAtmCommand>()
                .ConstructUsing(c => new UpdateAtmCommand(c.AtmCode, c.BankCode, c.AtmName));

            CreateMap<DepositViewModel, DepositMoneyCommand>()
                .ConstructUsing(c => new DepositMoneyCommand(c.DepCode, c.AccCode, c.TransactionDate, c.CusId, c.Amount, c.WitCode));

            CreateMap<WithdrawalViewModel, WithdrawalAtmCommand>()
                .ConstructUsing(c => new WithdrawalAtmCommand(c.WitCode, c.AccCode, c.TransactionDate, c.Amount, c.AtmCode));

            CreateMap<FundTransferViewModel, FundTransferCommand>()
                .ConstructUsing(c => new FundTransferCommand(c.WitCode, c.AccCode, c.ToAccCode, c.TransactionDate, c.CusId, c.Amount, c.AtmCode));

        }
    }
}
