using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalDataSystem.DataStructures
{
    public class WeightedConnection
    {
        public string LocationA { get; }
        public string LocationB { get; }
        public int Weight { get; }

        public WeightedConnection(
            string locationA,
            string locationB,
            int weight)
        {
            LocationA = locationA;
            LocationB = locationB;
            Weight = weight;
        }
    }
}
