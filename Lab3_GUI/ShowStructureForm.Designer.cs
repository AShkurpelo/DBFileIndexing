namespace Lab3_GUI
{
    partial class ShowStructureForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.button_close = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView_dbInfo = new System.Windows.Forms.DataGridView();
            this.dataGridView_indexFile = new System.Windows.Forms.DataGridView();
            this.dataGridView_dataFile = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox_loadData = new System.Windows.Forms.PictureBox();
            this.pictureBox_loadIndex = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dbInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_indexFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dataFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_loadData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_loadIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data base info";
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(351, 654);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(134, 36);
            this.button_close.TabIndex = 2;
            this.button_close.Text = "Close";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(634, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Index file";
            // 
            // dataGridView_dbInfo
            // 
            this.dataGridView_dbInfo.AllowUserToAddRows = false;
            this.dataGridView_dbInfo.AllowUserToDeleteRows = false;
            this.dataGridView_dbInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_dbInfo.Location = new System.Drawing.Point(33, 40);
            this.dataGridView_dbInfo.Name = "dataGridView_dbInfo";
            this.dataGridView_dbInfo.ReadOnly = true;
            this.dataGridView_dbInfo.RowTemplate.Height = 24;
            this.dataGridView_dbInfo.Size = new System.Drawing.Size(346, 228);
            this.dataGridView_dbInfo.TabIndex = 5;
            // 
            // dataGridView_indexFile
            // 
            this.dataGridView_indexFile.AllowUserToAddRows = false;
            this.dataGridView_indexFile.AllowUserToDeleteRows = false;
            this.dataGridView_indexFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_indexFile.Location = new System.Drawing.Point(488, 40);
            this.dataGridView_indexFile.Name = "dataGridView_indexFile";
            this.dataGridView_indexFile.ReadOnly = true;
            this.dataGridView_indexFile.RowTemplate.Height = 24;
            this.dataGridView_indexFile.Size = new System.Drawing.Size(346, 228);
            this.dataGridView_indexFile.TabIndex = 6;
            // 
            // dataGridView_dataFile
            // 
            this.dataGridView_dataFile.AllowUserToAddRows = false;
            this.dataGridView_dataFile.AllowUserToDeleteRows = false;
            this.dataGridView_dataFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_dataFile.Location = new System.Drawing.Point(33, 297);
            this.dataGridView_dataFile.Name = "dataGridView_dataFile";
            this.dataGridView_dataFile.ReadOnly = true;
            this.dataGridView_dataFile.RowTemplate.Height = 24;
            this.dataGridView_dataFile.Size = new System.Drawing.Size(801, 351);
            this.dataGridView_dataFile.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(403, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Data file";
            // 
            // pictureBox_loadData
            // 
            this.pictureBox_loadData.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox_loadData.Image = global::Lab3_GUI.Properties.Resources.Spinner;
            this.pictureBox_loadData.Location = new System.Drawing.Point(351, 390);
            this.pictureBox_loadData.Name = "pictureBox_loadData";
            this.pictureBox_loadData.Size = new System.Drawing.Size(148, 148);
            this.pictureBox_loadData.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_loadData.TabIndex = 9;
            this.pictureBox_loadData.TabStop = false;
            // 
            // pictureBox_loadIndex
            // 
            this.pictureBox_loadIndex.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox_loadIndex.Image = global::Lab3_GUI.Properties.Resources.Spinner;
            this.pictureBox_loadIndex.Location = new System.Drawing.Point(591, 79);
            this.pictureBox_loadIndex.Name = "pictureBox_loadIndex";
            this.pictureBox_loadIndex.Size = new System.Drawing.Size(148, 148);
            this.pictureBox_loadIndex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_loadIndex.TabIndex = 10;
            this.pictureBox_loadIndex.TabStop = false;
            // 
            // ShowStructureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 702);
            this.Controls.Add(this.pictureBox_loadIndex);
            this.Controls.Add(this.pictureBox_loadData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView_dataFile);
            this.Controls.Add(this.dataGridView_indexFile);
            this.Controls.Add(this.dataGridView_dbInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.label1);
            this.Name = "ShowStructureForm";
            this.Text = "ShowStructureForm";
            this.Load += new System.EventHandler(this.ShowStructureForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dbInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_indexFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dataFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_loadData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_loadIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView_dbInfo;
        private System.Windows.Forms.DataGridView dataGridView_indexFile;
        private System.Windows.Forms.DataGridView dataGridView_dataFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox_loadData;
        private System.Windows.Forms.PictureBox pictureBox_loadIndex;
    }
}