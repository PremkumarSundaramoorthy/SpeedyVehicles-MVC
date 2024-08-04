using Speedy.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speedy.Domain.Modles
{
    public class VehicleType : BaseModel
    {
        [Required]
        public string Name { get; set; }
    }
}
