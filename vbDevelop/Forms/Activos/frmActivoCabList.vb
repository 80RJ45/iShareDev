Imports System.Data.SqlClient

Public Class frmActivoCabList

    Public Overrides Sub Init()
        SQLGridParm = New SqlParameter("@ActivoCabID", 0)

        Dim adp As New SqlDataAdapter

        adp.SelectCommand = dcGral.getSQLCommand(Connect, "spActivoCabSelect", SQLGridParm)

        Adaptador = adp
        Detalle = True

        MyBase.Init()
    End Sub
    Public Overrides Sub Adicionar()
        Dim frm = New frmActivoDetail(Connect, Me, -1)
        frm.ShowDialog()
    End Sub
    Public Overrides Sub Modificar()
        Dim frm = New frmActivoDetail(Connect, Me, getID("ActivoCabID"))
        frm.ShowDialog()
        reloadRow(RowIndex, "ActivoCabID")
    End Sub
    Private Sub frmActivoCabList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Del.Visible = False
    End Sub
End Class