
-- =============================================
-- Author:		Roberto Alvarado
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE Delete_Address
	-- Add the parameters for the stored procedure here
  @AddressId        int             = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
DELETE FROM [dbo].[Addresses]
      WHERE AddressId = @AddressId



END
GO