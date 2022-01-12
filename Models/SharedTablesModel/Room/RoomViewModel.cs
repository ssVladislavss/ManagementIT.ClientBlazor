using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIBlazor.Models.SharedTablesModel.Building;
using UIBlazor.Models.SharedTablesModel.Department;

namespace UIBlazor.Models.SharedTablesModel.Room
{
    public class RoomViewModel : BaseModel, IComparable<RoomViewModel>
    {
        public BuildingViewModel Building { get; set; }
        public int Floor { get; set; }
        public DepartmentViewModel Departament { get; set; }
        public int RequiredCountSocket { get; set; }
        public int CurrentCountSocket { get; set; }

        public int CompareTo(RoomViewModel other)
        {
            if (Id > other.Id) return 1;
            if (Id < other.Id) return -1;
            else return 0;
        }
    }
}
