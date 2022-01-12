using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UIBlazor.Models
{
    public class BaseModel
    {
        [DisplayName("Идентификатор")]
        public virtual int Id { get; set; }
        [Required]
        [DisplayName("Название")]
        public virtual string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
