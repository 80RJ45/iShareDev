go
drop proc spBiometricLogInsert
go
create proc spBiometricLogInsert @biometricLogID int,@uid int, @user_id int,@timestamp datetime,@type int,@state int
as
	select @biometricLogID = ISNULL(max(biometriclogID),0)+1 from BiometricLog

	insert into BiometricLog values
	(@biometricLogID,@uid,@user_id,@timestamp,@type,@state)
go

