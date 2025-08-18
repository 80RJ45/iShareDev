<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmpleadoFilter
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbSitio = New System.Windows.Forms.ComboBox()
        Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
        Me.cmbPuesto = New System.Windows.Forms.ComboBox()
        Me.cmbProfesion = New System.Windows.Forms.ComboBox()
        Me.cmbHorario = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(74, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sitio"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Departamento"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(50, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Profesion"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(179, 219)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(167, 41)
        Me.btnCancelar.TabIndex = 21
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(21, 219)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(152, 41)
        Me.btnAceptar.TabIndex = 22
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(61, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Puesto"
        '
        'cmbSitio
        '
        Me.cmbSitio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSitio.FormattingEnabled = True
        Me.cmbSitio.Location = New System.Drawing.Point(107, 35)
        Me.cmbSitio.Name = "cmbSitio"
        Me.cmbSitio.Size = New System.Drawing.Size(211, 21)
        Me.cmbSitio.TabIndex = 24
        '
        'cmbDepartamento
        '
        Me.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartamento.FormattingEnabled = True
        Me.cmbDepartamento.Location = New System.Drawing.Point(107, 69)
        Me.cmbDepartamento.Name = "cmbDepartamento"
        Me.cmbDepartamento.Size = New System.Drawing.Size(211, 21)
        Me.cmbDepartamento.TabIndex = 25
        '
        'cmbPuesto
        '
        Me.cmbPuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPuesto.FormattingEnabled = True
        Me.cmbPuesto.Location = New System.Drawing.Point(107, 103)
        Me.cmbPuesto.Name = "cmbPuesto"
        Me.cmbPuesto.Size = New System.Drawing.Size(211, 21)
        Me.cmbPuesto.TabIndex = 26
        '
        'cmbProfesion
        '
        Me.cmbProfesion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProfesion.FormattingEnabled = True
        Me.cmbProfesion.Location = New System.Drawing.Point(107, 137)
        Me.cmbProfesion.Name = "cmbProfesion"
        Me.cmbProfesion.Size = New System.Drawing.Size(211, 21)
        Me.cmbProfesion.TabIndex = 27
        '
        'cmbHorario
        '
        Me.cmbHorario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHorario.FormattingEnabled = True
        Me.cmbHorario.Location = New System.Drawing.Point(107, 173)
        Me.cmbHorario.Name = "cmbHorario"
        Me.cmbHorario.Size = New System.Drawing.Size(211, 21)
        Me.cmbHorario.TabIndex = 29
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(50, 176)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Horario"
        '
        'frmEmpleadoFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(382, 272)
        Me.Controls.Add(Me.cmbHorario)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbProfesion)
        Me.Controls.Add(Me.cmbPuesto)
        Me.Controls.Add(Me.cmbDepartamento)
        Me.Controls.Add(Me.cmbSitio)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmEmpleadoFilter"
        Me.Text = "Cargar Empleados"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents btnCancelar As Windows.Forms.Button
    Friend WithEvents btnAceptar As Windows.Forms.Button
    Friend WithEvents Label4 As Windows.Forms.Label
    Protected WithEvents cmbSitio As Windows.Forms.ComboBox
    Protected WithEvents cmbDepartamento As Windows.Forms.ComboBox
    Protected WithEvents cmbPuesto As Windows.Forms.ComboBox
    Protected WithEvents cmbProfesion As Windows.Forms.ComboBox
    Protected WithEvents cmbHorario As Windows.Forms.ComboBox
    Friend WithEvents Label5 As Windows.Forms.Label
End Class
