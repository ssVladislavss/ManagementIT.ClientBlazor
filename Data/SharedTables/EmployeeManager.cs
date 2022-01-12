using Contracts.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using UIBlazor.Data;
using UIBlazor.Models;
using UIBlazor.Models.ResponseModels;
using UIBlazor.Models.SharedTablesModel;
using UIBlazor.Models.SharedTablesModel.Employee;
using UIBlazor.Services;

namespace UIBlazor.SharedTables.Data
{
    public class EmployeeManager : BaseExtandsManager<EmployeeViewModel, CreateOrEditEmployeeViewModel>
    {
        public EmployeeManager(HttpClient client) : base(client)
        {
            controller = "Employee";
        }

        //public async Task<NotificationViewModelGeneric<string>> RegisterEmployeeForIdentity(RegisterEmployeeModel model)
        //{
        //    try
        //    {
        //        var content = new FormUrlEncodedContent(new[]
        //        {
        //            new KeyValuePair<string,string>("EmployeeId", model.EmployeeId.ToString()),
        //            new KeyValuePair<string,string>("UserName", model.UserName),
        //            new KeyValuePair<string,string>("Password", model.Password),
        //        });
        //        var result = await client.PostAsync($"/{controller}/identity/register", content);
        //        var response = await ExtendFunction<string>.HandlingResponse(result);
        //        return response;
        //    }
        //    catch (Exception)
        //    {
        //        return new NotificationViewModelGeneric<string>()
        //        { Type = NotificationType.Warn, Text = "Произошла ошибка, сервер не отвечает" };
        //    }
        //}

        //public async Task<NotificationViewModelGeneric<string>> DeleteEmployeeForIdentity(int employeeId)
        //{
        //    try
        //    {
        //        var result = await client.DeleteAsync($"/{controller}/identity/delete?employeeId={employeeId}");
        //        var response = await ExtendFunction<string>.HandlingResponse(result);
        //        return response;
        //    }
        //    catch (Exception)
        //    {
        //        return new NotificationViewModelGeneric<string>()
        //        { Type = NotificationType.Warn, Text = "Произошла ошибка, сервер не отвечает" };
        //    }
        //}

        public async Task<ActionResult<EmployeeViewModel>> DeleteImageEmployeeAsync(int employeeId)
        {
            try
            {
                var result = await client.DeleteAsync($"/{controller}/deletePhoto?id={employeeId}");
                var response = await ExtendFunction<EmployeeViewModel>.HandlingResponse(result);
                return response;
            }
            catch (Exception)
            {
                return new ActionResult<EmployeeViewModel>()
                { Type = NotificationType.Warn, Text = "Произошла ошибка, сервер не отвечает" };
            }
        }

        //public async Task<ActionResult<CreateOrEditRoleEmployeeModel>> GetSetRoleEmployeeForIdentity(string userName)
        //{
        //    try
        //    {
        //        var result = await client.GetAsync($"/{controller}/identity/userRole?userName={userName}");
        //        var response = await ExtendFunction<CreateOrEditRoleEmployeeModel>.HandlingResponse(result);
        //        return response;
        //    }
        //    catch (Exception)
        //    {
        //        return new NotificationViewModelGeneric<CreateOrEditRoleEmployeeModel>()
        //        { Type = NotificationType.Warn, Text = "Произошла ошибка, сервер не отвечает" };
        //    }

        //}

        //public async Task<NotificationViewModelGeneric<CreateOrEditRoleEmployeeModel>> PostSetRoleEmployeeAsync(CreateOrEditRoleEmployeeModel model)
        //{
        //    try
        //    {
        //        var jsonModel = JsonSerializer.Serialize(model);

        //        var content = new FormUrlEncodedContent(new[]
        //        {
        //            new KeyValuePair<string,string>("json", jsonModel)
        //        });

        //        var result = await client.PutAsync($"/{controller}/identity/updateRole", content);
        //        var response = await ExtendFunction<CreateOrEditRoleEmployeeModel>.HandlingResponse(result);
        //        return response;
        //    }
        //    catch (Exception e)
        //    {
        //        return new NotificationViewModelGeneric<CreateOrEditRoleEmployeeModel>()
        //        { Type = NotificationType.Warn, Text = "Произошла ошибка, сервер не отвечает" };
        //    }

        //}

        //public async Task<NotificationViewModelGeneric<CreateOrEditAccountEmployeeViewModel>> UpdateAccountEmployeeAsync(CreateOrEditAccountEmployeeViewModel model)
        //{
        //    try
        //    {
        //        var content = new FormUrlEncodedContent(new[]
        //        {
        //            new KeyValuePair<string,string>("EmployeeId", model.EmployeeId.ToString()),
        //            new KeyValuePair<string,string>("Surname", model.SurName),
        //            new KeyValuePair<string,string>("Name", model.Name),
        //            new KeyValuePair<string,string>("Patronumic", model.Patronumic),
        //            new KeyValuePair<string,string>("Email", model.Email),
        //            new KeyValuePair<string,string>("UserName", model.UserName),
        //            new KeyValuePair<string,string>("WorkTelephone", model.WorkTelephone),
        //            new KeyValuePair<string,string>("MobileTelephone", model.MobileTelephone),
        //            new KeyValuePair<string,string>("DepartamentId", model.Departament.Id.ToString()),
        //            new KeyValuePair<string,string>("PositionId", model.Position.Id.ToString()),

        //        });

        //        var result = await client.PutAsync($"/{controller}/identity/updateAccount", content);
        //        var response = await ExtendFunction<CreateOrEditAccountEmployeeViewModel>.HandlingResponse(result);
        //        return response;
        //    }
        //    catch (Exception)
        //    {
        //        return new NotificationViewModelGeneric<CreateOrEditAccountEmployeeViewModel>()
        //        { Type = NotificationType.Warn, Text = "Произошла ошибка, сервер не отвечает" };
        //    }
        //}

        //public async Task<NotificationViewModelGeneric<ResetPasswordEmployeeViewModel>> ResetPasswordEmployeeAsync(ResetPasswordEmployeeViewModel model)
        //{
        //    try
        //    {
        //        var content = new FormUrlEncodedContent(new[]
        //        {
        //            new KeyValuePair<string,string>("UserName", model.UserName),
        //            new KeyValuePair<string,string>("OldPassword", model.OldPassword),
        //            new KeyValuePair<string,string>("NewPassword", model.NewPassword),
        //        });

        //        var result = await client.PutAsync($"/{controller}/identity/passwordReset", content);
        //        var response = await ExtendFunction<ResetPasswordEmployeeViewModel>.HandlingResponse(result);
        //        return response;
        //    }
        //    catch (Exception)
        //    {
        //        return new NotificationViewModelGeneric<ResetPasswordEmployeeViewModel>()
        //        { Type = NotificationType.Warn, Text = "Произошла ошибка, сервер не отвечает" };
        //    }
        //}

        //public async Task<ActionResult<EmployeeViewModel>> GetEmployeeByIdAsync(int employeeId)
        //{
        //    var result = await client.GetAsync($"/{controller}/details?id={employeeId}");
        //    var response = await ExtendFunction<EmployeeViewModel>.HandlingResponse(result);
        //    return response;
        //}

        public async Task<ActionResult<EmployeeViewModel>> GetEmployeeByUserNameAsync(string userName)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"/{controller}/byUserName?userName={userName}");
                var result = await ExtendFunction<EmployeeViewModel>.HandlingResponse(response);

                return result;
            }
            catch (Exception)
            {
                return new ActionResult<EmployeeViewModel>(NotificationType.Warn, "Сервер временно недоступен", "Произошла ошибка");
            }
        }

        public async Task<ActionResult<EmployeeViewModel>> CreateAsync(CreateOrEditEmployeeViewModel model)
        {
            if (model.MobileTelephone == "+7 " || model.MobileTelephone == "+7") model.MobileTelephone = null;
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("Surname", model.Surname),
                new KeyValuePair<string,string>("Name", model.Name),
                new KeyValuePair<string,string>("Patronymic", model.Patronymic),
                new KeyValuePair<string,string>("DepartamentId", model.Departament.Id.ToString()),
                new KeyValuePair<string,string>("PositionId", model.Position.Id.ToString()),
                new KeyValuePair<string,string>("WorkTelephone", model.WorkTelephone),
                new KeyValuePair<string,string>("MobileTelephone", model.MobileTelephone),
                new KeyValuePair<string,string>("Mail", model.Mail),
                new KeyValuePair<string,string>("User", model.User),
            });
            return await CreateAsync(content);
        }

        public async Task<ActionResult<EmployeeViewModel>> UpdateAsync(CreateOrEditEmployeeViewModel model)
        {
            if (model.MobileTelephone == "+7 " || model.MobileTelephone == "+7") model.MobileTelephone = null;
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("Id", model.Id.ToString()),
                new KeyValuePair<string,string>("Surname", model.Surname),
                new KeyValuePair<string,string>("Name", model.Name),
                new KeyValuePair<string,string>("Patronymic", model.Patronymic),
                new KeyValuePair<string,string>("DepartamentId", model.Departament.Id.ToString()),
                new KeyValuePair<string,string>("PositionId", model.Position.Id.ToString()),
                new KeyValuePair<string,string>("WorkTelephone", model.WorkTelephone),
                new KeyValuePair<string,string>("MobileTelephone", model.MobileTelephone),
                new KeyValuePair<string,string>("Mail", model.Mail),
                new KeyValuePair<string,string>("User", model.User),
            });
            return await UpdateAsync(content);
        }
        public async Task<ActionResult<EmployeeViewModel>> WorkOrPhotoEmployeeAsync(CreateOrEditEmployeeViewModel model)
        {
            try
            {
                ActionResult<EmployeeViewModel> response = null;
                using (var content = new MultipartFormDataContent())
                {
                    var fileContent =
                        new StreamContent(model.Photo.OpenReadStream(15120000));


                    fileContent.Headers.ContentType =
                        new MediaTypeHeaderValue(model.Photo.ContentType);

                    content.Add(
                        content: fileContent,
                        name: "\"Photo\"",
                        fileName: model.Photo.Name);

                    var idParameter = new StringContent(model.Id.ToString());
                    idParameter.Headers.Add("Content-Disposition", "form-data; name=\"EmployeeId\"");
                    content.Add(idParameter, "EmployeeId");

                    var result = await client.PutAsync($"/{controller}/updatePhoto", content);
                    response = await ExtendFunction<EmployeeViewModel>.HandlingResponse(result);
                }

                return response;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("Supplied file with size 1437403 bytes exceeds the maximum of 512000 bytes."))
                    return new ActionResult<EmployeeViewModel>()
                    { Type = NotificationType.Warn, Text = "Произошла ошибка, файл превышает допустимый размер" };

                return new ActionResult<EmployeeViewModel>()
                { Type = NotificationType.Warn, Text = "Произошла ошибка, сервер не отвечает" };
            }
        }
    }
}
