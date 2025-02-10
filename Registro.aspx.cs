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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario user = new Usuario();   
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                EmailService emailService = new EmailService();
                user.Email=txtEmail.Text;
                user.Pass=txtPassword.Text;
                user.Id = usuarioNegocio.insertarNuevo(user);
                Session.Add("usuario", user);

                emailService.armarCorreo(user.Email, "Bienvenido usuario", "Esperamos que disfrutes de la tienda");
                emailService.enviarMail();
                Response.Redirect("Home.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}