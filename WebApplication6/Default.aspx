<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="WebApplication6._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Bienvenido</h2>
            </hgroup>
            <p>
              Aquí podrás consultar nuevas noticias!!! </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Qué es un canvazazo?</h3>
    <ol class="round">
        <li class="one">
            <h5><asp:Label runat="server" ID="LBNombre" Text ="default"></asp:Label></h5>
            <asp:Label runat="server" ID="LBpicture"></asp:Label>
            Es un periódico digital local, raeremos noticias de tu ciudad al instante, no puedes dejar pasar esta oportunidad! <a href="http://go.microsoft.com/fwlink/?LinkId=245146">Learn more…</a>
        </li>
        <li class="two">
            <asp:Label Text="text" runat="server" id="Inscribete"/>
        </li>
    </ol>
    <asp:HyperLink  ID="LinkButton2" runat="server">contact.aspx</asp:HyperLink>
 <asp:label ID="LabelDatosFace" runat ="server" Visible =" false"></asp:label>
<div id="fb-root"></div>
<a href='#' onclick="FacebookInviteFriends();"> 
Facebook Invite Friends Link
</a>
    <script src="https://connect.facebook.net/es_MX/all.js"></script>

<script>
    FB.init({
        appId: '779337262082870',
        cookie: true,
        status: true,
        xfbml: true
    });

    function FacebookInviteFriends() {
        FB.ui({
            method: 'apprequests',
            message: 'Prueba la nueva App!'
        });
    }
</script>
</asp:Content>
