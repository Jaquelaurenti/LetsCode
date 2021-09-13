using StarWarsResistence.Interfaces;
using StarWarsResistence.Models;
using System.Collections.Generic;
using System.Linq;

namespace StarWarsResistence.Services
{
    public class InventarioService : IInventarioService
    {
        private StarWarsContexto _context;

        public InventarioService(StarWarsContexto contexto)
        {
            _context = contexto;
        }

        public Inventario SaveOrUpdate(Inventario model)
        {
            var existe = _context.Inventario
                    .Where(x => x.Id == model.Id)
                    .FirstOrDefault();

            if (existe == null)
                _context.Inventario.Add(model);
            else
            {
                existe.Id = model.Id;
            }
            _context.SaveChanges();

            return model;
        }

        public ItemInventario SaveOrUpdate(ItemInventario itens)
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
            _context.SaveChanges();

            return itens;
        }
    }
}
