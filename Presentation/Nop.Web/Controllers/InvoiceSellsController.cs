using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nop.Web.Models;

namespace Nop.Web.Controllers
{
    public class InvoiceSellsController : Controller
    {
        private readonly testContext _context = new testContext();

        /* public InvoiceSellsController(testContext context)
         {
             _context = context;
         }*/

        // GET: InvoiceSells
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvoiceSell.ToListAsync());
        }

        // GET: InvoiceSells/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceSell = await _context.InvoiceSell
                .FirstOrDefaultAsync(m => m.invoiceNo == id);
            if (invoiceSell == null)
            {
                return NotFound();
            }

            return View(invoiceSell);
        }

        // GET: InvoiceSells/Create
        public IActionResult Create()
        {
            InvoiceDetails id = new InvoiceDetails();

            return View();
        }

        // POST: InvoiceSells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InvoiceDetails invoiceDetails)
        {
            InvoiceSell x = new InvoiceSell();
            x.invoiceNo = invoiceDetails.invoiceNo;
            x.userNumber = invoiceDetails.userNumber;
            x.aName = invoiceDetails.aName;
            x.eName = invoiceDetails.eName;
            x.dateG = invoiceDetails.dateG;
            x.dateH = invoiceDetails.dateH;
            x.telephone = invoiceDetails.telephone;
            x.invoiceVATID = invoiceDetails.invoiceVATID;
            x.clientVendorNo = invoiceDetails.clientVendorNo;

            if (invoiceDetails.InvoiceDetailsList != null)
            {

                foreach (var e in invoiceDetails.InvoiceDetailsList)
                {
                    InvoiceSellUnit items = new InvoiceSellUnit();
                    items.invoiceNo = invoiceDetails.invoiceNo;
                    /* items.buildingNo = invoiceDetails.buildingNo;*/
                    items.orderNo = e.orderNo;
                    items.itemNo = e.itemNo;
                    items.aName = e.UaName;
                    items.unitNo = e.unitNo;
                    items.quantity = e.quantity;
                    items.price = e.price;
                    items.discount = e.discount;
                    items.total = e.total;
                    items.taxRate1_Percentage = e.taxRate1_Percentage;
                    items.taxRate1_Total = e.taxRate1_Total;
                    items.totalPlusTax = e.totalPlusTax;
                    _context.InvoiceSellUnit.Add(items);
                }
            }
            _context.InvoiceSell.Add(x);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult AddMorePartialView()
        {
            //this  action page is support cal the partial page.
            //We will call this action by view page.This Action is return partial page
            InvoiceDetails model = new InvoiceDetails();
            return PartialView("_AddMorePartialView", model);
            //^this is actual partical page we have 
            //create on this page in Home Controller as given below image
        }

        // GET: InvoiceSells/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceSell = await _context.InvoiceSell
             .FirstOrDefaultAsync(m => m.invoiceNo == id);

           
            if (invoiceSell == null)
            {
                return NotFound();
            }
            return View(invoiceSell);
        }

        // POST: InvoiceSells/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("buildingNo,invoiceNo,userNumber,billTypeNo,billTypeSubNo,storeNo,aName,eName,isCash,dateG,dateH,deliveryDate,deliveryDateH,isDelivered,deliveredDate,deliveredDateH,isOutDelivery,invoiceJobStatusNo,invoiceStatusNo,shipType,shipCost,shipTo,billToTypeNo,billToBuildingNo,billTo,isInventory1GaveIt,inventory1StaffNo,isInventory2ReceivedIt,inventory2StaffNo,depositNo,itemStatus,isPostedStock,isDeleted,isVoid,isPosted,isGLPosted,isPayments,isFastInvoice,isDeposited,isCleared,amountLeftAfterAllBills,collectedAmountFromOtherBills,note,isItemOrUnit,personNo2,carNo,driverNo,driverName,isUseInOutInvoice,regionNo,isAccountingForOthers,accountNo_Pay,accountNo_Ship,accountNo_Discount,name_Pay,name_Discount,name_Ship,billNo,projectNo,accountNo,accountNo_Second,agentNo,payBillNo,personNo,manPosted,manGLPosted,manVoid,telephone,sumPayed,subTotal,subTotalDiscount,subNetTotal,subNetTotalPlusTax,subCount,subLeftQuantity,subQuantity,amountCalculated,discount,totalDiscount,amountPayed01,amountPayed02,amountPayed03,amountPayed04,amountPayed05,amountLeft,amountCalculatedPayed,requestShipDate,paymentTermsId,dueDate,pricingSchemeId,pickedDate,packedDate,isCompleted,taxingSchemeNo,taxRate1_Percentage,taxRate2_Percentage,isCalculateTax2OnTax1,taxRate1eName,taxRate2eName,isTax1OnShipping,isTax2OnShipping,taxRate1aName,taxRate2aName,taxRateNo2,taxRate1_Total,taxRate2_Total,isOneInvoiceUploaded,taxRateNo,cashRegisterNo_BuildingNo,invoiceVATID,clientVendorNo,isUploadedToMainBranch,isPostedToTransactions,dateG_PerDay,dateG_PerMonth,dateG_PerYearQuarter,dateG_PerYearHalf,dateG_PerYear,VATTypeNo,VATGroupNo,profitMarginTotal,dateG_Posted,dateG_GLPosted,mainContact1,mainContact2,mainContact3,amountPayed01_VoucherNo,amountPayed02_VoucherNo,amountPayed03_VoucherNo,amountPayed04_VoucherNo,amountPayed05_VoucherNo,amountPayed01_bankAccountNo,amountPayed02_bankAccountNo,amountPayed03_bankAccountNo,amountPayed04_bankAccountNo,amountPayed05_bankAccountNo,customerCashGiven,customerCashReturned,price_differenceFromFirstPriceTotal,print_numOfCopies,print_DateG,leftMoneyPaymentDate,normalCustomerTypeNo,isPrintPartial,cardAmount_Visa,cardAmount_SPAN,dailyBillNo,runningCostAvg_diffrenceWhithPriceTotal,profitMarginTotal_fromAvgCost,runningCostAvgTotal,buyPrice_costPriceTotal,primaryUnit_QuantityTotal,paperBillNum,gazElectric_InNum,gaztElectric_OutNum,isReturnedFullyByReturnInvoice,isReturnedFullyByReturnInvoiceDate,weightTotal,staffNo1_personNo,staffNo2_personNo,staffNo3_personNo,exportImportType,billCreatorAsOf,IDCard,billPaperType,paymentTypes,subNetTotal_ExecludingTax,device_mileage,device_makerNo,device_model,device_plate,device_serial_1,device_serial_2,device_next_mileage,device_next_serviceDate,device_next_serviceDateH,device_makeYear,Inv_billTypeNo,Inv_buildingNo,Inv_invoiceNo,Inv_userNumber,calculatedPayed,amountPayed,calculatedCreditAmount,calculatedDebitAmount,isCreateGlass,rentType,rentDate,rentReturnDate,rentQuantity,service,isHangerOrFold,isSpot,isFastCleaning,starchNo,blueWeightNo,isLost,isPaperInvoiceReturned,spoilTypeNo,trainingHourseToBeGiven,trainingHourseLeft,gaztInvoiceNumber,gaztUniqueInvoiceIdentifier,gaztInvoiceTypeCode,gaztInvoiceTypeCode_SubType,gaztLatestDeliveryDate,gaztInvoiceHash,gaztPreviousInvoiceHash,row_timestamp")] InvoiceSell invoiceSell)
        {
         

            if (ModelState.IsValid)
            {
                try
                {
                    var insells = await _context.InvoiceSell.FirstOrDefaultAsync(m => m.invoiceNo == invoiceSell.invoiceNo);
                    insells.invoiceNo = invoiceSell.invoiceNo;
                    insells.userNumber = invoiceSell.userNumber;
                    insells.aName = invoiceSell.aName;
                    insells.eName = invoiceSell.eName;
                    insells.dateG = invoiceSell.dateG;
                    insells.dateH = invoiceSell.dateH;
                    insells.telephone = invoiceSell.telephone;
                    insells.invoiceVATID = invoiceSell.invoiceVATID;
                    insells.clientVendorNo = invoiceSell.clientVendorNo;
                    _context.Update(insells);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceSellExists(invoiceSell.buildingNo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(invoiceSell);
        }

        // GET: InvoiceSells/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceSell = await _context.InvoiceSell
                .FirstOrDefaultAsync(m => m.invoiceNo == id);
            if (invoiceSell == null)
            {
                return NotFound();
            }

            return View(invoiceSell);
        }

        // POST: InvoiceSells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {

            var invoiceSell = await _context.InvoiceSell.FirstOrDefaultAsync(m => m.invoiceNo == id);
            /*        foreach(InvoiceSellUnit unit in _context.InvoiceSellUnit)
                        {
                            if (unit.invoiceNo == id)
                            {
                                _context.InvoiceSellUnit.Remove(unit);
                            }
                        }*/
            /*_context.InvoiceSell.u*/
            _context.InvoiceSell.Remove(invoiceSell);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceSellExists(decimal id)
        {
            return _context.InvoiceSell.Any(e => e.buildingNo == id);
        }
    }
}
