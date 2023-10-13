﻿using Fut360.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fut360.Models
{
    
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Nome { get; set; }
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o Email do usuário")]
        [EmailAddress(ErrorMessage = "O email informado não é válido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o número de contato do usuário")]
        [Phone(ErrorMessage = "O número informado não é um telefone válido!")]
        public string Contato { get; set; }
        public PerfilEnum Perfil { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

    }
}