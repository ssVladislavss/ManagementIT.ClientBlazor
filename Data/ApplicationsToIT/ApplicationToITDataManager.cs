using Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UIBlazor.Models;
using UIBlazor.Models.ApplicationModel.Application;
using UIBlazor.Models.ResponseModels;
using UIBlazor.Services;

namespace UIBlazor.Data.ApplicationsToIT
{
    public class ApplicationToITDataManager : BaseExtandsManager<ApplicationTOITViewModel, CreateOrEditApplicationToITViewModel>
    {
        public ApplicationToITDataManager(HttpClient client) : base(client)
        {
            controller = "ApplicationToIt";
        }

        public async Task<ActionResult<ApplicationTOITViewModel>> CreateAsync(CreateOrEditApplicationToITViewModel model)
        {
            model.Name = $"{Guid.NewGuid()}: {model.Department?.Name}";
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("Name", model.Name),
                new KeyValuePair<string,string>("Content", model.Content),
                new KeyValuePair<string,string>("Note", model.Note),
                new KeyValuePair<string,string>("ApplicationTypeId", model.Type.Id.ToString()),
                new KeyValuePair<string,string>("DepartamentId", model.Department.Id.ToString()),
                new KeyValuePair<string,string>("RoomId", model.Room.Id.ToString()),
                new KeyValuePair<string,string>("RoomName", model.Room.Name),
                new KeyValuePair<string,string>("DepartamentName", model.Department.Name)
            });
            return await CreateAsync(content);
        }

        public async Task<ActionResult<ApplicationTOITViewModel>> UpdateAsync(CreateOrEditApplicationToITViewModel model)
        {
            model.Name = $"{Guid.NewGuid()}: {model.Department?.Name}";
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("Id", model.Id.ToString()),
                new KeyValuePair<string,string>("Name", model.Name),
                new KeyValuePair<string,string>("Content", model.Content),
                new KeyValuePair<string,string>("Note", model.Note),
                new KeyValuePair<string,string>("Contact", model.Contact),
                new KeyValuePair<string,string>("ApplicationTypeId", model.Type.Id.ToString()),
                new KeyValuePair<string,string>("ApplicationPriorityId", model.Priority.Id.ToString()),
                new KeyValuePair<string,string>("StateId", model.State.Id.ToString()),
                new KeyValuePair<string,string>("DepartamentId", model.Department.Id.ToString()),
                new KeyValuePair<string,string>("RoomId", model.Room.Id.ToString()),
                new KeyValuePair<string,string>("RoomName", model.Room.Name),
                new KeyValuePair<string,string>("DepartamentName", model.Department.Name)
            });
            return await UpdateAsync(content);
        }

        public async Task<ActionResult<List<ApplicationTOITViewModel>>> ListOrOnDelete(bool updateCache = true)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"/{controller}/listForOnDelete?updateCache={updateCache}");
                var result = await ExtendFunction<List<ApplicationTOITViewModel>>.HandlingResponse(response);
                return result;
            }
            catch (Exception)
            {
                return new ActionResult<List<ApplicationTOITViewModel>>(NotificationType.Warn, "Сервер временно недоступен", "Произошла ошибка");
            }
        }

        public async Task<ActionResult<ApplicationTOITViewModel>> DeleteRange()
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"/{controller}/deleteRange");
                var result = await ExtendFunction<ApplicationTOITViewModel>.HandlingResponse(response);
                return result;
            }
            catch (Exception)
            {
                return new ActionResult<ApplicationTOITViewModel>(NotificationType.Warn, "Сервер временно недоступен", "Произошла ошибка");
            }
        }

        public async Task<ActionResult<ApplicationTOITViewModel>> UpdateStateAsync(UpdateStateViewModel model)
        {
            try
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("AppId", model.ApplicationId.ToString()),
                    new KeyValuePair<string,string>("StateId", model.StateId.ToString()),
                });
                HttpResponseMessage response = await client.PutAsync($"/{controller}/updateState", content);
                var result = await ExtendFunction<ApplicationTOITViewModel>.HandlingResponse(response);
                return result;
            }
            catch (Exception)
            {
                return new ActionResult<ApplicationTOITViewModel>(NotificationType.Warn, "Сервер временно недоступен", "Произошла ошибка");
            }
        }

        public async Task<ActionResult<ApplicationTOITViewModel>> SetIniciator(UpdateEmployeeOrApplicationViewModel model)
        {
            try
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("AppId", model.AppId.ToString()),
                    new KeyValuePair<string,string>("IniciatorId", model.Employee.Id.ToString()),
                    new KeyValuePair<string,string>("IniciatorFullName", $"{model.Employee.Surname} {model.Employee.Name} {model.Employee.Patronymic}"),
                    new KeyValuePair<string,string>("Contact", model.Contact),
                });
                HttpResponseMessage response = await client.PutAsync($"/{controller}/setIniciator", content);
                var result = await ExtendFunction<ApplicationTOITViewModel>.HandlingResponse(response);
                return result;
            }
            catch (Exception)
            {
                return new ActionResult<ApplicationTOITViewModel>(NotificationType.Warn, "Сервер временно недоступен", "Произошла ошибка");
            }
        }

        public async Task<ActionResult<ApplicationTOITViewModel>> UpdateEmployeeAsync(UpdateEmployeeOrApplicationViewModel model)
        {
            try
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("AppId", model.AppId.ToString()),
                    new KeyValuePair<string,string>("EmployeeId", model.Employee.Id.ToString()),
                    new KeyValuePair<string,string>("EmployeeFullName", $"{model.Employee.Surname} {model.Employee.Name} {model.Employee.Patronymic}"),
                    //new KeyValuePair<string,string>("Contact", model.Contact.ToString())
                });
                HttpResponseMessage response = await client.PutAsync($"/{controller}/updateEmployee", content);
                var result = await ExtendFunction<ApplicationTOITViewModel>.HandlingResponse(response);
                return result;
            }
            catch (Exception)
            {
                return new ActionResult<ApplicationTOITViewModel>(NotificationType.Warn, "Сервер временно недоступен", "Произошла ошибка");
            }
        }

        public async Task<ActionResult<ApplicationTOITViewModel>> UpdatePriorityAsync(UpdatePriorityViewModel model)
        {
            try
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("AppId", model.AppId.ToString()),
                    new KeyValuePair<string,string>("PriorityId", model.PriorityId.ToString()),
                });
                HttpResponseMessage response = await client.PutAsync($"/{controller}/updatePriority", content);
                var result = await ExtendFunction<ApplicationTOITViewModel>.HandlingResponse(response);
                return result;
            }
            catch (Exception)
            {
                return new ActionResult<ApplicationTOITViewModel>(NotificationType.Warn, "Сервер временно недоступен", "Произошла ошибка");
            }
        }

        public async Task<ActionResult<ApplicationTOITViewModel>> OnDeleteAsync(int id)
        {
            try
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("id", id.ToString())
                });
                HttpResponseMessage response = await client.PutAsync($"/{controller}/onDelete", content);
                var result = await ExtendFunction<ApplicationTOITViewModel>.HandlingResponse(response);
                return result;
            }
            catch (Exception)
            {
                return new ActionResult<ApplicationTOITViewModel>(NotificationType.Warn, "Сервер временно недоступен", "Произошла ошибка");
            }
        }
    }
}
