﻿Imports System.Windows.Forms

Public Class frmActivoDetail
    Public Sub New(cnx As dcLibrary.dcConnect, parents As dcLibrary.dcParentList, DetailID As Integer)
        MyBase.New(cnx, parents, DetailID)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        newDinamicTable(Connect, 0, "ActivoCab", "@ActivoCabID", "@ActivoCabID", DetailID, ParameterDirection.InputOutput, -1)
        newDinamicTable(Connect, 1, "ActivoDet", "@ActivoCabID", "ActivoCabID", DetailID, ParameterDirection.Input, 0)
        newDinamicTable(Connect, 2, "ActivoCompra", "@ActivoCabID", "@ActivoCabID", DetailID, ParameterDirection.Input, 0)

        LoadDinamicTables()
    End Sub
    Public Overrides Sub SetGrids()
        MyBase.SetGrids()
        dcGral.initGrid(dgvDetalle, dsGral.Tables("ActivoDet"), True, True, "ActivoDetID", False, False, Connect, DataGridViewContentAlignment.MiddleCenter, False)
    End Sub
    Public Overrides Sub SetCombos()
        MyBase.SetCombos()
        dcGral.setCombo(cmbTipoActivo, dsGral.Tables("TipoActivoCab"), "Nombre", "TipoActivoCabID", 0)
    End Sub
    Public Overrides Sub LoadTables()
        MyBase.LoadTables()
        NewTable("spTipoActivoSelect 0", "TipoActivoCab")
        NewTable("Select *from dbo.iStatus('ActivoCab','TipoDep')", "ActivoCapTipoDep")
        NewTable("Select *from dbo.iStatus('ActivoDet','Estado')", "ActivoDetEstado")
    End Sub
    Public Overrides Sub DetailRow()
        MyBase.DetailRow()
        If dsGral.Tables("ActivoCab").Rows.Count = 0 Then
            dsGral.Tables("ActivoCab").Rows.Add()
        Else
            txtCodigo.Text = dsGral.Tables("ActivoCab").Rows(0).Item(1)
            cmbTipoDep.SelectedItem = dsGral.Tables("ActivoCab").Rows(0).Item(4)
            'cmbTipoActivo.SelectedItem = dsGral.Tables("TipoActivoCab").Rows(0).Item(2)
            cmbTipoActivo.SelectedValue = dsGral.Tables("TipoActivoCab").Rows(0).Item(0)

            'Articulo
            txtArticulo.Text = dsGral.Tables("ActivoCab").Rows(0).Item("Articulo")
            txtArticulo.Tag = dsGral.Tables("ActivoCab").Rows(0).Item("ArticuloID")
            txtMarca.Text = dsGral.Tables("ActivoCab").Rows(0).Item("marca")
            txtFamilia.Text = dsGral.Tables("ActivoCab").Rows(0).Item("Familia")

            'ActivoCompra
            txtProveedor.Text = dsGral.Tables("ActivoCompra").Rows(0).Item("proveedor")
            dtFechaCompra.Value = dsGral.Tables("ActivoCompra").Rows(0).Item("fecha")
            txtVida.Text = dsGral.Tables("ActivoCompra").Rows(0).Item("vida")
            txtValor.Text = dsGral.Tables("ActivoCompra").Rows(0).Item("precio")

        End If
    End Sub
    Private Sub frmActivoDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Try
            Err.Clean()
            If txtArticulo.Text.Length = 0 Then Err.AddError("Error, debe seleccionar un artículo", 0)
            If cmbTipoDep.SelectedIndex = -1 Then Err.AddError("Error, debe seleccionar el tipo de depreciación", 0)
            If txtCompra.Text.Length = 0 Then Err.AddError("Error, seleccione una compra", 0)
            If txtVida.Text.Length = 0 Then Err.AddError("Falta el tiempo de vida", 0)
            If txtPrecio.Text.Length = 0 Then Err.AddError("Falta el precio de compra", 0)

            If Err.Errors Then
                Err.ShowDialog()
                Exit Sub
            End If

            'Activo
            dsGral.Tables("ActivoCab").Rows(0)("tipodep") = cmbTipoDep.SelectedValue
            dsGral.Tables("ActivoCab").Rows(0)("ArticuloID") = dsGral.Tables("ActivoCab").Rows(0)("ArticuloID")
            dsGral.Tables("ActivoCab").Rows(0)("tipoActivoCabID") = cmbTipoActivo.SelectedValue

            'ActivoCompra
            dsGral.Tables("ActivoCompra").Rows(0)("Documento") = txtCompra.Text
            dsGral.Tables("ActivoCompra").Rows(0)("Proveedor") = txtProveedor.Text
            dsGral.Tables("ActivoCompra").Rows(0)("Precio") = txtPrecio.Text
            dsGral.Tables("ActivoCompra").Rows(0)("Vida") = txtVida.Text
            dsGral.Tables("ActivoCompra").Rows(0)("Residual") = txtValor.Text

            UpdateTables(0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim frm As New 
    End Sub
End Class
