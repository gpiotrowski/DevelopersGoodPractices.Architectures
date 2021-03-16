using System.Threading.Tasks;
using DGP.Architecture.Warehouse.Common.Types;

namespace DGP.Architecture.Warehouse.Common.Buses
{
    public interface IMessageBus
    {
        Task Send(ICommand message);
        Task<T> Query<T>(IQuery<T> message);
        Task Publish(IEvent @event);
    }
}
