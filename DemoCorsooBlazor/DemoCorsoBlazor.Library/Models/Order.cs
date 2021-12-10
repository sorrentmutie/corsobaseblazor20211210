using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DemoCorsoBlazor.Library.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; } = 0.0M;
        [Required(ErrorMessage = "Descrizione è obbligatoria")]
        [StringLength(20, ErrorMessage = "La lunghezza massima è di 20 caratteri")]
        public string Description { get; set; } = "";
    }
}
