Imports System.Data.SqlClient

Public Class frmActivoDepList

    Public Overrides Sub Init()
        SQLGridParm = New SqlParameter("@ActivoDepID", 0)

        Dim adp As New SqlDataAdapter

        adp.SelectCommand = dcGral.getSQLCommand(Connect, "spActivoDepSelect", SQLGridParm)

        Adaptador = adp
        Detalle = True

        MyBase.Init()
    End Sub
    Private Sub frmActivoDepList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
