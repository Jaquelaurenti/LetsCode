using StarWarsResistence.Interfaces;
using StarWarsResistence.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsResistence.Services
{
    public class InventarioService : IInventarioService
    {
        private StarWarsContexto _context;

        public InventarioService(StarWarsContexto contexto)
        {
            _context = contexto;
        }

        public bool Delete(Inventario inventario)
        {
            var existe = _context.Inventario
                    .Where(x => x.Id == inventario.Id)
                    .FirstOrDefault();

            foreach(var remove in existe.Itens)
            {
                _context.ItemInventario.Remove(remove);
            }

            _context.Inventario.Remove(existe);

            _context.SaveChangesAsync();

            return true;
        }

        public async Task<Inventario> SaveOrUpdate(Inventario model)
        {
            var existe = _context.Inventario
                    .Where(x => x.Id == model.Id)
                    .FirstOrDefault();

            if (existe == null)
            {
                _context.Inventario.Add(model);
                foreach (var item in model.Itens)
                {
                    await SaveOrUpdateItem(item);
                }

            }
            else
            {
                existe.Id = model.Id;
            }
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<ItemInventario> SaveOrUpdateItem(ItemInventario itens)
        {
            var existe = _context.ItemInventario
                    .Where(x => x.Id == itens.Id)
                    .FirstOrDefault();

            if (existe == null)
                _context.ItemInventario.Add(itens);
            else
            {
                existe.Id = itens.Id;
            }
            await _context.SaveChangesAsync();

            return itens;

        }
    }
}
