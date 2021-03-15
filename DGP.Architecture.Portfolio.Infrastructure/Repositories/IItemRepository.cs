using System.Collections.Generic;
using DGP.Architecture.Portfolio.Infrastructure.Models;

namespace DGP.Architecture.Portfolio.Infrastructure.Repositories
{
    public interface IItemRepository
    {
        Item GetItem(int id);
        List<Item> GetItems();
        List<Item> GetItems(IEnumerable<int> ids);
        void AddItem(Item item);
        void UpdateItem(Item item);
        void RemoveItem(int itemId);
    }
}