<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="TpFinalNivel3.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="row">
        <div class="col-6">

            <div class="mb-3">
                <label for="txtId" class="form-label">Id:</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Codigo:</label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre: </label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio: </label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca: </label>
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoria: </label>
                <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>

            <div class="d-flex gap-2 align-items-center">

                <asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary" runat="server" />
                <a href="ListadoArticulos.aspx" class="btn btn-primary">Cancelar</a>

                <%-- Boton de eliminacion --%>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" runat="server" />

                        <% if (confirmaEliminacion)
                            { %>
                        <div class="d-flex gap-2 align-items-center">
                            <asp:CheckBox Text="Confirmar eliminación" ID="chkConfirmarEliminacion" runat="server" />
                            <asp:Button Text="Eliminar" ID="btnEliminarConfirmado" OnClick="btnEliminarConfirmado_Click" CssClass="btn btn-outline-danger" runat="server" />
                        </div>
                        <% } %>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>



        </div>

        <%-- Segunda columna del formulario(Descripcion e Imagen) --%>

        <div class="col-6">

            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion: </label>
                <asp:TextBox runat="server" ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control" />
            </div>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                        <asp:TextBox runat="server" ID="txtImagenUrl" OnTextChanged="txtImagenUrl_TextChanged" CssClass="form-control" AutoPostBack="true" />
                    </div>

                    <asp:Image ImageUrl="https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg"
                        ID="imgArticulo" Width="60%" runat="server" />

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>


    </div>

</asp:Content>
