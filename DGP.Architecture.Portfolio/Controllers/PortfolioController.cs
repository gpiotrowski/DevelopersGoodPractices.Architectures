using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DGP.Architecture.Portfolio.Application.Services;

namespace DGP.Architecture.Portfolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpGet("{id}")]
        public ItemDto GetItem(int id)
        {
            return _portfolioService.GetItem(id);
        }

        [HttpGet]
        public List<ItemDto> GetItems()
        {
            return _portfolioService.GetAllItems();
        }

        [HttpPost]
        public void AddItem(NewItemDto newItemDto)
        {
            _portfolioService.AddItem(newItemDto);
        }

        [HttpPut("{id}")]
        public void UpdateItem(ItemDto itemDto)
        {
            _portfolioService.UpdateItem(itemDto);
        }

        [HttpDelete("{itemId}")]
        public void RemoveItem(int itemId)
        {
            _portfolioService.RemoveItem(itemId);
        }
    }
}
