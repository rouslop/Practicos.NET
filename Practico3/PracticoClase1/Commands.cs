using BusinessLayer.BLs;
using BusinessLayer.IBLs;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticoClase1
{
    public class Commands
    {
        IBL_Personas _personasBL;

        public Commands(IBL_Personas personasBL)
        {
            _personasBL = personasBL;
        }

        public void AddPersona()
        {
            // Pedimos los datos de la pesona.
            Persona persona = new Persona();
            Console.WriteLine("Ingrese el nombre de la persona: ");
            persona.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido de la persona: ");
            persona.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese el documento de la persona: ");
            persona.Documento = Console.ReadLine();
            Console.WriteLine("Ingrese el telefono de la persona: ");
            persona.Telefono = Console.ReadLine();
            Console.WriteLine("Ingrese la direccion de la persona: ");
            persona.Direccion = Console.ReadLine();
            Console.WriteLine("Día de nacimiento:");
            int dia = int.Parse(Console.ReadLine());
            Console.WriteLine("Mes de nacimiento: ");
            int mes = int.Parse(Console.ReadLine());
            Console.WriteLine("Anio de nacimiento: ");
            int year = int.Parse(Console.ReadLine());
            DateTime fecha = new DateTime(year, mes, dia);
            persona.FechaNacimiento = fecha;

            Console.WriteLine("Tiene vehiculo/s? (S/N)");
            string op = Console.ReadLine().ToLower();
            if (op == "n")
            {
                persona.Vehiculos = null;
            }
            else
            {
                persona.Vehiculos = new List<Vehiculo>();
                string agregar = "s";
                do
                {
                    Vehiculo v = new Vehiculo();
                    Console.WriteLine("Ingrese la marca del vehiculo: ");
                    v.Marca = Console.ReadLine();
                    Console.WriteLine("Ingrese el modelo del vehiculo: ");
                    v.Modelo = Console.ReadLine();
                    Console.WriteLine("Ingrese la matricula del vehiculo: ");
                    v.Matricula = Console.ReadLine();
                    persona.Vehiculos.Add(v);

                    Console.WriteLine("Desea agregar otro vehiculo? (S/N)");
                    agregar = Console.ReadLine().ToLower();
                }
                while (agregar!="n");
            }


            _personasBL.Insert(persona);

            _personasBL.Get(persona.Documento).Print();
        }

        public void ListPersonas()
        {
            List<Persona> personas = _personasBL.Get();

            Console.WriteLine("Listado de personas:");
            Console.WriteLine("| Documento | Nombre | Apellido | Telefono");

            foreach (Persona persona in personas)
            {
                persona.PrintTable();
            }
        }

        public void MostrarPersona()
        {
            Console.WriteLine("Ingrese el documento de la persona: ");
            string documento = Console.ReadLine();

            _personasBL.Get(documento).Print();
        }

        public void RemovePersona()
        {
            Console.WriteLine("Ingrese el documento de la persona a eliminar: ");
            string documento = Console.ReadLine();

            _personasBL.Delete(documento);

            Console.WriteLine("Persona eliminada correctamente.");
        }

        public void UpdatePersona()
        {
            Console.WriteLine("Ingrese el documento de la persona a modificar: ");
            Persona persona = new Persona();
            persona.Documento = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre de la persona: ");
            persona.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido de la persona: ");
            persona.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese el telefono de la persona: ");
            persona.Telefono = Console.ReadLine();
            Console.WriteLine("Ingrese la direccion de la persona: ");
            persona.Direccion = Console.ReadLine();
            Console.WriteLine("Día de nacimiento:");
            int dia = int.Parse(Console.ReadLine());
            Console.WriteLine("Mes de nacimiento: ");
            int mes = int.Parse(Console.ReadLine());
            Console.WriteLine("Anio de nacimiento: ");
            int year = int.Parse(Console.ReadLine());
            DateTime fecha = new DateTime(year, mes, dia);
            persona.FechaNacimiento = fecha;

            _personasBL.Update(persona);

            Console.WriteLine("Modificada con éxito");
        }
    }
}
