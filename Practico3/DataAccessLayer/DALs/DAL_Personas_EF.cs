using DataAccessLayer.EFModels;
using DataAccessLayer.IDALs;
using Microsoft.Data.SqlClient;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DALs
{
    public class DAL_Personas_EF : IDAL_Personas
    {
        private DBContextCore _dbContext;

        public DAL_Personas_EF(DBContextCore dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(string documento)
        {
            try
            {
                Personas persona = _dbContext.Personas.FirstOrDefault(p => p.Documento == documento);
                List<Vehiculos> vehiculos = _dbContext.Vehiculos.Where(v => v.Propietario == persona).ToList();
                persona.Vehiculos = vehiculos;
                if (persona != null)
                {
                    if (persona.Vehiculos.Any()) { 
                        foreach (Vehiculos v in persona.Vehiculos)
                        {
                            _dbContext.Vehiculos.Remove(v);
                        } 
                    }
                    _dbContext.Personas.Remove(persona);
                }
                else
                {
                    throw new Exception("No se encontró la persona");
                }

                _dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("No se pudo eliminar la persona");
            }
        }

        public List<Persona> Get()
        {
            return _dbContext.Personas
                             .Select(p => new Persona { 
                                 Documento = p.Documento, Nombre = p.Nombres, Telefono = p.Telefono, Direccion = p.Direccion, FechaNacimiento = p.FechaNacimiento, Apellido = p.Apellidos 
                             })
                             .ToList();
        }

        public Persona Get(string documento)
        {
            Personas p = _dbContext.Personas.FirstOrDefault(p => p.Documento == documento);
            Persona persona = new Persona { Documento = p.Documento, Nombre = p.Nombres, Telefono = p.Telefono, Direccion = p.Direccion, FechaNacimiento = p.FechaNacimiento, Apellido = p.Apellidos };
            return persona;
        }

        public void Insert(Persona persona)
        {
            Personas p = new Personas();
            p.Apellidos = persona.Apellido;
            p.Direccion = persona.Direccion;
            p.Telefono = persona.Telefono;
            p.Documento = persona.Documento;
            p.FechaNacimiento = persona.FechaNacimiento;
            p.Nombres = persona.Nombre;
            if (persona.Vehiculos.Any())
            {
                p.Vehiculos = new List<Vehiculos>();
                foreach (Vehiculo v in persona.Vehiculos)
                {
                    Vehiculos vh = new Vehiculos();
                    vh.Matricula = v.Matricula;
                    vh.Modelo = v.Modelo;
                    vh.Marca = v.Marca;
                    p.Vehiculos.Add(vh);
                }
            }

            _dbContext.Personas.Add(p);
            _dbContext.SaveChanges();
        }

        public void Update(Persona persona)
        {
            Personas p = _dbContext.Personas.FirstOrDefault(p => p.Documento == persona.Documento);
            if (p != null)
            {
                p.Apellidos = persona.Apellido;
                p.Direccion = persona.Direccion;
                p.FechaNacimiento = persona.FechaNacimiento;
                p.Nombres = persona.Nombre;
                p.Telefono = persona.Telefono;
                _dbContext.Personas.Update(p);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("No existe dicha persona");
            }
            
        }
    }
}
