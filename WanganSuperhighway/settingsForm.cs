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
    public partial class settingsForm : Form
    {
        public settingsForm()
        {
            InitializeComponent();
            textBoxLocation.Text = Form1.tpLocation;
            textBoxUsername.Text = Form1.username;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            Form1.username = textBoxUsername.Text;
            Form1.tpLocation = textBoxLocation.Text;
            using (StreamWriter writer = new StreamWriter("config.txt", false)) {
                writer.WriteLine(textBoxLocation.Text);
                writer.WriteLine(textBoxUsername.Text);
                writer.Close();
            }
            MessageBox.Show("Settings saved!");
            this.Close();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxLocation.Text = openFileDialog1.FileName;
            }
        }
    }
}
