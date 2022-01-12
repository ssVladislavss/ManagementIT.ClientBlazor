using System.Collections.Generic;
using UIBlazor.Models.SharedTablesModel.Employee;

namespace UIBlazor.Models.ApplicationModel.Application
{
    public class UpdateEmployeeOrApplicationViewModel
    {
        public int AppId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeFullName { get; set; }
        public string Contact { get; set; }

        public EmployeeViewModel Employee { get; set; }
        public List<EmployeeViewModel> SelectEmployee { get; set; }

        public UpdateEmployeeFluentValidator Validator { get; set; } = new UpdateEmployeeFluentValidator();

        public bool IsIniciator { get; set; }
    }
}
