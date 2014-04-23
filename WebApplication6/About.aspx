<%@ Page Title="About" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.vb" Inherits="WebApplication6.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Acerca de</h2>
    </hgroup>

    <article>
        <p>        
            Aquí irán las nuevas noticias que recibamos de nuestros reporteros
        </p>
    </article>

    <aside>
        <h3>Noticias</h3>
        <p>        
            Se aproximan nuevas carreras atléticas a la ciudad de Xalapa!
        </p>
        <ul>
            <li><a runat="server" href="~/">Home</a></li>
            <li><a runat="server" href="~/About.aspx">About</a></li>
            <li><a runat="server" href="~/Contact.aspx">Contact</a></li>
        </ul>
    </aside>
    <asp:Label ID ="respuesta" runat="server" ></asp:Label>
</asp:Content>