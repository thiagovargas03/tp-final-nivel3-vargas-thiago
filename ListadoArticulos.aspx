<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListadoArticulos.aspx.cs" Inherits="TpFinalNivel3.ListadoArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- filtro rapido --%>
    <div class="mb-3">
        <label for="txtFiltro" class="form-label">Filtrar</label>
        <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" OnTextChanged="txtFiltro_TextChanged" AutoPostBack="true" />
    </div>
    <%-- filtro avanzado --%>
    <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end">
        <div class="mb-3">
            <asp:CheckBox Text="Filtro Avanzado" ID="chkAvanzado" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" runat="server" />
        </div>
    </div>

    <% if (chkAvanzado.Checked)
        { %>
    <div class="row">
        <div class="col-3">

            <%-- Campo para filtrar --%>
            <div class="mb-3">
                <asp:Label Text="Campo" runat="server" />
                <asp:DropDownList ID="ddlCampo" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" runat="server">
                    <asp:ListItem Text="Precio" />
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Descripcion" />
                </asp:DropDownList>
            </div>
        </div>
        <%-- Criterio de filtro --%>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Criterio" runat="server" />
                <asp:DropDownList AutoPostBack="true" ID="ddlCriterio" CssClass="form-control" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <%-- Texto para filtrar --%>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Filtro" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
            </div>
        </div>
        <%-- Boton para buscar --%>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Button Text="Buscar" OnClick="btnBuscar_Click" CssClass="btn btn-primary" ID="btnBuscar" runat="server" />
                </div>
            </div>
        </div>












    </div>


    <% } %>

    <asp:GridView ID="dgvArticulos" runat="server" DataKeyNames="Id" CssClass="table" AutoGenerateColumns="false"
        OnPageIndexChanging="dgvArticulos_PageIndexChanging" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" AllowPaging="true" PageSize="6">

        <Columns>
            <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="✍" />
        </Columns>

    </asp:GridView>



</asp:Content>
