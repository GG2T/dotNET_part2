using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace _335ass2.Dtos
{
    public class PurchaseInput
    {
        
        
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
