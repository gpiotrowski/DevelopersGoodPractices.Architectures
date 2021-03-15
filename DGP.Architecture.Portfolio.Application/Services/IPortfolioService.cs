using System.Collections.Generic;
using DGP.Architecture.Portfolio.Controllers;

namespace DGP.Architecture.Portfolio.Application.Services
{
    public interface IPortfolioService
    {
        ItemDto GetItem(int id);
        List<ItemDto> GetAllItems();
        void AddItem(NewItemDto newItemDto);
        void UpdateItem(ItemDto itemDto);
        void RemoveItem(int itemId);
    }
}