SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--remove a procedure para ser recriada
IF EXISTS(SELECT 1 FROM sys.procedures WHERE Name = 'STP_USUARIO_ALTERAR')
    DROP PROCEDURE dbo.STP_USUARIO_ALTERAR
GO

CREATE PROCEDURE STP_USUARIO_ALTERAR
	@SQ_USUARIO int,
    @NM_USUARIO VARCHAR(200),
    @DS_EMAIL VARCHAR(200),
    @DS_SENHA VARCHAR(15)
AS
SET NOCOUNT ON;
--INICIO CODIGO

    DECLARE @SQ_REGISTRO_ENCONTRADO INT

    SET @SQ_REGISTRO_ENCONTRADO = (SELECT TOP 1 SQ_USUARIO 
                                   FROM TB_USUARIO
                                   WHERE SQ_USUARIO = @SQ_USUARIO)

    IF @SQ_REGISTRO_ENCONTRADO IS NULL 
    BEGIN
        SELECT 'Aviso' AS CT_TIPO, 'Usuário não encontrado' AS CT_MENSAGEM
    END

	DECLARE @SQ_USUARIO_EMAIL_DUP INT
			--validar se o email e unico no banco
	SET @SQ_USUARIO_EMAIL_DUP = (SELECT TOP 1 SQ_USUARIO FROM TB_USUARIO USU WITH(NOLOCK) WHERE USU.DS_EMAIL = @DS_EMAIL)

	IF @SQ_USUARIO_EMAIL_DUP IS NOT NULL
	BEGIN
		SELECT 'Aviso' AS CT_TIPO, 'Email já cadastrado' AS CT_MENSAGEM
	END
	ELSE
	BEGIN
			UPDATE TB_USUARIO
			SET NM_USUARIO = @NM_USUARIO, DS_EMAIL = @DS_EMAIL, DS_SENHA = @DS_SENHA
			WHERE SQ_USUARIO = @SQ_USUARIO

			-- retorno da procedure
			SELECT 'Sucesso' AS CT_TIPO, 'Registro incluido com sucesso' AS CT_MENSAGEM
	END

--FIM
SET NOCOUNT OFF
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO