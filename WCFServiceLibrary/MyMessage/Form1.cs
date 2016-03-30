using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            try
            {
                if (txtMessage.Text.Trim() != string.Empty && _client != null)
                {
                    var output = _client.GetMessage(txtMessage.Text);
                    txtAllMessage.Text += output + "\r\n";
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(string.Format("Error: {0}", exp.Message));
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

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (txtServerIP.Text != string.Empty)
            {
                if (_client != null)
                {
                    _client.Close();
                    _client = null;
                }

                _client = new MessageService.MessageServiceClient();
                _client.Endpoint.Address = new EndpointAddress(string.Format("http://{0}:8080/WCFServiceLibrary/MessageService/", txtServerIP.Text));
                _client.Open();
            }
        }
    }
}