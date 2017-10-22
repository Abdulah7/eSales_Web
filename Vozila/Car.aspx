<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Car.aspx.cs" Inherits="eProdaja_Web.Vozila.Car" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  
    <asp:Panel ID="ocjenePanel" runat="server">
        <div class="proizvodRow">
            <div class="proizvodRow">
                <asp:Label ID="lblOcjeni" runat="server" Font-Bold="True" Text="Ocjeni automobil:"></asp:Label>
                <br />
                <br />
            </div>
            <asp:DropDownList ID="ddlOcjene" runat="server" AutoPostBack="True">
                <asp:ListItem Text="<Ocijeni>" Value="0"></asp:ListItem>
                <asp:ListItem Text="Odličan" Value="5"></asp:ListItem>
                <asp:ListItem Text="Vrlo dobar" Value="4"></asp:ListItem>
                <asp:ListItem Text="Dobar" Value="3"></asp:ListItem>
                <asp:ListItem Text="Ispod prosjeka" Value="2"></asp:ListItem>
                <asp:ListItem Text="Loš" Value="1"></asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label12" runat="server"></asp:Label>
            <asp:Label ID="Label13" runat="server"></asp:Label>
        </div>
        <br />
        <asp:Button ID="btnOcjeni" runat="server" Text="Ocijeni" OnClick="btnOcjeni_Click" />

        <br />
        <hr />
        <br />

    </asp:Panel>
    
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;

    <asp:DataGrid ID="Grid" runat="server" DataSource="<%# preporuceniProizvodi.Take(3) %>"   AutoGenerateColumns="False"  DataKeyField="VoziloID"  OnItemDataBound="Grid_ItemDataBound" HorizontalAlign="Center" CellPadding="4" ForeColor="#333333" GridLines="None" OnItemCommand="Grid_ItemCommand" >


         <AlternatingItemStyle BackColor="White" />


         <Columns> 
           <asp:TemplateColumn HeaderText="Preporučujemo">

                <ItemTemplate>
                    <asp:Image ID="imageID" runat="server" DescriptionUrl='<%#"/Vozila/Car.aspx?VoziloID="+Eval("VoziloID") %>' />
                </ItemTemplate>
           
                </asp:TemplateColumn>
            
           
              <asp:BoundColumn  DataField="Naziv" HeaderText="Naziv"></asp:BoundColumn>

         
             <asp:TemplateColumn>

                 <ItemTemplate>
                     <asp:LinkButton ID="LinkButton1" runat="server"   CommandName="h" CommandArgument='<%# Eval("VoziloID") %>'>Detalji</asp:LinkButton>
                 </ItemTemplate>
             </asp:TemplateColumn>

       


             
             
              <asp:TemplateColumn  HeaderText="Prosječna ocjena">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server"  Text=""></asp:Label>

                </ItemTemplate>
            </asp:TemplateColumn>


                
        </Columns>

         <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
         <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
         <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
         <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />

    </asp:DataGrid>


        



  <div style="position: absolute; top: 357px; left: 18px;">
    <asp:Label ID="Label16" runat="server" Font-Bold="True">Boja:</asp:Label>
    <asp:Label ID="Label17" runat="server"></asp:Label>
    <br />
    <asp:Label ID="Label18" runat="server" Font-Bold="True">Emisija:</asp:Label>
    <asp:Label ID="Label19" runat="server"></asp:Label>
    <br />
    <asp:Label ID="Label20" runat="server" Font-Bold="True">Naziv:</asp:Label>
    <asp:Label ID="Label22" runat="server"></asp:Label>
    <br />
    <asp:Label ID="Label23" runat="server" Font-Bold="True">Vrsta motora:</asp:Label>
    <asp:Label ID="Label24" runat="server"></asp:Label>
    <br />
    <asp:Label ID="Label25" runat="server" Font-Bold="True">Cijena:</asp:Label>
    <asp:Label ID="Label26" runat="server"></asp:Label>
    <br />
    <asp:Label ID="Label27" runat="server" Font-Bold="True">Godina proizvodnje:</asp:Label>
    <asp:Label ID="Label28" runat="server"></asp:Label>
    </div>

</asp:Content>
