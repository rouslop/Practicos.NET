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
    public class DAL_Personas_ADONet : IDAL_Personas
    {
        private string _connectionString = "Server=localhost,1433;Database=practico2;User Id=sa;Password=Abc*123!;Encrypt=False;";
        public void Delete(string documento)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                Persona persona = new Persona();

                using (SqlCommand cmd = new SqlCommand("DELETE * FROM personas WHERE Documento = @documento", connection))
                {
                    cmd.Parameters.AddWithValue("@documento", documento);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Persona> Get()
        {
            //Instancio la lista a devolver
            List<Persona> res = new List<Persona>();

            //using -> para definir un contexto relacionado a un recurso y asegurarnos de que se cierre luego de usarse
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                
                using(SqlCommand cmd = new SqlCommand("SELECT * FROM personas", connection))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Persona persona = new Persona();

                            persona.Documento = reader["Documento"].ToString();
                            persona.Nombre = reader["Nombre"].ToString();

                            res.Add(persona);
                        }
                    }

                }
            }


            return res;

        }

        public Persona Get(string documento)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                Persona persona = new Persona();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM personas WHERE Documento = @documento", connection))
                {
                    cmd.Parameters.AddWithValue("@documento", documento);

                    using( SqlDataReader reader = cmd.ExecuteReader())
                    {
                        persona.Documento = reader["Documento"].ToString();
                        persona.Nombre = reader["Nombre"].ToString();

                        return persona;
                    }
                }
            }
        }

        public void Insert(Persona persona)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO personas (Documento, Nombre) VALUES (@documento, @nombre)", connection))
                {
                    cmd.Parameters.AddWithValue("@documento", persona.Documento);
                    cmd.Parameters.AddWithValue("@nombre", persona.Nombre);

                    cmd.ExecuteNonQuery();
                }
                
            }
        }

        public void Update(Persona persona)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("UPDATE personas SET Nombre = @nombre WHERE Documento = @documento", connection))
                {
                    cmd.Parameters.AddWithValue("@documento", persona.Documento);
                    cmd.Parameters.AddWithValue("@nombre", persona.Nombre);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
