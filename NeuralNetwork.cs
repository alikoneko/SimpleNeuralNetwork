using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNeuralNetwork
{
    class NeuralNetwork
    {
        public List<Layer> Layers { get; set; }
        public double LearningRate { get; set; }
        public int LayerCount
        {
            get
            {
                return Layers.Count;
            }
        }

        public NeuralNetwork(double learningRate, int[] layers)
        {
            if (layers.Length < 2) return; //must have more than 2 layers.

            this.LearningRate = learningRate;
            this.Layers = new List<Layer>();

            for(int i = 0; i < layers.Length; i++)
            {
                Layer layer = new Layer(layers[i]);
                this.Layers.Add(layer);

                for(int j = 0; j < layers[i]; j++)
                {
                    layer.Neurons.Add(new Neuron());
                }

                layer.Neurons.ForEach((nn) =>
                {
                    if (i == 0)
                    {
                        nn.Bias = 0;
                    }
                    else
                    {
                        for(int dendrite = 0; dendrite < layers[i - 1]; dendrite++)
                        {
                            nn.Dendrites.Add(new Dendrite());
                        }
                    }
                });
            }
        }

        private double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        public double[] Run(List<double> input)
        {
            if (input.Count != this.Layers[0].NeuronCount) return null;

            for(int i = 0; i < Layers.Count; i++)
            {
                Layer layer = Layers[i];

                for(int n = 0; n < layer.Neurons.Count; n++)
                {
                    Neuron neuron = layer.Neurons[n];

                    if(i == 0)
                    {
                        neuron.Value = input[n];
                    }
                    else
                    {
                        neuron.Value = 0;
                        for(int np = 0; np < this.Layers[i - 1].Neurons.Count; np++)
                        {
                            neuron.Value = neuron.Value + this.Layers[i - 1].Neurons[np].Value * neuron.Dendrites[np].Weight;
                        }

                        neuron.Value = Sigmoid(neuron.Value + neuron.Bias);
                    }
                }
            }

            Layer last = this.Layers[this.Layers.Count - 1];
            int numOutput = last.Neurons.Count;
            double[] output = new double[numOutput];

            for (int i = 0; i < last.Neurons.Count; i++)
            {
                output[i] = last.Neurons[i].Value;
            }   

            return output;
        }
    }
}
