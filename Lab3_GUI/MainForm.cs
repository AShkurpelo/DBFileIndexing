using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab3;
using Lab3.DB;
using Lab3.DB.Impl;

namespace Lab3_GUI
{
    public partial class MainForm : Form
    {
        private IDbConnection _dbConnection;

        public static MainForm Instance;

        public MainForm()
        {
            InitializeComponent();
            Instance = this;
            _dbConnection = new DbConnection();
        }

        public IDbConnection GetDbConnection()
        {
            return _dbConnection;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private SortedDictionary<int, object> CreateDbTestData()
        {
            var data = new SortedDictionary<int, object>();
            var rand = new Random();
            var maxStep = 10;
            var key = rand.Next(maxStep);
            for (int i = 0; i < 10000; ++i)
            {
                key += rand.Next(maxStep) + 1;
                data.Add(key, new Transaction(Guid.NewGuid(), Guid.NewGuid(), rand.Next(10000)));
            }
            return data;
        }

        private void button_generate_Click(object sender, EventArgs e)
        {
            GetDbConnection().GetManager().RewriteWithIndexRebuild(CreateDbTestData());
            MessageBox.Show(@"Data generated. ( 10000 records )");
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            var form = new AddRecordForm();
            form.Show();
            form.Location = this.Location;
            this.Hide();
        }

        private void button_find_Click(object sender, EventArgs e)
        {
            var form = new FindRecordForm();
            form.Show();
            form.Location = this.Location;
            this.Hide();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            var form = new DeleteRecordForm();
            form.Show();
            form.Location = this.Location;
            this.Hide();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _dbConnection.Dispose();
        }

        private void button_show_Click(object sender, EventArgs e)
        {
            var form = new ShowStructureForm();
            form.Show();
            form.Location = this.Location;
            this.Hide();
        }
    }
}
