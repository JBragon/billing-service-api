using Models.Infrastructure;

namespace Business.Interfaces
{
    public interface IBillingConsumerService
    {
        Task<CalculateResponse> Calculate(int pageIndex = 0);
    }
}
