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
    public partial class ModelName : Form
    {
        private string ext = "";
        public ModelName()
        {
            InitializeComponent();
        }

        public string ShapeModelName
        {
            get
            {
                if(listExt.SelectedIndex == 0) ext = ".bin";
                else if(listExt.SelectedIndex == 1) ext = ".e";
                return txtModelName.Text + ext;
            }
        }

        private void ModelName_Load(object sender, EventArgs e)
        {
            listExt.SelectedIndex = 0;
        }
    }
}
