<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pocetna.aspx.cs" Inherits="eProdaja_Web.Pocetna" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server" >


    <div style="text-align:center" >	
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate >

     <asp:Image ID="Image2" runat="server" Height="500px" style="margin-top: 0px;position:absolute; top: 185px; left: 189px; width: 1003px;"   />

     <asp:Timer ID="Timer2" runat="server" Interval="2000" OnTick="Timer1_Tick"></asp:Timer>

            <br />

            <h2 style="position:absolute; top: 714px; left: 187px;">O nama:</h2>

        </ContentTemplate>
 

    </asp:UpdatePanel>

        	<p style="height: 209px; text-align:left; width: 563px; position:absolute; top: 758px; left: 186px;" >Nalazimo se u Ružićima, točnije na Marića strani,uz magistralnu prometnicu Grude - Ljubuški. <br />
                Osnovna djelatnost našeg poduzeća, koje uspješno posluje od 1994 godine, je prodaja rabljenih vozila. Osim toga, bavimo se i
                 posredništvom u prodaji vozila , kao i transportom vozila iz inozemstva. 
                Potvrđujući našu visoku kvalitetu usluge, nastojimo zadovoljiti želje svakog ozbiljnog kupca.
                Ukoliko u našoj trenutnoj ponudi vozila ne nalazite vozilo koje odgovara Vašim željama i potrebama, nudimo Vam mogućnost narudžbe.
                Posjetite nas svakim radnim danom od 8 do 18, te subotom od 8 do 16 sati...</p>

    <div  style="text-align:right; position:absolute; top: 746px; left: 821px; width: 369px; height: 178px;">
		        
    <h2 style="position:absolute; top: -30px; left: 280px;">Kontakt:</h2>
                                                                                                                                              
                                                                                                                                                      
<h5 style="position:absolute; top: 25px; left: 322px;">Telefon:</h5>
<a style="position:absolute; top: 59px; left: 254px; width: 115px;">+387 39 674 042 </a>


 
    <h5 style="position:absolute; top: 89px; left: 327px;">Adresa:</h5>

<a style="position:absolute; top: 126px; left: 165px; height: 19px; width: 203px;">Ružići bb. 88340 Grude, BiH </a>
     
 
    

        </div>


                </div>

    
</asp:Content>
