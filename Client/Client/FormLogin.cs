using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;
using RijandelAlgorithm;
using ApplicationDatabaseServer;

namespace TCPClient
{
    public partial class FormLogin : Form
    {
       // RijandleManagedEnDe myRijandle = new RijandleManagedEnDe();
        string passPhrase = "Pas5pr@se";
        string saltValue = "s@1tValue";
        //string hashAlgorithm = "SHA1";
       // string hashAlgorithm = "SHA256";
        string hashAlgorithm = "SHA512";
        int passwordIterations = 2;
        string initVector = "@1B2c3D4e5F6g7H8";
        int keySize = 256;
        public FormLogin()
        {
            InitializeComponent();
            //Form1 f = new Form1();
        }

        private void button1_Click(object sender, EventArgs e)
        {

                
                

                    if (textBox1.Text != null && textBox2.Text!= null)
                    {

                        FormClient fc = new FormClient(textBox1.Text, textBox2.Text);
                        this.Hide();
                        fc.Show();

                    }
                    
                   
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength < 5 && textBox1.TextLength > 14)
            {
                MessageBox.Show("it can not be less than 5 and  more than 14 characters");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormRegister fr = new FormRegister();
            this.Hide();
            fr.Show();
        }
    }
}

