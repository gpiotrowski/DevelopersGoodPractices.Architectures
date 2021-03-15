using System;
using System.Collections.Generic;
using System.Linq;
using DGP.Architecture.Portfolio.Controllers;
using DGP.Architecture.Portfolio.Infrastructure.Models;
using DGP.Architecture.Portfolio.Infrastructure.Repositories;

namespace DGP.Architecture.Portfolio.Application.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IItemRepository _itemRepository;

        public PortfolioService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public ItemDto GetItem(int id)
        {
            var item = _itemRepository.GetItem(id);

            if (item == null) return null;

            var itemDto = MapToItemDto(item);

            return itemDto;
        }

        public List<ItemDto> GetAllItems()
        {
            var items = _itemRepository.GetItems();

            var itemsDto = items.Select(MapToItemDto).ToList();

            return itemsDto;
        }

        public void AddItem(NewItemDto newItemDto)
        {
            var allItems = _itemRepository.GetItems();

            if (allItems.Any(x => x.Name == newItemDto.Name))
            {
                throw new Exception("Item with that name already exist!");
            }

            if (newItemDto.Price < 0)
            {
                throw new Exception("Negative price not allowed!");
            }

            var newItem = new Item()
            {
                Name = newItemDto.Name,
                Price = newItemDto.Price
            };

            _itemRepository.AddItem(newItem);
        }

        public void UpdateItem(ItemDto itemDto)
        {
            var item = _itemRepository.GetItem(itemDto.Id);

            if (item == null)
            {
                throw new Exception("Requested item doesn't exist!");
            }

            item.Name = itemDto.Name;
            item.Price = item.Price;

            _itemRepository.UpdateItem(item);
        }

        public void RemoveItem(int itemId)
        {
            var item = _itemRepository.GetItem(itemId);

            if (item == null)
            {
                throw new Exception("Requested item doesn't exist!");
            }

            _itemRepository.RemoveItem(itemId);
        }

        private ItemDto MapToItemDto(Item item)
        {
            return new ItemDto()
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price
            };
        }
    }
}
