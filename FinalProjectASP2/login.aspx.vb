Imports System.Data
Partial Class login
    Inherits System.Web.UI.Page

    Dim dbIO As New DatabaseIO

    Protected Sub loginButton_Click(sender As Object, e As EventArgs) Handles loginButton.Click
        Dim data As DataTable = dbIO.userByName(unameText.Text.Trim)

        If (data.Rows.Count > 0) Then
            Dim uname As String = data.Rows(0).Item(0)
            Dim pword As String = data.Rows(0).Item(1)
            Dim authLvl As Integer = Integer.Parse(data.Rows(0).Item(2))

            If (pword = pwordText.Text.Trim) Then
                Dim ticket As New FormsAuthenticationTicket(1, uname, DateTime.Now, DateTime.Now.AddDays(1), persCookie.Checked, authLvl.ToString, FormsAuthentication.FormsCookiePath)
                Dim hash As String = FormsAuthentication.Encrypt(ticket)
                Dim cookie As New HttpCookie(FormsAuthentication.FormsCookieName, hash)

                Response.Cookies.Add(cookie)

                Response.Redirect(Request.QueryString("ReturnURL"))
            Else
                pwordText.Text = String.Empty
                loginErrors.Text = "Incorrect Password"
            End If

        Else
            unameText.Text = String.Empty
            pwordText.Text = String.Empty
            loginErrors.Text = "Unrecognized Username"
            Return
        End If

        loginErrors.Text = String.Empty
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If (AuthCookie.cookieExists(Me)) Then
            Response.Redirect("home.aspx")
        End If
    End Sub
End Class
