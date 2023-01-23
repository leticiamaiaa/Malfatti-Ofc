using malfatti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace malfatti.Carrinho.Models
{
    public class ItemCarrinho
    {
        public long? ItemCarrinhoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public Decimal ValorUnitario { get; set; }
        public Decimal SubTotal { get { return Quantidade * ValorUnitario; } }

    }
}