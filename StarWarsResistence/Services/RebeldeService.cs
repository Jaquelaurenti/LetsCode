﻿using StarWarsResistence.Models;
using System.Collections.Generic;
using System.Linq;

namespace StarWarsResistence.Services
{
    public class RebeldeService : IRebeldeService
    {
        private CentralErroContexto _context;

        public RebeldeService(CentralErroContexto contexto)
        {
            _context = contexto;
        }

        public IList<Rebelde> FindAllRebeldes()
        {
            return _context.Rebeldes.ToList();
        }

        public Rebelde FindByIdRebelde(int RebeldeId)
        {
            return _context.Rebeldes.Find(RebeldeId);
        }
        public Rebelde FindByNome(string name)
        {
            return _context.Rebeldes.FirstOrDefault(x => x.Nome == name);
        }

        public Rebelde SaveOrUpdate(Rebelde Rebelde)
        {
            var existe = _context.Rebeldes
                    .Where(x => x.IdRebelde == Rebelde.IdRebelde)
                    .FirstOrDefault();

            if (existe == null)
                _context.Rebeldes.Add(Rebelde);
            else
            {
                existe.Nome = Rebelde.Nome;
            }
            _context.SaveChanges();

            return Rebelde;
        }
    }
}
