<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="patient.aspx.vb" Inherits="patient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="css/patientChoice.css" />
    <script src="js/blockToggle.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="selector" onload="sessionStorage.setItem('TABLE_SLIDE', 'false');">
        <tr>
            <td onclick="toggleForm(this);">
                <div id="searchPatientByName">
                    <div id="formContent" onclick="event.stopPropagation();">
                        <span style="font-family: Arial; font-weight: lighter;">Search Patient By Last Name</span><br /><br />
                        <asp:TextBox ID="searchNameText" runat="server" placeholder="Patient Last Name..." ValidationGroup="One"></asp:TextBox>
                        <asp:CustomValidator ID="custVal" runat="server" ControlToValidate="searchNameText" ForeColor="Red" ValidationGroup="One"></asp:CustomValidator>
                        <asp:Button ID="searchPatientByNameButton" runat="server" Text="Search" OnClientClick="setSlide();" ValidationGroup="One"/>
                        <asp:ValidationSummary ID="valSum" runat="server" ValidationGroup="One"/>
                    </div>

                    <div id="formDescription">
                        Return a list of a single, or all patients matching the last name supplied. The last name does not have to be
                        complete.
                    </div>
                </div>
            </td>
            <td></td>
            <td>Search By ID</td>
            <td></td>
            <td>View Directory</td>
        </tr>
    </table>

    <div id="gridContainer">
        <asp:GridView ID="patientGridView" runat="server">
            <Columns>
                <asp:BoundField HeaderText="Patient ID" />
                <asp:BoundField HeaderText="First Name" />
                <asp:BoundField HeaderText="Last Name" />
                <asp:BoundField HeaderText="Address" />
            </Columns>
        </asp:GridView>
    </div>

    <script type="text/javascript">
        slideTable();
    </script>
</asp:Content>

