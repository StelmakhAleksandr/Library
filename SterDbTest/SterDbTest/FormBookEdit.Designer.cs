namespace SterDbTest
{
    partial class FormBookEdit
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
            this.lid = new System.Windows.Forms.Label();
            this.ltitle = new System.Windows.Forms.Label();
            this.ttitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bok = new System.Windows.Forms.Button();
            this.bcanel = new System.Windows.Forms.Button();
            this.cautor = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lid
            // 
            this.lid.AutoSize = true;
            this.lid.Location = new System.Drawing.Point(12, 9);
            this.lid.Name = "lid";
            this.lid.Size = new System.Drawing.Size(35, 13);
            this.lid.TabIndex = 0;
            this.lid.Text = "label1";
            // 
            // ltitle
            // 
            this.ltitle.AutoSize = true;
            this.ltitle.Location = new System.Drawing.Point(12, 39);
            this.ltitle.Name = "ltitle";
            this.ltitle.Size = new System.Drawing.Size(40, 13);
            this.ltitle.TabIndex = 1;
            this.ltitle.Text = "Книга:";
            // 
            // ttitle
            // 
            this.ttitle.Location = new System.Drawing.Point(67, 36);
            this.ttitle.Name = "ttitle";
            this.ttitle.Size = new System.Drawing.Size(155, 20);
            this.ttitle.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Автор:";
            // 
            // bok
            // 
            this.bok.Location = new System.Drawing.Point(57, 190);
            this.bok.Name = "bok";
            this.bok.Size = new System.Drawing.Size(63, 23);
            this.bok.TabIndex = 4;
            this.bok.Text = "Ок";
            this.bok.UseVisualStyleBackColor = true;
            this.bok.Click += new System.EventHandler(this.bok_Click);
            // 
            // bcanel
            // 
            this.bcanel.Location = new System.Drawing.Point(138, 190);
            this.bcanel.Name = "bcanel";
            this.bcanel.Size = new System.Drawing.Size(68, 23);
            this.bcanel.TabIndex = 5;
            this.bcanel.Text = "Отмена";
            this.bcanel.UseVisualStyleBackColor = true;
            this.bcanel.Click += new System.EventHandler(this.bcanel_Click);
            // 
            // cautor
            // 
            this.cautor.FormattingEnabled = true;
            this.cautor.Location = new System.Drawing.Point(67, 75);
            this.cautor.Name = "cautor";
            this.cautor.Size = new System.Drawing.Size(155, 21);
            this.cautor.TabIndex = 6;
            // 
            // FormBookEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 235);
            this.Controls.Add(this.cautor);
            this.Controls.Add(this.bcanel);
            this.Controls.Add(this.bok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ttitle);
            this.Controls.Add(this.ltitle);
            this.Controls.Add(this.lid);
            this.Name = "FormBookEdit";
            this.Text = "Книга";
            this.Load += new System.EventHandler(this.FormBookEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lid;
        private System.Windows.Forms.Label ltitle;
        private System.Windows.Forms.TextBox ttitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bok;
        private System.Windows.Forms.Button bcanel;
        private System.Windows.Forms.ComboBox cautor;
    }
}