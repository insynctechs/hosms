USE [hospitalERP_db]
GO
/****** Object:  StoredProcedure [dbo].[uspReport_Billing]    Script Date: 01-02-2018 11:58:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[uspReport_Billing]  @fromDate DateTime = '', @toDate DateTime ='', @bill_type int = 0,
@bill_status int =0  AS
BEGIN
SELECT b.bill_date, b.bill_number, b.bill_amount, dbo.svf_FormatName(p.first_name, p.last_name) as patient_name, 
dbo.svf_FormatDrName(d.first_name,d.last_name) as doctor_name, bs.name as status, bt.name as type
FROM Billing b JOIN Bill_Status bs ON bs.id=b.bill_status JOIN Bill_Types bt ON bt.id=b.bill_type
LEFT JOIN Appointments a ON a.id=b.appointment_id 
LEFT JOIN Doctors d ON d.id=a.doctor_id LEFT JOIN Patients p ON  p.id=a.patient_id WHERE 
b.bill_date>=@fromDate AND b.bill_date<=@toDate  
AND b.bill_type = case when @bill_type>0  then @bill_type else b.bill_type END 
AND b.bill_status = case when @bill_status>0  then @bill_status else b.bill_status END 
ORDER BY b.bill_date DESC;
END
GO
