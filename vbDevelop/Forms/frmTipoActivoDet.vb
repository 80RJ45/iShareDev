Imports System.Windows.Forms

Public Class frmTipoActivoDet
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
        dcGral.initGrid(DataGridView1, dsGral.Tables("TipoActivoDet"), True, True, "TipoActivoCabID", True, True, Connect, DataGridViewContentAlignment.MiddleCenter, False)
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
            'txtEstado.Text = dsGral.Tables("TipoActivoCab").Rows(0).Item("Estado")
            txtResidual.Text = dsGral.Tables("TipoActivoCab").Rows(0).Item("Residual")
            txtVida.Text = dsGral.Tables("TipoActivoCab").Rows(0).Item("Vida")

        End If
    End Sub
    Private Sub frmTipoActivoDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Try
            Err.Clean()
            If txtCodigo.Text.Length = 0 Then Err.AddError("Falta el Codigo", 0)
            If txtNombre.Text.Length = 0 Then Err.AddError("Falta el Nombre", 0)
            If dsGral.Tables("TipoActivoDet").DefaultView.Count = 0 Then Err.AddError("Faltan datos  del detalle", 0)
            If txtResidual.Text.Length = 0 Then Err.AddError("Falta el Codigo", 0)
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

            'Actualizar tablas
            UpdateTables(0)

            If Adding Then newRecord(0)
            Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
