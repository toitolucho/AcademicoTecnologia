USE AcademicaTecnologia
GO

DROP PROCEDURE ListarCarreras
GO

CREATE PROCEDURE ListarCarreras
AS
BEGIN
	select distinct NumeroCarrera, NombreCarrera
	from ListaHorarios

END
GO


USE AcademicaTecnologia
GO

DROP PROCEDURE ListarInasistenciasTipos
GO

CREATE PROCEDURE ListarInasistenciasTipos
AS
BEGIN
	select IdInasistencia, NombreInasistencia
	from InasistenciasTipos

END
GO

