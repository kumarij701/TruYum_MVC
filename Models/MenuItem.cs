
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruYum.Models
{
    public class MenuItem
    {
        [Key]
        public int MenuItemId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }
        public bool IsActive { get; set; }

        [Display(Name="Date Of Launch")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}" , ApplyFormatInEditMode = true)]
        public DateTime DateOfLaunch { get; set; }

        [Display(Name = "Category")]
        public String TypeOfItem { get; set; }

        [Display(Name="Free Delivery")]
        public bool IsFreeDelivered { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }


    }
    
}
