using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class KeyValuePair
    {
        [Key]
        public required string Key { get; set; }
        public required string Value { get; set; }
    }
}
