using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Desafio_Backend_Novaweb.Models
{
    public class Contato
    {
        [Key]
        public int ContatoID { get; set; }

        [Required(ErrorMessage = "Nome não pode ser vazio ou nulo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email não pode ser vazio ou nulo")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefone não pode ser vazio ou nulo")]
        [DataType(DataType.PhoneNumber)]
        public List<string> Telefone { get; set; }
    }
}
