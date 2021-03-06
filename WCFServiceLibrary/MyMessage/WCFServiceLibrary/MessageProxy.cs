﻿using System;
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
        private Action<string> _connetcAction = null;

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

        public void SetConnectAction(Action<string> action)
        {
            _connetcAction = action;
        }

        public void SenIP(string ipAddress)
        {
            if(_connetcAction != null)
            {
                _connetcAction(ipAddress);
            }
        }
    }
}
