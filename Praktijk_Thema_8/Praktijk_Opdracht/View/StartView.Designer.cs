
namespace Praktijk_Opdracht
{
    partial class StartView
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExportCSV = new System.Windows.Forms.Button();
            this.btnInlog = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pContainer = new System.Windows.Forms.Panel();
            this.pForms = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.pForms.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.BackColor = System.Drawing.Color.Silver;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(173, 40);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Sluiten";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExportCSV
            // 
            this.btnExportCSV.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportCSV.Location = new System.Drawing.Point(607, 0);
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.Size = new System.Drawing.Size(173, 40);
            this.btnExportCSV.TabIndex = 1;
            this.btnExportCSV.Text = "CSV exporteren";
            this.btnExportCSV.UseVisualStyleBackColor = true;
            this.btnExportCSV.Click += new System.EventHandler(this.btnExportCSV_Click);
            // 
            // btnInlog
            // 
            this.btnInlog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInlog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInlog.Location = new System.Drawing.Point(1209, 0);
            this.btnInlog.Name = "btnInlog";
            this.btnInlog.Size = new System.Drawing.Size(173, 40);
            this.btnInlog.TabIndex = 2;
            this.btnInlog.Text = "Inloggen";
            this.btnInlog.UseVisualStyleBackColor = true;
            this.btnInlog.Click += new System.EventHandler(this.btnInlog_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnInlog);
            this.panel1.Controls.Add(this.btnExportCSV);
            this.panel1.Location = new System.Drawing.Point(0, 667);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1385, 40);
            this.panel1.TabIndex = 3;
            // 
            // pContainer
            // 
            this.pContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pContainer.Location = new System.Drawing.Point(3, 3);
            this.pContainer.Name = "pContainer";
            this.pContainer.Size = new System.Drawing.Size(1382, 665);
            this.pContainer.TabIndex = 4;
            // 
            // pForms
            // 
            this.pForms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pForms.Controls.Add(this.panel1);
            this.pForms.Controls.Add(this.pContainer);
            this.pForms.Location = new System.Drawing.Point(1, 1);
            this.pForms.Name = "pForms";
            this.pForms.Size = new System.Drawing.Size(1382, 707);
            this.pForms.TabIndex = 0;
            // 
            // StartView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1384, 708);
            this.Controls.Add(this.pForms);
            this.Name = "StartView";
            this.Text = "De Vluggehandjes";
            this.Load += new System.EventHandler(this.StartView_Load);
            this.panel1.ResumeLayout(false);
            this.pForms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExportCSV;
        private System.Windows.Forms.Button btnInlog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pContainer;
        private System.Windows.Forms.Panel pForms;
    }
}

