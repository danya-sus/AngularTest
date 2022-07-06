using AngularTest.Filters;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AngularTest.Models
{
    public class InputTicketDto
    {
        [Required]
        [JsonProperty("ticketNumber")]
        [LengthFilter]
        [PatternFilter]
        public string TicketNumber { get; set; }

        [Required]
        [JsonProperty("isChecked")]
        public bool IsChecked { get; set; }
    }
}
