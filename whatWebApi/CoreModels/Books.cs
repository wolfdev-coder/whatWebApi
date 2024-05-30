using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace whatWebApi.Models
{
    [Table("Books")]
    public class Books
    {
        [Key,Required]
        public int id { get; set; }
        public int author_id { get; set; }
        public int genre_id { get; set; }
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
    }
}
