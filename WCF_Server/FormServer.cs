using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCF_Server
{
    public partial class FormServer : Form
    {
        MyService service = null;

        public FormServer()
        {
            InitializeComponent();

            service = new MyService();

            //with the config file
            if (RemotingConfiguration.GetRegisteredActivatedServiceTypes().Length == 0)
            {
                var appname = Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location) + ".exe.config";
                RemotingConfiguration.Configure(appname, false);
            }

            ////without the config file
            //var channel = new TcpChannel(7795);
            //ChannelServices.RegisterChannel(channel, false);

            //RemotingConfiguration.RegisterWellKnownServiceType(
            //    typeof(MyService), "MyService.soap", WellKnownObjectMode.Singleton);

            //// The following code is not needed in the example
            //foreach (WellKnownServiceTypeEntry entry in RemotingConfiguration.GetRegisteredWellKnownServiceTypes())
            //{
            //    if (entry.ObjectType == typeof(MyService))
            //    {
            //        ObjRef refObj = RemotingServices.Marshal(service, entry.ObjectUri);
            //        break;
            //    }
            //}

        }
    }
}
