namespace Chat_Client {
    partial class MessageScreen {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.textEntry = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.submit = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.messagePanel1 = new Chat_Client.MessagePanel();
            this.SuspendLayout();
            // 
            // textEntry
            // 
            this.textEntry.Location = new System.Drawing.Point(3, 604);
            this.textEntry.Name = "textEntry";
            this.textEntry.Size = new System.Drawing.Size(301, 46);
            this.textEntry.TabIndex = 0;
            this.textEntry.Text = "Type here";
            this.textEntry.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // submit
            // 
            this.submit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.submit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.submit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.submit.Location = new System.Drawing.Point(310, 604);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(117, 46);
            this.submit.TabIndex = 2;
            this.submit.Text = "Send";
            this.submit.UseVisualStyleBackColor = false;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(140, 3);
            this.textBox1.MaxLength = 10;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(146, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Username";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoCheck = false;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(327, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(83, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "connected?";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // messagePanel1
            // 
            this.messagePanel1.AutoScroll = true;
            this.messagePanel1.BackColor = System.Drawing.SystemColors.Control;
            this.messagePanel1.Location = new System.Drawing.Point(23, 24);
            this.messagePanel1.Name = "messagePanel1";
            this.messagePanel1.Size = new System.Drawing.Size(384, 554);
            this.messagePanel1.TabIndex = 0;
            this.messagePanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.messagePanel1_Paint);
            // 
            // MessageScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.messagePanel1);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.textEntry);
            this.Name = "MessageScreen";
            this.Size = new System.Drawing.Size(430, 660);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.Button submit;
        public System.Windows.Forms.RichTextBox textEntry;
        public MessagePanel messagePanel1;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.CheckBox checkBox1;
    }
}
