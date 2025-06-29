namespace Savas
{
    partial class AnaForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            sureLabel = new Label();
            bilgiPanel = new Label();
            panel2 = new Panel();
            savasAlani = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Silver;
            panel1.Controls.Add(sureLabel);
            panel1.Controls.Add(bilgiPanel);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1085, 85);
            panel1.TabIndex = 0;
            // 
            // sureLabel
            // 
            sureLabel.Font = new Font("Segoe UI", 10F);
            sureLabel.Location = new Point(974, 14);
            sureLabel.Name = "sureLabel";
            sureLabel.Size = new Size(99, 48);
            sureLabel.TabIndex = 1;
            sureLabel.Text = "0:00";
            sureLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // bilgiPanel
            // 
            bilgiPanel.AutoSize = true;
            bilgiPanel.Font = new Font("Segoe UI", 12F);
            bilgiPanel.ForeColor = SystemColors.ButtonFace;
            bilgiPanel.Location = new Point(12, 9);
            bilgiPanel.Name = "bilgiPanel";
            bilgiPanel.Size = new Size(362, 28);
            bilgiPanel.TabIndex = 0;
            bilgiPanel.Text = "Oyuna Başlamak için Enter Tuşuna basın \r\n";
            // 
            // panel2
            // 
            panel2.BackColor = Color.SeaGreen;
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 556);
            panel2.Name = "panel2";
            panel2.Size = new Size(1085, 70);
            panel2.TabIndex = 1;
            // 
            // savasAlani
            // 
            savasAlani.BackColor = Color.SteelBlue;
            savasAlani.Dock = DockStyle.Fill;
            savasAlani.Location = new Point(0, 85);
            savasAlani.Name = "savasAlani";
            savasAlani.Size = new Size(1085, 471);
            savasAlani.TabIndex = 2;
            // 
            // AnaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1085, 626);
            Controls.Add(savasAlani);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "AnaForm";
            Text = "Savaş Oyunu";
            KeyDown += AnaForm_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label sureLabel;
        private Label bilgiPanel;
        private Panel panel2;
        private Panel savasAlani;
    }
}
