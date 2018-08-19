using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab3;
using Lab3.DB;

namespace Lab3_GUI
{
    public partial class AddRecordForm : Form
    {
        public AddRecordForm()
        {
            InitializeComponent();
        }

        private bool readKey(out int key)
        {
            if (!int.TryParse(textBox_key.Text, out key))
            {
                textBox_key.Text = String.Empty;
                return false;
            }
            return true;
        }

        private bool readAmount(out float res)
        {
            if (!float.TryParse(textBox_amount.Text, out res))
            {
                textBox_amount.Text = String.Empty;
                return false;
            }
            return true;
        }

        private bool readSenderKey(out Guid res)
        {
            if (!Guid.TryParse(textBox_sender.Text, out res))
            {
                textBox_sender.Text = String.Empty;
                return false;
            }
            return true;
        }

        private bool readToken(out Guid res)
        {
            if (!Guid.TryParse(textBox_token.Text, out res))
            {
                textBox_token.Text = String.Empty;
                return false;
            }
            return true;
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            int key = 0;
            float amount = 0;
            Guid senderKey = Guid.Empty, publicToken = Guid.Empty;
            bool wrongData = readKey(out key) && readAmount(out amount)
                && readSenderKey(out senderKey) && readToken(out publicToken);
            if (!wrongData)
            {
                MessageBox.Show(@"Wrong data.");
                return;
            }

            MainForm.Instance.GetDbConnection().GetManager().Write(key, new Transaction(senderKey, publicToken, amount));
            MessageBox.Show(@"Record added.");
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            MainForm.Instance.Show();
            MainForm.Instance.Location = this.Location;
            this.Close();
        }

        private void button_getSenderKey_Click(object sender, EventArgs e)
        {
            textBox_sender.Text = Guid.NewGuid().ToString();
        }

        private void button_getPublicToken_Click(object sender, EventArgs e)
        {
            textBox_token.Text = Guid.NewGuid().ToString();
        }
    }
}
