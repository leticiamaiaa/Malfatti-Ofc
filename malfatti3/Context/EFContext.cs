using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using malfatti.Models;
using System.Data.Entity;

namespace malfatti.Context
{
    //lembrar de n colocar s na url de produto
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS")
        {
            Database.SetInitializer<EFContext>(
            new DropCreateDatabaseIfModelChanges<EFContext>());
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }

        internal List<Produto> Listar()
        {
            throw new NotImplementedException();
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemProduto> ItemProdutos { get; set; }

        internal void Inserir(Produto produto)
        {
            throw new NotImplementedException();
        }
    }
}