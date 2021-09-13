using StarWarsResistence.Interfaces;
using StarWarsResistence.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsResistence.Services
{
    public class LocalizacaoService : ILocalizacaoService
    {
        private StarWarsContexto _context;

        public LocalizacaoService(StarWarsContexto contexto)
        {
            _context = contexto;
        }

        public bool Delete(Localizacao localizacao)
        {
            var existe = _context.Localizacao
                    .Where(x => x.Id == localizacao.Id)
                    .FirstOrDefault();


            _context.Remove(localizacao);
            var x = _context.SaveChanges();
            return true;
        }

        public Localizacao FindByIdRebelde(int rebeldeId)
        {
            return _context.Localizacao.Find(rebeldeId);
        }
        public Localizacao FindByNome(string name)
        {
            return _context.Localizacao.FirstOrDefault(x => x.Nome == name);
        }

        public async Task<Localizacao> SaveOrUpdate(Localizacao model)
        {
            var existe = _context.Localizacao
                    .Where(x => x.Id == model.Id)
                    .FirstOrDefault();

            if (existe == null)
                _context.Localizacao.Add(model);
            else
            {
                existe.Nome = model.Nome;
            }
            await _context.SaveChangesAsync();

            return model;
        }
    }
}
