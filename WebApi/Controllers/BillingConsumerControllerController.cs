using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.HttpResponse;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingConsumerControllerController : ControllerBase
    {
        private readonly IBillingConsumerService _billingConsumerService;

        public BillingConsumerControllerController(IBillingConsumerService billingConsumerService)
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
