<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmActivoDetail
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbTipoDep = New System.Windows.Forms.ComboBox()
        Me.txtTipoActivo = New System.Windows.Forms.TextBox()
        Me.txtArticulo = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.dgvCompraDet = New System.Windows.Forms.DataGridView()
        Me.dgvActivoCompra = New System.Windows.Forms.DataGridView()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        CType(Me.dgvCompraDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvActivoCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(538, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Tipo Depósito: "
        '
        'cmbTipoDep
        '
        Me.cmbTipoDep.FormattingEnabled = True
        Me.cmbTipoDep.Location = New System.Drawing.Point(623, 100)
        Me.cmbTipoDep.Name = "cmbTipoDep"
        Me.cmbTipoDep.Size = New System.Drawing.Size(121, 21)
        Me.cmbTipoDep.TabIndex = 4
        '
        'txtTipoActivo
        '
        Me.txtTipoActivo.Location = New System.Drawing.Point(91, 96)
        Me.txtTipoActivo.Name = "txtTipoActivo"
        Me.txtTipoActivo.Size = New System.Drawing.Size(420, 20)
        Me.txtTipoActivo.TabIndex = 5
        '
        'txtArticulo
        '
        Me.txtArticulo.Location = New System.Drawing.Point(91, 62)
        Me.txtArticulo.Name = "txtArticulo"
        Me.txtArticulo.Size = New System.Drawing.Size(420, 20)
        Me.txtArticulo.TabIndex = 6
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(91, 28)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(109, 20)
        Me.txtCodigo.TabIndex = 7
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.Location = New System.Drawing.Point(35, 65)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(50, 13)
        Me.LinkLabel1.TabIndex = 8
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Artículo: "
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel2.Location = New System.Drawing.Point(21, 99)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(64, 13)
        Me.LinkLabel2.TabIndex = 9
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Tipo Activo:"
        '
        'dgvCompraDet
        '
        Me.dgvCompraDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCompraDet.Location = New System.Drawing.Point(24, 237)
        Me.dgvCompraDet.Name = "dgvCompraDet"
        Me.dgvCompraDet.Size = New System.Drawing.Size(730, 150)
        Me.dgvCompraDet.TabIndex = 10
        '
        'dgvActivoCompra
        '
        Me.dgvActivoCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvActivoCompra.Location = New System.Drawing.Point(24, 139)
        Me.dgvActivoCompra.Name = "dgvActivoCompra"
        Me.dgvActivoCompra.Size = New System.Drawing.Size(487, 78)
        Me.dgvActivoCompra.TabIndex = 11
        '
        'btnSalvar
        '
        Me.btnSalvar.Location = New System.Drawing.Point(24, 393)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(364, 63)
        Me.btnSalvar.TabIndex = 16
        Me.btnSalvar.Text = "Salvar"
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(390, 393)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(364, 63)
        Me.btnCancelar.TabIndex = 15
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmActivoDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(766, 463)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.dgvActivoCompra)
        Me.Controls.Add(Me.dgvCompraDet)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.txtArticulo)
        Me.Controls.Add(Me.txtTipoActivo)
        Me.Controls.Add(Me.cmbTipoDep)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmActivoDetail"
        Me.Text = "Activos"
        CType(Me.dgvCompraDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvActivoCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents cmbTipoDep As Windows.Forms.ComboBox
    Friend WithEvents txtTipoActivo As Windows.Forms.TextBox
    Friend WithEvents txtArticulo As Windows.Forms.TextBox
    Friend WithEvents txtCodigo As Windows.Forms.TextBox
    Friend WithEvents LinkLabel1 As Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As Windows.Forms.LinkLabel
    Friend WithEvents dgvCompraDet As Windows.Forms.DataGridView
    Friend WithEvents dgvActivoCompra As Windows.Forms.DataGridView
    Friend WithEvents btnSalvar As Windows.Forms.Button
    Friend WithEvents btnCancelar As Windows.Forms.Button
End Class
