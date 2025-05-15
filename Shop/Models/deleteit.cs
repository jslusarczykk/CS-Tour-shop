using System.ComponentModel.DataAnnotations;

namespace C_SHOP.Models
{
    public class Deleteit
    {
        [Key]
        public int admin_id { get; set; }
        public string admin_name { get; set; }
        public string admin_email { get; set; }
        public string admin_password { get; set; }
        public string admin_image { get; set; }
    }
}
