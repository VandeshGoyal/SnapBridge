using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SnapBridge.Models
{
    public class Inventory
    {
        public int Id { get; set; }     //PrimaryKey: EF by default takes ID or Classname+Id as primary key
        [Required]
        public string Name { get; set; }
        [Required]
        public string Discription { get; set; }
        [Required]
        public Decimal Price { get; set; }
        [Required]
        public byte[] Image { get; set; }
    }
}