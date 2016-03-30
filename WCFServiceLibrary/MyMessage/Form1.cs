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
        MessageProxy _maininstance = MessageProxy.Instance;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            sendmessage();
        }

        private void sendmessage()
        {
            if (txtMessage.Text.Trim() != string.Empty)
            {
                MessageService.MessageServiceClient client = new MessageService.MessageServiceClient()
                {
                    Endpoint =
                    { Address =
                            new EndpointAddress($"http://{toolStripTextBox1.Text}:8080/WCFServiceLibrary/MessageService/")}
                };
                var output = client.GetMessage(txtMessage.Text);
                txtAllMessage.AppendText(output + "\r\n");
                txtMessage.Text = "";
                txtMessage.Focus();
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
                { txtAllMessage.AppendText( String.Format("{0}\r\n", message)); };
                txtAllMessage.BeginInvoke(action);
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

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                sendmessage();
            }
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
            }
        }
    }
}
