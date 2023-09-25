namespace Shared
{
    public class Persona
    {
        public string Nombre { get; set; } = "-- Sin Nombre --";

        private string documento = "";
        public string Documento
        {
            get
            {
                return documento;
            }
            set
            {
                if (value.Length >= 7)
                {
                    documento = value;
                }
                else
                {
                    throw new Exception("El formato del documento no es correcto.");
                }
            }
        }

        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public ICollection<Vehiculo> Vehiculos { get; set; } 

        public void Print()
        {
            Console.WriteLine("-- Persona --");
            Console.WriteLine("Documento: " + Documento);
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Apellido: " + Apellido);
            Console.WriteLine("Telefono: " + Telefono);
            Console.WriteLine("Direccion: " + Direccion);
            Console.WriteLine("Fecha de Nacimiento: " +  FechaNacimiento.ToShortDateString());
            
        }

        public void PrintTable()
        {
            Console.WriteLine("| " + Documento + " | " + Nombre + " | " + Apellido + " | " + Telefono + " |");
        }

        public void PrintVehiculos()
        {
            Console.WriteLine("Vehiculos de " + Nombre + ": ");
            Vehiculos.ToList().ForEach(x => x.Print());
        }

    }
}