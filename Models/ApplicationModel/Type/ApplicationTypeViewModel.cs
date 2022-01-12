using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UIBlazor.Models.ApplicationModel.Type
{
    public class ApplicationTypeViewModel : BaseModel, IComparable<ApplicationTypeViewModel>
    {
        public ApplicationTypeViewModelFluentValidator ValidationRules { get; set; } = new ApplicationTypeViewModelFluentValidator();

        public ApplicationTypeViewModel() { }
        public ApplicationTypeViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int CompareTo(ApplicationTypeViewModel other)
        {
            if (Id > other.Id) return 1;
            if (Id < other.Id) return -1;
            else return 0;
        }
    }
}
