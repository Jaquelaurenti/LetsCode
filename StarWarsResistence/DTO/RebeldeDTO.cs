using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsResistence.DTO
{
    public class RebeldeDTO
    {

        [Required]
        public string Nome { get; set; }

        [Required]
        public int Idade { get; set; }

        [Required]
        public Genero Genero { get; set; }

        public LocalizacaoDTO Localizacao { get; set; }


    }

    public enum Genero
    {
        Feminino = 0,
        Masculino = 1,
        Outro = 2,
    }
}
