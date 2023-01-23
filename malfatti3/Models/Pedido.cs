using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using malfatti.Models;

namespace malfatti.Models
{
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }
        public int UsuarioID { get; set; }
        public DateTime DtPedido { get; set; }

        //public StatusPedido StatusPedido { get; set; } // StatusPedido seria um Enum

        public DateTime DtPagamento { get; set; }
        public Decimal ValorTotal { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<ItemProduto> ItensProduto { get; set; }
    }
}