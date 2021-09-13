using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarWarsResistence.Models
{
    [Table("ItemInventario")]
    public class ItemInventario
    {
        [Column("Id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column("Tipo")]
        [Required]
        public TipoItem Tipo { get; set; }

        [Column("Pontuacao")]
        [Required]
        public int Pontuacao { get; set; }

        [Column("IdInventario")]
        [Required]
        public Inventario Inventario { get; set; }

        [Column("IdInventario")]
        [Required]
        public int IdInventario { get; set; }

    }

    public enum TipoItem
    {
        Arma = 0,
        Municao = 1,
        Agua = 2,
        Comimda = 3,

    }

   
}
