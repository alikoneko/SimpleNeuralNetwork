using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNeuralNetwork
{
    class Dendrite
    {
        public double Weight { get; set; }

        public Dendrite()
        {
            this.Weight = ServiceRegistry.GetInstance().GetRandom().NextDouble();
        }
    }
}
