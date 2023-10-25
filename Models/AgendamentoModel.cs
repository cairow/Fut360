using Microsoft.AspNetCore.Identity;

namespace Fut360.Models
{
    public class AgendamentoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public LocalModel LocalId { get; set; }
        public IdentityRole UsuarioId { get; set; }
    }
}
