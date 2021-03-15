using System.Collections.Generic;

namespace DGP.Architecture.Portfolio.Controllers
{
    public interface IItemRepository
    {
        Item GetItem(int id);
        List<Item> GetItems();
        List<Item> GetItems(IEnumerable<int> ids);
        void AddItem(Item item);
        void UpdateItem(Item item);
        public void RemoveItem(int itemId);
    }
}