using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UIBlazor.Data;
using UIBlazor.Models;
using UIBlazor.Models.ResponseModels;
using UIBlazor.Models.SharedTablesModel;
using UIBlazor.Models.SharedTablesModel.Subdivision;
using UIBlazor.Services;

namespace UIBlazor.SharedTables.Data
{
    public class SubdivisionManager : BaseManager<SubdivisionViewModel>
    {
        public SubdivisionManager(HttpClient client) : base(client)
        {
            controller = "Subdivision";
        }

        public async Task<ActionResult<SubdivisionViewModel>> CreateAsync(SubdivisionViewModel model)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("Name", model.Name),
            });
            return await CreateAsync(content);
        }

        public async Task<ActionResult<SubdivisionViewModel>> UpdateAsync(SubdivisionViewModel model)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("Id", model.Id.ToString()),
                new KeyValuePair<string,string>("Name", model.Name),
            });
            return await UpdateAsync(content);
        }
    }
}
