using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Net.Security;
using System.Security.Cryptography;
using System.IO;
using RijandelAlgorithm;
using Client;


namespace TCPClient
{
    public partial class FormClient : Form
    {
        //ClientNode cn = null;
        TcpClient client;
        // Socket socket;
        byte[] byteArray;
        string hash = "tanver";
        //EndPoint localip, remoteIp;
        // byte[] clientBuffer;

        //RijndaelSimple rs = new RijndaelSimple();
        string passPhrase = "Pas5pr@se";
        string saltValue = "s@1tValue";
        //string hashAlgorithm = "SHA1";
        //string hashAlgorithm = "SHA256";
        string hashAlgorithm = "SHA512";
        int passwordIterations = 2;
        string initVector = "@1B2c3D4e5F6g7H8";
        int keySize = 256;


        // List<string> clientList;
        string username;
        string password;
        string repete_password;
        public FormClient()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        public FormClient(string username,string password)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
            
           // sendData("Connect|" + username + "|Online");
            textBoxUsername.Text = username;



        }
        public FormClient(string username,string password,string repassword)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
            this.repete_password = repassword;
           // btnConnect.PerformClick();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            btnConnect.PerformClick();
           
            
        }

        private string GetLocalIp()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient();
                client.BeginConnect(IPAddress.Parse("127.0.0.1"), 8888, onCompleteConnect, client);

            }
            catch (Exception exc)
            {
                MessageBox.Show("Sorry, server is not running try latter "+ exc.Message);
            }
        }

        void onCompleteConnect(IAsyncResult iar)
        {
            TcpClient tcpc;
            Invoke((MethodInvoker)delegate
            {
                try
                {
                    tcpc = (TcpClient)iar.AsyncState;
                    tcpc.EndConnect(iar);

                    print("Connected To Server...... ");
                    //sendData("Connect|" + username +  password + "|Online");
                    sendData("Connect|" + username +"|"+ password + "|Online");
                    // textLocalIp.Text = client.ToString();
                    byteArray = new byte[512];
                    tcpc.GetStream().BeginRead(byteArray, 0, byteArray.Length, onCompleteReadFromServerStream, tcpc);

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            });
        }

        void onCompleteReadFromServerStream(IAsyncResult iar)
        {
            TcpClient tcpc;
            int receivedByte;
            string strRec;
            try
            {
                tcpc = (TcpClient)iar.AsyncState;
                receivedByte = tcpc.GetStream().EndRead(iar);

                if (receivedByte == 0)
                {
                    MessageBox.Show("Connection broken.");
                    return;
                }

                strRec = Encoding.ASCII.GetString(byteArray, 0, receivedByte);
                string decrypted = Rijandel.Decrypt(strRec, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
                var receivedData = decrypted.Split('|');
                if (receivedData[0].Equals("Users"))
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        listBoxOnlineClient.Items.Clear();
                        for (int i = 1; i < receivedData.Length; i++)
                        {
                            listBoxOnlineClient.Items.Add(receivedData[i]);

                        }
                    });
                }
                else if (receivedData[0].Equals("Disconnected"))
                {
                    Invoke((MethodInvoker)delegate
                    {
                        if (client.Connected)
                        {
                            
                           
                            tcpc.Close(); 
                            client.Close();
                            listBoxOnlineClient.Items.Clear();
                            print("Server disconnected you . try to reestablished the connection ");

                        }

                    });
                }
                else if (receivedData[0].Equals("PeerToPeer"))
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        print(DateTime.Now + " Client says..... : " + receivedData[1]);
                    });

                }
                else if (receivedData[0].Equals("NotAuthorised"))
                {
                    Invoke((MethodInvoker)delegate
                    {
                        if (client.Connected)
                        {
                            //client.GetStream().Dispose();
                            client.Close();
                            //  client.GetStream().Dispose();
                            print("You are not authorised. Please register first ");
                            MessageBox.Show("You are not authorised");
                            FormRegister fr = new FormRegister();
                            this.Hide();
                            fr.Show();
                        }

                    });
                }
                else if (receivedData[0].Equals("Busy"))
                {
                    print(DateTime.Now + " : Client can not accept message at this time try later  ");
                }
                else
                {
                    print(DateTime.Now + " -- Server.... >> " + decrypted);
                }
                byteArray = new byte[512];
                tcpc.GetStream().BeginRead(byteArray, 0, byteArray.Length, onCompleteReadFromServerStream, tcpc);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void print(string _strPrint)
        {
            tbConsole.Invoke(new Action<string>(doInvoke), _strPrint);
        }


        public void doInvoke(string _strPrint)
        {
            tbConsole.Text = _strPrint + Environment.NewLine + tbConsole.Text;
        }
        private void tbSend_Click(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {

                listBoxOnlineClient.SelectionMode = SelectionMode.MultiExtended;

                if (listBoxOnlineClient.SelectedItem != null)
                {
                    string users = string.Empty;
                    string text = tbPayload.Text;
                    foreach (var item in listBoxOnlineClient.SelectedItems)
                    {
                        users = (item.ToString()) + "|";

                        sendData("PeerToPeer|" + text + "|" + users.TrimEnd('|'));

                        print(DateTime.Now + " :  Sending message to : " + users + " and the Message is :" + text);
                    }
                }
                else
                {

                    sendData(tbPayload.Text);
                    print(DateTime.Now + "  " + " Me >> " + tbPayload.Text);
                }
            });
            tbPayload.Text = string.Empty;
        }

        private void sendData(string text)
        {
            byte[] tx;

            if (string.IsNullOrEmpty(text)) return;
            Invoke((MethodInvoker)delegate
            {
                // foreach(var items in listBoxOnlineClient.SelectedItems)
                try
                {
                    // tx = myRijandle.EncryptStringToBytes(tbPayload.Text);
                    tx = Encoding.ASCII.GetBytes(Rijandel.Encrypt(text, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize));
                    if (client != null)
                    {
                        if (client.Client.Connected)
                        {
                            client.GetStream().BeginWrite(tx, 0, tx.Length, onCompleteWriteToServer, client);

                        }
                        else
                        {
                            MessageBox.Show("Message can not be send pleae connect to the server");
                        }
                    }

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            });
        }

        void onCompleteWriteToServer(IAsyncResult iar)
        {
            TcpClient tcpc;

            try
            {
                tcpc = (TcpClient)iar.AsyncState;
                tcpc.GetStream().EndWrite(iar);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void tbConsole_TextChanged(object sender, EventArgs e)
        {

        }




        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLogin fl = new FormLogin();
            fl.Show();
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRegister fr = new FormRegister();
            fr.Show();
        }

        private void tbPayload_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbSend_Validating(object sender, CancelEventArgs e)
        {
            // if (tbPayload.Text == "")
            // {
            //    MessageBox.Show("Please Enter the Text");
            // }
        }

        private void btnBusy_Click(object sender, EventArgs e)
        {
            sendData("Busy");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBoxOnlineClient.SelectedItem != null)
            {
                MessageBox.Show("Has " + (listBoxOnlineClient.SelectedItem.ToString()) + " item(s) selected.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {

                if (client.Connected)
                {
                    
                    client.Close();
                    client = null;
                }
                this.Close();
            });
        }

        private void listBoxOnlineClient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sendData("Free");
        }
    }
}
