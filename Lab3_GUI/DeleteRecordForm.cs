using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab3.DB;

namespace Lab3_GUI
{
    public partial class DeleteRecordForm : Form
    {
        public DeleteRecordForm()
        {
            InitializeComponent();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            int key;
            if (!int.TryParse(textBox_key.Text, out key))
            {
                textBox_key.Text = String.Empty;
                MessageBox.Show(@"Wrong data.");
                return;
            }

            MessageBox.Show(MainForm.Instance.GetDbConnection().GetManager().Delete(key)
                ? @"Record deleted."
                : @"Record not found.");
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            MainForm.Instance.Show();
            MainForm.Instance.Location = this.Location;
            this.Close();
        }
    }
}
