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
    public partial class TexConvCmd : Form
    {
        private string texConvCmd;
        private string texConvHelpText;
        
        public TexConvCmd()
        {
            InitializeComponent();
            setHelpText();
        }

        public string TexConvCommand
        {
            get
            {
                return texConvCmd;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            setTexConvCmd();
        }

        private void setTexConvCmd()
        {
            texConvCmd = cmdField.Text;
        }

        private void setHelpText()
        {
            //Add texture program help text
            StringBuilder texConvHelp = new StringBuilder();

            texConvHelp.AppendLine("You need to specify the structure of the command used to convert an image from one format to another.");
            //texConvHelp.AppendLine("You need to use placeholder text for the .exe location, the source image and the dest image");
            texConvHelp.AppendLine();
            texConvHelp.AppendLine("Example command:");
            texConvHelp.AppendLine("C:\\Program Files\\IrfanView\\i_view64.exe c:\\file1.gif /convert=c:\\file1.png");
            texConvHelp.AppendLine();
            texConvHelp.AppendLine("What you type:");
            texConvHelp.AppendLine("[exe-path] [source-img] /convert=[dest-img]");
            texConvHelp.AppendLine();
            texConvHelp.AppendLine("You need to use the placeholders as above, and for each texture this program will insert the correct filenames.");
            //texConvHelp.AppendLine("The image extensions will be inserted automatically based on your preferences.");
            
            texConvHelpText = texConvHelp.ToString();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Help convHelp = new Help(texConvHelpText);
            convHelp.ShowDialog();
        }
    }
}
