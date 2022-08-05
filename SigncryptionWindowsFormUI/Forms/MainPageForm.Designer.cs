
using SigncryptionProposed.Forms;

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
            this.executionTimeLabel = new System.Windows.Forms.Label();
            this.executionTimeButton = new System.Windows.Forms.Button();
            this.loopCountLabel = new System.Windows.Forms.Label();
            this.loopCount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.kclLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kclLogoEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loopCount)).BeginInit();
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
            this.btnShowInformation.Location = new System.Drawing.Point(530, 288);
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
            this.infoAboutProgram.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.infoAboutProgram.ForeColor = System.Drawing.Color.Black;
            this.infoAboutProgram.Location = new System.Drawing.Point(483, 359);
            this.infoAboutProgram.Name = "infoAboutProgram";
            this.infoAboutProgram.Size = new System.Drawing.Size(275, 60);
            this.infoAboutProgram.TabIndex = 1;
            this.infoAboutProgram.Text = "You can compare this signcryption \r\nscheme with the Sdss1 and Sdss2 \r\nschemes by " +
    "clicking the button above";
            this.infoAboutProgram.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 11;
            // 
            // labelEnd
            // 
            this.labelEnd.AutoSize = true;
            this.labelEnd.BackColor = System.Drawing.Color.Transparent;
            this.labelEnd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelEnd.ForeColor = System.Drawing.Color.Firebrick;
            this.labelEnd.Location = new System.Drawing.Point(221, 110);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(426, 20);
            this.labelEnd.TabIndex = 3;
            this.labelEnd.Text = "Produced by Mahmut Ahmet Unal - KCL Cyber Security MSc";
            this.labelEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // executionTimeLabel
            // 
            this.executionTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.executionTimeLabel.AutoSize = true;
            this.executionTimeLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.executionTimeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.executionTimeLabel.ForeColor = System.Drawing.Color.Black;
            this.executionTimeLabel.Location = new System.Drawing.Point(64, 359);
            this.executionTimeLabel.Name = "executionTimeLabel";
            this.executionTimeLabel.Size = new System.Drawing.Size(311, 60);
            this.executionTimeLabel.TabIndex = 10;
            this.executionTimeLabel.Text = "You can compare the execution times \r\nof the scheme proposed for each execution\r\n" +
    "by clicking the button above";
            this.executionTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // executionTimeButton
            // 
            this.executionTimeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.executionTimeButton.BackColor = System.Drawing.Color.Firebrick;
            this.executionTimeButton.FlatAppearance.BorderSize = 0;
            this.executionTimeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.executionTimeButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.executionTimeButton.ForeColor = System.Drawing.Color.White;
            this.executionTimeButton.Location = new System.Drawing.Point(122, 288);
            this.executionTimeButton.Name = "executionTimeButton";
            this.executionTimeButton.Size = new System.Drawing.Size(180, 57);
            this.executionTimeButton.TabIndex = 9;
            this.executionTimeButton.Text = "See Execution Times";
            this.executionTimeButton.UseVisualStyleBackColor = false;
            this.executionTimeButton.Click += new System.EventHandler(this.executionTimeButton_Click);
            // 
            // loopCountLabel
            // 
            this.loopCountLabel.AutoSize = true;
            this.loopCountLabel.BackColor = System.Drawing.Color.Transparent;
            this.loopCountLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.loopCountLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.loopCountLabel.Location = new System.Drawing.Point(202, 161);
            this.loopCountLabel.Name = "loopCountLabel";
            this.loopCountLabel.Size = new System.Drawing.Size(464, 60);
            this.loopCountLabel.TabIndex = 13;
            this.loopCountLabel.Text = "You can specify how many times this program loops for each file.\r\nThe more it loo" +
    "ps, the better result it gets.\r\nHowever, it could take significant time.";
            this.loopCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loopCount
            // 
            this.loopCount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.loopCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.loopCount.ForeColor = System.Drawing.Color.Firebrick;
            this.loopCount.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.loopCount.Location = new System.Drawing.Point(350, 238);
            this.loopCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.loopCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.loopCount.Name = "loopCount";
            this.loopCount.Size = new System.Drawing.Size(150, 27);
            this.loopCount.TabIndex = 14;
            this.loopCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.loopCount.ValueChanged += new System.EventHandler(this.loopCount_ValueChanged);
            // 
            // MainPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(856, 552);
            this.Controls.Add(this.loopCount);
            this.Controls.Add(this.loopCountLabel);
            this.Controls.Add(this.executionTimeLabel);
            this.Controls.Add(this.executionTimeButton);
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
            ((System.ComponentModel.ISupportInitialize)(this.loopCount)).EndInit();
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
        private System.Windows.Forms.Label executionTimeLabel;
        private System.Windows.Forms.Button executionTimeButton;
        private System.Windows.Forms.Label loopCountLabel;
        private System.Windows.Forms.NumericUpDown loopCount;
    }
}

