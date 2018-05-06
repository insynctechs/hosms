USE [hospitalERP_db]
GO
/****** Object:  StoredProcedure [dbo].[uspAppointments_Add]    Script Date: 07-05-2018 03:03:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[uspAppointments_Add] @patient_id int, @doctor_id int, @meet_date datetime, @status smallint As
 DECLARE @Ret int;
 DECLARE @token int;
 DECLARE @prev_id int;
 DECLARE @prev_date datetime;
 SET @Ret = -1;
 IF Exists (SELECT 1 FROM Appointments WHERE patient_id = @patient_id AND doctor_id=@doctor_id AND meet_date=@meet_date AND status=@status)
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

 USE [hospitalERP_db]
GO
/****** Object:  StoredProcedure [dbo].[uspAppointments_GetForDateDoc]    Script Date: 07-05-2018 03:04:33 ******/
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
LEFT JOIN Billing b ON a.prev_id=b.appointment_id
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

USE [hospitalERP_db]
GO
/****** Object:  StoredProcedure [dbo].[uspConsultationDet_SaveDiagnosis]    Script Date: 07-05-2018 03:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[uspConsultationDet_SaveDiagnosis] @appointment_id int,@patient_id int, @history text,  @allergies text, @notes text, @status int
 AS 
 Declare @Ret int;
 Set @Ret = -1; 
  Begin
   Update Patients Set [history] = @history, [allergies]=@allergies WHERE [id]=@patient_id 
   Update Appointments set [notes]=@notes, [status]=@status WHERE id=@appointment_id
   --when appointment status is completed check whether the patient has another appointment scheduled on the same day
   -- with status != completed and cancelled
   -- if so set its prev appointment to this id
   DECLARE @meet_date datetime;
   SELECT @meet_date = meet_date From Appointments WHERE id=@appointment_id;
   
   if(@status=2) 
   BEGIN
	UPDATE Appointments set [prev_id]=@appointment_id, [prev_date] = @meet_date, modified_date = GETDATE()
	WHERE meet_date=@meet_date AND id<>@appointment_id AND status <>2 AND status <>7;
   END  
   ---------- end -----------
   set @Ret = 1;
  End
SELECT @Ret


USE [hospitalERP_db]
GO
/****** Object:  StoredProcedure [dbo].[uspBill_Add]    Script Date: 07-05-2018 03:05:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


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
	SELECT @bill_due = bill_balance FROM Billing WHERE appointment_id IN (SELECT prev_id FROM Appointments WHERE id=@appointment_id)

	INSERT INTO dbo.Billing(appointment_id,bill_number,bill_date,patient_id,bill_amount,bill_paid,bill_balance,bill_type,bill_status, bill_created_userid, bill_due)
	VALUES(@appointment_id,@billnum,GETDATE(),@patient_id,@bill_amount,0,@bill_amount,@bill_type,1,@user_id,@bill_due);

	SELECT @id = SCOPE_IDENTITY();
	
	SET @Ret = @id;
	

SELECT @Ret;


USE [hospitalERP_db]
GO
/****** Object:  StoredProcedure [dbo].[uspPatients_GetDetailed]    Script Date: 07-05-2018 03:06:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[uspPatients_GetDetailed] @id int, @aid int AS
BEGIN

DECLARE @visit_date Datetime;
SET @visit_date = NULL;

DECLARE @app_id int;
SET @app_id = 0;

DECLARE @doctor_id int;
SET @doctor_id = 0;

DECLARE @doctor_name VARCHAR(50);
SET @doctor_name = NULL;

DECLARE @dues decimal(10,3)
SET @dues = 0;

DECLARE @doc_fee decimal(10,3)
SET @doc_fee = 0;

DECLARE @token int
SET @token = 0;


IF(@aid > 0)
 BEGIN
 SET @app_id = @aid;
 --SELECT TOP 1 @dues=isnull(bill_balance,0) FROM Billing WHERE appointment_id<@aid AND patient_id=@id ORDER BY id DESC
 END
ELSE
 BEGIN
 SELECT @app_id = MAX(id) FROM Appointments WHERE patient_id=@id AND [Status] IN (2) GROUP BY patient_id; 
 --SELECT  TOP 1 @dues=isnull(bill_balance,0) FROM Billing WHERE appointment_id<@app_id AND patient_id=@id ORDER BY id DESC  
 END
IF(@app_id > 0)
 BEGIN
 SELECT @visit_date=a.meet_date, @doctor_id=d.id, @doctor_name=dbo.svf_FormatDrName( d.first_name,d.last_name), @doc_fee=d.consultation_fee, @token=a.token FROM Appointments a JOIN Doctors d ON a.doctor_id=d.id WHERE a.id=@aid;
 END

SELECT *, dbo.svf_FormatName(first_name, last_name) as patient_name, dbo.svf_GetAge(dob) as age,
@visit_date as meet_date, @app_id as appointment_id, @doctor_id as doctor_id,@doctor_name as doctor_name, @doc_fee as doctor_fee,/* ISNULL(@dues,0) as dues,*/ @token as token 
 FROM Patients WHERE id=@id ;
END


USE [hospitalERP_db]
GO
/****** Object:  StoredProcedure [dbo].[uspBillDetails_Add]    Script Date: 07-05-2018 03:06:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[uspBillDetails_Add]
  @List AS dbo.BillDetails READONLY, @appId int
AS
BEGIN
  SET NOCOUNT ON;
  DECLARE @Ret int;
  SET @Ret = 0;
  DELETE FROM dbo.Billing_Details WHERE appointment_id=@appId;
  
  INSERT INTO dbo.Billing_Details SELECT appointment_id, item_no, item_name, item_amount, billing_id FROM @List; 
  SET @Ret = 1;
  SELECT @Ret;
END
