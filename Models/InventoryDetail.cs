using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    public class InventoryDetail
    {
       
        public string Medicines { get; set; }

         [Column(TypeName = "decimal(16,2)")]
        public decimal Prices { get; set; }

        public int Quantity { get; set; }

        public Guid Id { get; set; }
        public Inventory Inventory { get; set; }

    }
}