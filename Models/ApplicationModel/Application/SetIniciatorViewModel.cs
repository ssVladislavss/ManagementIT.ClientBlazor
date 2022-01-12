using System.Collections.Generic;
using UIBlazor.Models.SharedTablesModel.Employee;

namespace UIBlazor.Models.ApplicationModel.Application
{
    public class SetIniciatorViewModel
    {
        public int AppId { get; set; }
        public int IniciatorId { get; set; }
        public string IniciatorFullName { get; set; }
        public string Contact { get; set; }

        public EmployeeViewModel Employee { get; set; }
        public List<EmployeeViewModel> SelectEmployee { get; set; }

        public SetIniciatorFluentValidator Validator { get; set; } = new SetIniciatorFluentValidator();
    }
}
