# Sistema de Gestión de Gimnasio 🏋️‍♂️

Este proyecto es una aplicación de escritorio para la gestión integral de un gimnasio, desarrollada en C# utilizando Windows Forms para la interfaz de usuario y Entity Framework para el acceso a datos. La base de datos se implementa en SQLite, lo que permite un manejo ligero y eficiente de la información.

## Descripción

El sistema permite realizar operaciones de **alta**, **baja** y **modificación** de los siguientes módulos:
- **Clientes:** Registro y mantenimiento de datos personales.
- **Secretarios:** Gestión del personal administrativo.
- **Profesores:** Administración de datos y seguimiento del desempeño de los instructores.
- **Actividades:** Creación y modificación de las diferentes clases y actividades ofrecidas en el gimnasio.

Además, el sistema gestiona:
- **Suscripciones mensuales:** Permite la consulta y alta de suscripciones por parte de los clientes hacia las actividades disponibles.

## Tecnologías Utilizadas

- **Lenguaje:** C#
- **Interfaz Gráfica:** Windows Forms
- **ORM:** Entity Framework
- **Base de Datos:** SQLite

## Mejoras Futuras

- **Implementación de Roles de Usuario:** 
  - Incorporar un sistema de inicio de sesión con roles diferenciados para controlar el acceso a funcionalidades específicas.
- **Panel de Control para el Dueño:**
  - Visualización de estadísticas clave del negocio (número de suscripciones, asistencia a actividades, etc.).
  - Control y seguimiento de los sueldos de los profesores.
- **Gestión de Turnos:**
  - Agregar la funcionalidad de asignación y control de turnos para todos los roles del sistema.

## Requisitos

- [.NET Framework](https://dotnet.microsoft.com/) compatible con Windows Forms.
- [SQLite](https://www.sqlite.org/index.html)
- [Entity Framework](https://docs.microsoft.com/en-us/ef/) para el acceso a la base de datos.

## Instalación

1. **Clonar el repositorio:**

   ```bash
   git clone https://github.com/tu-usuario/gestion-gimnasio.git
   ```

2. **Abrir el proyecto en Visual Studio.**

3. **Restaurar los paquetes NuGet** necesarios para el proyecto.

4. **Configurar la cadena de conexión** en el archivo de configuración para conectar con la base de datos SQLite.

5. **Compilar y ejecutar** la aplicación.

## Uso

- **Inicio de Sesión:** Acceso al sistema mediante credenciales (la funcionalidad de roles se implementará en futuras versiones).
- **Módulos Administrativos:** Navegar por los distintos formularios para gestionar clientes, secretarios, profesores y actividades.
- **Suscripciones:** Registrar y consultar las suscripciones mensuales de los clientes a las actividades disponibles.

## A continuacion dejo la vizualizacion de algunas de las pantallas con las que cuenta el sistema.
- **Inicio de sesión**

![image](https://github.com/user-attachments/assets/7102f129-ee5b-4426-b8e3-889cb7452df6)

- **Menu principal**

![image](https://github.com/user-attachments/assets/e1ed4825-9426-49ee-8e5e-77326a31a155)

- **Gestión de clientes**

![image](https://github.com/user-attachments/assets/73e2248d-23e3-4b17-b8ae-3640ec3f15c1)

- **Gestión de suscripciones**

![image](https://github.com/user-attachments/assets/1bda84b4-95b9-420e-827b-e440613993ff)

- **Alta de suscripciones**

![image](https://github.com/user-attachments/assets/1a52abe7-4269-4020-9be1-bb0e900d447d)

