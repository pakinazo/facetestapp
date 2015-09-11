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
            <p>
                <a href="OtroAlto.aspx">otro alto</a>
                <a href="Testingancho.aspx">testing ancho</a>
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Qué es un canvazazo?</h3>
    <ol class="round">
        <li class="one">
            <h5><asp:Label runat="server" ID="LBNombre" Text ="default"></asp:Label></h5>
            <asp:Label runat="server" ID="LBpicture"></asp:Label>
            Es un periódico digital local, raeremos noticias de tu ciudad al instante, no puedes dejar pasar esta oportunidad! <a href="www.mundodexalapa.com">Visita otros periódicos</a>
        </li>
        <li class="one">
            <b>últimas carreras:</b> <br />
            Maratón Caja Zongolica <br />

            Será una gran reto para los atletas que deseen participar en este evento, porque se le considera una ruta extrema, debido, a que es una zona montañosa con altitudes que oscilan entre los 1,200 y 1,800 metros sobre el nivel del...
            <br />
            <img src="http://maratoncajazongolica.org.mx/wp-content/uploads/2014/03/Destacada-Marato%CC%81n.jpg" />

            <asp:Label ID="LBDatosPrincipalesFacebook" runat="server"></asp:Label>
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

      <div id="allContent" style="background-color: #0000FF; height:100%">
        <div id="output" style="color: #FFFFFF;" />
     </div>


    <table>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>

        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>
        <tr>
            <td>
                Algo
            </td>
        </tr>

    </table>
    <script src="https://connect.facebook.net/es_MX/all.js"></script>


<script>
    
    window.fbAsyncInit = function () {

    FB.init({
        appId: '779337262082870',
        cookie: true,
        status: true,
        xfbml: true
    });
    };
    //function echoSize() {
    //    document.getElementById('output').innerHTML =
    //       "HTML Content Width: " + window.innerWidth +
    //       " Height: " + window.innerHeight;
    //    console.log(window.innerWidth + ' x ' + window.innerHeight);
    //}

    //echoSize();
    //window.onresize = echoSize;

    //function FacebookInviteFriends() {
    //    FB.ui({
    //        method: 'apprequests',
    //        message: 'Prueba la nueva App!'
    //    });
    //}
</script>
</asp:Content>