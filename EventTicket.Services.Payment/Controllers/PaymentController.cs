using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventTicket.Services.Payment.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
