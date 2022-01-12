using UIBlazor.Models.SharedTablesModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UIBlazor.Data;
using Microsoft.AspNetCore.Components;

using FluentValidation;
using UIBlazor.Models.SharedTablesModel.Department;
using UIBlazor.Models.SharedTablesModel.Room;
using UIBlazor.Models.SharedTablesModel.Employee;
using UIBlazor.Models.ApplicationModel.Type;
using UIBlazor.Models.ApplicationModel.State;
using UIBlazor.Models.ApplicationModel.Priority;

namespace UIBlazor.Models.ApplicationModel.Application
{
    public class ApplicationTOITViewModel : BaseModel, IComparable<ApplicationTOITViewModel>
    {
        public string Content { get; set; }
        public string Note { get; set; }
        public string Contact { get; set; }
        public ApplicationStateViewModel State { get; set; }
        public ApplicationPriorityViewModel Priority { get; set; }
        public ApplicationTypeViewModel Type { get; set; }
        public DepartmentViewModel Departament { get; set; }
        public RoomViewModel Room { get; set; }
        public EmployeeViewModel Employee { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeFullName { get; set; }
        public string RoomName { get; set; }
        public string DepartamentName { get; set; }

        public int IniciatorId { get; set; }
        public string IniciatorFullName { get; set; }

        public bool OnDelete { get; set; }

        public ApplicationTOITViewModel() { }

        public ApplicationTOITViewModel(ApplicationTOITViewModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Priority = model.Priority;
            Type = model.Type;
            Content = model.Content;
            Note = model.Note;
            Departament = model.Departament;
            Room = model.Room;
            Employee = model.Employee;
            State = model.State;
            Priority = model.Priority;
            Type = model.Type;
            State = model.State;
            Employee = model.Employee;
            Room = model.Room;
            Departament = model.Departament;
            Contact = model.Contact;
        }

        public int CompareTo(ApplicationTOITViewModel other)
        {
            if (Id > other.Id) return -1;
            if (Id < other.Id) return 1;
            return 0;
        }
    }
}
