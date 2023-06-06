using DesafioAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Categoria> Categorias {get;set;}
        public DbSet<Starter> Starters {get;set;}

        public DbSet<Usuario> Usuarios{get;set;}
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.Entity<Starter>()
                .HasOne(starter => starter.Categoria)
                .WithMany(categoria => categoria.Starters)
                .HasForeignKey(starter => starter.CategoriaId);
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}