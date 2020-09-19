using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tresa.Models
{
    public class Device : BaseModel
    {
        [Required]
        public string Code { get; set; }

        public string SerialNumber { get; set; }

        public virtual ICollection<Battery> Batteries { get; set; }
    }
}
