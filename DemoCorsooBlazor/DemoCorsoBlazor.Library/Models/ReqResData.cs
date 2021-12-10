using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DemoCorsoBlazor.Library.Models
{
    public class ReqResUser
    {
        public int id { get; set; }
        public string email { get; set; } = String.Empty;
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; } = String.Empty;
        [JsonPropertyName("last_name")]
        public string LastName { get; set; } = String.Empty ;
        public string avatar { get; set; } = String.Empty;
    }

    public class Support
    {
        public string url { get; set; }
        public string text { get; set; }
    }

    public class ReqResData
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<ReqResUser> data { get; set; } = new List<ReqResUser> ();
        public Support? support { get; set; } 
    }
}
