namespace SterDbTest
{
    partial class FormBooks
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
            this.lbBooks = new System.Windows.Forms.ListBox();
            this.badd = new System.Windows.Forms.Button();
            this.bedit = new System.Windows.Forms.Button();
            this.bdel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbBooks
            // 
            this.lbBooks.FormattingEnabled = true;
            this.lbBooks.Location = new System.Drawing.Point(3, 1);
            this.lbBooks.Name = "lbBooks";
            this.lbBooks.Size = new System.Drawing.Size(156, 225);
            this.lbBooks.TabIndex = 0;
            // 
            // badd
            // 
            this.badd.Location = new System.Drawing.Point(165, 12);
            this.badd.Name = "badd";
            this.badd.Size = new System.Drawing.Size(99, 23);
            this.badd.TabIndex = 1;
            this.badd.Text = "Додати";
            this.badd.UseVisualStyleBackColor = true;
            this.badd.Click += new System.EventHandler(this.badd_Click);
            // 
            // bedit
            // 
            this.bedit.Location = new System.Drawing.Point(165, 41);
            this.bedit.Name = "bedit";
            this.bedit.Size = new System.Drawing.Size(99, 23);
            this.bedit.TabIndex = 2;
            this.bedit.Text = "Редагувати";
            this.bedit.UseVisualStyleBackColor = true;
            this.bedit.Click += new System.EventHandler(this.bedit_Click);
            // 
            // bdel
            // 
            this.bdel.Location = new System.Drawing.Point(166, 71);
            this.bdel.Name = "bdel";
            this.bdel.Size = new System.Drawing.Size(98, 23);
            this.bdel.TabIndex = 3;
            this.bdel.Text = "Видалити";
            this.bdel.UseVisualStyleBackColor = true;
            this.bdel.Click += new System.EventHandler(this.bdel_Click);
            // 
            // FormBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 228);
            this.Controls.Add(this.bdel);
            this.Controls.Add(this.bedit);
            this.Controls.Add(this.badd);
            this.Controls.Add(this.lbBooks);
            this.Name = "FormBooks";
            this.Text = "Книги";
            this.Load += new System.EventHandler(this.FormBooks_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbBooks;
        private System.Windows.Forms.Button badd;
        private System.Windows.Forms.Button bedit;
        private System.Windows.Forms.Button bdel;
    }
}