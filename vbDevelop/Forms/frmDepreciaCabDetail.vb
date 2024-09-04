Imports System.Globalization
Imports System.Windows.Forms
Public Class frmDepreciaCabDetail
    Dim id
    Dim per
    Public Sub New(cnx As dcLibrary.dcConnect, parents As dcLibrary.dcParentList, DetailID As Integer)
        MyBase.New(cnx, parents, DetailID)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        newDinamicTable(Connect, 0, "DepreciaCab", "@DepreciaCabID", "@DepreciaCabID", DetailID, ParameterDirection.InputOutput, -1)
        id = DetailID

        LoadDinamicTables()
    End Sub

    Public Overrides Sub SetGrids()
        MyBase.SetGrids()
        If id = -1 Then
            dcGral.initGrid(dgvActivos, dsGral.Tables("Activos"), False, False, "ActivoCabID,ActivoCompraID,Fecha", True, True, Connect, DataGridViewContentAlignment.MiddleCenter, False)
        Else
            dcGral.initGrid(dgvActivos, dsGral.Tables("ActivoDep"), False, False, "ActivoDepID,codDepreciacion,Fecha", True, True, Connect, DataGridViewContentAlignment.MiddleCenter, False)
        End If

        dcGral.FormatColumn(dgvActivos, "codActivo", "Codigo", 50, DataGridViewContentAlignment.MiddleLeft, "")
        dcGral.FormatColumn(dgvActivos, "Activo", "Activo", 160, DataGridViewContentAlignment.MiddleLeft, "")
        dcGral.FormatColumn(dgvActivos, "centro", "Ubicacion", 80, DataGridViewContentAlignment.MiddleLeft, "")
        dcGral.FormatColumn(dgvActivos, "estado", "Estado", 60, DataGridViewContentAlignment.MiddleLeft, "")
        dcGral.FormatColumn(dgvActivos, "ValorDep", "Valor", 60, DataGridViewContentAlignment.MiddleRight, "")

    End Sub
    Public Overrides Sub SetCombos()
        MyBase.SetCombos()

    End Sub

    Public Overrides Sub LoadTables()
        MyBase.LoadTables()
        NewTable("Select *from dbo.iStatus('activoDet','Estado')", "DepreciaCabEstado") 'Tabla        
        If id = -1 Then
            NewTable("execute spActivoDeprecia ", "Activos")
        Else
            NewTable("exec spActivoDepSelect " + id.ToString(), "ActivoDep")
        End If
        per = dcGral.getPeriodoDet(dtFecha.Value.ToString("yyyy/MM/dd"), "I", "A", Connect).ToString()
        NewTable("select nomPeriodo from vPeriodoDet where periodoDetID = " + per, "nomPeriodo", Connect)
        NewTable("spGetValorDepreciacion " + id.ToString(), "ValorDep")

    End Sub
    Public Overrides Sub DetailRow()
        MyBase.DetailRow()
        If dsGral.Tables("DepreciaCab").Rows.Count = 0 Then
            dsGral.Tables("DepreciaCab").Rows.Add()
            txtPeriodo.Text = dsGral.Tables("nomPeriodo").Rows(0).Item("nomPeriodo").ToString()
        Else
            lblEstado.Tag = dsGral.Tables("DepreciaCabEstado").Rows(0).Item(0).ToString()
            lblEstado.Text = dsGral.Tables("DepreciaCabEstado").Rows(0).Item(1).ToString()
            dtFecha.Value = dsGral.Tables("DepreciaCab").Rows(0).Item("Fecha")
            txtCodigo.Text = dsGral.Tables("DepreciaCab").Rows(0).Item("DepreciaCabID")
            txtAsiento.Text = dsGral.Tables("DepreciaCab").Rows(0).Item("AsientoCabID").ToString()
            'txtPeriodo.Text = dsGral.Tables("nomPeriodo").Rows(0).Item("nomPeriodo").ToString()
            txtValor.Text = dsGral.Tables("ValorDep").Rows(0).Item(0).ToString()

            If dsGral.Tables("DepreciaCab").Rows(0).Item(3).ToString.ToLower().Equals("p") Then
                btnSalvar.Enabled = False
            End If
        End If

    End Sub
    Private Sub frmDepreciaCabDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles dgvActivos.CellContentClick

    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Try
            Err.Clean()
            If dcGral.getPeriodoDet(dtFecha.Value.ToString("yyyy/MM/dd"), "I", "A", Connect) = -1 Then
                Err.AddError("El periodo de inventario no está abierto", 0)
            Else
                'getDataTable con el procedimiento que valida que no hayan depreciaCab de ese período
                dsGral.Tables.Add(dcGral.getDataTable("exec spDepreciaCabPeriodo " + (dcGral.getPeriodoDet(dtFecha.Value.ToString("yyyy/MM/dd"), "I", "A", Connect)).ToString(), Connect))
                If dsGral.Tables(dsGral.Tables.Count - 1).Rows.Count > 0 Then
                    Err.AddError("Ya se ha registrado depreciación para los activos en este período", 0)
                End If

            End If


            If Err.Errors Then
                Err.ShowDialog()
                Exit Sub
            End If

            dsGral.Tables("DepreciaCab").Rows(0).Item("PeriodoDetID") = 0 'El procedimiento almacenado lo va a sobreescribir
            dsGral.Tables("DepreciaCab").Rows(0).Item("Fecha") = dtFecha.Value.ToString("yyyy/MM/dd")
            dsGral.Tables("DepreciaCab").Rows(0).Item("Estado") = "G"
            dsGral.Tables("DepreciaCab").Rows(0).Item("AsientoCabID") = -1 'El procedimiento almacenado lo va a sobreescribir

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

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs)
        Try
            Err.Clean()
            If dcGral.getPeriodoDet(dtFecha.Value.ToString("yyyy/MM/dd"), "I", "A", Connect) = -1 Then
                Err.AddError("El periodo de inventario no está abierto", 0)
            Else
                dsGral.Tables.Add(dcGral.getDataTable("exec spDepreciaCabPeriodo " + (dcGral.getPeriodoDet(dtFecha.Value.ToString("yyyy/MM/dd"), "I", "A", Connect)).ToString(), Connect))
                If dsGral.Tables(dsGral.Tables.Count - 1).Rows.Count > 0 Then
                    Err.AddError("Error,Ya se ha registrado depreciación para los activos en este período", 0)
                End If
                'getDataTable con el procedimiento que valida que no hayan depreciaCab de ese período
            End If


            If Err.Errors Then
                Err.ShowDialog()
                Exit Sub
            End If

            dsGral.Tables("DepreciaCab").Rows(0).Item("PeriodoDetID") = 0 'El procedimiento almacenado lo va a sobreescribir
            dsGral.Tables("DepreciaCab").Rows(0).Item("AsientoCabID") = -1
            dsGral.Tables("DepreciaCab").Rows(0).Item("Fecha") = dtFecha.Value.ToString("yyyy/MM/dd")
            dsGral.Tables("DepreciaCab").Rows(0).Item("Estado") = "P"
            UpdateTables(0)

            dcGral.executeProcedure("exec spDepreciaCabProceso " + iParameter(0).Value.ToString(), Connect)
            'iParameter(0) devuelve el ID de la fila



            If Adding Then newRecord(0)
            Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try


    End Sub

    Private Sub dtFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtFecha.ValueChanged
        per = dcGral.getPeriodoDet(dtFecha.Value.ToString("yyyy/MM/dd"), "I", "", Connect).ToString()
        Dim tab = New DataTable
        tab = dcGral.getDataTable("select nomPeriodo from vPeriodoDet where periodoDetID = " + per.ToString(), Connect)
        If per > "0" Then
            txtPeriodo.Text = tab.Rows(0).Item(0).ToString()
        Else
            txtPeriodo.Text = ""
        End If
    End Sub
End Class
