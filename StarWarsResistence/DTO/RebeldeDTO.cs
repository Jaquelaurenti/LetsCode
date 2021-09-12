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
    }
}
