

select pd.PVNUM, pd.PName, pd.Purchase_OrderNo, FORMAT(pd.Quantiy,'N') AS Quantiy, 
FORMAT(pod.Quantiy ,'N') as orderQuantity, 
FORMAT((select sum(Quantiy) from msm.PurchaseDetails where Purchase_OrderNo = 'PO-2080-009' AND is_Deleted <> 1),'N')as totalReceived, 
FORMAT((select goods_quantity  from msm.PurchaseOrderMaster where POVNUM = 'PO-2080-009' AND is_Deleted <> 1), 'N') as totalQuantity 
from msm.PurchaseDetails pd
join msm.PurchaseOrderDetails pod on pod.POVNUM = pd.Purchase_OrderNo
where pd.Purchase_OrderNo = 'PO-2080-009' AND pd.is_Deleted <> 1 
order by PVNUM;


--OUTPUT:-
--PVNUM			| PName									| Purchase_OrderNo	| Quantity	| orderQuantity	| totalReceived	| totalQuantity
--PG-2080-041	| HOT PAPER ROLL 0.5MM					| PO-2080-009		| 3.00		| 5.00			| 10.00			| 15.00
--PG-2080-041	| CORROGRATED PAPER ROLL SINGLE LAYER	| PO-2080-009		| 7.00		| 5.00			| 10.00			| 15.00
--PG-2080-041	| HOT PAPER ROLL 0.5MM					| PO-2080-009		| 3.00		| 10.00			| 10.00			| 15.00
--PG-2080-041	| CORROGRATED PAPER ROLL SINGLE LAYER	| PO-2080-009		| 7.00		| 10.00			| 10.00			| 15.00

--DESIGRED OUTPUT
--PVNUM			| PName									| Purchase_OrderNo	| Quantity	| orderQuantity	| totalReceived	| totalQuantity
--PG-2080-041	| HOT PAPER ROLL 0.5MM					| PO-2080-009		| 3.00		| 5.00			| 10.00			| 15.00
--PG-2080-041	| CORROGRATED PAPER ROLL SINGLE LAYER	| PO-2080-009		| 7.00		| 10.00			| 10.00			| 15.00




