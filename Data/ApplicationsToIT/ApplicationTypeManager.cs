using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UIBlazor.Models;
using UIBlazor.Models.ApplicationModel.Type;
using UIBlazor.Models.ResponseModels;

namespace UIBlazor.Data.ApplicationsToIT
{
    public class ApplicationTypeManager : BaseManager<ApplicationTypeViewModel>
    {
        public ApplicationTypeManager(HttpClient client) : base(client)
        {
            controller = "Type";
        }

        public async Task<ActionResult<ApplicationTypeViewModel>> CreateAsync(ApplicationTypeViewModel model)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("Name", model.Name)
            });
            return await CreateAsync(content);
        }

        public async Task<ActionResult<ApplicationTypeViewModel>> UpdateAsync(ApplicationTypeViewModel model)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("Id", model.Id.ToString()),
                new KeyValuePair<string,string>("Name", model.Name)
            });
            return await UpdateAsync(content);
        }
    }
}
