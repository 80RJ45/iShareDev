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
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(56, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(535, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Tipo Depreciación:"
        '
        'cmbTipoDep
        '
        Me.cmbTipoDep.FormattingEnabled = True
        Me.cmbTipoDep.Location = New System.Drawing.Point(638, 97)
        Me.cmbTipoDep.Name = "cmbTipoDep"
        Me.cmbTipoDep.Size = New System.Drawing.Size(121, 21)
        Me.cmbTipoDep.TabIndex = 4
        '
        'txtTipoActivo
        '
        Me.txtTipoActivo.Location = New System.Drawing.Point(108, 97)
        Me.txtTipoActivo.Name = "txtTipoActivo"
        Me.txtTipoActivo.Size = New System.Drawing.Size(421, 20)
        Me.txtTipoActivo.TabIndex = 5
        '
        'txtArticulo
        '
        Me.txtArticulo.Location = New System.Drawing.Point(108, 63)
        Me.txtArticulo.Name = "txtArticulo"
        Me.txtArticulo.Size = New System.Drawing.Size(421, 20)
        Me.txtArticulo.TabIndex = 6
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(108, 29)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(110, 20)
        Me.txtCodigo.TabIndex = 7
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.Location = New System.Drawing.Point(52, 66)
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
        Me.LinkLabel2.Location = New System.Drawing.Point(38, 100)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(64, 13)
        Me.LinkLabel2.TabIndex = 9
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Tipo Activo:"
        '
        'dgvDetalle
        '
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Location = New System.Drawing.Point(12, 240)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(747, 150)
        Me.dgvDetalle.TabIndex = 10
        '
        'btnSalvar
        '
        Me.btnSalvar.Location = New System.Drawing.Point(12, 396)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(377, 63)
        Me.btnSalvar.TabIndex = 16
        Me.btnSalvar.Text = "Salvar"
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(395, 396)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(364, 63)
        Me.btnCancelar.TabIndex = 15
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel3.Location = New System.Drawing.Point(27, 142)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(75, 13)
        Me.LinkLabel3.TabIndex = 17
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Activo compra"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(111, 168)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(421, 20)
        Me.TextBox1.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(334, 202)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Fecha: "
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(383, 199)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(149, 20)
        Me.TextBox2.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(37, 171)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Proveeedor: "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(62, 202)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Precio: "
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(111, 199)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(164, 20)
        Me.TextBox3.TabIndex = 23
        '
        'frmActivoDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(771, 476)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.LinkLabel3)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.dgvDetalle)
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
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dgvDetalle As Windows.Forms.DataGridView
    Friend WithEvents btnSalvar As Windows.Forms.Button
    Friend WithEvents btnCancelar As Windows.Forms.Button
    Friend WithEvents LinkLabel3 As Windows.Forms.LinkLabel
    Friend WithEvents TextBox1 As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents TextBox2 As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents TextBox3 As Windows.Forms.TextBox
End Class
