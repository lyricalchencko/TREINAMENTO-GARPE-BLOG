SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--remove a procedure para ser recriada
IF EXISTS(SELECT 1 FROM sys.procedures WHERE Name = 'STP_USUARIO_CONSULTAR')
    DROP PROCEDURE dbo.STP_USUARIO_CONSULTAR
GO

CREATE PROCEDURE STP_USUARIO_CONSULTAR
	@DS_EMAIL VARCHAR(150), 
	@NM_USUARIO VARCHAR(100)
AS
SET NOCOUNT ON;
--INICIO CODIGO

	DECLARE @CONSULTA VARCHAR(MAX)
	
	SET @CONSULTA = ' SELECT USU.* ' +
                    ' FROM TB_USUARIO USU WITH(NOLOCK) ' +
                    ' WHERE USU.SQ_USUARIO = USU.SQ_USUARIO '

	IF @NM_USUARIO <> ''
	    SET @CONSULTA = @CONSULTA + ' AND USU.NM_USUARIO = ' + @NM_USUARIO

	IF @DS_EMAIL <> ''
	    SET @CONSULTA = @CONSULTA + ' AND USU.DS_EMAIL = ' + @DS_EMAIL

	EXEC (@CONSULTA)
  
--FIM
SET NOCOUNT OFF
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO