using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Lifetime;


namespace client
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ChannelServices.RegisterChannel(new TcpClientChannel(), false);
            object[] attr = { new UrlAttribute("tcp://localhost:8086/Class1") };
            Class1 obj = (Class1)Activator.CreateInstance(typeof(Class1), null, attr);
            if (obj == null)
            {
                Console.WriteLine("Сервер не доступен");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
    }
}
