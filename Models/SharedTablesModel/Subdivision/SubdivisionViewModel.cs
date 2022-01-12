using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIBlazor.Models.SharedTablesModel.Validation;

namespace UIBlazor.Models.SharedTablesModel.Subdivision
{
    public class SubdivisionViewModel : BaseModel, IComparable<SubdivisionViewModel>
    {
        public SubdivisionFluentValidator Validator { get; set; } = new SubdivisionFluentValidator();

        public int CompareTo(SubdivisionViewModel other)
        {
            if (Id > other.Id) return 1;
            if (Id < other.Id) return -1;
            else return 0;
        }
    }
}
