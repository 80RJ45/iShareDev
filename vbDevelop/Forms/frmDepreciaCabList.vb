Imports System.Data.SqlClient

Public Class frmDepreciaCabList
    Public Overrides Sub Init()
        SQLGridParm = New SqlParameter("@DepreciaCabID", 0)

        Dim adp = New SqlDataAdapter

        adp.SelectCommand = dcGral.getSQLCommand(Connect, "spDepreciaCabSelect", SQLGridParm)
        Adaptador = adp

        Detalle = True

        MyBase.Init()
    End Sub
    Public Overrides Sub Adicionar()
        Dim frm = New frmDepreciaCabDetail(Connect, Me, -1)
        frm.ShowDialog()
    End Sub
    Public Overrides Sub Modificar()
        Dim frm = New frmDepreciaCabDetail(Connect, Me, getID("DepreciaCabID"))
        frm.ShowDialog()
        reloadRow(RowIndex, "DepreciaCabID")
    End Sub
    Private Sub frmDepreciaCabList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Del.Visible = False
    End Sub
End Class
