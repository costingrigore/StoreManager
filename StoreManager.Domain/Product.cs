using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace StoreManager.Domain;
public class Product
{
    [Key]
    public int ProductId { get; set; }
    public string SKU { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}
