﻿using System.ComponentModel.DataAnnotations;

namespace Fut360.Models
{
    public class RegisterViewModel
    {
        public string Nome { get; set; }        

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "As senhas não são iguais")]
        public string? ConfirmPassword { get; set; }
    }
}
