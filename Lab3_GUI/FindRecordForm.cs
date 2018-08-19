using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab3;
using Lab3.DB;

namespace Lab3_GUI
{
    public partial class FindRecordForm : Form
    {
        public FindRecordForm()
        {
            InitializeComponent();
        }

        private void button_find_Click(object sender, EventArgs e)
        {
            int key;
            if (!int.TryParse(textBox_key.Text, out key))
            {
                textBox_key.Text = String.Empty;
                MessageBox.Show(@"Wrong data");
                return;
            }

            var useStatistic = checkBox_comp.Checked;
            int comparasions = 0;
            var record = useStatistic
                ? MainForm.Instance.GetDbConnection().GetManager().ReadWithStatistic(key, out comparasions)
                : MainForm.Instance.GetDbConnection().GetManager().Read(key);
            if (!record.HasValue)
            {
                MessageBox.Show(@"No records found.");
                return;
            }
            var transaction = (Transaction) record.Value.Value;
            textBox_sender.Text = transaction.SenderPrivateKey.ToString();
            textBox_token.Text = transaction.TransactionPublicToken.ToString();
            textBox_amount.Text = transaction.Amount.ToString(CultureInfo.CurrentCulture);
            textBox_comp.Text = useStatistic ? comparasions.ToString() : String.Empty;
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

        private void button_save_Click(object sender, EventArgs e)
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

            MainForm.Instance.GetDbConnection().GetManager().Write(
                key, new Transaction(senderKey, publicToken, amount));
            MessageBox.Show(@"Record saved.");
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
