namespace D2BoomerLootFilterManager_UI.UserControls
{
    partial class LootRule
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_RuleHolder = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_RuleDescription = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_RuleDelete = new System.Windows.Forms.Button();
            this.btn_RuleCopy = new System.Windows.Forms.Button();
            this.checkBox_RuleEnabled = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_RuleHolder
            // 
            this.btn_RuleHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_RuleHolder.Location = new System.Drawing.Point(14, 15);
            this.btn_RuleHolder.Name = "btn_RuleHolder";
            this.btn_RuleHolder.Size = new System.Drawing.Size(20, 18);
            this.btn_RuleHolder.TabIndex = 0;
            this.btn_RuleHolder.Text = "=";
            this.btn_RuleHolder.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_RuleHolder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(48, 49);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label_RuleDescription);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(48, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(397, 49);
            this.panel2.TabIndex = 2;
            // 
            // label_RuleDescription
            // 
            this.label_RuleDescription.AutoSize = true;
            this.label_RuleDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_RuleDescription.Location = new System.Drawing.Point(6, 4);
            this.label_RuleDescription.Name = "label_RuleDescription";
            this.label_RuleDescription.Size = new System.Drawing.Size(44, 16);
            this.label_RuleDescription.TabIndex = 0;
            this.label_RuleDescription.Text = "label1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_RuleDelete);
            this.panel3.Controls.Add(this.btn_RuleCopy);
            this.panel3.Controls.Add(this.checkBox_RuleEnabled);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(445, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(107, 49);
            this.panel3.TabIndex = 3;
            // 
            // btn_RuleDelete
            // 
            this.btn_RuleDelete.Location = new System.Drawing.Point(54, 22);
            this.btn_RuleDelete.Name = "btn_RuleDelete";
            this.btn_RuleDelete.Size = new System.Drawing.Size(47, 23);
            this.btn_RuleDelete.TabIndex = 2;
            this.btn_RuleDelete.Text = "Delete";
            this.btn_RuleDelete.UseVisualStyleBackColor = true;
            this.btn_RuleDelete.Click += new System.EventHandler(this.btn_RuleDelete_Click);
            // 
            // btn_RuleCopy
            // 
            this.btn_RuleCopy.Location = new System.Drawing.Point(6, 22);
            this.btn_RuleCopy.Name = "btn_RuleCopy";
            this.btn_RuleCopy.Size = new System.Drawing.Size(47, 23);
            this.btn_RuleCopy.TabIndex = 1;
            this.btn_RuleCopy.Text = "Copy";
            this.btn_RuleCopy.UseVisualStyleBackColor = true;
            this.btn_RuleCopy.Click += new System.EventHandler(this.btn_RuleCopy_Click);
            // 
            // checkBox_RuleEnabled
            // 
            this.checkBox_RuleEnabled.AutoSize = true;
            this.checkBox_RuleEnabled.Location = new System.Drawing.Point(22, 3);
            this.checkBox_RuleEnabled.Name = "checkBox_RuleEnabled";
            this.checkBox_RuleEnabled.Size = new System.Drawing.Size(65, 17);
            this.checkBox_RuleEnabled.TabIndex = 0;
            this.checkBox_RuleEnabled.Text = "Enabled";
            this.checkBox_RuleEnabled.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter Tier Level:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(114, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(37, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(157, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Style:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(203, 23);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(188, 21);
            this.comboBox2.TabIndex = 4;
            // 
            // LootRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "LootRule";
            this.Size = new System.Drawing.Size(550, 49);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_RuleHolder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_RuleCopy;
        private System.Windows.Forms.CheckBox checkBox_RuleEnabled;
        private System.Windows.Forms.Button btn_RuleDelete;
        private System.Windows.Forms.Label label_RuleDescription;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
    }
}
