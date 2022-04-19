using System.ComponentModel.DataAnnotations;

namespace Sparks_Task_1.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        [Required]
        public string Receiver { get; set; }
        [Required]
        public string Amount { get; set; }
    }
}
