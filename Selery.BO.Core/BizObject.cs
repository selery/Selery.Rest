using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Selery.BO.Core
{
    public class BizObject 
    {

        private string _webApiBaseEndPoint;
        public string WebApiBaseEndPoint
        {
            get { return _webApiBaseEndPoint; }
            set { _webApiBaseEndPoint = value; }
        }

        private string _contentType;
        public string ContentType
        {
            get { return _contentType; }
            set { _contentType = value; }
        }

        public BizObject()
        {
			_webApiBaseEndPoint = "http://192.168.0.9/Selery.Web.Api";
            _contentType = "application/json";
        }


    }
}
