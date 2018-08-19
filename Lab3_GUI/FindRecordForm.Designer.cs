namespace Lab3_GUI
{
    partial class FindRecordForm
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
            this.button_find = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_amount = new System.Windows.Forms.TextBox();
            this.button_getPublicToken = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_token = new System.Windows.Forms.TextBox();
            this.button_getSenderKey = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_sender = new System.Windows.Forms.TextBox();
            this.button_save = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_comp = new System.Windows.Forms.CheckBox();
            this.textBox_comp = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_key
            // 
            this.textBox_key.Location = new System.Drawing.Point(72, 40);
            this.textBox_key.Name = "textBox_key";
            this.textBox_key.Size = new System.Drawing.Size(309, 22);
            this.textBox_key.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Key";
            // 
            // button_find
            // 
            this.button_find.Location = new System.Drawing.Point(387, 32);
            this.button_find.Name = "button_find";
            this.button_find.Size = new System.Drawing.Size(130, 39);
            this.button_find.TabIndex = 2;
            this.button_find.Text = "Find";
            this.button_find.UseVisualStyleBackColor = true;
            this.button_find.Click += new System.EventHandler(this.button_find_Click);
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(312, 402);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(130, 39);
            this.button_close.TabIndex = 3;
            this.button_close.Text = "Close";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Amount";
            // 
            // textBox_amount
            // 
            this.textBox_amount.Location = new System.Drawing.Point(162, 147);
            this.textBox_amount.Name = "textBox_amount";
            this.textBox_amount.Size = new System.Drawing.Size(268, 22);
            this.textBox_amount.TabIndex = 18;
            // 
            // button_getPublicToken
            // 
            this.button_getPublicToken.Location = new System.Drawing.Point(439, 93);
            this.button_getPublicToken.Name = "button_getPublicToken";
            this.button_getPublicToken.Size = new System.Drawing.Size(54, 33);
            this.button_getPublicToken.TabIndex = 17;
            this.button_getPublicToken.Text = "New";
            this.button_getPublicToken.UseVisualStyleBackColor = true;
            this.button_getPublicToken.Click += new System.EventHandler(this.button_getPublicToken_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 34);
            this.label3.TabIndex = 16;
            this.label3.Text = "Transaction public \r\ntoken";
            // 
            // textBox_token
            // 
            this.textBox_token.Location = new System.Drawing.Point(162, 101);
            this.textBox_token.Name = "textBox_token";
            this.textBox_token.Size = new System.Drawing.Size(268, 22);
            this.textBox_token.TabIndex = 15;
            // 
            // button_getSenderKey
            // 
            this.button_getSenderKey.Location = new System.Drawing.Point(439, 47);
            this.button_getSenderKey.Name = "button_getSenderKey";
            this.button_getSenderKey.Size = new System.Drawing.Size(54, 33);
            this.button_getSenderKey.TabIndex = 14;
            this.button_getSenderKey.Text = "New";
            this.button_getSenderKey.UseVisualStyleBackColor = true;
            this.button_getSenderKey.Click += new System.EventHandler(this.button_getSenderKey_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Sender private key";
            // 
            // textBox_sender
            // 
            this.textBox_sender.Location = new System.Drawing.Point(162, 55);
            this.textBox_sender.Name = "textBox_sender";
            this.textBox_sender.Size = new System.Drawing.Size(268, 22);
            this.textBox_sender.TabIndex = 12;
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(113, 402);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(130, 39);
            this.button_save.TabIndex = 20;
            this.button_save.Text = "Save changes";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(25, 167);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(505, 215);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Record";
            // 
            // checkBox_comp
            // 
            this.checkBox_comp.AutoSize = true;
            this.checkBox_comp.Location = new System.Drawing.Point(17, 32);
            this.checkBox_comp.Name = "checkBox_comp";
            this.checkBox_comp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_comp.Size = new System.Drawing.Size(159, 21);
            this.checkBox_comp.TabIndex = 22;
            this.checkBox_comp.Text = "Count comparasions";
            this.checkBox_comp.UseVisualStyleBackColor = true;
            // 
            // textBox_comp
            // 
            this.textBox_comp.Location = new System.Drawing.Point(331, 30);
            this.textBox_comp.Name = "textBox_comp";
            this.textBox_comp.ReadOnly = true;
            this.textBox_comp.Size = new System.Drawing.Size(161, 22);
            this.textBox_comp.TabIndex = 23;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox_comp);
            this.groupBox2.Controls.Add(this.checkBox_comp);
            this.groupBox2.Location = new System.Drawing.Point(25, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(505, 72);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Statistics";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(227, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 17);
            this.label5.TabIndex = 24;
            this.label5.Text = "Comparasions";
            // 
            // FindRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 464);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.button_find);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_key);
            this.Name = "FindRecordForm";
            this.Text = "FindRecordForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_key;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_find;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_amount;
        private System.Windows.Forms.Button button_getPublicToken;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_token;
        private System.Windows.Forms.Button button_getSenderKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_sender;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_comp;
        private System.Windows.Forms.TextBox textBox_comp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
    }
}