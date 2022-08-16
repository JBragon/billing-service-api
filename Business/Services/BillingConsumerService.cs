using Business.HttpInterfaces;
using Business.Interfaces;
using Models.HttpRequest;
using Models.HttpResponse;
using Models.Infrastructure;
using Refit;

namespace Business.Services
{
    public class BillingConsumerService : IBillingConsumerService
    {
        private readonly IBillingHttpService _billingHttpService;
        private readonly IClientHttpService _clientHttpService;
        private CalculateResponse calculateResponse;

        public BillingConsumerService(IBillingHttpService billingHttpService, IClientHttpService clientHttpService)
        {
            _billingHttpService = billingHttpService;
            _clientHttpService = clientHttpService;
            calculateResponse = new CalculateResponse
            {
                successList = new List<BillingResponse>(),
                errorList = new List<BillingResponseError>()
            };
        }

        public async Task<CalculateResponse> Calculate(int pageIndex = 0)
        {

            ClientFilter filter = new ClientFilter
            {
                Page = pageIndex,
                RowsPerPage = 1000,
                Sort = "CPF",
                SortDir = "Asc"
            };

            SearchResponse<ClientResponse> response = await _clientHttpService.GetClients(filter);

            if (response.Items.Any())
            {
                foreach (ClientResponse item in response.Items)
                {
                    BillingPost billingPost = new BillingPost
                    {
                        CPF = item.CPF,
                        DueDate = DateTime.Now,
                        ChargeAmount = Convert.ToDecimal(item.CPF.Substring(0, 2) + item.CPF.Substring(item.CPF.Length - 2))
                    };

                    try
                    {
                        var r = await _billingHttpService.CreateBilling(billingPost);
                        calculateResponse.successList.Add(r);
                    }
                    catch (ValidationApiException ex)
                    {
                        calculateResponse.errorList.Add(new BillingResponseError
                        {
                            CPF = billingPost.CPF,
                            ChargeAmount = billingPost.ChargeAmount,
                            DueDate = billingPost.DueDate,
                            Error =
                            $"{string.Join(",", ex.Content is not null && ex.Content.Errors.Any() ? ex.Content.Errors.Select(e => e.Value[0]).FirstOrDefault() : "")} {ex.InnerException?.Message}"
                        });
                    }
                    catch (Exception ex)
                    {
                        calculateResponse.errorList.Add(new BillingResponseError
                        {
                            CPF = billingPost.CPF,
                            ChargeAmount = billingPost.ChargeAmount,
                            DueDate = billingPost.DueDate,
                            Error = $"{ex.ToString()} {ex.InnerException?.Message}"

                        });
                    }

                }

                if (response.Items.Count() < response.RowsCount)
                {
                    await Calculate(pageIndex + 1);
                }
            }

            return calculateResponse;
        }
    }
}
