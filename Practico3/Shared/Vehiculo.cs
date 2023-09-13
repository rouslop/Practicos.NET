using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Vehiculo
    {
        public long Id { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Matricula
        { get; set; }

        public Persona Propietario { get; set; }

        public void Print()
        {
            Console.WriteLine("Marca: " + Marca);
            Console.WriteLine("Modelo: " + Modelo);
            Console.WriteLine("Matricula: " + Matricula);
        }
    }
}
