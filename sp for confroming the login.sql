USE [Register]
GO
/****** Object:  StoredProcedure [dbo].[loginCheck]    Script Date: 9/2/2024 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure  [dbo].[loginCheck]
@email_id nvarchar(20) ,
@password nvarchar(20)
as
begin
select count(*) from RegisterForm where @email_id=email_id and  @password=password;
end

insert into RegisterForm
values('anbu123@gmail.com','amma@123','amma@123');
select * from RegisterForm

exec logincheck 'anbu123@gmail.com','amma@123'