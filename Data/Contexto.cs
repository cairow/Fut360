using Fut360.Enums;
using Fut360.Models;
using Microsoft.EntityFrameworkCore;

namespace Fut360.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        { 
        }
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<LocalModel> Local { get; set; }
        public DbSet<LoginModel> Login{ get; set; }
        

    }
}