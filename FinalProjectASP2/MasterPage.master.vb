
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim ticket As FormsAuthenticationTicket = AuthCookie.getCookieTicket(Me.Page)
        Dim authLvl As String = "0"

        If AuthCookie.cookieExists(Me.Page) Then
            userLogged.Text = "Current User: <b>" + ticket.Name.ToLower + "</b>"
            authLvl = ticket.UserData
        End If
    End Sub
End Class

