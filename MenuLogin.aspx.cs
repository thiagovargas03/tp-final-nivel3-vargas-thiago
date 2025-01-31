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
    public partial class MenuLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();    
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                usuario.Email = txtEmail.Text;
                usuario.Pass=txtPass.Text;
                if (negocio.Login(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("Error", "Usuario o contraseña incorrectos");
                    Response.Redirect("Error.aspx");
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}