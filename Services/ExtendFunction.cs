using Contracts.Enums;
using Contracts.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using UIBlazor.Models;
using UIBlazor.Models.ResponseModels;

namespace UIBlazor.Services
{
    public static class ExtendFunction<T>
    {
        public static async Task<ActionResult<T>> HandlingResponse(HttpResponseMessage responseMessage)
        {
            JsonSerializerOptions jsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };

            var _content = await responseMessage.Content.ReadAsStringAsync();
            try
            {
                return JsonSerializer.Deserialize<ActionResult<T>>(_content, jsonSerializerOptions);
            }
            catch (Exception e)
            {
                return new ActionResult<T>(NotificationType.Warn, e.Message, "Произошла ошибка", new List<TypeOfErrors> { TypeOfErrors.MappingError });
            }
        }
    }
}
