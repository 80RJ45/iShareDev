Imports System.Data.SqlClient
Public Class frmTipoEvaluaList
    Public Overrides Sub Init()
        MyBase.Init()
        Dim adp = New SqlDataAdapter
        Dim SQLGridParm = New SqlParameter("@TipoEvaluaCabID", 0)

        

        adp.SelectCommand = dcGral.getSQLCommand(Connect, "spTipoEvaluaCabSelect", SQLGridParm)
        adp.DeleteCommand = dcGral.getSQLCommand(Connect, "spTipoEvaluaCabDelete")
        adp.InsertCommand = dcGral.getSQLCommand(Connect, "spTipoEvaluaCabInsert")
        adp.UpdateCommand = dcGral.getSQLCommand(Connect, "spTipoEvaluaCabUpdate")

        Adaptador = adp

    End Sub

    Private Sub frmTipoEvaluaList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
