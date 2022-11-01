using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace Logica
{
    public class Principal
    {

        List<Profesores> ListaProfesores = new List<Profesores>();
        List<Clientes> ListaClientes = new List<Clientes>();
        List<Secretarios> ListaSecretarios = new List<Secretarios>();
        List<Actividades> ListaActividades = new List<Actividades>();
        List<Suscripciones> ListaSuscripciones = new List<Suscripciones>();
       

        public void altaCliente(Clientes persona)
        {
            var sql = "insert into clientes(dni, nombre, apellido, fechanacimiento, telefono, email, domicilio) values (@dni, @nombre, @apellido, @fechanacimiento, @telefono, @email, @domicilio)";
            SQLiteCommand cmd = new SQLiteCommand(sql, ConexionASql.obtenerInstancia());
            cmd.Parameters.Add(new SQLiteParameter("@dni", persona.dni));
            cmd.Parameters.Add(new SQLiteParameter("@nombre", persona.nombre));
            cmd.Parameters.Add(new SQLiteParameter("@apellido", persona.apellido));
            cmd.Parameters.Add(new SQLiteParameter("@fechanacimiento", persona.fechaNacimiento));
            cmd.Parameters.Add(new SQLiteParameter("@telefono", persona.telefono));
            cmd.Parameters.Add(new SQLiteParameter("@email", persona.email));
            cmd.Parameters.Add(new SQLiteParameter("@domicilio", persona.domicilio));
            cmd.ExecuteNonQuery();
        }

        public void modificacionCliente(Clientes clienteNuevo, int idCliente)
        {
            var sql = "update clientes set dni=@dni, nombre=@nombre, apellido=@apellido, fechanacimiento=@fechanacimiento, telefono=@telefono, email=@email, domicilio=@domicilio where id = @id";
            SQLiteCommand cmd = new SQLiteCommand(sql, ConexionASql.obtenerInstancia());
            cmd.Parameters.Add(new SQLiteParameter("@dni", clienteNuevo.dni));
            cmd.Parameters.Add(new SQLiteParameter("@nombre", clienteNuevo.nombre));
            cmd.Parameters.Add(new SQLiteParameter("@apellido", clienteNuevo.apellido));
            cmd.Parameters.Add(new SQLiteParameter("@fechanacimiento", clienteNuevo.fechaNacimiento));
            cmd.Parameters.Add(new SQLiteParameter("@telefono", clienteNuevo.telefono));
            cmd.Parameters.Add(new SQLiteParameter("@email", clienteNuevo.email));
            cmd.Parameters.Add(new SQLiteParameter("@domicilio", clienteNuevo.domicilio));
            cmd.Parameters.Add(new SQLiteParameter("@id", idCliente));
            cmd.ExecuteNonQuery();
        }

        public void bajaCliente(int idCliente)
        {
            string sql = "delete from clientes where id = @id";
            SQLiteCommand cmd = new SQLiteCommand(sql, ConexionASql.obtenerInstancia());
            cmd.Parameters.Add(new SQLiteParameter("@id", idCliente));
            cmd.ExecuteNonQuery();
        }

        public void altaProfesor(Profesores persona)
        {
            var sql = "insert into profesores (dni, nombre, apellido, fechanacimiento, telefono, email, domicilio, horastrabajadas, montoxhora, sueldo) values (@dni, @nombre, @apellido, @fechanacimiento, @telefono, @email, @domicilio, @horastrabajadas, @montoxhora, @sueldo)";
            SQLiteCommand cmd = new SQLiteCommand(sql, ConexionASql.obtenerInstancia());
            cmd.Parameters.Add(new SQLiteParameter("@dni", persona.dni));
            cmd.Parameters.Add(new SQLiteParameter("@nombre", persona.nombre));
            cmd.Parameters.Add(new SQLiteParameter("@apellido", persona.apellido));
            cmd.Parameters.Add(new SQLiteParameter("@fechanacimiento", persona.fechaNacimiento));
            cmd.Parameters.Add(new SQLiteParameter("@telefono", persona.telefono));
            cmd.Parameters.Add(new SQLiteParameter("@email", persona.email));
            cmd.Parameters.Add(new SQLiteParameter("@domicilio", persona.domicilio));
            cmd.Parameters.Add(new SQLiteParameter("@horastrabajadas", persona.horasTrabajadas));
            cmd.Parameters.Add(new SQLiteParameter("@montoxhora", persona.monto));
            persona.sueldo = persona.horasTrabajadas * persona.monto;
            cmd.Parameters.Add(new SQLiteParameter("@sueldo", persona.sueldo));
            cmd.ExecuteNonQuery();
        }

        public void modificacionProfesores(Profesores profesorNuevo, int idProfesor)
        {

            var sql = "update profesores set dni=@dni, nombre=@nombre, apellido=@apellido, fechanacimiento=@fechanacimiento, telefono=@telefono, email=@email, domicilio=@domicilio, horastrabajadas=@horastrabajadas, montoxhora=@montoxhora, sueldo=@sueldo where id = @id";
            SQLiteCommand cmd = new SQLiteCommand(sql, ConexionASql.obtenerInstancia());
            cmd.Parameters.Add(new SQLiteParameter("@dni", profesorNuevo.dni));
            cmd.Parameters.Add(new SQLiteParameter("@nombre", profesorNuevo.nombre));
            cmd.Parameters.Add(new SQLiteParameter("@apellido", profesorNuevo.apellido));
            cmd.Parameters.Add(new SQLiteParameter("@fechanacimiento", profesorNuevo.fechaNacimiento));
            cmd.Parameters.Add(new SQLiteParameter("@telefono", profesorNuevo.telefono));
            cmd.Parameters.Add(new SQLiteParameter("@email", profesorNuevo.email));
            cmd.Parameters.Add(new SQLiteParameter("@domicilio", profesorNuevo.domicilio));
            cmd.Parameters.Add(new SQLiteParameter("@horastrabajadas", profesorNuevo.horasTrabajadas));
            cmd.Parameters.Add(new SQLiteParameter("@montoxhora", profesorNuevo.monto));
            profesorNuevo.sueldo = profesorNuevo.horasTrabajadas * profesorNuevo.monto;
            cmd.Parameters.Add(new SQLiteParameter("@sueldo", profesorNuevo.sueldo));
            cmd.Parameters.Add(new SQLiteParameter("@id", idProfesor));
            cmd.ExecuteNonQuery();
        }

        public void bajaProfesor(int idProfesor)
        {
            string sql = "delete from profesores where id = @id";
            SQLiteCommand cmd = new SQLiteCommand(sql, ConexionASql.obtenerInstancia());
            cmd.Parameters.Add(new SQLiteParameter("@id", idProfesor));
            cmd.ExecuteNonQuery();
        }
        public void altaSecretarios(Secretarios persona)
        {
            var sql = "insert into secretarios (dni, contraseña, nombre, apellido, fechanacimiento, telefono, email, domicilio, horastrabajadas, montoxhora, sueldo) values (@dni, @contraseña, @nombre, @apellido, @fechanacimiento, @telefono, @email, @domicilio, @horastrabajadas, @montoxhora, @sueldo)";
            SQLiteCommand cmd = new SQLiteCommand(sql, ConexionASql.obtenerInstancia());
            cmd.Parameters.Add(new SQLiteParameter("@dni", persona.dni));
            cmd.Parameters.Add(new SQLiteParameter("@contraseña", persona.contraseña));
            cmd.Parameters.Add(new SQLiteParameter("@nombre", persona.nombre));
            cmd.Parameters.Add(new SQLiteParameter("@apellido", persona.apellido));
            cmd.Parameters.Add(new SQLiteParameter("@fechanacimiento", persona.fechaNacimiento));
            cmd.Parameters.Add(new SQLiteParameter("@telefono", persona.telefono));
            cmd.Parameters.Add(new SQLiteParameter("@email", persona.email));
            cmd.Parameters.Add(new SQLiteParameter("@domicilio", persona.domicilio));
            cmd.Parameters.Add(new SQLiteParameter("@horastrabajadas", persona.horasTrabajadas));
            cmd.Parameters.Add(new SQLiteParameter("@montoxhora", persona.monto));
            persona.sueldo = persona.horasTrabajadas * persona.monto;
            cmd.Parameters.Add(new SQLiteParameter("@sueldo", persona.sueldo));
            cmd.ExecuteNonQuery();

        }

    

        public void modificacionSecretarios(Secretarios nuevoSecretario, int idSecretario)
        {

            //var sql = " update secretarios " +
            //    " set dni = " +"'"+ nuevoSecretario.dni +"'"+
            //    " where id = " + idSecretario +
            //    ";" +
            //    " update secretarios " +
            //    " set contraseña = " +"'"+ nuevoSecretario.contraseña +"'"+
            //    " where id = " + idSecretario +
            //    ";" +
            //    " update secretarios " +
            //    " set nombre = " +"'"+ nuevoSecretario.nombre +"'"+
            //    " where id = " + idSecretario +
            //    ";" +
            //    " update secretarios " +
            //    " set apellido = " +"'"+ nuevoSecretario.apellido +"'"+
            //    " where id = " + idSecretario +
            //    ";" +
            //    " update secretarios " +
            //    " set fechanacimiento = " +"'"+ nuevoSecretario.fechaNacimiento +"'"+
            //    " where id = " + idSecretario +
            //    ";" +
            //    " update secretarios " +
            //    " set telefono = " +"'"+nuevoSecretario.telefono +"'"+
            //    " where id = " + idSecretario +
            //    ";" +
            //    " update secretarios " +
            //    " set email = " +"'"+ nuevoSecretario.email +"'"+
            //    " where id = " + idSecretario +
            //    ";" +
            //    " update secretarios " +
            //    " set domicilio = " +"'"+ nuevoSecretario.domicilio +"'"+
            //    " where id = " + idSecretario +
            //    ";" +
            //    " update secretarios " +
            //    " set horastrabajadas = " +"'"+ nuevoSecretario.horasTrabajadas +"'"+
            //    " where id = " + idSecretario +
            //    ";" +
            //    " update secretarios " +
            //    " set montoxhora = " +"'"+ nuevoSecretario.monto +"'"+
            //    " where id = " + idSecretario +
            //    ";" +
            //    " update secretarios " +
            //    " set sueldo = " +"'"+ nuevoSecretario.sueldo +"'"+
            //    " where id = " + idSecretario +
            //    ";";

            var sql = "update secretarios set dni=@dni, contraseña=@contraseña, nombre=@nombre, apellido=@apellido, fechanacimiento=@fechanacimiento, telefono=@telefono, email=@email, domicilio=@domicilio, horastrabajadas=@horastrabajadas, montoxhora=@montoxhora, sueldo=@sueldo where id = @id";
            SQLiteCommand cmd = new SQLiteCommand(sql, ConexionASql.obtenerInstancia());
            cmd.Parameters.Add(new SQLiteParameter("@dni", nuevoSecretario.dni));
            cmd.Parameters.Add(new SQLiteParameter("@contraseña", nuevoSecretario.contraseña));
            cmd.Parameters.Add(new SQLiteParameter("@nombre", nuevoSecretario.nombre));
            cmd.Parameters.Add(new SQLiteParameter("@apellido", nuevoSecretario.apellido));
            cmd.Parameters.Add(new SQLiteParameter("@fechanacimiento", nuevoSecretario.fechaNacimiento));
            cmd.Parameters.Add(new SQLiteParameter("@telefono", nuevoSecretario.telefono));
            cmd.Parameters.Add(new SQLiteParameter("@email", nuevoSecretario.email));
            cmd.Parameters.Add(new SQLiteParameter("@domicilio", nuevoSecretario.domicilio));
            cmd.Parameters.Add(new SQLiteParameter("@horastrabajadas", nuevoSecretario.horasTrabajadas));
            cmd.Parameters.Add(new SQLiteParameter("@montoxhora", nuevoSecretario.monto));
            nuevoSecretario.sueldo = nuevoSecretario.horasTrabajadas * nuevoSecretario.monto;
            cmd.Parameters.Add(new SQLiteParameter("@sueldo", nuevoSecretario.sueldo));
            cmd.Parameters.Add(new SQLiteParameter("@id", idSecretario));
            cmd.ExecuteNonQuery();
        }

        public void bajaSecretario(int idSecretario)
        {
            string sql = "delete from secretarios where id =@id";
            SQLiteCommand cmd = new SQLiteCommand(sql, ConexionASql.obtenerInstancia());
            cmd.Parameters.Add(new SQLiteParameter("@id", idSecretario));
            cmd.ExecuteNonQuery();
        }
        public void altaSuscripciones(Suscripciones suscripciones)
        {
            string sql = "insert into suscripciones (idactividad, idcliente, fechasuscripcion, finsuscripcion, pagado) values(@idactividad, @idcliente, @fechasuscripcion, @finsuscripcion, @pagado)";
            SQLiteCommand cmd = new SQLiteCommand(sql, ConexionASql.obtenerInstancia());
            cmd.Parameters.Add(new SQLiteParameter("@idactividad", suscripciones.idActividad));
            cmd.Parameters.Add(new SQLiteParameter("@idcliente", suscripciones.idCliente));
            cmd.Parameters.Add(new SQLiteParameter("@fechasuscripcion", suscripciones.fechaSuscripcion));
            cmd.Parameters.Add(new SQLiteParameter("@finsuscripcion", suscripciones.finSuscripcion));
            cmd.Parameters.Add(new SQLiteParameter("@pagado", suscripciones.pagado));
            cmd.ExecuteNonQuery();
        }
        
        public void modificacionSuscripciones(Suscripciones nuevaSuscripcion,int idSuscripcion)
        {
            //var sql = "update suscripciones set idactividad=@idactividad, idcliente=@idcliente, fechasuscripcion=@fechasuscripcion, finsuscripcion=@finsuscripcion, pagado=@pagado where id = @id";
            var sql = "update suscripciones set pagado = @pagado, fechaSuscripcion = @fechaSuscripcion, finSuscripcion = @finSuscripcion where id = @id";
            SQLiteCommand cmd = new SQLiteCommand(sql, ConexionASql.obtenerInstancia());
            cmd.Parameters.Add(new SQLiteParameter("@pagado", nuevaSuscripcion.pagado));
            cmd.Parameters.Add(new SQLiteParameter("@id", idSuscripcion));
            cmd.Parameters.Add(new SQLiteParameter("@fechaSuscripcion", nuevaSuscripcion.fechaSuscripcion));
            cmd.Parameters.Add(new SQLiteParameter("@finSuscripcion", nuevaSuscripcion.finSuscripcion));
            cmd.ExecuteNonQuery();
        }

        public void bajaSuscripcion(int idSuscripcion)
        {
           
        }

        public void altaActividades(Actividades actividad) { 
        Actividades nuevaActividad = new Actividades
        {
            
        };
        ListaActividades.Add(nuevaActividad);
        }

        public void modificacionActividad(Actividades nuevaActividad,int idActividad)
        {
            var actividadModificada = ListaActividades.Find(x => idActividad == x.idActividadPK);

            actividadModificada.idActividadPK = idActividad;
            actividadModificada.nombreActividad = nuevaActividad.nombreActividad;
            actividadModificada.descripcion = nuevaActividad.descripcion;

            var actividadEliminada = ListaActividades.Find(x => idActividad == x.idActividadPK);
            ListaActividades.Remove(actividadEliminada);
            ListaActividades.Add(actividadEliminada);
        }

        public void bajaActividad(int idActividad)
        {
            var actividadEliminado = ListaActividades.Find(x => idActividad == x.idActividadPK);
            ListaActividades.Remove(actividadEliminado);
        }
        
        public int calculoSueldo(Administradores administrador,int sueldo, int horas)
        {
            administrador.horasTrabajadas = horas * sueldo;
            return administrador.horasTrabajadas;
        }

    }
}


