using System.ComponentModel.DataAnnotations;

namespace C_SHOP.Models
{
    public class Category
    {
        [Key]
        public int category_id { get; set; }
        public string category_name { get; set; }
    }
}
