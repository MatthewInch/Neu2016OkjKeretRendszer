using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServiceLibrary
{
    public class MessageProxy
    {
        private static MessageProxy _instance;
        private Action<string> _action = null;

        //static MessageProxy()
        //{ }

        public static MessageProxy Instance
        {
            get
            {
                if (_instance == null)
                {
                    Instance = new MessageProxy();
                }
                return _instance;
            }
            set { _instance = value; }
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

        public void SendIP(string value)
        {
            if (_action!=null)
            {

            }
        }
    }
}
