using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MongoDB.Driver;
using MongoDB.Bson;

namespace WanganSuperhighway
{
    public partial class Form1 : Form
    {
        List<gameInstance> serverList = new List<gameInstance>();
        public static string username;
        public static string tpLocation;
        public static string selName;
        public static string selId;
        public static StreamReader reader;
        public static StreamWriter writer;

        public Form1()
        {
            InitializeComponent();
            listBoxServerBrowser.Items.Add("Game Name:".PadRight(20) + "# of players:".PadRight(16) + "Network ID".PadRight(26));
            try
            {
                if (File.Exists("config.txt"))
                {
                    using (reader = new StreamReader("config.txt"))
                    {
                        List<string> config = new List<string>();
                        while (!reader.EndOfStream)
                        {
                            string line = "";
                            line = reader.ReadLine();
                            config.Add(line);
                        }
                        if (config.Count < 2)
                        {
                            MessageBox.Show("Settings are invalid, resetting file");
                            reader.Close();
                            File.Create("config.txt").Dispose();
                            MessageBox.Show("This appears to be the first time you've launched this program. Please click settings and configure the app.");
                        }
                        else
                        {
                            tpLocation = config[0];
                            username = config[1];
                        }
                        reader.Close();
                    }
                }
                else
                {
                    File.Create("config.txt").Dispose();
                    MessageBox.Show("This appears to be the first time you've launched this program. Please click settings and configure the app.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            createServerForm cForm = new createServerForm();
            cForm.ShowDialog();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            int currentPlayers = int.Parse(serverList[listBoxServerBrowser.SelectedIndex - 1].Players);
            currentPlayers++;
            var connectionString = "mongodb://wgsh2:wmmt5dx+@ds263590.mlab.com:63590/wangansuperhighway";
            var client = new MongoClient(connectionString);

            IMongoDatabase db = client.GetDatabase("wangansuperhighway");
            IMongoCollection<BsonDocument> collection = db.GetCollection<BsonDocument>("servers");


            var filter = Builders<BsonDocument>.Filter.Eq("networkID", selId);
            var update = Builders<BsonDocument>.Update.Set("players", currentPlayers.ToString());
            var result = collection.UpdateOne(filter, update);
            
            
            connectForm cForm = new connectForm();
            cForm.ShowDialog();
            currentPlayers--;
            filter = Builders<BsonDocument>.Filter.Eq("networkID", selId);
            update = Builders<BsonDocument>.Update.Set("players", currentPlayers.ToString());
            result = collection.UpdateOne(filter, update);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            settingsForm sForm = new settingsForm();
            sForm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("C:\\Program Files (x86)\\ZeroTier\\One\\zerotier-cli.bat"))
            {
                DialogResult dialogResult = MessageBox.Show("ZeroTier One is not installed! This is a required component for the multiplayer to work, do you want to install it?", "ZeroTier Check", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("https://www.zerotier.com/download.shtml");
                    Application.Exit();
                }
                if (dialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
            }

            var connectionString = "mongodb://wgsh2:wmmt5dx+@ds263590.mlab.com:63590/wangansuperhighway";
            var client = new MongoClient(connectionString);

            IMongoDatabase db = client.GetDatabase("wangansuperhighway");
            IMongoCollection<BsonDocument> collection = db.GetCollection<BsonDocument>("servers");
            var resultDoc = collection.Find(new BsonDocument()).ToList();
            foreach (var item in resultDoc)
            {
                string name = item.GetElement("name").Value.ToString();
                string players = item.GetElement("players").Value.ToString();
                string networkID = item.GetElement("networkID").Value.ToString();
                gameInstance gameServer = new gameInstance();
                gameServer.GameName = name;
                gameServer.NetworkId = networkID;
                gameServer.Players = players;
                serverList.Add(gameServer);
                listBoxServerBrowser.Items.Add(name.PadRight(20) + players.PadRight(16) + networkID.PadRight(26));
            }
        }

        private void listBoxServerBrowser_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selName = serverList[listBoxServerBrowser.SelectedIndex - 1].GameName;
                selId = serverList[listBoxServerBrowser.SelectedIndex - 1].NetworkId;
                Console.WriteLine(selName + selId);
            }
            catch
            {

            }
        }
    }
}
