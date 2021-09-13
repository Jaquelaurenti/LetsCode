using StarWarsResistence.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWarsResistence.Interfaces
{
    public interface IInventarioService
    {
        Task<Inventario> SaveOrUpdate(Inventario inventario);
        Task<ItemInventario> SaveOrUpdateItem(ItemInventario itens);
        bool Delete(Inventario inventario);
    
    }
}
