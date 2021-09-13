using StarWarsResistence.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWarsResistence.Interfaces
{
    public interface IInventarioService
    {
        Task<Inventario> SaveOrUpdate(Inventario inventario);
        Task<ItemInventario> SaveOrUpdateItem(ItemInventario itens);
        bool Delete(Inventario inventario);
        Task<Tuple<Rebelde, Rebelde>>NegociaInventario(int IdNegociante, int IdNegociador, int IdItemNegociante, int IdItemNegociador);

    }
}
