using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tresa.Models
{
    public class Role: BaseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }     
    }
}
