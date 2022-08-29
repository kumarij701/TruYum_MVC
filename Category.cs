using System.ComponentModel.DataAnnotations;

namespace TruYum
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
