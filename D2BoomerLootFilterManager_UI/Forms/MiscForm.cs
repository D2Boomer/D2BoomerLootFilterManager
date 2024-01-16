using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D2BoomerLootFilterManager_UI.Forms
{
    public partial class MiscForm : Form
    {
        private FormMainMenu formMainMenu = null;

        public MiscForm()
        {
            InitializeComponent();
        }

        public MiscForm(Form callingForm)
        {
            formMainMenu = callingForm as FormMainMenu;
            InitializeComponent();
        }
    }
}
