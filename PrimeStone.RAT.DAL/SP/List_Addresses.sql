

-- =============================================
-- Author:		Roberto Alvarado
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[List_Addresses] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

SELECT AddressId
      ,Calle
      ,Carrera
      ,Numero
      ,Adicional
      ,AddressActive
      ,CreateAt
      ,UserCreated
      ,UpadtedAt
      ,UserLastUpdated
  FROM Addresses

END
