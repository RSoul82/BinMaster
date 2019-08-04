using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BinMaster
{
    public partial class Help : Form
    {
        private string textToShow;

        public Help(string helpText)
        {
            InitializeComponent();
            textToShow = helpText;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TextureHelp_Load(object sender, EventArgs e)
        {
            helpText.Text = textToShow;
            helpText.Select(0, 0);
        }
    }
}
