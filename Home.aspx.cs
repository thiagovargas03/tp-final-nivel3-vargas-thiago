using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TpFinalNivel3
{
    public partial class Home : System.Web.UI.Page
    {
        public List<Articulos> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulos = negocio.listarConSp();

            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListaArticulos;
                repRepetidor.DataBind();
            }
        }

        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string val = ((Button)sender).CommandArgument;
            int idProducto = int.Parse(val);
            FavoritosNegocio negocio = new FavoritosNegocio();  
            if (!(Seguridad.sesionActiva(Session["usuario"])))
            {
                Response.Redirect("Login.aspx");
            }
            else {
                int idUsuario = ((Usuario)Session["usuario"]).Id;
                negocio.agregarFavorito(idUsuario, idProducto);
                btn.CssClass = "btn btn-success rounded-circle p-0";
            }
           
            
        }
    }
}