<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="eProdaja_Web.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>
                    

                    <p class="validation-summary-errors">
                        <asp:Literal runat="server" ID="ErrorMessage" />
                    </p>

                    <fieldset>
                        <legend>Registration Form</legend>
                        <ol>
                            <li>
                                <asp:Label runat="server" ID="ime" AssociatedControlID="UserName">Ime</asp:Label>
                            </li>
                            <li>
                                <asp:TextBox runat="server" ID="UserName" Font-Size="Large" Height="26px"  />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                    CssClass="field-validation-error" ErrorMessage="Ime je obavezno." />
                            </li>
                            <li>
                                <asp:Label runat="server" ID="prezime" AssociatedControlID="prezimeId">Prezime</asp:Label>
                            </li>
                            <li>
                                <asp:TextBox runat="server" ID="prezimeId" Font-Size="Large" Height="27px"  />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="prezimeId"
                                    CssClass="field-validation-error" ErrorMessage="Prezime je obavezno." />
                            </li>
                            <li>
                                 <asp:Label ID="Label1" runat="server" AssociatedControlID="DatumID" >Datum registracije</asp:Label>
                            </li>
                            <li>
                                <asp:TextBox runat="server" ID="DatumID" TextMode="DateTime" Font-Size="Large" Height="26px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DatumID"
                                    CssClass="field-validation-error" ErrorMessage="Datum je obavezan." />
                                 </li>
                            <li>
                                  <asp:Label ID="Label2" runat="server" AssociatedControlID="EmailID" >Email</asp:Label>
                                 </li>
                            <li>
                                <asp:TextBox runat="server" ID="EmailID" Font-Size="Large" Height="28px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="EmailID"
                                    CssClass="field-validation-error" ErrorMessage="Email je obavezan." />
                                 </li>
                            <li>
                                 
                                <asp:Label runat="server" ID="pass" AssociatedControlID="Password">Password</asp:Label>
                                 </li>
                            <li>
                                 
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" Font-Size="Large" Height="27px" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                    CssClass="field-validation-error" ErrorMessage="The password field is required." />
             
                                 </li>
                            <li>
                                 
                                <asp:Label runat="server" ID="passss" AssociatedControlID="ConfirmPassword">Confirm password</asp:Label>
             
                                 </li>
                            <li>
                                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" Font-Size="Large" Height="29px" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                     CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                     CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                            </li>
                        </ol>
                        <asp:Button   ID="Sacuvajbuton"     runat ="server" Text="Registruj se" OnClick="Sacuvajbuton_Click" />
                    </fieldset>
                
</asp:Content>