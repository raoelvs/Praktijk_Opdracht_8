
namespace Praktijk_Opdracht.View
{
    partial class FrmScheidsrechterOverview
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvScheidsrechter = new System.Windows.Forms.ListView();
            this.btnVerwijderen = new System.Windows.Forms.Button();
            this.btnWijzigen = new System.Windows.Forms.Button();
            this.btnToevoegen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lvScheidsrechter);
            this.groupBox2.Controls.Add(this.btnVerwijderen);
            this.groupBox2.Controls.Add(this.btnWijzigen);
            this.groupBox2.Controls.Add(this.btnToevoegen);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(-1, -7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 462);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // lvScheidsrechter
            // 
            this.lvScheidsrechter.HideSelection = false;
            this.lvScheidsrechter.Location = new System.Drawing.Point(16, 45);
            this.lvScheidsrechter.Name = "lvScheidsrechter";
            this.lvScheidsrechter.Size = new System.Drawing.Size(572, 342);
            this.lvScheidsrechter.TabIndex = 4;
            this.lvScheidsrechter.UseCompatibleStateImageBehavior = false;
            this.lvScheidsrechter.SelectedIndexChanged += new System.EventHandler(this.lvScheidsrechter_SelectedIndexChanged);
            // 
            // btnVerwijderen
            // 
            this.btnVerwijderen.Enabled = false;
            this.btnVerwijderen.Location = new System.Drawing.Point(415, 404);
            this.btnVerwijderen.Name = "btnVerwijderen";
            this.btnVerwijderen.Size = new System.Drawing.Size(173, 42);
            this.btnVerwijderen.TabIndex = 3;
            this.btnVerwijderen.Text = "Verwijderen";
            this.btnVerwijderen.UseVisualStyleBackColor = true;
            this.btnVerwijderen.Click += new System.EventHandler(this.btnVerwijderen_Click);
            // 
            // btnWijzigen
            // 
            this.btnWijzigen.Enabled = false;
            this.btnWijzigen.Location = new System.Drawing.Point(216, 404);
            this.btnWijzigen.Name = "btnWijzigen";
            this.btnWijzigen.Size = new System.Drawing.Size(173, 42);
            this.btnWijzigen.TabIndex = 2;
            this.btnWijzigen.Text = "Wijzigen";
            this.btnWijzigen.UseVisualStyleBackColor = true;
            this.btnWijzigen.Click += new System.EventHandler(this.btnWijzigen_Click);
            // 
            // btnToevoegen
            // 
            this.btnToevoegen.Location = new System.Drawing.Point(16, 404);
            this.btnToevoegen.Name = "btnToevoegen";
            this.btnToevoegen.Size = new System.Drawing.Size(173, 42);
            this.btnToevoegen.TabIndex = 1;
            this.btnToevoegen.Text = "Toevoegen";
            this.btnToevoegen.UseVisualStyleBackColor = true;
            this.btnToevoegen.Click += new System.EventHandler(this.btnToevoegen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(16, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Scheidsrechter:";
            // 
            // FrmScheidsrechterOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 450);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmScheidsrechterOverview";
            this.Text = "FrmScheidsrechterOverview";
            this.Load += new System.EventHandler(this.FrmScheidsrechterOverview_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvScheidsrechter;
        private System.Windows.Forms.Button btnVerwijderen;
        private System.Windows.Forms.Button btnWijzigen;
        private System.Windows.Forms.Button btnToevoegen;
        private System.Windows.Forms.Label label2;
    }
}