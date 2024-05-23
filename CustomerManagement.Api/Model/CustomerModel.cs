namespace CustomerManagement.Api.Model
{
    public class CustomerModel
    {
        public Guid Id { get; set; }
        public DateTime BirthDate { get; set; }

        public string Name { get; set; }
        public bool  IsActive{ get; set; }
        public string NationalCode { get; set; }
        public string Mobile { get; set; }
    }
}