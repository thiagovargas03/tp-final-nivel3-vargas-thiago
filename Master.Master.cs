using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Microsoft.Win32;
using Negocio;

namespace TpFinalNivel3
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is MenuLogin || Page is Registro || Page is Home || Page is Error))
            {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                {
                    Response.Redirect("MenuLogin.aspx", false);
                }
                else
                {
                    Usuario user = (Usuario)Session["usuario"];
                    if (!string.IsNullOrEmpty(user.UrlImagen))
                    {
                        imgPerfil.ImageUrl = "~/Images/" + user.UrlImagen;
                    }
                }
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }

}

