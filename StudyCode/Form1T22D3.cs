using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyCode
{
    public partial class Form1T22D3 : Form
    {
        private UdpClient sendUdpClient;
        private UdpClient receiveUpdClient;
        public Form1T22D3()
        {
            InitializeComponent();
            IPAddress[] ips = Dns.GetHostAddresses("");
            foreach (var ip in ips)
            {
                tbxLocalIp.Text = ip.ToString();
                tbxSendToIp.Text = ip.ToString();
                break;
            }
            int port = 51883;
            int sendPort = 11883;
            tbxSendToPort.Text = sendPort.ToString();
            tbxLocalPort.Text = port.ToString(); 
        }

        private void ReceiveMessage()
        {
            if (receiveUpdClient==null)
            {
                return;
            }
            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                try
                {
                    byte[] receiveBytes = receiveUpdClient.Receive(ref remoteIpEndPoint);
                    string message = Encoding.Unicode.GetString(receiveBytes);
                    
                }
                catch
                {

                    break;
                }
            }
        }
        delegate void ShowMessageforViewCallBack(ListBox listbox, string text);

        private void ShowMessageforView(ListBox listbox, string text)
        {
            if (listbox.InvokeRequired)
            {
                ShowMessageforViewCallBack showMessageforViewCallback = ShowMessageforView;
                listbox.Invoke(showMessageforViewCallback, new object[] { listbox, text });

            }
            else
            {
                listBox1.Items.Add(text);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                listBox1.ClearSelected();
            }
        }

        private void SendMessage(object obj)
        {
            string message=(string)obj;
            byte[] sendbytes = Encoding.Unicode.GetBytes(message);
            IPAddress remoteIp = IPAddress.Parse(tbxSendToIp.Text);
            IPEndPoint remoteIpEndPoint = new IPEndPoint(remoteIp, int.Parse(tbxSendToPort.Text));
            sendUdpClient.Send(sendbytes, sendbytes.Length, remoteIpEndPoint);
            sendUdpClient.Close();
            ResetMessageText(tbxMessageSend);

        }

        delegate void ResetMessageCallback(TextBox textbox);
        private void ResetMessageText(TextBox textbox)
        {
            if (textbox.InvokeRequired)
            {
                ResetMessageCallback resetMessagecallback = ResetMessageText;
                textbox.Clear();
                textbox.Focus();
            }
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            IPAddress localIp = IPAddress.Parse(tbxLocalIp.Text);
            IPEndPoint localIpEndPoint = new IPEndPoint(localIp, int.Parse(tbxLocalPort.Text));
            try
            {
                receiveUpdClient = new UdpClient(localIpEndPoint);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (tbxMessageSend.Text==string.Empty)
            {
                MessageBox.Show("发送内容不能为空", "提示");
                return;
            }
            IPAddress localIp = IPAddress.Parse(tbxLocalIp.Text);
            IPEndPoint localIpEndPoint = new IPEndPoint(localIp, int.Parse(tbxLocalPort.Text));
            sendUdpClient = new UdpClient(localIpEndPoint);

            Thread sendThread = new Thread(SendMessage);
            sendThread.Start(tbxMessageSend.Text);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            receiveUpdClient.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
        }
    }
}
