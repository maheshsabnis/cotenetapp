using System;

namespace cotenetapp.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string ErrorMessage { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}