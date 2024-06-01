Imports System.Globalization
Imports System.Windows.Forms
Public Class frmDepreciaCabDetail
    Public Sub New(cnx As dcLibrary.dcConnect, parents As dcLibrary.dcParentList, DetailID As Integer)
        MyBase.New(cnx, parents, DetailID)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        newDinamicTable(Connect, 0, "DepreciaCab", "@DepreciaCabID", "@DepreciaCabID", DetailID, ParameterDirection.InputOutput, -1)

        LoadDinamicTables()
    End Sub

    Public Overrides Sub SetGrids()
        MyBase.SetGrids()
        dcGral.initGrid(dgvActivos, dsGral.Tables("Activos"), True, True, "ActivoCabID,ActivoCompraID,Fecha", False, False, Connect, DataGridViewContentAlignment.MiddleCenter, False)
    End Sub
    Public Overrides Sub SetCombos()
        MyBase.SetCombos()

    End Sub

    Public Overrides Sub LoadTables()
        MyBase.LoadTables()
        NewTable("Select *from dbo.iStatus('activoDet','Estado')", "DepreciaCabEstado") 'Tabla        
        NewTable("execute spActivoDeprecia ", "Activos")
    End Sub
    Public Overrides Sub DetailRow()
        MyBase.DetailRow()
        If dsGral.Tables("DepreciaCab").Rows.Count = 0 Then
            dsGral.Tables("DepreciaCab").Rows.Add()
        Else
            lblEstado.Tag = dsGral.Tables("DepreciaCabEstado").Rows(0).Item(0).ToString()
            lblEstado.Text = dsGral.Tables("DepreciaCabEstado").Rows(0).Item(1).ToString()
            dtFecha.Value = dsGral.Tables("DepreciaCab").Rows(0).Item("Fecha")
        End If

    End Sub
    Private Sub frmDepreciaCabDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles dgvActivos.CellContentClick

    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Try

            dsGral.Tables("DepreciaCab").Rows(0).Item("PeriodoDetID") = 0 'El procedimiento almacenado lo va a sobreescribir
            dsGral.Tables("DepreciaCab").Rows(0).Item("Fecha") = dtFecha.Value.ToString("yyyy/MM/dd")
            dsGral.Tables("DepreciaCab").Rows(0).Item("Estado") = "G"
            dsGral.Tables("DepreciaCab").Rows(0).Item("AsientoCabID") = 0 'El procedimiento almacenado lo va a sobreescribir

            UpdateTables(0)

            If Adding Then newRecord(0)
            Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles lblEstado.Click

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        'Dim frm = New frmActivoCabList()
        'frm.Connect = Connect
        'frm.ShowDialog()

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        'no hay cero filas en el gridView
        'Salvar,        
        lblEstado.Text = dtFecha.Value.ToShortDateString()
    End Sub

    Private Sub dtFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtFecha.ValueChanged

    End Sub
End Class
