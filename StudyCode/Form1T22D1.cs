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
    public partial class Form1T22D1 : Form
    {
        #region 变量
        private const int Port = 51388;
        private TcpListener tcpLister = null;
        private TcpClient tcpClient = null;
        IPAddress ipaddress;
        private NetworkStream networkStream = null;
        private BinaryReader reader;
        private BinaryWriter writer;

        private delegate void ShowMessage(string str);
        private ShowMessage showMessageCallback;
        private delegate void ResetMessage();
        private ResetMessage resetMessageCallBack;
        #endregion
        public Form1T22D1()
        {
            InitializeComponent();
            showMessageCallback = new ShowMessage(showMessage);
            resetMessageCallBack = new ResetMessage(resetMessage);
            ipaddress = IPAddress.Loopback;
            tbxserverIp.Text = ipaddress.ToString();
            tbxPort.Text = Port.ToString();

        }

        #region 定义回调函数
        private void showMessage(string str)
        {
            listBox1.Items.Add(str);
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }

        private void resetMessage()
        {
            textBox4.Text = string.Empty;
            textBox4.Focus();
        }
        #endregion

        private void SendMessage(object state)
        {
            listBox1.Invoke(showMessageCallback, "正在发送");
            try
            {
                writer.Write(state.ToString());
                Thread.Sleep(5000);
                writer.Flush();
                listBox1.Invoke(showMessageCallback,"发送完毕");
                textBox4.Invoke(resetMessageCallBack, null);
                listBox1.Invoke(showMessageCallback, state.ToString());
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
                listBox1.Invoke(showMessageCallback, "断开连接");
                Thread acceptThread = new Thread(acceptClientConnect);
                acceptThread.Start();
            }
        }

        private void acceptClientConect()
        {
            try
            {
                listBox1.Invoke(showMessageCallback, "等待连接");
                tcpClient = tcpLister.AcceptTcpClient();
                if (tcpLister!=null)
                {
                    listBox1.Invoke(showMessageCallback, "接收到连接");
                    networkStream = tcpClient.GetStream();
                    reader = new BinaryReader(networkStream);
                    writer = new BinaryWriter(networkStream);
                }
            }
            catch 
            {
                listBox1.Invoke(showMessageCallback, "停止监听");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            tcpLister = new TcpListener(ipaddress, Port);
            tcpLister.Start();
            Thread acceptThread = new Thread(acceptClientConect);
            acceptThread.Start();
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Invoke(showMessageCallback, "等待连接");
                tcpClient = tcpLister.AcceptTcpClient();
                if (tcpLister!=null)
                {
                    listBox1.Invoke(showMessageCallback, "接收到连接");
                    networkStream = tcpClient.GetStream();
                    reader = new BinaryReader(networkStream);
                    writer = new BinaryWriter(networkStream);
                }
            }
            catch
            {
                listBox1.Invoke(showMessageCallback, "停止监听");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

    }
}
