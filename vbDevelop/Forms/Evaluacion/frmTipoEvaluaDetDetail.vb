Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class frmTipoEvaluaDetDetail

    Public Sub New(cnx As dcLibrary.dcConnect, parents As dcLibrary.dcParentList, DetailID As Integer)
        MyBase.New(cnx, parents, DetailID)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        newDinamicTable(Connect, 0, "TipoEvaluaDet", "@TipoEvaluaDetID", "@TipoEvaluaDetID", DetailID, ParameterDirection.InputOutput, 0)
        LoadDinamicTables()



    End Sub
    Public Overrides Sub LoadTables()
        MyBase.LoadTables()

        NewTable("select *from TipoEvaluaCab", "TipoEvaluaCab", Connect)
        NewTable("select *from dbo.iStatus('TipoEvaluaDet','Estado')", "Estado", Connect)
    End Sub
    Public Overrides Sub SetCombos()
        MyBase.SetCombos()
        dcGral.setCombo(cmbTipo, dsGral.Tables("TipoEvaluaCab"), "Nombre", "TipoEvaluaCabID", -1)
        dcGral.setCombo(cmbEstado, dsGral.Tables("Estado"), "Nombre", "Codigo", 0)
    End Sub
    Public Overrides Sub DetailRow()
        MyBase.DetailRow()
        If dsGral.Tables(0).Rows.Count = 0 Then
            dsGral.Tables(0).Rows.Add()
        Else
            txtCodigo.Text = dsGral.Tables(0).Rows(0)("Codigo")

            txtNombre.Text = dsGral.Tables(0).Rows(0)("Nombre")
            cmbTipo.SelectedValue = dsGral.Tables(0).Rows(0)("TipoEvaluaCabID")
            txtDescripcion.Text = dsGral.Tables(0).Rows(0)("Descripcion")
            cmbEstado.SelectedValue = dsGral.Tables(0).Rows(0)("codEstado")
        End If
    End Sub
    Private Sub frmTipoEvaluaDetDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtDescripcion_TextChanged(sender As Object, e As EventArgs) Handles txtDescripcion.TextChanged
        Dim caracteresIngresados As Integer = txtDescripcion.Text.Length
        Dim maximo As Integer = txtDescripcion.MaxLength

        lblChar.Text = $"{caracteresIngresados}/{maximo}"
    End Sub

    Private Sub lLabelTipo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lLabelTipo.LinkClicked
        Try
            Dim frm As New frmTipoEvaluaList()
            frm.Connect = Connect
            frm.ShowDialog()

            dsGral.Tables("TipoEvaluaCab").Clear()
            dsGral.Tables("TipoEvaluaCab").Merge(dcGral.getDataTable("select *from TipoEvaluaCab", Connect))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click

        Try
            Err.Clean()
            If txtNombre.Text.Length < 2 Then Err.AddError("Ingrese un nombre válido", 0)
            If cmbTipo.SelectedIndex = -1 Or cmbTipo.SelectedItem Is Nothing Then Err.AddError("Seleccione un tipo de evaluación", 0)
            If txtDescripcion.Text.Length < 3 Then Err.AddError("Ingrese una descripción", 0)

            If Err.Errors Then
                Err.ShowDialog()
                Exit Sub
            End If


            dsGral.Tables(0).Rows(0)("Codigo") = txtCodigo.Text
            dsGral.Tables(0).Rows(0)("Nombre") = txtNombre.Text
            dsGral.Tables(0).Rows(0)("TipoEvaluaCabID") = cmbTipo.SelectedValue
            dsGral.Tables(0).Rows(0)("Descripcion") = txtDescripcion.Text
            dsGral.Tables(0).Rows(0)("Estado") = cmbEstado.SelectedValue
            UpdateTables(0)

            'If Adding Then newRecord(0)
            Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub
End Class
