using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNeuralNetwork
{
    class ServiceRegistry
    {
        private static ServiceRegistry instance;
        private Random random;

        public static ServiceRegistry GetInstance()
        {
            if (null == instance)
            {
                instance = new ServiceRegistry();
            }

            return instance;
        }

        public ServiceRegistry()
        {
            random = new Random();
        }

        public Random GetRandom()
        {
            return random;
        }
    }
}
