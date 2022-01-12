using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIBlazor.Models.SharedTablesModel.Subdivision;
using UIBlazor.Models.SharedTablesModel.Validation;

namespace UIBlazor.Models.SharedTablesModel.Department
{
    public class DepartmentViewModel : BaseModel, IComparable<DepartmentViewModel>
    {
        public SubdivisionViewModel Subdivision { get; set; }

        public int CompareTo(DepartmentViewModel other)
        {
            if (Id > other.Id) return 1;
            if (Id < other.Id) return -1;
            else return 0;
        }
    }
}
