using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace whatWebApi.Models
{
    [Table("Authors")]
    public class Authors
    {
        [Key, Required]
        public int id { get; set; }
        //public virtual Books Books { get; set; }
        public string name { get; set; } = string.Empty;
        public string bio { get; set; } = string.Empty;
    }
}
