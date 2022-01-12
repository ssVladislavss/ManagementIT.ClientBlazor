using Contracts.Enums;
using Contracts.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UIBlazor.Models;
using UIBlazor.Models.ResponseModels;
using UIBlazor.Services;

namespace UIBlazor.Data
{
    public class BaseExtandsManager<BaseViewModel, CreateOrEditViewModel> : BaseManager<BaseViewModel>
        where BaseViewModel : BaseModel
        where CreateOrEditViewModel : IExtandsBaseModel
    {
        public BaseExtandsManager(HttpClient client) : base(client) { }

        public async Task<ActionResult<CreateOrEditViewModel>> GetForCreateAsync()
        {
            try
            {
                var response = await client.GetAsync($"/{controller}/create");
                var result = await ExtendFunction<CreateOrEditViewModel>.HandlingResponse(response);
                //if (result.Data != null) result.Data.SetAll();
                return result;
            }
            catch (Exception)
            {
                return new ActionResult<CreateOrEditViewModel>(NotificationType.Warn, "Сервер временно недоступен", "Произошла ошибка");
            }
        }

        public async Task<ActionResult<CreateOrEditViewModel>> GetForUpdateAsync(int id)
        {
            try
            {
                var response = await client.GetAsync($"/{controller}/update?id={id}");
                var result = await ExtendFunction<CreateOrEditViewModel>.HandlingResponse(response);
                //if (result.Data != null) result.Data.SetAll(id);
                return result;
            }
            catch (Exception)
            {
                return new ActionResult<CreateOrEditViewModel>()
                { Type = NotificationType.Warn, Text = "Произошла ошибка, сервер не отвечает" };
            }
        }
    }
}
