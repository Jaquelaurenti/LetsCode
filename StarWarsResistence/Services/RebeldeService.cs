using Microsoft.EntityFrameworkCore;
using StarWarsResistence.Interfaces;
using StarWarsResistence.Models;
using System;
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

        public bool RebeldeTraidor(int RebeldeId)
        {
            var rebelde = _context.Rebeldes.FirstOrDefault(x => x.Id == RebeldeId);
            if (rebelde.Traidor) return true;
            else return false;

        }

        public IList<Tuple<TipoItem, int>> RetornaMediaRecurso()
        {
            throw new NotImplementedException();
        }

        public int RetornaPercentualRebeldes()
        {
            var countRebeldes = _context.Rebeldes.ToList().Count();
            var countRebeldesTraidores = _context.Rebeldes.ToList().Where(x => x.Traidor).Count();

            int percentComplete = (int)Math.Round((double)(100 * countRebeldes) / countRebeldesTraidores);

            return percentComplete;

        }

        public int RetornaPercentualTraidores()
        {
            var countRebeldes = _context.Rebeldes.ToList().Count();
            var countRebeldesTraidores = _context.Rebeldes.ToList().Where(x => x.Traidor).Count();

            int percentComplete = (int)Math.Round((double)(100 * countRebeldesTraidores) / countRebeldes);

            return percentComplete;
        }

        public int RetornaPontosPerdidosPorTraicao()
        {
            int pontos = 0;
            var traidores = _context.Rebeldes
                .Include(x => x.Inventario)
                .Include(y => y.Inventario.Itens)
                .Where(x => x.Reports >= 3).ToList();


            foreach (var rebeldes in traidores)
            {
                foreach (var itens in rebeldes.Inventario.Itens)
                {
                    pontos = pontos + itens.Pontuacao;
                }

            }

            return pontos;

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
