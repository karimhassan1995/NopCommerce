using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class InvoiceSellsController : Controller
    {
        private readonly testContext _context;

        public InvoiceSellsController(testContext context)
        {
            _context = context;
        }

        // GET: InvoiceSells
        public async Task<IActionResult> Index()
        {
              return _context.InvoiceSells != null ? 
                          View(await _context.InvoiceSells.ToListAsync()) :
                          Problem("Entity set 'testContext.InvoiceSells'  is null.");
        }

        // GET: InvoiceSells/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.InvoiceSells == null)
            {
                return NotFound();
            }

            var invoiceSell = await _context.InvoiceSells
                .FirstOrDefaultAsync(m => m.buildingNo == id);
            if (invoiceSell == null)
            {
                return NotFound();
            }

            return View(invoiceSell);
        }

        // GET: InvoiceSells/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvoiceSells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("buildingNo,invoiceNo,userNumber,billTypeNo,billTypeSubNo,storeNo,aName,eName,isCash,dateG,dateH,deliveryDate,deliveryDateH,isDelivered,deliveredDate,deliveredDateH,isOutDelivery,invoiceJobStatusNo,invoiceStatusNo,shipType,shipCost,shipTo,billToTypeNo,billToBuildingNo,billTo,isInventory1GaveIt,inventory1StaffNo,isInventory2ReceivedIt,inventory2StaffNo,depositNo,itemStatus,isPostedStock,isDeleted,isVoid,isPosted,isGLPosted,isPayments,isFastInvoice,isDeposited,isCleared,amountLeftAfterAllBills,collectedAmountFromOtherBills,note,isItemOrUnit,personNo2,carNo,driverNo,driverName,isUseInOutInvoice,regionNo,isAccountingForOthers,accountNo_Pay,accountNo_Ship,accountNo_Discount,name_Pay,name_Discount,name_Ship,billNo,projectNo,accountNo,accountNo_Second,agentNo,payBillNo,personNo,manPosted,manGLPosted,manVoid,telephone,sumPayed,subTotal,subTotalDiscount,subNetTotal,subNetTotalPlusTax,subCount,subLeftQuantity,subQuantity,amountCalculated,discount,totalDiscount,amountPayed01,amountPayed02,amountPayed03,amountPayed04,amountPayed05,amountLeft,amountCalculatedPayed,requestShipDate,paymentTermsId,dueDate,pricingSchemeId,pickedDate,packedDate,isCompleted,taxingSchemeNo,taxRate1_Percentage,taxRate2_Percentage,isCalculateTax2OnTax1,taxRate1eName,taxRate2eName,isTax1OnShipping,isTax2OnShipping,taxRate1aName,taxRate2aName,taxRateNo2,taxRate1_Total,taxRate2_Total,isOneInvoiceUploaded,taxRateNo,cashRegisterNo_BuildingNo,invoiceVATID,clientVendorNo,isUploadedToMainBranch,isPostedToTransactions,dateG_PerDay,dateG_PerMonth,dateG_PerYearQuarter,dateG_PerYearHalf,dateG_PerYear,VATTypeNo,VATGroupNo,profitMarginTotal,dateG_Posted,dateG_GLPosted,mainContact1,mainContact2,mainContact3,amountPayed01_VoucherNo,amountPayed02_VoucherNo,amountPayed03_VoucherNo,amountPayed04_VoucherNo,amountPayed05_VoucherNo,amountPayed01_bankAccountNo,amountPayed02_bankAccountNo,amountPayed03_bankAccountNo,amountPayed04_bankAccountNo,amountPayed05_bankAccountNo,customerCashGiven,customerCashReturned,price_differenceFromFirstPriceTotal,print_numOfCopies,print_DateG,leftMoneyPaymentDate,normalCustomerTypeNo,isPrintPartial,cardAmount_Visa,cardAmount_SPAN,dailyBillNo,runningCostAvg_diffrenceWhithPriceTotal,profitMarginTotal_fromAvgCost,runningCostAvgTotal,buyPrice_costPriceTotal,primaryUnit_QuantityTotal,paperBillNum,gazElectric_InNum,gaztElectric_OutNum,isReturnedFullyByReturnInvoice,isReturnedFullyByReturnInvoiceDate,weightTotal,staffNo1_personNo,staffNo2_personNo,staffNo3_personNo,exportImportType,billCreatorAsOf,IDCard,billPaperType,paymentTypes,subNetTotal_ExecludingTax,device_mileage,device_makerNo,device_model,device_plate,device_serial_1,device_serial_2,device_next_mileage,device_next_serviceDate,device_next_serviceDateH,device_makeYear,Inv_billTypeNo,Inv_buildingNo,Inv_invoiceNo,Inv_userNumber,calculatedPayed,amountPayed,calculatedCreditAmount,calculatedDebitAmount,isCreateGlass,rentType,rentDate,rentReturnDate,rentQuantity,service,isHangerOrFold,isSpot,isFastCleaning,starchNo,blueWeightNo,isLost,isPaperInvoiceReturned,spoilTypeNo,trainingHourseToBeGiven,trainingHourseLeft,gaztInvoiceNumber,gaztUniqueInvoiceIdentifier,gaztInvoiceTypeCode,gaztInvoiceTypeCode_SubType,gaztLatestDeliveryDate,gaztInvoiceHash,gaztPreviousInvoiceHash,row_timestamp")] InvoiceSell invoiceSell)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoiceSell);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invoiceSell);
        }

        // GET: InvoiceSells/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.InvoiceSells == null)
            {
                return NotFound();
            }

            var invoiceSell = await _context.InvoiceSells.FindAsync(id);
            if (invoiceSell == null)
            {
                return NotFound();
            }
            return View(invoiceSell);
        }

        // POST: InvoiceSells/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("buildingNo,invoiceNo,userNumber,billTypeNo,billTypeSubNo,storeNo,aName,eName,isCash,dateG,dateH,deliveryDate,deliveryDateH,isDelivered,deliveredDate,deliveredDateH,isOutDelivery,invoiceJobStatusNo,invoiceStatusNo,shipType,shipCost,shipTo,billToTypeNo,billToBuildingNo,billTo,isInventory1GaveIt,inventory1StaffNo,isInventory2ReceivedIt,inventory2StaffNo,depositNo,itemStatus,isPostedStock,isDeleted,isVoid,isPosted,isGLPosted,isPayments,isFastInvoice,isDeposited,isCleared,amountLeftAfterAllBills,collectedAmountFromOtherBills,note,isItemOrUnit,personNo2,carNo,driverNo,driverName,isUseInOutInvoice,regionNo,isAccountingForOthers,accountNo_Pay,accountNo_Ship,accountNo_Discount,name_Pay,name_Discount,name_Ship,billNo,projectNo,accountNo,accountNo_Second,agentNo,payBillNo,personNo,manPosted,manGLPosted,manVoid,telephone,sumPayed,subTotal,subTotalDiscount,subNetTotal,subNetTotalPlusTax,subCount,subLeftQuantity,subQuantity,amountCalculated,discount,totalDiscount,amountPayed01,amountPayed02,amountPayed03,amountPayed04,amountPayed05,amountLeft,amountCalculatedPayed,requestShipDate,paymentTermsId,dueDate,pricingSchemeId,pickedDate,packedDate,isCompleted,taxingSchemeNo,taxRate1_Percentage,taxRate2_Percentage,isCalculateTax2OnTax1,taxRate1eName,taxRate2eName,isTax1OnShipping,isTax2OnShipping,taxRate1aName,taxRate2aName,taxRateNo2,taxRate1_Total,taxRate2_Total,isOneInvoiceUploaded,taxRateNo,cashRegisterNo_BuildingNo,invoiceVATID,clientVendorNo,isUploadedToMainBranch,isPostedToTransactions,dateG_PerDay,dateG_PerMonth,dateG_PerYearQuarter,dateG_PerYearHalf,dateG_PerYear,VATTypeNo,VATGroupNo,profitMarginTotal,dateG_Posted,dateG_GLPosted,mainContact1,mainContact2,mainContact3,amountPayed01_VoucherNo,amountPayed02_VoucherNo,amountPayed03_VoucherNo,amountPayed04_VoucherNo,amountPayed05_VoucherNo,amountPayed01_bankAccountNo,amountPayed02_bankAccountNo,amountPayed03_bankAccountNo,amountPayed04_bankAccountNo,amountPayed05_bankAccountNo,customerCashGiven,customerCashReturned,price_differenceFromFirstPriceTotal,print_numOfCopies,print_DateG,leftMoneyPaymentDate,normalCustomerTypeNo,isPrintPartial,cardAmount_Visa,cardAmount_SPAN,dailyBillNo,runningCostAvg_diffrenceWhithPriceTotal,profitMarginTotal_fromAvgCost,runningCostAvgTotal,buyPrice_costPriceTotal,primaryUnit_QuantityTotal,paperBillNum,gazElectric_InNum,gaztElectric_OutNum,isReturnedFullyByReturnInvoice,isReturnedFullyByReturnInvoiceDate,weightTotal,staffNo1_personNo,staffNo2_personNo,staffNo3_personNo,exportImportType,billCreatorAsOf,IDCard,billPaperType,paymentTypes,subNetTotal_ExecludingTax,device_mileage,device_makerNo,device_model,device_plate,device_serial_1,device_serial_2,device_next_mileage,device_next_serviceDate,device_next_serviceDateH,device_makeYear,Inv_billTypeNo,Inv_buildingNo,Inv_invoiceNo,Inv_userNumber,calculatedPayed,amountPayed,calculatedCreditAmount,calculatedDebitAmount,isCreateGlass,rentType,rentDate,rentReturnDate,rentQuantity,service,isHangerOrFold,isSpot,isFastCleaning,starchNo,blueWeightNo,isLost,isPaperInvoiceReturned,spoilTypeNo,trainingHourseToBeGiven,trainingHourseLeft,gaztInvoiceNumber,gaztUniqueInvoiceIdentifier,gaztInvoiceTypeCode,gaztInvoiceTypeCode_SubType,gaztLatestDeliveryDate,gaztInvoiceHash,gaztPreviousInvoiceHash,row_timestamp")] InvoiceSell invoiceSell)
        {
            if (id != invoiceSell.buildingNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoiceSell);
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
            if (id == null || _context.InvoiceSells == null)
            {
                return NotFound();
            }

            var invoiceSell = await _context.InvoiceSells
                .FirstOrDefaultAsync(m => m.buildingNo == id);
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
            if (_context.InvoiceSells == null)
            {
                return Problem("Entity set 'testContext.InvoiceSells'  is null.");
            }
            var invoiceSell = await _context.InvoiceSells.FindAsync(id);
            if (invoiceSell != null)
            {
                _context.InvoiceSells.Remove(invoiceSell);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceSellExists(decimal id)
        {
          return (_context.InvoiceSells?.Any(e => e.buildingNo == id)).GetValueOrDefault();
        }
    }
}
