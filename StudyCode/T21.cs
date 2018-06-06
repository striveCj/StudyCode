using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace StudyCode
{
    public class T21
    {
        #region File和FileInfo类
        public void T21D1()
        {
            FileStream fs = null;
            StreamWriter writer = null;
            string path = "D:\\test.txt";
            if (!File.Exists(path))
            {
                fs = File.Create(path);
                Console.WriteLine($"新建一个文件{path}");
            }
            else
            {
                fs = File.Open(path, FileMode.Open);
                Console.WriteLine("文件已存在，直接打开");
            }
            writer = new StreamWriter(fs);
            writer.WriteLine("测试文本");
            Console.WriteLine("向文件写入文本数据");
            writer.Flush();
            writer.Close();
            fs.Close();
            Console.WriteLine("关闭数据流");
        }
        #endregion

        #region Directory和DirectoryInfo类
        public void T21D2()
        {
            string dirPath = "D:\\DirectorySample";
            string filePath = string.Format($"{dirPath}\\test.txt");
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
                Console.WriteLine("创建一个目录" + dirPath);
            }
            else
            {
                Console.WriteLine($"目录{dirPath}已存在");
            }
            FileInfo file = new FileInfo(filePath);
            if (!file.Exists)
            {
                file.Create();
                Console.WriteLine($"创建一个文件：{filePath}");
            }
            else
            {
                Console.WriteLine($"文件:{filePath}已存在");
            }
        }
        #endregion

        #region 流
        public void T21D3()
        {
            string filePath = "D:\\test.txt";
            using (FileStream fileStream = File.Open(filePath, FileMode.OpenOrCreate))
            {
                string msg = "Hello World";
                byte[] msgAsByteArray = Encoding.Default.GetBytes(msg);
                Console.WriteLine($"开始写入{msg}到文件中");
                fileStream.Write(msgAsByteArray, 0, msgAsByteArray.Length);
                fileStream.Seek(0, SeekOrigin.Begin);
                Console.WriteLine("写入文件中的数据为：");
                byte[] bytesFromFile = new byte[msgAsByteArray.Length];
                fileStream.Read(bytesFromFile, 0, msgAsByteArray.Length);
                Console.WriteLine(Encoding.Default.GetString(bytesFromFile));
                Console.Read();
            }
        }

        public void T21D4()
        {
            string filePath = "D:\\test.txt";
            using (FileStream fileStream = File.Open(filePath, FileMode.OpenOrCreate))
            {
                string msg = "Hello World";
                StreamWriter streamWriter = new StreamWriter(fileStream);
                Console.WriteLine($"开始写入{msg}到文件中");
                streamWriter.Write(msg);
                StreamReader streamReader = new StreamReader(fileStream);
                Console.WriteLine($"写入文件中的数据为：{streamReader.ReadToEnd()}");
                streamReader.Close();
                streamWriter.Close();
                Console.Read();
            }
        }
        #endregion

        #region 对文件进行一步操作
        public void T21D5()
        {
            FileStream fileStream = null;
            string filePath = "D:\\test.txt";
            FileInfo fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists)
            {
                fileStream = File.Create(filePath);
                Console.WriteLine($"新建文件夹{filePath}");
                fileStream.Close();
            }
            else Console.WriteLine($"文件：{filePath}已存在，直接打卡");
            fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Write, FileShare.None, 4096, true);
            Console.WriteLine($"开启异步操作{fileStream.IsAsync}");
            string msg = "HelloWord";
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            IAsyncResult asyncResult = fileStream.BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(EndWriteCallback), fileStream);
            Console.WriteLine($"开始异步写入，请稍等...");
            Console.Read();
        }

        public void EndWriteCallback(IAsyncResult asyncResult)
        {
            Console.WriteLine("异步方法写入开始...");
            FileStream stream = asyncResult.AsyncState as FileStream;
            if (stream!=null)
            {
                stream.EndWrite(asyncResult);
                stream.Close();
            }
            Console.WriteLine("异步写入完毕");
        }
        #endregion
    }
}
