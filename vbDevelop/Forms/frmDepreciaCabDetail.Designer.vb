<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDepreciaCabDetail
    Inherits dcLibrary.dcDetail

    'Form invalida a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtActivo = New System.Windows.Forms.TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.txtTipoActivo = New System.Windows.Forms.TextBox()
        Me.txtTipoDep = New System.Windows.Forms.TextBox()
        Me.dtFechaCompra = New System.Windows.Forms.DateTimePicker()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.lblEstado = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Fecha:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Tipo Activo:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(322, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Tipo depreciación: "
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(25, 152)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(543, 179)
        Me.DataGridView1.TabIndex = 7
        '
        'txtActivo
        '
        Me.txtActivo.Location = New System.Drawing.Point(95, 26)
        Me.txtActivo.Name = "txtActivo"
        Me.txtActivo.ReadOnly = True
        Me.txtActivo.Size = New System.Drawing.Size(473, 20)
        Me.txtActivo.TabIndex = 8
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(22, 29)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(40, 13)
        Me.LinkLabel1.TabIndex = 9
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Activo:"
        '
        'txtTipoActivo
        '
        Me.txtTipoActivo.Location = New System.Drawing.Point(95, 60)
        Me.txtTipoActivo.Name = "txtTipoActivo"
        Me.txtTipoActivo.ReadOnly = True
        Me.txtTipoActivo.Size = New System.Drawing.Size(151, 20)
        Me.txtTipoActivo.TabIndex = 10
        '
        'txtTipoDep
        '
        Me.txtTipoDep.Location = New System.Drawing.Point(426, 60)
        Me.txtTipoDep.Name = "txtTipoDep"
        Me.txtTipoDep.ReadOnly = True
        Me.txtTipoDep.Size = New System.Drawing.Size(142, 20)
        Me.txtTipoDep.TabIndex = 11
        '
        'dtFechaCompra
        '
        Me.dtFechaCompra.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaCompra.Location = New System.Drawing.Point(95, 97)
        Me.dtFechaCompra.Name = "dtFechaCompra"
        Me.dtFechaCompra.Size = New System.Drawing.Size(142, 20)
        Me.dtFechaCompra.TabIndex = 25
        '
        'btnSalvar
        '
        Me.btnSalvar.Location = New System.Drawing.Point(209, 337)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(178, 51)
        Me.btnSalvar.TabIndex = 28
        Me.btnSalvar.Text = "Salvar"
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(393, 337)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(175, 51)
        Me.btnCancelar.TabIndex = 29
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(25, 337)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(178, 51)
        Me.btnProcesar.TabIndex = 30
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.Location = New System.Drawing.Point(481, 103)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(11, 13)
        Me.lblEstado.TabIndex = 31
        Me.lblEstado.Text = "."
        '
        'frmDepreciaCabDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(594, 400)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.dtFechaCompra)
        Me.Controls.Add(Me.txtTipoDep)
        Me.Controls.Add(Me.txtTipoActivo)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.txtActivo)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Name = "frmDepreciaCabDetail"
        Me.Text = "Depreciación de activos"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents DataGridView1 As Windows.Forms.DataGridView
    Friend WithEvents txtActivo As Windows.Forms.TextBox
    Friend WithEvents LinkLabel1 As Windows.Forms.LinkLabel
    Friend WithEvents txtTipoActivo As Windows.Forms.TextBox
    Friend WithEvents txtTipoDep As Windows.Forms.TextBox
    Friend WithEvents dtFechaCompra As Windows.Forms.DateTimePicker
    Friend WithEvents btnSalvar As Windows.Forms.Button
    Friend WithEvents btnCancelar As Windows.Forms.Button
    Friend WithEvents btnProcesar As Windows.Forms.Button
    Friend WithEvents lblEstado As Windows.Forms.Label
End Class
