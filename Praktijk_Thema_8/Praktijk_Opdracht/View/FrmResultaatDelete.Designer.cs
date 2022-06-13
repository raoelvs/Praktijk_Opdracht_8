
namespace Praktijk_Opdracht.View
{
    partial class FrmResultaatDelete
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(334, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Weet u zeker dat u de Resultaat wilt verwijderen?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 35);
            this.label1.TabIndex = 6;
            this.label1.Text = "Resultaat verwijderen?";
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(369, 145);
            this.btnYes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(86, 31);
            this.btnYes.TabIndex = 5;
            this.btnYes.Text = "Ja";
            this.btnYes.UseVisualStyleBackColor = true;
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(12, 144);
            this.btnNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(86, 31);
            this.btnNo.TabIndex = 4;
            this.btnNo.Text = "Nee";
            this.btnNo.UseVisualStyleBackColor = true;
            // 
            // FrmResultaatDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 233);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.btnNo);
            this.Name = "FrmResultaatDelete";
            this.Text = "FrmResultaatDelete";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
    }
}