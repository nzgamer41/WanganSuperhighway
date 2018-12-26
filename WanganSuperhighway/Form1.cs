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

namespace WanganSuperhighway
{
    public partial class Form1 : Form
    {
        public static string username;
        public static string tpLocation;
        public static StreamReader reader;
        public static StreamWriter writer;
        public Form1()
        {
            InitializeComponent();
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
            
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            settingsForm sForm = new settingsForm();
            sForm.Show();
        }
    }
}
