using System;

namespace ServiceSystem.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; }  // INV-2024-0001
        public int? PaymentID { get; set; }        // ? means it can be null
        public int UnitID { get; set; }
        public string UnitName { get; set; }       // filled when reading from database

        // Giver = company giving the invoice
        public string GiverName { get; set; }
        public string GiverNameKurdish { get; set; }

        // Receiver = unit owner or tenant
        public string ReceiverName { get; set; }
        public string ReceiverNameKurdish { get; set; }

        // DebtMonth = first month on invoice
        // DebtToMonth = last month (null means only one month)
        public DateTime DebtMonth { get; set; }
        public DateTime? DebtToMonth { get; set; }

        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string BillType { get; set; }       // Service / Maintenance / Electric / Mixed

        // Free text printed on invoice — English and Kurdish
        public string InvoiceContent { get; set; }
        public string InvoiceContentKurdish { get; set; }

        public string CreatedByName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
