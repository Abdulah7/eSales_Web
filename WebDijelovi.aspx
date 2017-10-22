<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebDijelovi.aspx.cs" Inherits="eProdaja_Web.WebDijelovi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <asp:DataGrid ID="gridDijelovi" runat="server" AutoGenerateColumns="False" style="position:absolute; top: 358px; left: 335px; width: 406px;" AllowPaging="True" AllowCustomPaging="True" PageSize="3" OnPageIndexChanged="gridDijelovi_PageIndexChanged" OnItemCommand="gridDijelovi_ItemCommand" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <ItemStyle ForeColor="#000066" />
        <PagerStyle Mode="NumericPages" BackColor="White" ForeColor="#000066" HorizontalAlign="Left"  />
        <Columns>
            <asp:BoundColumn DataField="Naziv" HeaderText="Naziv"></asp:BoundColumn>
            <asp:BoundColumn DataField="Model" HeaderText="Model"></asp:BoundColumn>
            <asp:BoundColumn DataField="Zalihe" HeaderText="Zalihe"></asp:BoundColumn>
            <asp:BoundColumn DataField="Cijena" HeaderText="Cijena"></asp:BoundColumn>
            <asp:TemplateColumn>
                <ItemTemplate>
                    <asp:TextBox ID="hh" runat="server" Width="30px"  Text="1" TextMode="Number"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton2" runat="server" Width="100px" CommandName="dio"  CommandArgument='<%# Eval("DijeloviID") %>'>Add to Chart</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateColumn>
        </Columns>
        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
    </asp:DataGrid>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <h3 style="position:absolute; top: 156px; left: 455px; height: 19px; width: 171px;">Katalog dijelova</h3>
  
        
          <h5 style="position:absolute; top: 245px; left: 335px; font-size: medium;">Naziv:</h5>
        
      
                <asp:TextBox style="position:absolute; top: 299px; left: 334px; height: 26px;" ID="TextBox1" runat="server" Width="390px" OnTextChanged="TextBox1_TextChanged" BorderColor="Green" BorderStyle="Solid" BorderWidth="3px" Font-Size="Medium"></asp:TextBox>
           
              
           

                  
                <asp:Button style="position:absolute; top: 300px; left: 755px; height: 31px;" ID="Button2" runat="server" Text="Traži" OnClick="Button2_Click1" BorderColor="Green" BorderStyle="Solid" BorderWidth="3px" Font-Size="Medium"   />
         
                  
         
              
       </asp:Content>
