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
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        int flag = 0; // Indicates that the user hasn't click the button_Disconnect to disconnect.
        string location = Directory.GetCurrentDirectory();
        Queue<byte[]> data = new Queue<byte[]>();

        // Connect to Dynamic Detector Simulator
        private void button_Connect_Click(object sender, EventArgs e)
        {
            // avoid reconnect while connected.
            while (clientSocket.Connected)
            {
                AppendTextToLog("The connection has been completed, please don't reconnect.");
                return;
            }
            // Reconnect after disconnect
            if(flag == 1)
            {
                clientSocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
            }
            if(int.Parse(textBox_Port.Text) >= 0 && int.Parse(textBox_Port.Text) <= 65535)
            {
                if (IPValidate(textBox_IP.Text))
                {
                    clientSocket.Connect(new IPEndPoint(IPAddress.Parse(textBox_IP.Text), int.Parse(textBox_Port.Text)));
                    AppendTextToLog(DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss:fff") + " Successfully connect to " + clientSocket.RemoteEndPoint);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(Receive), clientSocket);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(Save), data);
                }
                else
                {
                    AppendTextToLog("Please input a correct IP.");
                }
            }
            else
            {
                AppendTextToLog("Please input a correct Port.");
            }
        }
        // Receive message or file
        private void Receive(object state)
        {
            Socket clientSocket = state as Socket;
            byte[] buffer = new byte[1024 * 1024];
            while (true)
            {
                try
                {
                    int len = clientSocket.Receive(buffer);
                    if(len <= 0)
                    {
                        AppendTextToLog(DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss:fff") + clientSocket.RemoteEndPoint + " exit normally.");
                        return;
                    }
                    else if(Encoding.UTF8.GetString(buffer,0,1) == "A")
                    {
                        data.Enqueue(buffer);                                              
                    }
                    else if(Encoding.UTF8.GetString(buffer, 0, 1) == "B")
                    {
                        string str = Encoding.UTF8.GetString(buffer, 1, len - 1);
                        AppendTextToLog(DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss:fff") + " Receive " + clientSocket.RemoteEndPoint + " message：" + str);
                    }
                }
                catch
                {
                    AppendTextToLog(DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss:fff") + " Connection dropped.");
                    return;
                }
            }
        }    

        // Save the data Queue in a target file folder
        private void Save(object state)
        {
            Queue<byte[]> data = state as Queue<byte[]>;
            while (true)
            {
                if (data.Count > 0)
                {
                    try
                    {
                        byte[] buffer = data.Dequeue();
                        int headLength = 521;
                        int fileSectionSize = buffer.Length - headLength;
                        // Obtain the size of a file 
                        long fileSize = 0;
                        for (int i = 1; i <= 8; i++)
                        {
                            fileSize += buffer[i] << (8 * (i - 1));
                        }
                        // file name
                        int MaxFileNameLength = 512;
                        string fileName = Encoding.UTF8.GetString(buffer, 9, MaxFileNameLength);
                        fileName = fileName.TrimEnd('\0');
                        // file save path
                        string fileSavePath = location + @"\" + fileName;
                        using (FileStream fileStream = new FileStream(fileSavePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                        {
                            while (fileSize > fileSectionSize)
                            {
                                fileStream.Write(buffer, headLength, fileSectionSize);
                                buffer = data.Dequeue();
                                fileSize -= fileSectionSize;
                            }
                            if (fileSize > 0)
                            {
                                fileStream.Write(buffer, headLength, (int)fileSize);
                            }
                            AppendTextToLog(DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss:fff") + "Successfully saved file:" + fileName);
                            fileStream.Close();
                        }
                    }
                    catch
                    {

                    }
                }
                
            }

            /*
            byte[] buffer = data.Dequeue();

            int headLength = 523;
            int fileSectionSize = buffer.Length - headLength;
            // Obtain the size of a file 
            long fileSize = 0;
            for (int i = 3; i <= 10; i++)
            {
                fileSize += buffer[i] << (8 * (i - 3));
            }
            // file name
            int MaxFileNameLength = 512;
            string fileName = Encoding.UTF8.GetString(buffer, 11, MaxFileNameLength);
            fileName = fileName.TrimEnd('\0');
            // file save path
            string fileSavePath = location + @"\" + fileName;

            while (data.Count >= 0 && fileSize > 0)
            {
                using (FileStream fileStream = new FileStream(fileSavePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                {
                    if (fileSize > fileSectionSize)
                    {
                        fileStream.Write(buffer, headLength, fileSectionSize);
                        fileSize -= fileSectionSize;
                    }
                    while (fileSize > fileSectionSize)
                    {
                        buffer = data.Dequeue();
                        fileStream.Write(buffer, headLength, fileSectionSize);
                        fileSize -= fileSectionSize;
                    }
                    if (fileSize > 0)
                    {
                        buffer = data.Dequeue();
                        fileStream.Write(buffer, headLength, (int)fileSize);
                    }
                    AppendTextToLog(DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss:fff") + "Successfully saved file:" + fileName);
                    fileStream.Close();
                }
            }
            */

        }

        /*
        // Store file section
        private void Store(object state)
        {
            byte[] buffer = state as byte[];
            long fileSize = 0;
            int headLength = 521;
            int MaxFileNameLength = 512;
            int fileSectionSize = buffer.Length - headLength;
            for(int i = 1; i <= 8; i++)
            {
                fileSize += buffer[i] << (8 * (i - 1));
            }
            string fileName = Encoding.UTF8.GetString(buffer, 9, MaxFileNameLength);
            fileName = fileName.TrimEnd('\0');
            string fileSavePath = location + @"\" + fileName;
            using(FileStream fileStream = new FileStream(fileSavePath, FileMode.Create))
            {
                while(fileSize > fileSectionSize)
                {
                    fileStream.Write(buffer, headLength, fileSectionSize);
                    fileSize -= fileSectionSize;
                    clientSocket.Receive(buffer);
                }
                if(fileSize > 0)
                {
                    fileStream.Write(buffer, headLength, (int)fileSize - headLength);
                }
                AppendTextToLog(DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss:fff") + " successfully save file:" + fileName + " in " + fileSavePath);
                fileStream.Close();
            }
        }
        */
        

        // Whether a valid IP
        private bool IPValidate(string IP)
        {
            Regex regex = new Regex(@"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$");
            return IP != "" && regex.IsMatch(IP);
        }
        // Add information to log textBox
        private void AppendTextToLog(string text)
        {
            if (this.InvokeRequired)
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
        // Disconnect
        private void button_Disconnect_Click(object sender, EventArgs e)
        {
            if (clientSocket.Connected)
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
                flag = 1;
            }
        }
        // Choose file save route
        private void button_ChooseRoute_Click(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                Action<FolderBrowserDialog> action = s =>
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        location = s.SelectedPath;
                    }
                };
                this.Invoke(action,dialog);
            }
            else
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    location = dialog.SelectedPath;
                }
            }
        }

        // Clear log textbox
        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox_Log.Text = "";
        }
    }
}
