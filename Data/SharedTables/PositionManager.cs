using Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UIBlazor.Data;
using UIBlazor.Models;
using UIBlazor.Models.ResponseModels;
using UIBlazor.Models.SharedTablesModel;
using UIBlazor.Models.SharedTablesModel.Position;

namespace UIBlazor.SharedTables.Data
{
    public class PositionManager : BaseManager<PositionViewModel>
    {
        public PositionManager(HttpClient client) : base(client)
        {
            controller = "Position";
        }

        public async Task<ActionResult<PositionViewModel>> CreateAsync(PositionViewModel entity)
        {
            try
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("Name", $"{entity.Name}")
                });
                return await CreateAsync(content);
            }
            catch (Exception)
            {
                return new ActionResult<PositionViewModel>()
                { Type = NotificationType.Warn, Text = "Произошла ошибка, сервер не отвечает" };
            }
        }

        public async Task<ActionResult<PositionViewModel>> UpdateAsync(PositionViewModel entity)
        {
            try
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("Id", $"{entity.Id}"),
                    new KeyValuePair<string,string>("Name", $"{entity.Name}"),
                });
                return await UpdateAsync(content);
            }
            catch (Exception)
            {
                return new ActionResult<PositionViewModel>()
                { Type = NotificationType.Warn, Text = "Произошла ошибка, сервер не отвечает" };
            }
        }
    }
}
