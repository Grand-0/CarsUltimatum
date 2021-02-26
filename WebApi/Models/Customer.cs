namespace WebApi.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public decimal Purse { get; set; }
        public string Role { get; set; }
    }
}
