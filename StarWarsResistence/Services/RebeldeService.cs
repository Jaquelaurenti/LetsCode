using Microsoft.EntityFrameworkCore;
using StarWarsResistence.Interfaces;
using StarWarsResistence.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsResistence.Services
{
    public class RebeldeService : IRebeldeService
    {
        private StarWarsContexto _context;

        public RebeldeService(StarWarsContexto contexto)
        {
            _context = contexto;
        }

        public async Task<IList<Rebelde>> FindAllRebeldesAsync()
        {
            return await _context.Rebeldes.AsNoTracking()
                 .Include(c => c.Localizacao)
                 .Include(d => d.Inventario)
                 .Include(c => c.Inventario.Itens).ToListAsync();

        }

        public Rebelde FindByIdRebelde(int RebeldeId)
        {
            return _context.Rebeldes.FirstOrDefault(x => x.Id == RebeldeId);
        }
        public Rebelde FindByNome(string name)
        {
            return _context.Rebeldes.FirstOrDefault(x => x.Nome == name);
        }

        public async Task<Rebelde> SaveOrUpdate(Rebelde Rebelde)
        {
            var existe = _context.Rebeldes
                    .Where(x => x.Id == Rebelde.Id)
                    .FirstOrDefault();

            if (existe == null)
                _context.Rebeldes.Add(Rebelde);
            else
            {
                existe.Nome = Rebelde.Nome;
            }
            await _context.SaveChangesAsync();

            return Rebelde;
        }
    }
}
