using StarWarsResistence.Models;
using System.Collections.Generic;

namespace StarWarsResistence.Interfaces
{
    public interface ILocalizacaoService
    {
        Localizacao FindByIdRebelde(int rebeldeId);
        Localizacao FindByNome(string nome);
        Localizacao SaveOrUpdate(Localizacao localizacao);
    }
}
