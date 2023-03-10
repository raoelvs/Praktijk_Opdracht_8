
namespace Praktijk_Opdracht.View
{
    partial class FrmWedstrijdUpdate
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
            this.dtpStarttime = new System.Windows.Forms.DateTimePicker();
            this.cmbRound = new System.Windows.Forms.ComboBox();
            this.cmbWedstrijd = new System.Windows.Forms.ComboBox();
            this.cmbPlayer1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbReferee = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpEndtime = new System.Windows.Forms.DateTimePicker();
            this.cmbPlayer2 = new System.Windows.Forms.ComboBox();
            this.btnOpslaan = new System.Windows.Forms.Button();
            this.btnAnnuleren = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpStarttime
            // 
            this.dtpStarttime.CustomFormat = "dd-MM-yyyy HH:mm";
            this.dtpStarttime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStarttime.Location = new System.Drawing.Point(165, 177);
            this.dtpStarttime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpStarttime.Name = "dtpStarttime";
            this.dtpStarttime.Size = new System.Drawing.Size(286, 27);
            this.dtpStarttime.TabIndex = 53;
            // 
            // cmbRound
            // 
            this.cmbRound.BackColor = System.Drawing.Color.DimGray;
            this.cmbRound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRound.ForeColor = System.Drawing.Color.Orange;
            this.cmbRound.FormattingEnabled = true;
            this.cmbRound.Location = new System.Drawing.Point(165, 77);
            this.cmbRound.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbRound.Name = "cmbRound";
            this.cmbRound.Size = new System.Drawing.Size(286, 28);
            this.cmbRound.TabIndex = 52;
            this.cmbRound.SelectedIndexChanged += new System.EventHandler(this.cmbRound_SelectedIndexChanged);
            // 
            // cmbWedstrijd
            // 
            this.cmbWedstrijd.BackColor = System.Drawing.Color.DimGray;
            this.cmbWedstrijd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbWedstrijd.ForeColor = System.Drawing.Color.Orange;
            this.cmbWedstrijd.FormattingEnabled = true;
            this.cmbWedstrijd.Location = new System.Drawing.Point(165, 129);
            this.cmbWedstrijd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbWedstrijd.Name = "cmbWedstrijd";
            this.cmbWedstrijd.Size = new System.Drawing.Size(286, 28);
            this.cmbWedstrijd.TabIndex = 51;
            // 
            // cmbPlayer1
            // 
            this.cmbPlayer1.BackColor = System.Drawing.Color.DimGray;
            this.cmbPlayer1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPlayer1.ForeColor = System.Drawing.Color.Orange;
            this.cmbPlayer1.FormattingEnabled = true;
            this.cmbPlayer1.Location = new System.Drawing.Point(165, 283);
            this.cmbPlayer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbPlayer1.Name = "cmbPlayer1";
            this.cmbPlayer1.Size = new System.Drawing.Size(286, 28);
            this.cmbPlayer1.TabIndex = 50;
            this.cmbPlayer1.SelectedIndexChanged += new System.EventHandler(this.cmbPlayer1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(29, 397);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 49;
            this.label1.Text = "Scheidsrechter";
            // 
            // cmbReferee
            // 
            this.cmbReferee.BackColor = System.Drawing.Color.DimGray;
            this.cmbReferee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbReferee.ForeColor = System.Drawing.Color.Orange;
            this.cmbReferee.FormattingEnabled = true;
            this.cmbReferee.Location = new System.Drawing.Point(165, 394);
            this.cmbReferee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbReferee.Name = "cmbReferee";
            this.cmbReferee.Size = new System.Drawing.Size(286, 28);
            this.cmbReferee.TabIndex = 48;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Orange;
            this.label8.Location = new System.Drawing.Point(29, 341);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 20);
            this.label8.TabIndex = 47;
            this.label8.Text = "Uit Speler";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Orange;
            this.label7.Location = new System.Drawing.Point(29, 286);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 20);
            this.label7.TabIndex = 46;
            this.label7.Text = "Thuis Speler";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Orange;
            this.label6.Location = new System.Drawing.Point(29, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 45;
            this.label6.Text = "Eindtijd";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Orange;
            this.label5.Location = new System.Drawing.Point(29, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 44;
            this.label5.Text = "Starttijd";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(29, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 43;
            this.label4.Text = "Wedstrijd";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(29, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 42;
            this.label3.Text = "Ronde";
            // 
            // dtpEndtime
            // 
            this.dtpEndtime.CustomFormat = "dd-MM-yyyy HH:mm";
            this.dtpEndtime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndtime.Location = new System.Drawing.Point(165, 231);
            this.dtpEndtime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpEndtime.Name = "dtpEndtime";
            this.dtpEndtime.Size = new System.Drawing.Size(286, 27);
            this.dtpEndtime.TabIndex = 41;
            // 
            // cmbPlayer2
            // 
            this.cmbPlayer2.BackColor = System.Drawing.Color.DimGray;
            this.cmbPlayer2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPlayer2.ForeColor = System.Drawing.Color.Orange;
            this.cmbPlayer2.FormattingEnabled = true;
            this.cmbPlayer2.Location = new System.Drawing.Point(165, 338);
            this.cmbPlayer2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbPlayer2.Name = "cmbPlayer2";
            this.cmbPlayer2.Size = new System.Drawing.Size(286, 28);
            this.cmbPlayer2.TabIndex = 40;
            // 
            // btnOpslaan
            // 
            this.btnOpslaan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpslaan.BackColor = System.Drawing.Color.Silver;
            this.btnOpslaan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpslaan.Location = new System.Drawing.Point(300, 462);
            this.btnOpslaan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOpslaan.Name = "btnOpslaan";
            this.btnOpslaan.Size = new System.Drawing.Size(198, 56);
            this.btnOpslaan.TabIndex = 39;
            this.btnOpslaan.Text = "Opslaan";
            this.btnOpslaan.UseVisualStyleBackColor = false;
            this.btnOpslaan.Click += new System.EventHandler(this.btnOpslaan_Click);
            // 
            // btnAnnuleren
            // 
            this.btnAnnuleren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAnnuleren.BackColor = System.Drawing.Color.Silver;
            this.btnAnnuleren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuleren.Location = new System.Drawing.Point(12, 462);
            this.btnAnnuleren.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAnnuleren.Name = "btnAnnuleren";
            this.btnAnnuleren.Size = new System.Drawing.Size(198, 56);
            this.btnAnnuleren.TabIndex = 38;
            this.btnAnnuleren.Text = "Annuleren";
            this.btnAnnuleren.UseVisualStyleBackColor = false;
            this.btnAnnuleren.Click += new System.EventHandler(this.btnAnnuleren_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 32);
            this.label2.TabIndex = 37;
            this.label2.Text = "Wijzigen Wedstrijd:";
            // 
            // FrmWedstrijdUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(510, 531);
            this.Controls.Add(this.dtpStarttime);
            this.Controls.Add(this.cmbRound);
            this.Controls.Add(this.cmbWedstrijd);
            this.Controls.Add(this.cmbPlayer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbReferee);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpEndtime);
            this.Controls.Add(this.cmbPlayer2);
            this.Controls.Add(this.btnOpslaan);
            this.Controls.Add(this.btnAnnuleren);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "FrmWedstrijdUpdate";
            this.Text = "FrmWedstrijdUpdate";
            this.Load += new System.EventHandler(this.FrmWedstrijdUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpStarttime;
        private System.Windows.Forms.ComboBox cmbRound;
        private System.Windows.Forms.ComboBox cmbWedstrijd;
        private System.Windows.Forms.ComboBox cmbPlayer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbReferee;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpEndtime;
        private System.Windows.Forms.ComboBox cmbPlayer2;
        private System.Windows.Forms.Button btnOpslaan;
        private System.Windows.Forms.Button btnAnnuleren;
        private System.Windows.Forms.Label label2;
    }
}