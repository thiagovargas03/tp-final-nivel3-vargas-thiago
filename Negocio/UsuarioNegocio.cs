using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool Login(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select id,email,pass,nombre,apellido,urlImagenPerfil,admin from USERS Where email = @email And pass = @pass");
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@pass", usuario.Pass);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["id"];
                    usuario.admin = (bool)datos.Lector["admin"];

                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        usuario.UrlImagen = (string)datos.Lector["urlImagenPerfil"];

                    if (!(datos.Lector["nombre"] is DBNull))
                        usuario.Nombre = (string)datos.Lector["nombre"];

                    if (!(datos.Lector["apellido"] is DBNull))
                        usuario.Apellido = (string)datos.Lector["nombre"];

                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();

            }
        }
    }
}
