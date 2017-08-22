using System.Threading.Tasks;
using ChiTrung.Domain.Core.Commands;
using ChiTrung.Domain.Core.Events;

namespace ChiTrung.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}