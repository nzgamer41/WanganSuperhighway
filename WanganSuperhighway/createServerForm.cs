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
using MongoDB.Driver;
using MongoDB.Bson;
using System.Net.NetworkInformation;
using System.Xml.Linq;
using System.IO;

namespace WanganSuperhighway
{
    public partial class createServerForm : Form
    {
        bool gameStart = false;
        string gameIP;
        string folder;
        public createServerForm()
        {
            InitializeComponent();
           
        }
       
        /// <summary>
        /// Executes a process as the Administrator.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="commandLine"></param>
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

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (!(textBoxNetworkId.Text.Length == 16))
            {
                MessageBox.Show("Your network ID is invalid, please re-check the ZeroTier Dashboard.");
            }
            else if (textBoxGameName.Text.Length == 0)
            {
                MessageBox.Show("You need to enter a value for the game name.");
            }
            else {
                try
                {
                    var connectionString = "mongodb://wgshuser:wangansuperhighway1@ds263590.mlab.com:63590/wangansuperhighway";
                    var client = new MongoClient(connectionString);

                    IMongoDatabase db = client.GetDatabase("wangansuperhighway");
                    IMongoCollection<BsonDocument> collection = db.GetCollection<BsonDocument>("servers");

                    var document = new BsonDocument
                    {
                    {"name", BsonValue.Create(textBoxGameName.Text)},
                    {"players", new BsonString("1")},
                    {"networkID", new BsonString(textBoxNetworkId.Text)},
                    };
                    collection.InsertOne(document);
                    
                    
                        
                    string command = "join " + textBoxNetworkId.Text;
                    ExecuteAsAdmin("C:\\Program Files (x86)\\ZeroTier\\One\\zerotier-cli.bat", command);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            textBoxNetworkId.ReadOnly = true;
            textBoxGameName.ReadOnly = true;
            buttonCreate.Visible = false;
            buttonStart.Enabled = true;
            
            gameStart = true;

            }
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (gameStart == true)
            {
                var connectionString = "mongodb://wgshuser:wangansuperhighway1@ds263590.mlab.com:63590/wangansuperhighway";
                var client = new MongoClient(connectionString);

                IMongoDatabase db = client.GetDatabase("wangansuperhighway");
                IMongoCollection<BsonDocument> collection = db.GetCollection<BsonDocument>("servers");


                var filter = Builders<BsonDocument>.Filter.Eq("networkID", textBoxNetworkId.Text);
                var result = collection.DeleteMany(filter);


                gameStart = false;
                string command = "leave " + textBoxNetworkId.Text;
                ExecuteAsAdmin("C:\\Program Files (x86)\\ZeroTier\\One\\zerotier-cli.bat", command);
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        { }

        private void buttonStart_Click(object sender, EventArgs e)
        {
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
                    el.Element("FieldValue").ReplaceNodes("1");
                }
            }
            objDoc.Save(folder + "UserProfiles\\WMMT5.xml");
            startTP(Form1.tpLocation, "--profile=WMMT5.xml");
            buttonCancel_Click(sender, e);
        }
    }
}
