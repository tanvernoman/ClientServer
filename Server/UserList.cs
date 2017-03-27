using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class UserList : Form
    {
        public UserList()
        {
            InitializeComponent();
        }

        private void tbUsersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tbUsersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.userDataSet);

        }

        private void UserList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'userDataSet.tbUsers' table. You can move, or remove it, as needed.
            this.tbUsersTableAdapter.Fill(this.userDataSet.tbUsers);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
