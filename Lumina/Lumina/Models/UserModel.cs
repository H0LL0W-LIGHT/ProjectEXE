using System.ComponentModel.DataAnnotations;

namespace Lumina.WebApp.Models
{
    public class UserModel
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "Hãy nhập Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Hãy nhập Email"), EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password), Required(ErrorMessage = "Hãy nhập mật khẩu")]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
