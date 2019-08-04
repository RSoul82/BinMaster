using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinMaster
{
    public partial class EditItems : Form
    {
        public EditItems(string[] items)
        {
            InitializeComponent();
            for(int i = 0; i < items.Length; i++)
            {
                lbItems.Items.Add(items[i]);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(lbItems.SelectedIndex != -1)
            {
                lbItems.Items.RemoveAt(lbItems.SelectedIndex);
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            lbItems.Items.Clear();
        }

        public string[] RemainingItems
        {
            get
            {
                string[] items = new string[lbItems.Items.Count];
                lbItems.Items.CopyTo(items, 0);
                return items;
            }
        }

        
    }
}
