
namespace Praktijk_Opdracht.View
{
    partial class FrmInlogOverview
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
            this.btnInloggen = new System.Windows.Forms.Button();
            this.btnSluiten = new System.Windows.Forms.Button();
            this.txtWachtwoord = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGebruikersnaam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnInloggen
            // 
            this.btnInloggen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInloggen.BackColor = System.Drawing.Color.Silver;
            this.btnInloggen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInloggen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInloggen.Location = new System.Drawing.Point(562, 401);
            this.btnInloggen.Name = "btnInloggen";
            this.btnInloggen.Size = new System.Drawing.Size(161, 63);
            this.btnInloggen.TabIndex = 13;
            this.btnInloggen.Text = "Inloggen";
            this.btnInloggen.UseVisualStyleBackColor = false;
            this.btnInloggen.Click += new System.EventHandler(this.btnInloggen_Click_1);
            // 
            // btnSluiten
            // 
            this.btnSluiten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSluiten.BackColor = System.Drawing.Color.Silver;
            this.btnSluiten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSluiten.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSluiten.Location = new System.Drawing.Point(12, 401);
            this.btnSluiten.Name = "btnSluiten";
            this.btnSluiten.Size = new System.Drawing.Size(173, 63);
            this.btnSluiten.TabIndex = 12;
            this.btnSluiten.Text = "Sluiten";
            this.btnSluiten.UseVisualStyleBackColor = false;
            this.btnSluiten.Click += new System.EventHandler(this.btnSluiten_Click);
            // 
            // txtWachtwoord
            // 
            this.txtWachtwoord.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtWachtwoord.BackColor = System.Drawing.Color.DimGray;
            this.txtWachtwoord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWachtwoord.ForeColor = System.Drawing.Color.Orange;
            this.txtWachtwoord.Location = new System.Drawing.Point(378, 245);
            this.txtWachtwoord.Name = "txtWachtwoord";
            this.txtWachtwoord.PasswordChar = '*';
            this.txtWachtwoord.Size = new System.Drawing.Size(182, 27);
            this.txtWachtwoord.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(167, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Wachtwoord:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(167, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Gebruikersnaam:";
            // 
            // txtGebruikersnaam
            // 
            this.txtGebruikersnaam.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtGebruikersnaam.BackColor = System.Drawing.Color.DimGray;
            this.txtGebruikersnaam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGebruikersnaam.ForeColor = System.Drawing.Color.Orange;
            this.txtGebruikersnaam.Location = new System.Drawing.Point(378, 166);
            this.txtGebruikersnaam.Name = "txtGebruikersnaam";
            this.txtGebruikersnaam.Size = new System.Drawing.Size(182, 27);
            this.txtGebruikersnaam.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(167, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 39);
            this.label1.TabIndex = 7;
            this.label1.Text = "Inloggen";
            // 
            // FrmInlogOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(735, 476);
            this.Controls.Add(this.btnInloggen);
            this.Controls.Add(this.btnSluiten);
            this.Controls.Add(this.txtWachtwoord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGebruikersnaam);
            this.Controls.Add(this.label1);
            this.Name = "FrmInlogOverview";
            this.Text = "FrmInlogOverview";
            this.Load += new System.EventHandler(this.FrmInlogOverview_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInloggen;
        private System.Windows.Forms.Button btnSluiten;
        private System.Windows.Forms.TextBox txtWachtwoord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGebruikersnaam;
        private System.Windows.Forms.Label label1;
    }
}