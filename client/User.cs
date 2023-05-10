using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using ClassLibrary1;
using System.Data.OleDb;
namespace client
{
    public partial class User : Form
    {
        Connection ClassLib = new Class1();
        public User()
        {
            InitializeComponent();
        }

        private void User_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Today;
            for (int i = 0; i < 13; i++)
                comboBox3.Items.Add(Convert.ToString(i + 8) + ":00:00");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;
                Data Source=D:\visual studio\Курсач по ТП\BankAccount\BankAccount\Bank.mdb";
            string data = dateTimePicker1.Text;
            string time = comboBox3.Text;
            string mesto = comboBox1.Text;
            string chel = comboBox2.Text;
            OleDbConnection con = new OleDbConnection(ConnectionString);

            string UserName = textBox1.Text, UserSurname = textBox2.Text;

            using (con)
            {
                using (OleDbCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = string.Format("INSERT INTO Registrations ([Имя], [Фамилия], [Местоположение], [Цель], [Дата], [Время]) Values(@UserName, @UserSurname, @mesto, @chel, @data, @time) ");
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@UserSurname", UserSurname);
                    cmd.Parameters.AddWithValue("@mesto", mesto);
                    cmd.Parameters.AddWithValue("@chel", chel);
                    cmd.Parameters.AddWithValue("@data", data);
                    cmd.Parameters.AddWithValue("@time", time);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            new Thread(() => { Application.Run(new Menu()); }).Start();
            this.Close();
        }
    }
}
