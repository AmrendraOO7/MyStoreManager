


insert into msm.ProductInventory sum(select Quantity from MSM.ProductInventory where prodID = )

select * from msm.ProductInventory

insert into MSM.ProductInventory (prodID,Quantity,AlternateQuantity,UnitID,AltUnitID,ActiveStatus) values(1,10,1,1,2,1);


select * from msm.UnitMaster;
select * from msm.ProductInventory
select * from msm.ProductMaster

update MSM.ProductInventory set Quantity = ((select Quantity from MSM.ProductInventory where prodID = 1) + 5) where prodID = 1; 
update MSM.ProductInventory set AlternateQuantity = ((select Quantity from MSM.ProductInventory where prodID = 1) / (select UnitQnty from msm.ProductMaster where PID = 1));
select * from msm.ProductInventory