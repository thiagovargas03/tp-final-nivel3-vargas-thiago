<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MenuLogin.aspx.cs" Inherits="TpFinalNivel3.MenuLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-6">

            <div class="mb-3">
                <label for="txtId" class="form-label">Email:</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Contraseña:</label>
                <asp:TextBox runat="server" ID="txtPass" CssClass="form-control" />
            </div>
            <asp:Button text="Ingresar" ID="btnIngresar" OnClick="btnIngresar_Click" CssClass="btn btn-primary" runat="server" />
        </div>
    </div>
</asp:Content>
