using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Garza_Johnny_HW2.Models
{
    public abstract class Order
    {
        //Fields - Named Constants
        public const decimal HARDBACK_PRICE = 19.00m;
        public const decimal PAPERBACK_PRICE = 7.00m;

        //Properties – Variables Instantation 
        public enum CustomerType
        {
            Walkup, Wholesale
        }

        [Display(Name = "Number Of Hardbacks: ")]
        public Int32 NumberOfHardbacks { get; set; }

        [Display(Name = "Number Of Paperbacks: ")]
        public Int32 NumberOfPaperbacks { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal HardbackSubtotal { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal PaperbackSubtotal { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Subtotal { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Total { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public Int32 TotalItems { get; set; }

        //Methods - Calcualtions 
        public void CalcSubtotals()
        {
            TotalItems = NumberOfHardbacks + NumberOfPaperbacks;

            if (TotalItems == 0)
            {
                throw new Exception("There was an error! You must buy at least one book!");
            }

            HardbackSubtotal = NumberOfHardbacks * HARDBACK_PRICE;
            PaperbackSubtotal = NumberOfPaperbacks * PAPERBACK_PRICE;
            Subtotal = HardbackSubtotal + PaperbackSubtotal;
        }
    }
}