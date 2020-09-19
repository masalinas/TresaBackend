using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tresa.Models
{
    public abstract class BaseModel
    {
        [Key]
        public long Id { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
