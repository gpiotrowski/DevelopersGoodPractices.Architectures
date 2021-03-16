﻿using System.Threading;
using System.Threading.Tasks;
using DGP.Architecture.Warehouse.Application.Commands;
using DGP.Architecture.Warehouse.Common.Handlers;
using DGP.Architecture.Warehouse.Infrastructure.Repositories;
using MediatR;

namespace DGP.Architecture.Warehouse.Application.Handlers.CommandHandlers
{
    public class BookProductHandler : ICommandHandler<BookProduct>
    {
        private readonly IProductRepository _productRepository;

        public BookProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<Unit> Handle(BookProduct request, CancellationToken cancellationToken)
        {
            var product = _productRepository.Get(request.ProductId);

            product.DecreaseAvailability();

            _productRepository.Update(product);

            return Unit.Task;
        }
    }
}
