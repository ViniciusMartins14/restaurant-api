using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace restaurant_api.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string SenhaHash { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = "Cliente";

        [JsonIgnore]
        public List<OrderModel> Pedidos { get; set; } = new();
    }
}
