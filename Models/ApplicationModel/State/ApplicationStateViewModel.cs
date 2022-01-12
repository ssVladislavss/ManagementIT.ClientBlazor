using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UIBlazor.Models.ApplicationModel.State
{
    public class ApplicationStateViewModel : BaseModel, IComparable<ApplicationStateViewModel>
    {
        public string State { get; set; }
        public string BGColor { get; set; }
        public bool IsDefault { get; set; }

        public ApplicationStateViewModelFluentValidator ValidationRules { get; set; } = new ApplicationStateViewModelFluentValidator();

        public ApplicationStateViewModel() { }
        public ApplicationStateViewModel(int id, string name, string bgColor, bool isDefault)
        {
            Id = id;
            Name = name;
            BGColor = bgColor;
            IsDefault = isDefault;
        }

        public int CompareTo(ApplicationStateViewModel other)
        {
            if (Id > other.Id) return 1;
            if (Id < other.Id) return -1;
            else return 0;
        }
    }
}
