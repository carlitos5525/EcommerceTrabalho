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
    }
}