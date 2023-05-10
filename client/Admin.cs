using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data.OleDb;
using ClassLibrary1;

namespace client
{
    public partial class Admin : Form
    {
        private OleDbConnection MyConnection = null;
        private OleDbCommand DataAdapter = null;
        private DataTable table = null;
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strSQL = null;
            MyConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;" +
                @"Data Source=D:\visual studio\Курсач по ТП\BankAccount\BankAccount\Bank.mdb");
            MyConnection.Open();
            strSQL = "SELECT * From Registrations ORDER BY 'BookingDate' ASC";
            DataAdapter = new OleDbCommand(strSQL, MyConnection);
            table = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter(DataAdapter);
            adp.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Thread(() => { Application.Run(new Menu()); }).Start();
            this.Close();
        }
    }
}
