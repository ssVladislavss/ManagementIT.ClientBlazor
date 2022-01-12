using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UIBlazor.Models.ApplicationModel.Action
{
    public class DeleteSelectedActionRequest
    {
        public List<int> IdsAction { get; set; }

        public bool IsDeletianAction { get; set; }
        public bool IsChangeAction { get; set; }
        public bool IsStateChangeAction { get; set; }
        public bool IsChangePriorityAction { get; set; }
        public bool IsAddingArchiveAction { get; set; }
        public bool IsCreateAction { get; set; }
        public bool IsChangeEmployee { get; set; }

        public DateRange DateRange { get; set; } = new DateRange(Start, End);

        private static DateTime? Start { get; set; } = DateTime.Now.Date;
        private static DateTime? End { get; set; } = DateTime.Now.Date;

        public bool IsActiveSelect { get; set; }

        public DeleteSelectedActionRequest(){}
        public DeleteSelectedActionRequest(List<int> ids)
        {
            IdsAction = ids;
        }

        public bool IsSelectDate(DateTime? start, DateTime? end)
        {
            if (start == Start && end == End) return false;
            return true;
        }
        public void SetStaticDate()
        {
            Start = DateRange.Start;
            End = DateRange.End;
        }
    }
}
