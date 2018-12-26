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
    public partial class connectForm : Form
    {
        public connectForm()
        {
            InitializeComponent();
        }

        private void connectForm_Load(object sender, EventArgs e)
        {
            listBox2.Items.Add(Form1.username);
        }
    }
}
