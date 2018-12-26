using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WanganSuperhighway
{
    public partial class createServerForm : Form
    {
        bool gameStart = false;
        public createServerForm()
        {
            InitializeComponent();
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
                gameStart = false;
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
    }
}
