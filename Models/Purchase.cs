using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreProject.Data;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreProject.Models
{
    public class Purchase
    {
        [Key]
        [Column]
        public int PurchaseId { get; set; }
        public int ClientId { get; set; }
        public Person Client { get; set; }
        public int ItemId { get; set; }
        public Article Item { get; set; }
        public int Quantity { get; set; }
    }
}
