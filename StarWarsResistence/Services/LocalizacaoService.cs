using StarWarsResistence.Interfaces;
using StarWarsResistence.Models;
using System.Collections.Generic;
using System.Linq;

namespace StarWarsResistence.Services
{
    public class LocalizacaoService : ILocalizacaoService
    {
        private StarWarsContexto _context;

        public LocalizacaoService(StarWarsContexto contexto)
        {
            _context = contexto;
        }


        public Localizacao FindByIdRebelde(int RebeldeId)
        {
            return _context.Localizacao.Find(RebeldeId);
        }
        public Localizacao FindByNome(string name)
        {
            return _context.Localizacao.FirstOrDefault(x => x.Nome == name);
        }

        public Localizacao SaveOrUpdate(Localizacao model)
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
            _context.SaveChanges();

            return model;
        }
    }
}
