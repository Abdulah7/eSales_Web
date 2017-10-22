<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="eProdaja_Web.Order.Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">





    <br />
    <asp:GridView ID="narudzbaGrid" runat="server" AutoGenerateColumns="false" style="position:absolute; top: 186px; left: 3px; height: 77px; width: 354px;" CellPadding="4" GridLines="None" PageSize="1" ForeColor="#333333" HorizontalAlign="Left">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField  DataField="Vozilo" HeaderText="Auto" />
            <asp:BoundField  DataField="Dijelovi" HeaderText="Dijelovi" />
            <asp:BoundField DataField="Kolicina" HeaderText="Količina" />
        </Columns>
        <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>

    <br />
    
    <br />
    
    <br />
    
    <br />
    
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ponisit" />
    
    <br />
    <br />
    
    <br />

    <asp:Label ID="Label1" runat="server" Text="Iznos računa:" Font-Bold="true"></asp:Label>
    
    <asp:Label ID="Label2" runat="server"></asp:Label>
    
    <br />
    <asp:Label ID="Label3" runat="server" Text="Popust:"></asp:Label>
    <asp:Label ID="Label4" runat="server"></asp:Label>
    
    <br />
    
    <asp:Button ID="narudzbaiD" runat="server" Text="Zaključi" OnClick="narudzbaiD_Click" Height="25px" />
    
    <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand" HorizontalAlign="Center">

        <AlternatingRowStyle BackColor="White" />

        <Columns >

            <asp:BoundField DataField="BrojNarudzbe" HeaderText="Broj Narudzbe" />
              <asp:BoundField DataField="Datum" HeaderText="Datum" />
            
            <asp:TemplateField >

                <ItemTemplate >

       

              <asp:LinkButton ID="link" runat="server"   CommandName="otkazi" CommandArgument='<%# Eval("NarudzbaID") %>' >Otkaži</asp:LinkButton>

                </ItemTemplate>
              </asp:TemplateField >
             
           
           
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
    
    <br />
    
    <br />
    
    <br />
    
    </asp:Content>
