namespace Lab3_GUI
{
    partial class MainForm
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
            this.button_generate = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.button_find = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_show = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_generate
            // 
            this.button_generate.Location = new System.Drawing.Point(151, 45);
            this.button_generate.Name = "button_generate";
            this.button_generate.Size = new System.Drawing.Size(186, 34);
            this.button_generate.TabIndex = 0;
            this.button_generate.Text = "Generate new data";
            this.button_generate.UseVisualStyleBackColor = true;
            this.button_generate.Click += new System.EventHandler(this.button_generate_Click);
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(151, 100);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(186, 34);
            this.button_add.TabIndex = 1;
            this.button_add.Text = "Add record";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_find
            // 
            this.button_find.Location = new System.Drawing.Point(151, 153);
            this.button_find.Name = "button_find";
            this.button_find.Size = new System.Drawing.Size(186, 34);
            this.button_find.TabIndex = 2;
            this.button_find.Text = "Find record";
            this.button_find.UseVisualStyleBackColor = true;
            this.button_find.Click += new System.EventHandler(this.button_find_Click);
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(151, 206);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(186, 34);
            this.button_delete.TabIndex = 3;
            this.button_delete.Text = "Delete record";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_show
            // 
            this.button_show.Location = new System.Drawing.Point(151, 259);
            this.button_show.Name = "button_show";
            this.button_show.Size = new System.Drawing.Size(186, 34);
            this.button_show.TabIndex = 5;
            this.button_show.Text = "Show structure";
            this.button_show.UseVisualStyleBackColor = true;
            this.button_show.Click += new System.EventHandler(this.button_show_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(509, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.programToolStripMenuItem.Text = "Program";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(108, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 305);
            this.Controls.Add(this.button_show);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_find);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.button_generate);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DB app";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_generate;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_find;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_show;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

