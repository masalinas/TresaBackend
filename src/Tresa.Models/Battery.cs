using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tresa.Models
{
    public class Battery : BaseModel
    {
        public long DeviceId { get; set; }

        [ForeignKey("DeviceId")]
        public virtual Device Device { get; set; }

        [Required]
        public string Code { get; set; }

        public string Version { get; set; }

        public String Description { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
    }
}
