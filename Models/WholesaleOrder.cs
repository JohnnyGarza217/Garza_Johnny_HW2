using System;
using System.ComponentModel.DataAnnotations;

namespace Garza_Johnny_HW2.Models
{
    public class WholesaleOrder : Order
    {
        // Properties – Variable Instantiation
        [Display(Name = "Customer Code: ")]
        [Required(ErrorMessage = "Customer Code is required!")]
        [StringLength(4, MinimumLength = 2, ErrorMessage = "Customer Code must be between 2 and 4 characters.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Customer Code can only contain letters.")]
        public string? CustomerCode { get; set; }

        // Use 'new' to hide the CustomerType property from the base class
        public new CustomerType CustomerType { get; set; }

        [Display(Name = "Delivery Fee: ")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Required(ErrorMessage = "Delivery Fee is required!")]
        [Range(0, 175, ErrorMessage = "Delivery Fee must be between $0 and $175")]
        public decimal DeliveryFee { get; set; }

        [Display(Name = "Preferred Customer")]
        public bool PreferredCustomer { get; set; }

        // Methods - Calculations 
        public void CalcTotals()
        {
            CalcSubtotals();

            // Calculate total based on whether the customer is preferred or not
            if (PreferredCustomer)
            {
                DeliveryFee = 0;
                Total = Subtotal + DeliveryFee;
            }
            else
            {
                Total = Subtotal + DeliveryFee;
            }
        }
    }
}
