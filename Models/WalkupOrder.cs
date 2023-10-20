using System;
using System.ComponentModel.DataAnnotations;

namespace Garza_Johnny_HW2.Models
{
    public class WalkupOrder : Order
    {
        //Fields - Named Constants
        public const decimal SALES_TAX_RATE = 0.0875m;

        public new CustomerType CustomerType { get; set; }

        //Properties – Variables Instantiation 
        [Display(Name = "Customer Name: ")]
        [Required(ErrorMessage = "Customer Name is required!")]
        public string? CustomerName { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal SalesTax { get; set; }

        //Methods - Calculations 
        public void CalcTotals()
        {
            CalcSubtotals();
            SalesTax = Subtotal * SALES_TAX_RATE;
            Total = Subtotal + SalesTax;
        }
    }
}
