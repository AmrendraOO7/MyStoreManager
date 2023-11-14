
DECLARE @prodID int = 1
DECLARE @IncQuantity decimal(16,8) = 5
DECLARE @Quantity decimal(16,8) = (select UnitQnty from MSM.ProductMaster where PID = @prodID);
DECLARE @altQuantity decimal(16,8) = (select AltUnitQnty from MSM.ProductMaster where PID = @prodID);

if @Quantity = @altQuantity 
	Begin update MSM.ProductInventory set Quantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID) + @IncQuantity) where prodID = @prodID end; 
	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID)) End;

if @Quantity > @altQuantity 
	Begin update MSM.ProductInventory set Quantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID) + @IncQuantity) where prodID = @prodID end; 
	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID) / (select UnitQnty from msm.ProductMaster where PID = @prodID)) End;

if @Quantity < @altQuantity  
	Begin update MSM.ProductInventory set Quantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID) + @IncQuantity) where prodID = @prodID end; 
	Begin update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = @prodID) * (select AltUnitQnty from msm.ProductMaster where PID = @prodID)) End;
