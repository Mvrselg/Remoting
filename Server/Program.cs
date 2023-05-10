using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Lifetime;
using System.Collections;
using System.Runtime.Serialization.Formatters;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                //Регистрация tcp канала через код
                RegisterTCP();
                //RemotingConfiguration.Configure("D:\\visual studio\\Курсач по ТП\\ClassLibrary1\\Server\\App.config", false);
                LifetimeServices.LeaseTime = TimeSpan.FromMinutes(0.2);
                LifetimeServices.RenewOnCallTime = TimeSpan.FromMinutes(0);
                System.Console.WriteLine("Сервер запущен. Нажмите 'Enter' для выхода");
                Console.ReadLine();//Удерживаем сервер в рабочем состоянии
            }
            catch
            {
                Console.WriteLine("Упс, что-то пошло не так1");
                Console.ReadLine();//Удерживаем сервер в рабочем состоянии
            }
        }
        static void RegisterTCP()
        {

            try
            {
                TcpServerChannel channel = new TcpServerChannel(8086);
                ChannelServices.RegisterChannel(channel, false);
                RemotingConfiguration.ApplicationName = "Class1";
                RemotingConfiguration.RegisterActivatedServiceType(typeof(Class1));
                //IDictionary properties = new Hashtable();
                //properties.Add("port", "8086");
                //properties.Add("secure", true);
                //properties.Add("protectionLevel", "EncryptAndSign");
                //properties.Add("impersonate", false);
                //SoapServerFormatterSinkProvider srvPrvd_1 = new SoapServerFormatterSinkProvider();
                ////устанавливаем полный уровень десериализации
                //srvPrvd_1.TypeFilterLevel = TypeFilterLevel.Full;

                //SoapClientFormatterSinkProvider clntPrvd_1 = new SoapClientFormatterSinkProvider();

                //TcpChannel tcpChannel = new TcpChannel( clntPrvd_1, srvPrvd_1);
                //ChannelServices.RegisterChannel(tcpChannel, true);


                RemotingConfiguration.RegisterWellKnownServiceType(typeof(Class1), "ClassLibrary1", WellKnownObjectMode.Singleton);
            }
            catch (Exception e)
            {
                //Console.WriteLine("Сервер запущен. Нажмите 'Enter' для выхода");
                Console.WriteLine("Упс, что-то пошло не так2");
                Console.ReadLine();//Удерживаем сервер в рабочем состоянии
            }
        }
    }
}
