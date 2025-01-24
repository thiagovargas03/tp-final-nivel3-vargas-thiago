using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{

    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        //Para poder leer el lector desde el exterior
        public SqlDataReader Lector
        {
            get { return lector; }
        }
        public void setearSp(string sp) 
        {
            comando.CommandType= System.Data.CommandType.StoredProcedure;
            comando.CommandText= sp;
        }

        //Genero un constructor de la clase para iniciar la conexion
        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true");
            comando = new SqlCommand();
        }
        //Genero una funcion para poder hacer consultas
        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        //Genero una funcion para ejecutar la lectura de la consulta.
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        //Genero una funcion para ejecutar una alteracion a la base de datos.
        public void ejecutarAccion()
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
        //Funcion para crear parametros para usar en el insert
        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }



        //Funcion para cerrar conexion
        public void cerrarConexion()
        {
            if (lector != null)
            {
                lector.Close();
            }
            conexion.Close();
        }
    }
}
