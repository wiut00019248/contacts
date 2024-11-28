namespace Web.CW._19248.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}
