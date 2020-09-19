using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tresa.Models
{
    public class User: BaseModel
    {
        public string Name { get; set; }

        public string email { get; set; }     

        public string password { get; set; }     

        public bool active { get; set; }     

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
