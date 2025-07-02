CREATE OR ALTER PROCEDURE sp_ExisteTipoCurso
    @TipoCurso INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT COUNT(1)
    FROM TiposCursos
    WHERE TipoCurso = @TipoCurso;
END;


CREATE OR ALTER PROCEDURE sp_ContarMatriculasPorEstudiante
    @Nombre NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT COUNT(*)
    FROM Estudiantes
    WHERE Nombre = @Nombre;
END;


CREATE OR ALTER PROCEDURE sp_RegistrarMatricula
    @Nombre NVARCHAR(255),
    @Fecha DATETIME,
    @Monto DECIMAL(10,2),
    @TipoCurso INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Estudiantes (Nombre, Fecha, Monto, TipoCurso)
    VALUES (@Nombre, @Fecha, @Monto, @TipoCurso);

    SELECT SCOPE_IDENTITY(); -- Retorna el ID insertado
END;

CREATE PROCEDURE sp_ConsultarMatriculas
AS
BEGIN
    SELECT e.Nombre AS NombreEstudiante,
           t.DescripcionTipoCurso,
           e.Monto,
           e.Fecha
    FROM Estudiantes e
    INNER JOIN TiposCursos t ON e.TipoCurso = t.TipoCurso
END


CREATE PROCEDURE sp_ObtenerTiposCursos
AS
BEGIN
    SELECT TipoCurso, DescripcionTipoCurso FROM TiposCursos
END
