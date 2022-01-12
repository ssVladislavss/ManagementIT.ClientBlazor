using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UIBlazor.Models.ApplicationModel.Application
{
    public class UpdatePriorityViewModel
    {
        public int AppId { get; set; }
        public int PriorityId { get; set; }

        public UpdatePriorityViewModel(){}
        public UpdatePriorityViewModel(int appId, SelectPriorityViewModel model)
        {
            AppId = appId;
            PriorityId = model.Priority.Id;
        }
    }
}
