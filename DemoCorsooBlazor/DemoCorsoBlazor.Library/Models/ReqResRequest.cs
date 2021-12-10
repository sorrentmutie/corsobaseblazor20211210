using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCorsoBlazor.Library.Models
{
    public class ReqResRequest
    {
        [Required(ErrorMessage = "Nome obbligatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lavoro obbligatorio")]
        public string Job { get; set; }
    }
}
