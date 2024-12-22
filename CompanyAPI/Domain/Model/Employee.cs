using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CompanyAPI.Domain.Model
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        public int Id { get; private set; }

        public string? Photo { get; private set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; private set; }

        [Required]
        [EmailAddress]
        public string Email { get; private set; }


        [Required]
        [StringLength(20)]
        public string Document { get; private set; }

        [Required]
        [Phone]
        public string Phone { get; private set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; private set; }

        [Required]
        [MaxLength(100)]
        public string City { get; private set; }

        [Required]
        [MaxLength(100)]
        public string Region { get; private set; }

        [Required]
        [MaxLength(20)]
        public string PostalCode { get; private set; }

        [Required]
        [MaxLength(100)]
        public string Country { get; private set; }

        public Employee(string name, string? photo, string email, string document, string phone, string address, string city, string region, string postalCode, string country)
        {
            Name = name ?? throw new NotImplementedException(nameof(name));
            Photo = photo;
            Email = email;
            Document = document;
            Phone = phone;
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalCode;
            Country = country;
        }
    }
}
