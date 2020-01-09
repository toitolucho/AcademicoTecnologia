USE AcademicaTecnologia
GO


--CORRECCION DE LA VISTA, CON EL PROBLEMA DEL NOMBRE DE LA CARRERA
DROP VIEW ListaHorarios
GO

CREATE VIEW ListaHorarios
AS
SELECT        D.NombreCompleto, PEA.NombreAsignatura, PEA.SiglaAsignatura, PEACH.NumeroGrupo, PEACH.CodigoTipoCargaHoraria, PEACH.CodigoDia, PEACH.IdHorario, PEACH.CodigoTipoHabilitacionGrupo, D.DiPersona, 
                         PEACH.TipoCondicionAsignacionGrupo, PEACH.IdAula, PEACH.GrupoProgramacion, 
                         CASE CodigoDia WHEN 'L' THEN 1 WHEN 'M' THEN 2 WHEN 'I' THEN 3 WHEN 'J' THEN 4 WHEN 'V' THEN 5 WHEN 'S' THEN 6 END AS CodigoNumericoDia, A.NombreAula, PEA.SiglaAsignatura + CHAR(13) 
                         + CHAR(10) + (CASE WHEN D .DocenteId = 1 THEN NombreCompleto ELSE CAST(abreviacionDocente AS VARCHAR(50)) END) 
                         + ' | ' + PEACH.CodigoTipoCargaHoraria + '-' + RIGHT('00' + CAST(PEACH.NumeroGrupo AS VARCHAR(2)), 2) + CHAR(13) + CHAR(10) + ISNULL(SUBSTRING(A.NombreAula, 0, 6) + '    ', 'SIN ASIG.') AS NombreCelda, 
                         CASE PE.NumeroCarrera WHEN 56 THEN 'INGENIERIA EN TELECOMUNICACIONES' WHEN 35 THEN 'INGENIERIA DE SISTEMAS' WHEN 57 THEN 'INGENIERIA EN DISEÑO Y ANIMACION DIGITAL' ELSE 'INGENIERIA ....' END AS NombreCarrera, PE.NumeroCarrera, 
                         PE.NumeroPlanEstudios, PEA.Curso, 
                         CASE PEA.Curso WHEN 1 THEN 'PRIMERO' WHEN 2 THEN 'SEGUNDO' WHEN 3 THEN 'TERCERO' WHEN 4 THEN 'CUARTO' WHEN 5 THEN 'QUINTO' WHEN 6 THEN 'SEXTO' WHEN 7 THEN 'SEPTIMO' WHEN 8 THEN
                          'OCTAVO' WHEN 9 THEN 'NOVENO' WHEN 10 THEN 'DECIMO' END AS CursoLiteral, 'FACULTAD DE TECNOLOGIA' AS NombreFacultad, PEACH.Gestion, PEACH.PlanEstudiosAsignaturaCargaHorariaId, 
                         PEACH.IdPlanEstudiosAsignatura, PEACH.TipoMatricialidad
FROM            dbo.PlanesEstudiosAsignaturasCargasHorarias AS PEACH INNER JOIN
                         dbo.PlanesEstudiosAsignaturas AS PEA ON PEA.PlanEstudiosAsignaturaId = PEACH.IdPlanEstudiosAsignatura INNER JOIN
                         dbo.PlanesEstudios AS PE ON PE.PlanEstudiosId = PEA.IdPlanEstudios INNER JOIN
                         dbo.Docentes AS D ON D.DocenteId = PEACH.IdDocente LEFT OUTER JOIN
                         dbo.Aulas AS A ON PEACH.IdAula = A.AulaId


GO

CREATE TABLE InasistenciasTipos
(
	IdInasistencia 		TINYINT IDENTITY(1,1),
	NombreInasistencia 	VARCHAR(50),
	CONSTRAINT PK_InasistenciasTipos PRIMARY KEY (IdInasistencia),
	CONSTRAINT U_NombreInasistencia UNIQUE(NombreInasistencia)
)
GO

INSERT INTO InasistenciasTipos VALUES  ('SIN LICENCIA'), ('CON LICENCIA'), ('COMISION'),('BAJA MEDICA'), ('ABANDONO');
GO

--DROP TABLE PlanesEstudiosAsignaturasCargasHorariasInasistencias
CREATE TABLE PlanesEstudiosAsignaturasCargasHorariasInasistencias
(
	CargaHorariaInasistenciaId				INT IDENTITY(1,1),
	IdPlanEstudiosAsignaturaCargaHoraria	INT,
	CantidadHoras							SMALLINT,--Este campo indicara el incremento de horas, a la hora de inicio
	FechaInasistencia						DATE,
	IdInasistencia							TINYINT,
	Observaciones							VARCHAR(30),
	CodigoEstado							CHAR(1), --'I' ->Iniciado, 'A' -> Anulado, 'E'->Enviado
	CONSTRAINT PK_CargasHorariasInasistencias PRIMARY KEY (CargaHorariaInasistenciaId),
	CONSTRAINT U_FechaAsignaturaCargaHoraria UNIQUE(IdPlanEstudiosAsignaturaCargaHoraria, FechaInasistencia),
	CONSTRAINT FK_CargasHorariasInasistencias01 FOREIGN KEY(IdPlanEstudiosAsignaturaCargaHoraria)
	REFERENCES [dbo].[PlanesEstudiosAsignaturasCargasHorarias] (PlanEstudiosAsignaturaCargaHorariaId),
	CONSTRAINT FK_PlanesEACHI_IT FOREIGN KEY (IdInasistencia) REFERENCES InasistenciasTipos(IdInasistencia)
)
GO



DROP PROCEDURE InsertarPlanesEstudiosAsignaturasCargasHorariasInasistencias
GO


CREATE PROCEDURE InsertarPlanesEstudiosAsignaturasCargasHorariasInasistencias
	@Gestion			CHAR(7),
	@FechaEvaluacion	DATE,
	@NombreCarrera		VARCHAR(300),
	@CodigoTurno		CHAR(1),--'M'->MAÑANA, 'T'-> TARDE
	@ListaIdFaltas	VARCHAR(500)

AS
BEGIN
	DECLARE @SeparadorTuplas CHAR(1) = ','
	DECLARE @SeparadorIds CHAR(1) = '-'

	DECLARE @HoraInicio TIME,
		@HoraFin TIME,
		@NroDiaSemana TINYINT = DATEPART(DW, @FechaEvaluacion)


	CREATE TABLE #InasistenciasNuevo
	(
		PlanEstudiosAsignaturaCargaHorariaId	INT,
		IdInasistencia							TINYINT,
		CantidadHoras							TINYINT
	);

	CREATE TABLE #InasistenciasAntiguo
	(
		PlanEstudiosAsignaturaCargaHorariaId	INT,
		CantidadHoras							TINYINT
	);



	INSERT INTO #InasistenciasNuevo
	SELECT CAST(SUBSTRING(Data, 0, CHARINDEX(@SeparadorIds,Data,0)) AS INT)  ,  CAST(SUBSTRING(Data, CHARINDEX(@SeparadorIds,Data,0)+1, LEN(Data) ) AS TINYINT), 0
	FROM  SplitByXml (@ListaIdFaltas, @SeparadorTuplas)

	

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
	

	


	INSERT INTO #InasistenciasAntiguo
	SELECT	PlanEstudiosAsignaturaCargaHorariaId, CAST(TA.CantidadHoras AS TINYINT)
	FROM
	(
		SELECT 
			ROW_NUMBER() OVER (PARTITION BY LH.CodigoNumericoDia,NombreAula, NombreAsignatura, NombreCompleto, lh.numerogrupo ORDER BY lh.Codigodia, nombrehorario  ASC) AS NroHoras,
			ROW_NUMBER() OVER (PARTITION BY LH.CodigoNumericoDia,NombreAula, NombreAsignatura, NombreCompleto, lh.numerogrupo ORDER BY lh.Codigodia, nombrehorario  DESC) AS CantidadHoras,			
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
	JOIN PlanesEstudiosAsignaturasCargasHorariasInasistencias TB
	ON TA.PlanEstudiosAsignaturaCargaHorariaId = TB.IdPlanEstudiosAsignaturaCargaHoraria
	WHERE TA.NroHoras = 1



	UPDATE #InasistenciasNuevo
		SET CantidadHoras = CAST(TA.CantidadHoras AS TINYINT)
	FROM
	(
		SELECT 
			ROW_NUMBER() OVER (PARTITION BY LH.CodigoNumericoDia,NombreAula, NombreAsignatura, NombreCompleto, lh.numerogrupo ORDER BY lh.Codigodia, nombrehorario  ASC) AS NroHoras,
			ROW_NUMBER() OVER (PARTITION BY LH.CodigoNumericoDia,NombreAula, NombreAsignatura, NombreCompleto, lh.numerogrupo ORDER BY lh.Codigodia, nombrehorario  DESC) AS CantidadHoras,			
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
	where #InasistenciasNuevo.PlanEstudiosAsignaturaCargaHorariaId = TA.PlanEstudiosAsignaturaCargaHorariaId

	SELECT * FROM #InasistenciasNuevo
	SELECT * FROM #InasistenciasAntiguo

	PRINT 'ELIMINANDO'
	--ELIMINAMOS LOS TIPOS DE INASISTENCIAS QUE FUERON REMOVIMOS EN LA INTERFAZ WEB
	DELETE  PlanesEstudiosAsignaturasCargasHorariasInasistencias
	FROM ListaHorarios LH
	INNER JOIN Horarios H
	ON LH.IdHorario = H.HorarioId
	INNER JOIN DiasSemana DS
	ON LH.CodigoDia = DS.CodigoDia		
	WHERE PlanesEstudiosAsignaturasCargasHorariasInasistencias.IdPlanEstudiosAsignaturaCargaHoraria NOT IN
	(
		SELECT TA.PlanEstudiosAsignaturaCargaHorariaId
		FROM #InasistenciasNuevo TA
	)
	AND LH.PlanEstudiosAsignaturaCargaHorariaId = PlanesEstudiosAsignaturasCargasHorariasInasistencias.IdPlanEstudiosAsignaturaCargaHoraria
	AND LH.NombreCarrera = @NombreCarrera
	AND Gestion = @Gestion AND LH.TipoMatricialidad = 'P'
	AND DS.IdDia = @NroDiaSemana
	AND H.DeHoras BETWEEN @HoraInicio AND @HoraFin

	PRINT 'INSERTANDO'
	--INSERTAMOS NUEVOS
	INSERT INTO PlanesEstudiosAsignaturasCargasHorariasInasistencias ( IdPlanEstudiosAsignaturaCargaHoraria, CantidadHoras, FechaInasistencia, IdInasistencia, Observaciones, CodigoEstado)
	SELECT INN.PlanEstudiosAsignaturaCargaHorariaId, ISNULL(INN.CantidadHoras,2), @FechaEvaluacion, INN.IdInasistencia, NULL, 'I'
	FROM #InasistenciasNuevo INN
	WHERE INN.PlanEstudiosAsignaturaCargaHorariaId NOT IN
	(
		SELECT IA.PlanEstudiosAsignaturaCargaHorariaId
		FROM #InasistenciasAntiguo IA
	)

	PRINT 'ACTUALIZANDO'
	--ACTUALIZAMOS LOS TIPOS DE INASISTENCIAS, SI EXISTIERON CAMBIOS
	UPDATE PlanesEstudiosAsignaturasCargasHorariasInasistencias
		SET IdInasistencia = TA.IdInasistencia
	FROM #InasistenciasNuevo TA
	WHERE PlanesEstudiosAsignaturasCargasHorariasInasistencias.IdPlanEstudiosAsignaturaCargaHoraria = TA.PlanEstudiosAsignaturaCargaHorariaId

END
GO



--EXEC InsertarPlanesEstudiosAsignaturasCargasHorariasInasistencias '01/2017', '31/01/2017', 'INGENIERIA DE SISTEMAS', 'M', '2974-4'
EXEC InsertarPlanesEstudiosAsignaturasCargasHorariasInasistencias '02/2017', '04/12/2017', 'INGENIERIA EN DISEÑO Y ANIMACION DIGITAL', 'M', '4222-3'


EXEC InsertarPlanesEstudiosAsignaturasCargasHorariasInasistencias '01/2017', '24/03/2017', 'INGENIERIA DE SISTEMAS', 'M', '2420-3, 2861-4, 2889-2'


4222
delete from PlanesEstudiosAsignaturasCargasHorariasInasistencias
select * from PlanesEstudiosAsignaturasCargasHorariasInasistencias