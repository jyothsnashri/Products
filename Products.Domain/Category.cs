using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Domain
{
    [Table("Category")]
    public class Category
    {
        public int ID { get; set; }
        public string Category1 { get; set; }
        public bool Status { get; set; }

    }
}
