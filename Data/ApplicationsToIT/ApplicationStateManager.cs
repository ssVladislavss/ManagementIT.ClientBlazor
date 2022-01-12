using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UIBlazor.Models;
using UIBlazor.Models.ApplicationModel.State;
using UIBlazor.Models.ResponseModels;

namespace UIBlazor.Data.ApplicationsToIT
{
    public class ApplicationStateManager : BaseManager<ApplicationStateViewModel>
    {
        public ApplicationStateManager(HttpClient client) : base(client)
        {
            controller = "State";
        }

        public async Task<ActionResult<ApplicationStateViewModel>> CreateAsync(ApplicationStateViewModel entity)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("Name", entity.Name),
                new KeyValuePair<string,string>("BGColor", entity.BGColor),
                new KeyValuePair<string,string>("IsDefault", entity.IsDefault.ToString())
            });
            return await CreateAsync(content);
        }

        public async Task<ActionResult<ApplicationStateViewModel>> UpdateAsync(ApplicationStateViewModel entity)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("Id", entity.Id.ToString()),
                new KeyValuePair<string,string>("Name", entity.Name),
                new KeyValuePair<string,string>("BGColor", entity.BGColor),
                new KeyValuePair<string,string>("IsDefault", entity.IsDefault.ToString())
            });
            return await UpdateAsync(content);
        }
    }
}
