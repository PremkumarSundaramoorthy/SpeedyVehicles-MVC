using Speedy.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Speedy.Domain.Models
{
    public class Brand : BaseModel
    {
        [Required]
        public string Name { get; set; }

        [Display(Name = "Established Year")]
        public int EstablishedYear { get; set; }

        [Display(Name = "Brand Logo")]
        public string BrandLogo { get; set; }
    }
}
