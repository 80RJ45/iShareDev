Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class frmEmpleadoFilter
    Public isOK As Boolean
    Public resTab As DataTable
    Public existentes As DataTable
    Public Sub New(cnx As dcLibrary.dcConnect, parents As dcLibrary.dcParentList, DetailID As Integer, tab As DataTable)
        MyBase.New(cnx, parents, DetailID)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        LoadDinamicTables()
        existentes = tab

        If existentes.Columns.Contains("EmpleadoID") Then
            existentes.PrimaryKey = New DataColumn() {existentes.Columns("EmpleadoID")}
        End If

    End Sub
    Public Overrides Sub LoadTables()
        MyBase.LoadTables()
        Dim tab As New DataTable()
        tab = dcGral.getDataTable("select DepartamentoID, Nombre from Departamento union select 0,'Todos' order by 1 desc", Connect)
        dsGral.Tables.Add(dcGral.getDataTable("select SitioID,Nombre from Sitio
                union select 0,'Todos' order by 1 desc", Connect))
        setName("Sitio")
        dsGral.Tables.Add(dcGral.getDataTable("select DepartamentoID, Nombre from Departamento
                union select 0,'Todos' order by 1 desc", Connect))
        setName("Departamento")
        dsGral.Tables.Add(dcGral.getDataTable("select PuestoID, Nombre from Puesto
                union select 0,'Todos' order by 1 desc", Connect))
        setName("Puesto")
        dsGral.Tables.Add(dcGral.getDataTable("select ProfesionID, Nombre from Profesion
                union select 0,'Todos' order by 1 desc", Connect))
        setName("Profesion")
        dsGral.Tables.Add(dcGral.getDataTable("select HorarioCabID, Nombre from HorarioCab
                union select 0, 'Todos' order by 1 desc", Connect))
        setName("Horario")
    End Sub
    Public Overrides Sub SetCombos()
        MyBase.SetCombos()
        dcGral.setCombo(cmbSitio, dsGral.Tables("Sitio"), "Nombre", "SitioID", dsGral.Tables("Sitio").Rows.Count - 1)
        dcGral.setCombo(cmbDepartamento, dsGral.Tables("Departamento"), "Nombre", "DepartamentoID", dsGral.Tables("Departamento").Rows.Count - 1)
        dcGral.setCombo(cmbPuesto, dsGral.Tables("Puesto"), "Nombre", "PuestoID", dsGral.Tables("Puesto").Rows.Count - 1)
        dcGral.setCombo(cmbProfesion, dsGral.Tables("Profesion"), "Nombre", "ProfesionID", dsGral.Tables("Profesion").Rows.Count - 1)
        dcGral.setCombo(cmbHorario, dsGral.Tables("Horario"), "Nombre", "HorarioCabID", dsGral.Tables("Horario").Rows.Count - 1)
    End Sub
    Private Sub setName(name As String)
        dsGral.Tables(dsGral.Tables.Count - 1).TableName = name
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.isOK = False
        Close()
    End Sub

    Private Sub frmEmpleadoFilter_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Err.Clean()

        Dim sitioID, departamentoID, puestoID, profesionID, horarioID As Integer
        sitioID = cmbSitio.SelectedValue
        departamentoID = cmbDepartamento.SelectedValue
        puestoID = cmbPuesto.SelectedValue
        profesionID = cmbProfesion.SelectedValue
        horarioID = cmbHorario.SelectedValue
        resTab = New DataTable()
        resTab.PrimaryKey = New DataColumn() {resTab.Columns("EmpleadoID")}
        Dim query As String = "exec spEmpleadoCapacitaSelect @sitioID = " & sitioID & ",@departamentoID =" & departamentoID & ",@PuestoID =" & puestoID & ",@ProfesionID = " & profesionID & ",@HorarioCabID = " & horarioID & ",@codigo = ''"

        resTab = dcGral.getDataTable(query, Connect)


        If resTab.Rows.Count > 0 Then
            Dim ag = mergeTables(existentes, resTab)
            If ag > 0 Then
                isOK = True
                Close()
            Else
                MsgBox("Los empleados ya han sido agregados", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If
        Else
            MsgBox("No se encontraron empleados", vbMsgBoxHelp, "Información")
            Exit Sub
        End If
    End Sub
    Private Function mergeTables(tabOrigen As DataTable, tabAgregar As DataTable) As Integer
        Dim agregados As Integer = 0
        For Each rowAgregar As DataRow In tabAgregar.Rows
            ' Buscar si ya existe en el origen codEmpleado
            Dim encontrado() As DataRow = tabOrigen.Select("codEmpleado = '" & rowAgregar("codEmpleado").ToString().Replace("'", "''") & "'")

            If encontrado.Length = 0 Then
                ' Crear nueva fila
                Dim nuevaFila As DataRow = tabOrigen.NewRow()

                ' Asignar valores columna por columna
                nuevaFila("CapacitaDetID") = rowAgregar("CapacitaDetID")
                nuevaFila("CapacitaCabID") = rowAgregar("CapacitaCabID")
                nuevaFila("EmpleadoID") = rowAgregar("EmpleadoID")
                nuevaFila("codEmpleado") = rowAgregar("codEmpleado")
                nuevaFila("Empleado") = rowAgregar("Empleado")
                nuevaFila("Identidad") = rowAgregar("Identidad")
                nuevaFila("Puesto") = rowAgregar("Puesto")
                nuevaFila("Horario") = rowAgregar("Horario")

                ' Agregar al origen
                tabOrigen.Rows.Add(nuevaFila)
                agregados = agregados + 1
            End If
        Next
        Return agregados
    End Function
End Class

