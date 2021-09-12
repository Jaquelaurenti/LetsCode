using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarWarsResistence.Models
{
    [Table("Localizacao")]
    public class Localizacao
    {
        [Column("Id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column("Nome")]
        [StringLength(50)]
        [Required]
        public string Nome { get; set; }

        [Column("Galaxia")]
        [StringLength(50)]
        [Required]
        public string Galaxia { get; set; }

        [Column("Latitude")]
        [StringLength(250)]
        [Required]
        public string Latitude { get; set; }

        [Column("Longitude")]
        [StringLength(250)]
        [Required]
        public string Longitude { get; set; }
    }
}
