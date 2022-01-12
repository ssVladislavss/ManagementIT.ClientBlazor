using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIBlazor.Models.SharedTablesModel.Validation;

namespace UIBlazor.Models.SharedTablesModel.Position
{
    public class PositionViewModel : BaseModel, IComparable<PositionViewModel>
    {
        public PositionFluentValidator Validator { get; set; } = new PositionFluentValidator();

        public PositionViewModel(){}
        public PositionViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int CompareTo(PositionViewModel other)
        {
            if (Id > other.Id) return 1;
            if (Id < other.Id) return -1;
            else return 0;
        }
    }
}
