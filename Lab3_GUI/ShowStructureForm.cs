using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab3;
using Lab3.DB.Impl;

namespace Lab3_GUI
{
    public partial class ShowStructureForm : Form
    {
        public ShowStructureForm()
        {
            InitializeComponent();
        }

        private DataTable GetDescriptorDataTable()
        {
            var descriptor = MainForm.Instance.GetDbConnection().GetDescriptor();
            var data = new DataTable();
            data.Columns.Add("Property");
            data.Columns.Add("Value");

            data.Rows.Add("Block size", descriptor.BlockSize);
            data.Rows.Add("Data blocks count", descriptor.DataBlocksCount);
            data.Rows.Add("Record size", descriptor.RecordSize);
            data.Rows.Add("Index record size", descriptor.IndexRecordSize);
            data.Rows.Add("Link size", descriptor.LinkSize);
            data.Rows.Add("Overload zone size", descriptor.OverloadSize);

            return data;
        }

        private void LoadDescriptor()
        {
            
            dataGridView_dbInfo.DataSource = GetDescriptorDataTable();
            dataGridView_dbInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_dbInfo.RowHeadersVisible = false;
            dataGridView_dbInfo.Columns["Value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            dataGridView_dbInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
        }

        private DataTable GetIndexRecordsDataTable()
        {
            var data = new DataTable();
            data.Columns.Add("Key");
            data.Columns.Add("Main file block");
            var dbConnection = MainForm.Instance.GetDbConnection();
            var descriptor = dbConnection.GetDescriptor();
            var indexBlocksCount = descriptor.DataBlocksCount / (descriptor.BlockSize / descriptor.IndexRecordSize) + 1;
            for (int i = 0; i < indexBlocksCount; ++i)
            {
                foreach (var record in DbIndexFileUtility.GetBlockRecords(i, dbConnection))
                {
                    data.Rows.Add(record.Key, record.Block);
                }
            }
            return data;
        }

        private void LoadIndexFile()
        {
            var indexDataTable = GetIndexRecordsDataTable();
            Invoke(new EventHandler(delegate
            {
                pictureBox_loadIndex.Visible = false;
                dataGridView_indexFile.DataSource = indexDataTable;
                dataGridView_indexFile.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView_indexFile.RowHeadersVisible = false;
                dataGridView_indexFile.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                dataGridView_indexFile.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                dataGridView_indexFile.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            }), this, null);
        }

        private DataTable GetDataRecordsDataTable()
        {
            var data = new DataTable();
            data.Columns.Add("Block");
            data.Columns.Add("Key");
            data.Columns.Add("Sender private key");
            data.Columns.Add("Public token");
            data.Columns.Add("Amount");

            var dbConnection = MainForm.Instance.GetDbConnection();
            var descriptor = dbConnection.GetDescriptor();
            var blocksCount = descriptor.DataBlocksCount;
            var maxRecordsPerBlock = descriptor.BlockSize / descriptor.RecordSize;
            for (int block = 0; block < blocksCount; ++block)
            {
                var records = DbDataFileUtility.GetBlockRecords(block, dbConnection);
                foreach (var record in records)
                {
                    var transaction = record.Value as Transaction;
                    data.Rows.Add(block, record.Key, transaction.SenderPrivateKey, transaction.TransactionPublicToken,
                        transaction.Amount);
                }
                for (int i = 0; i < maxRecordsPerBlock - records.Length; ++i)
                {
                    data.Rows.Add(block, "null");
                }
                var overload = records.Length > maxRecordsPerBlock;
                data.Rows.Add(block, overload ? "Overload link" : "null link");
            }
            if (descriptor.OverloadSize > 0)
            {
                var overloadRecords = DbDataFileUtility.ReadOverloadZone(dbConnection);
                foreach (var record in overloadRecords)
                {
                    if (record.Key == -1)
                    {
                        data.Rows.Add("Overload", "null");
                        //data.Rows.Add("Overload", "null link");
                    }
                    else
                    {
                        var transaction = record.Value as Transaction;
                        data.Rows.Add("Overload", record.Key, transaction.SenderPrivateKey,
                            transaction.TransactionPublicToken,
                            transaction.Amount);
                        //data.Rows.Add("Overload", "link");
                    }
                }
            }

            return data;
        }

        private void LoadDataFile()
        {
            var recordsDataTable = GetDataRecordsDataTable();
            Invoke(new EventHandler(delegate
            {
                pictureBox_loadData.Visible = false;
                dataGridView_dataFile.DataSource = recordsDataTable;
                dataGridView_dataFile.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView_dataFile.RowHeadersVisible = false;
            }), this, null);            
        }

        private void ShowStructureForm_Load(object sender, EventArgs e)
        {
            LoadDescriptor();
            pictureBox_loadIndex.Visible = true;
            pictureBox_loadData.Visible = true;
            new Thread(LoadIndexFile).Start();
            new Thread(LoadDataFile).Start();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            MainForm.Instance.Show();
            MainForm.Instance.Location = this.Location;
            this.Close();
        }
    }
}
