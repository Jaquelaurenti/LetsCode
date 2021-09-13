using StarWarsResistence.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWarsResistence.Interfaces
{
    public interface ILocalizacaoService
    {
        Localizacao FindByIdRebelde(int rebeldeId);
        Localizacao FindByNome(string nome);
        Task<Localizacao> SaveOrUpdate(Localizacao localizacao);
        bool Delete(Localizacao localizacao);
    }
}
