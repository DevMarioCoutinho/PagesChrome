
namespace PagesChrome
{
    partial class OptionsForm
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
            this.btnFacebook = new System.Windows.Forms.Button();
            this.btnHotmail = new System.Windows.Forms.Button();
            this.btnGmail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFacebook
            // 
            this.btnFacebook.Location = new System.Drawing.Point(12, 26);
            this.btnFacebook.Name = "btnFacebook";
            this.btnFacebook.Size = new System.Drawing.Size(226, 57);
            this.btnFacebook.TabIndex = 0;
            this.btnFacebook.Text = "Facebook";
            this.btnFacebook.UseVisualStyleBackColor = true;
            this.btnFacebook.Click += new System.EventHandler(this.btnFacebook_Click);
            // 
            // btnHotmail
            // 
            this.btnHotmail.Location = new System.Drawing.Point(12, 89);
            this.btnHotmail.Name = "btnHotmail";
            this.btnHotmail.Size = new System.Drawing.Size(226, 57);
            this.btnHotmail.TabIndex = 1;
            this.btnHotmail.Text = "Hotmail";
            this.btnHotmail.UseVisualStyleBackColor = true;
            this.btnHotmail.Click += new System.EventHandler(this.btnHotmail_Click);
            // 
            // btnGmail
            // 
            this.btnGmail.Location = new System.Drawing.Point(12, 152);
            this.btnGmail.Name = "btnGmail";
            this.btnGmail.Size = new System.Drawing.Size(226, 56);
            this.btnGmail.TabIndex = 2;
            this.btnGmail.Text = "Gmail";
            this.btnGmail.UseVisualStyleBackColor = true;
            this.btnGmail.Click += new System.EventHandler(this.btnGmail_Click);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 284);
            this.Controls.Add(this.btnGmail);
            this.Controls.Add(this.btnHotmail);
            this.Controls.Add(this.btnFacebook);
            this.Name = "OptionsForm";
            this.Text = "Paginas do Chrome";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFacebook;
        private System.Windows.Forms.Button btnHotmail;
        private System.Windows.Forms.Button btnGmail;
    }
}

