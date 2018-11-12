using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _13NetTeam.Core.Models
{
    public class Pergunta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Autor { get; set; }

        [Required]
        public string Descricao { get; set; }
        
        public List<Categoria> Tags { get; set; }

        public List<Resposta> Respostas  { get; set; }

        public int TotalRespostas()
        {
            if (Respostas != null)
                return Respostas.Count;
            else
               return 0;
        }

    }
}
