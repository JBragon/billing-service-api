using Models.HttpRequest;
using Models.HttpResponse;
using Refit;

namespace Business.HttpInterfaces
{
    public interface IClientHttpService
    {
        [Get("/api/Client")]
        Task<SearchResponse<ClientResponse>> GetClients(ClientFilter filter);
    }
}
