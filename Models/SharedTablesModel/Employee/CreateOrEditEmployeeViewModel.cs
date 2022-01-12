using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIBlazor.Models.SharedTablesModel.Department;
using UIBlazor.Models.SharedTablesModel.Position;
using UIBlazor.Models.SharedTablesModel.Validation;

namespace UIBlazor.Models.SharedTablesModel.Employee
{
    public class CreateOrEditEmployeeViewModel : IExtandsBaseModel
    {
        public void SetAll(int id = 0) => throw new NotImplementedException();

        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DepartmentViewModel Departament { get; set; }
        public PositionViewModel Position { get; set; }
        public string WorkTelephone { get; set; }
        public string MobileTelephone { get; set; }
        public string Mail { get; set; }
        public string User { get; set; }
        public List<DepartmentViewModel> SelectDepartment { get; set; }
        public List<PositionViewModel> SelectPosition { get; set; }

        public CreateOrEditEmployeeFluentValidator Validator { get; set; } = new CreateOrEditEmployeeFluentValidator();

        public IBrowserFile Photo { get; set; }

        public CreateOrEditEmployeeViewModel(){}
        public CreateOrEditEmployeeViewModel(EmployeeViewModel model)
        {
            Id = model.Id;
            Surname = model.Surname;
            Name = model.Name;
            Patronymic = model.Patronymic;
            Departament = model.Departament;
            Position = model.Position;
            WorkTelephone = model.WorkTelephone;
            MobileTelephone = model.MobileTelephone;
            Mail = model.Mail;
            User = model.User;
        }
        public CreateOrEditEmployeeViewModel(int id, IBrowserFile photo)
        {
            Id = id;
            Photo = photo;
        }
    }
}
