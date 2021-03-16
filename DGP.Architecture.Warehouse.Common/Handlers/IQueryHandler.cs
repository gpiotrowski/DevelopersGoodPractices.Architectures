using DGP.Architecture.Warehouse.Common.Types;
using MediatR;

namespace DGP.Architecture.Warehouse.Common.Handlers
{
    public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
    }
}