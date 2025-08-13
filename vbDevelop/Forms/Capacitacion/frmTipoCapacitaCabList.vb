Imports System.Data.SqlClient
Public Class frmTipoCapacitaCabList
    Private Sub frmTipoCapacitaCabList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Overrides Sub Init()

        Dim adp = New SqlDataAdapter
        SQLGridParm = New SqlParameter("@TipoCapacitaCabID", 0)
        adp.SelectCommand = dcGral.getSQLCommand(Connect, "spTipoCapacitaCabSelect", SQLGridParm)

        Adaptador = adp
        Detalle = True
        MyBase.Init()
    End Sub

    Public Overrides Sub Adicionar()
        Dim frm = New frmTipoCapacitaDetail(Connect, Me, -1)
        frm.ShowDialog()
        MyBase.Adicionar()
    End Sub
    Public Overrides Sub Modificar()
        Dim frm = New frmTipoCapacitaDetail(Connect, Me, getID("TipoCapacitaCabID"))
        frm.ShowDialog()
        MyBase.Modificar()
    End Sub

End Class
