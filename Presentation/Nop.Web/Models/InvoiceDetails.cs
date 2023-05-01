using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nop.Web.Models
{
    public class InvoiceDetails
    {
        public long invoiceNo { get; set; }

        public string userNumber { get; set; }
        public string aName { get; set; }

        public string eName { get; set; }

        public DateTime dateG { get; set; }

        public string dateH { get; set; }

        public string telephone { get; set; }

        public string invoiceVATID { get; set; }

        public decimal? clientVendorNo { get; set; }

        public int orderNo { get; set; }
        public decimal itemNo { get; set; }

        public string UaName { get; set; }

        public short? unitNo { get; set; }

        public decimal quantity { get; set; }

        public decimal price { get; set; }

        public decimal? discount { get; set; }

        public decimal? total { get; set; }

        public decimal? taxRate1_Percentage { get; set; }

        public decimal? taxRate1_Total { get; set; }

        public decimal? totalPlusTax { get; set; }
        public List<InvoiceDetails> InvoiceDetailsList { get; set; }
    }
}
