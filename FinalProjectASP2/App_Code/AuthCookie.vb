Imports Microsoft.VisualBasic

Public Class AuthCookie

    Public Shared Function getCookieTicket(reqPage As Page) As FormsAuthenticationTicket
        Dim authCookie As HttpCookie = reqPage.Request.Cookies(FormsAuthentication.FormsCookieName)

        If Not (IsNothing(authCookie)) Then
            Return FormsAuthentication.Decrypt(authCookie.Value)
        End If

        Return Nothing
    End Function

    Public Shared Function cookieExists(reqPage As Page) As Boolean
        Return Not IsNothing(getCookieTicket(reqPage))
    End Function

End Class
