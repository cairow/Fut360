using Microsoft.AspNetCore.Identity;

namespace Fut360.Models
{
    public class AgendamentoModel
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public LocalModel localModel { get; set; }
        public IdentityUser userModel { get; set; }

    }
}
