USE QBAlmacenes10

DROP FUNCTION VerificarUsuario
GO

CREATE FUNCTION VerificarUsuario(@NombreUsuario CHAR(32), @Contrasena CHAR(32))
RETURNS INT
AS
BEGIN
	DECLARE @CodigoUsuario INT
	
	SELECT @CodigoUsuario = CodigoUsuario
	FROM Usuarios U
	WHERE U.NombreUsuario = @NombreUsuario
	AND U.Contrasena = @Contrasena
	
	RETURN ISNULL(@CodigoUsuario, 0)
END 
GO


