using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using StarWarsResistence.Models;

namespace StarWarsResistence.Test.Comparers
{
    public class RebeldeIdComparer : IEqualityComparer<Rebelde>
    {
        public bool Equals(Rebelde x, Rebelde y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Rebelde obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
