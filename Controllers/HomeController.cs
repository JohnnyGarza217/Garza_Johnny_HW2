// Author: Johnny Garza
//Date: 10/12/2023
//Assignment: Homework 2

using Microsoft.AspNetCore.Mvc;
using Garza_Johnny_HW2.Models;


namespace Garza_Johnny_HW2.Controllers
{
    public class HomeController : Controller
    {
        //View Index 
        public IActionResult Index()
        {
            return View();
        }

        //Get Method for CheckoutWalkup
        [HttpGet]
        public ViewResult CheckoutWalkup()
        {
            return View();
        }
        //Post Method for WalkupTotals - Checks valid responses and instantates variables 
        [HttpPost]
        public IActionResult WalkupTotals(WalkupOrder walkupOrder)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // Set a generic error message for invalid data
                    ViewBag.ErrorMessage = "Please make sure you have entered valid data!";
                    return View("CheckoutWalkup", walkupOrder);
                }

                walkupOrder.CustomerType = Order.CustomerType.Walkup;

                // Assuming you have a CalcTotals method in your WalkupOrder class
                walkupOrder.CalcTotals();

                return View("WalkupTotals", walkupOrder);
            }
            catch (Exception ex)
            {
                // Handle the exception here, you can log it or display an error message
                ViewBag.ErrorMessage = $" {ex.Message}";
                return View("CheckoutWalkup", walkupOrder);
            }
        }
        //Get Method for CheckoutWholesale
        [HttpGet]
        public ViewResult CheckoutWholesale()
        {
            return View();
        }
        //Post Method for WholesaleTotals - Checks valid responses and instantates variables 
        [HttpPost]
        public IActionResult WholesaleTotals(WholesaleOrder wholesaleOrder)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // Set a generic error message for invalid data
                    ViewBag.ErrorMessage = "Please make sure you have entered valid data!";
                    return View("CheckoutWholesale", wholesaleOrder);
                }

                wholesaleOrder.CustomerType = Order.CustomerType.Wholesale;

                // Assuming you have a CalcTotals method in your WholesaleOrder class
                wholesaleOrder.CalcTotals();

                return View("WholesaleTotals", wholesaleOrder);
            }
            catch (Exception ex)
            {
                // Handle the exception here, you can log it or display an error message
                ViewBag.ErrorMessage = $" {ex.Message}";
                return View("CheckoutWholesale", wholesaleOrder);
            }
        }
    }
}