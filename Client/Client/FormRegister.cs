using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Security;
using Client;
using ApplicationDatabaseServer;
using Client;
using RijandelAlgorithm;

namespace TCPClient
{
    public partial class FormRegister : Form
    {
        
        string passPhrase = "Pas5pr@se";
        string saltValue = "s@1tValue";
       // string hashAlgorithm = "SHA1";
      //  string hashAlgorithm = "SHA256";
        string hashAlgorithm = "SHA512";
        int passwordIterations = 2;
        string initVector = "@1B2c3D4e5F6g7H8";
        int keySize = 256;

        public FormRegister()
        {
            InitializeComponent();

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            if (tbUserName.Text != "" && tbPassword.Text != "" && tbRepetePassword.Text != "")
            {
                string username = tbUserName.Text;
                string password = Rijandel.Encrypt(tbPassword.Text,passPhrase,saltValue,hashAlgorithm,passwordIterations,initVector,keySize);


                using (DataClassesDatabaseServerDataContext db = new DataClassesDatabaseServerDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\UN\06-02-2017-22-30 PEERTOPEERDONE\BACKUP\CLIENTSERVER\APPLICATIONDATABASESERVER\DATABASESERVER.MDF;Integrated Security=True;Connect Timeout=30"))
                {
                    Table<tbUser> logins = db.GetTable<tbUser>();
                        var query =
                          from c in logins
                          where (c.username == tbUserName.Text)
                          select c;

                        if (query.Count() > 0)
                        {
                            MessageBox.Show("Please Choose Different username");
                        }
                        else
                        {
                            tbUser u = new tbUser();

                            u.username = username;
                            u.password = password;


                            // db.tbUsers.InsertOnSubmit(u);
                            db.tbUsers.InsertOnSubmit(u);

                            try
                            {
                                db.SubmitChanges();
                                MessageBox.Show("Registered successfully");
                                FormLogin fl = new FormLogin();
                                this.Hide();
                                fl.Show();
                            }
                            catch (Exception ee)
                            {
                                MessageBox.Show(ee.Message);
                            }
                        }
                    }
                }
            
            else
            {
                MessageBox.Show("Please enter the data ");

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            tbPassword.PasswordChar = '*';
        }

        private void tbRepetePassword_TextChanged(object sender, EventArgs e)
        {
            tbRepetePassword.PasswordChar = '*';
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
