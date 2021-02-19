
-- =============================================
-- Author:		Roberto Alvarado
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE Add_Addresses 
  @Calle			nvarchar(5)		= NULL
, @Carrera			nvarchar(5)		= NULL
, @Numero			nvarchar(15)	= NULL
, @Adicional		nvarchar(50)	= NULL
, @AddressActive	bit				= NULL
, @CreateAt			datetime2(7)	= NULL
, @UserCreated		nvarchar(max)	= NULL
, @UpadtedAt		datetime2(7)	= NULL
, @UserLastUpdated	 nvarchar(max)	= NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

INSERT INTO dbo.Addresses
           (Calle
           ,Carrera
           ,Numero
           ,Adicional
           ,AddressActive
           ,CreateAt
           ,UserCreated
           ,UpadtedAt
           ,UserLastUpdated)
     VALUES
           (@Calle,			
            @Carrera,		
            @Numero,		
            @Adicional,		
            @AddressActive, 
            @CreateAt,		
            @UserCreated,	
            @UpadtedAt,		
            @UserLastUpdated)


	SELECT SCOPE_IDENTITY();
END
GO
