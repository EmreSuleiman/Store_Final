using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StoreProject.Data;


namespace StoreProject.Models
{
    public class Person
    {
        [Key]
        [Column]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
    }
}
