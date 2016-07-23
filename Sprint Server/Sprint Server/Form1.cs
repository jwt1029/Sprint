using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Json;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sprint_Server
{
    public partial class Form1 : Form
    {
        private List<string> packetHeaders = new List<string>();
        private const string logHeader = "[LOG]";
        private Socket serverSocket = null;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            initializePacketHeaders();
        }

        private void SwitchButton_Click(object sender, EventArgs e)
        {
            if (serverSocket == null)
            {
                Thread thread1 = new Thread(new ThreadStart(ServerOn));
                thread1.Start();
                SwitchButton.Text = "Server Off";
                appendLog(logHeader, "Server started.");
            }
            else
            {
                serverSocket.Close();
                serverSocket = null;
                SwitchButton.Text = "Server On";
                appendLog(logHeader, "Server closed.");
            }
        }

        /* Server Start */
        private void ServerOn()
        {
            string data = null;
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, 3141));

            serverSocket.Listen(100);
            while (true)
            {
                Socket clientSocket = null;
                try
                {
                    clientSocket = serverSocket.Accept();   
                    byte[] b = new byte[clientSocket.ReceiveBufferSize];
                    clientSocket.Receive(b);
                    data = Encoding.Default.GetString(b);

                    JsonObjectCollection col = checkPacket(data);

                    if (col != null && col["header"].GetValue().ToString() == "login") {
                        Login.LoginResult res = Login.tryLogin(col["id"].GetValue().ToString(), col["pw"].GetValue().ToString());
                        if (res == Login.LoginResult.LOGIN_SUCCEED)
                        {
                            Thread serverRecv = new Thread(new ParameterizedThreadStart(serverRecieveData));
                            List<object> args = new List<object>();
                            args.Add(clientSocket);
                            args.Add(col);

                            serverRecv.Start(args);
                            appendLog(logHeader, col["id"].GetValue().ToString() + "is logged in.");
                        }
                        else if(res == Login.LoginResult.LOGINDATA_ERR)
                        {
                            // check ID or PW again
                        }
                        else if (res == Login.LoginResult.INPUTDATA_ERR)
                        {
                            // illegal input data
                        }
                    }
                }
                catch (Exception er)
                {
                    break;
                }
            }
        }

        private JsonObjectCollection checkPacket(string data)
        {
            JsonTextParser parser = new JsonTextParser();
            JsonObject obj = parser.Parse(data);
            JsonArrayCollection cols = (JsonArrayCollection)obj;
            JsonObjectCollection col = (JsonObjectCollection)cols[0];

            string header = col["header"].GetValue().ToString();

            if (packetHeaders.Contains(header))
                return col;
            else
                return null;
        }

        private void serverRecieveData(object args)
        {
            Socket client = (Socket)((List<object>)args)[0];
            NetworkStream ns = new NetworkStream(client);
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            JsonObjectCollection col = (JsonObjectCollection)((List<object>)args)[1];
            string data = null;

            UserData userData = getUserData(col["id"].GetValue().ToString());

            while(serverSocket != null)
            {
                try
                {
                    data = sr.ReadLine();
                }
                catch
                {
                    client.Close();
                    break;
                }
            }
        }

        private void appendLog(string header, string log)
        {
            LogText.Text += header + "(" + DateTime.Now.ToString("HH:mm:ss tt") + ")" + log + Environment.NewLine;
        }

        private UserData getUserData(string id)
        {
            string name = "";
            int level = -1;
            int exp = -1;
            return new UserData(name, level, exp);
        }

        private void initializePacketHeaders()
        {
            packetHeaders.Add("register");
            packetHeaders.Add("login");
            packetHeaders.Add("join");
            packetHeaders.Add("left");
        }

    }
}
