using BlockbusterApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlockbusterApi.Data
{
    public class AppDataContext : IdentityDbContext
    {
        public DbSet<Prestador> Prestador { get; set; }
        public DbSet<Servico> Servico { get; set; }
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Movie>().HasData(
        //        new Movie
        //        {
        //            Id = 1,
        //            titulo = "Godzilla 2000",
        //            diretor = "Takao Okawara",
        //            estoque = 1
        //        },
        //        new Movie
        //        {
        //            Id = 2,
        //            titulo = "Godzilla Contra Ataca",
        //            diretor = "Motoyoshi Oda",
        //            estoque = 5
        //        },
        //        new Movie
        //        {
        //            Id = 3,
        //            titulo = "Godzilla",
        //            diretor = "Gareth Edwards",
        //            estoque = 3
        //        },
        //        new Movie
        //        {
        //            Id = 4,
        //            titulo = "Godzilla Resurgence",
        //            diretor = "Hideaki Anno",
        //            estoque = 4
        //        },
        //        new Movie
        //        {
        //            Id = 5,
        //            titulo = "Godzilla: Planeta dos Monstros",
        //            diretor = "Kōbun Shizuno",
        //            estoque = 2
        //        },
        //        new Movie
        //        {
        //            Id = 6,
        //            titulo = "Godzilla vs Kong",
        //            diretor = "Adam Wingard",
        //            estoque = 1
        //        });
        //}
    }
}