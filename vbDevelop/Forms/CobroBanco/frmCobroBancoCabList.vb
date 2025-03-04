Imports System.Data.SqlClient
Public Class frmCobroBancoCabList

    Public Overrides Sub Init()
        SQLGridParm = New SqlParameter("@CobroBancoCabID", 0)

        Dim adp As New SqlDataAdapter With {
            .SelectCommand = dcGral.getSQLCommand(Connect, "spCobroBancoCabSelect", SQLGridParm)
        }

        Adaptador = adp
        Detalle = True

        MyBase.Init()
    End Sub

    Public Overrides Sub Adicionar()
        '"spTipoSelect 'CobroBancoCab'", "Tipo"
        Dim frm = New frmCobroBancoDetail(Connect, Me, -1)
        frm.ShowDialog()
        MyBase.Adicionar()
    End Sub
    Public Overrides Sub Modificar()
        MyBase.Modificar()
        Dim frm = New frmCobroBancoDetail(Connect, Me, getID("CobroBancoCabID"))
        frm.ShowDialog()
        reloadRow(RowIndex, "CobroBancoCabID")
    End Sub
    Private Sub frmCobroBancoCabList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
