Imports System.Configuration.ConfigurationManager
Imports System.Data.SqlClient
Imports System.Data
Public Class DatabaseIO

    Private connString As New SqlConnection(ConnectionStrings("connString").ConnectionString) 'grab connString from web.config
    Private cmdString As New SqlCommand 'new blank command string

    'when a new instance of this class is created, it runs the initCommand method
    Public Sub New()
        initCommand() 'runs the initCommand method
    End Sub

    'gets all patient properties by name of patient
    Public Function allPatientByName(name As String) As DataTable
        openConnection() 'calls the openConnection method

        Dim dataSet As New DataSet 'initializes blank dataset
        Dim dataAdapter As New SqlDataAdapter 'initialized blank dataadapter

        cmdString.Parameters.Clear() 'clears existing cmdString parameters
        cmdString.CommandText = "GETPATIENTBYLASTNAME" 'set the stored procedure to use
        cmdString.Parameters.Add("LNAME", SqlDbType.VarChar, 25).Value = name 'adds the last name parameter and value

        dataAdapter.SelectCommand = cmdString 'assigns the command string to the dataadapter
        dataAdapter.Fill(dataSet) 'fills the dataset using the dataadapter

        closeConnection() 'closes the connection

        Return dataSet.Tables(0) 'returns the 0th table, instead of always returning the dataset and using the 0th table like a fucking moron
    End Function

    Public Function allPatientByID(id As String) As DataTable
        openConnection()

        Dim dataSet As New DataSet
        Dim dataAdapter As New SqlDataAdapter

        cmdString.Parameters.Clear()
        cmdString.CommandText = "SEARCHBYPATIENTID"
        cmdString.Parameters.Add("PATID", SqlDbType.VarChar, 5).Value = id

        dataAdapter.SelectCommand = cmdString
        dataAdapter.Fill(dataSet)

        closeConnection()

        Return dataSet.Tables(0)
    End Function

    Public Function userByName(name As String) As DataTable
        openConnection()

        Dim dataSet As New DataSet
        Dim dataAdapter As New SqlDataAdapter

        cmdString.Parameters.Clear()
        cmdString.CommandText = "SEARCHUSERBYNAME"
        cmdString.Parameters.Add("UNAME", SqlDbType.VarChar, 10).Value = name

        dataAdapter.SelectCommand = cmdString
        dataAdapter.Fill(dataSet)

        closeConnection()

        Return dataSet.Tables(0)
    End Function


    'opens the connection to the database
    Private Sub openConnection()
        Try
            connString.Open() 'obviously
        Catch ex As Exception
            closeConnection() 'closes connection if errored out
            Throw New Exception(ex.Message) 'throws any error encountered
        End Try
    End Sub

    'closes connection
    Private Sub closeConnection()
        connString.Close() 'duh
    End Sub

    'initializes the command string so we don't have to do this 16 fucking times like a bunch of retarded apes
    Private Sub initCommand()
        cmdString.Connection = connString 'sets the connection of the command string to the connection string
        cmdString.CommandType = CommandType.StoredProcedure 'sets the command type to stored procedure
        cmdString.CommandTimeout = 1500 'sets the timeout to a second and a half
    End Sub
End Class
