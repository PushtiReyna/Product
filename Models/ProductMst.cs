using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductInformationDemo.Models;

public partial class ProductMst
{
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Please enter Product Name."), MaxLength(20)]
    [RegularExpression(@"^[a-zA-Z][a-zA-Z ]+[a-zA-Z]$", ErrorMessage = "Please enter only letters.")]
    public string ProductName { get; set; } = null!;

    [Required(ErrorMessage = "Please enter Product Description.")]
    [RegularExpression(@"^[a-zA-Z][a-zA-Z ]+[a-zA-Z]$", ErrorMessage = "Please enter only letters.")]
    public string ProductDescription { get; set; } = null!;

    [Required(ErrorMessage = "Please enter Product Price.")]
    [Range(1, 9999999, ErrorMessage = "Please enter product price greater than 0")]
    public double ProductPrice { get; set; }

    [Required(ErrorMessage = "Please enter Opening Stock")]
    [Range(1, 9999999 ,ErrorMessage = "Please enter Opening Stock greater than 0")]
    public double OpeningStock { get; set; }

    [Required(ErrorMessage = "Please enter Buy Stock")]
    public double BuyStock { get; set; }

    [Required(ErrorMessage = "Please enter Sell Stock")]
    public double SellStock { get; set; }

    [Required(ErrorMessage = "Please enter Closing Stock.")]
    public double ClosingStock { get; set; }
}
