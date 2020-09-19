using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tresa.Models
{
    public class Test : BaseModel
    {
        public long BatteryId { get; set; }

        [ForeignKey("BatteryId")]
        public virtual Battery Battery { get; set; }

        [Required]
        public string Code{ get; set; }
    }
}
