using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiune_Service.model
{
    public class Car
    {
        public string Marca { get; set; }
        public string Model { get; set; }
        public string NrInmatriculare {  get; set; }
        public string Problem {  get; set; }
        public double Price {  get; set; }
        public bool Finished {  get; set; }

        public Car()
        {
            Marca = string.Empty;
            Model = string.Empty;
            NrInmatriculare= string.Empty;
            Problem=string.Empty;
            Price=0;
            Finished = false;
        }
        public Car(string name, string model, string nrinmatriculare, string problem, double price, bool finished)
        {
            Marca = name;
            Model = model;
            NrInmatriculare = nrinmatriculare;
            Problem = problem;
            Price = price;
            Finished = finished;
        }
    }
}
