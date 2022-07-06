using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AngularTest.Models
{
    public class InputDocDto
    {
        [Required]
        [JsonProperty("docNumber")]
        public string DocNumber { get; set; }
    }
}
