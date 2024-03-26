Imports System.Data.SqlClient

Public Class frmTipoActivoCabList
    Public Overrides Sub Init()
        MyBase.Init()
        SQLGridParm = New SqlParameter("@TipoActivoCabID", 0)

        Dim adp As New SqlDataAdapter
        adp.SelectCommand = dcGral.getSQLCommand(Connect, "spTipoActivoCabSelect", SQLGridParm)
        Adaptador = adp
        Detalle = True

    End Sub
    Public Overrides Sub Adicionar()
        Dim frm = New frmTipoActivoDet(Connect, Me, -1)
        frm.ShowDialog()
    End Sub
    Public Overrides Sub Modificar()
        Dim frm = New frmTipoActivoDet(Connect, Me, getID("TipoActivoCabID"))
        frm.ShowDialog()
        reloadRow(RowIndex, "TipoActivoCabID")
    End Sub
    Private Sub frmTipoActivoCabList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Del.Visible = False
    End Sub
End Class
