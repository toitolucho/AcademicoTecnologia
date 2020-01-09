USE AcademicaTecnologia
GO

DROP FUNCTION ObtenerFechaHoraServidor
GO

CREATE FUNCTION ObtenerFechaHoraServidor()
RETURNS DATETIME
WITH ENCRYPTION AS
BEGIN
	RETURN GETDATE()
END

