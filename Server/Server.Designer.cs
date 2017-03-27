namespace TCPServer
{
    partial class Form1
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
            this.tbConsoleOutput = new System.Windows.Forms.TextBox();
            this.btnStartListening = new System.Windows.Forms.Button();
            this.tbPayload = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lbClients = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listViewClient = new System.Windows.Forms.ListView();
            this.lvipaddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbusername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvstatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbConsoleOutput
            // 
            this.tbConsoleOutput.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConsoleOutput.Location = new System.Drawing.Point(417, 74);
            this.tbConsoleOutput.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.tbConsoleOutput.Multiline = true;
            this.tbConsoleOutput.Name = "tbConsoleOutput";
            this.tbConsoleOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbConsoleOutput.Size = new System.Drawing.Size(387, 205);
            this.tbConsoleOutput.TabIndex = 0;
            this.tbConsoleOutput.TextChanged += new System.EventHandler(this.tbConsoleOutput_TextChanged);
            // 
            // btnStartListening
            // 
            this.btnStartListening.Location = new System.Drawing.Point(428, 30);
            this.btnStartListening.Name = "btnStartListening";
            this.btnStartListening.Size = new System.Drawing.Size(125, 31);
            this.btnStartListening.TabIndex = 4;
            this.btnStartListening.Text = "Start Listening";
            this.btnStartListening.UseVisualStyleBackColor = true;
            this.btnStartListening.Click += new System.EventHandler(this.btnStartListening_Click);
            // 
            // tbPayload
            // 
            this.tbPayload.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPayload.Location = new System.Drawing.Point(417, 302);
            this.tbPayload.Multiline = true;
            this.tbPayload.Name = "tbPayload";
            this.tbPayload.Size = new System.Drawing.Size(282, 45);
            this.tbPayload.TabIndex = 5;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(715, 302);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(109, 45);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            this.btnSend.Validating += new System.ComponentModel.CancelEventHandler(this.btnSend_Validating);
            // 
            // lbClients
            // 
            this.lbClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClients.FormattingEnabled = true;
            this.lbClients.HorizontalScrollbar = true;
            this.lbClients.ItemHeight = 20;
            this.lbClients.Location = new System.Drawing.Point(15, 54);
            this.lbClients.Name = "lbClients";
            this.lbClients.ScrollAlwaysVisible = true;
            this.lbClients.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbClients.Size = new System.Drawing.Size(287, 184);
            this.lbClients.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Online Client";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(574, 30);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 31);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close Application";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(320, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 30);
            this.button1.TabIndex = 12;
            this.button1.Text = "Stop Client";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listViewClient
            // 
            this.listViewClient.AllowColumnReorder = true;
            this.listViewClient.CheckBoxes = true;
            this.listViewClient.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvipaddress,
            this.lbusername,
            this.lvstatus});
            this.listViewClient.FullRowSelect = true;
            this.listViewClient.GridLines = true;
            this.listViewClient.Location = new System.Drawing.Point(28, 244);
            this.listViewClient.Name = "listViewClient";
            this.listViewClient.Size = new System.Drawing.Size(357, 128);
            this.listViewClient.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewClient.TabIndex = 13;
            this.listViewClient.UseCompatibleStateImageBehavior = false;
            this.listViewClient.View = System.Windows.Forms.View.Details;
            this.listViewClient.SelectedIndexChanged += new System.EventHandler(this.listViewClient_SelectedIndexChanged);
            // 
            // lvipaddress
            // 
            this.lvipaddress.Text = "IPAddress";
            this.lvipaddress.Width = 137;
            // 
            // lbusername
            // 
            this.lbusername.Text = "User name";
            this.lbusername.Width = 106;
            // 
            // lvstatus
            // 
            this.lvstatus.Text = "Status";
            this.lvstatus.Width = 123;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(715, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "User List";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 384);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listViewClient);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbClients);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tbPayload);
            this.Controls.Add(this.btnStartListening);
            this.Controls.Add(this.tbConsoleOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbConsoleOutput;
        private System.Windows.Forms.Button btnStartListening;
        private System.Windows.Forms.TextBox tbPayload;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListBox lbClients;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listViewClient;
        private System.Windows.Forms.ColumnHeader lvipaddress;
        private System.Windows.Forms.ColumnHeader lbusername;
        private System.Windows.Forms.ColumnHeader lvstatus;
        private System.Windows.Forms.Button button2;
    }
}

