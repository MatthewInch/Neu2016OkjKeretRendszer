﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MessageService : IMessageService
    {
        public string GetMessage(string value)
        {
            MessageProxy.Instance.SendMessage(value);
            return string.Format("You entered: {0}", value);
        }



        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


        public string GetClientIP(string ipAddress)
        {
            MessageProxy.Instance.SenIP(ipAddress);
            return "OK";
        }
    }
}
