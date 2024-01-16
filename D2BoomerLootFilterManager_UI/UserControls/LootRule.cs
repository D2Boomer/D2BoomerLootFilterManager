using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D2BoomerLootFilterManager_UI.UserControls
{
    public partial class LootRule : UserControl
    {
        public static List<LootRule> lootRules = new List<LootRule>();

        public LootRule()
        {
            InitializeComponent();
        }

        public void AddLootRule(LootRule lootRule)
        {
            lootRules.Add(lootRule);
        }

        public bool GetIsEnabled()
        {
            return checkBox_RuleEnabled.Checked;
        }

        public void SetIsEnabled(bool isEnabled)
        {
            checkBox_RuleEnabled.Checked = isEnabled;
        }

        public string GetRuleDescription ()
        {
            return label_RuleDescription.Text;
        }

        public void SetRuleDescription(string ruleDescription)
        {
            label_RuleDescription.Text = ruleDescription;
        }

        public Button GetRuleHolder()
        {
            return btn_RuleHolder;
        }

        private void btn_RuleCopy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented");
        }

        private void btn_RuleDelete_Click(object sender, EventArgs e)
        {
            lootRules.Remove(this);
            this.Parent.Controls.Remove(this);
        }
    }
}
