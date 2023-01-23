using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Models.Sistema;
using malfatti.Models.Sistema;

namespace malfatti.Models.Cart
{
    public class OrderDetails
    {
        [Key]
        public long Id { get; set; }
        public long OrderId { get; set; }
        public string UserId { get; set; }
        public long ProdutoId { get; set; }
        public int Quantidade { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Orders { get; set; }
        [ForeignKey("UserId")]
        public virtual UsuarioAdm Users { get; set; }
        [ForeignKey("ProdutoId")]
        public virtual Produto Produtos { get; set; }
    }
}
