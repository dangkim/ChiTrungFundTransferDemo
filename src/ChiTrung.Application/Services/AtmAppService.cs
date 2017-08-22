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
    public class AtmAppService : IAtmAppService
    {
        private readonly IMapper _mapper;
        private readonly IAtmRepository _atmRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public AtmAppService(IMapper mapper,
                                  IAtmRepository atmRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _atmRepository = atmRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<AtmViewModel> GetAll()
        {
            return _atmRepository.GetAll().ProjectTo<AtmViewModel>();
        }

        public AtmViewModel GetByAtmCode(string atmCode)
        {
            return _mapper.Map<AtmViewModel>(_atmRepository.GetByAtmCode(atmCode));
        }

        public void AddNewAtm(AtmViewModel atmViewModel)
        {
            var AddNewAtmCommand = _mapper.Map<AddNewAtmCommand>(atmViewModel);
            Bus.SendCommand(AddNewAtmCommand);
        }

        public void Update(AtmViewModel atmViewModel)
        {
            var updateCommand = _mapper.Map<UpdateAtmCommand>(atmViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
