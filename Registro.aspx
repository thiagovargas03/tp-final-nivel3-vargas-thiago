<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TpFinalNivel3.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>





<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-4">
            <h2>Crea tu usuario</h2>
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email:</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtPassword" class="form-label">Contraseña:</label>
                <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" />
            </div>
            <asp:Button Text="Registrarse" ID="btnRegistrarse" OnClick="btnRegistrarse_Click" CssClass="btn btn-primary" runat="server" />
            <a href="/">Cancelar</a>
        </div>
    </div>
</asp:Content>
