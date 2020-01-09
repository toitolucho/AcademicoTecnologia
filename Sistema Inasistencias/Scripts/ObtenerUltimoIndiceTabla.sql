USE AcademicaTecnologia
GO
--Realiza la Obtención del Ultimo indice de la Tabla que contiene una columna Identity como 
--AutoIncrementable, en caso de que la Tabla este vacia, retorna 1, caso contrario el número 
--Actual donde se encuentra el Identity
DROP FUNCTION ObtenerUltimoIndiceTabla
GO

CREATE FUNCTION [dbo].[ObtenerUltimoIndiceTabla] (@NombreTabla VARCHAR(250))
RETURNS INT
AS
BEGIN
	DECLARE @Indice		INT
	SET @Indice = IDENT_CURRENT(@NombreTabla)
	RETURN @Indice 
END
