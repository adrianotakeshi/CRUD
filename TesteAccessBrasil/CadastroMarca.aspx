<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroMarca.aspx.cs" MasterPageFile="~/Site.Master" Inherits="TesteAccessBrasil.CadastroMarca" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

         <div class="formtop">
            <h3>Cadastro de Marca</h3>
            <br />
            Código:&nbsp;
            <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
            <br />
            Nome:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnNovo" runat="server" Text="Novo" OnClick="btnNovo_Click" />
            <asp:Button ID="btnSalvar" runat="server" OnClick="btnSalvar_Click" Text="Salvar" />
            <br />
            <br />
             <asp:GridView ID="GridView1" runat="server" CssClass="tabcentro" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting"  OnRowDataBound = "OnRowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None" CellSpacing="5">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Codigo" HeaderText="Codigo" HeaderStyle-CssClass="tabespaco" />
                    <asp:BoundField DataField="Nome" HeaderText="Nome" HeaderStyle-CssClass="tabespaco"  />
                    <asp:ButtonField ButtonType="Button" CommandName="Editar" Text="Editar" HeaderStyle-CssClass="tabespaco"  />
                    <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Excluir" HeaderStyle-CssClass="tabespaco" />
                    
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
            <br />
        </div>

</asp:Content>
