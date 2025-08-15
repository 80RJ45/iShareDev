Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class frmCapacitaCabDetail
    Public Cab As Integer
    Public Sub New(cnx As dcLibrary.dcConnect, parents As dcLibrary.dcParentList, DetailID As Integer)
            MyBase.New(cnx, parents, DetailID)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Cab = DetailID

        newDinamicTable(cnx, 0, "CapacitaCab", "@CapacitaCabID", "@CapacitaCabID", DetailID, ParameterDirection.InputOutput, -1)
        newDinamicTable(cnx, 1, "CapacitaDet", "@CapacitaCabID", "@CapacitaCabID", DetailID, ParameterDirection.Input, 0)

        LoadDinamicTables()
    End Sub
    Public Overrides Sub LoadTables()
        MyBase.LoadTables()
        NewTable("select *from dbo.iStatus('CapacitaCab','Tipo')", "Periodos")
        NewTable("Select *from TipoCapacitaCab", "TipoCapacita")
    End Sub
    Public Overrides Sub SetCombos()
        MyBase.SetCombos()
        dcGral.setCombo(cmbTipo, dsGral.Tables("Periodos"), "Nombre", "Codigo", -1)
        dcGral.setCombo(cmbTipoCapacitacion, dsGral.Tables("TipoCapacita"), "Nombre", "TipoCapacitaCabID", -1)
    End Sub
    Public Overrides Sub SetGrids()
        MyBase.SetGrids()
        dcGral.initGrid(dgvEmpleados, dsGral.Tables(1), True, True, "CapacitaDetID,CapacitaCabID,EmpleadoID", True, True, Connect, DataGridViewContentAlignment.MiddleCenter, False)
        dcGral.FormatColumn(dgvEmpleados, "codEmpleado", "Codigo", 50, 1, "", False)
        dcGral.FormatColumn(dgvEmpleados, "Empleado", "Empleado", 250, 1, "", True)
        dcGral.FormatColumn(dgvEmpleados, "Identidad", "Identidad", 100, 1, "", True)
        dcGral.FormatColumn(dgvEmpleados, "Puesto", "Puesto", 120, 1, "", True)
        dcGral.FormatColumn(dgvEmpleados, "Horario", "Horario", 120, 1, "", True)
    End Sub
    Public Overrides Sub DetailRow()
        MyBase.DetailRow()
        If dsGral.Tables(0).Rows.Count = 0 Then
            dsGral.Tables(0).Rows.Add()
            'dsGral.Tables(1).Rows.Add()
        Else
            Dim fila = dsGral.Tables(0).Rows(0)
            txtCodigo.Tag = fila(0).ToString()
            txtCodigo.Text = fila(1).ToString()
            txtNombre.Text = fila(2).ToString()
            txtLugar.Text = fila(3).ToString()
            txtInstructor.Text = fila(4).ToString()
            dtpInicio.Value = DateTime.Parse(fila(5).ToString())
            dtpFinal.Value = DateTime.Parse(fila(6).ToString())
            txtTiempo.Text = fila(9).ToString()
            cmbTipo.SelectedValue = fila(10)
            txtPrecio.Text = fila(11).ToString()
            cmbTipoCapacitacion.SelectedValue = fila(12)
        End If
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub frmCapacitaCabDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub lblTipo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblTipo.LinkClicked
        Try
            Dim frm = New frmTipoCapacitaDetail(Connect, Nothing, -1)
            frm.ShowDialog()

            dsGral.Tables("TipoCapacita").Clear()
            dsGral.Tables("TipoCapacita").Merge(dcGral.getDataTable("Select *from TipoCapacitaCab", Connect))
            'NewTable("Select *from TipoCapacitaCab", "TipoCapacita")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgvEmpleados_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvEmpleados.CellValidating

        Dim rowIndex As Integer = dgvEmpleados.CurrentCell.RowIndex
        Dim columnIndex As Integer = dgvEmpleados.CurrentCell.ColumnIndex
        Dim valor As String = e.FormattedValue.ToString()

        Dim col As String = dgvEmpleados.Columns(columnIndex).Name.ToLower

        If col.Equals("codempleado") Then
            If valor.ToString.Length > 0 Then
                If valor = "*" Then
                    'Mostrar formulario

                Else
                    'Cargar directamente
                    Dim sql As String =
                        "select e.EmpleadoID,e.Codigo codEmpleado,e.Nombre Empleado,e.Identidad, p.Nombre Puesto,h.Nombre Horario
                        from (select *from Empleado where codigo = '" & valor & "' )e
                        inner join (select *from Labor where empleadoID in (select empleadoID from Empleado where codigo = '" & valor & "' ))
                        l on l.EmpleadoID = e.EmpleadoID
                        inner join Puesto p on p.PuestoID = l.PuestoID
                        left join HorarioCab h on h.HorarioCabID = l.HorarioCabID"

                    Dim tabEmpleado As DataTable = dcGral.getDataTable(sql, Connect)
                    If tabEmpleado.Rows.Count > 0 Then
                        'El empleado existe, cargar información                        
                        'Validar que no se haya agregado

                        'comprobar que si se enccontró uno que ya estaba en la tabla no sea el de la misma fila
                        Dim f() As DataRow = dsGral.Tables(1).Select("codempleado = '" & valor & "'")

                        If f.Length > 0 Then
                            Dim antIndexRow As Integer = dsGral.Tables(1).Rows.IndexOf(f(0))
                            If antIndexRow = rowIndex Then
                                Exit Sub
                            End If

                            Err.AddError("El empleado ya fue agregado", 0)
                            Err.ShowDialog()
                            Err.Clean()
                            e.Cancel = True


                            If Not dgvEmpleados.Rows(dgvEmpleados.Rows.Count - 1).IsNewRow Then dsGral.Tables(1).Rows.Add()
                            dsGral.Tables(1).DefaultView.Item(rowIndex).Delete()
                            Try
                                'dgvEmpleados.Item(columnIndex, dgvEmpleados.Rows.Count - 1).Selected = True
                                dgvEmpleados.CurrentCell = dgvEmpleados.Item(columnIndex, dgvEmpleados.Rows.Count - 1)
                                'dgvEmpleados.BeginEdit(True)

                            Catch ex As Exception
                            End Try

                            dgvEmpleados.Refresh()
                            Exit Sub
                        End If

                        dsGral.Tables(1).DefaultView.Item(rowIndex).Item("EmpleadoID") = tabEmpleado.Rows(0)("EmpleadoID")
                        dsGral.Tables(1).DefaultView.Item(rowIndex).Item("Empleado") = tabEmpleado.Rows(0)("Empleado")
                        dsGral.Tables(1).DefaultView.Item(rowIndex).Item("Identidad") = tabEmpleado.Rows(0)("Identidad")
                        dsGral.Tables(1).DefaultView.Item(rowIndex).Item("Puesto") = tabEmpleado.Rows(0)("Puesto")
                        dsGral.Tables(1).DefaultView.Item(rowIndex).Item("Horario") = tabEmpleado.Rows(0)("Horario")
                        dgvEmpleados.Refresh()
                    Else
                        MsgBox("No existe el empleado", MsgBoxStyle.Critical, "Error")
                        dsGral.Tables(1).DefaultView.Item(rowIndex).Item("codempleado") = ""
                        e.Cancel = True
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Try
            Err.Clean()
            If cmbTipoCapacitacion.SelectedIndex = -1 Or cmbTipoCapacitacion.SelectedValue Is Nothing Then Err.AddError("Seleccione un tipo de capacitación", 0)
            If txtNombre.Text.Length < 3 Then Err.AddError("Agregue un nombre para la capacitación", 0)
            If txtLugar.Text.Length < 3 Then Err.AddError("Agregue un lugar para la capacitación", 0)
            If txtInstructor.Text.Length < 3 Then Err.AddError("Agregue un Instructor", 0)
            If txtPrecio.Text.Length < 1 Then Err.AddError("Especifique un precio", 1)
            If txtTiempo.Text.Length < 1 Then Err.AddError("Especifique el tiempo", 0)
            If cmbTipo.SelectedIndex = -1 Or cmbTipo.SelectedValue Is Nothing Then Err.AddError("Seleccione un periodo", 0)
            If dtpInicio.Value.Date > dtpFinal.Value.Date Then Err.AddError("La fecha de finalización debe ser posterior a la fecha inicial", 0)
            If dsGral.Tables(1).Rows.Count = 0 Then Err.AddError("Agregue empleados a la capacitación", 0)

            If Err.Errors Then
                Err.ShowDialog()
                Exit Sub
            End If

            dsGral.Tables(0).Rows(0)("CodCapacita") = txtCodigo.Text
            dsGral.Tables(0).Rows(0)("nomCapacita") = txtNombre.Text
            dsGral.Tables(0).Rows(0)("TipoCapacitaCabID") = cmbTipoCapacitacion.SelectedValue
            dsGral.Tables(0).Rows(0)("Lugar") = txtLugar.Text
            dsGral.Tables(0).Rows(0)("Instructor") = txtInstructor.Text
            dsGral.Tables(0).Rows(0)("Precio") = txtPrecio.Text
            dsGral.Tables(0).Rows(0)("Tiempo") = txtTiempo.Text
            dsGral.Tables(0).Rows(0)("codTipo") = cmbTipo.SelectedValue
            dsGral.Tables(0).Rows(0)("Inicio") = dtpInicio.Value
            dsGral.Tables(0).Rows(0)("Final") = dtpFinal.Value

            dsGral.Tables(0).Columns.Item("nomCapacita").ColumnName = "Nombre"
            dsGral.Tables(0).Columns.Item("codCapacita").ColumnName = "Codigo"
            dsGral.Tables(0).Columns.Item("codTipo").ColumnName = "Tipo"
            UpdateTables(0)

            dsGral.Tables(0).Columns.Item("Nombre").ColumnName = "nomCapacita"
            dsGral.Tables(0).Columns.Item("Codigo").ColumnName = "codCapacita"
            dsGral.Tables(0).Columns.Item("Tipo").ColumnName = "codTipo"
            If Adding Then newRecord(0)
            Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub dgvEmpleados_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvEmpleados.KeyPress

    End Sub

    Private Sub txtTiempo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTiempo.KeyPress
        ' Permitir tecla de retroceso (Backspace)
        If Char.IsControl(e.KeyChar) Then
            Return
        End If

        ' Permitir solo números y un punto decimal
        If Char.IsDigit(e.KeyChar) Then
            Return
        End If

        ' Permitir un solo punto decimal
        If e.KeyChar = "."c AndAlso Not txtTiempo.Text.Contains(".") Then
            Return
        End If

        ' Si no cumple ninguna condición, cancelar la tecla
        e.Handled = True
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        ' Permitir tecla de retroceso (Backspace)
        If Char.IsControl(e.KeyChar) Then
            Return
        End If

        ' Permitir solo números y un punto decimal
        If Char.IsDigit(e.KeyChar) Then
            Return
        End If

        ' Permitir un solo punto decimal
        If e.KeyChar = "."c AndAlso Not txtPrecio.Text.Contains(".") Then
            Return
        End If

        ' Si no cumple ninguna condición, cancelar la tecla
        e.Handled = True
    End Sub

    Private Sub dgvEmpleados_KeyUp(sender As Object, e As KeyEventArgs) Handles dgvEmpleados.KeyUp
    End Sub

    Private Sub dgvEmpleados_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmpleados.CellEndEdit

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

    End Sub
End Class
