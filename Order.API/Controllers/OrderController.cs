using Microsoft.AspNetCore.Mvc;
using System.Net;
using Order.API.Model;
using Order.API.Services;


namespace Order.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : Controller
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
                _orderService = orderService;
        }

        [HttpGet]
        [Route("/{orderId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> GetOrder([FromRoute] int OrderId)
        {

           var order = await _orderService.GetOrderById(OrderId);
            return Ok(order);
        }

        [HttpPost]
        [Route("/")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductOrder>> AddOrder([FromBody]NewOrder newOrder)
        {
            var createdOrder = _orderService.CreateOder(newOrder);
            return Ok("Add order");
        }

        [HttpPut]
        [Route("/")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductOrder>> UpdateOrder([FromBody] NewOrder changeOrder)
        {
            var updatedOrder = _orderService.UpdateOrder(changeOrder);
            return Ok(updatedOrder);
        }

    }
}
