Imports System.Data.SqlClient
Public Class frmProductoList2
    Public Overrides Sub Init()
        MyBase.Init()
        SQLGridParm = New SqlParameter("@ProductoID", 0)

        Dim adp As New SqlDataAdapter
        adp.SelectCommand = dcGral.getSQLCommand(Connect, "spProductoSelect", SQLGridParm)
        adp.InsertCommand = dcGral.getSQLCommand(Connect, "spProductoInsert")
        adp.InsertCommand.Parameters(0).Direction = ParameterDirection.InputOutput
        adp.UpdateCommand = dcGral.getSQLCommand(Connect, "spProductoUpdate")
        adp.DeleteCommand = dcGral.getSQLCommand(Connect, "spProductoDelete")
        Adaptador = adp

    End Sub
    Private Sub frmProductoList2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
