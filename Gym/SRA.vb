Imports System.Data.SqlClient

Public Class SRA
    Dim miConexion As New SqlConnection("data source = KALO; initial catalog = Gym; user id = kalo; password = kalo")
    Dim miComandoSQL As SqlCommand
    Dim instruccionSQL As String
    Dim dataReader As SqlDataReader

    Private Sub SRA_Load(sender As Object, e As EventArgs) Handles Me.Load

        CargarCmbLocal()
        CargarCmbModalidad()

    End Sub

    Sub CargarCmbLocal()
        instruccionSQL = "select * from local"
        miConexion.Open()
        miComandoSQL = New SqlCommand(instruccionSQL, miConexion)
        Dim adaptador As New SqlDataAdapter(miComandoSQL)
        Dim tabla As New DataTable
        adaptador.Fill(tabla)
        miConexion.Close()
        cmbLocal.DataSource = tabla
        cmbLocal.DisplayMember = "Nombre"
        cmbLocal.ValueMember = "LocalID"
    End Sub

    Sub CargarCmbModalidad()
        instruccionSQL = "select * from Modalidad"
        miConexion.Open()
        miComandoSQL = New SqlCommand(instruccionSQL, miConexion)
        Dim adaptador As New SqlDataAdapter(miComandoSQL)
        Dim tabla As New DataTable
        adaptador.Fill(tabla)
        miConexion.Close()
        cmbModalidad.DataSource = tabla
        cmbModalidad.DisplayMember = "Descripcion"
        cmbModalidad.ValueMember = "ModalidadID"
    End Sub

    'FUNCION RECUPERAR DATOS DEL ALUMNO
    Function RecuperarDatosV2(nroDocumento As Integer) As String

        If ValidarExisteAlumno(txtDocumento.Text) = True And ValidarEstadoAlumno(txtDocumento.Text) = True Then

            miConexion.Open()
            instruccionSQL = "select * from Alumno where NroDocumento = '" & nroDocumento & "'"
            miComandoSQL = New SqlCommand(instruccionSQL, miConexion)
            Dim adaptador As New SqlDataAdapter(miComandoSQL)
            miConexion.Close()
            Dim tabla As New DataTable
            adaptador.Fill(tabla)

            If tabla.Rows.Count > 0 Then
                Return tabla.Rows(0)(2).ToString() & ", " & "Estado: Al dia"
            Else
                MsgBox("No existe")
            End If

        Else

            miConexion.Open()
            instruccionSQL = "select * from Alumno where NroDocumento = '" & nroDocumento & "'"
            miComandoSQL = New SqlCommand(instruccionSQL, miConexion)
            Dim adaptador As New SqlDataAdapter(miComandoSQL)
            miConexion.Close()
            Dim tabla As New DataTable
            adaptador.Fill(tabla)

            If tabla.Rows.Count > 0 Then
                Return tabla.Rows(0)(2).ToString() & ", " & "Estado: Moroso"
            Else
            MsgBox("No existe")
        End If

        End If

    End Function

    'FUNCION PARA BUSCAR Y VALIDAR SI EL ALUMNO EXISTE
    Function ValidarExisteAlumno(ByVal nroDocumento As Integer) As Boolean
        Dim resultado As Boolean = False

        miConexion.Open()
        instruccionSQL = "Select * from Alumno where NroDocumento = '" & nroDocumento & "'"
        miComandoSQL = New SqlCommand(instruccionSQL, miConexion)

        dataReader = miComandoSQL.ExecuteReader

        If dataReader.Read Then
            resultado = True
        End If

        dataReader.Close()
        miConexion.Close()

        Return resultado
    End Function

    'FUNCION PARA RECUPERAR FECHA_VENCIMIENTO Y VALIDAR EL ESTADO(Al dia/Moroso) DEL ALUMNO
    Function ValidarEstadoAlumno(ByVal nroDocumento As Integer) As Boolean

        Dim resultado As Boolean = False

        miConexion.Open()
        instruccionSQL = "select i.FechaVencimiento 
                          from Alumno a join Inscripcion i on a.AlumnoID = i.AlumnoID 
                          where a.NroDocumento = '" & nroDocumento & "' and i.FechaVencimiento > GETDATE()"
        miComandoSQL = New SqlCommand(instruccionSQL, miConexion)

        dataReader = miComandoSQL.ExecuteReader

        If dataReader.Read Then
            resultado = True
        End If

        dataReader.Close()
        miConexion.Close()

        Return resultado
    End Function

    'Evento “Leave” del control que contiene el número de documento............................
    Private Sub txtDocumento_Leave(sender As Object, e As EventArgs) Handles txtDocumento.Leave
        'Validando que no ingrese el campo vacio, y que lo que ingrese sea solo nros.
        If IsNumeric(txtDocumento.Text) And txtDocumento.Text.Equals("") = False Then
            Dim documento As Integer
            documento = Val(txtDocumento.Text)
            lblAlumnoEstado.Text = RecuperarDatosV2(documento)
        Else
            MsgBox("No puede dejar campos vacios y debe ingresar solo numeros")
        End If

    End Sub

    'EVENTO SelectedIndexChanged
    Private Sub cmbModalidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbModalidad.SelectedIndexChanged

        Dim cod As Integer = Val(cmbModalidad.SelectedValue.ToString)

        instruccionSQL = "select HorarioID, Descripcion from Horario where ModalidadID =" & cod
        miConexion.Open()
        miComandoSQL = New SqlCommand(instruccionSQL, miConexion)
        Dim adaptador As New SqlDataAdapter(miComandoSQL)
        Dim tabla As New DataTable
        adaptador.Fill(tabla)
        miConexion.Close()
        cmbHorario.DataSource = tabla
        cmbHorario.DisplayMember = "Descripcion"
        cmbHorario.ValueMember = "HorarioID"

    End Sub

    Private Sub cmbModalidad_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbModalidad.SelectedValueChanged

        Dim cod As Integer = Val(cmbModalidad.SelectedValue.ToString)

        instruccionSQL = "select HorarioID, Descripcion from Horario where ModalidadID =" & cod
        miConexion.Open()
        miComandoSQL = New SqlCommand(instruccionSQL, miConexion)
        Dim adaptador As New SqlDataAdapter(miComandoSQL)
        Dim tabla As New DataTable
        adaptador.Fill(tabla)
        miConexion.Close()
        cmbHorario.DataSource = tabla
        cmbHorario.DisplayMember = "Descripcion"
        cmbHorario.ValueMember = "HorarioID"

    End Sub

    'VALIDAR QUE HAYA SELECCIONADO UN HORARIO............
    Private Function ValidarSeleccionHorario() As Boolean
        If (cmbHorario.SelectedIndex.Equals(-1)) Then

            MessageBox.Show("Debe seleccionar un horario")

            Return False

        End If

        Return True

    End Function

    'VERIFICAR CUPO
    Private Sub btnVerificarCupo_Click(sender As Object, e As EventArgs) Handles btnVerificarCupo.Click

        If ValidarSeleccionHorario() = True Then

            'Profe, mi instruccionSQL en este Tema parace un caos, pero funciona...
            miConexion.Open()
            instruccionSQL = "If exists (select (h.Limite - COUNT(ReservaID)) as Disponible 
                              from Horario h join Reserva r on h.HorarioID = r.HorarioID
						                     join Modalidad m on m.ModalidadID = r.ModalidadID
                              where h.Descripcion = '" + cmbHorario.Text + "'  and m.Descripcion = '" + cmbModalidad.Text + "'
                              group by h.Limite)

                              select (h.Limite - COUNT(ReservaID)) as Disponible 
                              from Horario h join Reserva r on h.HorarioID = r.HorarioID
						                     join Modalidad m on m.ModalidadID = r.ModalidadID
                              where h.Descripcion = '" + cmbHorario.Text + "' and m.Descripcion = '" + cmbModalidad.Text + "'
                              group by h.Limite

                              Else (select h.Limite from Horario h join Modalidad m 
						      on h.ModalidadID = m.ModalidadID
                              where m.Descripcion = '" + cmbModalidad.Text + "'
						      group by h.Limite)"

            miComandoSQL = New SqlCommand(instruccionSQL, miConexion)
            Dim adaptador As New SqlDataAdapter(miComandoSQL)
            Dim tabla As New DataTable
            adaptador.Fill(tabla)
            miConexion.Close()

            lblDisponible.Text = tabla.Rows(0)(0).ToString()

            If lblDisponible.Text < 1 Then
                MsgBox("Ya no hay cupos disponibles")
            End If

        End If

    End Sub

    'VALIDAR QUE HAYA SELECCIONADO UN LOCAL............
    Private Function ValidarSeleccionLocal() As Boolean
        If (cmbLocal.SelectedIndex.Equals(-1)) Then

            MessageBox.Show("Debe seleccionar un local")

            Return False

        End If

        Return True

    End Function

    'VALIDAR QUE HAYA SELECCIONADO UNA MODALIDAD...........
    Private Function ValidarSeleccionModalidad() As Boolean
        If (cmbModalidad.SelectedIndex.Equals(-1)) Then

            MessageBox.Show("Debe seleccionar una modalidad")

            Return False

        End If

        Return True

    End Function

    'FUNCION PARA RECUPERAR LocalID FILTRANDO MEDIANTE EL LOCAL SELECCIONADO EN EL COMBOBOX cmbLocal
    Function RecuperarLocalID() As Integer

        miConexion.Open()
        instruccionSQL = "select LocalID from Local where Nombre = '" + cmbLocal.Text + "'"
        miComandoSQL = New SqlCommand(instruccionSQL, miConexion)
        Dim adaptador As New SqlDataAdapter(miComandoSQL)
        miConexion.Close()
        Dim tabla As New DataTable
        adaptador.Fill(tabla)

        Return tabla.Rows(0)(0)

    End Function

    'FUNCION PARA RECUPERAR ModalidadID FILTRANDO MEDIANTE LA MODALIDAD SELECCIONADO EN EL COMBOBOX cmbModalidad
    Function RecuperarModalidadlID() As Integer

        miConexion.Open()
        instruccionSQL = "select ModalidadID from Modalidad where Descripcion = '" + cmbModalidad.Text + "'"
        miComandoSQL = New SqlCommand(instruccionSQL, miConexion)
        Dim adaptador As New SqlDataAdapter(miComandoSQL)
        miConexion.Close()
        Dim tabla As New DataTable
        adaptador.Fill(tabla)

        Return tabla.Rows(0)(0).ToString()

    End Function

    'FUNCION PARA RECUPERAR HorarioID FILTRANDO MEDIANTE LA MODALIDAD Y EL HORARIO SELECCIONADO
    Function RecuperarHorarioID() As Integer

        miConexion.Open()
        instruccionSQL = "select h.HorarioID FROM Horario h join Modalidad m on h.ModalidadID = m.ModalidadID
                          where m.Descripcion = '" + cmbModalidad.Text + "' and h.Descripcion  = '" + cmbHorario.Text + "'"
        miComandoSQL = New SqlCommand(instruccionSQL, miConexion)
        Dim adaptador As New SqlDataAdapter(miComandoSQL)
        miConexion.Close()
        Dim tabla As New DataTable
        adaptador.Fill(tabla)
        miConexion.Close()

        Return tabla.Rows(0)(0).ToString()

    End Function

    'FUNCION PARA RECUPERAR AlumnoID FILTRANDO MEDIANTE EL NRO DE DCOUMENTO INGRESADO EN EL txtDocumento
    Function RecuperarAlumnolID() As Integer

        miConexion.Open()
        instruccionSQL = "select AlumnoID from Alumno where NroDocumento = '" + txtDocumento.Text + "'"
        miComandoSQL = New SqlCommand(instruccionSQL, miConexion)
        Dim adaptador As New SqlDataAdapter(miComandoSQL)
        miConexion.Close()
        Dim tabla As New DataTable
        adaptador.Fill(tabla)

        Return tabla.Rows(0)(0).ToString

    End Function

    'FUNCION PARA RECUPERAR LA FECHA ACTUAL DEL SISTEMA
    Function RecuperarFechaActualSistema() As Date

        miConexion.Open()
        instruccionSQL = "select GETDATE()"
        miComandoSQL = New SqlCommand(instruccionSQL, miConexion)
        Dim adaptador As New SqlDataAdapter(miComandoSQL)
        miConexion.Close()
        Dim tabla As New DataTable
        adaptador.Fill(tabla)

        Return tabla.Rows(0)(0).ToString

    End Function

    'BOTON CONFIRMAR
    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click

        If ValidarExisteAlumno(txtDocumento.Text) = True And ValidarEstadoAlumno(txtDocumento.Text) And
           ValidarSeleccionLocal() = True And ValidarSeleccionModalidad() = True Then

            Dim FechaActualSistema As Date = RecuperarFechaActualSistema()
            Dim FechaAsistencia As Date = dtFechaAsistencia.Value
            Dim LocalID As Integer = RecuperarLocalID()
            Dim ModalidadID As Integer = RecuperarModalidadlID()
            Dim HorarioID As Integer = RecuperarHorarioID()
            Dim AlumnoID As Integer = RecuperarAlumnolID()
            Dim Anulado As String = "N" 'Le puse como valor por defecto N ya que en el prototipo de
            ' formulario no se ingresaba si estaba o no anulado
            miConexion.Open()
            instruccionSQL = "insert Reserva values ('" & FechaActualSistema & "','" & FechaAsistencia & "','" & LocalID & "','" & ModalidadID & "','" & HorarioID & "','" & AlumnoID & "','" & Anulado & "')"
            miComandoSQL = New SqlCommand(instruccionSQL, miConexion)

            miComandoSQL.ExecuteNonQuery()
            miConexion.Close()

            MsgBox("La reserva fue registrada correctamente")
            txtDocumento.Clear()
        Else

            MsgBox("No se ha podido registrar la reserva")
            txtDocumento.Clear() 'En este caso lo unico que se ingresa es el Nro de documento,
            'al arrancar el formulario los combobox ya vienen con valores cargados, por eso fue el
            'unico campo que limpie.

        End If

    End Sub

End Class

