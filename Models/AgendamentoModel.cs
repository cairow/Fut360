using Microsoft.AspNetCore.Identity;

namespace Fut360.Models
{
    public class AgendamentoModel
    {
        public int Id { get; set; }
        public DateTime DataHoraInicial { get; set; }
        public DateTime DataHoraFinal { get; set; }
        public LocalModel localModel { get; set; }
        public IdentityUser userModel { get; set; }
        public bool Aprovado { get; set; }

    }
}
