Imports System.Windows.Forms

Public Class frmTipoActivoDet
    Private codCuenta As String = ""
    Public Sub New(cnx As dcLibrary.dcConnect, parents As dcLibrary.dcParentList, DetailID As Integer)
        MyBase.New(cnx, parents, DetailID)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        newDinamicTable(cnx, 0, "TipoActivoCab", "@TipoActivoCabID", "@TipoActivoCabID", DetailID, ParameterDirection.InputOutput, -1)
        newDinamicTable(cnx, 1, "TipoActivoDet", "@TipoActivoCabID", "@TipoActivoCabID", DetailID, ParameterDirection.Input, 0)
        LoadDinamicTables()
    End Sub
    Public Overrides Sub SetGrids()
        MyBase.SetGrids()
        dcGral.initGrid(DataGridView1, dsGral.Tables("TipoActivoDet"), True, True, "TipoActivoCabID,TipoActivoDetID,CuentaID,Tipo", True, True, Connect, DataGridViewContentAlignment.MiddleCenter, False)
        dcGral.addComboGrid(DataGridView1, Connect, "Select *from dbo.iStatus('TipoActivoDet','Tipo')", "Tipo", 3, "Tipo", "Nombre", "Codigo", 100)
        dcGral.FormatColumn(DataGridView1, "nomCuenta", "Descripcion Cuenta", 300, "L", "", True)
        dcGral.FormatColumn(DataGridView1, "Numero", "#Cuenta", 90, "L", "", False)


    End Sub

    Public Overrides Sub LoadTables()
        MyBase.LoadTables()
        NewTable("Select *from dbo.iStatus('TipoActivoCab','Estado')", "TipoActivoEstado")
    End Sub
    Public Overrides Sub SetCombos()
        MyBase.SetCombos()
        dcGral.setCombo(cmbEstado, dsGral.Tables("TipoActivoEstado"), "Nombre", "Codigo", 0)
    End Sub

    Public Overrides Sub DetailRow()
        MyBase.DetailRow()
        If dsGral.Tables("TipoActivoCab").Rows.Count = 0 Then
            'Modalidad de adición
            dsGral.Tables("TipoActivoCab").Rows.Add()
        Else
            txtCodigo.Text = dsGral.Tables("TipoActivoCab").Rows(0).Item("Codigo")
            txtNombre.Text = dsGral.Tables("TipoActivoCab").Rows(0).Item("Nombre")
            txtObservacion.Text = dsGral.Tables("TipoActivoCab").Rows(0).Item("Observacion")
            txtResidual.Text = dsGral.Tables("TipoActivoCab").Rows(0).Item("Residual")
            txtVida.Text = dsGral.Tables("TipoActivoCab").Rows(0).Item("Vida")

        End If
    End Sub
    Private Sub frmTipoActivoDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Try
            Err.Clean()
            If txtNombre.Text.Length = 0 Then Err.AddError("Falta el Nombre", 0)
            If dsGral.Tables("TipoActivoDet").DefaultView.Count = 0 Then Err.AddError("Debe seleccionar una cuenta", 0)
            If txtResidual.Text.Length = 0 Then Err.AddError("Falta Residual", 0)
            If txtVida.Text.Length = 0 Then Err.AddError("Falta ingresar el tiempo de vida", 0)
            If txtObservacion.Text.Length = 0 Then Err.AddError("Falta observación", 1)


            If Err.Errors Then
                Err.ShowDialog()
                Exit Sub 'para finalizar'
            End If

            dsGral.Tables("TipoActivoCab").Rows(0)("Codigo") = txtCodigo.Text
            dsGral.Tables("TipoActivoCab").Rows(0)("Nombre") = txtNombre.Text
            dsGral.Tables("TipoActivoCab").Rows(0)("Observacion") = txtObservacion.Text
            dsGral.Tables("TipoActivoCab").Rows(0)("Residual") = txtResidual.Text
            dsGral.Tables("TipoActivoCab").Rows(0)("Vida") = txtVida.Text
            dsGral.Tables("TipoActivoCab").Rows(0)("Estado") = dsGral.Tables("TipoActivoEstado").Rows(cmbEstado.SelectedIndex).Item("Codigo")


            'Actualizar tablas.
            UpdateTables(0)

            If Adding Then newRecord(0)
            Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub DataGridView1_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating
        Dim col As String = DataGridView1.Columns(e.ColumnIndex).Name.ToLower

        If col = "numero" Then
            If e.FormattedValue.ToString.Length > 0 Then
                If e.FormattedValue = "**" Then
                    Dim frm As New Contabilidad.frmCatalogoDetail(Connect, True, -1, -1)
                    frm.ShowDialog()
                    If frm.isOK Then
                        dsGral.Tables("TipoActivoDet").DefaultView.Item(e.RowIndex).Item("nomCuenta") = frm.Nombre
                        dsGral.Tables("TipoActivoDet").DefaultView.Item(e.RowIndex).Item("CuentaID") = frm.CuentaID
                        codCuenta = frm.Codigo
                        DataGridView1.Refresh()
                    End If
                Else
                    Dim sql As String = "Select *from dbo.iCuenta() where numero = '" & e.FormattedValue & "'"
                    Dim tabCuenta As DataTable = dcGral.getDataTable(sql, Connect)
                    If tabCuenta.Rows.Count = 0 Then
                        MsgBox("La cuenta no existe.", MsgBoxStyle.Critical, "Error")
                        e.Cancel = True
                        Exit Sub
                    Else
                        If tabCuenta.Rows(0).Item("nomNivel").ToString.ToLower = "cuenta" Then
                            dsGral.Tables("TipoActivoDet").DefaultView.Item(e.RowIndex).Item("Numero") = tabCuenta.Rows(0).Item("numero")
                            dsGral.Tables("TipoActivoDet").DefaultView.Item(e.RowIndex).Item("nomCuenta") = tabCuenta.Rows(0).Item("Nombre")
                            dsGral.Tables("TipoActivoDet").DefaultView.Item(e.RowIndex).Item("CuentaID") = tabCuenta.Rows(0).Item("CuentaID")
                            DataGridView1.Refresh()
                        Else
                            MsgBox("Esta cuenta no permite transacciones", MsgBoxStyle.Critical, "Error")
                            e.Cancel = True
                            Exit Sub
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValidated
        Dim col As String = DataGridView1.Columns(e.ColumnIndex).Name.ToLower

        If col = "numero" And codCuenta.Length > 0 Then
            dsGral.Tables("TipoActivoDet").DefaultView.Item(e.RowIndex).Item("numero") = codCuenta
            codCuenta = ""
            DataGridView1.Refresh()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()

    End Sub
End Class
