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
    public class GameEventsService : IGameEventsService
    {
        private readonly IMapper _mapper;
        private readonly IGameEventsRepository _gameEventsRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public GameEventsService(IMapper mapper,
                                  IGameEventsRepository gameEventsRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _gameEventsRepository = gameEventsRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<GameEventsViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<GameEventsViewModel>>(_gameEventsRepository.GetAll());
            //return _mapper.Map<GameEventsViewModel>(_gameEventsRepository.GetAll());
        }

        public GameEventsViewModel GetById(long id)
        {
            return _mapper.Map<GameEventsViewModel>(_gameEventsRepository.GetById(id));
        }

        public GameEventsViewModel GetByTransactionId(Guid tnxId)
        {
            return _mapper.Map<GameEventsViewModel>(_gameEventsRepository.GetById(tnxId));
        }
        //public IList<CustomerHistoryData> GetAllHistory(Guid id)
        //{
        //    return CustomerHistory.ToJavaScriptCustomerHistory(_eventStoreRepository.All(id));
        //}

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
