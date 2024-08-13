using System.ComponentModel.DataAnnotations;

namespace Lumina.WebApp.Models.ViewModels
{
    public class LoginViewModel
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "Hãy nhập Username")]
        public string Username { get; set; }
        [DataType(DataType.Password), Required(ErrorMessage = "Hãy nhập mật khẩu")]
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
