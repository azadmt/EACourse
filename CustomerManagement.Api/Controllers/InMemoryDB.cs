using CustomerManagement.Api.Model;

namespace CustomerManagement.Api.Controllers
{
    public static class DB
    {
        static List<CustomerModel> customers = new();

        static DB()
        {
            customers.Add(new CustomerModel()
            {
                Id = new Guid("5B02A3A2-4CDD-4076-8DDE-BDCAE904CD05"),
                Name = "Customer 1",
                BirthDate = DateTime.Now.AddYears(-18),

                IsActive = true,
            });
        }

        public static CustomerModel GetCustomer(Guid id)
        {
            return customers.FirstOrDefault(x => x.Id == id);
        }
    }
}