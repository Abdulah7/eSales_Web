<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="eProdaja_Web.Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
          <h3 style="position:absolute; top: 169px; left: 443px;">Katalog vozila</h3> 

  
  
            <h5 style="position:absolute; top: 219px; left: 245px; font-size: medium;"  class="auto-style1">Model:</h5>
            <h5 style="position:absolute; top: 216px; left: 365px; width: 48px; font-size: medium;" class="auto-style1">Naziv: </h5>

   
      
           
                <asp:DropDownList  BorderColor="Green" BorderStyle="Solid" BorderWidth="3px" ID="vrstaModela" runat="server" DataTextField="Naziv" DataValueField="ModelID"  style="margin-bottom: 10px; position:absolute; top: 270px; height: 33px; left: 245px;"  Width="94px" Font-Size="Medium"></asp:DropDownList>
           
                <asp:TextBox style="position:absolute; top: 269px; left: 363px;" ID="nazivInput" runat="server" Height="28px" Width="310px" BorderColor="Green" BorderStyle="Solid" BorderWidth="3px" Font-Size="Medium"></asp:TextBox>
             
                <asp:Button style="position:absolute; top: 268px; left: 697px; height: 37px; width: 54px;" ID="traziButton" runat="server" Text="Traži" OnClick="traziButton_Click" BorderColor="Green" BorderStyle="Solid" BorderWidth="3px" Font-Size="Medium" />
          

   
    <br />
     <br />
    <asp:DataGrid ID="vozilaGrid" runat="server" AutoGenerateColumns="False" style="position:absolute; top: 355px; left: 244px; width: 699px;"
        AllowPaging="True" AllowCustomPaging="True" PageSize="3" OnItemDataBound="vozilaGrid_ItemDataBound" OnPageIndexChanged="vozilaGrid_PageIndexChanged" 
        DataKeyField="VoziloID" OnItemCommand="vozilaGrid_ItemCommand" BackColor="#DEBA84" BorderColor="#DEBA84" BorderWidth="1px" CellPadding="3" BorderStyle="None" CellSpacing="2">
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" Mode="NumericPages"  />
        <Columns>
          <asp:TemplateColumn>

                <ItemTemplate>
                    <asp:Image ID="ImageID" runat="server" />
                </ItemTemplate>

            </asp:TemplateColumn>
            <asp:BoundColumn DataField="Naziv" HeaderText="Naziv" />
            <asp:BoundColumn DataField="Boja" HeaderText="Boja" />
            <asp:BoundColumn DataField="Godiste" HeaderText="Godina proizvodnje" />

            <asp:TemplateColumn>
                <ItemTemplate>
                    <asp:HyperLink ID="DetaljiProizvoda" runat="server"  NavigateUrl='<%#"/Vozila/Car.aspx?VoziloID="+Eval("VoziloID") %>'>DETALJI</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateColumn>
      <asp:TemplateColumn>
          <ItemTemplate>

              <asp:TextBox ID="kk" runat="server" Width="30px" Text="1" TextMode="Number"></asp:TextBox>
              <asp:LinkButton ID="LinkButton1" runat="server" Width="100px"  CommandName="AddToCart"  CommandArgument='<%# Eval("VoziloID") %>'>Add to Chart</asp:LinkButton>
          </ItemTemplate>
      </asp:TemplateColumn>
          
        </Columns>
        <SelectedItemStyle BackColor="#738A9C" ForeColor="White" Font-Bold="True" />
        </asp:DataGrid>
          <br />
          <br />




</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            height: 19px;
        }
    </style>
    </asp:Content>

