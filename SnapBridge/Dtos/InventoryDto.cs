using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SnapBridge.Dtos
{
    public class InventoryDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Discription { get; set; }
        [Required]
        public Decimal Price { get; set; }
        [Required]
        public HttpPostedFileBase Image { get; set; }
    }
}