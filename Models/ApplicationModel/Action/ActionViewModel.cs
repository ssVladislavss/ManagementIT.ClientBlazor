using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UIBlazor.Models.ApplicationModel.Action
{
    public class ActionViewModel : BaseModel, IComparable<ActionViewModel>
    {
        public int AppId { get; set; }
        public string StateName { get; set; }
        public string UserNameIniciator { get; set; }
        public int IniciatorId { get; set; }
        public string DateOrTime { get; set; }
        public int DeptId { get; set; }
        public string ContentApp { get; set; }
        public string Action { get; set; }

        public int CompareTo(ActionViewModel other)
        {
            if (AppId > other.AppId) return 1;
            if (AppId < other.AppId) return -1;
            return 0;
        }
    }
}
