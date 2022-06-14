
namespace Praktijk_Opdracht.View
{
    partial class FrmScheidsrechterUpdate
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAchternaam = new System.Windows.Forms.TextBox();
            this.txtTussenvoegsel = new System.Windows.Forms.TextBox();
            this.txtVoornaam = new System.Windows.Forms.TextBox();
            this.btnOpslaan = new System.Windows.Forms.Button();
            this.btnAnnuleren = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Achternaam *";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Tussenvoegsel";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Voornaam *";
            // 
            // txtAchternaam
            // 
            this.txtAchternaam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAchternaam.Location = new System.Drawing.Point(226, 185);
            this.txtAchternaam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAchternaam.MaxLength = 30;
            this.txtAchternaam.Name = "txtAchternaam";
            this.txtAchternaam.Size = new System.Drawing.Size(228, 27);
            this.txtAchternaam.TabIndex = 18;
            // 
            // txtTussenvoegsel
            // 
            this.txtTussenvoegsel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTussenvoegsel.Location = new System.Drawing.Point(226, 135);
            this.txtTussenvoegsel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTussenvoegsel.MaxLength = 10;
            this.txtTussenvoegsel.Name = "txtTussenvoegsel";
            this.txtTussenvoegsel.Size = new System.Drawing.Size(228, 27);
            this.txtTussenvoegsel.TabIndex = 17;
            // 
            // txtVoornaam
            // 
            this.txtVoornaam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtVoornaam.Location = new System.Drawing.Point(226, 83);
            this.txtVoornaam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVoornaam.Name = "txtVoornaam";
            this.txtVoornaam.Size = new System.Drawing.Size(228, 27);
            this.txtVoornaam.TabIndex = 16;
            // 
            // btnOpslaan
            // 
            this.btnOpslaan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpslaan.Location = new System.Drawing.Point(472, 531);
            this.btnOpslaan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOpslaan.Name = "btnOpslaan";
            this.btnOpslaan.Size = new System.Drawing.Size(198, 56);
            this.btnOpslaan.TabIndex = 15;
            this.btnOpslaan.Text = "Opslaan";
            this.btnOpslaan.UseVisualStyleBackColor = true;
            this.btnOpslaan.Click += new System.EventHandler(this.btnOpslaan_Click);
            // 
            // btnAnnuleren
            // 
            this.btnAnnuleren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAnnuleren.Location = new System.Drawing.Point(16, 531);
            this.btnAnnuleren.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAnnuleren.Name = "btnAnnuleren";
            this.btnAnnuleren.Size = new System.Drawing.Size(198, 56);
            this.btnAnnuleren.TabIndex = 14;
            this.btnAnnuleren.Text = "Annuleren";
            this.btnAnnuleren.UseVisualStyleBackColor = true;
            this.btnAnnuleren.Click += new System.EventHandler(this.btnAnnuleren_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(16, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 32);
            this.label2.TabIndex = 13;
            this.label2.Text = "Wijzigen Scheidsrechter:";
            // 
            // FrmScheidsrechterUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 600);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAchternaam);
            this.Controls.Add(this.txtTussenvoegsel);
            this.Controls.Add(this.txtVoornaam);
            this.Controls.Add(this.btnOpslaan);
            this.Controls.Add(this.btnAnnuleren);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmScheidsrechterUpdate";
            this.Text = "20";
            this.Load += new System.EventHandler(this.FrmScheidsrechterUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAchternaam;
        private System.Windows.Forms.TextBox txtTussenvoegsel;
        private System.Windows.Forms.TextBox txtVoornaam;
        private System.Windows.Forms.Button btnOpslaan;
        private System.Windows.Forms.Button btnAnnuleren;
        private System.Windows.Forms.Label label2;
    }
}