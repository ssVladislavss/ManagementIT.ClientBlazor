using Contracts.Enums;
using Contracts.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UIBlazor.Data;
using UIBlazor.Models;
using UIBlazor.Models.ResponseModels;
using UIBlazor.Models.SharedTablesModel;
using UIBlazor.Models.SharedTablesModel.Building;
using UIBlazor.Services;

namespace UIBlazor.SharedTables.Data
{
    public class BuildingsManager : BaseManager<BuildingViewModel>
    {
        public BuildingsManager(HttpClient client): base(client)
        {
            controller = "Building";
        }

        public async Task<ActionResult<BuildingViewModel>> CreateAsync(BuildingViewModel entity)
        {
            try
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("Name", $"{entity.Name}"),
                    new KeyValuePair<string,string>("Address", $"{entity.Address}"),
                    new KeyValuePair<string,string>("Floor", $"{entity.Floor}")
                });
                return await CreateAsync(content);
            }
            catch (Exception)
            {
                return new ActionResult<BuildingViewModel>(NotificationType.Warn, "Сервер временно недоступен", "Произошла ошибка");   
            }
        }

        public async Task<ActionResult<BuildingViewModel>> UpdateAsync(BuildingViewModel entity)
        {
            try
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("Id", $"{entity.Id}"),
                    new KeyValuePair<string,string>("Name", $"{entity.Name}"),
                    new KeyValuePair<string,string>("Address", $"{entity.Address}"),
                    new KeyValuePair<string,string>("Floor", $"{entity.Floor}")
                });
                return await UpdateAsync(content);
            }
            catch (Exception)
            {
                return new ActionResult<BuildingViewModel>(NotificationType.Warn, "Сервер временно недоступен", "Произошла ошибка");
            }
        }
    }
}
