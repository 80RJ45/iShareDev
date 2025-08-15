Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class frmCapacitaCabList
    Public Overrides Sub Init()
        MyBase.Init()

        Dim adp = New SqlDataAdapter
        SQLGridParm = New SqlParameter("@CapacitaCabID", 0)

        adp.SelectCommand = dcGral.getSQLCommand(Connect, "spCapacitaCabSelect", SQLGridParm)

        Adaptador = adp
        Detalle = True

    End Sub
    Public Overrides Sub Adicionar()
        Dim frm = New frmCapacitaCabDetail(Connect, Me, -1)
        frm.ShowDialog()
        MyBase.Adicionar()
    End Sub

    Public Overrides Sub Modificar()
        Dim frm = New frmCapacitaCabDetail(Connect, Me, getID("CapacitaCabID"))
        frm.ShowDialog()
        MyBase.Modificar()
    End Sub
    Private Sub frmCapacitaCabList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
