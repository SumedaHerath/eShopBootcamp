using System.Net;
using System.Threading.Tasks;
using eShop.Catalog.API.Exception;
using eShop.Catalog.API.Models;
using eShop.Catalog.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Catalog.API.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            this._catalogService = catalogService;
        }

        [HttpGet("catalogtypes")]
        public IActionResult GetCatalogTypes()
        {
            var result = _catalogService.GetCatalogTypes();
            return Ok(result);
        }

        [HttpGet("catalogbrands")]
        public IActionResult GetCatalogBrands()
        {
            var result = _catalogService.GetCatalogBrands();
            return Ok(result);            
        }

        [HttpGet("catalogitems/{id}")]
        public async Task<IActionResult> GetCatalogItem(string id)
        {
            var result = await _catalogService.GetCatalogItemAsync(id);
            return Ok(result);
        }

        [HttpGet("catalogitems/{brandid}/{typeid}")]
        public  IActionResult GetCatalogItems(string brandId, string typeId)
        {
            var result = _catalogService.GetCatalogItems(brandId,typeId);
            return Ok(result);
        }
               
        [HttpPost("catalogitems")]
        public async Task<IActionResult> CreateCatalogItem([FromBody] CatalogItem catalogItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _catalogService.CreateCatalogItemAsync(catalogItem);
            return Ok();
        }
                
        [HttpPut("catalogitems/{id}")]
        public async Task<IActionResult> UpdateCatalogItemAsync(string id, [FromBody] CatalogItem catalogItem)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _catalogService.UpdateCatalogItemAsync(id, catalogItem);
                return Ok();
            }
            catch (CatalogItemNotFoundException ex)
            {
                var problem = new ProblemDetails
                {
                    Title = "Unable to delete the catalog item",
                    Status = (int)HttpStatusCode.NotFound,
                    Detail = "Catalog Item not found",
                    Instance = $"catalog/catalogItems/{id}"
                };
                return BadRequest(problem);
            }
        }
    }
}
