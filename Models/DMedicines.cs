using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Test.Models
{
    public class DMedicines
    {
        [Key]
        public Int64 Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        
    }
}