using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Negocio
{
    public class ArticuloNegocio
    {

        public List<Articulos> listar(string id = "")

        {
            List<Articulos> lista = new List<Articulos>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Codigo,Nombre,A.Descripcion,M.Descripcion Marca,C.Descripcion Categoria,ImagenUrl,Precio,A.IdMarca,A.IdCategoria,A.Id from ARTICULOS A, MARCAS M,CATEGORIAS C Where M.Id = A.IdMarca AND C.Id = A.IdCategoria";
                if (id != "")
                    comando.CommandText += " and A.Id = " + id;
                comando.Connection = conexion;


                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)lector["Id"];
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)lector["IdMarca"];
                    aux.Marca.Descripcion = (string)lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)lector["Categoria"];
                    aux.ImagenUrl = (string)lector["ImagenUrl"];
                    aux.Precio = (decimal)lector["Precio"];



                    if (!(lector["ImagenUrl"] is DBNull))
                    {
                        aux.ImagenUrl = (string)lector["ImagenUrl"];
                    }



                    lista.Add(aux);
                }

                conexion.Close();
                return lista;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Articulos> listarConSp()
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string sp = "storedListar";
                datos.setearSp(sp);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];



                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    }

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void modificar(Articulos modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo = @codigo , Nombre = @nombre, Descripcion = @desc,ImagenUrl=@img,Precio=@precio,IdMarca=@idMarca,IdCategoria=@idCategoria WHERE Id = @id ");
                datos.setearParametro("@codigo", modificar.Codigo);
                datos.setearParametro("@nombre", modificar.Nombre);
                datos.setearParametro("@desc", modificar.Descripcion);
                datos.setearParametro("@img", modificar.ImagenUrl);
                datos.setearParametro("@precio", modificar.Precio);
                datos.setearParametro("@idMarca", modificar.Marca.Id);
                datos.setearParametro("@idCategoria", modificar.Categoria.Id);
                datos.setearParametro("@id", modificar.Id);


                datos.ejecutarAccion();
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
        public void modificarConSp(Articulos modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSp("storedModificarArticulo");
                datos.setearParametro("@codigo", modificar.Codigo);
                datos.setearParametro("@nombre", modificar.Nombre);
                datos.setearParametro("@desc", modificar.Descripcion);
                datos.setearParametro("@img", modificar.ImagenUrl);
                datos.setearParametro("@precio", modificar.Precio);
                datos.setearParametro("@idMarca", modificar.Marca.Id);
                datos.setearParametro("@idCategoria", modificar.Categoria.Id);
                datos.setearParametro("@id", modificar.Id);


                datos.ejecutarAccion();
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
        public void agregar(Articulos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta
               ("Insert into ARTICULOS (Codigo,Nombre,Descripcion,ImagenUrl,Precio,IdMarca,IdCategoria) " +
               "Values (@codigo,@nombre,@desc,@img,@precio,@idMarca,@idCategoria)");
                datos.setearParametro("@codigo", nuevo.Codigo);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@desc", nuevo.Descripcion);
                datos.setearParametro("@img", nuevo.ImagenUrl);
                datos.setearParametro("@precio", nuevo.Precio);
                datos.setearParametro("@idMarca", nuevo.Marca.Id);
                datos.setearParametro("@idCategoria", nuevo.Categoria.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }



        }
        public void agregarConSp(Articulos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSp("AltaArticulo");
                datos.setearParametro("@codigo", nuevo.Codigo);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@desc", nuevo.Descripcion);
                datos.setearParametro("@img", nuevo.ImagenUrl);
                datos.setearParametro("@precio", nuevo.Precio);
                datos.setearParametro("@idMarca", nuevo.Marca.Id);
                datos.setearParametro("@idCategoria", nuevo.Categoria.Id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM ARTICULOS WHERE id=@id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();


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

        public List<Articulos> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Select Codigo,Nombre,A.Descripcion,M.Descripcion Marca,C.Descripcion Categoria,ImagenUrl,Precio,A.IdMarca,A.IdCategoria,A.Id from ARTICULOS A, MARCAS M,CATEGORIAS C Where M.Id = A.IdMarca AND C.Id = A.IdCategoria AND ";
                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Precio < " + filtro;
                            break;
                        default:
                            consulta += "Precio = " + filtro;
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "A.Descripcion like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "A.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "A.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];



                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    }



                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw;

            }
        }
    }
}
