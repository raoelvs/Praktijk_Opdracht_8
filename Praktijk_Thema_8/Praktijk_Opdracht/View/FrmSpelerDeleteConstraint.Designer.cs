﻿
namespace Praktijk_Opdracht.View
{
    partial class FrmSpelerDeleteConstraint
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
            this.lblConstraint = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblConstraint
            // 
            this.lblConstraint.AutoSize = true;
            this.lblConstraint.Location = new System.Drawing.Point(12, 46);
            this.lblConstraint.Name = "lblConstraint";
            this.lblConstraint.Size = new System.Drawing.Size(354, 30);
            this.lblConstraint.TabIndex = 11;
            this.lblConstraint.Text = "Deze speler heeft een relatie met een andere tabel wil je hem toch \r\nverwijderen?" +
    " \r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 28);
            this.label1.TabIndex = 10;
            this.label1.Text = "Speler verwijderen?";
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(325, 103);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 9;
            this.btnYes.Text = "Ja";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(12, 103);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.TabIndex = 8;
            this.btnNo.Text = "Nee";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // FrmSpelerDeleteConstraint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 133);
            this.Controls.Add(this.lblConstraint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.btnNo);
            this.Name = "FrmSpelerDeleteConstraint";
            this.Text = "FrmSpelerDeleteConstraint";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConstraint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
    }
}