using ChiTrung.Domain.Models;

namespace ChiTrung.Domain.Interfaces
{
    public interface IAtmRepository : IRepository<Atm>
    {
        Atm GetByAtmCode(string atmCode);
    }
}