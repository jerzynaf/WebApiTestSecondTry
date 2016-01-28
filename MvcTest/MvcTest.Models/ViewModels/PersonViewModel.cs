using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace MvcTest.Models.ViewModels
{
    [DataContract]
    public class PersonViewModel
    {
         [DataMember(Name = "id")]
        public int PersonId { get; set; }

        [DataMember]
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [DataMember]
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [DataMember]
        [UIHint("YesNo")]
        [Display(Name = "Authorised")]
        public bool IsAuthorised { get; set; }

        [DataMember]
        public bool IsValid { get; set; }

        [DataMember]
        [UIHint("YesNo")]
        [Display(Name = "Enabled")]
        public bool IsEnabled { get; set; }

        [DataMember]
        public List<ColourViewModel> Colours { get; set; }

        [DataMember]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        [DataMember]
        public string ColoursString
        {
            get { return string.Join(", ", Colours.OrderBy(c => c.Name).Select(c => c.Name)); }
        }

        [DataMember]
        [UIHint("YesNo")]
        public bool IsPalindrome
        {
            get
            {
                var fullName = FirstName.ToUpper() + LastName.ToUpper();
                return fullName.SequenceEqual(fullName.Reverse());
            }
        }
    }
}