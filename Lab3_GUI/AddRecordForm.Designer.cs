namespace Lab3_GUI
{
    partial class AddRecordForm
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
            this.textBox_key = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_sender = new System.Windows.Forms.TextBox();
            this.button_getSenderKey = new System.Windows.Forms.Button();
            this.button_getPublicToken = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_token = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_amount = new System.Windows.Forms.TextBox();
            this.button_add = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_key
            // 
            this.textBox_key.Location = new System.Drawing.Point(156, 33);
            this.textBox_key.Name = "textBox_key";
            this.textBox_key.Size = new System.Drawing.Size(322, 22);
            this.textBox_key.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sender private key";
            // 
            // textBox_sender
            // 
            this.textBox_sender.Location = new System.Drawing.Point(156, 73);
            this.textBox_sender.Name = "textBox_sender";
            this.textBox_sender.Size = new System.Drawing.Size(322, 22);
            this.textBox_sender.TabIndex = 2;
            // 
            // button_getSenderKey
            // 
            this.button_getSenderKey.Location = new System.Drawing.Point(487, 65);
            this.button_getSenderKey.Name = "button_getSenderKey";
            this.button_getSenderKey.Size = new System.Drawing.Size(47, 33);
            this.button_getSenderKey.TabIndex = 4;
            this.button_getSenderKey.Text = "Get";
            this.button_getSenderKey.UseVisualStyleBackColor = true;
            this.button_getSenderKey.Click += new System.EventHandler(this.button_getSenderKey_Click);
            // 
            // button_getPublicToken
            // 
            this.button_getPublicToken.Location = new System.Drawing.Point(487, 111);
            this.button_getPublicToken.Name = "button_getPublicToken";
            this.button_getPublicToken.Size = new System.Drawing.Size(47, 33);
            this.button_getPublicToken.TabIndex = 7;
            this.button_getPublicToken.Text = "Get";
            this.button_getPublicToken.UseVisualStyleBackColor = true;
            this.button_getPublicToken.Click += new System.EventHandler(this.button_getPublicToken_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 34);
            this.label3.TabIndex = 6;
            this.label3.Text = "Transaction public \r\n token";
            // 
            // textBox_token
            // 
            this.textBox_token.Location = new System.Drawing.Point(156, 119);
            this.textBox_token.Name = "textBox_token";
            this.textBox_token.Size = new System.Drawing.Size(322, 22);
            this.textBox_token.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Amount";
            // 
            // textBox_amount
            // 
            this.textBox_amount.Location = new System.Drawing.Point(156, 165);
            this.textBox_amount.Name = "textBox_amount";
            this.textBox_amount.Size = new System.Drawing.Size(322, 22);
            this.textBox_amount.TabIndex = 8;
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(117, 259);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(130, 39);
            this.button_add.TabIndex = 10;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(316, 259);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(130, 39);
            this.button_close.TabIndex = 11;
            this.button_close.Text = "Close";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_amount);
            this.groupBox1.Controls.Add(this.button_getPublicToken);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_token);
            this.groupBox1.Controls.Add(this.button_getSenderKey);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_sender);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_key);
            this.groupBox1.Location = new System.Drawing.Point(22, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 220);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Record";
            // 
            // AddRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 316);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.button_add);
            this.Name = "AddRecordForm";
            this.Text = "AddRecordForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_key;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_sender;
        private System.Windows.Forms.Button button_getSenderKey;
        private System.Windows.Forms.Button button_getPublicToken;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_token;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_amount;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}