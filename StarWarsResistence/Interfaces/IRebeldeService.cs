using StarWarsResistence.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWarsResistence.Interfaces
{
    public interface IRebeldeService
    {
        Task<IList<Rebelde>> FindAllRebeldesAsync();
        Rebelde FindByIdRebelde(int RebeldeId);
        Rebelde FindByNome(string name);
        Task<Rebelde> SaveOrUpdate(Rebelde Rebelde);
        bool RebeldeTraidor(int RebeldeId);
        
    }
}
