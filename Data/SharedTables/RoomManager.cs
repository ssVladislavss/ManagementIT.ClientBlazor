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
using UIBlazor.Models.SharedTablesModel.Room;
using UIBlazor.Services;


namespace UIBlazor.SharedTables.Data
{
    public class RoomManager : BaseExtandsManager<RoomViewModel, CreateOrEditRoomViewModel>
    {
        public RoomManager(HttpClient client) : base(client)
        {
            controller = "Room";
        }

        public async Task<ActionResult<RoomViewModel>> CreateAsync(CreateOrEditRoomViewModel model)
        {
            try
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("Name", model.Name),
                    new KeyValuePair<string,string>("Floor", model.Floor.ToString()),
                    new KeyValuePair<string,string>("BuildingId", model.Building.Id.ToString()),
                    new KeyValuePair<string,string>("DepartamentId", model.Departament.Id.ToString()),
                    new KeyValuePair<string,string>("RequiredCountSocket", model.RequiredCountSocket.ToString()),
                    new KeyValuePair<string,string>("CurrentCountSocket", model.CurrentCountSocket.ToString()),
                });
                return await CreateAsync(content);
            }
            catch (Exception)
            {
                return new ActionResult<RoomViewModel>()
                { Type = NotificationType.Warn, Text = "Произошла ошибка, сервер не отвечает" };
            }
        }

        public async Task<ActionResult<RoomViewModel>> UpdateAsync(CreateOrEditRoomViewModel model)
        {
            try
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("Id", model.Id.ToString()),
                    new KeyValuePair<string,string>("Name", model.Name),
                    new KeyValuePair<string,string>("Floor", model.Floor.ToString()),
                    new KeyValuePair<string,string>("BuildingId", model.Building.Id.ToString()),
                    new KeyValuePair<string,string>("DepartamentId", model.Departament.Id.ToString()),
                    new KeyValuePair<string,string>("RequiredCountSocket", model.RequiredCountSocket.ToString()),
                    new KeyValuePair<string,string>("CurrentCountSocket", model.CurrentCountSocket.ToString()),
                });
                return await UpdateAsync(content);
            }
            catch (Exception)
            {
                return new ActionResult<RoomViewModel>()
                { Type = NotificationType.Warn, Text = "Произошла ошибка, сервер не отвечает" };
            }
        }
    }
}
