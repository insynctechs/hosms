USE [hospitalERP_db]
GO
/****** Object:  StoredProcedure [dbo].[uspAppointments_GetForDateDoc]    Script Date: 24-07-2018 13:09:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[uspAppointments_GetForDateDoc] @meet_date datetime, @doctor_id int, @status smallint AS
BEGIN
DECLARE @sql VARCHAR(max);
DECLARE @max_id int;

SELECT @max_id = isnull(max(id),0) FROM Appointments where meet_date=@meet_date;

SET @sql = 'SELECT a.id, a.patient_id,  a.doctor_id,a.prev_date, p.patient_number, dbo.svf_FormatName(p.first_name, p.last_name) as patient_name, dbo.svf_FormatDrName(d.first_name,d.last_name)  as doctor_name, a.token, ISNULL(b.bill_balance,0) as dues, s.name as status, s.id as status_id  
FROM Appointments a 
JOIN Patients p ON a.patient_id=p.id 
JOIN Doctors d ON d.id=a.doctor_id 
JOIN Appointment_Status s on a.status=s.id 
LEFT JOIN Billing b ON a.prev_id=b.appointment_id AND b.bill_status!=5
WHERE a.meet_date='''+ CAST(@meet_date AS varchar(20))+'''';

--id<>'''+CAST(@max_id AS varchar(20))+''' AND 
IF(@doctor_id >0)
BEGIN
SET @sql = @sql + ' AND  doctor_id =''' + CAST(@doctor_id AS varchar(20)) + '''';
END
IF(@status >0)
BEGIN
SET @sql = @sql + ' AND status =''' + CAST(@status AS varchar(20)) + ''' ';
END
SET @sql = @sql + ' ORDER BY id,patient_number';
PRINT @sql;
EXEC(@sql);
END




ALTER PROCEDURE [dbo].[uspBill_Add] @appointment_id int, @patient_id int, @bill_amount decimal(10,3), @bill_type  int, @user_id int 
AS
	SET NOCOUNT ON;
	DECLARE @id AS int;
	DECLARE @billid AS int;	
	DECLARE @Ret int;
	SET @Ret = -1;
	
	DECLARE @prefix varchar(20);
	DECLARE @billnum varchar(20);
	
	SELECT @billid=(ISNULL(MAX(id),0)+ 1) From Billing;
	SELECT @prefix = op_value FROM Options WHERE op_name = 'BILLNUM_PREFIX'; 
	
	DECLARE @start int;
	SELECT   @start = TRY_CAST (op_value AS INT) FROM Options WHERE op_name= 'BILLNUM_START'; 
	
	SET @billid = @billid+@start;
	SET @billnum = @prefix + cast(@billid as varchar);	

	DECLARE @bill_due decimal(10,3);
	SELECT @bill_due = bill_balance FROM Billing WHERE bill_status!=5 AND appointment_id IN (SELECT prev_id FROM Appointments WHERE id=@appointment_id) 

	INSERT INTO dbo.Billing(appointment_id,bill_number,bill_date,patient_id,bill_amount,bill_paid,bill_balance,bill_type,bill_status, bill_created_userid, bill_due)
	VALUES(@appointment_id,@billnum,GETDATE(),@patient_id,@bill_amount,0,@bill_amount,@bill_type,1,@user_id,@bill_due);

	SELECT @id = SCOPE_IDENTITY();
	
	SET @Ret = @id;
	

SELECT @Ret;


ALTER PROCEDURE [dbo].[uspAppointments_Add] @patient_id int, @doctor_id int, @meet_date datetime, @status smallint As
 DECLARE @Ret int;
 DECLARE @token int;
 DECLARE @prev_id int;
 DECLARE @prev_date datetime;
 SET @Ret = -1;
 IF Exists (SELECT 1 FROM Appointments WHERE patient_id = @patient_id AND doctor_id=@doctor_id AND meet_date=@meet_date AND status NOT IN (2,5)) /*AND status=@status*/
 BEGIN
  SET @Ret = 0;  
 END
 ELSE
 BEGIN
 SELECT @token=(ISNULL(MAX(token),0)+ 1) From Appointments WHERE meet_date=@meet_date AND doctor_id=@doctor_id;
 SELECT @prev_id= (ISNULL(MAX(id),0)) From Appointments WHERE meet_date<=@meet_date AND patient_id=@patient_id AND status=2;
 IF @prev_id>0
 BEGIN
 SELECT @prev_date= meet_date From Appointments WHERE id=@prev_id;
 END
 INSERT INTO Appointments(patient_id, doctor_id, meet_date,token, [status], prev_id, prev_date, added_date, modified_date)
  Values (@patient_id,@doctor_id,@meet_date,@token,@status,@prev_id,@prev_date,getdate(),getdate());
 SET @Ret = SCOPE_IDENTITY();
 End
 SELECT @Ret


 ALTER PROCEDURE [dbo].[uspAppointments_Cancel] @id int, @patient_id int, @status smallint As
	DECLARE @Ret int;	
	DECLARE @isDeleteStatus bit;
	SET @Ret = -1;
	SELECT @isDeleteStatus = delete_lock FROM Appointment_Status WHERE id=@status;
	BEGIN
	IF @status = 0
	BEGIN
		SET @Ret = -2;
	END
	ELSE IF EXISTS (SELECT 1 FROM Patient_Procedures WHERE appointment_id=@id AND patient_id=@patient_id)
	BEGIN
		SET @Ret = -3;		
	END
	ELSE IF EXISTS (SELECT 1 FROM Patient_Medicines WHERE appointment_id=@id AND patient_id=@patient_id)
	BEGIN
		SET @Ret = -5;		
	END	
	ELSE IF EXISTS (SELECT 1 FROM Billing WHERE appointment_id=@id AND patient_id=@patient_id)
	BEGIN
		SET @Ret = -4;		
	END
	ELSE
	BEGIN	
	UPDATE Appointments SET status=7 WHERE id=@id;		
	SET @Ret = @@ROWCOUNT;
	END
	END
	SELECT @Ret


	ALTER PROCEDURE [dbo].[uspAppointments_Delete] @id int, @patient_id int, @status smallint As
 DECLARE @Ret int; 
 DECLARE @isDeleteStatus bit;
 SET @Ret = -1;
 SELECT @isDeleteStatus = delete_lock FROM Appointment_Status WHERE id=@status;
 BEGIN
 IF @status = 0
 BEGIN
  SET @Ret = -2;
 END
 ELSE IF EXISTS (SELECT 1 FROM Patient_Procedures WHERE appointment_id=@id AND patient_id=@patient_id)
 BEGIN
  SET @Ret = -3;  
 END
 ELSE IF EXISTS (SELECT 1 FROM Billing WHERE appointment_id=@id AND patient_id=@patient_id)
 BEGIN
  SET @Ret = -4;  
 END
 ELSE IF EXISTS (SELECT 1 FROM Patient_Medicines WHERE appointment_id=@id AND patient_id=@patient_id)
	BEGIN
		SET @Ret = -5;		
	END	
 ELSE
 BEGIN 
 UPDATE Appointments SET status=7 WHERE id=@id;  
 SET @Ret = @@ROWCOUNT;
 END
 END
 SELECT @Ret


 ALTER PROCEDURE [dbo].[uspBill_Edit] @id int, @amount decimal(10,3), @paid decimal(10,3), @balance decimal(10,3), @status int, @user int
 AS 

 DECLARE @Ret int;
 DECLARE @appointment_id int;
 SELECT @appointment_id = appointment_id FROM Billing WHERE id=@id;

 DECLARE @bill_due decimal(10,3);
 SELECT @bill_due = bill_balance FROM Billing WHERE bill_status!=5 AND appointment_id IN (SELECT prev_id FROM Appointments WHERE id=@appointment_id)

 SET @Ret = -1;
 UPDATE Billing SET bill_date=GETDATE(), bill_amount=@amount, bill_paid=@paid, bill_balance=@balance, bill_status=@status, bill_created_userid=@user, bill_due=@bill_due  WHERE [id]=@id 
 
 SET @Ret = @@ROWCOUNT; 
SELECT @Ret



ALTER PROCEDURE [dbo].[uspBill_Add] @appointment_id int, @patient_id int, @bill_amount decimal(10,3), @bill_type  int, @user_id int 
AS
	SET NOCOUNT ON;
	DECLARE @id AS int;
	DECLARE @billid AS int;	
	DECLARE @Ret int;
	SET @Ret = -1;
	
	DECLARE @prefix varchar(20);
	DECLARE @billnum varchar(20);
	
	SELECT @billid=(ISNULL(MAX(id),0)+ 1) From Billing;
	SELECT @prefix = op_value FROM Options WHERE op_name = 'BILLNUM_PREFIX'; 
	
	DECLARE @start int;
	SELECT   @start = TRY_CAST (op_value AS INT) FROM Options WHERE op_name= 'BILLNUM_START'; 
	
	SET @billid = @billid+@start;
	SET @billnum = @prefix + cast(@billid as varchar);	

	DECLARE @bill_due decimal(10,3);
	SELECT @bill_due = bill_balance FROM Billing WHERE bill_status!=5 AND appointment_id IN (SELECT prev_id FROM Appointments WHERE id=@appointment_id) 

	IF @bill_due>0 
	BEGIN
		SET @bill_amount = @bill_amount+@bill_due;
	END

	INSERT INTO dbo.Billing(appointment_id,bill_number,bill_date,patient_id,bill_amount,bill_paid,bill_balance,bill_type,bill_status, bill_created_userid, bill_due)
	VALUES(@appointment_id,@billnum,GETDATE(),@patient_id,@bill_amount,0,@bill_amount,@bill_type,1,@user_id,@bill_due);

	SELECT @id = SCOPE_IDENTITY();
	
	SET @Ret = @id;
	

SELECT @Ret;


ALTER PROCEDURE [dbo].[uspConsultationDet_Get] @id int 
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	
	
	SELECT a.*, dbo.svf_FormatName(d.first_name, d.last_name) as doctor_name,  p.id as patient_id ,p.patient_number , dbo.svf_FormatName(p.first_name, p.last_name) as patient_name
,p.gender, p.nationality, p.phone, p.dob, p.address, p.city, p.state, p.zip, dbo.svf_GetAge(p.dob) as age, p.history, p.allergies, CONVERT(date, am.prev_date) as prev_date,ISNULL(b.bill_balance,0) as dues, a.meet_date as appointment_date, ast.name as status_name, ast.edit_lock as status_edit_lock ,
ref_doc.referred_doctor_name
FROM Appointments a 
JOIN Patients p ON a.patient_id=p.id 
JOIN Doctors d ON d.id=a.doctor_id 
JOIN Appointment_Status ast ON a.status = ast.id
LEFT JOIN (SELECT patient_id, MAX(meet_date) as prev_date FROM Appointments  WHERE id!=@id AND status IN (2) GROUP BY patient_id) as am ON am.patient_id=a.patient_id 
/*LEFT JOIN (SELECT patient_id, bill_balance FROM Billing WHERE appointment_id IN (SELECT MAX(id) FROM Appointments WHERE bill_status=2 OR bill_status=3 GROUP BY patient_id)) as b ON b.patient_id=a.patient_id  */
LEFT JOIN Billing b ON a.prev_id=b.appointment_id AND b.bill_status!=5

LEFT JOIN (SELECT id, dbo.svf_FormatName(first_name, last_name) as referred_doctor_name FROM Doctors ) as ref_doc ON ref_doc.id=a.refer_by_doctor_id
WHERE a.id=@id;

END

