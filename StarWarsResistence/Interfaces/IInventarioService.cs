using StarWarsResistence.Models;
using System.Collections.Generic;

namespace StarWarsResistence.Interfaces
{
    public interface IInventarioService
    {
        Inventario SaveOrUpdate(Inventario inventario);
        ItemInventario SaveOrUpdate(ItemInventario itens);
    
    }
}
