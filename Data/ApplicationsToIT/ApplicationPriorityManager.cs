using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UIBlazor.Models;
using UIBlazor.Models.ApplicationModel.Priority;
using UIBlazor.Models.ResponseModels;

namespace UIBlazor.Data.ApplicationsToIT
{
    public class ApplicationPriorityManager : BaseManager<ApplicationPriorityViewModel>
    {
        public ApplicationPriorityManager(HttpClient client) : base(client)
        {
            controller = "Priority";
        }

        public async Task<ActionResult<ApplicationPriorityViewModel>> CreateAsync(ApplicationPriorityViewModel entity)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("Name", entity.Name),
                new KeyValuePair<string,string>("IsDefault", entity.IsDefault.ToString())
            });
            return await CreateAsync(content);
        }

        public async Task<ActionResult<ApplicationPriorityViewModel>> UpdateAsync(ApplicationPriorityViewModel entity)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("Id", entity.Id.ToString()),
                new KeyValuePair<string,string>("Name", entity.Name),
                new KeyValuePair<string,string>("IsDefault", entity.IsDefault.ToString())
            });
            return await UpdateAsync(content);
        }
    }
}
