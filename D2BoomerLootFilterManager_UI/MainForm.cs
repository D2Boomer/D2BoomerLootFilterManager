using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace D2BoomerLootFilterManager_UI
{
    public partial class FormMainMenu : Form
    {
        // Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private int currentColorIndex = -1;
        private Form activeForm;

        // Constructor
        public FormMainMenu()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        // Methods
        private Color SelectThemeColor()
        {
            if (ConfigurationManager.AppSettings["useTheme"] == "true")
            {
                var max = ThemeColor.ColorList.Count - 1;

                if (currentColorIndex == max)
                    currentColorIndex = 0;
                else
                    currentColorIndex++;

                string color = ThemeColor.ColorList[currentColorIndex];
                return ColorTranslator.FromHtml(color);
            }

            return Color.Gainsboro;
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender) 
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm!=null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelLowerSection.Controls.Add(childForm);
            this.panelLowerSection.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            labelTitle.Text = childForm.Text;
        }

        private void buttonEquipment_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.EquipmentForm(this), sender);
        }

        private void buttonInventory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.InventoryForm(this), sender);
        }

        private void buttonRaresAndCrafted_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.RaresAndCraftedForm(this), sender);
        }

        private void buttonMisc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.MiscForm(this), sender);
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.SettingsForm(this), sender);
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
           else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void labelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
