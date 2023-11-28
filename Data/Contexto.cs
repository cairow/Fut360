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
        public DbSet<HorarioModel> Horarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            int id = 1;
            for (int hour = 6; hour <= 23; hour++)
            {
                builder.Entity<HorarioModel>().HasData(new HorarioModel
                {
                    Id = id++,
                    Hora_inicio = new TimeOnly(hour, 0).ToTimeSpan(),
                    Hora_fim = new TimeOnly(hour, 0).ToTimeSpan()
                });
                builder.Entity<HorarioModel>().HasData(new HorarioModel
                {
                    Id = id++,
                    Hora_inicio = new TimeOnly(hour, 30).ToTimeSpan(),
                    Hora_fim = new TimeOnly(hour, 30).ToTimeSpan()
                });
            }

            builder.Entity<HorarioModel>().HasData(new HorarioModel
            {
                Id = id,
                Hora_inicio = new TimeOnly(0, 0).ToTimeSpan(),
                Hora_fim = new TimeOnly(0, 0).ToTimeSpan()
            });
        }
    }
}
