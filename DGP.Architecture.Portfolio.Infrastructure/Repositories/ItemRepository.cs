using System.Collections.Generic;
using System.Linq;
using DGP.Architecture.Portfolio.Infrastructure.Models;

namespace DGP.Architecture.Portfolio.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private List<Item> _items { get; set; }
        public ItemRepository()
        {
            _items = new List<Item>()
            {
                new Item()
                {
                    Id =  1,
                    Name = "Book A",
                    Price = 30.99M
                }
            };
        }

        public List<Item> GetItems()
        {
            return _items;
        }

        public Item GetItem(int id)
        {
            return _items.SingleOrDefault(x => x.Id == id);
        }

        public List<Item> GetItems(IEnumerable<int> ids)
        {
            return _items.FindAll(x => ids.Contains(x.Id));
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            // Simulate "update"
            var itemToRemove = _items.Single(x => x.Id == item.Id);
            _items.Remove(itemToRemove);

            _items.Add(item);
        }

        public void RemoveItem(int itemId)
        {
            var itemToRemove = _items.Single(x => x.Id == itemId);
            _items.Remove(itemToRemove);
        }
    }
}
