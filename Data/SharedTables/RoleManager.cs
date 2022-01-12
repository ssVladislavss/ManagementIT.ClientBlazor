using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UIBlazor.Data;
using UIBlazor.Models;
using UIBlazor.Models.SharedTablesModel;
using UIBlazor.Services;

namespace UIBlazor.SharedTables.Data
{
    //public class RoleManager : BaseManager<RoleViewModel>
    //{
    //    public RoleManager(HttpClient client) :base(client) => controller = "Role";

    //    public async Task<NotificationViewModelGeneric<RoleViewModel>> CreateRoleAsync(RoleViewModel entity)
    //    {
    //        try
    //        {
    //            var content = new FormUrlEncodedContent(new[]
    //            {
    //                new KeyValuePair<string,string>("RoleNames", $"{entity.RoleNames[0]}")
    //            });
    //            return await CreateAsync(content);
    //        }
    //        catch (Exception)
    //        {
    //            return new NotificationViewModelGeneric<RoleViewModel>()
    //                { Type = NotificationType.Warn, Text = "Произошла ошибка, сервер не отвечает" };
    //        }
    //    }

    //    public async Task<NotificationViewModelGeneric<RoleViewModel>> DeleteRoleAsync(RoleViewModel entity)
    //    {
    //        try
    //        {
    //            var result = await client.DeleteAsync($"/{controller}/delete?rolename={entity.Name}");
    //            return await ExtendFunction<RoleViewModel>.HandlingResponse(result);
    //        }
    //        catch (Exception)
    //        {
    //            return new NotificationViewModelGeneric<RoleViewModel>()
    //                { Type = NotificationType.Warn, Text = "Произошла ошибка, сервер не отвечает" };
    //        }
    //    }
    //}
}