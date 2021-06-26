using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace RecordKeeping.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Expense name")]
        [Required]
        public string ExpenseName { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Amount must be greater than 0!!!")]
        public int Amount { get; set; }
    }
}
