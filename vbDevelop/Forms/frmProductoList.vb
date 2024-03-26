Imports System.Data.SqlClient
Public Class frmProductoList

    Public Overrides Sub Init()
        SQLGridParm = New SqlParameter("@ProductoID", 0)

        Dim adp As New SqlDataAdapter

        adp.SelectCommand = dcGral.getSQLCommand(Connect, "spProductoSelect", SQLGridParm)
        adp.InsertCommand = dcGral.getSQLCommand(Connect, "spProductoInsert")
        adp.UpdateCommand = dcGral.getSQLCommand(Connect, "spProductoUpdate")
        adp.DeleteCommand = dcGral.getSQLCommand(Connect, "spProductoDelete")
        adp.InsertCommand.Parameters(0).Direction = ParameterDirection.InputOutput
        Adaptador = adp
        MyBase.Init()
    End Sub

    Private Sub frmProductoList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
