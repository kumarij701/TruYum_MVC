using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TruYum.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Free Delivery")]
        public Boolean IsFreeDelivered { get; set; }


        [Required]
        public int Price { get; set; }

        public string TypeOfItem { get; set; }


        [ForeignKey("MenuItem")]
        public int MenuItemId { get; set; }

        public MenuItem MenuItem { get; set; }

    }
}
