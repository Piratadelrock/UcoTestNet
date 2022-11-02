<%@ Page Title="Practica NET" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="UCO.PracticaNET.AppWeb.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.<asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSourceCiudad" Height="278px" Width="344px" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
        </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSourceCiudad" runat="server" SelectMethod="ConsultarCiudad" TypeName="UCO.PracticaNET.ReglasNegocio.Model.CiudadModel"></asp:ObjectDataSource>
    </p>
</asp:Content>
