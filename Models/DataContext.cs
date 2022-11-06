using Microsoft.EntityFrameworkCore;


namespace EcommerceTrabalho.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<CategoriaProduto> Categorias {get; set;}
        public DbSet<Produto> Produtos {get; set;}

        public DbSet<Usuario> Usuarios {get; set;}

        public DbSet<Compra> Compras {get; set;}
        public DbSet<Carrinho> Carrinhos {get; set;}
    }
}