﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace StudyCode
{
    public partial class Form1T20 : Form
    {
        public Form1T20()
        {
            InitializeComponent();
            txbUrl.Text = "http://download.microsoft.com/download/7/0/3/70345ee-a747-4cc8-bd3e-98a615c3aedb/dotNetFx35setup.exe";
        }

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            rtbState.Text = "下载中......";
            if (txbUrl.Text==string.Empty)
            {
                MessageBox.Show("请先输入下载地址！");
                return;
            }
        }
        public void DownLoadFileSync(string url)
        {
            int BufferSize = 2048;
            byte[] BufferRead = new byte[BufferSize];
            string savepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\dotNetFx35setup.exe";
            FileStream filestream = null;
            HttpWebResponse myWebResponse = null;
            if (File.Exists(savepath))
            {
                File.Delete(savepath);
            }
            filestream = new FileStream(savepath, FileMode.OpenOrCreate);
            try
            {
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                if (myHttpWebRequest!=null)
                {
                    myWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                    Stream responseStream = myWebResponse.GetResponseStream();
                    int readSize = responseStream.Read(BufferRead, 0, BufferSize);
                    while (readSize>0)
                    {
                        filestream.Write(BufferRead, 0, readSize);
                        readSize = responseStream.Read(BufferRead, 0, BufferSize);
                    }
                    rtbState.Text = "文件下载完成，文件大小为" + filestream.Length + "下载路径为" + savepath;
                }
            }
            catch (Exception e)
            {
                rtbState.Text = "下载过程中发生异常，异常信息为：" + e.Message;
                throw;
            }
            finally
            {
                if (myWebResponse!=null)
                {
                    myWebResponse.Close();
                }
                if (filestream!=null)
                {
                    filestream.Close(); 
                }
            }
        }
    }
}
