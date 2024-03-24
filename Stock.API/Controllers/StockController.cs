using Microsoft.AspNetCore.Mvc;
using Stock.API.Model;
using Stock.API.Services;
using System.Net;

namespace Stock.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StockController : Controller
    {

        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;   
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetStock()
        {
            var stocks = await _stockService.GetStock();
            return Ok(stocks);
        }

        [HttpGet]
        [Route("{pdoduct_id}")]
        public IActionResult GetStockById([FromRoute]int pdoduct_id) {
            var productId = pdoduct_id;
            return Ok($"get stsock by id : {productId}");
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> AddStock([FromBody] ProductStock productStock)
        {
            var response = await _stockService.AddStock(productStock);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdateStock([FromBody] ProductStock productStock)
        {
            var res = await _stockService.UpdateStock(productStock);
            
            return Ok(res);
        }

    }
}
