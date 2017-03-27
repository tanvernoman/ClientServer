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
using System.Security.Cryptography;
using System.IO;
using RijandelAlgorithm;
using Server;
using System.Data.Linq;
using ApplicationDatabaseServer;
namespace TCPServer
{

    public partial class Form1 : Form
    {
        //RijndaelManaged myRijandle = new RijndaelManaged();

        TcpListener listener;
        TcpClient client;
        byte[] mRx;

        private List<ClientNode> clientList;

        //RijandleManagedEnDe myRijandle = new RijandleManagedEnDe();


        //----------------------------------
        // RijndaelSimple rs = new RijndaelSimple();
        string passPhrase = "Pas5pr@se";        // can be any string
        string saltValue = "s@1tValue";        // can be any string
       // string hashAlgorithm = "SHA1";
        //string hashAlgorithm = "SHA256";// can be "MD5"
        string hashAlgorithm = "SHA512";
        int passwordIterations = 2;                // can be any number
        string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
        int keySize = 256;                // can be 192 or 128
        //private AsyncCallback broadCastClient;

        public Form1()
        {
            InitializeComponent();
            clientList = new List<ClientNode>(2);
            CheckForIllegalCrossThreadCalls = false;
        }



        private void btnStartListening_Click(object sender, EventArgs e)
        {


            try
            {
                listener = new TcpListener(IPAddress.Any, 8888);

                listener.Start();

                listener.BeginAcceptTcpClient(onCompleteAcceptTcpClient, listener);
                printLine("Server started....");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        void onCompleteAcceptTcpClient(IAsyncResult iar)
        {
            TcpListener tcpl = (TcpListener)iar.AsyncState;
            TcpClient tclient = null;
            ClientNode cNode = null;

            try
            {
                tclient = tcpl.EndAcceptTcpClient(iar);

                printLine("Client Connected...");

                tcpl.BeginAcceptTcpClient(onCompleteAcceptTcpClient, tcpl);


                Invoke((MethodInvoker)delegate
                {
                    cNode = new ClientNode(tclient, new byte[512], new byte[512], tclient.Client.RemoteEndPoint.ToString());

                    clientList.Add(cNode);
                    lbClients.Items.Add(cNode.ToString());

                    BroadCast();

                });

                tclient.GetStream().BeginRead(cNode.Rx, 0, cNode.Rx.Length, readCallBack, tclient);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BroadCast()
        {
            string users = string.Empty;
            for (int j = 0; j < lbClients.Items.Count; j++)
            {
                users += lbClients.Items[j].ToString() + "|";

            }
            string text = "Users|" + users.TrimEnd('|');
            foreach (var items in clientList)
            {
                SendClient(items.tclient, Rijandel.Encrypt(text, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize));

            }
        }

        private static void SendClient(TcpClient client, String data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.  
            client.GetStream().BeginWrite(byteData, 0, byteData.Length,
                new AsyncCallback(SendCallback), client);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                TcpClient client = (TcpClient)ar.AsyncState;

                // Complete sending the data to the remote device.  
                client.GetStream().EndRead(ar);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        void readCallBack(IAsyncResult iar)
        {
            TcpClient tcpc;
            int nCountReadBytes = 0;
            string strRecv;
            ClientNode cn = null;
            ClientNode cnn = null;
            try
            {
                Invoke((MethodInvoker)delegate
                {
                    tcpc = (TcpClient)iar.AsyncState;

                    cn = clientList.Find(x => x.strId == tcpc.Client.RemoteEndPoint.ToString());

                    nCountReadBytes = tcpc.GetStream().EndRead(iar);

                    if (nCountReadBytes == 0)// this happens when the client is disconnected
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            MessageBox.Show("Client disconnected.");
                            clientList.Remove(cn);
                            lbClients.Items.Remove(cn.ToString());

                            BroadCast();
                            var remove = listViewClient.FindItemWithText(cn.ToString());
                            if (remove != null)
                            {
                                listViewClient.Items.Remove(remove);
                            }

                            return;
                        });

                    }
                    strRecv = Encoding.ASCII.GetString(cn.Rx, 0, nCountReadBytes);
                    string decrypted = Rijandel.Decrypt(strRecv, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
                    var receivedData = decrypted.Split('|');
                    if (receivedData[0].Equals("Connect"))
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            //  using (DataClassesDatabaseServerDataContext db = new ServerDataClassesDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\un\06-02-2017-22-30 PeerToPeerDone\BackUp\ClientServer\Server\ServerDatabase.mdf;Integrated Security=True"))
                            using (DataClassesDatabaseServerDataContext db = new DataClassesDatabaseServerDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\UN\06-02-2017-22-30 PEERTOPEERDONE\BACKUP\CLIENTSERVER\APPLICATIONDATABASESERVER\DATABASESERVER.MDF;Integrated Security=True;Connect Timeout=30"))
                            {
                                Table<tbUser> logins = db.GetTable<tbUser>();

                                string username = receivedData[1];
                                string password = Rijandel.Encrypt(receivedData[2], passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);


                                var query =
                               from c in logins
                               where (c.username == username)
                               select c;


                                String _username = "";
                                string _password = "";
                                //string _role = "";
                                foreach (var item in query)
                                {

                                    _username = item.username;
                                    _password = item.password;

                                }

                                if (username.Equals(_username) && password.Equals(_password))
                                {
                                    string[] row = { cn.ToString(), receivedData[1], receivedData[3] };
                                    var listViewItem = new ListViewItem(row);
                                    listViewClient.Items.Add(listViewItem);
                                    SendClient(cn.tclient, Rijandel.Encrypt("Authentication Successful", passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize));

                                    printLine("successful");

                                }

                                else
                                {

                                    SendClient(cn.tclient, Rijandel.Encrypt("NotAuthorised", passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize));
                                    clientList.Remove(cn);
                                    lbClients.Items.Remove(cn.ToString());
                                    BroadCast();

                                }
                            }
                        });

                    }
                    else if (receivedData[0].Equals("PeerToPeer"))
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            var items = listViewClient.FindItemWithText(receivedData[2]);
                            if (items.SubItems[2].Text == "Busy")
                            {
                                SendClient(cn.tclient, Rijandel.Encrypt("Busy", passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize));
                            }
                            else
                            {
                                cnn = clientList.Find(x => x.strId == receivedData[2]);
                                SendClient(cnn.tclient, Rijandel.Encrypt(receivedData[1].TrimEnd('|'), passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize));
                                printLine(DateTime.Now + cn.ToString() + "Sending message to :   " + cnn.ToString() + "    Message is : " + receivedData[1]);

                            }
                        });
                    }
                    else if (receivedData[0].Equals("Busy"))
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            foreach (ListViewItem item in listViewClient.Items)
                            {
                                item.UseItemStyleForSubItems = false;

                                var invoice = item.SubItems[0];
                                if (invoice.Text == cn.ToString())
                                {
                                    item.SubItems[2] = new ListViewItem.ListViewSubItem() { Text = "Busy" };

                                    item.SubItems[2].ForeColor = System.Drawing.Color.Red;

                                }
                            }

                        });

                    }
                    else if (receivedData[0].Equals("Free"))
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            foreach (ListViewItem item in listViewClient.Items)
                            {
                                var invoice = item.SubItems[0];
                                if (invoice.Text == cn.ToString())
                                {
                                    item.SubItems[2] = new ListViewItem.ListViewSubItem() { Text = "Online" };
                                    //break;
                                }
                            }
                        });
                    }
                    else
                    {
                        printLine(DateTime.Now + " - " + "Received from " + cn.ToString() + ": " + decrypted);
                    }
                    cn.Rx = new byte[512];
                    tcpc.GetStream().BeginRead(cn.Rx, 0, cn.Rx.Length, readCallBack, tcpc);
                });
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                lock (clientList)
                {
                    printLine("Client disconnected: " + cn.ToString());
                    clientList.Remove(cn);
                    lbClients.Items.Remove(cn.ToString());
                }

            }

        }

        public void printLine(string _strPrint)
        {
            tbConsoleOutput.Invoke(new Action<string>(doInvoke), _strPrint);
        }

        public void doInvoke(string _strPrint)
        {
            tbConsoleOutput.Text = _strPrint + Environment.NewLine + tbConsoleOutput.Text;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            send(tbPayload.Text);
            tbPayload.Text = string.Empty;
        }

        private void send(string text)
        {
            if (string.IsNullOrEmpty(text) && lbClients.Items.Count <= 0)
            {

                MessageBox.Show("Please write message and choose  the client");
            }
            else
            {
                ClientNode cn = null;
                try
                {

                    Invoke((MethodInvoker)delegate
                    {
                        lbClients.SelectionMode = SelectionMode.MultiExtended;
                        foreach (var item in lbClients.SelectedItems)
                        {
                            cn = clientList.Find(x => x.strId == item.ToString());
                            cn.Tx = new byte[512];


                            if (cn != null)
                            {
                                if (cn.tclient != null)
                                {
                                    if (cn.tclient.Client.Connected)
                                    {

                                        cn.Tx = Encoding.ASCII.GetBytes(Rijandel.Encrypt(text, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize));
                                        cn.tclient.GetStream().BeginWrite(cn.Tx, 0, cn.Tx.Length, onCompleteWriteToClientStream, cn.tclient);
                                    }
                                }
                            }

                        }
                        printLine(DateTime.Now + " - " + "Sends to" + ": " + text);
                    });//release lock

                }

                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                    MessageBox.Show("Please choose the client");
                }
            }
        }


        private void onCompleteWriteToClientStream(IAsyncResult iar)
        {
            try
            {
                TcpClient tcpc = (TcpClient)iar.AsyncState;
                tcpc.GetStream().EndWrite(iar);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            var items = lbClients.SelectedItems;
            
            if (lbClients.SelectedIndex != -1)
            {
                send("Disconnected");
                for (int i = items.Count - 1; i >= 0; i--)
                    lbClients.Items.Remove(items[i]);

            }
            else
                MessageBox.Show("Please select an item");
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // listener.Start();
            btnStartListening.PerformClick();
        }

        private void tbIPAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (listener.Server.Connected)
            {
                listener.Server.Disconnect(true);

            }
            listener.Stop();
           // listener.Server.Close();
           if(client != null)
            {
                client.Close();
                client = null;
                
            }
            this.Close();
        }

        private void btnSend_Validating(object sender, CancelEventArgs e)
        {
            if (lbClients.SelectedIndex <= 1 && tbPayload.Text == "")
            {
                MessageBox.Show("Pleae Enter the Text and selete the client  ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {



            send("Users|" + "Remote endpoint");

        }

        private void tbConsoleOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void listViewClient_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FormClientList fcl = new FormClientList();
            //fcl.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            UserList f2 = new UserList();
            f2.Show();
        }
    }
}


