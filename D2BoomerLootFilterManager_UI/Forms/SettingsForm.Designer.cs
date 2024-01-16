namespace D2BoomerLootFilterManager_UI.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBox_UsePrideTheme = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBox_UsePrideTheme
            // 
            this.checkBox_UsePrideTheme.AutoSize = true;
            this.checkBox_UsePrideTheme.Checked = true;
            this.checkBox_UsePrideTheme.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_UsePrideTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_UsePrideTheme.Location = new System.Drawing.Point(31, 63);
            this.checkBox_UsePrideTheme.Name = "checkBox_UsePrideTheme";
            this.checkBox_UsePrideTheme.Size = new System.Drawing.Size(132, 20);
            this.checkBox_UsePrideTheme.TabIndex = 0;
            this.checkBox_UsePrideTheme.Text = "Use Pride Theme";
            this.checkBox_UsePrideTheme.UseVisualStyleBackColor = true;
            this.checkBox_UsePrideTheme.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Appearance";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_UsePrideTheme);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_UsePrideTheme;
        private System.Windows.Forms.Label label1;
    }
}