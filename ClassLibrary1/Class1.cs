using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Runtime.Remoting.Lifetime;


namespace ClassLibrary1
{
    public class Class1 : MarshalByRefObject, Connection
    {

        private const string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\visual studio\\Курсач по ТП(Основа)\\BankAccount\\BankAccount\\Bank.mdb";
        private OleDbConnection myConnection;
        public Class1()
        {
            Console.WriteLine("Объект Hello создан");
        }
        ~Class1()
        {
            Console.WriteLine("Объект Hello уничтожен");
        }
        public void Connecting()
        {
            myConnection = new OleDbConnection(ConnectionString);
            myConnection.Open();
        }
        public static bool IsUserExists(string name, string password)
        {
            string selectCmd = string.Format("SELECT * FROM Users WHERE Логин='{0}' AND Пароль='{1}'",
                                             name, password);
            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                con.Open();
                using (OleDbCommand cmd = new OleDbCommand(selectCmd, con))
                {
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        public ILease MyInitializeLifetimeService()
        {
            ILease lease = (ILease)base.InitializeLifetimeService();
            return lease;
        }
        //public void find_for_List(OleDbConnection con, string CommandText, string FindPar, System.Data.OleDb.OleDbType dbType, int count, string SearchColl, ref OleDbDataReader rdr)
        //{
        //    OleDbCommand cmd = new OleDbCommand(CommandText);
        //    cmd.Connection = con;

        //    // Добавляем параметр @Find
        //    cmd.Parameters.Add(
        //        new OleDbParameter(
        //        "@Find", // Имя параметра
        //        dbType, // SqlDbType значения
        //        count, // Длина(количество символов) в параметре
        //        SearchColl));  // имя поля(колонки) по которому выполняем поиск


        //    cmd.Parameters["@Find"].Value = FindPar;

        //    // Заполнение списка результатом запроса
        //    rdr = cmd.ExecuteReader();
        //}
        //public string CreateReg(string UserId, ref string UserName, ref string UserSurname)
        //{
        //    OleDbConnection con = new OleDbConnection(ConnectionString);
        //    OleDbDataReader rdr = null;
        //    con.Open();
        //    //string UserName = "", UserSurname = "", UserPhone = "";

        //    string CommandText = "SELECT ID, Имя, Фамилия, Номер телефона" +
        //                             "  FROM Users" +
        //                             " WHERE (ID LIKE @Find)";
        //    find_for_List(con, CommandText, UserId, OleDbType.Integer, 20, "ID", ref rdr);
        //    while (rdr.Read())
        //    {
        //        UserName = rdr["FirstName"].ToString();
        //        UserSurname = rdr["SecondName"].ToString();
        //        //UserPhone = rdr["PhoneNumber"].ToString();
        //    }

        //    return UserName + " " + UserSurname;
        //}
        //public void UserPage(string UserID, ref List<string> comboBox1, ref List<string> comboBox2, ref string hello)
        //{
        //    OleDbConnection con = new OleDbConnection(ConnectionString);
        //    OleDbDataReader rdr = null;
        //    con.Open();
        //    string CommandText = "SELECT *" +
        //                             "  FROM Users" +
        //                             " WHERE (Id LIKE @Find)";
        //    find_for_List(con, CommandText, UserID, OleDbType.Integer, 20, "ID", ref rdr);
        //    string UserName = "", UserSurname = "", UserPhone = "";
        //    while (rdr.Read())
        //    {
        //        UserName = rdr["FirstName"].ToString();
        //        UserSurname = rdr["SecondName"].ToString();
        //        UserPhone = rdr["PhoneNumber"].ToString();
        //    }
        //    hello = "Здравствуйте, " + UserName + " " + UserSurname + "!";
        //    rdr.Close();

        //    CommandText = "SELECT BankID, Местоположение" +
        //                            "  FROM Mesto";
        //    find_for_List(con, CommandText, UserID, OleDbType.Integer, 20, "BankID", ref rdr);
        //    string mesto = "";
        //    while (rdr.Read())
        //        comboBox1.Add(rdr["Местоположение"].ToString());
        //    rdr.Close();
        //    CommandText = "SELECT ID, Цель" +
        //                            "  FROM Uslug";
        //    //+" WHERE (UserId LIKE @Find)"
        //    find_for_List(con, CommandText, UserID, OleDbType.Integer, 20, "ID", ref rdr);
        //    string chel = "";
        //    while (rdr.Read())
        //        comboBox2.Add(rdr["Цель"].ToString());
        //    rdr.Close();
        //    con.Close();
        //}
    }
}
