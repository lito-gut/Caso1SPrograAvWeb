# Caso1SPrograAvWeb
Crear una Aplicación Web en .Net Core utilizando C#, con un patrón de diseño de MVC. 
Crear una pantalla principal con un menú de acceso a las vistas. 
Implementar Dependencias y Valores en los archivos appsettings.json. 
Se debe utilizar Dapper con procedimientos almacenados. 
La interfaz gráfica de usuario requiere bootstrap como mínimo. 

Pantalla Web de Registro. 
• El usuario podrá registrar matriculas a distintos tipos de cursos.  
Nombre: Campo obligatorio, debe indicar el nombre del estudiante. 
Fecha: Campo obligatorio, debe indicar la fecha y la hora, no debe mostrarse en pantalla. 
Monto: Campo obligatorio, debe indicar el monto del pago realizado (no son letras). 
TipoCurso, Campo obligatorio, debe ser una caja de texto. (debe validarse que el ID del tipo de curso exista) 
• Una matrícula solo puede ser del tipo de curso indicado en la tabla de tipos.  
• No se puede matricular más de 2 cursos por cada estudiante (validado por nombre)  
• Validaciones y mensajes claros al usuario. 

Pantalla Web de Consulta. 
• El usuario podrá consultar todas las matrículas registradas en la base de datos.  
• Se debe mostrar: Fecha, Monto, Descripción del tipo de curso y el Nombre del Estudiante. 
• Se debe documentar en PDF el funcionamiento de la consulta y del registro de matrículas. 
