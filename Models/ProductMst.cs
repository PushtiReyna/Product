using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductInformationDemo.Models;

public partial class ProductMst
{
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Please enter Product Name."), MaxLength(10)]
    [RegularExpression(@"^[a-zA-Z][a-zA-Z ]+[a-zA-Z]$", ErrorMessage = "Please enter only letters.")]
    public string ProductName { get; set; } = null!;

    [Required(ErrorMessage = "Please enter Product Description.")]
    [RegularExpression(@"^[a-zA-Z][a-zA-Z ]+[a-zA-Z]$", ErrorMessage = "Please enter only letters.")]
    public string ProductDescription { get; set; } = null!;

    [Required(ErrorMessage = "Please enter Product Price.")]
    [Range(1, 99999, ErrorMessage = "Please enter product price in range of 1 - 99999")]
    public string ProductPrice { get; set; } = null!;

    [Required(ErrorMessage = "Please enter Opening Stock")]
    [Range(1,500, ErrorMessage = "Please enter Opening Stock in range of 1 - 500")]
    public int OpeningStock { get; set; }

    [Required(ErrorMessage = "Please enter Buy Stock")]
   
    public int BuyStock { get; set; }

    [Required(ErrorMessage = "Please enter Sell Stock")]
    
    public int SellStock { get; set; }

    [Required(ErrorMessage = "Please enter Closing Stock.")]
    public int ClosingStock { get; set; }
}
