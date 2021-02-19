

-- =============================================
-- Author:		Roberto Alvarado
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE Update_Addresses
  @AddressId        int             = NULL
, @Calle			nvarchar(5)		= NULL
, @Carrera			nvarchar(5)		= NULL
, @Numero			nvarchar(15)	= NULL
, @Adicional		nvarchar(50)	= NULL
, @AddressActive	bit				= NULL
, @UpadtedAt		datetime2(7)	= NULL
, @UserLastUpdated	 nvarchar(max)	= NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

UPDATE dbo.Addresses
   SET Calle			=  @Calle			
      ,Carrera			=  @Carrera			
      ,Numero			=  @Numero			
      ,Adicional		=  @Adicional		
      ,AddressActive	=  @AddressActive	
      ,UpadtedAt		=  @UpadtedAt		
      ,UserLastUpdated	=  @UserLastUpdated
 WHERE AddressId = @AddressId


END
