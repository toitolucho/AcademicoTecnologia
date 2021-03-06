USE [AcademicaTecnologia]
GO
/****** Object:  StoredProcedure [dbo].[ListarHorariosCargaHorariaInasistencia]    Script Date: 21/02/2018 9:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[ListarHorariosCargaHorariaInasistencia]
	@Gestion			CHAR(7),
	@FechaEvaluacion	DATE,
	@NombreCarrera		VARCHAR(300),
	@CodigoTurno		CHAR(1)--'M'->MAÑANA, 'T'-> TARDE
AS
BEGIN

DECLARE @HoraInicio TIME,
		@HoraFin TIME,
		@NroDiaSemana TINYINT = DATEPART(DW, @FechaEvaluacion)


IF(@CodigoTurno = 'M') 
BEGIN
	SET @HoraInicio = '07:00:00';
	SET @HoraFin = '13:00:00';
END
ELSE
BEGIN
	SET @HoraInicio = '14:00:00';
	SET @HoraFin = '21:00:00';
END
--SELECT *,  DATEADD(hh,TA.CantidadHoras, TA.dehoras) as AHoras,
	--CASE WHEN TB.IdPlanEstudiosAsignaturaCargaHoraria IS NULL THEN 1 ELSE 0 END AS Asistencia
SELECT	TA.NombreCarrera, TA.NombreDiaSemana, TA.DeHoras, DATEADD(hh,TA.CantidadHoras, TA.dehoras) as AHoras,
		TA.NombreCompleto, TA.NombreAsignatura, TA.TipoCargaHoraria, TA.NombreAula,
		TA.CantidadHoras,
		CAST(CASE WHEN TB.IdPlanEstudiosAsignaturaCargaHoraria IS NULL THEN 1 ELSE 0 END AS BIT) AS Asistencia,
		PlanEstudiosAsignaturaCargaHorariaId, TB.IdInasistencia
FROM
(
	SELECT DS.Nombre1 AS NombreDiaSemana, LH.CodigoNumericoDia, LH.CodigoDia, H.NombreHorario, LH.NombreCompleto, LH.NombreAsignatura, LH.NombreAula, LH.NumeroGrupo,
		ROW_NUMBER() OVER (PARTITION BY LH.CodigoNumericoDia,NombreAula, NombreAsignatura, NombreCompleto, lh.numerogrupo ORDER BY lh.Codigodia, nombrehorario  ASC) AS NroHoras,
		ROW_NUMBER() OVER (PARTITION BY LH.CodigoNumericoDia,NombreAula, NombreAsignatura, NombreCompleto, lh.numerogrupo ORDER BY lh.Codigodia, nombrehorario  DESC) AS CantidadHoras,
		H.DeHoras, LH.NombreCarrera,
		CASE  LH.CodigoTipoCargaHoraria WHEN 'L' THEN 'LABORATORIO' WHEN 'T' THEN 'TEORIA' WHEN 'P' THEN 'PRACTICA' END AS TipoCargaHoraria,
		LH.PlanEstudiosAsignaturaCargaHorariaId
	FROM ListaHorarios LH
	INNER JOIN Horarios H
	ON LH.IdHorario = H.HorarioId
	INNER JOIN DiasSemana DS
	ON LH.CodigoDia = DS.CodigoDia
	WHERE Gestion = @Gestion AND LH.TipoMatricialidad = 'P'
	and LH.NombreCarrera = @NombreCarrera
	AND DS.IdDia = @NroDiaSemana
	AND H.DeHoras BETWEEN @HoraInicio AND @HoraFin
--ORDER BY LH.CodigoNumericoDia, NombreAula, NombreAsignatura, NombreCompleto
) TA
LEFT JOIN PlanesEstudiosAsignaturasCargasHorariasInasistencias TB
ON TA.PlanEstudiosAsignaturaCargaHorariaId = TB.IdPlanEstudiosAsignaturaCargaHoraria
AND TB.FechaInasistencia = @FechaEvaluacion
WHERE TA.NroHoras = 1
ORDER BY ta.CodigoNumericoDia, TA.NombreHorario, NombreCompleto, NombreAula, NombreAsignatura

END
