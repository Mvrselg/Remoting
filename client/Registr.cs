using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Threading;
using ClassLibrary1;

namespace client
{
    public partial class Registr : Form
    {
        public Registr()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                OleDbCommand cmd = null;
                string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;
                Data Source=D:\visual studio\Курсач по ТП\BankAccount\BankAccount\Bank.mdb";
                OleDbConnection con = new OleDbConnection(ConnectionString);
                string Login = textBox1.Text;
                string Password = textBox2.Text;
                string Name = textBox3.Text;
                string Surname = textBox4.Text;
                string Phone = textBox5.Text;

                using (con)
                {
                    using (cmd = con.CreateCommand())
                    {
                        cmd.CommandText = string.Format("INSERT INTO Users ([Логин], [Пароль], [Имя], " +
                            "[Фамилия], [Номер телефона]) " +
                            "Values(@Login, @Password, @Name, @Surname, @Phone)");
                        cmd.CommandType = CommandType.Text;
                        // Добавить параметры
                        cmd.Parameters.AddWithValue("@Login", Login);
                        cmd.Parameters.AddWithValue("@Password", Password);
                        cmd.Parameters.AddWithValue("@Name", Name);
                        cmd.Parameters.AddWithValue("@Surname", Surname);
                        cmd.Parameters.AddWithValue("@Phone", Phone);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                new Thread(() => { Application.Run(new Menu()); }).Start();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Thread(() => { Application.Run(new Menu()); }).Start();
            this.Close();
        }
    }
}
