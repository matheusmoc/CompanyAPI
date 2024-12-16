using System.ComponentModel.DataAnnotations;

namespace CompanyAPI.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail fornecido não é válido.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "O documento é obrigatório.")]
        [StringLength(20, ErrorMessage = "O documento deve ter no máximo 20 caracteres.")]
        public required string Document { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [Phone(ErrorMessage = "O telefone fornecido não é válido.")]
        public required string Phone { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O endereço pode ter no máximo 200 caracteres.")]
        public required string Address { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        [MaxLength(100, ErrorMessage = "A cidade pode ter no máximo 100 caracteres.")]
        public required string City { get; set; }

        [Required(ErrorMessage = "A região é obrigatória.")]
        [MaxLength(100, ErrorMessage = "A região pode ter no máximo 100 caracteres.")]
        public required string Region { get; set; }

        [Required(ErrorMessage = "O código postal é obrigatório.")]
        [MaxLength(20, ErrorMessage = "O código postal pode ter no máximo 20 caracteres.")]
        public required string PostalCode { get; set; }

        [Required(ErrorMessage = "O país é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O país pode ter no máximo 100 caracteres.")]
        public required string Country { get; set; }
    }
}
