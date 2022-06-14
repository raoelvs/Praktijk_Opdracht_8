
namespace Praktijk_Opdracht.View
{
    partial class FrmSpelersOverview
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
            this.btnClearfilter = new System.Windows.Forms.Button();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lvSpeler = new System.Windows.Forms.ListView();
            this.btnVerwijderen = new System.Windows.Forms.Button();
            this.btnWijzigen = new System.Windows.Forms.Button();
            this.btnToevoegen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClearfilter
            // 
            this.btnClearfilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearfilter.BackColor = System.Drawing.Color.Silver;
            this.btnClearfilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearfilter.Location = new System.Drawing.Point(487, 12);
            this.btnClearfilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClearfilter.Name = "btnClearfilter";
            this.btnClearfilter.Size = new System.Drawing.Size(198, 56);
            this.btnClearfilter.TabIndex = 17;
            this.btnClearfilter.Text = "Filter verwijderen";
            this.btnClearfilter.UseVisualStyleBackColor = false;
            this.btnClearfilter.Click += new System.EventHandler(this.btnClearfilter_Click);
            // 
            // cbFilter
            // 
            this.cbFilter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbFilter.BackColor = System.Drawing.Color.DimGray;
            this.cbFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFilter.ForeColor = System.Drawing.Color.Orange;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Location = new System.Drawing.Point(261, 27);
            this.cbFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(204, 28);
            this.cbFilter.TabIndex = 16;
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.BackColor = System.Drawing.Color.Silver;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Location = new System.Drawing.Point(691, 12);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(198, 56);
            this.btnFilter.TabIndex = 15;
            this.btnFilter.Text = "Filteren";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(158, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Filter op speler";
            // 
            // lvSpeler
            // 
            this.lvSpeler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSpeler.BackColor = System.Drawing.SystemColors.Window;
            this.lvSpeler.BackgroundImageTiled = true;
            this.lvSpeler.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvSpeler.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lvSpeler.HideSelection = false;
            this.lvSpeler.Location = new System.Drawing.Point(14, 83);
            this.lvSpeler.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvSpeler.Name = "lvSpeler";
            this.lvSpeler.Size = new System.Drawing.Size(875, 392);
            this.lvSpeler.TabIndex = 13;
            this.lvSpeler.UseCompatibleStateImageBehavior = false;
            this.lvSpeler.SelectedIndexChanged += new System.EventHandler(this.lvSpeler_SelectedIndexChanged);
            // 
            // btnVerwijderen
            // 
            this.btnVerwijderen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerwijderen.BackColor = System.Drawing.Color.Silver;
            this.btnVerwijderen.Enabled = false;
            this.btnVerwijderen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerwijderen.Location = new System.Drawing.Point(691, 491);
            this.btnVerwijderen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnVerwijderen.Name = "btnVerwijderen";
            this.btnVerwijderen.Size = new System.Drawing.Size(198, 56);
            this.btnVerwijderen.TabIndex = 12;
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
            this.btnWijzigen.Location = new System.Drawing.Point(370, 491);
            this.btnWijzigen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWijzigen.Name = "btnWijzigen";
            this.btnWijzigen.Size = new System.Drawing.Size(198, 56);
            this.btnWijzigen.TabIndex = 11;
            this.btnWijzigen.Text = "Wijzigen";
            this.btnWijzigen.UseVisualStyleBackColor = false;
            this.btnWijzigen.Click += new System.EventHandler(this.btnWijzigen_Click);
            // 
            // btnToevoegen
            // 
            this.btnToevoegen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnToevoegen.BackColor = System.Drawing.Color.Silver;
            this.btnToevoegen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToevoegen.Location = new System.Drawing.Point(14, 491);
            this.btnToevoegen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnToevoegen.Name = "btnToevoegen";
            this.btnToevoegen.Size = new System.Drawing.Size(198, 56);
            this.btnToevoegen.TabIndex = 10;
            this.btnToevoegen.Text = "Toevoegen";
            this.btnToevoegen.UseVisualStyleBackColor = false;
            this.btnToevoegen.Click += new System.EventHandler(this.btnToevoegen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(14, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 32);
            this.label2.TabIndex = 9;
            this.label2.Text = "Spelers:";
            // 
            // FrmSpelersOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(904, 557);
            this.Controls.Add(this.btnClearfilter);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvSpeler);
            this.Controls.Add(this.btnVerwijderen);
            this.Controls.Add(this.btnWijzigen);
            this.Controls.Add(this.btnToevoegen);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmSpelersOverview";
            this.Text = "Kickbokstoernooi de vlugge handjes";
            this.Load += new System.EventHandler(this.Spelers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClearfilter;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvSpeler;
        private System.Windows.Forms.Button btnVerwijderen;
        private System.Windows.Forms.Button btnWijzigen;
        private System.Windows.Forms.Button btnToevoegen;
        private System.Windows.Forms.Label label2;
    }
}