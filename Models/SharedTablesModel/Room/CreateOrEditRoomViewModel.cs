using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIBlazor.Models.SharedTablesModel.Building;
using UIBlazor.Models.SharedTablesModel.Department;
using UIBlazor.Models.SharedTablesModel.Validation;

namespace UIBlazor.Models.SharedTablesModel.Room
{
    public class CreateOrEditRoomViewModel : IExtandsBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BuildingViewModel Building { get; set; }
        public int Floor { get; set; }
        public DepartmentViewModel Departament { get; set; }
        public int RequiredCountSocket { get; set; }
        public int CurrentCountSocket { get; set; }

        public List<BuildingViewModel> SelectBuilding { get; set; }
        public List<DepartmentViewModel> SelectDepartment { get; set; }

        public CreateOrEditRoomFluentValidation Validator { get; set; } = new CreateOrEditRoomFluentValidation();

        public CreateOrEditRoomViewModel() {}
        public CreateOrEditRoomViewModel(RoomViewModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Floor = model.Floor;
            RequiredCountSocket = model.RequiredCountSocket;
            CurrentCountSocket = model.CurrentCountSocket;
            Building = model.Building;
            Departament = model.Departament;
        }

        public void SetAll(int id = 0)
        {
            throw new NotImplementedException();
        }
    }
}
