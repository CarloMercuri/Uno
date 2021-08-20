
namespace UnoForms.Forms
{
    partial class MainGameForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_PlayingArea = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(1608, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 944);
            this.panel1.TabIndex = 1;
            // 
            // panel_PlayingArea
            // 
            this.panel_PlayingArea.Location = new System.Drawing.Point(-4, -2);
            this.panel_PlayingArea.Name = "panel_PlayingArea";
            this.panel_PlayingArea.Size = new System.Drawing.Size(1615, 944);
            this.panel_PlayingArea.TabIndex = 2;
            // 
            // MainGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1874, 936);
            this.Controls.Add(this.panel_PlayingArea);
            this.Controls.Add(this.panel1);
            this.Name = "MainGameForm";
            this.Text = "MainGameForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_PlayingArea;
    }
}