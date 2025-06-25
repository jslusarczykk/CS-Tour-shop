using System.ComponentModel.DataAnnotations;

namespace C_SHOP.Models
{
    public enum Gender
    {
        Male,
        Female,
        Unknown
    }
    public class Customer
    {
        [Key]
        public int customer_id { get; set; }
        public string customer_name { get; set; }
        public string? customer_phone { get; set; }
        public string customer_email { get; set; }
        public string customer_password { get; set; }
        public Gender? customer_gender { get; set; } = Gender.Unknown;
        public string? customer_country { get; set; }
        public string? customer_city { get; set; }
        public string? customer_address { get; set; }
        public string? customer_image { get; set; }

    }
}
