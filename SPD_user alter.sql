USE [Register]
GO
/****** Object:  StoredProcedure [dbo].[SPD_User]    Script Date: 9/3/2024 3:20:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SPD_User]
@SignUp_id int 
as
begin
begin tran
delete from RegisterForm where SignUp_id = @SignUp_id  ;
commit tran 
end
