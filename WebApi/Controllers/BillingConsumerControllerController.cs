using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingConsumerController : ControllerBase
    {
        private readonly IBillingConsumerService _billingConsumerService;

        public BillingConsumerController(IBillingConsumerService billingConsumerService)
        {
            _billingConsumerService = billingConsumerService;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var result = await _billingConsumerService.Calculate();
            return Ok(result);
        }
    }
}
