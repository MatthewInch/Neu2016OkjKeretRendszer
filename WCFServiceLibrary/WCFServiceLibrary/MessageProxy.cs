using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFServiceLibrary
{
    public class MessageProxy
    {
        private static readonly MessageProxy _instance = new MessageProxy();
        private Action<EndpointAddress, string> _action = null;

        static MessageProxy()
        { }

        public static MessageProxy Instance
        {
            get
            {
                return _instance;
            }
        }

        public void SetAction(Action<EndpointAddress, string> action)
        {
            _action = action;
        }

        public void SendMessage(string message)
        {
	        _action?.Invoke(null,message);
        }
    }
}
