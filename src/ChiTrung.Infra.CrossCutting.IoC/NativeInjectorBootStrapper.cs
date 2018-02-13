using AutoMapper;
using ChiTrung.Application.Interfaces;
using ChiTrung.Application.Services;
using ChiTrung.Domain.CommandHandlers;
using ChiTrung.Domain.Commands;
using ChiTrung.Domain.Core.Bus;
using ChiTrung.Domain.Core.Events;
using ChiTrung.Domain.Core.Notifications;
using ChiTrung.Domain.EventHandlers;
using ChiTrung.Domain.Events;
using ChiTrung.Domain.Interfaces;
using ChiTrung.Infra.CrossCutting.Bus;
using ChiTrung.Infra.CrossCutting.Identity.Authorization;
using ChiTrung.Infra.CrossCutting.Identity.Models;
using ChiTrung.Infra.CrossCutting.Identity.Services;
using ChiTrung.Infra.Data.Context;
using ChiTrung.Infra.Data.EventSourcing;
using ChiTrung.Infra.Data.Repository;
using ChiTrung.Infra.Data.Repository.EventSourcing;
using ChiTrung.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ChiTrung.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<IClientAppService, ClientAppService>();
            services.AddScoped<IBankAppService, BankAppService>();
            services.AddScoped<IAccountAppService, AccountAppService>();
            services.AddScoped<IAtmAppService, AtmAppService>();
            services.AddScoped<IDepositAppService, DepositAppService>();
            services.AddScoped<IWithdrawalAppService, WithdrawalAppService>();
            services.AddScoped<IGameEventsService, GameEventsService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            // Bank - Events
            services.AddScoped<INotificationHandler<BankAddedEvent>, BankEventHandler>();
            services.AddScoped<INotificationHandler<BankUpdatedEvent>, BankEventHandler>();

            // Account - Events
            services.AddScoped<INotificationHandler<AccountAddedEvent>, AccountEventHandler>();
            services.AddScoped<INotificationHandler<AccountUpdatedEvent>, AccountEventHandler>();

            // Atm - Events
            services.AddScoped<INotificationHandler<AtmAddedEvent>, AtmEventHandler>();
            services.AddScoped<INotificationHandler<AtmUpdatedEvent>, AtmEventHandler>();

            // Domain - Commands
            services.AddScoped<INotificationHandler<RegisterNewCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<INotificationHandler<RemoveCustomerCommand>, CustomerCommandHandler>();

            // Bank - Commands
            services.AddScoped<INotificationHandler<AddNewBankCommand>, BankCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateBankCommand>, BankCommandHandler>();

            // Account - Commands
            services.AddScoped<INotificationHandler<AddNewAccountCommand>, AccountCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateAccountCommand>, AccountCommandHandler>();

            // Atm - Commands
            services.AddScoped<INotificationHandler<AddNewAtmCommand>, AtmCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateAtmCommand>, AtmCommandHandler>();

            // Deposit/Withdrawal - Commands
            services.AddScoped<INotificationHandler<DepositMoneyCommand>, DepositCommandHandler>();
            services.AddScoped<INotificationHandler<WithdrawalAtmCommand>, WithdrawalCommandHandler>();
            services.AddScoped<INotificationHandler<FundTransferCommand>, WithdrawalCommandHandler>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAtmRepository, AtmRepository>();
            services.AddScoped<IDepositRepository, DepositRepository>();
            services.AddScoped<IWithdrawalRepository, WithdrawalRepository>();
            services.AddScoped<IGameEventsRepository, GameEventsRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ChiTrungContext>();
            services.AddScoped<TigersContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}