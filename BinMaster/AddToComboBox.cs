using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinMaster
{
    class AddToComboBox
    {
        /// <summary>
        /// Updates a ComboBox with the selection from the file browser if the user clicks on OK.
        /// </summary>
        /// <param name="fileDlg">File dialog box to show.</param>
        /// <param name="cB">ComboBox to update.</param>
        /// <returns></returns>
        public static void UpdateItems(OpenFileDialog fileDlg, ComboBox cB)
        {
            DialogResult dR = fileDlg.ShowDialog();
            if (dR == DialogResult.OK)
            {
                string newItem = fileDlg.FileName;
                if (cB.Items.Contains(newItem))
                {
                    cB.Items.Remove(newItem);
                }
                cB.Items.Insert(0, newItem);
                cB.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Updates a ComboBox with the selection from the folder browser if the user clicks on OK.
        /// </summary>
        /// <param name="folderDlg">Folder dialog box to show.</param>
        /// <param name="cB">ComboBox to update.</param>
        public static void UpdateItems(FolderBrowserDialog folderDlg, ComboBox cB)
        {
            DialogResult dR = folderDlg.ShowDialog();
            if (dR == DialogResult.OK)
            {
                string newItem = folderDlg.SelectedPath;
                if (cB.Items.Contains(newItem))
                {
                    cB.Items.Remove(newItem);
                }
                cB.Items.Insert(0, newItem);
                cB.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Adds a string to a combo box's list, or moves it to the top if already present.
        /// </summary>
        /// <param name="newItem"></param>
        /// <param name="cB"></param>
        public static void UpdateItems(string newItem, ComboBox cB)
        {
            if (newItem != "")
            {
                if (cB.Items.Contains(newItem))
                {
                    cB.Items.Remove(newItem);
                }
                cB.Items.Insert(0, newItem);
                cB.SelectedIndex = 0;
            }
        }
    }
}
