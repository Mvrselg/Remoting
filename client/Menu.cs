using System;
using System.Collections;
using System.Windows.Forms;
using ClassLibrary1;
using System.Threading;
using System.Runtime.Remoting.Lifetime;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Remoting;

namespace client
{
    public partial class Menu : Form
    {
        Connection ClassLib = new Class1();
        static public Class1 ClassLib1;
        public Menu()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string loginAdmin = "admin", passwordAdmin = "admin";
            if (Class1.IsUserExists(textBox1.Text, textBox2.Text))
            {
                if (textBox1.Text == loginAdmin && textBox2.Text == passwordAdmin)
                {
                    new Thread(() => { Application.Run(new Admin()); }).Start();
                    this.Close();
                }
                else
                {
                    new Thread(() => { Application.Run(new User()); }).Start();
                    this.Close();
                }
            }
            else
            {
                textBox1.Clear();
                textBox2.Clear();
                MessageBox.Show("Неверно введен логин или пароль");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Thread(() => { Application.Run(new Registr()); }).Start();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                IDictionary properties = new Hashtable();
                properties.Add("port", "0");
                properties.Add("secure", true);
                properties.Add("protectionLevel", "EncryptAndSign");
                properties.Add("TokenImpersonationLevel", "Impersonation");
                SoapServerFormatterSinkProvider srvPrvd_1 = new SoapServerFormatterSinkProvider();
                srvPrvd_1.TypeFilterLevel = TypeFilterLevel.Full;
                SoapClientFormatterSinkProvider clntPrvd_1 = new SoapClientFormatterSinkProvider();

                TcpChannel tcpChannel = new TcpChannel(properties, clntPrvd_1, srvPrvd_1);
                //ChannelServices.RegisterChannel(tcpChannel, true);

                //ClassLib1 = (Class1)RemotingServices.Connect(typeof(Class1), "tcp://localhost:8086/ClassLib");
                //ClassLib.Connecting();
                MessageBox.Show("TCP канал создан");
                button3.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс, что-то пошло не таR:\n " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure("D:\\visual studio\\Курсач по ТП\\ClassLibrary1\\client\\App.config", false);
            MessageBox.Show("HTTP канал создан");
            ClassLib.Connecting();
            button4.Visible = false;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            ILease lease = ClassLib.MyInitializeLifetimeService();
            MyClientSponsor myClientSponsor = new MyClientSponsor();
            lease.Register(myClientSponsor);
        }
        private void Sponsors()
        {
            ILease lease = (ILease)ClassLib.MyInitializeLifetimeService();
            MyClientSponsor sponsor = new MyClientSponsor();
            lease.Register(sponsor);
        }
        public class MyClientSponsor : MarshalByRefObject, ISponsor
        {
            public MyClientSponsor()
            {
                //Console.WriteLine("\nСпонсор создан ");
            }
            public TimeSpan Renewal(ILease lease)
            {
                return TimeSpan.FromSeconds(20);
            }
        }

        private void buttonSponser_Click(object sender, EventArgs e)
        {
            Sponsors();
            labelSponser.Text = "Спонсирование сработало";
        }
    }
}
