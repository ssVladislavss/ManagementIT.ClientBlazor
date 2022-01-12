using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIBlazor.Models.ApplicationModel.Priority;

namespace UIBlazor.Models.ApplicationModel.Application
{
    public class SelectPriorityViewModel
    {
        public List<ApplicationPriorityViewModel> SelectPriority { get; set; }
        public ApplicationPriorityViewModel Priority { get; set; }

        public SelectPriorityFluentValidator Validator { get; set; } = new SelectPriorityFluentValidator();
    }
}
