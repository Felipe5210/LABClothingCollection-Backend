using LabClothingCollection.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LabClothingCollection.Infrastructure.Data
{
    public class ClothingCollectionDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Colecao> Colecoes { get; set; }

        public DbSet<Modelo> Modelos { get; set; }
        public ClothingCollectionDbContext(DbContextOptions<ClothingCollectionDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.CpfOuCnpj)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();


            modelBuilder.Entity<Colecao>()
                .HasIndex(c => c.NomeDaColecao)
                .IsUnique();

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    id = 1,
                    nomeCompleto = "Koiru Teusda Vueca",
                    Genero = "Masculino",
                    DataDeNascimento = DateTime.Parse("1990-01-01"),
                    CpfOuCnpj = "141.659.360-81",
                    Telefone = "9999-9999",
                    TipoDeUsuario = "Administrador",
                    Email = "maria@mail.com",
                    Status = "Ativo"
                },
                new Usuario
                {
                    id = 2,
                    nomeCompleto = "Fulano de Tal",
                    Genero = "Masculino",
                    DataDeNascimento = DateTime.Parse("1985-05-10"),
                    CpfOuCnpj = "123.456.789-00",
                    Telefone = "8888-8888",
                    TipoDeUsuario = "Colaborador",
                    Email = "fulano@mail.com",
                    Status = "Ativo"
                },
                new Usuario
                {
                    id = 3,
                    nomeCompleto = "Ciclana Silva",
                    Genero = "Feminino",
                    DataDeNascimento = DateTime.Parse("1992-11-20"),
                    CpfOuCnpj = "987.654.321-00",
                    Telefone = "7777-7777",
                    TipoDeUsuario = "Cliente",
                    Email = "ciclana@mail.com",
                    Status = "Ativo"
                },
                new Usuario
                {
                    id = 4,
                    nomeCompleto = "Beltrano Pereira",
                    Genero = "Masculino",
                    DataDeNascimento = DateTime.Parse("1978-03-15"),
                    CpfOuCnpj = "567.890.123-00",
                    Telefone = "6666-6666",
                    TipoDeUsuario = "Administrador",
                    Email = "beltrano@mail.com",
                    Status = "Inativo"
                },

                new Usuario
                {
                    id = 5,
                    nomeCompleto = "Ana Souza",
                    Genero = "Feminino",
                    DataDeNascimento = DateTime.Parse("1995-07-25"),
                    CpfOuCnpj = "321.654.987-00",
                    Telefone = "5555-5555",
                    TipoDeUsuario = "Cliente",
                    Email = "ana@mail.com",
                    Status = "Ativo"
                }

          );
        }
    }
}
