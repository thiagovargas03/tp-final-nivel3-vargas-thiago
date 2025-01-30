using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using System.Xml.Linq;

namespace TpFinalNivel3
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        public bool confirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            confirmaEliminacion = false;
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

                if (id != "" && !IsPostBack)
                {
                    btnAceptar.Text = "Modificar";
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Articulos seleccionado = (negocio.listar(id))[0];

                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    txtImagenUrl.Text = seleccionado.ImagenUrl;
                    txtDescripcion.Text = seleccionado.Descripcion;

                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
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

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulos nuevo = new Articulos();
            ArticuloNegocio negocio = new ArticuloNegocio();

            nuevo.Codigo = txtCodigo.Text;
            nuevo.Nombre = txtNombre.Text;
            nuevo.Descripcion = txtDescripcion.Text;
            nuevo.Precio = Decimal.Parse(txtPrecio.Text);
            nuevo.ImagenUrl = txtImagenUrl.Text;

            nuevo.Marca = new Marcas();
            nuevo.Marca.Id = int.Parse(ddlMarca.Text);
            nuevo.Categoria = new Categoria();
            nuevo.Categoria.Id = int.Parse(ddlCategoria.Text);


            if (Request.QueryString["id"] != null)
            {
                //Cargo el id del pokemon a modificar para poder enviarlo al procedimiento
                nuevo.Id = int.Parse(txtId.Text);
                negocio.modificarConSp(nuevo);
            }
            else
            {
                negocio.agregarConSp(nuevo);
            }
            Response.Redirect("ListadoArticulos.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            confirmaEliminacion = true;
        }

        protected void btnEliminarConfirmado_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmarEliminacion.Checked)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("ListadoArticulos.aspx");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error",ex);
            }
        }
    }
}