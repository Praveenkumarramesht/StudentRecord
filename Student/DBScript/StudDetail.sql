select  * from StudDetail

go
 create procedure Insertdetail (@Name nvarchar(Max),@DOB datetime2(7),@age int,@Gender nvarchar(Max),@MobileNum bigint,@Email nvarchar(Max),@Subject nvarchar(Max))
 AS
 BEGIN
 INSERT INTO StudDetail values(@Name,@DOB,@age,@Gender,@MobileNum,@Email,@Subject)
 END
 exec Insertdetail 'madhan','05/05/2002',23,'Male',99999999999,'madhan@gmail.com','English'
 
 drop procedure Insertdetail
