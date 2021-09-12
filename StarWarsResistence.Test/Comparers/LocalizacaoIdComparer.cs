using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using StarWarsResistence.Models;

namespace StarWarsResistence.Test.Comparers
{
    public class LocalizacaoIdComparer : IEqualityComparer<Localizacao>
    {
        public bool Equals(Localizacao x, Localizacao y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Localizacao obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
