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

        public Form1()
        {
            InitializeComponent();
        }

	    private List<EndpointAddress> clientsList = new List<EndpointAddress>(); 
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text.Trim() != string.Empty)
            {
                MessageService.MessageServiceClient client = new MessageService.MessageServiceClient() {Endpoint = { Address = new EndpointAddress($"http://{textBox1.Text}:8080/WCFServiceLibrary/MessageService/") } };
	            listBox1.Items.Add($"Te: {txtMessage.Text}");
                /*var output = */client.GetMessage(txtMessage.Text);
                //listBox1.Items.Add($"Valaki: {output}");
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

        public void GetMessage(EndpointAddress host, string message)
        {
            try
            {
	            MethodInvoker action = delegate
	            {
		            listBox1.Items.Add($"{host}: {message}");
	            };
                listBox1.BeginInvoke(action);
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

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				btnSend_Click(null, null);
			}
		}
	}
}
