using System;
using System.Collections.Generic;
using ChiTrung.Application.EventSourcedNormalizers;
using ChiTrung.Application.ViewModels;

namespace ChiTrung.Application.Interfaces
{
    public interface IAtmAppService : IDisposable
    {
        void AddNewAtm(AtmViewModel atmViewModel);
        IEnumerable<AtmViewModel> GetAll();
        AtmViewModel GetByAtmCode(string atmCode);
        void Update(AtmViewModel atmViewModel);
    }
}
