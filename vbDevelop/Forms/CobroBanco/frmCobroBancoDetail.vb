Imports System.Windows.Forms
Public Class frmCobroBancoDetail
    'Public id As Int16
    Public Sub New(cnx As dcLibrary.dcConnect, parents As dcLibrary.dcParentList, DetailID As Integer)
        MyBase.New(cnx, parents, DetailID)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        newDinamicTable(cnx, 0, "CobroBancoCab", "@CobroBancocabID", "@cobroBancoCabID", DetailID, ParameterDirection.InputOutput, -1)
        newDinamicTable(cnx, 1, "CobroBancoDet", "@CobroBancocabID", "@cobroBancoCabID", DetailID, ParameterDirection.InputOutput, 0)


        'id = DetailID
        LoadDinamicTables()
    End Sub
    Public Overrides Sub LoadTables()
        MyBase.LoadTables()

        NewTable("select *from Sitio", "Sitio")
        NewTable("spTipoSelect 'CobroBancoCab'", "Tipo")
        NewTable("select *from dbo.iStatus ('CobroBancoCab','Estado')", "Estado")
        NewTable("select *from vPuntoVentaDet", "PuntoVenta")

    End Sub
    Public Overrides Sub SetGrids()
        MyBase.SetGrids()

        dcGral.initGrid(DataGridView1, dsGral.Tables(1), False, False, "CobroBancoCabID,CobroBancoDetID,AvisoCabID,", True, True, Connect, DataGridViewContentAlignment.MiddleCenter, True, 40, True, False)
        dcGral.FormatColumn(DataGridView1, "codigo", "", 80, "C", "", True)
        dcGral.FormatColumn(DataGridView1, "nomTipoContrato", "Tipo Contrato", 300, "L", "", True)
        dcGral.FormatColumn(DataGridView1, "periodo", "", 80, "C", "", True)
        dcGral.FormatColumn(DataGridView1, "valor", "", 80, "R", "n2", True)
    End Sub
    Public Overrides Sub SetCombos()
        MyBase.SetCombos()
        dcGral.setCombo(cmbUbicacion, dsGral.Tables("Sitio"), "Nombre", "SitioID", -1)
        'dcGral.setCombo(cmbTipo, dsGral.Tables("Tipo"), "Nombre", "TipoID", -1)
        dcGral.setCombo(cmbPuntoVenta, dsGral.Tables("PuntoVenta"), "BancoCuenta", "PuntoVentaDetID", -1)
    End Sub
    Public Overrides Sub DetailRow()
        If dsGral.Tables(0).Rows.Count = 0 Then
            dsGral.Tables(0).Rows.Add()
        Else
            Try
                Dim row = dsGral.Tables(0).Rows(0)
                txtCodigo.Text = row("codCobro")
                dtpFecha.Value = row("Fechaf")
                txtDuracion.Text = row("Duracion")
                txtCliente.Text = row("Cliente")
                txtCliente.Tag = row("codCliente")
                txtTipo.Text = row("Grado")
                cmbPuntoVenta.SelectedValue = row("codPuntoVenta").ToString()
                'cmbTipo.SelectedValue = row("codTipo").ToString()
                cmbUbicacion.SelectedValue = row("CodSitio")
                lblEstado.Text = row("Estado")
                lblEstado.Tag = row("CodEstado")
                'refrescarDet("cobroBancoCabID", id)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.DefaultButton1)
            End Try

            If lblEstado.Tag = "P" Or lblEstado.Tag = "N" Then
                btnSalvar.Enabled = False
                'btnProcesar.Enabled = False
            End If
        End If

        lblEstado.Text = "Grabado"
    End Sub
    Private Sub Total()
        Dim total As Double = 0

        For Each row As DataRow In dsGral.Tables("CobroBancoDet").DefaultView.Table.Rows
            total += row.Item("valor")
        Next

        txtValor.Text = Format(total, "###,###.00")
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        'Validaciones
        Try
            Err.Clean()
            If txtDuracion.Text.Length = 0 Then Err.AddError("Debe ingresar duración", 0)
            If txtCliente.Text.Length = 0 Then Err.AddError("Seleccione un cliente", 0)
            If cmbUbicacion.SelectedIndex = -1 Then Err.AddError("Debe seleccionar una ubicación", 0)
            'If cmbTipo.SelectedIndex = -1 Then Err.AddError("Seleccione un tipo", 0)
            If cmbPuntoVenta.SelectedIndex = -1 Then Err.AddError("Seleccione el punto de venta", 0)
            Dim fecha = dtpFecha.Value

            'periodo abierto?
            If dcGral.getPeriodoDet(Format(fecha, Connect.DateFormat), "B", "A", Connect) = -1 Then Err.AddError("El periodo de Bancos no está abierto", 0)


            Dim seleccionado As Boolean = False

            For Each fila As DataGridViewRow In DataGridView1.Rows
                If fila.Cells("Sel").Value IsNot Nothing AndAlso CBool(fila.Cells("Sel").Value) Then
                    seleccionado = True
                    Exit For
                End If
            Next

            If seleccionado = False Then Err.AddError("No hay avisos seleccionados", 1)

            If Err.Errors Then
                Err.ShowDialog()
                Exit Sub
            End If


            dsGral.Tables("CobroBancoCab").Rows(0)("Fecha") = dtpFecha.Value
            dsGral.Tables("CobrobancoCab").Rows(0)("Duracion") = txtDuracion.Text
            dsGral.Tables("CobrobancoCab").Rows(0)("ClienteID") = txtCliente.Tag
            dsGral.Tables("CobrobancoCab").Rows(0)("SitioID") = txtDuracion.Text
            'dsGral.Tables("CobroBancoCab").Rows(0)("TipoID") = cmbTipo.SelectedValue
            dsGral.Tables("CobroBancoCab").Rows(0)("PuntoVentaDetID") = cmbPuntoVenta.SelectedValue

            For i As Integer = DataGridView1.Rows.Count - 1 To 0 Step -1
                Dim fila As DataGridViewRow = DataGridView1.Rows(i)

                ' Verificamos que la celda no sea Nothing y que el valor sea False o nulo
                If fila.Cells("Sel").Value Is Nothing OrElse Not CBool(fila.Cells("Sel").Value) Then
                    DataGridView1.Rows.RemoveAt(i)
                End If
            Next

            UpdateTables(0)
            If Adding Then newRecord(0)
            Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.DefaultButton1)
        End Try
    End Sub
    Private Sub refrescarDet(parm As String, value As Int16)
        Dim tab As New DataTable
        tab = dcGral.getDataTable("spCobroBancoDetSelect @" + parm + "=" + value.ToString(), Connect)

        replaceTable("CobroBancoDet", tab)
    End Sub
    Private Sub lnkCliente_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCliente.LinkClicked
        Dim frm As New CuentasCobrar.frmClienteList(Connect, False)
        frm.Connect = Connect

        frm.Display = True
        frm.ShowDialog()

        If frm.isOK Then
            txtCliente.Text = frm.RowSelected.Item("Nombre").ToString()
            txtCliente.Tag = frm.RowSelected.Item("ClienteID").ToString()

            Dim frmAvisos As New Contratos.frmAvisoList(Connect, 0, txtCliente.Tag, 1, 0, 0, 0)
            frmAvisos.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
            frmAvisos.Display = True
            frmAvisos.ShowDialog()

            If frmAvisos.isOK Then
                For Each row As DataRow In frmAvisos.Table.Rows
                    If row.Item("sel") Then
                        Dim nRow As DataRow = dsGral.Tables("CobroBancoDet").NewRow

                        nRow.Item("AvisoCabID") = row.Item("AvisoCabID")
                        nRow.Item("Codigo") = row.Item("Codigo")
                        nRow.Item("nomTipoContrato") = row.Item("nomTipoContrato")
                        nRow.Item("Periodo") = row.Item("Periodo")
                        nRow.Item("valor") = row.Item("Total")

                        dsGral.Tables("CobroBancoDet").Rows.Add(nRow)
                    End If
                Next

                Total()
            End If
        End If
    End Sub
    Private Sub frmCobroBancoDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
