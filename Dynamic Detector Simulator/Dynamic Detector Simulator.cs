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

namespace Dynamic_Detector_Simulator
{
    public partial class Dynamic_Detector_Simulator : Form
    {
        public Dynamic_Detector_Simulator()
        {
            InitializeComponent();
        }
        List<Socket> clientSocketList = new List<Socket>();
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Queue<string> fileQueue = new Queue<string>();
        //Queue<byte[]> data = new Queue<byte[]>();
        private void button_Start_Click(object sender, EventArgs e)
        {
            // Get host IP address
            IPHostEntry hostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = hostInfo.AddressList[0];

            // Bind
            socket.Bind(new IPEndPoint(ipAddress, int.Parse(textBox_ListenPort.Text)));

            // Listen
            socket.Listen(10);

            // Accept client to connect
            ThreadPool.QueueUserWorkItem(new WaitCallback(AcceptClientConnect), socket);
        }
        // Accept client to connect
        private void AcceptClientConnect(object state)
        {
            AppendTextToLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + " The Dynamic Detector Simulator starts to accept client connections.");
            while (true)
            {
                try
                {
                    Socket clientSocket = socket.Accept();
                    AppendTextToLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + " Client" + clientSocket.RemoteEndPoint + "connected.");
                    clientSocketList.Add(clientSocket);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(WhetherConnected), clientSocket);
                }
                catch
                {
                    AppendTextToLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + " Fail to connect.");
                    socket.Close();
                }
            }
        }

        private void WhetherConnected(object state)
        {
            Socket clientSocket = state as Socket;
            byte[] buffer = new byte[1024];
            while (true)
            {
                try
                {
                    int len = clientSocket.Receive(buffer);
                    if (len <= 0)
                    {
                        AppendTextToLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + " Client:" + clientSocket.RemoteEndPoint + " exit normally.");
                        clientSocketList.Remove(clientSocket);
                        return;
                    }
                }
                catch
                {
                    AppendTextToLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + " Client:" + clientSocket.RemoteEndPoint + " exit abnormally.");
                    clientSocketList.Remove(clientSocket);
                    return;
                }               
            }
        }

        // Add information to log textbox
        private void AppendTextToLog(string text)
        {
            if(this.InvokeRequired)
            {
                Action<string> action = s =>
                {
                    if (textBox_Log.Text == "")
                    {
                        textBox_Log.Text = s;
                    }
                    else
                    {
                        textBox_Log.Text = textBox_Log.Text + "\r\n" + s;
                    }
                };
                this.Invoke(action, text);
            }
            else
            {
                if (textBox_Log.Text == "")
                {
                    textBox_Log.Text = text;
                }
                else
                {
                    textBox_Log.Text = textBox_Log.Text + "\r\n" + text;
                }
            }        
        } 
        // Clear log
        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox_Log.Text = "";
        }
        // Send Message hello world!
        private void button_SendHello_Click(object sender, EventArgs e)
        {
            foreach(Socket clientSocket in clientSocketList)
            {
                if (clientSocket.Connected)
                {
                    byte[] buffer = Encoding.UTF8.GetBytes("B" + "Hello World!");
                    clientSocket.Send(buffer);
                    AppendTextToLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + " Send message \"Hello World!\" to " + clientSocket.RemoteEndPoint);
                }
                else
                {
                    AppendTextToLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + "Client connection failed.");
                }
            }
        }
        // Send each file that in the target folder.
        private void button_SendData_Click(object sender, EventArgs e)
        {
            // Construct the file queue
            fileQueue.Clear();
            FileQueue();
            while(fileQueue.Count > 0)
            {
                string path = fileQueue.Dequeue();
                SendFile(path);
            }
            AppendTextToLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + "All files have been sent.");
        }
        // send file
        private void SendFile(string path)
        {
            using (FileStream fileStream = File.OpenRead(path))
            {
                foreach(Socket clientSocket in clientSocketList)
                {                                      
                    Send(clientSocket, fileStream);                   
                }
                fileStream.Close();
            }            
        }
        // Send one file piece by piece
        private void Send(Socket clientSocket, FileStream fileStream)
        {
            int headLength = 521;
            long fileSize = fileStream.Length;
            string fileName = fileStream.Name.Substring(fileStream.Name.LastIndexOf(@"\") + 1);
            // each buffer store the identifier "A", the size of the file, the file's name and the data.
            byte[] buffer = CreateBuffer(fileSize, fileName);
            int fileSectionSize = buffer.Length - headLength;
            while (fileSize > fileSectionSize)
            {
                fileStream.Read(buffer, headLength, fileSectionSize);
                clientSocket.Send(buffer);
                fileSize -= fileSectionSize;
            }
            if (fileSize > 0)
            {
                fileStream.Read(buffer, headLength, (int)fileSize);               
                clientSocket.Send(buffer);
            }
            AppendTextToLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + "Successfully send file:" + fileName);
        }
        // Create the buffer to send file
        private byte[] CreateBuffer(long fileSize, string fileName)
        {
            byte[] buffer = new byte[1024 * 1024];
            buffer[0] = Encoding.UTF8.GetBytes("A")[0];
            for (int i = 1; i <= 8; i++)
            {
                buffer[i] = (byte)(fileSize >> (8 * (i - 1)));
            }
            Encoding.UTF8.GetBytes(fileName, 0, fileName.Length, buffer, 9);
            return buffer;
        }
        // Construct the file queue
        private void FileQueue()
        {
            string path = Directory.GetCurrentDirectory() + "\\Image";
            for (int i = 0; i < Directory.GetFiles(path).Length; i++)
            {
                fileQueue.Enqueue(Directory.GetFiles(path)[i]);
            }
            if (checkBox_File1.Checked || checkBox_File2.Checked)
            {
                fileQueue.Clear();
                if (checkBox_File1.Checked)
                {
                    string filePath = Directory.GetCurrentDirectory() + "\\File1";
                    for (int i = 0; i < Directory.GetFiles(filePath).Length; i++)
                    {
                        fileQueue.Enqueue((string)Directory.GetFiles(filePath)[i]);
                    }
                }
                if (checkBox_File2.Checked)
                {
                    string filePath = Directory.GetCurrentDirectory() + "\\File2";
                    for (int i = 0; i < Directory.GetFiles(filePath).Length; i++)
                    {
                        fileQueue.Enqueue((string)Directory.GetFiles(filePath)[i]);
                    }
                }
            }
        }

        private void checkBox_File1_CheckedChanged(object sender, EventArgs e)
        {
            label_File1.Text = "File1 Route:" + Directory.GetCurrentDirectory() + "\\File1";
        }

        private void checkBox_File2_CheckedChanged(object sender, EventArgs e)
        {
            label_File2.Text = "File1 Route:" + Directory.GetCurrentDirectory() + "\\File2";
        }
    }
}
