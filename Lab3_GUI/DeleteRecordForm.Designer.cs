namespace Lab3_GUI
{
    partial class DeleteRecordForm
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
            this.button_delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_key = new System.Windows.Forms.TextBox();
            this.button_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(274, 30);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(130, 39);
            this.button_delete.TabIndex = 5;
            this.button_delete.Text = "Delete";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Key";
            // 
            // textBox_key
            // 
            this.textBox_key.Location = new System.Drawing.Point(45, 39);
            this.textBox_key.Name = "textBox_key";
            this.textBox_key.Size = new System.Drawing.Size(197, 22);
            this.textBox_key.TabIndex = 3;
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(143, 104);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(130, 39);
            this.button_close.TabIndex = 6;
            this.button_close.Text = "Close";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // DeleteRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 165);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_key);
            this.Name = "DeleteRecordForm";
            this.Text = "DeleteRecordForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_key;
        private System.Windows.Forms.Button button_close;
    }
}