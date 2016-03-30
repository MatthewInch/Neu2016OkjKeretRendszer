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

        private void btnSend_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (txtMessage.Text.Trim() != string.Empty)
            {
                MessageService.MessageServiceClient client = new MessageService.MessageServiceClient();
                if (txtServerIP.Text != null)
                {
                    client.Endpoint.Address = new EndpointAddress((@"http://192.168.8." + txtServerIP.Text + @":8080/WCFServiceLibrary/MessageService/").ToString());
                }
                if (!checkedListBox1.Items.Contains(client.Endpoint.Address))
                {
                    checkedListBox1.Items.Add(client.Endpoint.Address);
                    checkedListBox1.SetItemChecked(checkedListBox1.Items.Count-1,true);
                }
                var output = client.GetMessage(txtMessage.Text);
                richTextBox1.SelectionColor = Color.Blue;
                richTextBox1.SelectionBackColor = Color.DarkGray;
                richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
                richTextBox1.SelectedText = output + Environment.NewLine;
                client.Close();
            }
            this.Cursor = Cursors.Default;
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
                {
                    richTextBox1.SelectionColor = Color.Purple;
                    richTextBox1.SelectionBackColor = Color.DarkGray;
                    richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
                    richTextBox1.SelectedText = message + Environment.NewLine;
                };
                richTextBox1.BeginInvoke(action);
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
            
        }
    }
}
