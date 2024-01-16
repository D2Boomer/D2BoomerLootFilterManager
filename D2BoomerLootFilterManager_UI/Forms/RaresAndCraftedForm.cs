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
    public partial class RaresAndCraftedForm : Form
    {
        private FormMainMenu formMainMenu = null;

        public RaresAndCraftedForm()
        {
            InitializeComponent();
        }

        public RaresAndCraftedForm(Form callingForm)
        {
            formMainMenu = callingForm as FormMainMenu;
            InitializeComponent();
        }
    }
}
