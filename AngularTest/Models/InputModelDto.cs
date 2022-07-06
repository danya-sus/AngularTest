using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AngularTest.Models
{
    public class InputModelDto
    {
        [Required]
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("isChecked")]
        public bool IsChecked { get; set; }
    }
}
