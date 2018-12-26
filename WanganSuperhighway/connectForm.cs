using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Xml.Linq;

namespace WanganSuperhighway
{
    public partial class connectForm : Form
    {
        public connectForm()
        {
            InitializeComponent();
        }

        string folder;
        string gameIP;

        public void ExecuteAsAdmin(string fileName, string commandLine)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.Arguments = commandLine;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.Start();
        }

        public void startTP(string fileName, string commandLine)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.Arguments = commandLine;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.StartInfo.WorkingDirectory = folder;
            proc.Start();
            proc.WaitForExit();
        }

        private void connectForm_Load(object sender, EventArgs e)
        {
            listBox2.Items.Add(Form1.username);
            textBoxGameName.Text = Form1.selName;
            textBoxNetworkId.Text = Form1.selId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string command = "join " + textBoxNetworkId.Text;
            ExecuteAsAdmin("C:\\Program Files (x86)\\ZeroTier\\One\\zerotier-cli.bat", command);

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && (ip.Address.ToString().StartsWith("192.168.191") || ip.Address.ToString().StartsWith("192.168.192") || ip.Address.ToString().StartsWith("192.168.193") || ip.Address.ToString().StartsWith("192.168.194") || ip.Address.ToString().StartsWith("192.168.195") || ip.Address.ToString().StartsWith("192.168.196")))
                        {
                            Console.WriteLine(ip.Address.ToString());
                            gameIP = ip.Address.ToString();
                        }
                    }
                }
            }
            string tpLocationn = Form1.tpLocation;
            folder = tpLocationn.Replace("TeknoParrotUi.exe", "");
            XDocument objDoc = XDocument.Load(folder + "UserProfiles\\WMMT5.xml");
            foreach (var el in objDoc.Descendants("FieldInformation"))
            {
                var command_name = el.Element("FieldName").Value;
                if (command_name.ToUpper().Equals("NETWORKADAPTERIP"))
                {
                    el.Element("FieldValue").ReplaceNodes(gameIP);
                }
                if (command_name.ToUpper().Equals("TERMINALEMULATOR"))
                {
                    el.Element("FieldValue").ReplaceNodes("0");
                }
            }
            objDoc.Save(folder + "UserProfiles\\WMMT5.xml");
            startTP(Form1.tpLocation, "--profile=WMMT5.xml");
            string command2 = "leave " + textBoxNetworkId.Text;
            ExecuteAsAdmin("C:\\Program Files (x86)\\ZeroTier\\One\\zerotier-cli.bat", command);
            this.Close();
        }
    }
}
