using UIBlazor.Models.SharedTablesModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UIBlazor.Models.SharedTablesModel.Department;
using UIBlazor.Models.SharedTablesModel.Room;
using UIBlazor.Models.SharedTablesModel.Employee;
using UIBlazor.Models.ApplicationModel.Type;
using UIBlazor.Models.ApplicationModel.State;
using UIBlazor.Models.ApplicationModel.Priority;

namespace UIBlazor.Models.ApplicationModel.Application
{
    public class CreateOrEditApplicationToITViewModel :  IExtandsBaseModel
    {
        public ApplicationTOITViewModelFluentValidator ValidationRules { get; set; } = new ApplicationTOITViewModelFluentValidator();

        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Note { get; set; }
        public string Contact { get; set; }
        public int ApplicationTypeId { get; set; }
        public int ApplicationPriorityId { get; set; }
        public int DepartmentId { get; set; }
        public int RoomId { get; set; }
        public int EmployeeId { get; set; }
        public int StateId { get; set; }

        public ApplicationPriorityViewModel Priority { get; set; }
        public ApplicationStateViewModel State { get; set; }
        public ApplicationTypeViewModel Type { get; set; }
        public EmployeeViewModel Employee { get; set; }
        public DepartmentViewModel Department { get; set; }
        public RoomViewModel Room { get; set; }

        public List<ApplicationPriorityViewModel> SelectPriority { get; set; }
        public List<ApplicationTypeViewModel> SelectType { get; set; }
        public List<ApplicationStateViewModel> SelectState { get; set; }
        public List<DepartmentViewModel> SelectDepartment { get; set; }
        public List<RoomViewModel> SelectRoom { get; set; }
        public List<EmployeeViewModel> SelectEmployee { get; set; }

        
        public CreateOrEditApplicationToITViewModel() { }

        public CreateOrEditApplicationToITViewModel(CreateOrEditApplicationToITViewModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Priority = model.Priority;
            Type = model.Type;
            State = model.State;
            Employee = model.Employee;
            Room = model.Room;
            Department = model.Department;
            Contact = model.Contact;
            Content = model.Content;
            Note = model.Note;

            SelectDepartment = model.SelectDepartment;
            SelectPriority = model.SelectPriority;
            SelectType = model.SelectType;
            SelectRoom = model.SelectRoom;
            SelectEmployee = model.SelectEmployee;
            SelectState = model.SelectState;
        }

        public CreateOrEditApplicationToITViewModel(ApplicationTOITViewModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Content = model.Content;
            Note = model.Note;
            Priority = model.Priority;
            Type = model.Type;
            State = model.State;
            Employee = model.Employee;
            Room = model.Room;
            Department = model.Departament;
            Contact = model.Contact;
        }

        public void SetAll(int id = 0)
        {
            throw new NotImplementedException();
        }
    }
}
