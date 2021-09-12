using StarWarsResistence.Models;
using System.Collections.Generic;

namespace StarWarsResistence.Services
{
    public interface IRebeldeService
    {
        IList<Rebelde> FindAllRebeldes();
        Rebelde FindByIdRebelde(int RebeldeId);
        Rebelde FindByNome(string name);
        Rebelde SaveOrUpdate(Rebelde Rebelde);
    }
}
