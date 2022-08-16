using Models.HttpRequest;
using Models.HttpResponse;
using Refit;

namespace Business.HttpInterfaces
{
    public interface IBillingHttpService
    {
        [Post("/api/Billing")]
        Task<BillingResponse> CreateBilling(BillingPost billing);
    }
}
