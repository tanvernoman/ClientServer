namespace TCPClient
{
    partial class FormClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbConsole = new System.Windows.Forms.TextBox();
            this.tbPayload = new System.Windows.Forms.TextBox();
            this.tbSend = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.textLocalIp = new System.Windows.Forms.TextBox();
            this.listBoxOnlineClient = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBusy = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbConsole
            // 
            this.tbConsole.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConsole.Location = new System.Drawing.Point(391, 90);
            this.tbConsole.Multiline = true;
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbConsole.Size = new System.Drawing.Size(365, 261);
            this.tbConsole.TabIndex = 0;
            this.tbConsole.TextChanged += new System.EventHandler(this.tbConsole_TextChanged);
            // 
            // tbPayload
            // 
            this.tbPayload.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPayload.Location = new System.Drawing.Point(391, 368);
            this.tbPayload.Multiline = true;
            this.tbPayload.Name = "tbPayload";
            this.tbPayload.Size = new System.Drawing.Size(239, 39);
            this.tbPayload.TabIndex = 1;
            this.tbPayload.TextChanged += new System.EventHandler(this.tbPayload_TextChanged);
            // 
            // tbSend
            // 
            this.tbSend.Location = new System.Drawing.Point(656, 368);
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(100, 34);
            this.tbSend.TabIndex = 4;
            this.tbSend.Text = "Send";
            this.tbSend.UseVisualStyleBackColor = true;
            this.tbSend.Click += new System.EventHandler(this.tbSend_Click);
            this.tbSend.Validating += new System.ComponentModel.CancelEventHandler(this.tbSend_Validating);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(444, 27);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(130, 47);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect To Server";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(617, 27);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(139, 47);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close Application";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // textLocalIp
            // 
            this.textLocalIp.Location = new System.Drawing.Point(25, 90);
            this.textLocalIp.Name = "textLocalIp";
            this.textLocalIp.Size = new System.Drawing.Size(139, 20);
            this.textLocalIp.TabIndex = 7;
            // 
            // listBoxOnlineClient
            // 
            this.listBoxOnlineClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxOnlineClient.FormattingEnabled = true;
            this.listBoxOnlineClient.ItemHeight = 20;
            this.listBoxOnlineClient.Location = new System.Drawing.Point(25, 178);
            this.listBoxOnlineClient.Name = "listBoxOnlineClient";
            this.listBoxOnlineClient.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxOnlineClient.Size = new System.Drawing.Size(339, 224);
            this.listBoxOnlineClient.TabIndex = 13;
            this.listBoxOnlineClient.SelectedIndexChanged += new System.EventHandler(this.listBoxOnlineClient_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.registerToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(796, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // registerToolStripMenuItem
            // 
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.registerToolStripMenuItem.Text = "Register";
            this.registerToolStripMenuItem.Click += new System.EventHandler(this.registerToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.logOutToolStripMenuItem.Text = "LogOut";
            // 
            // btnBusy
            // 
            this.btnBusy.Location = new System.Drawing.Point(25, 38);
            this.btnBusy.Name = "btnBusy";
            this.btnBusy.Size = new System.Drawing.Size(75, 23);
            this.btnBusy.TabIndex = 18;
            this.btnBusy.Text = "Busy";
            this.btnBusy.UseVisualStyleBackColor = true;
            this.btnBusy.Click += new System.EventHandler(this.btnBusy_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(123, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "Free";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUsername.Location = new System.Drawing.Point(240, 38);
            this.textBoxUsername.Multiline = true;
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(198, 34);
            this.textBoxUsername.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 22);
            this.label1.TabIndex = 22;
            this.label1.Text = "Online User";
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 431);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnBusy);
            this.Controls.Add(this.listBoxOnlineClient);
            this.Controls.Add(this.textLocalIp);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.tbSend);
            this.Controls.Add(this.tbPayload);
            this.Controls.Add(this.tbConsole);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormClient";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbConsole;
        private System.Windows.Forms.TextBox tbPayload;
        private System.Windows.Forms.Button tbSend;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox textLocalIp;
        private System.Windows.Forms.ListBox listBoxOnlineClient;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.Button btnBusy;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label label1;
    }
}

