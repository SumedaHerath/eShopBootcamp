using eShop.Inventory.API.Exception;
using eShop.Inventory.API.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace eShop.Inventory.API.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private IInventoryService _inventroyService;

        public InventoryController(IInventoryService inventroyService)
        {
            _inventroyService = inventroyService;
        }

        [HttpDelete("{catalogItemId}/{reorderPoint}")]
        public async Task<IActionResult> SetReorderPoint(int catalogItemId, int reorderPoint)
        {
            try
            {
                await _inventroyService.SetReorderPoint(catalogItemId, reorderPoint);
                return Ok();
            }
            catch (CatalogItemStockNotFoundException ex)
            {
                var problem = new ProblemDetails
                {
                    Title = "Unable to set the reorder point for catalog item",
                    Status = (int)HttpStatusCode.NotFound,
                    Detail = "Stock is not created for Catalog Item",
                    Instance = $"inventory/{catalogItemId}/{reorderPoint}"
                };
                return BadRequest(problem);
            }
        }
    }
}
