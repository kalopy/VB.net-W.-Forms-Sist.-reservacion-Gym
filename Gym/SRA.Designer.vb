<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SRA
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.cmbLocal = New System.Windows.Forms.ComboBox()
        Me.cmbModalidad = New System.Windows.Forms.ComboBox()
        Me.lblLocal = New System.Windows.Forms.Label()
        Me.lblModalidad = New System.Windows.Forms.Label()
        Me.txtDocumento = New System.Windows.Forms.TextBox()
        Me.lblDocumento = New System.Windows.Forms.Label()
        Me.cmbHorario = New System.Windows.Forms.ComboBox()
        Me.lblHorario = New System.Windows.Forms.Label()
        Me.btnVerificarCupo = New System.Windows.Forms.Button()
        Me.lblNombreEstado = New System.Windows.Forms.Label()
        Me.btnConfirmar = New System.Windows.Forms.Button()
        Me.dtFechaAsistencia = New System.Windows.Forms.DateTimePicker()
        Me.lblCupos = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblAlumnoEstado = New System.Windows.Forms.Label()
        Me.lblDisponible = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmbLocal
        '
        Me.cmbLocal.FormattingEnabled = True
        Me.cmbLocal.Location = New System.Drawing.Point(208, 98)
        Me.cmbLocal.Name = "cmbLocal"
        Me.cmbLocal.Size = New System.Drawing.Size(153, 21)
        Me.cmbLocal.TabIndex = 0
        '
        'cmbModalidad
        '
        Me.cmbModalidad.FormattingEnabled = True
        Me.cmbModalidad.Location = New System.Drawing.Point(208, 149)
        Me.cmbModalidad.Name = "cmbModalidad"
        Me.cmbModalidad.Size = New System.Drawing.Size(153, 21)
        Me.cmbModalidad.TabIndex = 1
        '
        'lblLocal
        '
        Me.lblLocal.AutoSize = True
        Me.lblLocal.Location = New System.Drawing.Point(100, 106)
        Me.lblLocal.Name = "lblLocal"
        Me.lblLocal.Size = New System.Drawing.Size(33, 13)
        Me.lblLocal.TabIndex = 2
        Me.lblLocal.Text = "Local"
        '
        'lblModalidad
        '
        Me.lblModalidad.AutoSize = True
        Me.lblModalidad.Location = New System.Drawing.Point(100, 152)
        Me.lblModalidad.Name = "lblModalidad"
        Me.lblModalidad.Size = New System.Drawing.Size(56, 13)
        Me.lblModalidad.TabIndex = 3
        Me.lblModalidad.Text = "Modalidad"
        '
        'txtDocumento
        '
        Me.txtDocumento.Location = New System.Drawing.Point(208, 12)
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.Size = New System.Drawing.Size(200, 20)
        Me.txtDocumento.TabIndex = 4
        '
        'lblDocumento
        '
        Me.lblDocumento.AutoSize = True
        Me.lblDocumento.Location = New System.Drawing.Point(100, 15)
        Me.lblDocumento.Name = "lblDocumento"
        Me.lblDocumento.Size = New System.Drawing.Size(85, 13)
        Me.lblDocumento.TabIndex = 5
        Me.lblDocumento.Text = "Nro. Documento"
        '
        'cmbHorario
        '
        Me.cmbHorario.FormattingEnabled = True
        Me.cmbHorario.Location = New System.Drawing.Point(208, 202)
        Me.cmbHorario.Name = "cmbHorario"
        Me.cmbHorario.Size = New System.Drawing.Size(153, 21)
        Me.cmbHorario.TabIndex = 9
        '
        'lblHorario
        '
        Me.lblHorario.AutoSize = True
        Me.lblHorario.Location = New System.Drawing.Point(100, 210)
        Me.lblHorario.Name = "lblHorario"
        Me.lblHorario.Size = New System.Drawing.Size(41, 13)
        Me.lblHorario.TabIndex = 10
        Me.lblHorario.Text = "Horario"
        '
        'btnVerificarCupo
        '
        Me.btnVerificarCupo.Location = New System.Drawing.Point(208, 243)
        Me.btnVerificarCupo.Name = "btnVerificarCupo"
        Me.btnVerificarCupo.Size = New System.Drawing.Size(87, 30)
        Me.btnVerificarCupo.TabIndex = 11
        Me.btnVerificarCupo.Text = "Verificar Cupo"
        Me.btnVerificarCupo.UseVisualStyleBackColor = True
        '
        'lblNombreEstado
        '
        Me.lblNombreEstado.AutoSize = True
        Me.lblNombreEstado.Location = New System.Drawing.Point(205, 45)
        Me.lblNombreEstado.Name = "lblNombreEstado"
        Me.lblNombreEstado.Size = New System.Drawing.Size(0, 13)
        Me.lblNombreEstado.TabIndex = 13
        '
        'btnConfirmar
        '
        Me.btnConfirmar.Location = New System.Drawing.Point(238, 317)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(89, 34)
        Me.btnConfirmar.TabIndex = 14
        Me.btnConfirmar.Text = "Confirmar"
        Me.btnConfirmar.UseVisualStyleBackColor = True
        '
        'dtFechaAsistencia
        '
        Me.dtFechaAsistencia.Location = New System.Drawing.Point(208, 60)
        Me.dtFechaAsistencia.Name = "dtFechaAsistencia"
        Me.dtFechaAsistencia.Size = New System.Drawing.Size(200, 20)
        Me.dtFechaAsistencia.TabIndex = 15
        '
        'lblCupos
        '
        Me.lblCupos.AutoSize = True
        Me.lblCupos.Location = New System.Drawing.Point(244, 301)
        Me.lblCupos.Name = "lblCupos"
        Me.lblCupos.Size = New System.Drawing.Size(0, 13)
        Me.lblCupos.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(100, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Fecha de asistencia"
        '
        'lblAlumnoEstado
        '
        Me.lblAlumnoEstado.AutoSize = True
        Me.lblAlumnoEstado.Location = New System.Drawing.Point(208, 41)
        Me.lblAlumnoEstado.Name = "lblAlumnoEstado"
        Me.lblAlumnoEstado.Size = New System.Drawing.Size(77, 13)
        Me.lblAlumnoEstado.TabIndex = 18
        Me.lblAlumnoEstado.Text = "Nombre&Estado"
        '
        'lblDisponible
        '
        Me.lblDisponible.AutoSize = True
        Me.lblDisponible.Location = New System.Drawing.Point(322, 252)
        Me.lblDisponible.Name = "lblDisponible"
        Me.lblDisponible.Size = New System.Drawing.Size(56, 13)
        Me.lblDisponible.TabIndex = 19
        Me.lblDisponible.Text = "Disponible"
        '
        'SRA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(502, 409)
        Me.Controls.Add(Me.lblDisponible)
        Me.Controls.Add(Me.lblAlumnoEstado)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblCupos)
        Me.Controls.Add(Me.dtFechaAsistencia)
        Me.Controls.Add(Me.btnConfirmar)
        Me.Controls.Add(Me.lblNombreEstado)
        Me.Controls.Add(Me.btnVerificarCupo)
        Me.Controls.Add(Me.lblHorario)
        Me.Controls.Add(Me.cmbHorario)
        Me.Controls.Add(Me.lblDocumento)
        Me.Controls.Add(Me.txtDocumento)
        Me.Controls.Add(Me.lblModalidad)
        Me.Controls.Add(Me.lblLocal)
        Me.Controls.Add(Me.cmbModalidad)
        Me.Controls.Add(Me.cmbLocal)
        Me.Name = "SRA"
        Me.Text = "Sistema de Reserva de Asistencia"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbLocal As ComboBox
    Friend WithEvents cmbModalidad As ComboBox
    Friend WithEvents lblLocal As Label
    Friend WithEvents lblModalidad As Label
    Friend WithEvents txtDocumento As TextBox
    Friend WithEvents lblDocumento As Label
    Friend WithEvents cmbHorario As ComboBox
    Friend WithEvents lblHorario As Label
    Friend WithEvents txtprueba As TextBox
    Friend WithEvents btnVerificarCupo As Button
    Friend WithEvents lblNombreEstado As Label
    Friend WithEvents btnConfirmar As Button
    Friend WithEvents dtFechaAsistencia As DateTimePicker
    Friend WithEvents lblCupos As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblAlumnoEstado As Label
    Friend WithEvents lblDisponible As Label
End Class
