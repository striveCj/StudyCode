using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyCode
{
    public partial class Form1T22D2 : Form
    {
        #region 变量
        private TcpClient tcpClient = null;
        private NetworkStream networkStream = null;
        private BinaryReader reader;
        private BinaryWriter writer;
        private const int Port = 51388;
        IPAddress ipaddress;
        private delegate void ShowMessage(string str);
        private ShowMessage showMessageCallback;
        private delegate void ResetMessage();
        private ResetMessage resetMessageCallBack;

        //private TcpListener tcpLister = null;
        #endregion
        public Form1T22D2()
        {
            InitializeComponent();
            showMessageCallback = new ShowMessage(showMessage);
            resetMessageCallBack = new ResetMessage(resetMessage);
            ipaddress = IPAddress.Loopback;
            tbxPort.Text = Port.ToString();
            tbxserverIp.Text = ipaddress.ToString();
        }
        public void showMessage(string str)
        {
            listBox1.Items.Add(tcpClient.Client.RemoteEndPoint);
            listBox1.Items.Add(str);
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        private void resetMessage()
        {
            textBox4.Text = "";
            textBox4.Focus();
        }
        
        public void ConnectToServer()
        {
            try
            {
                if (tbxserverIp.Text==string.Empty||tbxPort.Text==string.Empty)
                {
                    MessageBox.Show("请先输入服务器的IP地址和端口号");
                }
                IPAddress ipaddress = IPAddress.Parse(tbxserverIp.Text);
                tcpClient = new TcpClient();
                tcpClient.Connect(ipaddress, int.Parse(tbxPort.Text));
                Thread.Sleep(1000);
                if (tcpClient!=null)
                {
                    MessageBox.Show("链接成功！");
                    networkStream = tcpClient.GetStream();
                    reader = new BinaryReader(networkStream);
                    writer = new BinaryWriter(networkStream);
                }
            }
            catch
            {
                MessageBox.Show("链接失败，请重试！");
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Thread connectThread = new Thread(ConnectToServer);
            connectThread.Start();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }
        private void receiveMessage() {
            try
            {
                string receivemessage = reader.ReadString();
                listBox1.Invoke(showMessageCallback, receivemessage);
            }
            catch 
            {
                if (reader!=null)
                {
                    reader.Close();
                }
                if (writer!=null)
                {
                    writer.Close();
                }
                if (tcpClient!=null)
                {
                    tcpClient.Close();
                }
            }
        }
        private void btnReceive_Click(object sender, EventArgs e)
        {
            Thread receiveThread = new Thread(receiveMessage);
            receiveThread.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (reader!=null)
            {
                reader.Close();
            }
            if (writer!=null)
            {
                writer.Close();
            }
            if (tcpClient!=null)
            {
                tcpClient.Close();
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            
        }
        private void SendMessage(object state)
        {
            try
            {
                writer.Write(state.ToString());
                Thread.Sleep(5000);
                writer.Flush();
                textBox4.Invoke(showMessageCallback);
                listBox1.Invoke(showMessageCallback, state.ToString());
            }
            catch
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (writer != null)
                {
                    writer.Close();
                }
                if (tcpClient != null)
                {
                    tcpClient.Close();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
