using Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using UIBlazor.Models.ApplicationModel.Action;
using UIBlazor.Models.ResponseModels;
using UIBlazor.Services;

namespace UIBlazor.Data.ApplicationsToIT
{
    public class ActionManager : BaseManager<ActionViewModel>
    {
        public ActionManager(HttpClient client) : base(client) => controller = "Action";

        public async Task<ActionResult<List<ActionViewModel>>> GetActionByApplicationIdAsync(int applicationId)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"/{controller}/listOrAppId?id={applicationId}");
                var result = await ExtendFunction<List<ActionViewModel>>.HandlingResponse(response);

                if (result.Type == NotificationType.Success) result.Data.OrderBy(t => t.Id).ToList();
                return result;
            }
            catch (Exception)
            {
                return new ActionResult<List<ActionViewModel>>(NotificationType.Warn, "Сервер временно недоступен", "Произошла ошибка");
            }
        }

        public async Task<ActionResult<List<ActionViewModel>>> GetActionByActionTypeAsync(int numberType)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"/{controller}/listByActionType?NumberType={numberType}");
                var result = await ExtendFunction<List<ActionViewModel>>.HandlingResponse(response);

                if (result.Type == NotificationType.Success) result.Data.OrderBy(t => t.Id).ToList();
                return result;
            }
            catch (Exception)
            {
                return new ActionResult<List<ActionViewModel>>(NotificationType.Warn, "Сервер временно недоступен", "Произошла ошибка");
            }
        }

        public async Task<ActionResult<ActionViewModel>> DeleteSelectedAsync(DeleteSelectedActionRequest model)
        {
            try
            {
                var jsonIds = JsonSerializer.Serialize(model);
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("jsonIds", jsonIds)
                });
                var response = await client.PostAsync($"/{controller}/deleteSelected", content);
                return await ExtendFunction<ActionViewModel>.HandlingResponse(response);
            }
            catch (Exception)
            {
                return new ActionResult<ActionViewModel>(NotificationType.Warn, "Сервер временно недоступен", "Произошла ошибка");
            }
        }
    }
}
