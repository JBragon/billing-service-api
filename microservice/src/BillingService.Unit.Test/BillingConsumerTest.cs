using Business.Interfaces;
using Models.Infrastructure;
using Moq;
using Xunit;

namespace BillingConsumerService.Unit.Test
{
    public class BillingConsumerTest
    {
        private readonly Mock<IBillingConsumerService> _billingConsumerService;

        public BillingConsumerTest()
        {
            var fixture = new TestFixture();
            _billingConsumerService = fixture._billingConsumerService;
        }

        [Fact]
        public async Task BillingConsumerService_Calculate_Success()
        {

            var result = await _billingConsumerService.Object.Calculate();

            Assert.NotNull(result);
            Assert.True(result.successList.Any());
            Assert.IsType<CalculateResponse>(result);
        }

        [Fact]
        public async Task BillingConsumerService_Calculate_Error()
        {

            var result = await _billingConsumerService.Object.Calculate();

            Assert.NotNull(result);
            Assert.True(result.errorList.Any());
            Assert.IsType<CalculateResponse>(result);
        }
    }
}
