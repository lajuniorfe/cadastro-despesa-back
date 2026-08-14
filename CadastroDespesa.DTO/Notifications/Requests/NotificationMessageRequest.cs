using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.DTO.Notifications.Requests
{
    public class NotificationMessageRequest
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
    }
}
