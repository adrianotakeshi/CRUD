<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroCarros.aspx.cs" MasterPageFile="~/Site.Master"  Inherits="TesteAccessBrasil.WebForm1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

       <div class="formtop">
            <h3>Cadastro de Carros</h3>
            <br />
            Código:&nbsp;&nbsp;
            <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
            <br />
            Marca:&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlMarca" runat="server" DataValueField="Nome" Width="180px">
            </asp:DropDownList>
            <br />
            Modelo:&nbsp; <asp:TextBox ID="txtModelo" runat="server"></asp:TextBox>
            <br />
            Ano:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtAno" runat="server"></asp:TextBox>
            <br />
            Cor:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCor" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnNovo" runat="server" OnClick="btnNovo_Click" Text="Novo" />
            <asp:Button ID="btnSalvar" runat="server" OnClick="btnSalvar_Click" Text="Salvar" />
            <br />
            <br />
        </div>
        <asp:GridView ID="gridCarros" runat="server" CssClass="tabcentro" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting= "gridCarros_RowDeleting" OnRowDataBound="OnRowDataBound" OnRowCommand="gridCarros_RowCommand" AutoGenerateColumns="False" CellSpacing="5">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Codigo" HeaderText="Codigo" HeaderStyle-CssClass="tabespaco" />
                <asp:BoundField DataField="CodigoMarca" HeaderText="Codigo da Marca" HeaderStyle-CssClass="tabespaco"  />
                <asp:BoundField DataField="Nome" HeaderText="Marca" HeaderStyle-CssClass="tabespaco"  />
                <asp:BoundField DataField="Modelo" HeaderText="Modelo" HeaderStyle-CssClass="tabespaco"  />
                <asp:BoundField DataField="Ano" HeaderText="Ano" HeaderStyle-CssClass="tabespaco"  />
                <asp:BoundField DataField="Cor" HeaderText="Cor" HeaderStyle-CssClass="tabespaco"  />
                <asp:ButtonField ButtonType="Button" CommandName="Editar" Text="Editar" HeaderStyle-CssClass="tabespaco"  />
                <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Excluir" HeaderStyle-CssClass="tabespaco"  />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>

</asp:Content>
