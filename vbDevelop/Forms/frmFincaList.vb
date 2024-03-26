Imports System.Data.SqlClient

Public Class frmFincaList
    Public Overrides Sub Init()
        MyBase.Init()
        SQLGridParm = New SqlParameter("@FincaID", 0)

        Dim adp As New SqlDataAdapter

        adp.SelectCommand = dcGral.getSQLCommand(Connect, "spFincaSelect", SQLGridParm)
        Adaptador = adp
        Detalle = True
    End Sub

    Public Overrides Sub Adicionar()
        Dim frm = New frmFincaDet(Connect, Me, -1)
        frm.ShowDialog()
    End Sub
    Public Overrides Sub Modificar()
        If dg.SelectedRows.Count > 0 Then
            Dim frm = New frmFincaDet(Connect, Me, getID("FincaID"))
            frm.ShowDialog()
            reloadRow(RowIndex, "FincaID")
        End If
    End Sub
    Private Sub frmFincaList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
