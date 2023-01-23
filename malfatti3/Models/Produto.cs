using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using malfatti.Models;

namespace malfatti.Models
{
    public class Produto
    {
        [DisplayName("ID")]
        public long ProdutoId { get; set; }
        [StringLength(100, ErrorMessage = "O nome do produto precisa ter no mínimo 10 caracteres", MinimumLength = 10)]
        [Required(ErrorMessage = "Informe o nome do produto")]
        public string Nome { get; set; }
        [Range(1, Double.PositiveInfinity)]
        public Decimal Preco { get; set; }
        public String Descricao { get; set; }
        public bool Disponivel { get; set; }
        [DisplayName("Categoria")]
        public long? CategoriaId { get; set; }
        [DisplayName("Fabricante")]
        public long? FabricanteId { get; set; }
        public Categoria Categoria { get; set; }
        public Fabricante Fabricante { get; set; }
        [DisplayName("Tipo do Logitipo")]
        public string LogotipoMimeType { get; set; }
        [DisplayName("Logotipo")]
        public byte[] Logotipo { get; set; }
        public bool Destaque { get; set; }

        [DisplayName("Nome do arquivo")]
        public string NomeArquivo { get; set; }
        [DisplayName("Tamanho do arquivo")]
        public long TamanhoArquivo { get; set; }

        public virtual ICollection<ItemProduto> ItensProduto { get; set; }

        internal static object FirstOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}