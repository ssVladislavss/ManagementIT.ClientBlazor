using Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UIBlazor.Data;
using UIBlazor.Models;
using UIBlazor.Models.ResponseModels;
using UIBlazor.Models.SharedTablesModel;
using UIBlazor.Models.SharedTablesModel.Department;
using UIBlazor.Services;

namespace UIBlazor.SharedTables.Data
{
    public class DepartamentManager : BaseExtandsManager<DepartmentViewModel, CreateOrEditDepartmentViewModel>
    {

        public DepartamentManager(HttpClient client) : base(client) => controller = "Department";
        

        public async Task<ActionResult<DepartmentViewModel>> CreateAsync(CreateOrEditDepartmentViewModel model)
        {
            try
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("Name", model.Name),
                    new KeyValuePair<string,string>("subdivisionId", model.Subdivision.Id.ToString()),
                });
                return await CreateAsync(content);
            }
            catch (Exception)
            {
                return new ActionResult<DepartmentViewModel>()
                { Type = NotificationType.Warn, Text = "Произошла ошибка, сервер не отвечает" };
            }
        }

        public async Task<ActionResult<DepartmentViewModel>> UpdateAsync(CreateOrEditDepartmentViewModel model)
        {
            try
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("Id", model.Id.ToString()),
                    new KeyValuePair<string,string>("Name", model.Name),
                    new KeyValuePair<string,string>("subdivisionId", model.Subdivision.Id.ToString()),
                });
                return await UpdateAsync(content);
            }
            catch (Exception)
            {
                return new ActionResult<DepartmentViewModel>()
                { Type = NotificationType.Warn, Text = "Произошла ошибка, сервер не отвечает" };
            }
        }
    }
}
