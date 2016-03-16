using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServiceLibrary
{
    public class MessageProxy
    {
        private static readonly MessageProxy _instance = new MessageProxy();
        private Action<string> _action = null;
        private Action<string> _ipAction = null;

        static MessageProxy()
        { }

        public static MessageProxy Instance
        {
            get
            {
                return _instance;
            }
        }

        public void SetAction(Action<string> action)
        {
            _action = action;
        }

        public void SendMessage(string message)
        {
            if (_action != null)
            {
                _action(message);
            }
        }

        public void SetIPAddressAction(Action<string> action)
        {
            _ipAction = action;
        }

        public void SetIpAddress(string ipAddress)
        {
            if (_ipAction != null)
            {
                _ipAction(ipAddress);
            }
        }
    }

}
