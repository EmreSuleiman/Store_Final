using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreProject.Data;

namespace StoreProject.Models
{
    
    public class Article
    {
        [Key]
        [Column]
        public int ID { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal BuyCost { get; set; }
        public decimal SellPrice { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
    }
}
