Imports System.Windows.Forms
Public Class frmTipoCapacitaDetail
    Private Cab As Int16
    Public Sub New(cnx As dcLibrary.dcConnect, parents As dcLibrary.dcParentList, DetailID As Integer)
        MyBase.New(cnx, parents, DetailID)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        newDinamicTable(cnx, 0, "TipoCapacitaCab", "@TipoCapacitaCabID", "@TipoCapacitaCabID", DetailID, ParameterDirection.InputOutput, -1)
        newDinamicTable(cnx, 1, "TipoCapacitaDet", "@TipoCapacitaCabID", "@TipoCapacitaCabID", DetailID, ParameterDirection.Input, 0)
        newDinamicTable(cnx, 2, "TipoCompetencia", "@Cab", "@Cab", 0, ParameterDirection.Input, -1)

        LoadDinamicTables()

        Cab = DetailID

    End Sub
    Public Overrides Sub SetGrids()
        MyBase.SetGrids()
        dcGral.initGrid(dgvCompetencia, dsGral.Tables("Competencias"), False, False, "TipoCapacitaDetID,TipoCapacitaCabID,CompetenciaCabID,TipoCompetenciaID", False, False, Connect, DataGridViewContentAlignment.MiddleCenter, False)
        dcGral.FormatColumn(dgvCompetencia, "Nombre", "Competencia", 200, DataGridViewContentAlignment.MiddleLeft, "")
        dcGral.FormatColumn(dgvCompetencia, "sel", " ", 30, DataGridViewContentAlignment.MiddleCenter, "")
        dgvCompetencia.AllowUserToResizeRows = False
    End Sub
    Public Overrides Sub LoadTables()
        MyBase.LoadTables()
        NewTable("select *from dbo.iStatus('TipoCapacitaCab','Tipo')", "Periodos")
        If Cab = -1 Then
            NewTable("exec spTipoCapacitaDetSelect 0", "Competencias")
        Else
            NewTable("exec spTipoCapacitaDetSelect " + Cab.ToString(), "Competencias")
        End If
    End Sub
    Public Overrides Sub SetCombos()
        MyBase.SetCombos()
        dcGral.setCombo(cmbTipoCompetencia, dsGral.Tables(2), "Nombre", "TipoCompetenciaID", 0)
        dcGral.setCombo(cmbTipo, dsGral.Tables("Periodos"), "Nombre", "Codigo", -1)
        cmbTipoCompetencia.DropDownStyle = ComboBoxStyle.DropDownList
        cmbTipoCompetencia.SelectedIndex = 1

    End Sub

    Public Overrides Sub DetailRow()
        MyBase.DetailRow()
        If dsGral.Tables(0).Rows.Count = 0 Then
            dsGral.Tables(0).Rows.Add()
            dsGral.Tables(1).Rows.Add()

        Else
            txtCodigo.Text = dsGral.Tables(0).Rows(0).Item("Codigo").ToString()
            txtCodigo.Tag = dsGral.Tables(0).Rows(0).Item("TipoCapacitaCabID").ToString()
            txtNombre.Text = dsGral.Tables(0).Rows(0).Item("Nombre").ToString()
            CheckBox1.Checked = Boolean.Parse(dsGral.Tables(0).Rows(0).Item("Vence").ToString())
            cmbTipo.SelectedValue = dsGral.Tables(0).Rows(0).Item("codTipo")
            txtTiempo.Text = dsGral.Tables(0).Rows(0).Item("Tiempo").ToString()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub cmbTipoCompetencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoCompetencia.SelectedIndexChanged
        If cmbTipoCompetencia.SelectedValue IsNot Nothing And cmbTipoCompetencia.ValueMember.ToString.Equals("TipoCompetenciaID") Then
            dsGral.Tables("Competencias").DefaultView.RowFilter = "TipoCompetenciaID = " + cmbTipoCompetencia.SelectedValue.ToString()
        End If

    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged

    End Sub

    Private Sub dgvCompetencia_CellContentClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles dgvCompetencia.CellContentClick

    End Sub

    Private Sub TipoCapacitaDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'txtTiempo.Text = Nothing
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Dim b As Boolean
        b = CheckBox1.Checked
        cmbTipo.Enabled = b
        txtTiempo.Enabled = b

        If Not b Then
            txtTiempo.Text = Nothing
            cmbTipo.SelectedIndex = -1
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTiempo.KeyPress
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Try
            Dim selec = False
            For Each fila As DataGridViewRow In dgvCompetencia.Rows
                If Boolean.Parse(fila.Cells("sel").Value.ToString()) Then
                    selec = True
                    Exit For
                End If
            Next
            Err.Clean()
            If txtNombre.Text.Length < 3 Then Err.AddError("Debe ingresar un nombre para el tipo", 0)
            If Not selec Then Err.AddError("Debe seleccionar al menos una competencia", 0)
            If CheckBox1.Checked And cmbTipo.SelectedIndex = -1 Then Err.AddError("Especifique un periodo para renovación de la capacitación", 0)
            If CheckBox1.Checked And (txtTiempo.Text.Length = 0 Or txtTiempo.Text.Equals("0")) Then Err.AddError("Especifique tiempo para renovación de la capacitación", 0)

            If Err.Errors Then
                Err.ShowDialog()
                Exit Sub
            End If

            dsGral.Tables(0).Rows(0)("Nombre") = txtNombre.Text
            dsGral.Tables(0).Rows(0)("Vence") = CheckBox1.Checked
            dsGral.Tables(0).Rows(0)("Tiempo") = If(txtTiempo.Text.Length = 0, DBNull.Value, Double.Parse(txtTiempo.Text))
            dsGral.Tables(0).Rows(0)("Tipo") = cmbTipo.SelectedValue

            For Each fila As DataRow In dsGral.Tables("Competencias").Rows
                If Boolean.Parse(fila.Item("Sel").ToString()) Then
                    'Agregar fila al dt que se va a la base
                    Dim f = dsGral.Tables(1).NewRow()
                    f.ItemArray = fila.ItemArray
                    dsGral.Tables(1).Rows.Add(f)
                End If
            Next
            dsGral.Tables(1).Rows.RemoveAt(0)
            UpdateTables(0)
            If Adding And Me.Parent IsNot Nothing Then newRecord(0)
            Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
