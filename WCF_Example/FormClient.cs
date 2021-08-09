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
using System.Windows.Forms.Design;
using WCF_Interface;

namespace WCF_Client
{
    public partial class FormClient : Form
    {
        IInterface _interface = null;

        public FormClient()
        {
            InitializeComponent();
        }

        private WellKnownClientTypeEntry getWCFServerRemotingClient()
        {
            WellKnownClientTypeEntry[] clients = RemotingConfiguration.GetRegisteredWellKnownClientTypes();

            foreach (WellKnownClientTypeEntry remotingClient in clients)
            {
                if (remotingClient.ObjectType == typeof(WCF_Interface.IInterface))
                {
                    return remotingClient;
                }
            }

            return null;
        }

        private void FormClient_Load(object sender, EventArgs e)
        {
            WellKnownClientTypeEntry clientEntry = getWCFServerRemotingClient();
            if (clientEntry == null)
            {
                string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var appName = Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location);

                RemotingConfiguration.Configure(Path.Combine(exePath, (appName + ".exe.config")), false);
                clientEntry = getWCFServerRemotingClient();
            }

            _interface = (IInterface)Activator.GetObject(typeof(IInterface), clientEntry.ObjectUrl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double sum = _interface.Add(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));

            textBoxSum.Text = sum.ToString();
        }
    }
}
