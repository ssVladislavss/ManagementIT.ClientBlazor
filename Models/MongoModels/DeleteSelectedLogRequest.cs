using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UIBlazor.Models.MongoModels
{
    public class DeleteSelectedLogRequest
    {
        public List<string> LogIds { get; set; }
        public DeleteSelectedLogRequest(){}
        public DeleteSelectedLogRequest(List<string> ids)
        {
            LogIds = ids;
        }
    }
}
