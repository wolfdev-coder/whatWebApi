using System.ComponentModel.DataAnnotations.Schema;

namespace whatWebApi.Models
{
    public class GenresModel
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
    }
}
