Imports System.Data.SqlClient

Public Class frmCentroCosto
    Public Overrides Sub Init()
        SQLGridParm = New SqlParameter("@CentroCostoID", 0)

        Dim adp As New SqlDataAdapter
        adp.SelectCommand = dcGral.getSQLCommand(Connect, "spCentroCostoSelect", SQLGridParm)
        adp.InsertCommand = dcGral.getSQLCommand(Connect, "spCentroCostoInsert")
        adp.UpdateCommand = dcGral.getSQLCommand(Connect, "spCentroCostoUpdate")
        adp.DeleteCommand = dcGral.getSQLCommand(Connect, "spCentroCostoDelete")
        '-------------------------------
        adp.InsertCommand.Parameters(1).Direction = ParameterDirection.InputOutput
        '----------------------------
        Adaptador = adp
        MyBase.Init()
    End Sub
    Private Sub frmCentroCosto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
