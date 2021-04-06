using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConnectionLibrary
{
    public class ConnectApiModel
    {
        public string UrlEndPoint { get; set; }
        public string Schema { get; set; }
        public string AuthorizationToken { get; set; }
        public object Parameters { get; set; }
    }
}
