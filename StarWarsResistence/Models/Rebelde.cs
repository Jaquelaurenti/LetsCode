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
        [Column("Id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column("Nome")]
        [StringLength(50)]
        [Required]
        public string Nome { get; set; }

        [Column("Idade")]
        [Required]
        public int Idade { get; set; }

        [Column("Genero")]
        [Required]
        public Genero IdGenero { get; set; }

        [Column("Traidor")]
        public bool Traidor { get; set; }

        [Column("Reports")]
        public int Reports { get; set; }

        [Column("IdLocalizacao")]
        public int IdLocalizacao { get; set; }

        [Column("IdLocalizacao")]
        public Localizacao Localizacao { get; set; }

        [Column("IdInventario")]
        public Inventario Inventario { get; set; }

        [Column("IdInventario")]
        public int IdInventario { get; set; }

    }

    public enum Genero
    {
        Feminino = 0,
        Masculino = 1,
        Outro = 2,
    }
}
