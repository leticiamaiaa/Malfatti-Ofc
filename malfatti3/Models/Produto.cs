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
        [StringLength(100, ErrorMessage = "O nome do produto precisa ter no mínimo 8 caracteres", MinimumLength = 8)]
        [Required(ErrorMessage = "Informe o nome do produto")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe data de cadastro do produto")]
        public DateTime? DataCadastro { get; set; }
        [DisplayName("Preço")]
        [Range(1, Double.PositiveInfinity)]
        [Required(ErrorMessage = "O preço deve conter um valor válido")]
        public Decimal Preco { get; set; }
        [DisplayName("Quantidade")]
        public int Qtd { get; set; }
        public String Descricao { get; set; }
        public bool Disponivel { get; set; }
        [DisplayName("Categoria")]
        public long? CategoriaId { get; set; }
        [DisplayName("Fabricante")]
        public long? FabricanteId { get; set; }
        public Categoria Categoria { get; set; }
        public Fabricante Fabricante { get; set; }
        public string UpImgMimeType { get; set; }
        public byte[] UpImg { get; set; }
        public string NomeArquivo { get; set; }
        public long TamanhoArquivo { get; set; }
        public string Slug { get; set; }
    }
}
