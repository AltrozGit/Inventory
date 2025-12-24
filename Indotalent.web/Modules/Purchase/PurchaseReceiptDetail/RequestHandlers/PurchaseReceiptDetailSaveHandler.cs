using Indotalent.Administration;
using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Purchase.PurchaseReceiptDetailRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Purchase.PurchaseReceiptDetailRow;

namespace Indotalent.Purchase
{
    public interface IPurchaseReceiptDetailSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class PurchaseReceiptDetailSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IPurchaseReceiptDetailSaveHandler
    {
        public PurchaseReceiptDetailSaveHandler(IRequestContext context)
             : base(context)
        {
        }
        //protected override void BeforeSave()
        //{
        //    base.BeforeSave();
          
        //   if(Row.QtyReceive > Row.Qty || Row.QtyReceive <=0)
        //    {
        //        throw new Exception(" Qty Received less than eqaul to Qty Purchased and greater than 0");
        //    }
        //}


        }
    }
