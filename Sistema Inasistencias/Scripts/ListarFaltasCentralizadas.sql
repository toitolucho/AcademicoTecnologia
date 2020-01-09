USE AcademicaTecnologia
GO

DROP PROCEDURE ListarFaltasCentralizadas
GO

CREATE PROCEDURE ListarFaltasCentralizadas
	@FechaInicio		DATE,
	@FechaFin			DATE
AS
BEGIN

	SELECT *
	FROM
	(
	

	
		SELECT	 LH.NombreAsignatura, LH.SiglaAsignatura, PEACHI.FechaInasistencia, 
				CAST(H.DeHoras AS VARCHAR(5)) + ' a ' +  CAST( DATEADD(HH, PEACHI.CantidadHoras,  h.DeHoras) AS VARCHAR(5) ) AS Horario,
				LH.NombreCompleto, PEACHI.IdInasistencia, IT.NombreInasistencia
		FROM [dbo].[PlanesEstudiosAsignaturasCargasHorariasInasistencias] PEACHI
		INNER JOIN ListaHorarios LH
		ON LH.PlanEstudiosAsignaturaCargaHorariaId = PEACHI.IdPlanEstudiosAsignaturaCargaHoraria
		JOIN Horarios H
		ON LH.IdHorario = H.HorarioId
		JOIN InasistenciasTipos IT
		ON IT.IdInasistencia = PEACHI.IdInasistencia
		WHERE PEACHI.FechaInasistencia BETWEEN @FechaInicio AND @FechaFin
	
	)TA1
	PIVOT 
	(
		MAX(Horario)
		FOR NombreInasistencia

		IN ( [CON LICENCIA],[SIN LICENCIA],[COMISION],[BAJA MEDICA],[ABANDONO])
	)AS Cro

END
GO

EXEC ListarFaltasCentralizadas '01/01/2017','28/02/2019'
EXEC [dbo].[ListarHorariosCargaHorariaInasistencia] '02/2017', '04/12/2017', 'INGENIERIA EN DISEÑO Y ANIMACION DIGITAL', 'M'

delete from PlanesEstudiosAsignaturasCargasHorariasInasistencias

SELECT 
			ROW_NUMBER() OVER (PARTITION BY LH.CodigoNumericoDia,NombreAula, NombreAsignatura, NombreCompleto, lh.numerogrupo ORDER BY lh.Codigodia, nombrehorario  ASC) AS NroHoras,
			ROW_NUMBER() OVER (PARTITION BY LH.CodigoNumericoDia,NombreAula, NombreAsignatura, NombreCompleto, lh.numerogrupo ORDER BY lh.Codigodia, nombrehorario  DESC) AS CantidadHoras,			
			LH.PlanEstudiosAsignaturaCargaHorariaId
		FROM ListaHorarios LH
		INNER JOIN Horarios H
		ON LH.IdHorario = H.HorarioId
		INNER JOIN DiasSemana DS
		ON LH.CodigoDia = DS.CodigoDia
		WHERE Gestion = '01/2017'
		AND LH.TipoMatricialidad = 'P'
		and LH.NombreCarrera = 'INGENIERIA DE SISTEMAS'
		AND DS.IdDia = 2
		AND H.DeHoras BETWEEN  '07:00:00' AND  '13:00:00'
		and LH.PlanEstudiosAsignaturaCargaHorariaId = 2974

'01/2017', '31/01/2017', 'INGENIERA DE SISTEMAS', 'M', '2974-4'
INGENIERIA DE SISTEMAS
select DATEPART(DW, '31/01/2017')

select * 
from ListaHorarios LH
JOIN PlanesEstudiosAsignaturasCargasHorariasInasistencias CI
on CI.IdPlanEstudiosAsignaturaCargaHoraria = LH.PlanEstudiosAsignaturaCargaHorariaId

EXEC ListarFaltasCentralizadas 