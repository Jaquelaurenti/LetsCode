using System;
using System.ComponentModel.DataAnnotations;

namespace StarWarsResistence.DTO
{
    public class LocalizacaoDTO
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Galaxia { get; set; }

        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Longitude { get; set; }

    }
}
