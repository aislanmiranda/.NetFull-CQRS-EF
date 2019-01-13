using System.Threading.Tasks;
using Red.Domain.Core.Commands;
using Red.Domain.Core.Events;


namespace Red.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
