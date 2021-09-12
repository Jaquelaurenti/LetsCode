using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsResistence.Models
{
    [Table("Rebelde")]
    public class Rebelde
    {
        [Column("ID")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdRebelde { get; set; }

        [Column("Rebelde")]
        [StringLength(50)]
        [Required]
        public string Nome { get; set; }

    }
}
