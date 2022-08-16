using Models.HttpResponse;

namespace Models.Infrastructure
{
    public class CalculateResponse
    {
        public List<BillingResponse> successList { get; set; }
        public List<BillingResponseError> errorList { get; set; }
    }

    public class BillingResponseError : BillingResponse
    {
        public string Error { get; set; }
    }
}
