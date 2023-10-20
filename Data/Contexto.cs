using Fut360.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fut360.Data
{
    public class Contexto : IdentityDbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        { 
        }
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<LocalModel> Local { get; set; }
        
        

    }
}