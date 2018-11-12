using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _13NetTeam.Core.Models
{
    public class Resposta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Autor { get; set; }

        [Required]
        public string Descricao { get; set; }
    }
}
