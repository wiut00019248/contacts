using System.ComponentModel.DataAnnotations;

namespace Web.CW._19248.Models
{
    public class Category
    {
        public int Id { get; set; }
        private string _type;
        [Required(ErrorMessage = "Type is required")]
        public string Type 
        {
            get => _type;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Type cannot be null or empty.");
                }
                _type = value;
            }
        }
    }
}
