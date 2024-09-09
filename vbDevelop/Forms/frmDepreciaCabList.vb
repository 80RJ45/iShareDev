Imports System.Data.SqlClient

Public Class frmDepreciaCabList
    Public Overrides Sub Init()
        SQLGridParm = New SqlParameter("@DepreciaCabID", 0)

        Dim adp = New SqlDataAdapter

        adp.SelectCommand = dcGral.getSQLCommand(Connect, "spDepreciaCabSelect", SQLGridParm)

        Adaptador = adp

        Detalle = True

        MyBase.Init()
    End Sub
    Public Overrides Sub Adicionar()
        Dim frm = New frmDepreciaCabDetail(Connect, Me, -1)
        frm.ShowDialog()
    End Sub
    Public Overrides Sub Modificar()
        Dim frm = New frmDepreciaCabDetail(Connect, Me, getID("DepreciaCabID"))
        frm.ShowDialog()
        reloadRow(RowIndex, "DepreciaCabID")
    End Sub
    Private Sub frmDepreciaCabList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initConextual()
        addOption("Generar", New EventHandler(AddressOf Generar))
        addOption("Procesar", New EventHandler(AddressOf Procesar))
        addOption("Asiento", New EventHandler(AddressOf verAsiento))
    End Sub
    Public Sub verAsiento()
        If Not IsDBNull(Table.DefaultView.Item(dg.CurrentRow.Index).Item("asientocabid")) Then
            Dim estado As String = Table.DefaultView.Item(dg.CurrentRow.Index).Item("estado")
            Dim fec As Date = Table.DefaultView.Item(dg.CurrentRow.Index).Item("Fecha") '***********
            Dim cerrado As Boolean = dcGral.getPeriodoDet(fec, "T", "A", Connect) = 0
            Dim modificar As Boolean = False

            Dim frm As New Contabilidad.frmAsientoDetail(Connect, Me, getID("asientocabid"), modificar, 0)
            frm.ShowDialog()
        End If
    End Sub
    Public Sub Generar()
        'Table.DefaultView.Item(dg.CurrentRow.Index).Item("asientocabid")

        Dim fila = Table.DefaultView.Item(dg.CurrentRow.Index)
        Dim fecha = DateValue(fila.Item("Fecha").ToString())
        Dim tabActivoDep As DataTable = dcGral.getDataTable("exec spActivoDepSelect " + getID("DepreciaCabID").ToString(), Connect)

        If fila.Item("Estado").ToString() = "P" Or fila.Item("Estado") = "Procesado" Then
            MsgBox("La depreciación ya ha sido procesada", MsgBoxStyle.Critical, "Error")
            Return
        End If

        If tabActivoDep.Rows.Count > 0 Then
            MsgBox("Ya se ha generado la depreciación de los Activos", MsgBoxStyle.Information, "Información")
            Return
        End If



        Try
            Dim cadena As String = "exec spActivoDepGenera " + getID("DepreciaCabID").ToString() + ",'" + Format(fecha, Connect.DateFormat) + "'"
            dcGral.executeProcedure(cadena, Connect)

            reloadRow(RowIndex, "DepreciaCabID")
            MsgBox("Depreciaciones Generadas", MsgBoxStyle.Information, "Información")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Public Sub Procesar()
        Try
            Dim fila = Table.DefaultView.Item(dg.CurrentRow.Index)
            Dim fecha = DateValue(fila.Item("Fecha").ToString())
            Dim tabActivoDep As DataTable = dcGral.getDataTable("exec spActivoDepSelect " + getID("DepreciaCabID").ToString(), Connect)

            If dcGral.getPeriodoDet(Format(fecha, Connect.DateFormat), "I", "A", Connect) = -1 Then
                MsgBox("El periodo contable no está abierto", MsgBoxStyle.Critical, "Error")
                Return
            Else
                If fila.Item("Estado").ToString() = "P" Or fila.Item("Estado") = "Procesado" Then
                    MsgBox("La depreciación ya ha sido procesada", MsgBoxStyle.Critical, "Error")
                    Return
                End If
            End If
            If tabActivoDep.Rows.Count = 0 Then
                MsgBox("Debe generar primero las depreciaciones", MsgBoxStyle.Critical, "Error")
                Return
            End If


            Dim tabDeprecia As DataTable = dcGral.getDataTable("exec spAsientoDeprecia " & getID("DepreciaCabID"), Connect)
            Dim frm As New Contabilidad.frmAsientoDetail(Connect, tabDeprecia, "Depreciacion")
            frm.ShowDialog()

            If frm.AsientoID > 0 Then
                dcGral.executeProcedure("exec spDepreciaCabProceso " + fila.Item("DepreciaCabID").ToString() + ", " + frm.AsientoID.ToString(), Connect)
                reloadRow(RowIndex, "DepreciaCabID")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
