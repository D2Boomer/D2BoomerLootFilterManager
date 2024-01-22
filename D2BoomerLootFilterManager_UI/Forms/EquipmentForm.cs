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
using D2BoomerLootFilterManager_UI.UserControls;
using Lib_D2Data;
using D2BoomerLootFilterManager_UI.Forms.LoadFormMethods;

namespace D2BoomerLootFilterManager_UI.Forms
{
    public partial class EquipmentForm : Form
    {
        private FormMainMenu formMainMenu = null;

        public EquipmentForm()
        {
            InitializeComponent();
        }

        public EquipmentForm(Form callingForm)
        {
            formMainMenu = callingForm as FormMainMenu;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Theme Setting: " + ConfigurationManager.AppSettings["useTheme"]);
        }

        private void EquipmentForm_Load(object sender, EventArgs e)
        {
            EquipmentForm_Load _load = new EquipmentForm_Load();
            tv_UniqueItems.Nodes.Insert(0, _load.tv_AllItems);
            tv_UniqueItems.Refresh();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LootRule lootRule = new LootRule();
            lootRule.SetRuleDescription("Example Rule Txt");

            lootRule.AddLootRule(lootRule);

            formMainMenu.flowPanel_Rules.Controls.Add(lootRule);
        }
    }
}
