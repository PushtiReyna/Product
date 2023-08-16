using System;
using System.Collections.Generic;

namespace ProductInformationDemo.Models;

public partial class ProductMst
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string ProductDescription { get; set; } = null!;

    public string ProductPrice { get; set; } = null!;

    public int OpeningStock { get; set; }

    public int BuyStock { get; set; }

    public int SellStock { get; set; }

    public int ClosingStock { get; set; }
}
