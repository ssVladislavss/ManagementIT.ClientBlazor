using Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UIBlazor.Models.ResponseModels
{
    public class ActionResult<T>
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Typestr { get { return Type.ToString(); } }
        public NotificationType Type { get; set; }
        public List<TypeOfErrors> Errors { get; set; }
        public string AspNetException { get; set; }
        public T Data { get; set; }

        public ActionResult() 
        {
            Text = "Success";
            Type = NotificationType.Success;
            Errors = new List<TypeOfErrors>();
            Title = "Запрос обработан";

        }
        public ActionResult(NotificationType type, string text = "success", string title = "Запрос обработан", List<TypeOfErrors> errors = null)
        {
            Type = type;
            Text = text;
            Title = title;
            Errors = errors == null ? new List<TypeOfErrors>() : errors;
        }
    }
}
