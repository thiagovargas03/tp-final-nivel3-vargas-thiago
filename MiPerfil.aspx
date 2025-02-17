<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TpFinalNivel3.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .validacion {
            font-size: 16px;
            color: red;
        }
    </style>

  <script>
        //Creamos una funcion para validar que el campo no se encuentre vacio
        function validar() {
            const txtApellido = document.getElementById("txtApellido");
            if (txtApellido.value == "") {
                txtApellido.classList.add("is-invalid");
                return false;
            }
            txtApellido.classList.remove("is-invalid")
            return true;
        }

    </script>
    <h2>Mi Perfil</h2>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
            </div>
            <div class="mb-3">
                <label class="form label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
                <%-- Validator --%>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El nombre es obligatorio" ControlToValidate="txtNombre" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form label">Apellido</label>
                <asp:TextBox runat="server" ClientIDMode="Static" CssClass="form-control" ID="txtApellido" />
            </div>
            
        </div>

        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen Perfil</label>
                <input type="file" id="txtImagen" runat="server" class="form-control" />
            </div>
            <asp:Image ID="imgNuevoPerfil" ImageUrl="https://dynamoprojects.com/wp-content/uploads/2022/12/no-image.jpg" CssClass="img-fluid mb-3" runat="server" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Button Text="Guardar" OnClientClick="return validar();"  CssClass="btn btn-primary" ID="btnGuardar" OnClick="btnGuardar_Click" runat="server" />
            <a href="/">Regresar</a>
        </div>
    </div>

</asp:Content>
