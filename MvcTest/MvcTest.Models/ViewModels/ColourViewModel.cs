using System.ComponentModel.DataAnnotations;

namespace MvcTest.Models.ViewModels
{
    public class ColourViewModel
    {
        public int ColourId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool IsChecked { get; set; }
    }
}