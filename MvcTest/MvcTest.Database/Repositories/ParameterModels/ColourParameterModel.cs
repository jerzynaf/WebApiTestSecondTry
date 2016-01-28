using System.ComponentModel.DataAnnotations;

namespace MvcTest.Database.Repositories.ParameterModels
{
    public class ColourParameterModel
    {
        public int ColourId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool IsChecked { get; set; }
    }
}