using System;
using System.Collections.Generic;

namespace StarWarsResistence.DTO
{
    public class InventarioDTO
    {
        public List<ItensInventarioDTO> Itens { get; set; }
    }

    public class ItensInventarioDTO
    {
        public int Tipo { get; set; }

        public int Pontos { get; set; }

    }
}
