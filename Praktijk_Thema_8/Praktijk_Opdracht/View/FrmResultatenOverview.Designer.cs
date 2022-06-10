
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnScheidsrechter = new System.Windows.Forms.Button();
            this.btnSluiten = new System.Windows.Forms.Button();
            this.btnScholen = new System.Windows.Forms.Button();
            this.btnSpelers = new System.Windows.Forms.Button();
            this.btnResultaten = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvResultaten = new System.Windows.Forms.ListView();
            this.btnVerwijderen = new System.Windows.Forms.Button();
            this.btnWijzigen = new System.Windows.Forms.Button();
            this.btnToevoegen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(17, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "De vlugge handjes";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnScheidsrechter);
            this.groupBox1.Controls.Add(this.btnSluiten);
            this.groupBox1.Controls.Add(this.btnScholen);
            this.groupBox1.Controls.Add(this.btnSpelers);
            this.groupBox1.Controls.Add(this.btnResultaten);
            this.groupBox1.Controls.Add(this.btnHome);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, -20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(229, 640);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btnScheidsrechter
            // 
            this.btnScheidsrechter.Location = new System.Drawing.Point(0, 297);
            this.btnScheidsrechter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnScheidsrechter.Name = "btnScheidsrechter";
            this.btnScheidsrechter.Size = new System.Drawing.Size(229, 56);
            this.btnScheidsrechter.TabIndex = 6;
            this.btnScheidsrechter.Text = "Scheidsrechters";
            this.btnScheidsrechter.UseVisualStyleBackColor = true;
            // 
            // btnSluiten
            // 
            this.btnSluiten.Location = new System.Drawing.Point(0, 556);
            this.btnSluiten.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSluiten.Name = "btnSluiten";
            this.btnSluiten.Size = new System.Drawing.Size(229, 56);
            this.btnSluiten.TabIndex = 5;
            this.btnSluiten.Text = "Sluiten";
            this.btnSluiten.UseVisualStyleBackColor = true;
            // 
            // btnScholen
            // 
            this.btnScholen.Location = new System.Drawing.Point(0, 245);
            this.btnScholen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnScholen.Name = "btnScholen";
            this.btnScholen.Size = new System.Drawing.Size(229, 56);
            this.btnScholen.TabIndex = 4;
            this.btnScholen.Text = "Scholen";
            this.btnScholen.UseVisualStyleBackColor = true;
            // 
            // btnSpelers
            // 
            this.btnSpelers.Location = new System.Drawing.Point(0, 193);
            this.btnSpelers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSpelers.Name = "btnSpelers";
            this.btnSpelers.Size = new System.Drawing.Size(229, 56);
            this.btnSpelers.TabIndex = 3;
            this.btnSpelers.Text = "Spelers";
            this.btnSpelers.UseVisualStyleBackColor = true;
            // 
            // btnResultaten
            // 
            this.btnResultaten.Location = new System.Drawing.Point(0, 143);
            this.btnResultaten.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnResultaten.Name = "btnResultaten";
            this.btnResultaten.Size = new System.Drawing.Size(229, 56);
            this.btnResultaten.TabIndex = 2;
            this.btnResultaten.Text = "Resultaten";
            this.btnResultaten.UseVisualStyleBackColor = true;
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(0, 91);
            this.btnHome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(229, 56);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lvResultaten);
            this.groupBox2.Controls.Add(this.btnVerwijderen);
            this.groupBox2.Controls.Add(this.btnWijzigen);
            this.groupBox2.Controls.Add(this.btnToevoegen);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(253, -20);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(686, 640);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // lvResultaten
            // 
            this.lvResultaten.HideSelection = false;
            this.lvResultaten.Location = new System.Drawing.Point(18, 60);
            this.lvResultaten.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvResultaten.Name = "lvResultaten";
            this.lvResultaten.Size = new System.Drawing.Size(653, 455);
            this.lvResultaten.TabIndex = 4;
            this.lvResultaten.UseCompatibleStateImageBehavior = false;
            // 
            // btnVerwijderen
            // 
            this.btnVerwijderen.Location = new System.Drawing.Point(474, 539);
            this.btnVerwijderen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnVerwijderen.Name = "btnVerwijderen";
            this.btnVerwijderen.Size = new System.Drawing.Size(198, 56);
            this.btnVerwijderen.TabIndex = 3;
            this.btnVerwijderen.Text = "Verwijderen";
            this.btnVerwijderen.UseVisualStyleBackColor = true;
            // 
            // btnWijzigen
            // 
            this.btnWijzigen.Location = new System.Drawing.Point(247, 539);
            this.btnWijzigen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWijzigen.Name = "btnWijzigen";
            this.btnWijzigen.Size = new System.Drawing.Size(198, 56);
            this.btnWijzigen.TabIndex = 2;
            this.btnWijzigen.Text = "Wijzigen";
            this.btnWijzigen.UseVisualStyleBackColor = true;
            // 
            // btnToevoegen
            // 
            this.btnToevoegen.Location = new System.Drawing.Point(18, 539);
            this.btnToevoegen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnToevoegen.Name = "btnToevoegen";
            this.btnToevoegen.Size = new System.Drawing.Size(198, 56);
            this.btnToevoegen.TabIndex = 1;
            this.btnToevoegen.Text = "Toevoegen";
            this.btnToevoegen.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(18, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Resultaten:";
            // 
            // FrmResultaten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 600);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmResultaten";
            this.Text = "FrmResultaten";
            this.Load += new System.EventHandler(this.FrmResultaten_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnScheidsrechter;
        private System.Windows.Forms.Button btnSluiten;
        private System.Windows.Forms.Button btnScholen;
        private System.Windows.Forms.Button btnSpelers;
        private System.Windows.Forms.Button btnResultaten;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvResultaten;
        private System.Windows.Forms.Button btnVerwijderen;
        private System.Windows.Forms.Button btnWijzigen;
        private System.Windows.Forms.Button btnToevoegen;
        private System.Windows.Forms.Label label2;
    }
}