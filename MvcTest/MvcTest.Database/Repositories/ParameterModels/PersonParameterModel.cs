using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MvcTest.Models.ViewModels;

namespace MvcTest.Database.Repositories.ParameterModels
{
    public class PersonParameterModel
    {
        public int PersonId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public bool IsAuthorised { get; set; }

        public bool IsValid { get; set; }

        public bool IsEnabled { get; set; }

        public List<ColourParameterModel> Colours { get; set; }
    }
}