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
            ucaksavarPanel = new Panel();
            savasAlaniPanel = new Panel();
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
            panel1.Size = new Size(1488, 85);
            panel1.TabIndex = 0;
            // 
            // sureLabel
            // 
            sureLabel.Dock = DockStyle.Right;
            sureLabel.Font = new Font("Segoe UI", 10F);
            sureLabel.Location = new Point(1389, 0);
            sureLabel.Name = "sureLabel";
            sureLabel.Size = new Size(99, 85);
            sureLabel.TabIndex = 1;
            sureLabel.Text = "0:00";
            sureLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // bilgiPanel
            // 
            bilgiPanel.AutoSize = true;
            bilgiPanel.Font = new Font("Segoe UI", 11F);
            bilgiPanel.ForeColor = SystemColors.ButtonFace;
            bilgiPanel.Location = new Point(3, 0);
            bilgiPanel.Name = "bilgiPanel";
            bilgiPanel.Size = new Size(540, 175);
            bilgiPanel.TabIndex = 0;
            bilgiPanel.Text = "Oyuna Başlamak için Enter Tuşuna basın \r\nHareket Etmek İçin: Yön tuşları veya \"A\" ve \"D\" tuşlarını kullanın\r\nAteş Etmek için boşluk (space) tuşunu kullanın\r\n\r\n\r\n\r\n\r\n";
            // 
            // ucaksavarPanel
            // 
            ucaksavarPanel.BackColor = Color.SeaGreen;
            ucaksavarPanel.Dock = DockStyle.Bottom;
            ucaksavarPanel.Location = new Point(0, 826);
            ucaksavarPanel.Name = "ucaksavarPanel";
            ucaksavarPanel.Size = new Size(1488, 70);
            ucaksavarPanel.TabIndex = 1;
            // 
            // savasAlaniPanel
            // 
            savasAlaniPanel.BackColor = Color.SteelBlue;
            savasAlaniPanel.Dock = DockStyle.Fill;
            savasAlaniPanel.Location = new Point(0, 85);
            savasAlaniPanel.Name = "savasAlaniPanel";
            savasAlaniPanel.Size = new Size(1488, 741);
            savasAlaniPanel.TabIndex = 2;
            // 
            // AnaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1488, 896);
            Controls.Add(savasAlaniPanel);
            Controls.Add(ucaksavarPanel);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AnaForm";
            StartPosition = FormStartPosition.Manual;
            Text = "Savaş Oyunu";
            WindowState = FormWindowState.Maximized;
            KeyDown += AnaForm_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label sureLabel;
        private Label bilgiPanel;
        private Panel ucaksavarPanel;
        private Panel savasAlaniPanel;
    }
}
