using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIBlazor.Models.SharedTablesModel.Subdivision;
using UIBlazor.Models.SharedTablesModel.Validation;

namespace UIBlazor.Models.SharedTablesModel.Department
{
    public class CreateOrEditDepartmentViewModel : IExtandsBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SubdivisionViewModel Subdivision { get; set; }

        public List<SubdivisionViewModel> SelectedSubdivision { get; set; }

        public DepartamentFluentValidator Validator { get; set; } = new DepartamentFluentValidator();

        public void SetAll(int id = 0)
        {
            throw new NotImplementedException();
        }

        public CreateOrEditDepartmentViewModel(){}
        public CreateOrEditDepartmentViewModel(DepartmentViewModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Subdivision = model.Subdivision;
        }
    }
}
