using Newtonsoft.Json;
using OrderManagement.ApplicationService.ACL;
using OrderManagement.Domain.ACL;
using System.Net.Http;

namespace OrderManagement.CustomerManagement.ACL
{
    public class CustomerDataProvider : ICustomerDataProvider
    {
        private readonly IHttpClientFactory httpClientFactory;

        public CustomerDataProvider(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public Customer GetCustomer(Guid id)
        {
            var httpClient = httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("http://localhost:5248/");
            var apiResponse = httpClient.GetAsync($"Customer/{id}").GetAwaiter().GetResult();
            var customer = JsonConvert.DeserializeObject<Customer>(apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult());
            return customer;
        }
    }
}