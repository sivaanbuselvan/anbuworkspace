create procedure insert_user
@email_id nvarchar(50),
@password nvarchar(50)
as 
begin
begin tran
insert into RegisterForm values (@email_id,@password)
commit tran
end 

use Register

create procedure SPD_User
@SignUp_id int 
as
begin
begin tran
delete from RegisterForm where SignUp_id = @SignUp_id  ;
commit tran 
end


exec DeleteUser 3;
select * from RegisterForm;

create procedure SPI_Student

select * from studentDetails;

alter table studentDetails
add UG_or_PG nvarchar(10) not null

alter table studentDetails
add percentage number(4,2) not null