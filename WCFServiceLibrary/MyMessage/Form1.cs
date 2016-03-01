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

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text.Trim() != string.Empty)
            {
                MessageService.MessageServiceClient client = new MessageService.MessageServiceClient();
                var output = client.GetMessage(txtMessage.Text);
                txtAllMessage.Text += output + "\r\n";
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
        }

        public void GetMessage(string message)
        {
            try
            {
                MethodInvoker action = delegate
                { txtReceived.Text += $"{message}\r\n"; };
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
