using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UIBlazor.Models;
using UIBlazor.Services;
using System.Threading;
using Contracts.ResponseModels;
using Contracts.Enums;
using System.Text.Json;
using UIBlazor.Models.SharedTablesModel.Building;
using UIBlazor.Models.ResponseModels;

namespace UIBlazor.Data
{
    public abstract class BaseManager<T> where T : BaseModel
    {
        protected HttpClient client;
        protected string controller;


        public BaseManager(HttpClient client)
        {
            this.client = client;
        }

        public async Task<ActionResult<List<T>>> GetListViewModelsAsync(bool updateCache = true)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"/{controller}/list?updateCache={updateCache}");
                var result = await ExtendFunction<List<T>>.HandlingResponse(response);
                
                if (result.Type == NotificationType.Success) result.Data.OrderBy(t => t.Id).ToList();
                return result;
            }
            catch (Exception)
            {
                return new ActionResult<List<T>>(NotificationType.Warn, "Сервер временно недоступен", "Произошла ошибка");
            }
        }

        public async Task<ActionResult<T>> GetModelByIdAsync(int appId)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"/{controller}/details?id={appId}");
                var result = await ExtendFunction<T>.HandlingResponse(response);

                return result;
            }
            catch (Exception)
            {
                return new ActionResult<T>(NotificationType.Warn, "Сервер временно недоступен", "Произошла ошибка");
            }
        }

        public async Task<ActionResult<T>> CreateAsync(FormUrlEncodedContent content)
        {
            try
            {
                var response = await client.PostAsync($"/{controller}/create", content);
                return await ExtendFunction<T>.HandlingResponse(response);
            }
            catch (Exception)
            {
                return new ActionResult<T>(NotificationType.Warn, "Сервер временно недоступен", "Произошла ошибка");
            }
        }

        public async Task<ActionResult<T>> UpdateAsync(FormUrlEncodedContent content)
        {
            try
            {
                var response = await client.PutAsync($"/{controller}/update", content);
                return await ExtendFunction<T>.HandlingResponse(response);
            }
            catch (Exception)
            {
                return new ActionResult<T>(NotificationType.Warn, "Сервер временно недоступен", "Произошла ошибка");
            }
        }

        public async Task<ActionResult<T>> DeleteAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"/{controller}/delete?id={id}");
                return await ExtendFunction<T>.HandlingResponse(response);
            }
            catch (Exception)
            {
                return new ActionResult<T>(NotificationType.Warn, "Сервер временно недоступен", "Произошла ошибка");
            }
        }
    }
}
