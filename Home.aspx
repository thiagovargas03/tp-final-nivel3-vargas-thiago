<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TpFinalNivel3.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Hola!</h1>
    <p>Bienvenido a la tienda</p>

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <%-- CARDS DE PRODUCTOS --%>
        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("ImagenUrl")%>" class="card-img-top img-fluid align-self-center" style="max-width:45%;max-height:45%" alt="..." />
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%></h5>
                            <p class="card-text"><%#Eval("Descripcion")%></p>
                             <asp:Button Text="Detalle" CssClass="btn btn-primary" 
                                 runat="server" ID="btnDetalle" CommandArgument='<%#Eval("Id")%>' 
                                 CommandName="ArticuloId" OnClick="btnDetalle_Click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <%-- CARDS DE PRODUCTOS --%>
    </div>
</asp:Content>
