using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Material.IssueDetailRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Material.IssueDetailRow;

namespace Indotalent.Material
{
    public interface IIssueDetailSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class IssueDetailSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IIssueDetailSaveHandler
    {
        public IssueDetailSaveHandler(IRequestContext context)
             : base(context)
        {
        }
        
    }

}


//protected override void BeforeSave()
//{
//    base.BeforeSave();

//    if (Row.QtyIssue > Row.PurchasePrice || Row.QtyIssue <= 0)
//    {
//        throw new Exception(" Qty Issue less than eqaul to Qty Purchased and greater than  0");
//    }