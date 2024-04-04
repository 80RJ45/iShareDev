Imports System.Windows.Forms

Public Class frmActivoDetail
    Public Sub New(cnx As dcLibrary.dcConnect, parents As dcLibrary.dcParentList, DetailID As Integer)
        MyBase.New(cnx, parents, DetailID)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        newDinamicTable(Connect, 0, "ActivoCab", "@ActivoCabID", "@ActivoCabID", DetailID, ParameterDirection.InputOutput, -1)
        newDinamicTable(Connect, 1, "ActivoDet", "ActivoCabID", "ActivoCabID", DetailID, ParameterDirection.Input, 0)
        LoadDinamicTables()
    End Sub
    Public Overrides Sub SetGrids()
        MyBase.SetGrids()
        dcGral.initGrid(dgvDetalle, dsGral.Tables("ActivoDet"), False, False, "", True, True, Connect, DataGridViewContentAlignment.MiddleCenter, True)
    End Sub
    Private Sub frmActivoDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click

    End Sub
End Class
