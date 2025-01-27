using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TpFinalNivel3
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
				if (!IsPostBack)
				{
					CategoriasNegocio negocioCat = new CategoriasNegocio();	
					List<Categoria> listaCategorias = negocioCat.listar();

					MarcaNegocio negocioMarca = new MarcaNegocio();
					List<Marcas> listaMarcas = negocioMarca.listar();

					ddlCategoria.DataSource = listaCategorias;
					ddlCategoria.DataValueField = "Id";
					ddlCategoria.DataTextField = "Descripcion";
					ddlCategoria.DataBind();
					
                    ddlMarca.DataSource = listaMarcas;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                }

				string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if (id !="" && !IsPostBack)
                {
					ArticuloNegocio negocio = new ArticuloNegocio();
					Articulos seleccionado = (negocio.listar(id))[0];

					txtCodigo.Text = seleccionado.Codigo;
					txtNombre.Text=seleccionado.Nombre;
					txtPrecio.Text = seleccionado.Precio.ToString();
					txtImagenUrl.Text = seleccionado.ImagenUrl;
					txtDescripcion.Text = seleccionado.Descripcion;

					ddlCategoria.SelectedValue=seleccionado.Categoria.Id.ToString();
					ddlMarca.SelectedValue=seleccionado.Marca.Id.ToString();
					txtImagenUrl_TextChanged(sender, e);
					
                }
            }
			catch (Exception)
			{

				throw;
			}
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }
    }
}