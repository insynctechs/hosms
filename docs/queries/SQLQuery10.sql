USE [hospitalERP_db]
GO
select * from Bill_Status
select * from Bill_Types
DECLARE	@return_value int

EXEC	@return_value = [dbo].[uspReport_Billing]
		@fromDate = N'01-12-2017',
		@toDate = N'03-03-2018',
		@bill_type = 1

SELECT	'Return Value' = @return_value

GO
