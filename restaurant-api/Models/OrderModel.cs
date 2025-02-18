using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace restaurant_api.Models
{
    public class OrderModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserModel Usuario { get; set; } = null!;

        public List<OrderProductModel> Produtos { get; set; } = new();

        [Required]
        public string Status { get; set; } = "Pendente";
    }

    public class OrderProductModel
    {
        public int OrderId { get; set; }
        public OrderModel Pedido { get; set; } = null!;

        public int ProductId { get; set; }
        public ProductModel Produto { get; set; } = null!;

        [Required]
        public int Quantidade { get; set; } = 1;
    }
}
