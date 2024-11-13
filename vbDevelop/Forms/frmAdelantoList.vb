Imports System.Data.SqlClient
Public Class frmAdelantoList

    Public Overrides Sub Init()

        SQLGridParm = New SqlParameter("@AdelantoCabID", 0)

        Dim adp As New SqlDataAdapter

        adp.SelectCommand = dcGral.getSQLCommand(Connect, "spAdelantoCabSelect", SQLGridParm)
        Adaptador = adp

        Detalle = True
        MyBase.Init()
    End Sub
    Private Sub frmAdelantoList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
