using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UIBlazor.Models.ApplicationModel.Application
{
    public class UpdateStateViewModel
    {
        public int ApplicationId { get; set; }
        public int StateId { get; set; }

        public UpdateStateViewModel(){}
        public UpdateStateViewModel(int appId, SelectedStateViewModel model)
        {
            ApplicationId = appId;
            StateId = model.State.Id;
        }
    }
}
