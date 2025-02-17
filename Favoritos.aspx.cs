using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinalNivel3
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Articulos> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.sesionActiva(Session["usuario"]))
            {
                Session.Add("error", "Porfavor ingrese con un usuario para poder ver sus articulos favoritos");
                Response.Redirect("Error.aspx");
            }

            int idUsuario = ((Usuario)Session["usuario"]).Id;
            FavoritosNegocio negocio = new FavoritosNegocio();
            ListaArticulos = negocio.listarFavoritosConSp(idUsuario);
            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListaArticulos;
                repRepetidor.DataBind();
            }
        }
    }
}