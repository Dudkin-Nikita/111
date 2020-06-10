using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Riptide
{
    public partial class SyncInForm : Form
    {
        public SyncInForm()
        {
            InitializeComponent();
        }

        private void QuitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FindBtn_Click(object sender, EventArgs e)
        {
            GameForm GF = new GameForm();
            GF.Owner = this;
            GF.Show();
            this.Hide();
        }

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            InfoForm IF = new InfoForm();
            IF.Owner = this;
            IF.ShowDialog();
        }
    }
}
