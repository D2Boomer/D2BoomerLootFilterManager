using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace D2BoomerLootFilterManager_UI.Forms
{
    public partial class SettingsForm : Form
    {
        private FormMainMenu formMainMenu = null;

        public SettingsForm()
        {
            InitializeComponent();
        }

        public SettingsForm(Form callingForm)
        {
            formMainMenu = callingForm as FormMainMenu;
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
