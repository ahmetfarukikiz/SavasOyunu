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
            puanLabel = new Label();
            sureLabel = new Label();
            bilgiPanel = new Label();
            savasAlaniPanel = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(puanLabel);
            panel1.Controls.Add(sureLabel);
            panel1.Controls.Add(bilgiPanel);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1488, 74);
            panel1.TabIndex = 0;
            // 
            // puanLabel
            // 
            puanLabel.Dock = DockStyle.Right;
            puanLabel.Font = new Font("Rockwell", 15F, FontStyle.Bold);
            puanLabel.ForeColor = SystemColors.ButtonFace;
            puanLabel.Location = new Point(1257, 0);
            puanLabel.Name = "puanLabel";
            puanLabel.Size = new Size(132, 74);
            puanLabel.TabIndex = 2;
            puanLabel.Text = "Puan: 0";
            puanLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // sureLabel
            // 
            sureLabel.Dock = DockStyle.Right;
            sureLabel.Font = new Font("Rockwell", 15F, FontStyle.Bold);
            sureLabel.ForeColor = SystemColors.ButtonFace;
            sureLabel.Location = new Point(1389, 0);
            sureLabel.Name = "sureLabel";
            sureLabel.Size = new Size(99, 74);
            sureLabel.TabIndex = 1;
            sureLabel.Text = "0:00";
            sureLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // bilgiPanel
            // 
            bilgiPanel.AutoSize = true;
            bilgiPanel.Font = new Font("Segoe UI", 9F);
            bilgiPanel.ForeColor = SystemColors.ButtonFace;
            bilgiPanel.Location = new Point(0, 0);
            bilgiPanel.Name = "bilgiPanel";
            bilgiPanel.Size = new Size(415, 160);
            bilgiPanel.TabIndex = 0;
            bilgiPanel.Text = "Oyuna Başlamak için Enter Tuşuna basın \r\nHareket Etmek İçin: Yön tuşları veya WASD tuşlarını kullanın\r\nAteş Etmek için Boşluk (space) tuşunu veya \"L\" tuşunu kullanın\r\n\r\n\r\n\r\n\r\n\r\n";
            // 
            // savasAlaniPanel
            // 
            savasAlaniPanel.BackColor = Color.SkyBlue;
            savasAlaniPanel.Dock = DockStyle.Fill;
            savasAlaniPanel.Location = new Point(0, 74);
            savasAlaniPanel.Name = "savasAlaniPanel";
            savasAlaniPanel.Size = new Size(1488, 822);
            savasAlaniPanel.TabIndex = 2;
            // 
            // AnaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1488, 896);
            Controls.Add(savasAlaniPanel);
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
        private Panel savasAlaniPanel;
        private Label puanLabel;
    }
}
