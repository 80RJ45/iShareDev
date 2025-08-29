Imports System.Data.SqlClient
Public Class frmTipoEvaluaDetList
    Public Overrides Sub Init()
        MyBase.Init()

        Dim adp = New SqlDataAdapter
        Dim SQLGridParm = New SqlParameter("@TipoEvaluaDetID", 0)

        adp.SelectCommand = dcGral.getSQLCommand(Connect, "spTipoEvaluaDetSelect", SQLGridParm)

        Adaptador = adp

        Detalle = True
    End Sub
    Public Overrides Sub Adicionar()
        Dim frm = New frmTipoEvaluaDetDetail(Connect, Me, -1)
        frm.ShowDialog()

        Reload()
    End Sub
    Public Overrides Sub Modificar()
        MyBase.Modificar()
        Dim frm = New frmTipoEvaluaDetDetail(Connect, Me, getID("TipoEvaluaDetID"))
        frm.ShowDialog()
    End Sub
    Private Sub frmTipoEvaluaDetList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
