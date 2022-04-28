using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Inventory
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public ICollection<InventoryDetail> InventoryDetails { get; set; }

    }
}