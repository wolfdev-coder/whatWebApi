namespace whatWebApi.Models
{
    public class BookModel
    {
        public int id { get; set; }
        public int author_id { get; set; }
        public int genre_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
