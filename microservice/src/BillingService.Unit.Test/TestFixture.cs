using Business.Interfaces;
using Models.HttpResponse;
using Models.Infrastructure;
using Moq;
using Moq.AutoMock;

namespace BillingConsumerService.Unit.Test
{
    public class TestFixture
    {

        public readonly Mock<IBillingConsumerService> _billingConsumerService;

        public TestFixture()
        {
            AutoMocker mocker = new AutoMocker();

            CalculateResponse response = new CalculateResponse
            {
                successList = new List<BillingResponse>
                {
                    new BillingResponse {
                        Id = Guid.NewGuid().ToString(),
                        CPF = "456.462.300-12",
                        DueDate = DateTime.Now,
                        ChargeAmount = 1234
                    }
                },
                errorList = new List<BillingResponseError>
                {
                    new BillingResponseError
                    {
                        Error ="CPF Inválido",
                        CPF = "456.462.300-18",
                        DueDate = DateTime.Now,
                        ChargeAmount = 1234
                    }
                }
            };

            mocker.GetMock<IBillingConsumerService>().Setup(uow => uow.Calculate(It.IsAny<int>())).Returns(Task.FromResult(response));

            _billingConsumerService = mocker.GetMock<IBillingConsumerService>();
        }
    }
}
