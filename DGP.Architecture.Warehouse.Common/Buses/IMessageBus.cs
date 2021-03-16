using System.Threading.Tasks;
using DGP.Architecture.Warehouse.Common.Types;

namespace DGP.Architecture.Warehouse.Common.Buses
{
    public interface IMessageBus
    {
        Task Send(IMessage message);
        Task<T> Query<T>(IMessage<T> message);
    }
}
