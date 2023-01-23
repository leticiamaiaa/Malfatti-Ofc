using Models.Sistema;
using System.Collections.Generic;

namespace malfatti.Models.Sistema
{
    public class Cart
    {
        public long CartId { get; set; }
        public string UserId { get; set; }
        public UsuarioAdm Usuario { get; set; }
        public virtual ICollection<Produto> ProdutosCarrinho { get; set; }
    }
}
