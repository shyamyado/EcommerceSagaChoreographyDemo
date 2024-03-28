using Microsoft.AspNetCore.Mvc;
using Payment.API.Models;
using Payment.API.Services;
using System.Net;

namespace Payment.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PaymentController : ControllerBase
    {

        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService ?? throw new ArgumentNullException(nameof(paymentService)); ;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PaymentOrder), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<PaymentOrder>> GetPaymentById([FromRoute] int id)
        {
            var payment = _paymentService.GetPaymentById(id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PaymentOrder), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<PaymentOrder>> AddPayment([FromBody] NewPayment newPayment)
        {
            if (newPayment == null)
            {
                return BadRequest("Data is missing");
            }

            try
            {
                var payment = await _paymentService.AddPayment(newPayment);
                return Ok(payment);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred while making payment.");
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(PaymentOrder), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<PaymentOrder>> UpdatePayment([FromRoute]int id,[FromBody] NewPayment newPayment)
        {
            var payment = await _paymentService.UpdatePayment(id, newPayment);
            if (payment == null)
            {
                return BadRequest
            }
            return Ok(payment);
        }

    }
}
