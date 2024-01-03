using External.PaymentGateway.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace External.PaymentGateway.Controllers
{
    [Route("api/paymentapprover")]
    [ApiController]
    public class PaymentApproverController : ControllerBase
    {
        [HttpPost]
        public IActionResult TryPayment([FromBody] PaymentDto payment)
        {

            int num = new Random().Next(1000);
            if (num > 500)
                return Ok(true);

            return Ok(false);
        }
    }
}
