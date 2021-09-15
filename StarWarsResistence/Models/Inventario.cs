using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarWarsResistence.Models
{
    [Table("Inventario")]
    public class Inventario : BaseModel
    {
        public List<ItemInventario> Itens { get; set; }
        
    }

}
