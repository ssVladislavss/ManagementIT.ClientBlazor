using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIBlazor.Models.SharedTablesModel.Department;
using UIBlazor.Models.SharedTablesModel.Position;

namespace UIBlazor.Models.SharedTablesModel.Employee
{
    public class EmployeeViewModel : BaseModel, IComparable<EmployeeViewModel>
    {
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DepartmentViewModel Departament { get; set; }
        public PositionViewModel Position { get; set; }
        public string WorkTelephone { get; set; }
        public string MobileTelephone { get; set; }
        public string Mail { get; set; }
        public string User { get; set; }
        public EmployeePhotoViewModel Photo { get; set; }

        public EmployeeViewModel(){}
        public EmployeeViewModel(int id, string surName, string name, string patronumic, DepartmentViewModel department, PositionViewModel position,
            string workTelephone, string mobileTelephone, string mail, string user)
        {
            Id = id;
            Surname = surName;
            Name = name;
            Patronymic = patronumic;
            Departament = department;
            Position = position;
            WorkTelephone = workTelephone;
            MobileTelephone = mobileTelephone;
            Mail = mail;
            User = user;
        }
        public EmployeeViewModel(CreateOrEditEmployeeViewModel model, EmployeePhotoViewModel photo)
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

            Photo = photo;
        }

        public string GetShortName() => $"{Surname} {Name[0]} {Patronymic[0]}";
        public string GetFullName() => $"{Surname} {Name} {Patronymic}";

        public int CompareTo(EmployeeViewModel other)
        {
            if (Id > other.Id) return 1;
            if (Id < other.Id) return -1;
            else return 0;
        }
    }
}
