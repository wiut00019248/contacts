namespace Web.CW._19248.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
