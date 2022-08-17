using NBomber.Contracts;
using NBomber.CSharp;

namespace NBomberTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("https://localhost:7155/");

            var step = Step.Create("PostBillingConsummer", async context =>
            {
                var response = await httpClient.PostAsync("api/BillingConsumer", null);

                return response.IsSuccessStatusCode
                    ? Response.Ok()
                    : Response.Fail();
            });

            NBomberRunner
                .RegisterScenarios(
                    ScenarioBuilder.CreateScenario("PostBillingConsummerRequest", step)
                    .WithoutWarmUp()
                    .WithLoadSimulations(Simulation.InjectPerSec(1, TimeSpan.FromSeconds(10)))
                ).Run();

        }
    }
}