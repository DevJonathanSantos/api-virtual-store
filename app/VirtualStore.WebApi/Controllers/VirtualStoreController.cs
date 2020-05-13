using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VirtualStore.Entities;
using VirtualStore.Interfaces.Services;
using VirtualStore.WebApi.ViewModels;

namespace VirtualStore.WebApi.Controllers
{
    [Route("api/store")]
    [ApiController]
    public class VirtualStoreController : ControllerBase
    {
        private readonly IDigitalStoreService _digitalStoreService;
        public VirtualStoreController(IDigitalStoreService digitalStoreService)
        {
            _digitalStoreService = digitalStoreService;
        }

        [HttpPost("search")]
        public async Task<ActionResult<List<Product>>> Search(SearchViewModel model)
        {
            var product = await _digitalStoreService.Search(model.Parameter);

            return Ok(product);
        }

        [HttpPost("insert")]
        public async Task<ActionResult<List<Product>>> Insert(InsertViewModel model)
        {
            var product = await _digitalStoreService.Insert(
                model.Name,
                model.Category,
                model.Manufacturer, model.DanufacturingDate, model.Price, model.Description);

            return Ok(product);
        }
    }
}