using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIBlazor.Models.ApplicationModel.State;

namespace UIBlazor.Models.ApplicationModel.Application
{
    public class SelectedStateViewModel
    {
        public List<ApplicationStateViewModel> SelectState { get; set; }
        public ApplicationStateViewModel State { get; set; }

        public SelectStateFluentValidator Validator { get; set; } = new SelectStateFluentValidator();
    }
}
