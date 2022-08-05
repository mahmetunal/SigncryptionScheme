
namespace SigncryptionProposed
{
    partial class MainPageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPageForm));
            this.btnShowInformation = new System.Windows.Forms.Button();
            this.infoAboutProgram = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelEnd = new System.Windows.Forms.Label();
            this.kclLogo = new System.Windows.Forms.PictureBox();
            this.kclLogoEnd = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kclLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kclLogoEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShowInformation
            // 
            this.btnShowInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowInformation.BackColor = System.Drawing.Color.Firebrick;
            this.btnShowInformation.FlatAppearance.BorderSize = 0;
            this.btnShowInformation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnShowInformation.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnShowInformation.ForeColor = System.Drawing.Color.White;
            this.btnShowInformation.Location = new System.Drawing.Point(340, 251);
            this.btnShowInformation.Name = "btnShowInformation";
            this.btnShowInformation.Size = new System.Drawing.Size(180, 57);
            this.btnShowInformation.TabIndex = 0;
            this.btnShowInformation.Text = "Make a Comparison";
            this.btnShowInformation.UseVisualStyleBackColor = false;
            this.btnShowInformation.Click += new System.EventHandler(this.btnShowInformation_Click);
            // 
            // infoAboutProgram
            // 
            this.infoAboutProgram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoAboutProgram.AutoSize = true;
            this.infoAboutProgram.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.infoAboutProgram.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.infoAboutProgram.ForeColor = System.Drawing.Color.Black;
            this.infoAboutProgram.Location = new System.Drawing.Point(188, 186);
            this.infoAboutProgram.Name = "infoAboutProgram";
            this.infoAboutProgram.Size = new System.Drawing.Size(498, 40);
            this.infoAboutProgram.TabIndex = 1;
            this.infoAboutProgram.Text = "You can compare this signcryption scheme with the Sdss1 and Sdss2 \nschemes by pre" +
    "ssıng the button below";
            this.infoAboutProgram.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 6;
            // 
            // labelEnd
            // 
            this.labelEnd.AutoSize = true;
            this.labelEnd.BackColor = System.Drawing.Color.White;
            this.labelEnd.ForeColor = System.Drawing.Color.Black;
            this.labelEnd.Location = new System.Drawing.Point(167, 412);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(533, 20);
            this.labelEnd.TabIndex = 3;
            this.labelEnd.Text = "Produced by Mahmut Ahmet UNAL - King\'s College London MSc Cyber Security";
            // 
            // kclLogo
            // 
            this.kclLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("kclLogo.BackgroundImage")));
            this.kclLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.kclLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.kclLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("kclLogo.InitialImage")));
            this.kclLogo.Location = new System.Drawing.Point(0, 0);
            this.kclLogo.Name = "kclLogo";
            this.kclLogo.Size = new System.Drawing.Size(856, 107);
            this.kclLogo.TabIndex = 4;
            this.kclLogo.TabStop = false;
            // 
            // kclLogoEnd
            // 
            this.kclLogoEnd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("kclLogoEnd.BackgroundImage")));
            this.kclLogoEnd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kclLogoEnd.InitialImage = ((System.Drawing.Image)(resources.GetObject("kclLogoEnd.InitialImage")));
            this.kclLogoEnd.Location = new System.Drawing.Point(0, 447);
            this.kclLogoEnd.Name = "kclLogoEnd";
            this.kclLogoEnd.Size = new System.Drawing.Size(856, 105);
            this.kclLogoEnd.TabIndex = 7;
            this.kclLogoEnd.TabStop = false;
            // 
            // MainPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(856, 552);
            this.Controls.Add(this.kclLogoEnd);
            this.Controls.Add(this.kclLogo);
            this.Controls.Add(this.labelEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.infoAboutProgram);
            this.Controls.Add(this.btnShowInformation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainPageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Signcryption Proposed";
            ((System.ComponentModel.ISupportInitialize)(this.kclLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kclLogoEnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowInformation;
        private System.Windows.Forms.Label infoAboutProgram;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelEnd;
        private System.Windows.Forms.PictureBox kclLogo;
        private System.Windows.Forms.PictureBox kclLogoEnd;
    }
}

