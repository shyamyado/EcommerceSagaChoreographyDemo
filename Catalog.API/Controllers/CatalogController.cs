using Catalog.API.Model;
using Catalog.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogController : Controller
    {

        public readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
        {
                _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<CatalogProduct>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<CatalogProduct>>> GetCatalog()
        {
            try
            {
                var catalog = await _catalogService.GetCatalog();
                return Ok(catalog);
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(CatalogProduct),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<CatalogProduct>> GetCatalogById([FromRoute]int id)
        {
            if(id<0)
            {
                return BadRequest("Product Id must me greater than 0");
            }
            try
            {
                var catalog = await _catalogService.GetCatalogById(id);
                if(catalog == null)
                {
                    return NotFound($"Product with id {id} not found");
                }
                return Ok(catalog);
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> AddCatalog([FromBody]CatalogProduct catalogProduct)
        {
            if (catalogProduct == null)
            {
                return BadRequest("Catalog product is required.");
            }
            try
            {
                await _catalogService.AddCatalog(catalogProduct);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
