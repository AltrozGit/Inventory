IF EXISTS(select 1 from sys.views where name='vwProjectFund' and type='v')
DROP VIEW vwProjectFund;
go
CREATE VIEW [vwProjectFund] AS
with TotalAllocatedFund as
(
	select 
		pf.ProjectId, 
		sum(pf.AddedFund) TotalAllocatedFund 
	from ProjectFund pf 
	group by pf.ProjectId
), 

ProjectExpence as
(
	select 
		pe.ProjectId, 
		sum(pe.Cost) ProjectExpence 
	from ProjectExpense pe 
	group by pe.ProjectId
),

MaterialCost as
(
	select
		mi.ProjectId, 
		sum((p.PurchasePrice * mid.QtyIssue)) MaterialCost 
	from MaterialIssueDetail mid
	inner join Product p on p.Id = mid.ProductId
	inner join PurchaseTax pt on pt.Id = p.PurchaseTaxId 
	inner join MaterialIssue mi on mi.Id = mid.MaterialIssueId
	group by mi.ProjectId
),

ProductTax as
(
	select 
		ProjectId, 
		sum(Tax) ProductTax 
	from
		(select
			mi.ProjectId, 
			P.Id ProductId,
			case 
				when pt.TaxRatePercentage > 0 then (pt.TaxRatePercentage * (p.PurchasePrice/100)) * mid.QtyIssue
				else 0
			end as Tax
		from MaterialIssueDetail mid
		inner join Product p on p.Id = mid.ProductId
		inner join PurchaseTax pt on pt.Id = p.PurchaseTaxId 
		inner join MaterialIssue mi on mi.Id = mid.MaterialIssueId) 
	as ProductTaxTemp
	group by ProjectId
)

select 
	ProjectId,
	p.Name as ProjectName,
	TotalAllocatedFund,
	(ProjectExpence + MaterialCost + ProductTax) TotalExpense,
	AvailableFund
from
	(select 
		ISNULL(ISNULL(taf.ProjectId, tpe.ProjectId), mc.ProjectId) ProjectId, 
		ISNULL(taf.TotalAllocatedFund, 0) TotalAllocatedFund, 
		ISNULL(tpe.ProjectExpence, 0) ProjectExpence, 
		ISNULL(mc.MaterialCost, 0) MaterialCost, 
		ISNULL(pt.ProductTax, 0) ProductTax,
		(ISNULL(taf.TotalAllocatedFund, 0) - (ISNULL(tpe.ProjectExpence, 0) + ISNULL(mc.MaterialCost, 0) + ISNULL(pt.ProductTax, 0))) AvailableFund
	from TotalAllocatedFund taf 
	full join ProjectExpence tpe on taf.ProjectId = tpe.ProjectId
	full join MaterialCost mc on ISNULL(taf.ProjectId, tpe.ProjectId) = mc.ProjectId
	full join ProductTax pt on pt.ProjectId = mc.ProjectId)
as ProjectFund inner join Project p on p.Id = ProjectId