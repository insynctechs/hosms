USE [hospitalERP_db]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[uspReport_Patient]
		@fromDate = N'1/12/2017',
		@toDate = N'4/4/2018',
		@SearchBy ='ALL',
		@SearchValue = ''

SELECT	'Return Value' = @return_value

GO
