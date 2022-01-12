using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIBlazor.Models.SharedTablesModel.Validation;

namespace UIBlazor.Models.SharedTablesModel.Building
{
    public class BuildingViewModel : BaseModel, IComparable<BuildingViewModel>
    {
        public string Address { get; set; }
        public int Floor { get; set; }

        public BuildingValidator Validator { get; set; } = new BuildingValidator();

        public BuildingViewModel(){}
        public BuildingViewModel(int id, string name, string address, int floor)
        {
            Id = id;
            Name = name;
            Address = address;
            Floor = floor;
        }

        public int CompareTo(BuildingViewModel other)
        {
            if (Id > other.Id) return 1;
            if (Id < other.Id) return -1;
            else return 0;
        }
    }
}
