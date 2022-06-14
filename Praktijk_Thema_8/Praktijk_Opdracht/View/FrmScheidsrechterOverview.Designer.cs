
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
            this.lvScheidsrechter = new System.Windows.Forms.ListView();
            this.btnVerwijderen = new System.Windows.Forms.Button();
            this.btnWijzigen = new System.Windows.Forms.Button();
            this.btnToevoegen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvScheidsrechter
            // 
            this.lvScheidsrechter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvScheidsrechter.BackColor = System.Drawing.SystemColors.Window;
            this.lvScheidsrechter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lvScheidsrechter.HideSelection = false;
            this.lvScheidsrechter.Location = new System.Drawing.Point(15, 52);
            this.lvScheidsrechter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvScheidsrechter.Name = "lvScheidsrechter";
            this.lvScheidsrechter.Size = new System.Drawing.Size(653, 455);
            this.lvScheidsrechter.TabIndex = 9;
            this.lvScheidsrechter.UseCompatibleStateImageBehavior = false;
            this.lvScheidsrechter.SelectedIndexChanged += new System.EventHandler(this.lvScheidsrechter_SelectedIndexChanged);
            // 
            // btnVerwijderen
            // 
            this.btnVerwijderen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerwijderen.BackColor = System.Drawing.Color.Silver;
            this.btnVerwijderen.Enabled = false;
            this.btnVerwijderen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerwijderen.Location = new System.Drawing.Point(471, 531);
            this.btnVerwijderen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnVerwijderen.Name = "btnVerwijderen";
            this.btnVerwijderen.Size = new System.Drawing.Size(198, 56);
            this.btnVerwijderen.TabIndex = 8;
            this.btnVerwijderen.Text = "Verwijderen";
            this.btnVerwijderen.UseVisualStyleBackColor = false;
            this.btnVerwijderen.Click += new System.EventHandler(this.btnVerwijderen_Click);
            // 
            // btnWijzigen
            // 
            this.btnWijzigen.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnWijzigen.BackColor = System.Drawing.Color.Silver;
            this.btnWijzigen.Enabled = false;
            this.btnWijzigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWijzigen.Location = new System.Drawing.Point(243, 531);
            this.btnWijzigen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWijzigen.Name = "btnWijzigen";
            this.btnWijzigen.Size = new System.Drawing.Size(198, 56);
            this.btnWijzigen.TabIndex = 7;
            this.btnWijzigen.Text = "Wijzigen";
            this.btnWijzigen.UseVisualStyleBackColor = false;
            this.btnWijzigen.Click += new System.EventHandler(this.btnWijzigen_Click);
            // 
            // btnToevoegen
            // 
            this.btnToevoegen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnToevoegen.BackColor = System.Drawing.Color.Silver;
            this.btnToevoegen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToevoegen.Location = new System.Drawing.Point(15, 531);
            this.btnToevoegen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnToevoegen.Name = "btnToevoegen";
            this.btnToevoegen.Size = new System.Drawing.Size(198, 56);
            this.btnToevoegen.TabIndex = 6;
            this.btnToevoegen.Text = "Toevoegen";
            this.btnToevoegen.UseVisualStyleBackColor = false;
            this.btnToevoegen.Click += new System.EventHandler(this.btnToevoegen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "Scheidsrechter:";
            // 
            // FrmScheidsrechterOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(685, 600);
            this.Controls.Add(this.lvScheidsrechter);
            this.Controls.Add(this.btnVerwijderen);
            this.Controls.Add(this.btnWijzigen);
            this.Controls.Add(this.btnToevoegen);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmScheidsrechterOverview";
            this.Text = "FrmScheidsrechterOverview";
            this.Load += new System.EventHandler(this.FrmScheidsrechterOverview_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvScheidsrechter;
        private System.Windows.Forms.Button btnVerwijderen;
        private System.Windows.Forms.Button btnWijzigen;
        private System.Windows.Forms.Button btnToevoegen;
        private System.Windows.Forms.Label label2;
    }
}