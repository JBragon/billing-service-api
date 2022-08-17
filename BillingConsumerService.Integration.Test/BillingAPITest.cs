using BillingConsumerService.Integration.Test.Utils;
using Microsoft.AspNetCore.Mvc.Testing;
using Models.Infrastructure;
using Newtonsoft.Json;
using Xunit;

namespace BillingConsumerService.Integration.Test
{
    public class BillingAPITest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public BillingAPITest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Create_Cliente_Success()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.PostAsync($"/api/BillingConsumer", null);

            var billingsRegistered = await response.ReadContentAs<CalculateResponse>();

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299

            Assert.NotNull(billingsRegistered);
            Assert.IsType<CalculateResponse>(billingsRegistered);
            Assert.True(billingsRegistered.successList.Any());
            Assert.False(billingsRegistered.errorList.Any());

        }
    }
}
