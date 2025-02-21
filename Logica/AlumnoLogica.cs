using Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class AlumnoLogica
    {
        private SqlCommand comando;        
        private SqlConnection conexion;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AlumnoLogica()
        {
            comando = new SqlCommand();
            conexion = new SqlConnection("server=DESKTOP-J6SUQQ6\\SQLEXPRESS;database=ALUMNO_DB;integrated security=true");                        
        }
        public void iniciarConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;            
            comando.CommandText = consulta; 
        }
        public void abrirConexion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        public void guardarAlumno()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void cerrarConexion()
        {
            if (lector != null)
            {
                lector.Close();
            }
            conexion.Close();
        }
        public List<Alumno> mostrarLista()
        {
            List<Alumno> listaAlumno = new List<Alumno>();
            try
            {
                iniciarConsulta("select * from ALUMNO");
                abrirConexion();
                while (lector.Read())
                {
                    Alumno alumno = new Alumno();
                    alumno.Id = (int)lector["Id"];
                    alumno.Nombre = (string)lector["Nombre"];
                    alumno.Dni = (int)lector["Dni"];
                    alumno.Direccion = (string)lector["Direccion"];
                    alumno.Edad = (int)lector["Edad"];                    
                    alumno.Activo = (bool)lector["Activo"];

                    listaAlumno.Add(alumno);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            cerrarConexion();
            return listaAlumno;
        }




        public List<Alumno> listaFiltrada()
        {
            List<Alumno> listaAlumnosFiltrados = new List<Alumno>();

            try
            {
                iniciarConsulta("select * from ALUMNO where Activo = 1");
                abrirConexion();
                while (lector.Read())
                {
                    Alumno alumno = new Alumno();
                    alumno.Id = (int)lector["Id"];
                    alumno.Nombre = (string)lector["Nombre"];
                    alumno.Dni = (int)lector["Dni"];
                    alumno.Direccion = (string)lector["Direccion"];
                    alumno.Edad = (int)lector["Edad"];
                    alumno.Activo = (bool)lector["Activo"];

                    listaAlumnosFiltrados.Add(alumno);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            cerrarConexion();
            return listaAlumnosFiltrados;



        }





        public void cargarAlumno(Alumno alumno)
        {
            try
            {
                iniciarConsulta("insert into ALUMNO(Nombre,Dni,Direccion,Edad) values(' "+alumno.Nombre+" ', "+alumno.Dni+"  ,'"+alumno.Direccion+"', "+alumno.Edad+")");
                guardarAlumno();
            }
            catch (Exception)
            {

                throw;
            }
            cerrarConexion();
        }

        public void eliminarAlumno(Alumno alumno)
        {
            iniciarConsulta("delete from ALUMNO where Id = "+alumno.Id+"");
            abrirConexion();
            cerrarConexion();
        }

    }
}
