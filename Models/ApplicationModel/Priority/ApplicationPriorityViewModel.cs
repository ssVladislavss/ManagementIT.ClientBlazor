using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UIBlazor.Models.ApplicationModel.Priority
{
    public class ApplicationPriorityViewModel : BaseModel, IComparable<ApplicationPriorityViewModel>
    {
        public ApplicationPrioityViewModelFluentValidator ValidationRules { get; set; } = new ApplicationPrioityViewModelFluentValidator();

        public bool IsDefault { get; set; }

        public ApplicationPriorityViewModel() { }
        public ApplicationPriorityViewModel(int id, string name, bool isDefault = false)
        {
            Id = id;
            Name = name;
            IsDefault = isDefault;
        }

        public int CompareTo(ApplicationPriorityViewModel other)
        {
            if (Id > other.Id) return 1;
            if (Id < other.Id) return -1;
            else return 0;
        }
    }
}
