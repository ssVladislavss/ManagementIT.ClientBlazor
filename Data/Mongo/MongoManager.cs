using Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using UIBlazor.Models.MongoModels;
using UIBlazor.Models.ResponseModels;
using UIBlazor.Services;

namespace UIBlazor.Data.Mongo
{
    public class MongoManager : BaseManager<LogMessage>
    {
        public MongoManager(HttpClient client) : base(client)
        {
            controller = "Log";
        }

        public async Task<ActionResult<List<LogMessage>>> GetAllLogsAsync()
        {
            try
            {
                var response = await client.GetAsync($"/{controller}/list");

                if ((int)response.StatusCode == 200)
                {
                    var result = await ExtendFunction<List<LogMessage>>.HandlingResponse(response);
                    return result;
                }

                throw new ArgumentException();
            }
            catch (Exception)
            {
                return new ActionResult<List<LogMessage>>()
                { Type = NotificationType.Warn, Text = "Сервис временно недоступен" };
            }
        }

        public async Task<ActionResult<LogMessage>> DeleteLog(string id)
        {
            try
            {
                var response = await client.DeleteAsync($"/{controller}/delete?id={id}");
                if ((int)response.StatusCode == 200)
                {
                    var result = await ExtendFunction<LogMessage>.HandlingResponse(response);
                    return result;
                }

                throw new ArgumentException();
            }
            catch (Exception)
            {
                return new ActionResult<LogMessage>()
                { Type = NotificationType.Warn, Text = "Сервис временно недоступен" };
            }
        }

        public async Task<ActionResult<LogMessage>> DeleteLog(List<string> ids)
        {
            try
            {
                var model = new DeleteSelectedLogRequest(ids);
                var jsonIds = JsonSerializer.Serialize(model);
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("ids", jsonIds)
                });
                var response = await client.PostAsync($"/{controller}/deleteSelected", content);
                if ((int)response.StatusCode == 200)
                {
                    var result = await ExtendFunction<LogMessage>.HandlingResponse(response);
                    return result;
                }

                throw new ArgumentException();
            }
            catch (Exception)
            {
                return new ActionResult<LogMessage>()
                { Type = NotificationType.Warn, Text = "Сервис временно недоступен" };
            }
        }
    }
}