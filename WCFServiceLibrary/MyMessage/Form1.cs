using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCFServiceLibrary;

namespace MyMessage
{
    public partial class Form1 : Form
    {
        private ServiceHost _host;
        private ServiceHost _innerHost;

        private MessageService.MessageServiceClient _client;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text.Trim() != string.Empty)
            {
                //MessageService.MessageServiceClient client = new MessageService.MessageServiceClient();
                var output = _client.GetMessage(txtMessage.Text);
                txtAllMessage.Text += output + "\r\n";
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text.Trim() != string.Empty)
            {
                EndpointIdentity EndpointSPN = EndpointIdentity.CreateSpnIdentity("localhost");
                Uri uri = new Uri(string.Format("http://{0}:8080/WCFServiceLibrary/MessageService/", txtAddress));
                var Address = new EndpointAddress(uri, EndpointSPN);

                _client = new MessageService.MessageServiceClient();
                _client.GetMessage(string.Format("{0} csatlakozott hozzád!", "Kismajom"));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageProxy.Instance.SetAction(GetMessage);


            Task.Factory.StartNew(() =>
           {
               _host = new ServiceHost(typeof(WCFServiceLibrary.MessageService));
               _host.Open();
           });
            //Task.Factory.StartNew(() =>
            //{
            //    _innerHost = new ServiceHost(typeof(InnerService));
            //    _innerHost.Open();
            //});
        }

        public void GetMessage(string message)
        {
            try
            {
                MethodInvoker action = delegate
                { txtReceived.Text += String.Format("{0}\r\n", message); };
                txtReceived.BeginInvoke(action);
            }
            catch(Exception ex)
            {

            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                _host.Close();
                _innerHost.Close();
            }
            catch
            {

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
