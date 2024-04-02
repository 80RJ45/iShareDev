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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.dtFechaCompra = New System.Windows.Forms.DateTimePicker()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(121, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(435, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Tipo Depreciación"
        '
        'cmbTipoDep
        '
        Me.cmbTipoDep.FormattingEnabled = True
        Me.cmbTipoDep.Location = New System.Drawing.Point(538, 127)
        Me.cmbTipoDep.Name = "cmbTipoDep"
        Me.cmbTipoDep.Size = New System.Drawing.Size(183, 21)
        Me.cmbTipoDep.TabIndex = 4
        '
        'txtArticulo
        '
        Me.txtArticulo.Location = New System.Drawing.Point(170, 59)
        Me.txtArticulo.Name = "txtArticulo"
        Me.txtArticulo.ReadOnly = True
        Me.txtArticulo.Size = New System.Drawing.Size(551, 20)
        Me.txtArticulo.TabIndex = 6
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(170, 25)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(121, 20)
        Me.txtCodigo.TabIndex = 7
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.Location = New System.Drawing.Point(117, 63)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(44, 13)
        Me.LinkLabel1.TabIndex = 8
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Artículo"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel2.Location = New System.Drawing.Point(468, 97)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(61, 13)
        Me.LinkLabel2.TabIndex = 9
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Tipo Activo"
        '
        'dgvDetalle
        '
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Location = New System.Drawing.Point(12, 266)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(279, 150)
        Me.dgvDetalle.TabIndex = 10
        '
        'btnSalvar
        '
        Me.btnSalvar.Location = New System.Drawing.Point(12, 422)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(388, 63)
        Me.btnSalvar.TabIndex = 16
        Me.btnSalvar.Text = "Salvar"
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(399, 422)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(388, 63)
        Me.btnCancelar.TabIndex = 15
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel3.Location = New System.Drawing.Point(118, 199)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(43, 13)
        Me.LinkLabel3.TabIndex = 17
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Compra"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(170, 161)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(551, 20)
        Me.TextBox1.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(351, 199)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Fecha"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(564, 199)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Vida"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(600, 195)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(121, 20)
        Me.TextBox3.TabIndex = 23
        '
        'dtFechaCompra
        '
        Me.dtFechaCompra.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaCompra.Location = New System.Drawing.Point(395, 195)
        Me.dtFechaCompra.Name = "dtFechaCompra"
        Me.dtFechaCompra.Size = New System.Drawing.Size(112, 20)
        Me.dtFechaCompra.TabIndex = 24
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(297, 266)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(487, 150)
        Me.DataGridView1.TabIndex = 25
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(170, 195)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(121, 20)
        Me.TextBox2.TabIndex = 26
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(392, 229)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(121, 20)
        Me.TextBox4.TabIndex = 28
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(305, 233)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Dep.Acumulada"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(538, 93)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(183, 21)
        Me.ComboBox1.TabIndex = 29
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(170, 93)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(230, 20)
        Me.TextBox5.TabIndex = 30
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(124, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Marca"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(86, 163)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(75, 17)
        Me.CheckBox1.TabIndex = 32
        Me.CheckBox1.Text = "Proveedor"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(122, 131)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Familia"
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(170, 127)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(230, 20)
        Me.TextBox6.TabIndex = 33
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(600, 229)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(121, 20)
        Me.TextBox7.TabIndex = 36
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(530, 233)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Valor Libros"
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(170, 229)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(121, 20)
        Me.TextBox8.TabIndex = 38
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(124, 233)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "Precio"
        '
        'frmActivoDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(796, 495)
        Me.Controls.Add(Me.TextBox8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.dtFechaCompra)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label5)
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
        Me.Controls.Add(Me.cmbTipoDep)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmActivoDetail"
        Me.Text = "Activos Fijos"
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents cmbTipoDep As Windows.Forms.ComboBox
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
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents TextBox3 As Windows.Forms.TextBox
    Friend WithEvents dtFechaCompra As Windows.Forms.DateTimePicker
    Friend WithEvents DataGridView1 As Windows.Forms.DataGridView
    Friend WithEvents TextBox2 As Windows.Forms.TextBox
    Friend WithEvents TextBox4 As Windows.Forms.TextBox
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents ComboBox1 As Windows.Forms.ComboBox
    Friend WithEvents TextBox5 As Windows.Forms.TextBox
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents CheckBox1 As Windows.Forms.CheckBox
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents TextBox6 As Windows.Forms.TextBox
    Friend WithEvents TextBox7 As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents TextBox8 As Windows.Forms.TextBox
    Friend WithEvents Label9 As Windows.Forms.Label
End Class
