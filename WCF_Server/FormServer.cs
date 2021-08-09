using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
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
            if (RemotingConfiguration.GetRegisteredActivatedServiceTypes().Length == 0)
            {
                var appname = Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location);
                RemotingConfiguration.Configure(appname + ".exe.config", false);
            }

            foreach (WellKnownServiceTypeEntry entry in RemotingConfiguration.GetRegisteredWellKnownServiceTypes())
            {
                if (entry.ObjectType == typeof(MyService))
                {
                    ObjRef refObj = RemotingServices.Marshal(service, entry.ObjectUri);
                }
            }

        }
    }
}
