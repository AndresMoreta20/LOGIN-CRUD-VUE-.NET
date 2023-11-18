using System.ComponentModel.DataAnnotations;

namespace CRUD_LOGIN.Dtos
{
    public class RegisterRequest
    {
        [Required]
        public string? UserName { get; set; }
        public string Username { get; internal set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
