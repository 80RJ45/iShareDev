Imports System.Windows.Forms

Public Class frmFincaDet
    Public Sub New(cnx As dcLibrary.dcConnect, parents As dcLibrary.dcParentList, DetailID As Integer)
        MyBase.New(cnx, parents, DetailID)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        newDinamicTable(cnx, 0, "Finca", "@FincaID", "@FincaID", DetailID, ParameterDirection.InputOutput, -1)
        newDinamicTable(cnx, 1, "Lote", "@FincaID", "@FincaID", DetailID, ParameterDirection.Input, 0)
        LoadDinamicTables()
    End Sub
    Public Overrides Sub SetGrids()
        MyBase.SetGrids()
        dcGral.initGrid(DataGridView1, dsGral.Tables("Lote"), True, True, "FincaID,LoteID", True, True, Connect, DataGridViewContentAlignment.MiddleCenter, False)
    End Sub
    Public Overrides Sub DetailRow()
        MyBase.DetailRow()
        If dsGral.Tables("Finca").Rows.Count = 0 Then
            'Modalidad de adición
            dsGral.Tables("Finca").Rows.Add()
        Else
            txtCodigo.Text = dsGral.Tables("Finca").Rows(0).Item("Codigo")
            txtNombre.Text = dsGral.Tables("Finca").Rows(0).Item("Nombre")

        End If
    End Sub
    Private Sub frmFincaDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Try
            Err.Clean()
            If txtCodigo.Text.Length = 0 Then Err.AddError("Falta el Codigo de la finca", 0)
            If txtNombre.Text.Length = 0 Then Err.AddError("Falata el Nombre de la finca", 0)
            If dsGral.Tables("Lote").DefaultView.Count = 0 Then Err.AddError("La finca debe tener lote", 0)

            If Err.Errors Then
                Err.ShowDialog()
                Exit Sub 'para finalizar'
            End If

            dsGral.Tables("Finca").Rows(0)("Codigo") = txtCodigo.Text
            dsGral.Tables("Finca").Rows(0)("Nombre") = txtNombre.Text

            'Actualizar tablas
            UpdateTables(0)

            If Adding Then newRecord(0)
            Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
