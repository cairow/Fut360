using Fut360.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Fut360.Data
{
    public class Contexto : IdentityDbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
        public DbSet<LocalModel> LocalModel { get; set; }
        public DbSet<AgendamentoModel> AgendamentoModel { get; set; }

    }
}