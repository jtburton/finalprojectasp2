<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="css/loginPage.css" />
    <title>Louis' Pharmacy - Login</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="loginForm">
        <table>
            <tr>
                <th colspan="2">Please <b>Login</b> to use Louis' Pharmacy's Website</th>
            </tr>

            <tr>
                <td>Username:</td>
                <td><asp:TextBox ID="unameText" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="unameRequired" runat="server" ErrorMessage="Username required" ForeColor="Red" ControlToValidate="unameText">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Password:</td>
                <td><asp:TextBox ID="pwordText" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="pwordRequired" runat="server" ErrorMessage="Password required" ForeColor="Red" ControlToValidate="pwordText">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td><asp:Button ID="loginButton" runat="server" Text="Login" /></td>
                <td style="font-size: 12px; text-align: left;"><asp:CheckBox ID="rememberUser" runat="server" Text="Remember Username?" /><br /><asp:CheckBox ID="persCookie" runat="server" Text="Keep me logged in?" /></td>
            </tr>
            <tr>
                <td style="font-size: 12px; color: red;"">
                    <asp:Literal ID="loginErrors" runat="server"></asp:Literal><asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" /></td>
            </tr>
        </table>
        <div style="background: aliceblue; border-top: 2px solid lightblue; font-size: 12px; color: darkgray; padding: 10px;">
            By logging onto the Louis' Pharmacy website, you agree to not be a pleb like John Delallo 
            and enjoy Apple products, or to drive a crappy Porsche. Furthermore, you must be able to drive over speedbumps without
            losing your oil pan and be able to eat bread.
            <br /><br />
            &copy; 2018 Zach, Kev, and Tracey
        </div>
    </div>
</asp:Content>

