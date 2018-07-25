USE [hospitalERP_db]
GO

CREATE TABLE [dbo].[Medicine_Types](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type_name] [varchar](max) NOT NULL,
	[description] [text] NOT NULL,
	[active] [bit] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


CREATE TABLE [dbo].[Medicines](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](max) NOT NULL,
	[prescription] [text] NOT NULL,
	[type] [int] NOT NULL,	
	[active] [bit] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO




CREATE TABLE [dbo].[Patient_Medicines](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[patient_id] [int] NULL,
	[doctor_id] [int] NULL,
	[appointment_id] [int] NULL,
	[medicine_id] [int] NULL,
	[prescription] [text] NULL,
 CONSTRAINT [PK_Patient_Medicines] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO




create procedure [dbo].[uspMedicineTypes_Get] @SearchBy varchar(50), @SearchValue varchar(100) as
begin
declare @sql nvarchar(max);
set @sql = 'select id, type_name, description,active from Medicine_Types';
if(@SearchBy <> 'All')
begin
set @sql = @sql + ' where ' + @SearchBy + ' like ''' + @SearchValue + '%''';
end
exec(@sql);
end

GO






CREATE PROCEDURE [dbo].[uspMedicineTypes_Add] @type_name Varchar(max), @description text, @active bit AS
	Declare @Ret int; 
	Set @Ret = -1;
	If Exists (Select 1 From Medicine_Types Where type_name = @type_name)
	Begin
		Set @Ret = 0;
		return;
	End
	Else
	Begin
	Insert Into Medicine_Types (type_name, description, active)
		Values (@type_name, @description, @active);
	set @Ret = 1;
	End
	Select @Ret;
GO


CREATE PROCEDURE [dbo].[uspMedicineTypes_Combo] @id int 
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @sql varchar(max);
	
	SET @sql = 'SELECT id, type_name from Medicine_Types WHERE Active = 1';
	
	IF(@id > 0)
	BEGIN
	SET @sql = @sql + ' OR  id=''' +   CAST(@id AS varchar(30)) + '''';
	END

	SET @sql = @sql + ' ORDER BY Active, type_name';

	EXEC(@sql);
	
END
GO




CREATE PROCEDURE [dbo].[uspMedicineTypes_Edit] @id int, @name Varchar(max),  @desc text, @active bit
	AS	
	Declare @Ret int;
	Set @Ret = -1;
	If Exists (Select 1 From Medicine_Types Where type_name = @name and id <> @id)
		Begin
			Set @Ret = 0;		
		End
	Else
		Begin
			Update Medicine_Types Set [type_name] = @name, [description]=@desc, active=@active WHERE [id]=@id 
			set @Ret = 1;
		End
SELECT @Ret
GO

CREATE PROCEDURE [dbo].[uspMedicines_Add] @name Varchar(max),  @desc text, @type int, @active bit
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Declare @Ret int;
	Set @Ret = -1;
	If Exists (Select 1 From dbo.Medicines Where name = @name)
	Begin
		Set @Ret = 0;
		return;
	End
	Else
	Begin
	Insert Into dbo.Medicines(name,prescription,type, active)
		Values (@name,@desc,@type, @active);
	set @Ret = 1;
	End
	select @Ret
	
END
GO


CREATE PROCEDURE [dbo].[uspMedicines_Get] @SearchBy varchar(50), @SearchValue varchar(100) 
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @sql nvarchar(max);
	DECLARE @fee decimal;
	
	SET @sql = 'SELECT p.id, p.name, p.prescription, p.type, t.type_name, p.active from Medicines p JOIN Medicine_Types t ON t.id=p.type ';
	
	IF(@SearchBy <> 'All')
	BEGIN
	SET @sql = @sql + ' WHERE ' + @SearchBy + ' like ''' + @SearchValue + '%''';
	END
	
	EXEC(@sql);
	
END
GO


CREATE PROCEDURE [dbo].[uspMedicines_Edit] @id int, @name Varchar(max),  @desc text, @type int, @active bit
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   DECLARE @Ret int;
	SET @Ret = -1;
	IF Exists (SELECT 1 FROM dbo.[Medicines] WHERE [name] = @name and id <> @id)
		BEGIN
			SET @Ret = 0;		
		END
	ELSE
		BEGIN
			UPDATE dbo.[Medicines] SET [name] = @name, [prescription]=@desc, type=@type, active=@active WHERE [id]=@id 
			SET @Ret = 1;
		END
SELECT @Ret
	
END
GO


CREATE PROCEDURE [dbo].[uspMedicines_Single] @id int 
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	
	
	SELECT p.*, t.type_name FROM dbo.[MEDICINES] p JOIN dbo.medicine_types t ON t.id=p.type WHERE p.id=@id
	
END
GO


CREATE PROCEDURE [dbo].[uspMedicines_PatientAppt_Get] @id int 
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	
	
	SELECT pm.*, mt.type_name as medicine_type, m.name as medicine_name from Patient_Medicines pm LEFT JOIN  Medicines m ON m.id=pm.medicine_id LEFT JOIN Medicine_Types mt ON mt.id=m.type 
	WHERE pm.appointment_id = @id
	
	
	
END



CREATE PROCEDURE [dbo].[uspMedicines_AddPatientMedicines] @patient_id int,@doctor_id int, @appointment_id int,  @medicine_id int, @prescription text
	AS	
	Declare @Ret int;
	Set @Ret = -1;	
	Begin
			INSERT INTO Patient_Medicines (patient_id, doctor_id, appointment_id, medicine_id, prescription)
		Values (@patient_id, @doctor_id, @appointment_id, @medicine_id, @prescription);
		set @Ret = 1;
	End
	select @Ret



CREATE PROCEDURE [dbo].[uspMedicines_Combo] @id int 
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @sql varchar(max);
	
	SET @sql = 'SELECT id, name from Medicines WHERE active = 1';
	
	IF(@id > 0)
	BEGIN
	SET @sql = @sql + ' OR  id=''' +   CAST(@id AS varchar(30)) + '''';
	END

	SET @sql = @sql + ' ORDER BY active, name';

	EXEC(@sql);
	
END

CREATE PROCEDURE [dbo].[uspMedicines_GetPrescription] @id int 
AS
BEGIN
	SET NOCOUNT ON;	
	
	DECLARE @prescription as varchar(max), @type as varchar(100)
	SELECT @prescription = m.prescription, @type=mt.type_name FROM dbo.[Medicines] m JOIN dbo.Medicine_Types mt ON mt.id=m.type  WHERE M.id=@id
	SELECT @prescription, @type
	
END
 


CREATE PROCEDURE [dbo].[uspMedicines_EditPatientMedicines] @id int,@patient_id int,@doctor_id int, @appointment_id int,  @medicine_id int, @prescription text
	AS	
	Declare @Ret int;
	Set @Ret = -1;	
	Begin
			UPDATE Patient_Medicines SET [patient_id]=@patient_id, [doctor_id]=@doctor_id, [appointment_id]=@appointment_id,
			medicine_id=@medicine_id, prescription=@prescription WHERE id=@id;
		
		set @Ret = 1;
	End
	select @Ret


ALTER PROCEDURE [dbo].[uspConsultationDet_Get_History] @id int , @patient_id int
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	
	
	SELECT a.id,a.meet_date, dbo.svf_FormatDrName(d.first_name,d.last_name) as doctor_name,a.notes , aps.name as status_name, 
	( SELECT m.name + ' : '+ CAST(pm.prescription as varchar(8000))  + ',  ' 
           FROM Patient_Medicines pm JOIN Medicines m ON m.id=pm.medicine_id
          WHERE pm.appointment_id=a.id FOR XML PATH(''),type).value('.', 'varchar(8000)') AS Prescription
FROM Appointments a JOIN Doctors d ON d.id=a.doctor_id 
LEFT JOIN Appointment_Status aps ON a.status=aps.id
WHERE /*a.id!=@id AND */a.patient_id=@patient_id ORDER BY meet_date DESC;

END


CREATE PROCEDURE [dbo].[uspGetBillLock] @app_id int As
	Declare @Ret int;
	Set @Ret = -1;
	SELECT @Ret =  id FROM Appointments WHERE prev_id=@app_id
	
	select @Ret


CREATE PROCEDURE [dbo].[uspMedicines_DeletePatientMedicines] @id int As
	Declare @Ret int;
	DELETE FROM Patient_Medicines WHERE id=@id
	SELECT @Ret =1

CREATE PROCEDURE [dbo].[uspProcedures_DeletePatientProcedures] @id int As
	Declare @Ret int;
	DELETE FROM Patient_Procedures WHERE id=@id
	SELECT @Ret =1

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
LEFT JOIN Billing b ON a.prev_id=b.appointment_id

LEFT JOIN (SELECT id, dbo.svf_FormatName(first_name, last_name) as referred_doctor_name FROM Doctors ) as ref_doc ON ref_doc.id=a.refer_by_doctor_id
WHERE a.id=@id;

END

INSERT INTO Menu_Items (parent_id, menu_name, menu_text, active, locked, menu_order) values( 5,'menuItemMedicine', 'Medicines',
  1,0,6);
INSERT INTO Menu_Items (parent_id, menu_name, menu_text, active, locked, menu_order) values( 5,'menuItemMedType', 'Medicine Types',
  1,0,8);