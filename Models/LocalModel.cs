using Microsoft.AspNetCore.Identity;

namespace Fut360.Models
{
    public class LocalModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Maplink {  get; set; }
        public string Contato { get; set; }
        public string? ImagemLocal { get; set; }
        public IdentityUser Aprovador { get; set; }
    }
}

