
namespace Praktijk_Opdracht.View
{
    partial class FrmResultatenOverview
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
            this.lvResultaat = new System.Windows.Forms.ListView();
            this.btnWijzigen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvResultaat
            // 
            this.lvResultaat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvResultaat.HideSelection = false;
            this.lvResultaat.Location = new System.Drawing.Point(12, 45);
            this.lvResultaat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvResultaat.Name = "lvResultaat";
            this.lvResultaat.Size = new System.Drawing.Size(662, 319);
            this.lvResultaat.TabIndex = 9;
            this.lvResultaat.UseCompatibleStateImageBehavior = false;
            // 
            // btnWijzigen
            // 
            this.btnWijzigen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWijzigen.Location = new System.Drawing.Point(476, 385);
            this.btnWijzigen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWijzigen.Name = "btnWijzigen";
            this.btnWijzigen.Size = new System.Drawing.Size(198, 56);
            this.btnWijzigen.TabIndex = 7;
            this.btnWijzigen.Text = "Wijzigen";
            this.btnWijzigen.UseVisualStyleBackColor = true;
            this.btnWijzigen.Click += new System.EventHandler(this.btnWijzigen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "Resultaten:";
            // 
            // FrmResultatenOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 454);
            this.Controls.Add(this.lvResultaat);
            this.Controls.Add(this.btnWijzigen);
            this.Controls.Add(this.label2);
            this.Name = "FrmResultatenOverview";
            this.Text = "FrmResultaten";
            this.Load += new System.EventHandler(this.FrmResultaten_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvResultaat;
        private System.Windows.Forms.Button btnWijzigen;
        private System.Windows.Forms.Label label2;
    }
}