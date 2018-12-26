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

namespace WanganSuperhighway
{
    public partial class createServerForm : Form
    {
        bool gameStart = false;
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
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.Verb = "runas";
            proc.Start();
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
                    var connectionString = "mongodb://wgsh2:wmmt5dx+@ds263590.mlab.com:63590/wangansuperhighway";
                    var client = new MongoClient(connectionString);

                    IMongoDatabase db = client.GetDatabase("wangansuperhighway");
                    IMongoCollection<BsonDocument> collection = db.GetCollection<BsonDocument>("servers");

                    var document = new BsonDocument
                    {
                    {"name", BsonValue.Create(textBoxGameName.Text)},
                    {"players", new BsonString("1")},
                    {"networkID", new BsonString(textBoxNetworkId.Text)}
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
            listBox1.Items.Add(Form1.username);            
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (gameStart == true)
            {
                var connectionString = "mongodb://wgsh2:wmmt5dx+@ds263590.mlab.com:63590/wangansuperhighway";
                var client = new MongoClient(connectionString);

                IMongoDatabase db = client.GetDatabase("wangansuperhighway");
                IMongoCollection<BsonDocument> collection = db.GetCollection<BsonDocument>("servers");


                var filter = Builders<BsonDocument>.Filter.Eq("networkID", textBoxNetworkId.Text);
                var result = collection.DeleteOne(filter);


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
    }
}
