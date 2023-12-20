using System.ComponentModel.DataAnnotations;

namespace Trinca.Domain.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email é um campo obrigatório")]
        [EmailAddress(ErrorMessage = "Email em formato inválido")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Email é um campo obrigatório")]        
        [StringLength(12, ErrorMessage = "Senha deve ter no máximo {1} caracteres")]
        public string Password { get; set; }
    }
}
