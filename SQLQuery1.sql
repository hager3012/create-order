create database Task_Orders;
create Table Orders(
   orderId int primary key Identity(1,1),
   orderDate Date ,
   customerName varchar(50),
   Total decimal(18,2)
   );
create Table  orderDetails  (
   orderDetailsID int primary key Identity(1,1),
   orderId int ,
   productName varchar(50),
   quantity int ,
   price decimal(18,2),
   Foreign Key (orderId) References Orders(orderId)
   );
   create Type  orderDetailsType As Table(
   productName varchar(50),
   quantity int ,
   price decimal(18,2)
   );
 Go 
-- Create Stored Procedure For Insert Into Tables Orders and ordersDetails
Create Or Alter Procedure Sp_InsertOrderWithDetails
   @CustomerName varchar(50),
   @OrderDate Date ,
   @OrderTotal decimal,
   @OrderDetails orderDetailsType Readonly
As
  Begin
       Begin Try
	         Begin Transaction 
			     -- Insert Order Table
					 Insert Into Orders (customerName , orderDate,Total)
					 Values(@CustomerName,@OrderDate,@OrderTotal)
                 -- Insert Order Details Table
				 Declare @InsertedOrder int = Scope_Identity();
					 Insert Into orderDetails(orderId,productName,quantity,price)
					 Select @InsertedOrder ,OD.productName, OD.quantity, OD.price
					 From @OrderDetails As OD
					 Join Orders O ON @InsertedOrder = O.orderId
			 Commit Transaction 
			 Select 'Success' As Status
		End Try
		Begin Catch 
		    If @@TRANCOUNT > 0 
			   RollBack Transaction 

			   Select 'Error' + ERROR_MESSAGE() As Status
	    End Catch
  End
		
GO