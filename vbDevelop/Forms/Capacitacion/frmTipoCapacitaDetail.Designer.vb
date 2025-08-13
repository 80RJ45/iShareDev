<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTipoCapacitaDetail
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
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.cmbTipoCompetencia = New System.Windows.Forms.ComboBox()
        Me.dgvCompetencia = New System.Windows.Forms.DataGridView()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTiempo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.dgvCompetencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSalvar
        '
        Me.btnSalvar.Location = New System.Drawing.Point(43, 286)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(261, 46)
        Me.btnSalvar.TabIndex = 0
        Me.btnSalvar.Text = "Salvar"
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(306, 286)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(261, 46)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Código:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nombre: "
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(100, 33)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(99, 20)
        Me.txtCodigo.TabIndex = 1
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(100, 69)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(467, 20)
        Me.txtNombre.TabIndex = 2
        '
        'cmbTipoCompetencia
        '
        Me.cmbTipoCompetencia.FormattingEnabled = True
        Me.cmbTipoCompetencia.Location = New System.Drawing.Point(311, 105)
        Me.cmbTipoCompetencia.Name = "cmbTipoCompetencia"
        Me.cmbTipoCompetencia.Size = New System.Drawing.Size(256, 21)
        Me.cmbTipoCompetencia.TabIndex = 3
        '
        'dgvCompetencia
        '
        Me.dgvCompetencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCompetencia.Location = New System.Drawing.Point(311, 132)
        Me.dgvCompetencia.Name = "dgvCompetencia"
        Me.dgvCompetencia.Size = New System.Drawing.Size(256, 146)
        Me.dgvCompetencia.TabIndex = 7
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(134, 143)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox1.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox1.TabIndex = 8
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(41, 218)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Tiempo:"
        '
        'txtTiempo
        '
        Me.txtTiempo.Enabled = False
        Me.txtTiempo.Location = New System.Drawing.Point(96, 215)
        Me.txtTiempo.Name = "txtTiempo"
        Me.txtTiempo.Size = New System.Drawing.Size(144, 20)
        Me.txtTiempo.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(44, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Periodo:"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Enabled = False
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(96, 173)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(144, 21)
        Me.cmbTipo.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(155, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Vence: "
        '
        'frmTipoCapacitaDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(612, 345)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbTipo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtTiempo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.dgvCompetencia)
        Me.Controls.Add(Me.cmbTipoCompetencia)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnSalvar)
        Me.Name = "frmTipoCapacitaDetail"
        Me.Padding = New System.Windows.Forms.Padding(15)
        Me.Text = "Tipo de Capacitación"
        CType(Me.dgvCompetencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSalvar As Windows.Forms.Button
    Friend WithEvents btnCancelar As Windows.Forms.Button
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents txtCodigo As Windows.Forms.TextBox
    Friend WithEvents txtNombre As Windows.Forms.TextBox
    Friend WithEvents cmbTipoCompetencia As Windows.Forms.ComboBox
    Friend WithEvents dgvCompetencia As Windows.Forms.DataGridView
    Friend WithEvents CheckBox1 As Windows.Forms.CheckBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents txtTiempo As Windows.Forms.TextBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents cmbTipo As Windows.Forms.ComboBox
    Friend WithEvents Label5 As Windows.Forms.Label
End Class
