Imports System.Windows.Forms
Public Class frmDepreciaCabDetail
    Public Sub New(cnx As dcLibrary.dcConnect, parents As dcLibrary.dcParentList, DetailID As Integer)
        MyBase.New(cnx, parents, DetailID)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        newDinamicTable(Connect, 0, "DepreciaCab", "@DepreciaCabID", "@DepreciaCabID", 0, ParameterDirection.InputOutput, -1)
        newDinamicTable(Connect, 0, "ActivoDep", "@DepreciaCabID", "@DepreciaCabID", 0, ParameterDirection.Input, 0)

        LoadDinamicTables()
    End Sub
    Public Overrides Sub SetGrids()
        MyBase.SetGrids()
        dcGral.initGrid(DataGridView1, dsGral.Tables("ActivoDep"), False, False, "ActivoDetID,ActivoDepID", True, True, Connect, DataGridViewContentAlignment.MiddleCenter, True)
    End Sub
    Public Overrides Sub SetCombos()
        MyBase.SetCombos()
        ' dcGral.setCombo(cmbEstado, dsGral.Tables("DepreciaCabEstado"), "Nombre", "Codigo", -1)
    End Sub

    Public Overrides Sub LoadTables()
        MyBase.LoadTables()
        NewTable("Select *from dbo.iStatus('ActivoDet','Estado')", "DepreciaCabEstado") 'Tabla

    End Sub
    Public Overrides Sub DetailRow()
        MyBase.DetailRow()
        If dsGral.Tables("DepreciaCab").Rows.Count = 0 Then
            dsGral.Tables("DepreciaCab").Rows.Add()
        Else
            'Activo
            txtActivo.Text = dsGral.Tables("DepreciaCab").Rows(0).Item("Articulo")
            txtTipoActivo.Text = dsGral.Tables("DepreciaCab").Rows(0).Item("TipoActivo")
            txtTipoDep.Text = dsGral.Tables("DepreciaCab").Rows(0).Item("TipoDep")

            'DepreciaCab
            'cmbEstado.SelectedValue = dsGral.Tables("DepreciaCab").Rows(0).Item("Estado")
            lblEstado.Tag = dsGral.Tables("DepreciaCabEstado").Rows(0).Item(0)
            lblEstado.Text = dsGral.Tables("DepreciaCabEstado").Rows(0).Item(1)
            dtFechaCompra.Value = dsGral.Tables("DepreciaCab").Rows(0).Item("Fecha")


        End If

    End Sub
    Private Sub frmDepreciaCabDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Try
            Err.Clean()
            If txtActivo.Text.Length = 0 Then Err.AddError("Debe seleccionar un Activo", 0)
            'If cmbEstado.SelectedIndex = -1 Then Err.AddError("Falta seleccionar estado", 0)

            If Err.Errors Then
                Err.ShowDialog()
                Exit Sub
            End If

            dsGral.Tables("DepreciaCab").Rows(0).Item("PeriodoDetID") = 0 'El procedimiento almacenado lo va a sobreescribir
            dsGral.Tables("DepreciaCab").Rows(0).Item("Fecha") = dtFechaCompra.Value
            dsGral.Tables("DepreciaCab").Rows(0).Item("Estado") = "G" 'Grabada?
            dsGral.Tables("DepreciaCab").Rows(0).Item("AsientoCabID") = Nothing '¿Se deja en null?

            UpdateTables(0)

            If Adding Then newRecord(0)
            Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles lblEstado.Click

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        'Dim frm = New frmActivoCabList()
        'frm.Connect = Connect
        'frm.ShowDialog()

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub
End Class
