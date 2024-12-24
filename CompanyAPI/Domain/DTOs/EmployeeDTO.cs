namespace CompanyAPI.Domain.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string? Photo { get; set; }
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public required string Region { get; set; }
        public required string PostalCode { get; set; }
        public required string Country { get; set; }
    }
}