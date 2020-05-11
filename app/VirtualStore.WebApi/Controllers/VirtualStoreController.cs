using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using VirtualStore.Entities;
using VirtualStore.Interfaces;
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
        //[Route("teste")]
        public async Task<ActionResult<List<Product>>> Search(CategoryViewModel model)
        
        {
            return await _digitalStoreService.Search(model.Category);
        }
    }
}