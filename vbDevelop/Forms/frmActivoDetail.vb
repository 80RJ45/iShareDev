Imports System.Windows.Forms

Public Class frmActivoDetail
    Public id As Int16
    Public Sub New(cnx As dcLibrary.dcConnect, parents As dcLibrary.dcParentList, DetailID As Integer)
        MyBase.New(cnx, parents, DetailID)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        newDinamicTable(Connect, 0, "ActivoCab", "@ActivoCabID", "@ActivoCabID", DetailID, ParameterDirection.InputOutput, -1)
        newDinamicTable(Connect, 1, "ActivoDet", "@ActivoCabID", "@ActivoCabID", DetailID, ParameterDirection.Input, 0)
        newDinamicTable(Connect, 2, "ActivoCompra", "@ActivoCabID", "@ActivoCabID", DetailID, ParameterDirection.Input, 0)
        newDinamicTable(Connect, 3, "ActivoDep", "@ActivoCabID", "@ActivoCabID", DetailID, ParameterDirection.Input, 0)
        id = DetailID
        LoadDinamicTables()

    End Sub
    Public Overrides Sub SetGrids()
        MyBase.SetGrids()
        dcGral.initGrid(dgvDepreciacion, dsGral.Tables(3), False, False, "ActivoDepID,Activo,codDepreciacion", True, True, Connect, DataGridViewContentAlignment.MiddleCenter, True)
        dcGral.FormatColumn(dgvDepreciacion, "Valor", "Valor", 150, DataGridViewContentAlignment.MiddleRight, "0.00", True)
        dcGral.FormatColumn(dgvDepreciacion, "Fecha", "Fecha", 150, DataGridViewContentAlignment.MiddleCenter, "")
        dcGral.initGrid(dgvDetalle, dsGral.Tables("ActivoDet"), True, True, "ActivoCabID,ActivoDetID,CentroCostoID,Estado", True, True, Connect, DataGridViewContentAlignment.MiddleCenter, False)
        dcGral.addComboGrid(dgvDetalle, Connect, "Select *from CentroCosto", "Centro Costo", 3, "CentroCostoID", "Nombre", "CentroCostoID", 120)
        dcGral.addComboGrid(dgvDetalle, Connect, "Select *from dbo.iStatus('ActivoDet','Estado')", "Estado", 5, "Estado", "Nombre", "Codigo", 100)
        dcGral.FormatColumn(dgvDetalle, "Fecha", "Fecha", 90, "L", "", False)
        'dcGral.insertDateColumn(dgvDetalle, 4, "Fecha", "Fecha", 150, "Y")

    End Sub
    Public Overrides Sub SetCombos()
        MyBase.SetCombos()
        dcGral.setCombo(cmbTipoActivo, dsGral.Tables("TipoActivoCab"), "Nombre", "TipoActivoCabID", -1)
        dcGral.setCombo(cmbTipoDep, dsGral.Tables("ActivoCapTipoDep"), "Nombre", "Codigo", -1)
    End Sub
    Public Overrides Sub LoadTables()
        MyBase.LoadTables()
        NewTable("spTipoActivoCabSelect 0", "TipoActivoCab")
        NewTable("Select *from dbo.iStatus('ActivoCab','TipoDep')", "ActivoCapTipoDep")
        NewTable("Select *from dbo.iStatus('ActivoDet','Estado')", "ActivoDetEstado")

    End Sub
    Public Overrides Sub DetailRow()
        MyBase.DetailRow()
        If dsGral.Tables("ActivoCab").Rows.Count = 0 Then
            dsGral.Tables("ActivoCab").Rows.Add()
            dsGral.Tables("ActivoDet").Rows.Add()
            dsGral.Tables("ActivoCompra").Rows.Add()
            txtValor.ReadOnly = False
            txtDepAcomulada.ReadOnly = False
        Else
            txtCodigo.Text = dsGral.Tables("ActivoCab").Rows(0).Item(1)
            cmbTipoActivo.SelectedValue = dsGral.Tables("ActivoCab").Rows(0).Item("TipoActivoCabID")
            cmbTipoDep.SelectedValue = dsGral.Tables("ActivoCab").Rows(0).Item("TipoDep")

            'Articulo
            txtArticulo.Text = dsGral.Tables("ActivoCab").Rows(0).Item("Articulo")
            txtArticulo.Tag = dsGral.Tables("ActivoCab").Rows(0).Item("ArticuloID")
            txtMarca.Text = dsGral.Tables("ActivoCab").Rows(0).Item("marca").ToString()
            txtFamilia.Text = dsGral.Tables("ActivoCab").Rows(0).Item("Familia").ToString()

            'ActivoCompra
            txtProveedor.Text = dsGral.Tables("ActivoCompra").Rows(0).Item("proveedor")
            dtFechaCompra.Value = dsGral.Tables("ActivoCompra").Rows(0).Item("fecha")
            txtVida.Text = dsGral.Tables("ActivoCompra").Rows(0).Item("vida")
            txtPrecio.Text = dsGral.Tables("ActivoCompra").Rows(0).Item("precio")


            'txtDepAcomulada.Text = Int32.Parse(txtPrecio.Text) - Int32.Parse(txtValor.Text)
            Dim tabDepAcomulada = New DataTable()
            tabDepAcomulada = dcGral.getDataTable(String.Concat("exec spGetDepAcomulada ", id), Connect)

            If tabDepAcomulada.Rows.Count = 0 Then
                txtDepAcomulada.Text = 0
            Else
                txtDepAcomulada.Text = Math.Round(Double.Parse(tabDepAcomulada(0)(0).ToString()), 3)

            End If

            txtValor.Text = Double.Parse(txtPrecio.Text) - Double.Parse(txtDepAcomulada.Text)

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
            If cmbTipoActivo.SelectedIndex = -1 Then Err.AddError("Error, Falta seleccionar un tipo de activo", 0)
            If CheckBox1.Checked = True And txtCompra.Text.Length = 0 Then Err.AddError("Error, seleccione una compra", 0)
            If txtVida.Text.Length = 0 Then Err.AddError("Falta el tiempo de vida", 0)
            If txtPrecio.Text.Length = 0 Then Err.AddError("Falta el precio de compra", 0)
            'validar dgvDetalle
            If dsGral.Tables("ActivoDet").Rows.Count = 0 Then Err.AddError("Falta información extra del activo", 0)


            If Err.Errors Then
                Err.ShowDialog()
                Exit Sub
            End If

            'Activo
            dsGral.Tables("ActivoCab").Rows(0)("tipodep") = cmbTipoDep.SelectedValue
            dsGral.Tables("ActivoCab").Rows(0)("ArticuloID") = txtArticulo.Tag
            dsGral.Tables("ActivoCab").Rows(0)("tipoActivoCabID") = cmbTipoActivo.SelectedValue



            'ActivoCompra
            dsGral.Tables("ActivoCompra").Rows(0)("Proveedor") = txtProveedor.Text
            If CheckBox1.Checked Then
                dsGral.Tables("ActivoCompra").Rows(0)("Documento") = txtCompra.Text
            Else
                dsGral.Tables("ActivoCompra").Rows(0)("Documento") = Nothing
            End If
            dsGral.Tables("ActivoCompra").Rows(0)("Fecha") = dtFechaCompra.Value
            dsGral.Tables("ActivoCompra").Rows(0)("Precio") = txtPrecio.Text
            dsGral.Tables("ActivoCompra").Rows(0)("Residual") = txtValor.Text
            dsGral.Tables("ActivoCompra").Rows(0)("Vida") = txtVida.Text


            UpdateTables(0)

            If Adding Then newRecord(0)
            Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim frm As New Inventario.frmArticuloDetalle(Connect, "4")
        frm.Display = True
        frm.ShowDialog()
        If frm.isOK Then
            txtArticulo.Text = frm.RowSelected.Item("Nombre").ToString()
            txtMarca.Text = frm.RowSelected.Item("Marca").ToString()
            txtFamilia.Text = frm.RowSelected.Item("Familia").ToString()
            txtArticulo.Tag = frm.RowSelected.Item("ArticuloID")
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            LinkLabel3.Enabled = True
        Else
            LinkLabel3.Enabled = False
        End If

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim frmTipoActivo = New frmTipoActivoCabList()
        Dim frm = New frmTipoActivoDet(Connect, frmTipoActivo, -1)
        frm.ShowDialog()
    End Sub
End Class
