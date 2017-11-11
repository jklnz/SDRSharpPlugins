using System;
using System.Windows.Forms;

namespace SDRSharp.AutoStartRadio
{
    public partial class AutoStartPanel : UserControl
    {

        public AutoStartPanel()
        {
            
            InitializeComponent();

            enableCheckBox.Checked = true;
        }
        
        private void enableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
